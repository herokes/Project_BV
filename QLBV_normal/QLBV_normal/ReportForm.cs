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
        public String typeReport;
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            //if (typeReport!=null)
            //{
            //    switch (typeReport)
            //    {
            //        case "phieukhambenh":
            //                Phieukhambenhvaovien rp = new Phieukhambenhvaovien();
            //                if (arrReport != null && arrReport.Count > 0)
            //                {
            //                    rp.SetDataSource(arrReport);
            //                }
            //                crystalReportViewer.ReportSource = rp;
            //                break;
            //        case "":
            //        default:
            //            break;
            //    }
            //}
            
            Phieukhambenhvaovien rp = new Phieukhambenhvaovien();
            if (arrReport != null && arrReport.Count > 0)
            {
                rp.SetDataSource(arrReport);
            }
            crystalReportViewer.ReportSource = rp;
        }
    }
}
