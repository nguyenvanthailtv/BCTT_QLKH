using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCTT_QLKH.Module1_form
{
    public partial class frm_PhieuGiaoChiTiet : Form
    {
        public frm_PhieuGiaoChiTiet()
        {
            InitializeComponent();
        }

        private void frm_PhieuGiaoChiTiet_Load(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn dgvcbb = new DataGridViewComboBoxColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            DataTable dt_load_HangHoa = new DataTable();
            dt_load_HangHoa = Class.cl_load.loaddl("select * from HANGHOA");
            dgvcbb.DataSource = dt_load_HangHoa;
            dgvcbb.DisplayMember = "TenHang";
            dgvcbb.ValueMember = "MaHang";
            dgvcbb.HeaderText = "Tên Hàng";
            dgvcbb.Width = 150;
            dgvHanghoa.Columns.Add(dgvcbb);

            //cột Số Lượng
            DataGridViewColumn dgvc_SoLuong = new DataGridViewColumn();
            dgvc_SoLuong.HeaderText = "Số Lượng";
            dgvc_SoLuong.Name = "PHIEUNHAPCHITIET.SLGiao";
            dgvc_SoLuong.Width = 120;
            dgvc_SoLuong.CellTemplate = cell;
            dgvHanghoa.Columns.Add(dgvc_SoLuong);

            //cột giá nhập
            DataGridViewColumn dgvc_GiaNhap = new DataGridViewColumn();
            dgvc_GiaNhap.HeaderText = "Giá Giao";
            dgvc_GiaNhap.Name = "PHIEUNHAPCHITIET.SLGiao";
            dgvc_GiaNhap.Width = 120;
            dgvc_GiaNhap.CellTemplate = cell;
            dgvHanghoa.Columns.Add(dgvc_GiaNhap);

            //cột thành tiền
            DataGridViewColumn dgvc_ThanhTien = new DataGridViewColumn();
            dgvc_ThanhTien.HeaderText = "Thành Tiền";
            dgvc_ThanhTien.Width = 120;
            dgvc_ThanhTien.Name = "Thanhtien";
            dgvc_ThanhTien.CellTemplate = cell;
            dgvHanghoa.Columns.Add(dgvc_ThanhTien);

            //load danh sách Kho
            DataTable dt_Kho = new DataTable();
            dt_Kho = Class.cl_load.loaddl("select * from KHO");
            cbbMakho.DataSource = dt_Kho;
            cbbMakho.ValueMember = "MaKho";
            cbbMakho.DisplayMember = "TenKho";
            DataTable dt_NCC = new DataTable();
            dt_NCC = Class.cl_load.loaddl("select * from DONDAT");
            cbbDonMua.DataSource = dt_NCC;
            cbbDonMua.ValueMember = "SoDD";
            cbbDonMua.DisplayMember = "SoDD";


            txtSoPN.Enabled = txtTongTien.Enabled = false;

            if (frm_PhieuGiao.insert_update == "U")
            {
                txtSoPN.Text = frm_PhieuGiao.SoPG;
                cbbMakho.SelectedValue = frm_PhieuGiao.MaKho.Trim();
                dtpNgayNhap.Value = frm_PhieuGiao.NgayGiao;
                cbbDonMua.SelectedValue = frm_PhieuGiao.SoDD.Trim();
                txtTongTien.Text = frm_PhieuGiao.TongTien.ToString();
                DataTable dt_load_danhsach = new DataTable();
                dt_load_danhsach = Class.cl_load.loaddl("select MaHang,SLGiao,GiaGiao,ThanhTien from PHIEUGIAOCHITIET where SoPG='" + frm_PhieuGiao.SoPG + "'");
                for (int i = 0; i < dt_load_danhsach.Rows.Count; i++)
                {
                    string[] row = new string[]
                    { dt_load_danhsach.Rows[i][0].ToString(),dt_load_danhsach.Rows[i][1].ToString(),dt_load_danhsach.Rows[i][2].ToString(),dt_load_danhsach.Rows[i][3].ToString() };
                    dgvHanghoa.Rows.Add(row);
                }
            }
            else
            {
                txtSoPN.Text = String.Format("PG"+"{0:ddhhmmss}", DateTime.Now);

            }
        }

        private void dgvHanghoa_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt_HangHoa;
            int vitri = e.ColumnIndex;
            if (vitri >= 0)
            {
                if (vitri == 0)
                {
                    dt_HangHoa = Class.cl_load.loaddl("select GiaNhap from HANGHOA where MaHang='" + dgvHanghoa.CurrentRow.Cells[0].Value.ToString().Trim() + "'");
                    dgvHanghoa.CurrentRow.Cells[1].Value = 1;
                    int giagiao = int.Parse(dt_HangHoa.Rows[0][0].ToString());
                    dgvHanghoa.CurrentRow.Cells[2].Value = giagiao*1.1;
                    dgvHanghoa.CurrentRow.Cells[3].Value = giagiao * 1.1;
                }
                if (vitri == 1)
                {
                    int soluong, dongia, thanhtien;
                    soluong = int.Parse(dgvHanghoa.CurrentRow.Cells[1].Value.ToString());
                    dongia = int.Parse(dgvHanghoa.CurrentRow.Cells[2].Value.ToString());
                    
                    thanhtien = soluong * dongia;
                    dgvHanghoa.CurrentRow.Cells[3].Value = thanhtien.ToString();
                }
                int tongtien = 0;
                for (int i = 0; i < dgvHanghoa.Rows.Count - 1; i++)
                {
                    int thanhtien = int.Parse(dgvHanghoa.Rows[i].Cells[3].Value.ToString());
                    tongtien = tongtien + thanhtien;
                    txtTongTien.Text = tongtien.ToString();
                }

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (frm_PhieuGiao.insert_update == "U")
            {
                int update_PhieuGiao = Class.cl_load.insert_update_delete("update PHIEUGIAO set MaKho='" + cbbMakho.SelectedValue + "',NgayGiao='" + dtpNgayNhap.Value.ToString("MM/dd/yyyy") + "',TongTienGiao=" + txtTongTien.Text + ",SoDD='" + cbbDonMua.SelectedValue + "' where SoPG='" + txtSoPN.Text + "'");
                for (int i = 0; i < dgvHanghoa.RowCount - 1; i++)
                {
                    string mahang = dgvHanghoa.Rows[i].Cells[0].Value.ToString().Trim();
                    int soluong = int.Parse(dgvHanghoa.Rows[i].Cells[1].Value.ToString());
                    int dongia = int.Parse(dgvHanghoa.Rows[i].Cells[2].Value.ToString());
                    int thanhtien = int.Parse(dgvHanghoa.Rows[i].Cells[3].Value.ToString());
                    int update_PhieuGiaoChiTiet = Class.cl_load.insert_update_delete("update PHIEUGIAOCHITIET set SLGiao=" + soluong + ",GiaGiao=" + dongia + ",ThanhTien=" + thanhtien + " where SoPG='" + txtSoPN.Text.Trim() + "' and MaHang='" + mahang + "'");
                    DataTable dt2 = Class.cl_load.loaddl("select * from PHIEUGIAOCHITIET where SoPG='" + txtSoPN.Text + "' and MaHang='" + mahang + "'");
                    if (dt2.Rows.Count == 0)
                    {
                        int insertPhieuGiaoChiTiet = Class.cl_load.insert_update_delete("insert into PHIEUGIAOCHITIET values('" + txtSoPN.Text + "','" + mahang + "'," + soluong + "," + dongia + "," + thanhtien + ")");
                    }
                    
                        int updateKhoHang = Class.cl_load.insert_update_delete("update KHOHANG set SLGiao=SLGiao+" + soluong + ",TonKho=TonKho -" + soluong + " where MaHang ='" + mahang + "'");
                    

                }
                if (update_PhieuGiao > 0)
                {
                    MessageBox.Show("Sửa Phiếu Giao " + txtSoPN.Text + " thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa Phiếu Giao " + txtSoPN.Text + "không thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                int insert_PhieuGiao = Class.cl_load.insert_update_delete("insert into PHIEUGIAO values('" + txtSoPN.Text + "','" + dtpNgayNhap.Value + "'," + txtTongTien.Text + ",'" + cbbMakho.SelectedValue + "','" + cbbDonMua.SelectedValue + "')");
                for (int i = 0; i < dgvHanghoa.RowCount - 1; i++)
                {
                    string mahang = dgvHanghoa.Rows[i].Cells[0].Value.ToString();
                    int soluong = int.Parse(dgvHanghoa.Rows[i].Cells[1].Value.ToString());
                    int gianhap = int.Parse(dgvHanghoa.Rows[i].Cells[2].Value.ToString());
                    int thanhtien = int.Parse(dgvHanghoa.Rows[i].Cells[3].Value.ToString());
                    int insert_PhieuGiaoChiTiet = Class.cl_load.insert_update_delete("insert into PHIEUGIAOCHITIET values('" + txtSoPN.Text + "','" + mahang + "'," + soluong + "," + gianhap + "," + thanhtien + ")");
                    int update_KhoHang = Class.cl_load.insert_update_delete("update KHOHANG set SLGiao=SLGiao+" + soluong + " , TonKho = TonKho - " + soluong + " where MaHang ='" + mahang + "'");
                }
                if (insert_PhieuGiao > 0)
                {
                    MessageBox.Show("Thêm Phiếu Giao " + txtSoPN.Text + " thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm Phiếu Giao " + txtSoPN.Text + "không thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frm_PhieuGiao h = new frm_PhieuGiao();
            this.Hide();
            h.ShowDialog();
        }
    }
}
