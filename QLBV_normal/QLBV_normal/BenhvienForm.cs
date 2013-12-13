using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QLBV_normal
{
    public partial class BenhvienForm : Form
    {
        public MainForm frmMain;

        public BenhvienForm()
        {
            InitializeComponent();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (textBox_tenbenhvien.Text.Trim().Equals("")) 
            {
                return;
            }
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@tenbenhvien", MySqlDbType.VarChar, 45).Value = textBox_tenbenhvien.Text.Trim();
                com.Parameters.Add("@ghichu", MySqlDbType.VarChar, 200).Value = richTextBox_ghichu.Text.Trim();
                com.CommandText = "INSERT INTO Benhvien(Tenbenhvien, Ghichu) values(@tenbenhvien, @ghichu)";
                Util.con.Open();
                com.ExecuteNonQuery();
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }
    }
}
