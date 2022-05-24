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
    public partial class frm_PhieuNhapChiTiet : Form
    {
        public frm_PhieuNhapChiTiet()
        {
            InitializeComponent();
        }

        private void frm_DonNhapChiTiet_Load(object sender, EventArgs e)
        {

            loaddatagridview();
            txtSoPN.Enabled = txtTongTien.Enabled = false;

            if(frm_PhieuNhap.insert_update == "U")
            {
                txtSoPN.Text = frm_PhieuNhap.SoPN;
                cbbMakho.SelectedValue = frm_PhieuNhap.MaKho.Trim();
                dtpNgayNhap.Value = frm_PhieuNhap.NgayNhap;
                cbbDonMua.SelectedValue = frm_PhieuNhap.SoDM.Trim();
                txtTongTien.Text = frm_PhieuNhap.TongTien.ToString();
                DataTable dt_load_danhsach = new DataTable();
                dt_load_danhsach = Class.cl_load.loaddl("select MaHang,SLNhap,GiaNhap,ThanhTien from PHIEUNHAPCHITIET where SoPN='" + frm_PhieuNhap.SoPN + "'");
                for (int i = 0; i < dt_load_danhsach.Rows.Count; i++)
                {
                    string[] row = new string[]
                    { dt_load_danhsach.Rows[i][0].ToString(),dt_load_danhsach.Rows[i][1].ToString(),dt_load_danhsach.Rows[i][2].ToString(),dt_load_danhsach.Rows[i][3].ToString() };
                    dgvHanghoa.Rows.Add(row);
                }
            }
            else
            {
                txtSoPN.Text = String.Format("{0:ddmmhhmmss}", DateTime.Now);

            }
        }
        private void loaddatagridview()
        {
            //tạo cột cho datagridview dgvHangHoa
            //tạo cột Tên Hàng
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
            dgvc_SoLuong.Name = "PHIEUNHAPCHITIET.SLNhap";
            dgvc_SoLuong.Width = 120;
            dgvc_SoLuong.CellTemplate = cell;
            dgvHanghoa.Columns.Add(dgvc_SoLuong);

            //cột giá nhập
            DataGridViewColumn dgvc_GiaNhap = new DataGridViewColumn();
            dgvc_GiaNhap.HeaderText = "Giá Nhập";
            dgvc_GiaNhap.Name = "PHIEUNHAPCHITIET.GiaNhap";
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
            dt_NCC = Class.cl_load.loaddl("select * from DONMUA");
            cbbDonMua.DataSource = dt_NCC;
            cbbDonMua.ValueMember = "SoDM";
            cbbDonMua.DisplayMember = "SoDM";


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
                    dgvHanghoa.CurrentRow.Cells[2].Value = dt_HangHoa.Rows[0][0];
                    dgvHanghoa.CurrentRow.Cells[3].Value = dt_HangHoa.Rows[0][0];
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

        private void Reset_Click(object sender, EventArgs e)
        {
            txtSoPN.ResetText();
            txtTongTien.ResetText();
            dtpNgayNhap.Value = DateTime.Now;
            cbbMakho.SelectedIndex = 0;
            cbbDonMua.SelectedIndex = 0;
            dgvHanghoa.Rows.Clear();
            //dgvHanghoa.Refresh();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frm_PhieuNhap d = new frm_PhieuNhap();
            this.Hide();
            d.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(frm_PhieuNhap.insert_update == "U")
            {
                int update_PhieuNhap = Class.cl_load.insert_update_delete("update PHIEUNHAP set MaKho='" +cbbMakho.SelectedValue + "',NgayNhap='" + dtpNgayNhap.Value.ToString("MM/dd/yyyy") + "',TongTienNhap=" + txtTongTien.Text + ",SoDM='"+cbbDonMua.SelectedValue+"' where SoPN='" +txtSoPN.Text.Trim() + "'");
                for (int i = 0; i < dgvHanghoa.RowCount - 1; i++)
                {
                    string mahang = dgvHanghoa.Rows[i].Cells[0].Value.ToString().Trim();
                    int soluong = int.Parse(dgvHanghoa.Rows[i].Cells[1].Value.ToString());
                    int dongia = int.Parse(dgvHanghoa.Rows[i].Cells[2].Value.ToString());
                    int thanhtien = int.Parse(dgvHanghoa.Rows[i].Cells[3].Value.ToString());
                    int update_PhieuNhapChiTiet = Class.cl_load.insert_update_delete("update PHIEUNHAPCHITIET set SLNhap=" + soluong + ",GiaNhap=" + dongia + ",ThanhTien=" + thanhtien + " where SoPN='" + txtSoPN.Text.Trim() + "' and MaHang='" + mahang + "'");
                    DataTable dt2 = Class.cl_load.loaddl("select * from PHIEUNHAPCHITIET where SoPN='" + txtSoPN.Text.Trim() + "' and MaHang='" + mahang + "'");
                    if (dt2.Rows.Count == 0)
                    {
                        int insertPhieuNhapChiTiet = Class.cl_load.insert_update_delete("insert into PHIEUNHAPCHITIET values('" + txtSoPN.Text + "','" + mahang + "'," + soluong + "," + dongia + "," + thanhtien + ")");
                    }
                    DataTable dt3 = Class.cl_load.loaddl("select * from KHOHANG where MaKho='" + cbbMakho.SelectedValue + "' and MaHang='" + mahang + "'");
                    if (dt3.Rows.Count == 0)
                    {
                        int insertKhoHang = Class.cl_load.insert_update_delete("insert into KHOHANG values('" + cbbMakho.SelectedValue + "','" + mahang + "'," + soluong + ",0," + soluong + ")");
                    }
                    else
                    {
                        int updateKhoHang = Class.cl_load.insert_update_delete("update KHOHANG set SLNhap=SLNhap+" + soluong + ",TonKho=TonKho+"+soluong+" where MaHang ='" + mahang + "'");
                    }

                }
                if (update_PhieuNhap > 0)
                {
                    MessageBox.Show("Sửa Phiếu Nhập " + txtSoPN.Text + " thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa Phiếu Nhập " + txtSoPN.Text + "không thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                int insert_PhieuNhap = Class.cl_load.insert_update_delete("insert into PHIEUNHAP values('" +txtSoPN.Text + "','" + dtpNgayNhap.Value + "'," +txtTongTien.Text + ",'"+cbbMakho.SelectedValue+"','"+cbbDonMua.SelectedValue+"')");
                for (int i = 0; i < dgvHanghoa.RowCount - 1; i++)
                {
                    string mahang = dgvHanghoa.Rows[i].Cells[0].Value.ToString();
                    int soluong = int.Parse(dgvHanghoa.Rows[i].Cells[1].Value.ToString());
                    int gianhap = int.Parse(dgvHanghoa.Rows[i].Cells[2].Value.ToString());
                    int thanhtien = int.Parse(dgvHanghoa.Rows[i].Cells[3].Value.ToString());
                    int insert_PhieuNhapChiTiet =Class.cl_load.insert_update_delete("insert into PHIEUNHAPCHITIET values('" + txtSoPN.Text + "','" + mahang + "'," + soluong + "," + gianhap + "," + thanhtien + ")");
                    DataTable dt3 = Class.cl_load.loaddl("select * from KHOHANG where MaKho='" + cbbMakho.SelectedValue + "' and MaHang='" + mahang + "'");
                    if (dt3.Rows.Count == 0)
                    {
                        int insertKhoHang = Class.cl_load.insert_update_delete("insert into KHOHANG values('" + cbbMakho.SelectedValue + "','" + mahang + "'," + soluong + ",0," + soluong + ")");
                    }
                    else
                    {
                        int updateKhoHang = Class.cl_load.insert_update_delete("update KHOHANG set SLNhap=SLNhap+" + soluong + ",TonKho=TonKho+" + soluong + " where MaHang ='" + mahang + "'");
                    }

                }
                if (insert_PhieuNhap > 0)
                {
                    MessageBox.Show("Thêm Phiếu Nhập "+txtSoPN.Text+" thành công ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm Phiếu Nhập " + txtSoPN.Text + "không thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
