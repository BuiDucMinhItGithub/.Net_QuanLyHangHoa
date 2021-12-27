﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Nhom20_Bùi Đức Minh_18103100061_11/11/2000_DHTI12A1HN
//Nhom20_Dương Văn Long_18103100027_19/11/2000_DHTI12A1HN
//Nhom20_Nguyễn Thăng Long_18103100034_23/10/2000_DHTI12A1HN
namespace _20_BĐMinhDVLongNTLong_LTNET
{
    public partial class ReportGoods : Form
    {
        Connect con = new Connect();
        DataTable dt = new DataTable();
        public ReportGoods()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            dt = con.GetData("SELECT * FROM hanghoa");
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet2", dt);
            reportViewer1.LocalReport.ReportPath = "Report2.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
        }
    }
}
