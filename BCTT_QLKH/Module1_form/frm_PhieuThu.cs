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
    public partial class frm_PhieuThu : Form
    {
        DataTable dt;
        public static string sopt = null;
        public frm_PhieuThu()
        {
            InitializeComponent();
        }

        private void frm_PhieuThu_Load(object sender, EventArgs e)
        {
            QL.Text = QL.Text + frm_DangNhap.Tenquanly;
            dt = Class.cl_load.loaddl("select * from PHIEUTHU");
            dgvPhieuThu.DataSource = dt;


            dgvPhieuThu.Columns[0].HeaderText = "Số Phiếu Thu";
            dgvPhieuThu.Columns[1].HeaderText = "Ngày Thu";
            dgvPhieuThu.Columns[2].HeaderText = "Số Phiếu Giao";
            dgvPhieuThu.Columns[3].HeaderText = "Tên Khách";
            dgvPhieuThu.Columns[4].HeaderText = "Tên Quản Lý Kho";
            dgvPhieuThu.Columns[5].HeaderText = "Tổng Tiền Thu";

            dgvPhieuThu.Columns[0].Width = 150;
            dgvPhieuThu.Columns[1].Width = 150;
            dgvPhieuThu.Columns[2].Width = 150;
            dgvPhieuThu.Columns[3].Width = 250;
            dgvPhieuThu.Columns[4].Width = 250;
            dgvPhieuThu.Columns[5].Width = 150;

            dgvPhieuThu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataTable dt1 = Class.cl_load.loaddl("select * from PHIEUGIAO");
            cbbPT.DataSource = dt1;
            cbbPT.DisplayMember = "SoPG";
            cbbPT.ValueMember = "SoPG";

            DataTable dt2 = Class.cl_load.loaddl("select * from KHACHHANG");
            cbbTenKhach.DataSource = dt2;
            cbbTenKhach.DisplayMember = "TenKhach";
            cbbTenKhach.ValueMember = "MaKhach";
            dtpNgayThu.Enabled = txtTenQuanLy.Enabled = txtTongTien.Enabled = cbbTenKhach.Enabled = false;
            txtTenQuanLy.Text = frm_DangNhap.Tenquanly;
        }
        public bool kiemtra()
        {
            if (txtSoPT.Text.Equals(""))
            {
                MessageBox.Show("Số Phiếu Thu không được để trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTongTien.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng chọn Số Phiếu Giao", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        public bool kiemtra2()
        {
            DataTable dt = Class.cl_load.loaddl("select * from PHIEUTHU where SoPT='" + txtSoPT.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Số Phiếu Thu đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoPT.ResetText();
                txtSoPT.Focus();
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (kiemtra() == false && kiemtra2() == false)
            {
                return;
            }
            int thongbao_them = Class.cl_load.insert_update_delete("insert into PHIEUTHU values('" + txtSoPT.Text.Trim() + "','" + dtpNgayThu.Value + "','" + cbbPT.SelectedValue + "',N'" + cbbTenKhach.Text.Trim() + "',N'" + txtTenQuanLy.Text.Trim() + "'," + txtTongTien.Text.Trim() + ")");
            if (thongbao_them > 0)
            {
                MessageBox.Show("Thêm mới Phiếu Thu " + txtSoPT.Text + " thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt.Rows.Add(txtSoPT.Text, dtpNgayThu.Value, cbbPT.SelectedValue, cbbTenKhach.Text.Trim(), txtTenQuanLy.Text, txtTongTien.Text);
            }
            else
            {
                MessageBox.Show("Thêm mới Phiếu Thu " + txtSoPT.Text + " không thành công thành công \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbbPN_MouseClick(object sender, MouseEventArgs e)
        {
            DataTable dt = Class.cl_load.loaddl("select NgayGiao,TenKhach,TongTienGiao from PHIEUGIAO,DONDAT inner join KHACHHANG on DONDAT.MaKhach=KHACHHANG.MaKhach where DONDAT.SoDD = PHIEUGIAO.SoDD and PHIEUGIAO.SoPG='" + cbbPT.SelectedValue + "'");
            txtTongTien.Text = dt.Rows[0][2].ToString();
            cbbTenKhach.Text = dt.Rows[0][1].ToString();
            dtpNgayThu.Value = (DateTime)dt.Rows[0][0];
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (kiemtra() == false)
            {
                return;
            }
            int thongbao_sua = Class.cl_load.insert_update_delete("update PHIEUTHU set NgayThu='" + dtpNgayThu.Value + "',SoPG='" + cbbPT.Text.Trim() + "',TenKhach=N'" + cbbTenKhach.Text.Trim() + "',TenQuanLyKho=N'" + txtTenQuanLy.Text.Trim() + "',TongTienThu="+txtTongTien.Text+" where SoPT='" + txtSoPT.Text.Trim() + "'");
            if (thongbao_sua > 0)
            {
                MessageBox.Show("Sửa Phiếu Thu " + txtSoPT.Text + " thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int chon = dgvPhieuThu.CurrentRow.Index;
                dgvPhieuThu.Rows[chon].Cells[1].Value = dtpNgayThu.Value;
                dgvPhieuThu.Rows[chon].Cells[2].Value = cbbPT.SelectedValue;
                dgvPhieuThu.Rows[chon].Cells[3].Value = cbbTenKhach.Text.Trim();
                dgvPhieuThu.Rows[chon].Cells[4].Value = txtTenQuanLy.Text.Trim();
                dgvPhieuThu.Rows[chon].Cells[5].Value = txtTongTien.Text.Trim();

            }
            else
            {
                MessageBox.Show("Sửa Phiếu Thu " + txtSoPT.Text + " không thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbao_xoa = MessageBox.Show("Bạn có chắc muốn xóa Phiếu Thu " + txtSoPT.Text.Trim() + " ?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (thongbao_xoa == DialogResult.Yes)
            {
                int xoa_PC = Class.cl_load.insert_update_delete("delete from PHIEUTHU where SoPT='" + txtSoPT.Text + "'");
                if (xoa_PC > 0)
                {
                    MessageBox.Show("Xóa Phiếu Thu " + txtSoPT.Text + " thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvPhieuThu.Rows.RemoveAt(dgvPhieuThu.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("xóa Phiếu Thu " + txtSoPT.Text + " không thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvPhieuChi_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < dgvPhieuThu.Rows.Count - 1 && index >= 0)
            {
                txtSoPT.Text = dgvPhieuThu.Rows[index].Cells[0].Value.ToString();
                dtpNgayThu.Value = (DateTime)dgvPhieuThu.Rows[index].Cells[1].Value;
                cbbPT.Text = dgvPhieuThu.Rows[index].Cells[2].Value.ToString();
                cbbTenKhach.Text = dgvPhieuThu.Rows[index].Cells[3].Value.ToString();
                txtTenQuanLy.Text = dgvPhieuThu.Rows[index].Cells[4].Value.ToString();
                txtTongTien.Text = dgvPhieuThu.Rows[index].Cells[5].Value.ToString();
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            txtSoPT.ResetText();
            txtTongTien.ResetText();
            txtSoPT.Focus();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frm_InPhieuThu i = new frm_InPhieuThu();
            sopt = txtSoPT.Text.Trim();
            i.ShowDialog();
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
