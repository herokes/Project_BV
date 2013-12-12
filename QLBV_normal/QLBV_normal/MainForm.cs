using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace QLBV_normal
{
    public partial class MainForm : Form
    {
        //Global form variable
        public SetupForm frmSetup;
        public LoginForm frmLogin;

        //Global class variable

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ArrayList arrServer = Util.openList("server.list");
            if (arrServer.Count > 0)
            {
                Server server = (Server)arrServer[0];
                Session.SERVER = Util.connect(server);
                if (Session.SERVER.Count != 0)
                {
                    if (Session.USER.Count == 0)
                    {
                        this.frmLogin = new LoginForm();
                        this.frmLogin.Show();
                        this.Close();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            this.frmSetup = new SetupForm();
            this.frmSetup.Show();
            this.Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((Session.SERVER.Count != 0) && (Session.USER.Count != 0))
            {
                Application.Exit();
            }
        }

    }
}
