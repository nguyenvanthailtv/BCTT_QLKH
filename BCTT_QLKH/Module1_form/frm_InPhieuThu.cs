using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace BCTT_QLKH.Module1_form
{
    public partial class frm_InPhieuThu : Form
    {
        public frm_InPhieuThu()
        {
            InitializeComponent();
        }

        private void frm_InPhieuThu_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt = Class.cl_load.loaddl("select SoPT, CONVERT(date,NgayThu,103)as NgayThu, SoTienNop, TenKhach, TenQuanLyKho, PHIEUGIAOCHITIET.MaHang as MaHang, TenHang, SLGiao, GiaGiao, ThanhTien from PHIEUTHU, PHIEUGIAOCHITIET inner join HANGHOA on HANGHOA.MaHang = PHIEUGIAOCHITIET.MaHang where PHIEUGIAOCHITIET.SoPG = PHIEUTHU.SoPG and SoPT='" + frm_PhieuThu.sopt+"'");
            reportViewer1.LocalReport.ReportEmbeddedResource = "BCTT_QLKH.Module1_form.Report_PhieuThu.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = dt;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
