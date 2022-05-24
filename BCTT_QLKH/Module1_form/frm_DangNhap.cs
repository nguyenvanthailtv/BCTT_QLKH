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

namespace BCTT_QLKH
{
    public partial class frm_DangNhap : Form
    {
        public static string Tenquanly = null;
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = Class.cl_load.loaddl("select * from TAIKHOAN where TenDangNhap='"+textBox1.Text.Trim()+"' and MatKhau='"+textBox2.Text.Trim()+"'");
            
                if (dt.Rows.Count>0)
                {
                    MessageBox.Show("Đăng Nhập Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Tenquanly = dt.Rows[0][2].ToString().Trim();
                    frm_Main m = new frm_Main();
                    this.Hide();
                    m.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sai Tên Đăng Nhập hoặc Mật Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
             DialogResult tb =  MessageBox.Show("Bạn có chắc là muốn thoát ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(tb == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            frm_DangKyTK m = new frm_DangKyTK();
            this.Hide();
            m.ShowDialog();
        }
    }
}
