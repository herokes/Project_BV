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
    public partial class DangkyForm : Form
    {
        public MainForm frmMain;
        int tt = 0;
        public DangkyForm()
        {
            InitializeComponent();
        }

        private void DangkyForm_Load(object sender, EventArgs e)
        {

        }



        private void button_CapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@id", MySqlDbType.Int16, 50).Value = textBox_MaBN.Text;
                com.Parameters.Add("@ten", MySqlDbType.VarChar, 200).Value = textBox_Ten.Text;
                com.Parameters.Add("@ngaysinh", MySqlDbType.Date, 20).Value = DateTime.Parse(textBox_Ngaysinh.Text);
                if(comboBox_Gioitinh.Text== "Nam")
                com.Parameters.Add("@gioitinh", MySqlDbType.Bit,10).Value = 1;
                else
                com.Parameters.Add("@gioitinh", MySqlDbType.Bit, 10).Value = 0;
                com.Parameters.Add("@nghenghiep", MySqlDbType.VarChar, 20).Value = comboBox_Nghenghiep.Text;
                com.Parameters.Add("@dantoc", MySqlDbType.VarChar, 20).Value = comboBox_Dantoc.Text;
                com.Parameters.Add("@cmnd", MySqlDbType.VarChar,20 ).Value = textBox_CMND.Text;
                com.Parameters.Add("@ngoaikieu", MySqlDbType.VarChar, 20).Value = comboBox_Ngoaikieu.Text;
                com.Parameters.Add("@sonha", MySqlDbType.VarChar, 50).Value = textBox_Sonha.Text;
                com.Parameters.Add("@phuong", MySqlDbType.VarChar, 50).Value = textBox_Phuong.Text;
                com.Parameters.Add("@quan", MySqlDbType.VarChar, 50).Value = textBox_Quan.Text;
                com.Parameters.Add("@thanhpho", MySqlDbType.VarChar, 50).Value = textBox_Thanhpho.Text;
                com.Parameters.Add("@noilamviec", MySqlDbType.VarChar, 50).Value = textBox_Noilamviec.Text;
                com.CommandText = "insert into Benhnhan values (@id,@ten,@ngaysinh,@gioitinh,@nghenghiep,@dantoc,@cmnd,@ngoaikieu,@sonha,@phuong,@quan,@thanhpho,@noilamviec)";
                Util.con.Open();
                com.ExecuteNonQuery();
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show(sqlE.Source.ToString());
                return;
            }
        }
        public  void Show_Combobox_Bacsi ()
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                // com.Parameters.Add("@", MySqlDbType.VarChar, 50).Value = textBox_username.Text.Trim();
                // com.Parameters.Add("@", MySqlDbType.VarChar, 200).Value = Util.MD5Hash(textBox_password.Text.Trim());
                com.CommandText = "SELECT * FROM Bacsi";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                if (read.Read())
                {
                    comboBox_Bacsikham.Text= read[1].ToString();
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show(sqlE.Source.ToString());
                return;
            }
        }

     
      
    }
}
