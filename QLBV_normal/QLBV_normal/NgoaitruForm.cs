using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;
using QLBV_normal.Class;

namespace QLBV_normal
{
    public partial class NgoaitruForm : Form
    {
        public MainForm frmMain;
        public Hashtable currentObject = new Hashtable();

        public NgoaitruForm()
        {
            InitializeComponent();
        }
        public void Show_danhsachbenhnhan()
        {
            try
            {
                listView_danhsachbenhnhan.Items.Clear();
                string sql="";
                if (radioButton_dieutri.Checked == true)
                {
                    sql = "select DISTINCT benhnhan.id, benhnhan.Ten from benhnhan,phieukhambenh,ngoaitru where benhnhan.id= phieukhambenh.Benhnhan_id and phieukhambenh.id= ngoaitru.Phieukhambenh_id and ngoaitru.Tinhtrangravien=0";
                }
                else
                    if(radioButton_xuatvien.Checked== true)
                    {
                        sql = "select DISTINCT benhnhan.id, benhnhan.Ten from benhnhan,phieukhambenh,ngoaitru where benhnhan.id= phieukhambenh.Benhnhan_id and phieukhambenh.id= ngoaitru.Phieukhambenh_id and ngoaitru.Tinhtrangravien!=0";
                    }
                
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.CommandText = sql;
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    int i = listView_danhsachbenhnhan.Items.Count;
                    listView_danhsachbenhnhan.Items.Add(read[0].ToString());
                    listView_danhsachbenhnhan.Items[i].SubItems.Add(read[1].ToString());
                }

                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                //MessageBox.Show(sqlE.Source.ToString());
                return;
            }
        }

        private void NgoaitruFormnew_Load(object sender, EventArgs e)
        {
            Show_danhsachbenhnhan();
        }

        private void radioButton_xuatvien_CheckedChanged(object sender, EventArgs e)
        {
            Show_danhsachbenhnhan();
        }

