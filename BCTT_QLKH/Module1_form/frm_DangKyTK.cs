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
    public partial class frm_DangKyTK : Form
    {
        public frm_DangKyTK()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_DangNhap m = new frm_DangNhap();
            this.Hide();
            m.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string tenDN = txtTenDN.Text.Trim();
            string mk = txtMK.Text.Trim();
            string nhaplai = txtNhaplai.Text.Trim();
            if (tenDN.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDN.Focus();
                return;
            }
            if (mk.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMK.Focus();
                return;
            }
            if (nhaplai.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNhaplai.Focus();
                return;
            }
            if (txtTenQL.Text.Equals(""))
            {
                MessageBox.Show("Tên quản lý không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenQL.Focus();
                return;
            }
            DataTable dt = Class.cl_load.loaddl("select * from TAIKHOAN where TenDangNhap='" + tenDN + "'");
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại \n Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDN.Focus();
                return;
            }
            if (mk.Equals(nhaplai)==false)
            {
                MessageBox.Show("Mật khẩu không trùng nhau \n Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMK.Focus();
                return;
            }
            int dangky = Class.cl_load.insert_update_delete("insert into TAIKHOAN values('" + tenDN + "','" + mk + "',N'" + txtTenQL.Text + "')");
            if (dangky > 0)
            {
                MessageBox.Show("Đăng Ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm_Main m = new frm_Main();
                frm_DangNhap.Tenquanly = txtTenQL.Text;
                this.Hide();
                m.ShowDialog();
            }

        }
    }
}
