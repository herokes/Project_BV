
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;

namespace QLBV_normal
{
    public partial class ThontinbenhnhanForm : Form
    {
        public MainForm frmMain;
        public int trangthai = 0;
        public ThontinbenhnhanForm()
        {
            InitializeComponent();
        }

        private void textBox_MaBN_Validated(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.CommandText = "SELECT * FROM benhnhan where id= "+ textBox_MaBN.Text;
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                if (read.Read())
                {
                    while (read.Read())
                    {
                        textBox_MaBN.Text = read[0].ToString();
                        textBox_Ten.Text = read[1].ToString();
                        dateTimePicker_Namsinh.Value = DateTime.Parse(read[0].ToString());
                        if (read[3].ToString() == "1")
                            comboBox_Gioitinh.Text = "Nam";
                        else
                            comboBox_Gioitinh.Text = "Nữ";

                        comboBox_Nghenghiep.Text = read[4].ToString();
                        comboBox_Dantoc.Text = read[5].ToString();
                        textBox_CMND.Text = read[6].ToString();
                        comboBox_Ngoaikieu.Text = read[7].ToString();
                        textBox_Sonha.Text = read[8].ToString();
                        textBox_duong.Text = read[9].ToString();
                        textBox_Thanhpho.Text = read[12].ToString();
                        textBox_Quan.Text = read[11].ToString();
                        textBox_Phuong.Text = read[10].ToString();
                        textBox_Noilamviec.Text = read[13].ToString();
                    }
                    trangthai=1;
                }
                else
                    trangthai = 0;
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                Util.con.Close();
                MessageBox.Show(sqlE.Source.ToString());
                return;
            }
        }

        private void button_Capnhat_Click(object sender, EventArgs e)
        {
            try
            {
               if (trangthai == 0)
                {
                    MySqlCommand com = new MySqlCommand();
                    com.Connection = Util.con;
                    com.Parameters.Add("@id", MySqlDbType.Int64, 50).Value = textBox_MaBN.Text;
                    com.Parameters.Add("@ten", MySqlDbType.VarChar, 200).Value = textBox_Ten.Text;
                    com.Parameters.Add("@ngaysinh", MySqlDbType.Date, 20).Value = dateTimePicker_Namsinh.Value;
                    if (comboBox_Gioitinh.Text == "Nam")
                        com.Parameters.Add("@gioitinh", MySqlDbType.Int16, 10).Value = 0;
                    else
                        com.Parameters.Add("@gioitinh", MySqlDbType.Int16, 10).Value = 1;
                    com.Parameters.Add("@nghenghiep", MySqlDbType.VarChar, 20).Value = comboBox_Nghenghiep.Text;
                    com.Parameters.Add("@dantoc", MySqlDbType.VarChar, 20).Value = comboBox_Dantoc.Text;
                    com.Parameters.Add("@cmnd", MySqlDbType.VarChar, 20).Value = textBox_CMND.Text;
                    com.Parameters.Add("@ngoaikieu", MySqlDbType.VarChar, 20).Value = comboBox_Ngoaikieu.Text;
                    com.Parameters.Add("@sonha", MySqlDbType.VarChar, 50).Value = textBox_Sonha.Text;
                    com.Parameters.Add("@duong", MySqlDbType.VarChar, 50).Value = textBox_duong.Text;
                    com.Parameters.Add("@phuong", MySqlDbType.VarChar, 50).Value = textBox_Phuong.Text;
                    com.Parameters.Add("@quan", MySqlDbType.VarChar, 50).Value = textBox_Quan.Text;
                    com.Parameters.Add("@thanhpho", MySqlDbType.VarChar, 50).Value = textBox_Thanhpho.Text;
                    com.Parameters.Add("@noilamviec", MySqlDbType.VarChar, 50).Value = textBox_Noilamviec.Text;
                    com.CommandText = "insert into Benhnhan values (@id,@ten,@ngaysinh,@gioitinh,@nghenghiep,@dantoc,@cmnd,@ngoaikieu,@sonha,@duong,@phuong,@quan,@thanhpho,@noilamviec)";
                    Util.con.Open();
                    com.ExecuteNonQuery();
                    Util.con.Close();
                    Clear_Thongtin();
                    trangthai = 0;
                }
               else
                   if (trangthai == 1)
                   { 
     ///UPDATE  `dbthan`.`benhnhan` SET  `ten` =  'QUANG2',`ngaysinh` =  '2013-12-02 00:00:00',`gioitinh` =  '1',`nghenghiep` =  'Học sinh',`Dantoc` =  'Kinh',`CMND` =  '025118871',
///`Ngoaikieu` =  'k',`Sonha` =  '1234212',`Duong` =  'LTK2',`Phuong` =  'P3',`Quan` =  'H4',`Thanhpho` =  'TP5',`Noilamviec` =  'NLV5' WHERE  `benhnhan`.`id` =1300003;    
                       MySqlCommand com = new MySqlCommand();
                       com.Connection = Util.con;
                       com.Parameters.Add("@id", MySqlDbType.Int64, 50).Value = textBox_MaBN.Text;
                       com.Parameters.Add("@ten", MySqlDbType.VarChar, 200).Value = textBox_Ten.Text;
                       com.Parameters.Add("@ngaysinh", MySqlDbType.Date, 20).Value = dateTimePicker_Namsinh.Value;
                       if (comboBox_Gioitinh.Text == "Nam")
                           com.Parameters.Add("@gioitinh", MySqlDbType.Bit, 10).Value = 1;
                       else
                           com.Parameters.Add("@gioitinh", MySqlDbType.Bit, 10).Value = 0;
                       com.Parameters.Add("@nghenghiep", MySqlDbType.VarChar, 20).Value = comboBox_Nghenghiep.Text;
                       com.Parameters.Add("@dantoc", MySqlDbType.VarChar, 20).Value = comboBox_Dantoc.Text;
                       com.Parameters.Add("@cmnd", MySqlDbType.VarChar, 20).Value = textBox_CMND.Text;
                       com.Parameters.Add("@ngoaikieu", MySqlDbType.VarChar, 20).Value = comboBox_Ngoaikieu.Text;
                       com.Parameters.Add("@sonha", MySqlDbType.VarChar, 50).Value = textBox_Sonha.Text;
                       com.Parameters.Add("@duong", MySqlDbType.VarChar, 50).Value = textBox_duong.Text;
                       com.Parameters.Add("@phuong", MySqlDbType.VarChar, 50).Value = textBox_Phuong.Text;
                       com.Parameters.Add("@quan", MySqlDbType.VarChar, 50).Value = textBox_Quan.Text;
                       com.Parameters.Add("@thanhpho", MySqlDbType.VarChar, 50).Value = textBox_Thanhpho.Text;
                       com.Parameters.Add("@noilamviec", MySqlDbType.VarChar, 50).Value = textBox_Noilamviec.Text;
                       com.CommandText = "UPDATE  benhnhan SET  ten =  @ten,ngaysinh =  @ngaysinh,gioitinh =  @gioitinh,nghenghiep =  @nghenghiep,Dantoc = @dantoc"+
                       ",CMND =@cmnd,Ngoaikieu = @ngoaikieu,Sonha =  @sonha,Duong =  @duong,Phuong =  @phuong,Quan =  @quan,"+
                       "Thanhpho = @thanhpho,Noilamviec =  @noilamviec WHERE  id ="+ textBox_MaBN.Text;
                       Util.con.Open();
                       com.ExecuteNonQuery();
                       Util.con.Close();
                       Clear_Thongtin();
                   }

            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show(sqlE.Source.ToString());
                return;
            }
        }
        public void Clear_Thongtin()
        {// thong tin hanh chinh
            textBox_MaBN.Text = "";
            textBox_Ten.Text = "";
            dateTimePicker_Namsinh.Value = DateTime.Today;
            comboBox_Gioitinh.Text = "Nam";
            textBox_CMND.Text = "";
            comboBox_Nghenghiep.Text = "";
            comboBox_Dantoc.Text = "KINH";
            comboBox_Ngoaikieu.Text = "";
            textBox_Sonha.Text = "";
            textBox_Thanhpho.Text = "";
            textBox_Quan.Text = "";
            textBox_Phuong.Text = "";
            textBox_Noilamviec.Text = "";

        }

