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
    public partial class frm_KhachHang : Form
    {
        DataTable dt = new DataTable();
        public frm_KhachHang()
        {
            InitializeComponent();
        }

        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            QL.Text = QL.Text + frm_DangNhap.Tenquanly;

            loadDatagridview();
        }

        //load dữ liệu cho dgvKhachhang và tạo cột cho dgvKhachhang
        public void loadDatagridview()
        {
            //load dữ liệu vào dgvKhachhang
            dt = Class.cl_load.loaddl("select * from KHACHHANG");
            dgvKhachhang.DataSource = dt;

            //Tạo các cột cho dgvKhachhang
            dgvKhachhang.Columns[0].HeaderText = "Mã Khách";
            dgvKhachhang.Columns[1].HeaderText = "Tên Khách";
            dgvKhachhang.Columns[2].HeaderText = "Địa Chỉ";
            dgvKhachhang.Columns[3].HeaderText = "SĐT";

            dgvKhachhang.Columns[0].Width = 120;
            dgvKhachhang.Columns[1].Width = 220;
            dgvKhachhang.Columns[2].Width = 300;
            dgvKhachhang.Columns[3].Width = 150;

            dgvKhachhang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        public bool kiemtra()
        {
           if (txtMakhach.Text.Equals(""))
            {
                MessageBox.Show("Mã khách không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            } 
            
            if (txtTenkhach.Text.Equals(""))
            {
                MessageBox.Show("Tên Khách không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            
            if (txtDiachi.Text.Equals(""))
            {
                MessageBox.Show("Địa chỉ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtSdt.Text.Equals(""))
            {
                MessageBox.Show("Số điện thoại không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //kiểm tra xem ô số điện thoại nhập chữ hay số
                try
                {
                    int test = int.Parse(txtSdt.Text);
                }
                catch
                {
                    MessageBox.Show("Số điện thoại chỉ được nhập số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }
                //kiểm tra xem mã khách đã tồn tại chưa
                DataTable dtKhachhang = Class.cl_load.loaddl("select * from KHACHHANG where MaKhach = '" + txtMakhach.Text.Trim() + "'");
                if (dtKhachhang.Rows.Count > 0)
                {
                    MessageBox.Show("Mã Khách " + txtMakhach.Text.Trim() + " đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //thêm mới khách
                int thongbao_them = Class.cl_load.insert_update_delete("insert into KHACHHANG values('" + txtMakhach.Text.Trim() + "',N'" + txtTenkhach.Text.Trim() + "',N'" + txtDiachi.Text.Trim() + "','" + txtSdt.Text.Trim() + "')");
                if (thongbao_them > 0)
                {
                    MessageBox.Show("Thêm mới Khách " + txtMakhach.Text + " thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt.Rows.Add(txtMakhach.Text, txtTenkhach.Text, txtDiachi.Text, txtSdt.Text);
                }
                else
                {
                    MessageBox.Show("Thêm mới Khách " + txtMakhach.Text + " không thành công thành công \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Thêm mới khách " + txtMakhach.Text + " không thành công thành công \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvKhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chon_hang = e.RowIndex;
            if (chon_hang < dgvKhachhang.Rows.Count - 1 && chon_hang >= 0)
            {
                txtMakhach.Text = dgvKhachhang.Rows[chon_hang].Cells[0].Value.ToString().Trim();
                txtTenkhach.Text = dgvKhachhang.Rows[chon_hang].Cells[1].Value.ToString().Trim();
                txtDiachi.Text = dgvKhachhang.Rows[chon_hang].Cells[2].Value.ToString().Trim();
                txtSdt.Text = dgvKhachhang.Rows[chon_hang].Cells[3].Value.ToString().Trim();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult thongbao_xoa = MessageBox.Show("Bạn có chắc muốn xóa khách " + txtMakhach.Text.Trim() + " ?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (thongbao_xoa == DialogResult.Yes)
                {
                    int xoa_Khach = Class.cl_load.insert_update_delete("delete from KHACHHANG where MaKhach='" + txtMakhach.Text.Trim() + "'");
                    if (xoa_Khach > 0)
                    {
                        MessageBox.Show("Xóa khách " + txtMakhach.Text + " thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvKhachhang.Rows.RemoveAt(dgvKhachhang.CurrentRow.Index);
                    }
                    else
                    {
                        MessageBox.Show("xóa khách " + txtMakhach.Text + " không thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi vui lòng kiểm tra lại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            txtMakhach.ResetText();
            txtSdt.ResetText();
            txtTenkhach.ResetText();
            txtDiachi.ResetText();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frm_Main m = new frm_Main();
            this.Hide();
            m.ShowDialog();
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
                int thongbao_sua = Class.cl_load.insert_update_delete("update KHACHHANG set TenKhach=N'" + txtTenkhach.Text + "',DiaChi=N'" + txtDiachi.Text + "',DienThoai='" + txtSdt.Text.Trim() + "' where MaKhach='" + txtMakhach.Text + "'");
                if (thongbao_sua > 0)
                {
                    MessageBox.Show("Sửa Khách " + txtMakhach.Text + " thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int chon = dgvKhachhang.CurrentRow.Index;
                    dgvKhachhang.Rows[chon].Cells[1].Value = txtTenkhach.Text.Trim();
                    dgvKhachhang.Rows[chon].Cells[2].Value = txtDiachi.Text.Trim();
                    dgvKhachhang.Rows[chon].Cells[3].Value = txtSdt.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Sửa Khách " + txtMakhach.Text + " không thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
