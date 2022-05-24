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
    public partial class frm_DonMuaChiTiet : Form
    {
        public frm_DonMuaChiTiet()
        {
            InitializeComponent();
        }

        private void cbbMancc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frm_DonMuaChiTiet_Load(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn dgvcbb = new DataGridViewComboBoxColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            DataTable dt2 = new DataTable();
            dt2 = Class.cl_load.loaddl("select * from HANGHOA ");
            dgvcbb.DataSource = dt2;
            dgvcbb.DisplayMember = "TenHang";
            dgvcbb.ValueMember = "MaHang";
            dgvcbb.HeaderText = "Tên Hàng";
            dgvcbb.Width = 150;
            dgvHanghoa.Columns.Add(dgvcbb);

            DataGridViewColumn dgvc1 = new DataGridViewColumn();
            dgvc1.HeaderText = "Số Lượng";
            dgvc1.Name = "DONMUACHITIET.SoLuong";
            dgvc1.Width = 120;
            dgvc1.CellTemplate = cell;
            dgvHanghoa.Columns.Add(dgvc1);


            DataTable dt3 = new DataTable();
            dt3 = Class.cl_load.loaddl("select * from NHACUNGCAP");
            cbbMancc.DataSource = dt3;
            cbbMancc.ValueMember = "MaNCC";
            cbbMancc.DisplayMember = "TenNCC";

            txtSoDM.Enabled = false;
            if(frm_DonMua.I_U == "I")
            {
                txtSoDM.Text = "DM" + string.Format("{0:hhmmss}", DateTime.Now);
            }
            else
            {
                txtSoDM.Text = frm_DonMua.SoDM;
                cbbMancc.SelectedValue = frm_DonMua.NCC.Trim();
                dtpNgayMua.Value = frm_DonMua.NgayMua;
                DataTable dtload = new DataTable();
                dtload = Class.cl_load.loaddl("select MaHang,SLMua from DONMUACHITIET where SoDM='" + frm_DonMua.SoDM.Trim() + "'");
                for (int i = 0; i < dtload.Rows.Count; i++)
                {
                    string[] row = new string[]
                    { dtload.Rows[i][0].ToString(),dtload.Rows[i][1].ToString()};
                    dgvHanghoa.Rows.Add(row);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (frm_DonMua.I_U == "I")
            {
                int insertDonMua = Class.cl_load.insert_update_delete("insert into DONMUA values('" + txtSoDM.Text + "','" + cbbMancc.SelectedValue + "','" + dtpNgayMua.Value + "')");
                for (int i = 0; i < dgvHanghoa.RowCount - 1; i++)
                {
                    string mahang = dgvHanghoa.Rows[i].Cells[0].Value.ToString();
                    int soluong = int.Parse(dgvHanghoa.Rows[i].Cells[1].Value.ToString());
                    int insertDonMuaChiTiet = Class.cl_load.insert_update_delete("insert into DONMUACHITIET values('" + txtSoDM.Text + "','" + mahang + "'," + soluong + ")");
                    
                }
                if (insertDonMua > 0)
                {
                    MessageBox.Show("Thêm Đơn Mua có Số Đơn Mua : " + txtSoDM.Text + " thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                int updateDonMua = Class.cl_load.insert_update_delete("update DONMUA set MaNCC='" + cbbMancc.SelectedValue + "',NgayMua='" + dtpNgayMua.Value.ToString("MM/dd/yyyy") + "' where SoDM='" + txtSoDM.Text + "'");
                for (int i = 0; i < dgvHanghoa.RowCount - 1; i++)
                {
                    string mahang = dgvHanghoa.Rows[i].Cells[0].Value.ToString().Trim();
                    int soluong = int.Parse(dgvHanghoa.Rows[i].Cells[1].Value.ToString());
                    int updateDonMuaChiTiet = Class.cl_load.insert_update_delete("update DONMUACHITIET set SLMua=" + soluong + " where SoDM='" +txtSoDM.Text.Trim() + "' and MaHang='" + mahang + "'");
                    DataTable dt2 = Class.cl_load.loaddl("select * from DONMUACHITIET where SoDM='" + txtSoDM.Text + "' and MaHang='" + mahang + "'");
                    if (dt2.Rows.Count == 0)
                    {
                        int insertDonMuaChiTiet = Class.cl_load.insert_update_delete("insert into DONMUACHITIET values('" + txtSoDM.Text + "','" + mahang + "'," + soluong + ")");
                    }
                 }
                if (updateDonMua > 0)
                {
                    MessageBox.Show("Sửa Đơn Mua có Số Đơn Mua : " + txtSoDM.Text + " thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frm_DonMua g = new frm_DonMua();
            this.Hide();
            g.ShowDialog();
        }

        private void dgvHanghoa_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                dgvHanghoa.CurrentRow.Cells[1].Value = 1;
            }
        }
    }
}
