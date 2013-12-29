﻿using System;
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
        public NgoaitruForm()
        {
            InitializeComponent();
        }
        public void Show_danhsachbenhnhan()
        {
            listView_danhsachbenhnhan.Items.Clear();
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.AddWithValue("@seach_string", "%" + textBox_search_benhnhan.Text.Trim() + "%");

                if (radioButton_dieutri.Checked == true)
                {
                    com.CommandText = @"SELECT DISTINCT benhnhan.id, benhnhan.Ten 
                                        FROM benhnhan 
                                        LEFT OUTER JOIN phieukhambenh 
                                            ON benhnhan.id=phieukhambenh.Benhnhan_id 
                                        LEFT OUTER JOIN ngoaitru
                                            ON phieukhambenh.id=ngoaitru.Phieukhambenh_id
                                        WHERE ngoaitru.Tinhtrangravien=0 
										    AND (benhnhan.id LIKE @seach_string OR benhnhan.Ten LIKE @seach_string)";
                }
                else
                {
                    com.CommandText = @"SELECT DISTINCT benhnhan.id, benhnhan.Ten 
                                        FROM benhnhan 
                                        LEFT OUTER JOIN phieukhambenh 
                                            ON benhnhan.id=phieukhambenh.Benhnhan_id 
                                        LEFT OUTER JOIN ngoaitru
                                            ON phieukhambenh.id=ngoaitru.Phieukhambenh_id
                                        WHERE ngoaitru.Tinhtrangravien!=0 
										    AND (benhnhan.id LIKE @seach_string OR benhnhan.Ten LIKE @seach_string)";
                }

                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = read[0].ToString();
                    item.SubItems.Add(read[1].ToString());
                    listView_danhsachbenhnhan.Items.Add(item);
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
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
            textBox_Ten.Text = "";
            comboBox_Gioitinh.SelectedIndex = -1;
            dateTimePicker_Namsinh.Value = DateTime.Now;
            textBox_Tuoi.Text = "";
            textBox_diachi.Text = "";
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
                    textBox_Ten.Text = read["Ten"].ToString();
                    comboBox_Gioitinh.SelectedIndex = int.Parse(read["Gioitinh"].ToString());
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
                com.CommandText = @"SELECT benhnhan.Ten, benhnhan.Ngaysinh, todieutri_noidung.*, ylenh.Mota
                                        FROM todieutri_noidung 
                                        LEFT OUTER JOIN todieutri
                                            ON todieutri_noidung.Todieutri_id=todieutri.id
                                        LEFT OUTER JOIN phieukhambenh 
                                            ON phieukhambenh.id=todieutri.Phieukhambenh_id 
                                        LEFT OUTER JOIN ngoaitru
                                            ON ngoaitru.Phieukhambenh_id=phieukhambenh.id 
                                        LEFT OUTER JOIN benhnhan
                                            ON benhnhan.id=phieukhambenh.Benhnhan_id 
                                        LEFT OUTER JOIN ylenh
                                            ON ylenh.id=todieutri_noidung.ylenh_id 
                                        WHERE benhnhan.id=@id AND ngoaitru.Tinhtrangravien=0";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = DateTime.Parse(read["Ngaygio"].ToString()).ToString("dd/MM/yyyy h\\h mm");
                    item.SubItems.Add(read["Dientienbenh"].ToString());
                    item.SubItems.Add(read["Mota"].ToString());
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
            richTextBox_dientienbenh.Text = "";
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
                    richTextBox_dientienbenh.Text = read["Toanthan"].ToString()
                        + "\nMạch: " + read["Mach"].ToString() + " lần/phút"
                        + "\nHuyết áp: " + read["Huyetap"].ToString() + " mmHg"
                        + "\n" + read["Cacbophan"].ToString()
                        + "\nVấn đề: "
                        + "\n" + read["Chuandoanvaovien"].ToString();
                    textBox_Quatrinhbenhly.Text = read["Quatrinhbenhly"].ToString();
                    textBox_Phuongphapdieutri.Text = read["Xuli"].ToString();
                    dateTimePicker_Ngaykham.Value =DateTime.Parse(read["Thoigiandenkham"].ToString());

                    dateTimePicker_Giokham.Value = dateTimePicker_Ngaykham.Value;
                    comboBox_Doituong.Text = read["Doituong"].ToString();
                    textBox_Sothe.Text = read["Sobhyt"].ToString();
                    dateTimePicker_Tu.Value = DateTime.Parse(read["Bhytgiatritu"].ToString());
                    dateTimePicker_Den.Value = DateTime.Parse(read["Bhytgiatriden"].ToString());
                    textBox_Nguoithan.Text = read["Nguoithan"].ToString();
                    textBox_Dienthoai.Text = read["Dienthoai"].ToString();
                    textBox_Diachinguoithan.Text = read["Diachinguoithan"].ToString();
                    textBox_Noigioithieu.Text = read["Noigioithieu"].ToString();
                    textBox_Lydovaovien.Text = read["Lydovaovien"].ToString();
                    textBox_Chuandoan.Text = read["Chuandoanvaovien"].ToString();

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
            richTextBox_ylenh.Text = "";
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = idBenhnhan;
                com.CommandText = @"SELECT ylenh.Mota
                                        FROM phieukhambenh
                                        LEFT OUTER JOIN ngoaitru
                                            ON ngoaitru.Phieukhambenh_id=phieukhambenh.id 
                                        LEFT OUTER JOIN benhnhan
                                            ON benhnhan.id=phieukhambenh.Benhnhan_id 
                                        LEFT OUTER JOIN Ylenh
                                            ON Ylenh.Phieukhambenh_id=phieukhambenh.id 
                                        WHERE benhnhan.id=@id 
                                            AND ngoaitru.Tinhtrangravien=0
                                            AND ylenh.status=1";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    richTextBox_ylenh.Text = read[0].ToString();
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }

        public Hashtable get_CurrentObject(int idBenhnhan)
        {
            Hashtable hash = new Hashtable();
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = idBenhnhan;
                com.CommandText = @"SELECT benhnhan.id, phieukhambenh.id, ngoaitru.id, todieutri.id, phieuxetnghiem.id
                                        FROM benhnhan
                                        LEFT OUTER JOIN phieukhambenh 
                                            ON benhnhan.id=phieukhambenh.Benhnhan_id 
                                        LEFT OUTER JOIN ngoaitru
                                            ON phieukhambenh.id=ngoaitru.Phieukhambenh_id
                                        LEFT OUTER JOIN todieutri
                                            ON phieukhambenh.id=todieutri.Phieukhambenh_id
                                        LEFT OUTER JOIN todieutri_noidung
                                            ON todieutri.id=todieutri_noidung.Todieutri_id
                                        LEFT OUTER JOIN phieuxetnghiem
                                            ON phieukhambenh.id=phieuxetnghiem.Phieukhambenh_id
                                        WHERE benhnhan.id=@id AND ngoaitru.Tinhtrangravien=0
                                        GROUP BY benhnhan.id";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    hash.Add("idBenhnhan", read[0].ToString());
                    hash.Add("idPhieukhambenh", read[1].ToString());
                    hash.Add("idNgoaitru", read[2].ToString());
                    hash.Add("idTodieutri", read[3].ToString());
                    hash.Add("idPhieuxetnghiem", read[4].ToString());
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {

            }
            return hash;
        }

        public int get_CurrentYlenh(int idPhieukhambenh)
        {
            int idYlenh = -1;
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = idPhieukhambenh;
                com.CommandText = @"SELECT ylenh.id
                                        FROM ylenh
                                        WHERE Phieukhambenh_id=@id AND status=1";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                if (read.Read())
                {
                    idYlenh = int.Parse(read[0].ToString());
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {

            }
            return idYlenh;
        }
        private void listView_danhsachbenhnhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_danhsachbenhnhan.SelectedItems.Count < 1)
            {
                return;
            }
            textBox_MaBN.Text = listView_danhsachbenhnhan.SelectedItems[0].SubItems[0].Text;
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
                com.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = int.Parse(textBox_MaBN.Text);
                com.CommandText = @"SELECT benhnhan.Ten, benhnhan.Ngaysinh, todieutri_noidung.*, ngoaitru.*, ylenh.Mota
                                        FROM todieutri_noidung 
                                        LEFT OUTER JOIN todieutri
                                            ON todieutri_noidung.Todieutri_id=todieutri.id
                                        LEFT OUTER JOIN phieukhambenh 
                                            ON phieukhambenh.id=todieutri.Phieukhambenh_id 
                                        LEFT OUTER JOIN ngoaitru
                                            ON ngoaitru.Phieukhambenh_id=phieukhambenh.id 
                                        LEFT OUTER JOIN benhnhan
                                            ON benhnhan.id=phieukhambenh.Benhnhan_id 
                                        LEFT OUTER JOIN ylenh
                                            ON ylenh.id=todieutri_noidung.Ylenh_id                                         
                                        WHERE benhnhan.id=@id AND ngoaitru.Tinhtrangravien=0";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    Todieutri obj = new Todieutri();
                    obj.Tenbenhnhan = read["Ten"].ToString();
                    obj.Ngaysinh = DateTime.Parse(read["Ngaysinh"].ToString());
                    obj.Chandoan = read["Benhchinh"].ToString() + " - " + read["Benhkemtheo"].ToString();
                    obj.Ngaygio = DateTime.Parse(read["Ngaygio"].ToString());
                    obj.Dientienbenh = read["Dientienbenh"].ToString();
                    obj.Ylenh = read["Mota"].ToString();
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
            int idBenhnhan = 0;
            try
            {
                idBenhnhan = int.Parse(textBox_MaBN.Text);
            }
            catch (Exception ex)
            {

            }
            Hashtable currentObject = get_CurrentObject(idBenhnhan);
            if (currentObject.Count == 0)
            {
                return;
            }
            int currentYlenh = get_CurrentYlenh(int.Parse(currentObject["idPhieukhambenh"].ToString()));
            if (currentYlenh == -1)
            {
                return;
            }
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;

                if (currentObject["idTodieutri"].ToString() == "")
                {
                    com.Parameters.Add("@phieukhambenh_id", MySqlDbType.Int32, 11).Value = int.Parse(currentObject["idPhieukhambenh"].ToString());
                    com.CommandText = @"INSERT INTO todieutri(Phieukhambenh_id) 
                                            VALUES (@phieukhambenh_id)";
                    Util.con.Open();
                    com.ExecuteNonQuery();
                    Util.con.Close();
                    currentObject = get_CurrentObject(idBenhnhan);
                }

                com.Parameters.Add("@dientienbenh", MySqlDbType.Text).Value = richTextBox_dientienbenh.Text.Trim();
                com.Parameters.Add("@ngaygio", MySqlDbType.DateTime).Value = DateTime.Now;
                com.Parameters.Add("@todieutri_id", MySqlDbType.Int32, 11).Value = int.Parse(currentObject["idTodieutri"].ToString());
                com.Parameters.Add("@ylenh_id", MySqlDbType.Int32, 11).Value = currentYlenh;

                com.CommandText = @"INSERT INTO todieutri_noidung(Dientienbenh, Ngaygio, Todieutri_id, Ylenh_id) 
                                        VALUES (@dientienbenh, @ngaygio, @todieutri_id, @ylenh_id)";
                Util.con.Open();
                com.ExecuteNonQuery();
                Util.con.Close();

                com.CommandText = @"UPDATE ylenh SET status=0 WHERE id=@ylenh_id";
                Util.con.Open();
                com.ExecuteNonQuery();
                Util.con.Close();

                load_Dieutri(int.Parse(currentObject["idBenhnhan"].ToString()));
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }

        private void textBox_MaBN_TextChanged(object sender, EventArgs e)
        {
            int idBenhnhan = -1;
            try
            {
                idBenhnhan = int.Parse(textBox_MaBN.Text);
            }
            catch (Exception ex)
            {
             
            }
            load_Thongtinhanhchinh(idBenhnhan);
            load_Dieutri(idBenhnhan);
            load_Dientienbenh(idBenhnhan);
            load_Ylenh(idBenhnhan);
        }

        private void textBox_search_benhnhan_TextChanged(object sender, EventArgs e)
        {
            Show_danhsachbenhnhan();
        }
 

       
    }
}
