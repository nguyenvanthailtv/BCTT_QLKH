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
    public partial class frm_PhieuNhap : Form
    {
        DataTable dt = new DataTable();
        public static string SoPN;
        public static string MaKho;
        public static string SoDM;
        public static int TongTien;
        public static DateTime NgayNhap;
        public static string insert_update;
        public frm_PhieuNhap()
        {
            InitializeComponent();
        }

        private void frm_DonMua_Load(object sender, EventArgs e)
        {
            QL.Text = QL.Text + frm_DangNhap.Tenquanly;
            dt = Class.cl_load.loaddl("select SoPN,NgayNhap,PHIEUNHAP.MaKho,TenKho,PHIEUNHAP.SoDM,TongTienNhap from PHIEUNHAP inner join KHO on KHO.MaKho = PHIEUNHAP.MaKho");
            dgvPhieuNhap.DataSource = dt;
   
            dgvPhieuNhap.Columns[0].HeaderText = "Số Phiếu Nhập";
            dgvPhieuNhap.Columns[1].HeaderText = "Ngày Nhập";
            dgvPhieuNhap.Columns[2].HeaderText = "Mã Kho";
            dgvPhieuNhap.Columns[3].HeaderText = "Tên Kho";
            dgvPhieuNhap.Columns[4].HeaderText = "Số Đơn Mua";
            dgvPhieuNhap.Columns[5].HeaderText = "Tổng Tiền Nhập";

            dgvPhieuNhap.Columns[0].Width = 120;
            dgvPhieuNhap.Columns[1].Width = 120;
            dgvPhieuNhap.Columns[2].Width = 120;
            dgvPhieuNhap.Columns[3].Width = 220;
            dgvPhieuNhap.Columns[4].Width = 150;
            dgvPhieuNhap.Columns[5].Width = 150;

            dgvPhieuNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            insert_update = "I";
            frm_PhieuNhapChiTiet m = new frm_PhieuNhapChiTiet();
            this.Hide();
            m.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            insert_update = "U";
            SoPN = dgvPhieuNhap.Rows[dgvPhieuNhap.CurrentRow.Index].Cells[0].Value.ToString().Trim();
            NgayNhap = (DateTime)dgvPhieuNhap.Rows[dgvPhieuNhap.CurrentRow.Index].Cells[1].Value;
            TongTien =int.Parse(dgvPhieuNhap.Rows[dgvPhieuNhap.CurrentRow.Index].Cells[5].Value.ToString().Trim());
            MaKho = dgvPhieuNhap.Rows[dgvPhieuNhap.CurrentRow.Index].Cells[2].Value.ToString().Trim();
            SoDM = dgvPhieuNhap.Rows[dgvPhieuNhap.CurrentRow.Index].Cells[4].Value.ToString().Trim();
            frm_PhieuNhapChiTiet m = new frm_PhieuNhapChiTiet();
            this.Hide();
            m.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc muốn xóa Phiếu Nhập : " +dgvPhieuNhap.Rows[dgvPhieuNhap.CurrentRow.Index].Cells[0].Value.ToString().Trim() + " ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (tb == DialogResult.Yes)
            {
                int xoa_PNCT = Class.cl_load.insert_update_delete("delete from PHIEUNHAPCHITIET where SoPN = '" + dgvPhieuNhap.Rows[dgvPhieuNhap.CurrentRow.Index].Cells[0].Value.ToString().Trim() + "'");
                int xoa_PC = Class.cl_load.insert_update_delete("delete from PHIEUCHI where SoPN = '" + dgvPhieuNhap.Rows[dgvPhieuNhap.CurrentRow.Index].Cells[0].Value.ToString().Trim() + "'");
                int xoa_PN = Class.cl_load.insert_update_delete("delete from PHIEUNHAP where SoPN = '" + dgvPhieuNhap.Rows[dgvPhieuNhap.CurrentRow.Index].Cells[0].Value.ToString().Trim() + "'");
                if (xoa_PN > 0)
                {
                    MessageBox.Show("xóa Phiếu nhập : " + dgvPhieuNhap.Rows[dgvPhieuNhap.CurrentRow.Index].Cells[0].Value.ToString().Trim() + " thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvPhieuNhap.Rows.RemoveAt(dgvPhieuNhap.CurrentRow.Index);
                }
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
