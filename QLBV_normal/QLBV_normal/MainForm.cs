using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLBV_normal
{
    public partial class MainForm : Form
    {
        public SetupForm frmSetup;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //frmSetup.Visible = false;
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            //frmSetup.Visible = false;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
