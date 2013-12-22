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
    public partial class ThuocForm : Form
    {
        public MainForm frmMain;

        public ThuocForm()
        {
            InitializeComponent();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (textBox_tenthuoc.Text.Trim().Equals(""))
            {
                return;
            }
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@tenthuoc", MySqlDbType.VarChar, 45).Value = textBox_tenthuoc.Text.Trim();
                com.Parameters.Add("@taduoc", MySqlDbType.VarChar, 45).Value = richTextBox_taduoc.Text.Trim();
                com.Parameters.Add("@hamluong", MySqlDbType.VarChar, 45).Value = textBox_hamluong.Text.Trim();
                com.Parameters.Add("@duongdung", MySqlDbType.VarChar, 45).Value = comboBox_duongdung.Text;
                com.Parameters.Add("@dang", MySqlDbType.VarChar, 45).Value = comboBox_dang.Text;
                com.Parameters.Add("@soluong", MySqlDbType.Int32, 11).Value = int.Parse(textBox_soluong.Text);
                com.CommandText = "INSERT INTO Thuoc(Tenthuoc, Taduoc, Hamluong, Duongdung, Dang, Soluong) values(@tenthuoc, @taduoc, @hamluong, @duongdung, @dang, @soluong)";
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
