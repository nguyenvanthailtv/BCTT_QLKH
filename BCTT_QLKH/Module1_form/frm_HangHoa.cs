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
    public partial class frm_HangHoa : Form
    {
        DataTable dt = new DataTable();
        public frm_HangHoa()
        {
            InitializeComponent();
        }

        private void frm_HangHoa_Load(object sender, EventArgs e)
        {
            loadDatagridview();

            QL.Text = QL.Text + frm_DangNhap.Tenquanly;
        }

        //load dữ liệu cho dgvHanghoa và tạo cột cho dgvHanghoa
        public void loadDatagridview()
        {
            //load dữ liệu vào dgvHanghoa
            dt = Class.cl_load.loaddl("select * from HANGHOA");
            dgvHanghoa.DataSource = dt;

            //Tạo các cột cho dgvHanghoa
            dgvHanghoa.Columns[0].HeaderText = "Mã Hàng";
            dgvHanghoa.Columns[1].HeaderText = "Tên Hàng";
            dgvHanghoa.Columns[2].HeaderText = "Giá Nhập";
            dgvHanghoa.Columns[3].HeaderText = "Mô Tả";
            dgvHanghoa.Columns[4].HeaderText = "Đơn Vị Tính";

            dgvHanghoa.Columns[0].Width = 120;
            dgvHanghoa.Columns[1].Width = 200;
            dgvHanghoa.Columns[2].Width = 150;
            dgvHanghoa.Columns[3].Width = 200;
            dgvHanghoa.Columns[4].Width = 150;

            dgvHanghoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        public bool kiemtra()
        {
            if (txtMahang.Text.Equals(""))
            {
                MessageBox.Show("Mã hàng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTenhang.Text.Equals(""))
            {
                MessageBox.Show("Tên hàng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (nudGiaNhap.Value < 0)
            {
                MessageBox.Show("Giá nhập không được <0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtMota.Text.Equals(""))
            {
                MessageBox.Show("Mô tả không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtDvt.Text.Equals(""))
            {
                MessageBox.Show("Đơn vị tính không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //kiểm tra xem mã Hàng đã tồn tại chưa
                DataTable dtHanghoa = Class.cl_load.loaddl("select * from HANGHOA where MaHang = '" + txtMahang.Text.Trim() + "'");
                if (dtHanghoa.Rows.Count > 0)
                {
                    MessageBox.Show("Mã Hàng " + txtMahang.Text.Trim() + " đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //thêm mới hàng
                int thongbao_them = Class.cl_load.insert_update_delete("insert into HANGHOA values('" + txtMahang.Text.Trim() + "',N'" +txtTenhang.Text.Trim() + "',"+nudGiaNhap.Value+",N'" + txtMota.Text.Trim() + "',N'" + txtDvt.Text.Trim() + "')");
                if (thongbao_them > 0)
                {
                    MessageBox.Show("Thêm mới Hàng " + txtMahang.Text.Trim() + " thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt.Rows.Add(txtMahang.Text.Trim(),txtTenhang.Text,nudGiaNhap.Value,txtMota.Text,txtDvt.Text);
                }
                else
                {
                    MessageBox.Show("Thêm mới Hàng " + txtMahang.Text.Trim() + " không thành công thành công \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Thêm mới Hàng " + txtMahang.Text.Trim() + " không thành công thành công \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvHanghoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chon_hang = e.RowIndex;
            if (chon_hang < dgvHanghoa.Rows.Count - 1 && chon_hang >= 0)
            {
                txtMahang.Text = dgvHanghoa.Rows[chon_hang].Cells[0].Value.ToString().Trim();
                txtTenhang.Text = dgvHanghoa.Rows[chon_hang].Cells[1].Value.ToString().Trim();
                nudGiaNhap.Value = int.Parse(dgvHanghoa.Rows[chon_hang].Cells[2].Value.ToString().Trim());
                txtMota.Text = dgvHanghoa.Rows[chon_hang].Cells[3].Value.ToString().Trim();
                txtDvt.Text = dgvHanghoa.Rows[chon_hang].Cells[4].Value.ToString().Trim();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult thongbao_xoa = MessageBox.Show("Bạn có chắc muốn xóa hàng " + txtMahang.Text.Trim() + " ?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (thongbao_xoa == DialogResult.Yes)
                {
                    int xoa_Hang = Class.cl_load.insert_update_delete("delete from HANGHOA where MaHang='" + txtMahang.Text.Trim() + "'");
                    if (xoa_Hang > 0)
                    {
                        MessageBox.Show("Xóa hàng " + txtMahang.Text.Trim() + " thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvHanghoa.Rows.RemoveAt(dgvHanghoa.CurrentRow.Index);
                    }
                    else
                    {
                        MessageBox.Show("xóa hàng " + txtMahang.Text.Trim() + " không thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtMahang.ResetText();
            txtMota.ResetText();
            txtTenhang.ResetText();
            txtDvt.ResetText();
            nudGiaNhap.Value = 0;
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
                int thongbao_sua = Class.cl_load.insert_update_delete("update HANGHOA set TenHang=N'" + txtTenhang.Text.Trim() + "',GiaNhap="+nudGiaNhap.Value+",MoTaHang=N'" + txtMota.Text.Trim() + "',DVT=N'" + txtDvt.Text.Trim() + "' where MaHang='" + txtMahang.Text.Trim() + "'");
                if (thongbao_sua > 0)
                {
                    MessageBox.Show("Sửa Hàng " + txtMahang.Text + " thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int chon = dgvHanghoa.CurrentRow.Index;
                    dgvHanghoa.Rows[chon].Cells[1].Value = txtTenhang.Text.Trim();
                    dgvHanghoa.Rows[chon].Cells[2].Value = nudGiaNhap.Value;
                    dgvHanghoa.Rows[chon].Cells[3].Value = txtMota.Text.Trim();
                    dgvHanghoa.Rows[chon].Cells[4].Value = txtDvt.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Sửa Hàng " + txtMahang.Text + " không thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