        private void radioButton_dieutri_CheckedChanged(object sender, EventArgs e)
        {
            Show_danhsachbenhnhan();
        }
        public void load_Thongtinhanhchinh(int idBenhnhan)
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = idBenhnhan;
                com.CommandText = @"SELECT * FROM benhnhan WHERE id=@id";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    textBox_MaBN.Text = read["id"].ToString();
                    textBox_Ten.Text = read["Ten"].ToString();
                    comboBox_Gioitinh.SelectedIndex = bool.Parse(read["Gioitinh"].ToString()) ? 0 : 1;
                    dateTimePicker_Namsinh.Value = DateTime.Parse(read["Ngaysinh"].ToString());
                    textBox_Tuoi.Text = (DateTime.Today.Year - DateTime.Parse(read["Ngaysinh"].ToString()).Year).ToString();
                    textBox_diachi.Text = read["Sonha"].ToString() + " " + read["Duong"].ToString() + " - Phường " + read["Phuong"].ToString() + " - Quận " + read["Quan"].ToString() + " - TP." + read["Thanhpho"].ToString();

                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                
                return;

            }
        }

        public void load_Dieutri(int idBenhnhan)
        {
            listView_dieutri.Items.Clear();
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = idBenhnhan;
                com.CommandText = @"SELECT benhnhan.Ten, benhnhan.Ngaysinh, todieutri_noidung.*
                                        FROM todieutri_noidung 
                                        LEFT OUTER JOIN todieutri
                                            ON todieutri_noidung.Todieutri_id=todieutri.id
                                        LEFT OUTER JOIN phieukhambenh 
                                            ON phieukhambenh.id=todieutri.Phieukhambenh_id 
                                        LEFT OUTER JOIN ngoaitru
                                            ON ngoaitru.Phieukhambenh_id=phieukhambenh.id 
                                        LEFT OUTER JOIN benhnhan
                                            ON benhnhan.id=phieukhambenh.Benhnhan_id 
                                        WHERE benhnhan.id=@id AND ngoaitru.Tinhtrangravien=0";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = DateTime.Parse(read["Ngaygio"].ToString()).ToString("dd/MM/yyyy h\\h mm");
                    item.SubItems.Add(read["Dientienbenh"].ToString());
                    item.SubItems.Add(read["Ylenh"].ToString());
                    listView_dieutri.Items.Add(item);
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }

        public void load_Dientienbenh(int idBenhnhan)
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = idBenhnhan;
                com.CommandText = @"SELECT phieukhambenh.*
                                        FROM phieukhambenh
                                        LEFT OUTER JOIN ngoaitru
                                            ON ngoaitru.Phieukhambenh_id=phieukhambenh.id 
                                        LEFT OUTER JOIN benhnhan
                                            ON benhnhan.id=phieukhambenh.Benhnhan_id 
                                        WHERE benhnhan.id=@id AND ngoaitru.Tinhtrangravien=0";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    richTextBox_dientienbenh.Text = "1.Toàn thân: " + read["Toanthan"].ToString()
                        + "\n2.Các bộ phận: " + read["Cacbophan"].ToString()
                        + "\nMạch: " + read["Mach"].ToString() + " lần/phút"
                        + "\nNhiệt độ: " + read["Nhietdo"].ToString() + " oC"
                        + "\nHuyết áp: " + read["Huyetap"].ToString() + " mmHg"
                        + "\nNhịp thở: " + read["Nhiptho"].ToString() + " lần/phút"
                        + "\nCân nặng: " + read["Trongluong"].ToString() + " lần/phút"
                        + "\n3.Tóm tắt kết quả lâm sàn: " + read["Cacbophan"].ToString()
                        + "\n4.Chuẩn đoán vào viện: " + read["Chuandoanvaovien"].ToString()
                        + "\n5.Đã xử lí (thuốc, chăm sóc...): " + read["Xuli"].ToString()
                        + "\n6.Cho vào điều trị tại khoa: " + read["Dieutritaikhoa"].ToString()
                        + "\n7.Chú ý: " + read["Chuy"].ToString();
                    textBox_Quatrinhbenhly.Text = read["Quatrinhbenhly"].ToString();
                    textBox_Phuongphapdieutri.Text = read["Xuli"].ToString();

                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }

        public void load_Ylenh(int idBenhnhan)
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = idBenhnhan;
                com.CommandText = @"SELECT phieukhambenh.*
                                        FROM phieukhambenh
                                        LEFT OUTER JOIN ngoaitru
                                            ON ngoaitru.Phieukhambenh_id=phieukhambenh.id 
                                        LEFT OUTER JOIN benhnhan
                                            ON benhnhan.id=phieukhambenh.Benhnhan_id 
                                        WHERE benhnhan.id=@id AND ngoaitru.Tinhtrangravien=0";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    richTextBox_ylenh.Text = "1.Toàn thân: " + read["Toanthan"].ToString()
                        + "\n2.Các bộ phận: " + read["Cacbophan"].ToString()
                        + "\nMạch: " + read["Mach"].ToString() + " lần/phút"
                        + "\nNhiệt độ: " + read["Nhietdo"].ToString() + " oC"
                        + "\nHuyết áp: " + read["Huyetap"].ToString() + " mmHg"
                        + "\nNhịp thở: " + read["Nhiptho"].ToString() + " lần/phút"
                        + "\nCân nặng: " + read["Trongluong"].ToString() + " lần/phút"
                        + "\n3.Tóm tắt kết quả lâm sàn: " + read["Cacbophan"].ToString()
                        + "\n4.Chuẩn đoán vào viện: " + read["Chuandoanvaovien"].ToString()
                        + "\n5.Đã xử lí (thuốc, chăm sóc...): " + read["Xuli"].ToString()
                        + "\n6.Cho vào điều trị tại khoa: " + read["Dieutritaikhoa"].ToString()
                        + "\n7.Chú ý: " + read["Chuy"].ToString();
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }

        public void set_CurrentObject()
        {
            currentObject.Add("idBenhnhan", 0);
            currentObject.Add("idPhieukhambenh", 0);
            currentObject.Add("idNgoaitru", 0);
            currentObject.Add("idTodieutri", 0);
            currentObject.Add("idPhieuxetnghiem", 0);
        }
        private void listView_danhsachbenhnhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_danhsachbenhnhan.SelectedItems.Count < 1)
            {
                return;
            }
            int idBenhnhan = int.Parse(listView_danhsachbenhnhan.SelectedItems[0].SubItems[0].Text);
            load_Thongtinhanhchinh(idBenhnhan);
            load_Dieutri(idBenhnhan);
            load_Dientienbenh(idBenhnhan);
            load_Ylenh(idBenhnhan);
        }

        private void button_print_todieutri_Click(object sender, EventArgs e)
        {
            frmMain.frmReport = new ReportForm();
            frmMain.frmReport.frmMain = this.frmMain;
            frmMain.frmReport.MdiParent = this.frmMain;
            frmMain.frmReport.arrReport = new ArrayList();
            frmMain.frmReport.typeReport = "todieutri";
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = int.Parse(listView_danhsachbenhnhan.SelectedItems[0].SubItems[0].Text);
                com.CommandText = @"SELECT benhnhan.Ten, benhnhan.Ngaysinh, todieutri_noidung.*
                                        FROM todieutri_noidung 
                                        LEFT OUTER JOIN todieutri
                                            ON todieutri_noidung.Todieutri_id=todieutri.id
                                        LEFT OUTER JOIN phieukhambenh 
                                            ON phieukhambenh.id=todieutri.Phieukhambenh_id 
                                        LEFT OUTER JOIN ngoaitru
                                            ON ngoaitru.Phieukhambenh_id=phieukhambenh.id 
                                        LEFT OUTER JOIN benhnhan
                                            ON benhnhan.id=phieukhambenh.Benhnhan_id 
                                        WHERE benhnhan.id=@id AND ngoaitru.Tinhtrangravien=0";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    Todieutri obj = new Todieutri();
                    obj.Tenbenhnhan = read["Ten"].ToString();
                    obj.Ngaysinh = DateTime.Parse(read["Ngaysinh"].ToString());
                    obj.Ngaygio = DateTime.Parse(read["Ngaygio"].ToString());
                    obj.Dientienbenh = read["Dientienbenh"].ToString();
                    obj.Ylenh = read["Ylenh"].ToString();
                    frmMain.frmReport.arrReport.Add(obj);
                }
                Util.con.Close();
                frmMain.frmReport.Show();
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }

        private void button_add_dieutri_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@dientienbenh", MySqlDbType.Text).Value = "";
                com.Parameters.Add("@ylenh", MySqlDbType.Text).Value = "";
                com.Parameters.Add("@ngaygio", MySqlDbType.DateTime).Value = DateTime.Now;
                com.Parameters.Add("@todieutri_id", MySqlDbType.Int32, 11).Value = "";

                com.CommandText = @"INSERT INTO `todieutri_noidung` (`Dientienbenh`, `Ylenh`, `Ngaygio`, `Todieutri_id`) VALUES (@dientienbenh, @ylenh, @ngaygio, @todieutri_id)";
                Util.con.Open();
                if (com.ExecuteNonQuery() != 0)
                {
                    //load_Dieutri(currentObject);
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }

        private void textBox_MaBN_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("ok");
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void textBox45_TextChanged(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

 

       
    }
}
