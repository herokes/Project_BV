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
    public partial class SetupForm : Form
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

        private void button_ok_Click(object sender, EventArgs e)
        {
            Server server = new Server();
            server.Hostname = textBox_hostname.Text;
            server.Username = textBox_username.Text;
            server.Password = textBox_password.Text;
            server.Database = textBox_database.Text;
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
