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
    public partial class BaocaoxetnghiemForm : Form
    {
        public MainForm frmMain;
        public BaocaoxetnghiemForm()
        {
            InitializeComponent();
        }

        private void button_Baocao_Click(object sender, EventArgs e)
        {
            frmMain.frmReport = new ReportForm();
            frmMain.frmReport.frmMain = this.frmMain;
            frmMain.frmReport.MdiParent = this.frmMain;
            frmMain.frmReport.arrReport = new ArrayList();
            frmMain.frmReport.typeReport = "Baocaoxetnghiem";


            //Bienba bant = new Bienbanhoichuan();
            //bant.Mabenhnhan = idbn.ToString();
            //bant.Tenbenhnhan = textBox_Ten.Text;
            //bant.Ngaysinh = dateTimePicker_Namsinh.Value;
            //bant.Chuandoan = textBox_Chuandoan.Text;
            //DateTime thoigianhoichuan = new DateTime(dateTimePicker_ngayhoichuan_hoichuan.Value.Year, dateTimePicker_ngayhoichuan_hoichuan.Value.Month, dateTimePicker_ngayhoichuan_hoichuan.Value.Day, dateTimePicker_giohoichuan_hoichuan.Value.Hour, dateTimePicker_giohoichuan_hoichuan.Value.Minute, dateTimePicker_giohoichuan_hoichuan.Value.Second);
            //bant.Ngayhoichuan = thoigianhoichuan;
            //bant.Mucdothieumau = comboBox_thieumaumucdo_hoichuan.Text;
            //bant.Ketquaxetnghiem = richTextBox_ketquaxetnghiem_hoichuan.Text;
            //bant.Ketluanhoichuan = richTextBox_ketluanhoichuan_hoichuan.Text;
            //bant.Bacsihoichuan = textBox_bacsihoichuan_hoichuan.Text;
            //frmMain.frmReport.arrReport.Add(bant);
            //frmMain.frmReport.Show();

        }

   
    }
}
