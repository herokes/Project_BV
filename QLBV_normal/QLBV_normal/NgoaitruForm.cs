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

        private void listView_danhsachbenhnhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = listView_danhsachbenhnhan.SelectedItems[0].SubItems[0].Text;
                com.CommandText = @"SELECT xn_pxn.Thongsoxetnghiem, xn.*, bn.*, pkb.* FROM xetnghiem_phieuxetnghiem xn_pxn  
                                        LEFT OUTER JOIN phieuxetnghiem pxn 
                                            ON pxn.id=xn_pxn.Phieuxetnghiem_id  
                                        LEFT OUTER JOIN xetnghiem xn 
                                            ON xn.id=xn_pxn.Xetnghiem_id
                                        LEFT OUTER JOIN phieukhambenh pkb 
                                            ON pkb.id=pxn.Phieukhambenh_id 
                                        LEFT OUTER JOIN ngoaitru ngt 
                                            ON pkb.id=ngt.Phieukhambenh_id 
                                        LEFT OUTER JOIN benhnhan bn 
                                            ON bn.id=pkb.Benhnhan_id 
                                        WHERE bn.id=@id AND ngt.Tinhtrangravien=0";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    textBox_MaBN.Text = read["Benhnhan_id"].ToString();
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
                com.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = listView_danhsachbenhnhan.SelectedItems[0].SubItems[0].Text;
                com.CommandText = @"SELECT xn_pxn.Thongsoxetnghiem, xn.*, bn.*, pkb.* FROM xetnghiem_phieuxetnghiem xn_pxn  
                                        LEFT OUTER JOIN phieuxetnghiem pxn 
                                            ON pxn.id=xn_pxn.Phieuxetnghiem_id  
                                        LEFT OUTER JOIN xetnghiem xn 
                                            ON xn.id=xn_pxn.Xetnghiem_id
                                        LEFT OUTER JOIN phieukhambenh pkb 
                                            ON pkb.id=pxn.Phieukhambenh_id 
                                        LEFT OUTER JOIN ngoaitru ngt 
                                            ON pkb.id=ngt.Phieukhambenh_id 
                                        LEFT OUTER JOIN benhnhan bn 
                                            ON bn.id=pkb.Benhnhan_id 
                                        WHERE bn.id=@id AND ngt.Tinhtrangravien=0";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    Todieutri obj = new Todieutri();
                    obj.Tenbenhnhan = read["Ten"].ToString();
                    obj.Ngaysinh = DateTime.Parse(read["Ngaysinh"].ToString());
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

 

       
    }
}
