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
    public partial class frm_DonDat : Form
    {
        DataTable dt;
        public static string I_U = null;
        public static string SoDD = null;
        public static string MaKhach = null;
        public static DateTime NgayDat;
        public frm_DonDat()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            I_U = "I";
            frm_DonDatChiTiet d = new frm_DonDatChiTiet();
            this.Hide();
            d.ShowDialog();
            
        }

        private void frm_DonDat_Load(object sender, EventArgs e)
        {
            QL.Text = QL.Text + frm_DangNhap.Tenquanly;

            dt = Class.cl_load.loaddl("select SoDD,DONDAT.MaKhach,KHACHHANG.TenKhach,NgayDat from DONDAT inner join KHACHHANG on KHACHHANG.MAKHACH = DONDAT.MAKHACH");
            dgvDonDat.DataSource = dt;

            dgvDonDat.Columns[0].HeaderText = "Số Đơn Đặt";
            dgvDonDat.Columns[1].HeaderText = "Mã Khách";
            dgvDonDat.Columns[2].HeaderText = "Tên Khách";
            dgvDonDat.Columns[3].HeaderText = "Ngày Đặt";

            dgvDonDat.Columns[0].Width = 150;
            dgvDonDat.Columns[1].Width = 150;
            dgvDonDat.Columns[2].Width = 200;
            dgvDonDat.Columns[3].Width = 150;

            dgvDonDat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            I_U = "S";
            SoDD = dgvDonDat.Rows[dgvDonDat.CurrentRow.Index].Cells[0].Value.ToString();
            MaKhach = dgvDonDat.Rows[dgvDonDat.CurrentRow.Index].Cells[1].Value.ToString();
            NgayDat = (DateTime)dgvDonDat.Rows[dgvDonDat.CurrentRow.Index].Cells[3].Value;
            frm_DonDatChiTiet d = new frm_DonDatChiTiet();
            this.Hide();
            d.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc muốn xóa Đơn đặt : " + dgvDonDat.Rows[dgvDonDat.CurrentRow.Index].Cells[0].Value.ToString().Trim() + " ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (tb == DialogResult.Yes)
            {
                int xoa_DDCT = Class.cl_load.insert_update_delete("delete from DONDATCHITIET where SoDD = '" + dgvDonDat.Rows[dgvDonDat.CurrentRow.Index].Cells[0].Value.ToString().Trim() + "'");
                int xoa_DD = Class.cl_load.insert_update_delete("delete from DONDAT where SoDD = '" +dgvDonDat.Rows[dgvDonDat.CurrentRow.Index].Cells[0].Value.ToString().Trim() + "'");
                if (xoa_DD > 0)
                {
                    MessageBox.Show("xóa Đơn đặt : " + dgvDonDat.Rows[dgvDonDat.CurrentRow.Index].Cells[0].Value.ToString().Trim() + " thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDonDat.Rows.RemoveAt(dgvDonDat.CurrentRow.Index);
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
