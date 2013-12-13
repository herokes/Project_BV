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

        Server server = new Server();

        public SetupForm()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            server.Hostname = textBox_hostname.Text;
            server.Username = textBox_username.Text;
            server.Password = textBox_password.Text;
            server.Database = textBox_database.Text;
            Session.CONNECTED = Util.connect(server);
            if (Session.CONNECTED)
            {
                ArrayList arrServer = new ArrayList();
                arrServer.Add(server);
                Util.saveList(arrServer, "server.list");
                this.Close();
                this.frmMain = new MainForm();
                this.frmMain.Show();
            }
        }

        private void SetupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Session.CONNECTED)
            {
                Application.Exit();
            }
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            textBox_hostname.Focus();
        }
    }
}
