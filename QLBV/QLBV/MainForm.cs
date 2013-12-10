using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace QLBV
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        public SetupForm frmSetup;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            frmSetup.Visible = false;
        }
    }
}
