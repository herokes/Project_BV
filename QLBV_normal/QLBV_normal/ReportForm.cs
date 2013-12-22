using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using QLBV_normal.Report;

namespace QLBV_normal
{
    public partial class ReportForm : Form
    {
        public MainForm frmMain;
        public ArrayList arrReport;

        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            Report_Benhanngoaitru rp = new Report_Benhanngoaitru();
            if (arrReport != null && arrReport.Count > 0)
            {
                rp.SetDataSource(arrReport);
            }
            crystalReportViewer.ReportSource = rp;
        }
    }
}
