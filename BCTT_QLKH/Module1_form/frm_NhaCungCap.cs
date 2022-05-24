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
    public partial class frm_NhaCungCap : Form
    {
        DataTable dt = new DataTable();
        public frm_NhaCungCap()
        {
            InitializeComponent();
        }

        private void frm_NhaCungCap_Load(object sender, EventArgs e)
        {
            QL.Text = QL.Text + frm_DangNhap.Tenquanly;
            loadDatagridview();
        }
        //load dữ liệu cho dgvNcc và tạo cột cho dgvNcc
        public void loadDatagridview()
        {
            //load dữ liệu vào dgvNcc
            dt = Class.cl_load.loaddl("select * from NHACUNGCAP");
            dgvNcc.DataSource = dt;

            //Tạo các cột cho dgvNcc
            dgvNcc.Columns[0].HeaderText = "Mã NCC";
            dgvNcc.Columns[1].HeaderText = "Tên NCC";
            dgvNcc.Columns[2].HeaderText = "Địa Chỉ";
            dgvNcc.Columns[3].HeaderText = "SĐT";

            dgvNcc.Columns[0].Width = 150;
            dgvNcc.Columns[1].Width = 300;
            dgvNcc.Columns[2].Width = 345;
            dgvNcc.Columns[3].Width = 150;

            dgvNcc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        public bool kiemtra()
        {
            if (txtMancc.Text.Equals(""))
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTenncc.Text.Equals(""))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //kiểm tra xem mã nhà cung cấp đã tồn tại chưa
                DataTable dtNcc = Class.cl_load.loaddl("select * from NHACUNGCAP where MaNCC = '" + txtMancc.Text.Trim() + "'");
                if (dtNcc.Rows.Count > 0)
                {
                    MessageBox.Show("Mã nhà cung cấp " + txtMancc.Text.Trim() + " đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //thêm mới nhà cung cấp
                int thongbao_them = Class.cl_load.insert_update_delete("insert into NHACUNGCAP values('" + txtMancc.Text.Trim() + "',N'" + txtTenncc.Text.Trim() + "',N'" + txtDiachi.Text.Trim() + "','"+txtSdt.Text.Trim()+"')");
                if (thongbao_them > 0)
                {
                    MessageBox.Show("Thêm mới nhà cung cấp " + txtMancc.Text.Trim() + " thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt.Rows.Add(txtMancc.Text.Trim(), txtTenncc.Text.Trim(), txtDiachi.Text.Trim(),txtSdt.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Thêm mới nhà cung cấp " + txtMancc.Text.Trim() + " không thành công thành công \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Thêm mới nhà cung cấp " + txtMancc.Text.Trim() + " không thành công thành công \n Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvNcc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chon_hang = e.RowIndex;
            if (chon_hang < dgvNcc.Rows.Count - 1 && chon_hang >= 0)
            {
                txtMancc.Text = dgvNcc.Rows[chon_hang].Cells[0].Value.ToString().Trim();
                txtTenncc.Text = dgvNcc.Rows[chon_hang].Cells[1].Value.ToString().Trim();
                txtDiachi.Text = dgvNcc.Rows[chon_hang].Cells[2].Value.ToString().Trim();
                txtSdt.Text = dgvNcc.Rows[chon_hang].Cells[3].Value.ToString().Trim();   
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult thongbao_xoa = MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp " + txtMancc.Text.Trim() + " ?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (thongbao_xoa == DialogResult.Yes)
                {
                    int xoa_Ncc = Class.cl_load.insert_update_delete("delete from NHACUNGCAP where MaNCC='" + txtMancc.Text.Trim() + "'");
                    if (xoa_Ncc > 0)
                    {
                        MessageBox.Show("Xóa nhà cung cấp " + txtMancc.Text.Trim() + " thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvNcc.Rows.RemoveAt(dgvNcc.CurrentRow.Index);
                    }
                    else
                    {
                        MessageBox.Show("xóa nhà cung cấp " + txtMancc.Text.Trim() + " không thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtTenncc.ResetText();
            txtSdt.ResetText();
            txtMancc.ResetText();
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
                int thongbao_sua = Class.cl_load.insert_update_delete("update NHACUNGCAP set TenNCC=N'" + txtTenncc.Text.Trim() + "',DiaChi=N'" + txtDiachi.Text.Trim() + "',DienThoai='"+txtSdt.Text.Trim()+"' where MaNCC='" + txtMancc.Text.Trim() + "'");
                if (thongbao_sua > 0)
                {
                    MessageBox.Show("Sửa nhà cung cấp " + txtMancc.Text.Trim() + " thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int chon = dgvNcc.CurrentRow.Index;
                    dgvNcc.Rows[chon].Cells[1].Value = txtTenncc.Text.Trim();
                    dgvNcc.Rows[chon].Cells[2].Value = txtDiachi.Text.Trim();
                    dgvNcc.Rows[chon].Cells[3].Value = txtSdt.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Sửa nhà cung cấp " + txtMancc.Text.Trim() + " không thành công ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi vui lòng kiểm tra lại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
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