        private void textBox_Ten_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.Parse(e.KeyChar.ToString().ToUpper()); 
        }

        private void textBox_MaBN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    MySqlCommand com = new MySqlCommand();
                    com.Connection = Util.con;
                    com.CommandText = "SELECT * FROM benhnhan WHERE id= " + textBox_MaBN.Text;
                    //MessageBox.Show(com.CommandText.te);
                    Util.con.Open();
                    MySqlDataReader read = com.ExecuteReader();
                    if (read.Read())
                    {

                        textBox_Ten.Text = read[1].ToString();
                        dateTimePicker_Namsinh.Value = DateTime.Parse(read[2].ToString());
                        //MessageBox.Show(read[3].ToString());
                        if (read[3].ToString() == "True")
                            comboBox_Gioitinh.Text = "Nam";
                        else comboBox_Gioitinh.Text = "Nữ";
                        comboBox_Nghenghiep.Text = read[4].ToString();
                        comboBox_Dantoc.Text = read[5].ToString();
                        textBox_CMND.Text = read[6].ToString();
                        comboBox_Ngoaikieu.Text = read[7].ToString();
                        textBox_Sonha.Text = read[8].ToString();
                        textBox_duong.Text = read[9].ToString();
                        textBox_Phuong.Text = read[10].ToString();
                        textBox_Quan.Text = read[11].ToString();
                        textBox_Thanhpho.Text = read[12].ToString();
                        textBox_Noilamviec.Text = read[13].ToString();
                        trangthai = 1;

                    }
                    Util.con.Close();
                }
                else
                    trangthai = 0;
            }
            catch (MySqlException sqlE)
            {
                Util.con.Close();
                MessageBox.Show(sqlE.Source.ToString());
                return;
            }
        }

        private void dateTimePicker_Namsinh_ValueChanged(object sender, EventArgs e)
        {
            DateTime a = DateTime.Today;
            int b = a.Year - dateTimePicker_Namsinh.Value.Year;
            textBox_Tuoi.Text = b.ToString();
        }






       

       
    }
}
