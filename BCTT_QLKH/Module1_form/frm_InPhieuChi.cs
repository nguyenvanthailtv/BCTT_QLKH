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
    public partial class frm_InPhieuChi : Form
    {
        public frm_InPhieuChi()
        {
            InitializeComponent();
        }

        private void frm_InPhieuChi_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Class.cl_load.loaddl("select SoPC, CONVERT(date,NgayChi,103)as NgayChi, TongTienTra, TenNCC, TenQuanLyKho, PHIEUNHAPCHITIET.MaHang as MaHang, TenHang, SLNhap,PHIEUNHAPCHITIET.GiaNhap as GiaNhap  , ThanhTien from PHIEUCHI, PHIEUNHAPCHITIET inner join HANGHOA on HANGHOA.MaHang = PHIEUNHAPCHITIET.MaHang inner join PHIEUNHAP on PHIEUNHAPCHITIET.SoPN = PHIEUNHAP.SoPN where PHIEUNHAPCHITIET.SoPN = PHIEUCHI.SoPN and SoPC ='" + frm_PhieuChi.sopc + "'");
            reportViewer1.LocalReport.ReportEmbeddedResource = "BCTT_QLKH.Module1_form.Report_PhieuChi.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = dt;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
