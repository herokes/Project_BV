using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QLBV_normal.Class;

namespace QLBV_normal
{
    public partial class LoginForm : Form
    {
        public MainForm frmMain;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Session.USER.Count == 0)
            {
                Application.Exit();
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@user", MySqlDbType.VarChar, 50).Value = textBox_username.Text.Trim();
                com.Parameters.Add("@pass", MySqlDbType.VarChar, 200).Value = Util.MD5Hash(textBox_password.Text.Trim());
                com.CommandText = "SELECT * FROM user WHERE username=@user AND password=@pass";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                if (read.Read())
                {
                    Session.USER.Add("id", read["id"].ToString());
                    Session.USER.Add("username", read["username"].ToString());
                    Session.USER.Add("level", (int)read["level"]);
                    this.Close();
                    this.frmMain = new MainForm();
                    this.frmMain.Show();
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }

    }
}
