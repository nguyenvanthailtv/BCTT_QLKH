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
    public partial class frm_DonDatChiTiet : Form
    {
        public frm_DonDatChiTiet()
        {
            InitializeComponent();
        }

        private void frm_DonDatChiTiet_Load(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn dgvcbb = new DataGridViewComboBoxColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            DataTable dt2 = new DataTable();
            dt2 = Class.cl_load.loaddl("select * from HANGHOA");
            dgvcbb.DataSource = dt2;
            dgvcbb.DisplayMember = "TenHang";
            dgvcbb.ValueMember = "MaHang";
            dgvcbb.HeaderText = "Tên Hàng";
            dgvcbb.Width = 150;
            dgvHanghoa.Columns.Add(dgvcbb);

            DataGridViewColumn dgvc1 = new DataGridViewColumn();
            dgvc1.HeaderText = "Số Lượng";
            dgvc1.Name = "DONDATCHITIET.SoLuong";
            dgvc1.Width = 120;
            dgvc1.CellTemplate = cell;
            dgvHanghoa.Columns.Add(dgvc1);


            DataTable dt3 = new DataTable();
            dt3 = Class.cl_load.loaddl("select * from KHACHHANG");
            cbbMakhach.DataSource = dt3;
            cbbMakhach.ValueMember = "MaKhach";
            cbbMakhach.DisplayMember = "TenKhach";

            txtSoDD.Enabled = false;
            if (frm_DonDat.I_U == "I")
            {
                txtSoDD.Text = "DD" + string.Format("{0:hhmmss}", DateTime.Now);
            }
            else
            {
                txtSoDD.Text = frm_DonDat.SoDD;
                cbbMakhach.SelectedValue = frm_DonDat.MaKhach.Trim();
                dtpNgayDat.Value = frm_DonDat.NgayDat;
                DataTable dtload = new DataTable();
                dtload = Class.cl_load.loaddl("select MaHang,SLDat from DONDATCHITIET where SoDD='" + frm_DonDat.SoDD.Trim() + "'");
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
            if (frm_DonDat.I_U == "I")
            {
                int insertDonDat = Class.cl_load.insert_update_delete("insert into DONDAT values('" + txtSoDD.Text + "','" + cbbMakhach.SelectedValue + "','" + dtpNgayDat.Value + "')");
                for (int i = 0; i < dgvHanghoa.RowCount - 1; i++)
                {
                    string mahang = dgvHanghoa.Rows[i].Cells[0].Value.ToString();
                    int soluong = int.Parse(dgvHanghoa.Rows[i].Cells[1].Value.ToString());
                    int insertDonDatChiTiet = Class.cl_load.insert_update_delete("insert into DONDATCHITIET values('" + txtSoDD.Text + "','" + mahang + "'," + soluong + ")");

                }
                if (insertDonDat > 0)
                {
                    MessageBox.Show("Thêm Đặt Mua có Số Đơn Đặt : " + txtSoDD.Text + " thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                int updateDonDat = Class.cl_load.insert_update_delete("update DONDAT set MaKhach='" + cbbMakhach.SelectedValue + "',NgayDat='" + dtpNgayDat.Value.ToString("MM/dd/yyyy") + "' where SoDD='" + txtSoDD.Text + "'");
                for (int i = 0; i < dgvHanghoa.RowCount - 1; i++)
                {
                    string mahang = dgvHanghoa.Rows[i].Cells[0].Value.ToString().Trim();
                    int soluong = int.Parse(dgvHanghoa.Rows[i].Cells[1].Value.ToString());
                    int updateDonDatChiTiet = Class.cl_load.insert_update_delete("update DONDATCHITIET set SLDat=" + soluong + " where SoDD='" + txtSoDD.Text.Trim() + "' and MaHang='" + mahang + "'");
                    DataTable dt2 = Class.cl_load.loaddl("select * from DONDATCHITIET where SoDD='" + txtSoDD.Text + "' and MaHang='" + mahang + "'");
                    if (dt2.Rows.Count == 0)
                    {
                        int insertDonDatChiTiet = Class.cl_load.insert_update_delete("insert into DONDATCHITIET values('" + txtSoDD.Text.Trim() + "','" + mahang + "'," + soluong + ")");
                    }
                }
                if (updateDonDat > 0)
                {
                    MessageBox.Show("Sửa Đơn Đặt có Số Đơn Đặt : " + txtSoDD.Text + " thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
