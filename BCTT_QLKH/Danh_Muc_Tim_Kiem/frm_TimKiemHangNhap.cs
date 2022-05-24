using BCTT_QLKH.Module1_form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCTT_QLKH.Danh_Muc_Tim_Kiem
{
    public partial class frm_TimKiemHangNhap : Form
    {
        DataTable dt = null;
        public frm_TimKiemHangNhap()
        {
            InitializeComponent();
        }

        private void frm_TimKiemHangNhap_Load(object sender, EventArgs e)
        {
            dt = load_dl("select PHIEUNHAPCHITIET.SoPN,NgayNhap,KHOHANG.MaKho,TenKho,DONMUA.MaNCC,TenNCC,KHOHANG.MaHang,TenHang,PHIEUNHAPCHITIET.GiaNhap,PHIEUNHAPCHITIET.SLNhap from KHOHANG inner join PHIEUNHAPCHITIET on PHIEUNHAPCHITIET.MaHang=KHOHANG.MaHang inner join HANGHOA on KHOHANG.MaHang=HANGHOA.MaHang inner join PHIEUNHAP on PHIEUNHAPCHITIET.SoPN=PHIEUNHAP.SoPN inner join DONMUA on DONMUA.SoDM=PHIEUNHAP.SoDM inner join NHACUNGCAP on DONMUA.MaNCC = NHACUNGCAP.MaNCC inner join KHO on KHOHANG.MaKho = KHO.MaKho");
            txtMa.Enabled = txtSP.Enabled = txtTen.Enabled=txtNCC.Enabled=txtMaKho.Enabled = false;

            QL.Text = QL.Text + frm_DangNhap.Tenquanly;
        }
        public DataTable load_dl(string sql)
        {
            DataTable dt2;
            dt2 = Class.cl_load.loaddl(sql);
            dgvHang.DataSource = dt2;


            dgvHang.Columns[0].HeaderText = "Số Phiếu Nhập";
            dgvHang.Columns[1].HeaderText = "Ngày Nhập";
            dgvHang.Columns[2].HeaderText = "Mã Kho";
            dgvHang.Columns[3].HeaderText = "Tên Kho";
            dgvHang.Columns[4].HeaderText = "Mã Nhà Cung Cấp";
            dgvHang.Columns[5].HeaderText = "Tên Nhà Cung Cấp";
            dgvHang.Columns[6].HeaderText = "Mã Hàng";
            dgvHang.Columns[7].HeaderText = "Tên Hàng";
            dgvHang.Columns[8].HeaderText = "Giá Nhập";
            dgvHang.Columns[9].HeaderText = "Số Lượng Nhập";

            dgvHang.Columns[0].Width = 150;
            dgvHang.Columns[1].Width = 150;
            dgvHang.Columns[2].Width = 140;
            dgvHang.Columns[3].Width = 200;
            dgvHang.Columns[4].Width = 130;
            dgvHang.Columns[5].Width = 200;
            dgvHang.Columns[6].Width = 120;
            dgvHang.Columns[7].Width = 150;
            dgvHang.Columns[8].Width = 100;
            dgvHang.Columns[9].Width = 120;

            dgvHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            return dt;
        }
        private void radMa_Click(object sender, EventArgs e)
        {
            txtMa.Enabled = true;
            txtSP.Enabled = txtTen.Enabled=txtNCC.Enabled=txtMaKho.Enabled = false;
            txtSP.ResetText();
            txtTen.ResetText();
            txtMaKho.ResetText();
            txtNCC.ResetText();
        }

        private void radTen_Click(object sender, EventArgs e)
        {
            txtTen.Enabled = true;
            txtSP.Enabled = txtMa.Enabled = txtNCC.Enabled = txtMaKho.Enabled = false;
            txtSP.ResetText();
            txtMa.ResetText();
            txtMaKho.ResetText();
            txtNCC.ResetText();
        }

        private void radSoPhieu_Click(object sender, EventArgs e)
        {
            txtSP.Enabled = true;
            txtMa.Enabled = txtTen.Enabled = txtNCC.Enabled = txtMaKho.Enabled = false;
            txtMa.ResetText();
            txtTen.ResetText();
            txtMaKho.ResetText();
            txtNCC.ResetText();

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string timkiem = null;
            if (radMa.Checked == true) timkiem = "and KHOHANG.MaHang ='" + txtMa.Text.Trim() + "'";
            if (radTen.Checked == true) timkiem = "and TenHang ='" + txtTen.Text.Trim() + "'";
            if (radSoPhieu.Checked == true) timkiem = "and PHIEUNHAPCHITIET.SoPN='" + txtSP.Text.Trim() + "'";
            if (rabKho.Checked == true) timkiem = " and KHOHANG.MaKho='" + txtMaKho.Text.Trim() + "'";
            if (rabNCC.Checked == true) timkiem = " and DONMUA.MaNCC='" + txtNCC.Text.Trim() + "'";
            dt = load_dl("select PHIEUNHAPCHITIET.SoPN,NgayNhap,KHOHANG.MaKho,TenKho,DONMUA.MaNCC,TenNCC,KHOHANG.MaHang,TenHang,PHIEUNHAPCHITIET.GiaNhap,KHOHANG.SLNhap from KHOHANG inner join PHIEUNHAPCHITIET on PHIEUNHAPCHITIET.MaHang=KHOHANG.MaHang inner join HANGHOA on KHOHANG.MaHang=HANGHOA.MaHang inner join PHIEUNHAP on PHIEUNHAPCHITIET.SoPN=PHIEUNHAP.SoPN inner join DONMUA on DONMUA.SoDM=PHIEUNHAP.SoDM inner join NHACUNGCAP on DONMUA.MaNCC = NHACUNGCAP.MaNCC inner join KHO on KHOHANG.MaKho = KHO.MaKho " +timkiem);
        }

        private void rabKho_Click(object sender, EventArgs e)
        {
            txtMaKho.Enabled = true;
            txtSP.Enabled = false;
            txtMa.Enabled = txtTen.Enabled = txtNCC.Enabled = false;
            txtSP.ResetText();
            txtTen.ResetText();
            txtMa.ResetText();
            txtNCC.ResetText();
        }

        private void rabNCC_Click(object sender, EventArgs e)
        {
            txtNCC.Enabled = true;
            txtSP.Enabled = false;
            txtMa.Enabled = txtTen.Enabled = txtMaKho.Enabled = false;
            txtSP.ResetText();
            txtTen.ResetText();
            txtMa.ResetText();
            txtMaKho.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt = load_dl("select PHIEUNHAPCHITIET.SoPN,NgayNhap,KHOHANG.MaKho,TenKho,DONMUA.MaNCC,TenNCC,KHOHANG.MaHang,TenHang,PHIEUNHAPCHITIET.GiaNhap,KHOHANG.SLNhap from KHOHANG inner join PHIEUNHAPCHITIET on PHIEUNHAPCHITIET.MaHang=KHOHANG.MaHang inner join HANGHOA on KHOHANG.MaHang=HANGHOA.MaHang inner join PHIEUNHAP on PHIEUNHAPCHITIET.SoPN=PHIEUNHAP.SoPN inner join DONMUA on DONMUA.SoDM=PHIEUNHAP.SoDM inner join NHACUNGCAP on DONMUA.MaNCC = NHACUNGCAP.MaNCC inner join KHO on KHOHANG.MaKho = KHO.MaKho");
            txtMa.Enabled = txtSP.Enabled = txtTen.Enabled = txtNCC.Enabled = txtMaKho.Enabled = false;
            txtMa.ResetText();
            txtMaKho.ResetText();
            txtNCC.ResetText();
            txtSP.ResetText();
            txtTen.ResetText();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void khoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void danhSáchHàngTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

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
