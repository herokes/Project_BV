using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using QLBV_normal.Class;

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
            Show_Combobox_Bacsi();
        }



        private void button_CapNhat_Click(object sender, EventArgs e)
        {
            // cap nhat bn
            
            try
            {
                if (tt == 0)
                {
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
                    com.Parameters.Add("@phuong", MySqlDbType.VarChar, 50).Value = textBox_Phuong.Text;
                    com.Parameters.Add("@quan", MySqlDbType.VarChar, 50).Value = textBox_Quan.Text;
                    com.Parameters.Add("@thanhpho", MySqlDbType.VarChar, 50).Value = textBox_Thanhpho.Text;
                    com.Parameters.Add("@noilamviec", MySqlDbType.VarChar, 50).Value = textBox_Noilamviec.Text;
                    com.CommandText = "insert into Benhnhan values (@id,@ten,@ngaysinh,@gioitinh,@nghenghiep,@dantoc,@cmnd,@ngoaikieu,@sonha,@phuong,@quan,@thanhpho,@noilamviec)";
                    Util.con.Open();
                    com.ExecuteNonQuery();
                    Util.con.Close();
                    tt = 0;
                }
                
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show(sqlE.Source.ToString());
                return;
            }
            // cap nhat phieu kham benh
            try
            {
                MySqlCommand com1 = new MySqlCommand();
                com1.Connection = Util.con;
                
                com1.Parameters.Add("@doituong", MySqlDbType.VarChar, 200).Value = comboBox_Doituong.Text;
                com1.Parameters.Add("@bhytgiatritu", MySqlDbType.Date, 20).Value = dateTimePicker_Tu.Value;
                com1.Parameters.Add("@bhytgiatriden", MySqlDbType.Date, 20).Value = dateTimePicker_Den.Value;
                com1.Parameters.Add("@sobhyt", MySqlDbType.VarChar,30).Value = textBox_Sothe.Text;
                com1.Parameters.Add("@nguoithan", MySqlDbType.VarChar, 20).Value = textBox_Nguoithan.Text;
                com1.Parameters.Add("@diachinguoithan", MySqlDbType.VarChar, 100).Value = textBox_Diachinguoithan.Text;
                com1.Parameters.Add("@dienthoai", MySqlDbType.VarChar, 50).Value = textBox_Dienthoai.Text;
                com1.Parameters.Add("@thoigiandenkham", MySqlDbType.DateTime, 50).Value = dateTimePicker_Ngaykham.Value;
                com1.Parameters.Add("@noigioithieu", MySqlDbType.VarChar, 100).Value = textBox_Noigioithieu.Text;
                com1.Parameters.Add("@lydovaovien", MySqlDbType.VarChar, 200).Value = textBox_Lydovaovien.Text;
                com1.Parameters.Add("@quatrinhbenhly", MySqlDbType.VarChar, 200).Value = textBox_Quatrinhbenhly.Text;
                com1.Parameters.Add("@tiensubenh", MySqlDbType.VarChar, 200).Value = textBox_Tiensubenh.Text;
                com1.Parameters.Add("@mach", MySqlDbType.VarChar, 20).Value = textBox_Mach.Text;
                com1.Parameters.Add("@nhietdo", MySqlDbType.VarChar, 20).Value = textBox_Nhiet.Text;
                com1.Parameters.Add("@huyetap", MySqlDbType.VarChar, 20).Value = textBox_Huyetap.Text;
                com1.Parameters.Add("@nhiptho", MySqlDbType.VarChar, 20).Value = textBox_Nhiptho.Text;
                com1.Parameters.Add("@trongluong", MySqlDbType.VarChar, 20).Value = textBox_Trongluong.Text;
                com1.Parameters.Add("@toanthan", MySqlDbType.VarChar, 20).Value = richText_Toanthan.Text;
                com1.Parameters.Add("@cacbophan", MySqlDbType.VarChar, 200).Value = richTextBox_Cacbophan.Text;
                com1.Parameters.Add("@tomtat", MySqlDbType.VarChar, 200).Value = richTextBox_Tomtat.Text;
                com1.Parameters.Add("@chuandoan", MySqlDbType.VarChar, 200).Value = textBox_Chuandoan.Text;
                com1.Parameters.Add("@xuli", MySqlDbType.VarChar, 200).Value = richTextBox_Xuly.Text;
                com1.Parameters.Add("@dieutritaikhoa", MySqlDbType.VarChar, 200).Value = textBox_Dieutritaikhoa.Text;
                com1.Parameters.Add("@chuy", MySqlDbType.VarChar, 200).Value = textBox_Chuy.Text;
                com1.Parameters.Add("@idbenhnhan", MySqlDbType.Int64, 20).Value = textBox_MaBN.Text;
                //com1.Parameters.Add("@hosophimanh", MySqlDbType.Int16, 20).Value = 0;
                com1.Parameters.Add("@idbacsi", MySqlDbType.Int32, 20).Value = textBox_idbacsikham.Text;
               // com.Parameters.Add("@idbacsi", MySqlDbType.Int16, 20).Value = comboBox_Bacsikham.Value;

                com1.CommandText = "insert into phieukhambenh(Doituong,BHYTgiatritu,BHYTgiatriden,SoBHYT,Nguoithan,Diachinguoithan,Dienthoai,Thoigiandenkham,Noigioithieu,Lydovaovien,Quatrinhbenhly,Tiensubenh,Mach,Nhietdo,Huyetap,Nhiptho,Trongluong,Toanthan,Cacbophan,Tomtatketqualamsan,Chuandoanvaovien,Xuli,Dieutritaikhoa,Chuy,Benhnhan_idBenhnhan,Idbacsi) values (@doituong,@bhytgiatritu,@bhytgiatriden,@sobhyt,@nguoithan,@diachinguoithan,@dienthoai,@thoigiandenkham,@noigioithieu,@lydovaovien,@quatrinhbenhly,@tiensubenh,@mach,@nhietdo,@huyetap,@nhiptho,@trongluong,@toanthan,@cacbophan,@tomtat,@chuandoan,@xuli,@dieutritaikhoa,@chuy,@idbenhnhan,@idbacsi)";
               
                Util.con.Open();
                com1.ExecuteNonQuery();
                Util.con.Close();
               
            
            /// nhap vao ngoai tru hay noi tru 
            /// lay ma phieu kham benh
                
                com1.CommandText = "SELECT MAX( idphieukhambenh )FROM benhnhan, phieukhambenh WHERE benhnhan.idbenhnhan = phieukhambenh.benhnhan_idbenhnhan AND benhnhan.idbenhnhan ="+ textBox_MaBN.Text;
                //MessageBox.Show("executenonquery select");
                Util.con.Open();
                int maphieukhambenh=(int)com1.ExecuteScalar();
                Util.con.Close();
                if (comboBox_Loaidieutri.Text == "NGOẠI TRÚ CHẠY THẬN")
                    //MessageBox.Show(maphieukhambenh.ToString());
                    com1.CommandText = "INSERT INTO  ngoaitru (idNgoaitru ,Ngaygiovaovien,Benhchinh ,Benhkemtheo,Dieutritu ,Dieutriden ,Tinhtrangravien ,Huongdieutri ,Bacsikhambenh ,Bacsidieutri ,chaythan ,Phieukhambenh_idPhieukhambenh)VALUES (NULL , NULL , NULL , NULL , NULL , NULL , NULL , NULL , NULL , 1 , NULL ," + maphieukhambenh.ToString() + ")";
                else if (comboBox_Loaidieutri.Text == "NGOẠI TRU KHÔNG CHẠY THẬN")
                    com1.CommandText = "INSERT INTO  ngoaitru (idNgoaitru ,Ngaygiovaovien,Benhchinh ,Benhkemtheo,Dieutritu ,Dieutriden ,Tinhtrangravien ,Huongdieutri ,Bacsikhambenh ,Bacsidieutri ,chaythan ,Phieukhambenh_idPhieukhambenh)VALUES (NULL , NULL , NULL , NULL , NULL , NULL , NULL , NULL , NULL , NULL , NULL ," + maphieukhambenh.ToString() + ")";
                else com1.CommandText = "";
                Util.con.Open();
                com1.ExecuteNonQuery();
                Util.con.Close();
                MessageBox.Show("Đăng ký thành công");
            }
            catch (MySqlException sqlE)
            {
                Util.con.Close();
                MessageBox.Show(sqlE.Source.ToString());
                return;
            }
                //MessageBox.Show("ok");
            
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
            dateTimePicker_Ngaykham.Value = DateTime.Today;
            dateTimePicker_Giokham.Value = DateTime.Now;
            comboBox_Doituong.Text = "BHYT";
            textBox_NoiDKKCBBD.Text = "";
            textBox_Sothe.Text = "";
            dateTimePicker_Tu.Value = DateTime.Today;
            dateTimePicker_Den.Value = DateTime.Today;
            textBox_Nguoithan.Text = "";
            textBox_Dienthoai.Text = "";
            textBox_Diachinguoithan.Text = "";
            textBox_Noigioithieu.Text = "";
            textBox_Lydovaovien.Text = "";
            textBox_Quatrinhbenhly.Text = "";
            textBox_Tiensubenh.Text = "";
            textBox_Mach.Text = "";
            textBox_Nhiet.Text = "";
            textBox_Huyetap.Text = "";
            textBox_Nhiptho.Text = "";
            textBox_Trongluong.Text = "";
            richText_Toanthan.Text = "";
            richTextBox_Cacbophan.Text = "";
            richTextBox_Tomtat.Text = "";
            textBox_Chuandoan.Text = "";
            richTextBox_Xuly.Text = "";
            comboBox_Loaidieutri.Text = "NGOẠI TRÚ CHẠY THẬN";
            textBox_Chuy.Text = "";

          

         // thong tin phieu kham benh
        }
        public  void Show_Combobox_Bacsi ()
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.CommandText = "SELECT * FROM bacsi";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                if (read.Read())
                {
                    while(read.Read())
                    comboBox_Bacsikham.Items.Add(read[1].ToString());
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show(sqlE.Source.ToString());
                return;
            }
        }

        private void textBox_idbacsikham_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.CommandText = "SELECT * FROM bacsi WHERE idBacsi= "+ textBox_idbacsikham.Text;
                //MessageBox.Show(com.CommandText.te);
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                if (read.Read())
                {

                    comboBox_Bacsikham.Text = read[1].ToString();

                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                Util.con.Close();
                MessageBox.Show(sqlE.Source.ToString());
                return;
            }
        }

       

        private void textBox_MaBN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    MySqlCommand com = new MySqlCommand();
                    com.Connection = Util.con;
                    com.CommandText = "SELECT * FROM benhnhan WHERE idbenhnhan= " + textBox_MaBN.Text;
                    //MessageBox.Show(com.CommandText.te);
                    Util.con.Open();
                    MySqlDataReader read = com.ExecuteReader();
                    if (read.Read())
                    {
                        tt = 1;
                        textBox_Ten.Text = read[1].ToString();
                        dateTimePicker_Namsinh.Value = DateTime.Parse(read[2].ToString());
                        if (int.Parse(read[3].ToString()) == 0)
                            comboBox_Gioitinh.Text = "Nam";
                        else comboBox_Gioitinh.Text = "Nữ";
                        comboBox_Nghenghiep.Text = read[4].ToString();
                        comboBox_Dantoc.Text = read[5].ToString();
                        textBox_CMND.Text = read[6].ToString();
                        comboBox_Ngoaikieu.Text = read[7].ToString();
                        textBox_Sonha.Text = read[8].ToString();
                        textBox_Phuong.Text = read[9].ToString();
                        textBox_Quan.Text = read[10].ToString();
                        textBox_Thanhpho.Text = read[11].ToString();
                        textBox_Noilamviec.Text = read[12].ToString();

                    }
                    Util.con.Close();
                }
            }
            catch (MySqlException sqlE)
            {
                Util.con.Close();
                MessageBox.Show(sqlE.Source.ToString());
                return;
            }
        }

        private void button_Nhapmoi_Click(object sender, EventArgs e)
        {
            Clear_Thongtin();
        }



        private void dateTimePicker_Namsinh_ValueChanged(object sender, EventArgs e)
        {
            DateTime a = DateTime.Today;
            int b = a.Year - dateTimePicker_Namsinh.Value.Year;
            textBox_Tuoi.Text = b.ToString();
        }

        private void textBox_MaBN_Validating(object sender, CancelEventArgs e)
        {
            if(textBox_MaBN.Text==string.Empty)
            {
                errorProvider1.SetError(textBox_MaBN, "bạn chưa nhập Mã bệnh nhân");
            }
            else
            {
                Regex numberchk = new Regex(@"^([0-9]*|\d*)$");
                if (!numberchk.IsMatch(textBox_MaBN.Text))
                {
                   
                    errorProvider1.SetError(textBox_MaBN, "Nhập số");
                }

            } 
        }

        private void textBox_CMND_Validating(object sender, CancelEventArgs e)
        {
            if (textBox_CMND.Text == string.Empty)
            {
                errorProvider1.SetError(textBox_CMND, "bạn chưa nhập CMND");
            }
            else
            {
                Regex numberchk = new Regex(@"^([0-9]*|\d*)$");
                if (!numberchk.IsMatch(textBox_CMND.Text))
                {

                    errorProvider1.SetError(textBox_CMND, "Phải Nhập bằng số");
                }

            } 
        }

      
    }
}
