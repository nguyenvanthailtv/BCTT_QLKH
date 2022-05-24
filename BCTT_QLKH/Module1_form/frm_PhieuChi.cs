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
    public partial class frm_PhieuChi : Form
    {
        DataTable dt;
        public frm_PhieuChi()
        {
            InitializeComponent();
        }

        private void frm_PhieuChi_Load(object sender, EventArgs e)
        {
            QL.Text = QL.Text + frm_DangNhap.Tenquanly;
            dt = Class.cl_load.loaddl("select * from PHIEUCHI");
            dgvPhieuChi.DataSource = dt;

            
            dgvPhieuChi.Columns[0].HeaderText = "Số Phiếu Chi";
            dgvPhieuChi.Columns[1].HeaderText = "Ngày Chi";
            dgvPhieuChi.Columns[2].HeaderText = "Số Phiếu Nhập";
            dgvPhieuChi.Columns[3].HeaderText = "Tên Nhà Cung Cấp";
            dgvPhieuChi.Columns[4].HeaderText = "Tên Quản Lý Kho";
            dgvPhieuChi.Columns[5].HeaderText = "Tổng Tiền Trả";

            dgvPhieuChi.Columns[0].Width = 150;
            dgvPhieuChi.Columns[1].Width = 150;
            dgvPhieuChi.Columns[2].Width = 150;
            dgvPhieuChi.Columns[3].Width = 250;
            dgvPhieuChi.Columns[4].Width = 250;
            dgvPhieuChi.Columns[5].Width = 150;

            dgvPhieuChi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataTable dt1 = Class.cl_load.loaddl("select * from PHIEUNHAP");
            cbbPN.DataSource = dt1;
            cbbPN.DisplayMember = "SoPN";
            cbbPN.ValueMember = "SoPN";

            DataTable dt2 = Class.cl_load.loaddl("select * from NHACUNGCAP");
            cbbNCC.DataSource = dt2;
            cbbNCC.DisplayMember = "TenNCC";
            cbbNCC.ValueMember = "MaNCC";
            dtpNgayChi.Enabled = txtTenQuanLy.Enabled = txtTongTien.Enabled = cbbNCC.Enabled = false;
            txtTenQuanLy.Text = frm_DangNhap.Tenquanly;
        }

        private void cbbPN_MouseClick(object sender, MouseEventArgs e)
        {
            DataTable dt = Class.cl_load.loaddl("select NgayNhap,TenNCC,TongTienNhap from PHIEUNHAP,DONMUA inner join NHACUNGCAP on DONMUA.MaNCC=NHACUNGCAP.MaNCC where DONMUA.SoDM = PHIEUNHAP.SoDM and PHIEUNHAP.SoPN='" + cbbPN.SelectedValue + "'");
            txtTongTien.Text = dt.Rows[0][2].ToString();
            cbbNCC.Text = dt.Rows[0][1].ToString();
            dtpNgayChi.Value = (DateTime)dt.Rows[0][0];
        }
        public bool kiemtra()
        {
            if (txtSoPC.Text.Equals(""))
            {
                MessageBox.Show("Số Phiếu Chi không được để trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTongTien.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng chọn Số Phiếu Nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        public bool kiemtra2()
        {
            DataTable dt = Class.cl_load.loaddl("select * from PHIEUCHI where SoPC='" + txtSoPC.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Số Phiếu Chi đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoPC.ResetText();
                txtSoPC.Focus();
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(kiemtra()==false && kiemtra2() == false)
            {
                return;
            }
            int thongbao_them = Class.cl_load.insert_update_delete("insert into PHIEUCHI values('" + txtSoPC.Text.Trim() + "','"+dtpNgayChi.Value+"','" + cbbPN.SelectedValue + "',N'" + cbbNCC.Text.Trim() + "',N'" +txtTenQuanLy.Text.Trim() + "'," + txtTongTien.Text.Trim() + ")");
            if (thongbao_them > 0)
            {
                MessageBox.Show("Thêm mới Phiếu Chi " + txtSoPC.Text + " thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt.Rows.Add(txtSoPC.Text,dtpNgayChi.Value,cbbPN.SelectedValue,cbbNCC.Text.Trim(),txtTenQuanLy.Text,txtTongTien.Text);
            }
            else
            {
                MessageBox.Show("Thêm mới Phiếu Chi " +txtSoPC.Text + " không thành công thành công \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (kiemtra() == false)
            {
                return;
            }
            int thongbao_sua = Class.cl_load.insert_update_delete("update PHIEUCHI set NgayChi='" + dtpNgayChi.Value + "',SoPN='" +cbbPN.Text.Trim() + "',TenNCC=N'" + cbbNCC.Text.Trim() + "',TenQuanLyKho=N'"+txtTenQuanLy.Text.Trim()+"',TongTienTra="+txtTongTien.Text+" where SoPC='" + txtSoPC.Text.Trim() + "'");
            if (thongbao_sua > 0)
            {
                MessageBox.Show("Sửa Phiếu Chi " + txtSoPC.Text + " thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int chon = dgvPhieuChi.CurrentRow.Index;
                dgvPhieuChi.Rows[chon].Cells[1].Value = dtpNgayChi.Value;
                dgvPhieuChi.Rows[chon].Cells[2].Value = cbbPN.SelectedValue;
                dgvPhieuChi.Rows[chon].Cells[3].Value = cbbNCC.Text.Trim();
                dgvPhieuChi.Rows[chon].Cells[4].Value = txtTenQuanLy.Text.Trim();
                dgvPhieuChi.Rows[chon].Cells[5].Value = txtTongTien.Text.Trim();
                
            }
            else
            {
                MessageBox.Show("Sửa Phiếu Chi " + txtSoPC.Text + " không thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvPhieuChi_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index <dgvPhieuChi.Rows.Count-1 && index >= 0)
            {
                txtSoPC.Text = dgvPhieuChi.Rows[index].Cells[0].Value.ToString();
                dtpNgayChi.Value =(DateTime) dgvPhieuChi.Rows[index].Cells[1].Value;
                cbbPN.Text = dgvPhieuChi.Rows[index].Cells[2].Value.ToString();
                cbbNCC.Text = dgvPhieuChi.Rows[index].Cells[3].Value.ToString();
                txtTenQuanLy.Text = dgvPhieuChi.Rows[index].Cells[4].Value.ToString();
                txtTongTien.Text = dgvPhieuChi.Rows[index].Cells[5].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbao_xoa = MessageBox.Show("Bạn có chắc muốn xóa Phiếu Chi " + txtSoPC.Text.Trim() + " ?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (thongbao_xoa == DialogResult.Yes)
            {
                int xoa_PC = Class.cl_load.insert_update_delete("delete from PHIEUCHI where SoPC='" + txtSoPC.Text + "'");
                if (xoa_PC > 0)
                {
                    MessageBox.Show("Xóa Phiếu Chi " + txtSoPC.Text + " thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvPhieuChi.Rows.RemoveAt(dgvPhieuChi.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("xóa Phiếu Chi " + txtSoPC.Text + " không thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            txtSoPC.ResetText();
            txtTongTien.ResetText();
            txtSoPC.Focus();
        }
        public static string sopc = null;
        private void btnIn_Click(object sender, EventArgs e)
        {
            frm_InPhieuChi i = new frm_InPhieuChi();
            sopc = txtSoPC.Text.Trim();
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
