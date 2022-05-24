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
    public partial class frm_Kho : Form
    {
        DataTable dt = new DataTable();

        public frm_Kho()
        {
            InitializeComponent();
        }
        //load dữ liệu cho dgvkho và tạo cột cho dgvkho
        public void loadDatagridview()
        {
            //load dữ liệu vào dgvKho
            dt = Class.cl_load.loaddl("select * from KHO");
            dgvKho.DataSource = dt;

            //Tạo các cột cho dgvKho
            dgvKho.Columns[0].HeaderText = "Mã Kho";
            dgvKho.Columns[1].HeaderText = "Tên Kho";
            dgvKho.Columns[2].HeaderText = "Địa Chỉ";

            dgvKho.Columns[0].Width = 150;
            dgvKho.Columns[1].Width = 150;
            dgvKho.Columns[2].Width = 445;

            dgvKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
        }

        private void frm_Kho_Load(object sender, EventArgs e)
        {
            loadDatagridview();
            QL.Text = QL.Text + frm_DangNhap.Tenquanly;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            //xóa sạch dữ liệu trong các ô nhập dữ liệu
            txtDiachi.ResetText();
            txtMakho.ResetText();
            txtTenkho.ResetText();
        }
        
        public bool kiemtra()
        {
          
            
            if (txtMakho.Text.Equals(""))
            {
                MessageBox.Show("Mã Kho không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTenkho.Text.Equals(""))
            {
                MessageBox.Show("Tên Kho không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtDiachi.Text.Equals(""))
            {
                MessageBox.Show("Địa chỉ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra xem điền đầy đủ thông tin hay không
                if (kiemtra() == false)
                {
                    return;
                }

                //kiểm tra xem mã kho đã tồn tại chưa
                DataTable dtkho = Class.cl_load.loaddl("select * from KHO where MaKho = '"+txtMakho.Text.Trim()+"'");
                if (dtkho.Rows.Count > 0)
                {
                    MessageBox.Show("Mã kho "+txtMakho.Text.Trim()+" đã tồn tại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }

                //thêm mới kho hàng
                int thongbao_them = Class.cl_load.insert_update_delete("insert into KHO values('" + txtMakho.Text.Trim() + "',N'" + txtTenkho.Text.Trim() + "',N'" + txtDiachi.Text.Trim() + "')");
                if(thongbao_them > 0)
                {
                    MessageBox.Show("Thêm mới kho "+txtMakho.Text.Trim()+" thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt.Rows.Add(txtMakho.Text.Trim(), txtTenkho.Text.Trim(), txtDiachi.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Thêm mới kho " + txtMakho.Text.Trim() + " không thành công thành công \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Thêm mới kho " + txtMakho.Text.Trim() + " không thành công thành công \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chon_hang = e.RowIndex;
            if(chon_hang < dgvKho.Rows.Count - 1 && chon_hang >=0)
            {
                txtMakho.Text = dgvKho.Rows[chon_hang].Cells[0].Value.ToString().Trim();
                txtTenkho.Text = dgvKho.Rows[chon_hang].Cells[1].Value.ToString().Trim();
                txtDiachi.Text = dgvKho.Rows[chon_hang].Cells[2].Value.ToString().Trim();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult thongbao_xoa = MessageBox.Show("Bạn có chắc muốn xóa kho "+txtMakho.Text.Trim()+" ?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (thongbao_xoa == DialogResult.Yes)
                {
                    int xoa_kho = Class.cl_load.insert_update_delete("delete from KHO where MaKho='" + txtMakho.Text.Trim() + "'");
                    if (xoa_kho > 0)
                    {
                        MessageBox.Show("Xóa kho " + txtMakho.Text.Trim() + " thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvKho.Rows.RemoveAt(dgvKho.CurrentRow.Index);
                    }
                    else
                    {
                        MessageBox.Show("xóa kho " + txtMakho.Text + " không thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi vui lòng kiểm tra lại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra xem điền đầy đủ thông tin hay không
                if (kiemtra() == false)
                {
                    return;
                }
                int thongbao_sua = Class.cl_load.insert_update_delete("update KHO set TenKho=N'"+txtTenkho.Text.Trim()+"',DiaChi=N'"+txtDiachi.Text.Trim()+"' where MaKho='"+txtMakho.Text.Trim()+"'");
                if(thongbao_sua > 0)
                {
                    MessageBox.Show("Sửa kho " + txtMakho.Text.Trim() + " thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int chon = dgvKho.CurrentRow.Index;
                    dgvKho.Rows[chon].Cells[1].Value = txtTenkho.Text.Trim();
                    dgvKho.Rows[chon].Cells[2].Value = txtDiachi.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Sửa kho " + txtMakho.Text.Trim() + " không thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi vui lòng kiểm tra lại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DanhMuc1_Click(object sender, EventArgs e)
        {
            frm_Main h = new frm_Main();
            this.Hide();
            h.ShowDialog();
        }

        private void khoHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_Kho k = new frm_Kho();
            this.Hide();
            k.ShowDialog();

        }

        private void hàngTồnKhoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_KhoHang k = new frm_KhoHang();
            this.Hide();
            k.ShowDialog();

        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_NhaCungCap m = new frm_NhaCungCap();
            this.Hide();
            m.ShowDialog();

        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_HangHoa h = new frm_HangHoa();
            this.Hide();
            h.ShowDialog();

        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_KhachHang h = new frm_KhachHang();
            this.Hide();
            h.ShowDialog();

        }

        private void đơnMuaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DonMua h = new frm_DonMua();
            this.Hide();
            h.ShowDialog();

        }

        private void phiếuNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_PhieuNhap h = new frm_PhieuNhap();
            this.Hide();
            h.ShowDialog();

        }

        private void phiếuChiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_PhieuChi h = new frm_PhieuChi();
            this.Hide();
            h.ShowDialog();

        }

        private void đơnĐặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DonDat h = new frm_DonDat();
            this.Hide();
            h.ShowDialog();

        }

        private void phiếuGiaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_PhieuGiao h = new frm_PhieuGiao();
            this.Hide();
            h.ShowDialog();

        }

        private void phiếuThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_PhieuThu h = new frm_PhieuThu();
            this.Hide();
            h.ShowDialog();

        }

        private void hàngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Danh_Muc_Tim_Kiem.frm_TimKiemHangNhap h = new Danh_Muc_Tim_Kiem.frm_TimKiemHangNhap();
            this.Hide();
            h.ShowDialog();

        }

        private void hàngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Danh_Muc_Tim_Kiem.frm_TimKiemHangXuat h = new Danh_Muc_Tim_Kiem.frm_TimKiemHangXuat();
            this.Hide();
            h.ShowDialog();

        }

        private void hàngTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Danh_Muc_Tim_Kiem.frm_TimKiemHangTonKho h = new Danh_Muc_Tim_Kiem.frm_TimKiemHangTonKho();
            this.Hide();
            h.ShowDialog();

        }

        private void báoCáoTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Danh_Muc_Bao_Cao.frm_BaoCaoHangTonKho h = new Danh_Muc_Bao_Cao.frm_BaoCaoHangTonKho();
            this.Hide();
            h.ShowDialog();

        }

        private void báoCáoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Danh_Muc_Bao_Cao.frm_BaoCaoDoanhThu h = new Danh_Muc_Bao_Cao.frm_BaoCaoDoanhThu();
            this.Hide();
            h.ShowDialog();

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (tb == DialogResult.Yes) Application.Exit();

        }
    }
}
