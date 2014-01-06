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
using CrystalDecisions.Shared;

namespace QLBV_normal
{
    public partial class ReportForm : Form
    {
        public MainForm frmMain;
        public ArrayList arrReport;
        public string typeReport;

        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            dynamic rp;
            switch (typeReport)
            {
                case "benhanngoaitru":
                    rp = new Report_Benhanngoaitru();
                    break;
                case "Phieukhambenh":
                    rp = new Phieukhambenhvaovien();
                    break;
                case "todieutri":
                    rp = new Report_Todieutri();
                    break;
                case "Tongketbenhanngoaitru":
                    rp = new Report_Tongketbenhanngoaitru();
                    break;
                case "toathuoc":
                    rp = new Report_Toathuoc();
                    break;
                case "Bienbanhoichuan":
                    rp = new Report_Bienbanhoichuan();
                    break;
                default:
                    rp = new Report_Todieutri();
                    break;
            }

            if (arrReport != null && arrReport.Count > 0)
            {
                rp.SetDataSource(arrReport);
            }
            crystalReportViewer.ReportSource = rp;
        }
    }
}
