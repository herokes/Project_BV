using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Collections;

namespace QLBV
{
    public partial class SetupForm : Telerik.WinControls.UI.RadForm
    {
        public MainForm frmMain;
        
        public Util util = new Util();

        public SetupForm()
        {
            InitializeComponent();
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            ArrayList arrServer = util.openList("server.list");
            foreach (Server server in arrServer)
            {
                if (util.connect(server))
                {
                    if (frmMain == null || frmMain.IsDisposed)
                    {
                        frmMain = new MainForm();
                        frmMain.frmSetup = this;
                        frmMain.Show();
                        frmMain.Activate();
                    }
                }
            }
        }

        private void radButton_ok_Click(object sender, EventArgs e)
        {
            Server server = new Server();
            server.Hostname = radTextBox_hostname.Text;
            server.Username = radTextBox_username.Text;
            server.Password = radTextBox_password.Text;
            server.Database = radTextBox_database.Text;
            if (util.connect(server))
            {
                ArrayList arrServer = new ArrayList();
                arrServer.Add(server);
                util.saveList(arrServer, "server.list");
                if (frmMain == null || frmMain.IsDisposed)
                {
                    frmMain = new MainForm();
                    frmMain.frmSetup = this;
                    frmMain.Show();
                    frmMain.Activate();
                }
            }
        }

    }
}
