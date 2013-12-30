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
        /// <summary>
        /// to dieu tri va y lenh
        /// </summary>
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
            //autocomplete_thuoc();
           
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
                    dateTimePicker_Ngaykham.Value = DateTime.Parse(read["Thoigiandenkham"].ToString());

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
                    //textBox_Chuandoan.Text = read["Chuandoanvaovien"].ToString();

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
            int idBenhnhan = -1;
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
            frmMain.frmReport = new ReportForm();
            frmMain.frmReport.frmMain = this.frmMain;
            frmMain.frmReport.MdiParent = this.frmMain;
            frmMain.frmReport.arrReport = new ArrayList();
            frmMain.frmReport.typeReport = "todieutri";
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = int.Parse(currentObject["idBenhnhan"].ToString());
                com.CommandText = @"SELECT benhnhan.Ten, benhnhan.Ngaysinh, todieutri_noidung.*, ngoaitru.*, ylenh.Mota, bacsi.TenBacsi
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
                                        LEFT OUTER JOIN bacsi
                                            ON bacsi.id=ylenh.Bacsi_id                                         
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
                    obj.Bacsi = read["TenBacsi"].ToString();
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
            int idBenhnhan = -1;
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

        public void load_Xetnhgiem(int idPhieuxetnghiem)
        {
            listView_xetnghiem.Items.Clear();
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.CommandText = @"SELECT *
                                        FROM xetnghiem";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    Hashtable hash = new Hashtable();
                    hash.Add("id", read["id"].ToString());
                    hash.Add("tenxetnghiem", read["TenXetnghiem"].ToString());
                    ListViewItem item = new ListViewItem();
                    item.Text = read["TenXetnghiem"].ToString();
                    item.Tag = hash;
                    item.Checked = int.Parse(read["Macdinh"].ToString()) == 1 ? true : false;
                    listView_xetnghiem.Items.Add(item);
                }
                Util.con.Close();
                if (idPhieuxetnghiem != -1)
                {
                    com.Parameters.Add("@idPhieuxetnghiem", MySqlDbType.Int32, 11).Value = idPhieuxetnghiem;
                    com.CommandText = @"SELECT *
                                        FROM xetnghiem_phieuxetnghiem
                                        LEFT OUTER JOIN xetnghiem
                                        	ON xetnghiem_phieuxetnghiem.Xetnghiem_id = xetnghiem.id
                                        WHERE Phieuxetnghiem_id=@idPhieuxetnghiem";
                    Util.con.Open();
                    read = com.ExecuteReader();
                    //while (read.Read())
                    //{
                    //    ListViewItem item = new ListViewItem();
                    //    item.Text = read["TenXetnghiem"].ToString();
                    //    item.Tag = hash;
                    //    item.Checked = int.Parse(read["Macdinh"].ToString()) == 1 ? true : false;
                    //    listView_xetnghiem.Items.Add(item);
                    //    listView_ketquaxetnghiem.Items.Add(item);
                    //}
                    int list_length = listView_xetnghiem.Items.Count;
                    for (int i = 0; i < list_length; i++)
                    {
                        listView_xetnghiem.Items[i].Checked = false;
                        while (read.Read())
                        {
                            Hashtable hash = (Hashtable)listView_xetnghiem.Items[i].Tag;
                            if (hash["id"].ToString() == read["Xetnghiem_id"].ToString())
                            {
                                listView_xetnghiem.Items[i].Checked = true;
                            }
                        }
                    }
                    Util.con.Close();
                }
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }

        public void load_Phieuxetnhgiem(int idBenhnhan, int idPhieukhambenh)
        {
            comboBox_phieuxetnghiem.DataSource = null;
            comboBox_phieuxetnghiem.Text = "";
            comboBox_phieuxetnghiem.SelectedIndex = -1;
            comboBox_phieuxetnghiem.DisplayMember = "Text";
            comboBox_phieuxetnghiem.ValueMember = "Value";
            List<object> myCollection = new List<object>();
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@idBenhnhan", MySqlDbType.Int32, 11).Value = idBenhnhan;
                com.Parameters.Add("@idPhieukhambenh", MySqlDbType.Int32, 11).Value = idPhieukhambenh;
                com.CommandText = @"SELECT phieuxetnghiem.*
                                        FROM phieuxetnghiem
                                        LEFT OUTER JOIN phieukhambenh
                                            ON phieuxetnghiem.Phieukhambenh_id=phieukhambenh.id 
                                        LEFT OUTER JOIN ngoaitru
                                            ON ngoaitru.Phieukhambenh_id=phieukhambenh.id 
                                        LEFT OUTER JOIN benhnhan
                                            ON benhnhan.id=phieukhambenh.Benhnhan_id
                                        WHERE benhnhan.id=@idBenhnhan
                                            AND phieukhambenh.id=@idPhieukhambenh
                                        ORDER BY Ngayxetnghiem desc";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    myCollection.Add(new {Text = DateTime.Parse(read["Ngayxetnghiem"].ToString()).ToString("dd/MM/yyyy"), Value = read["id"].ToString()});
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                return;
            }
            comboBox_phieuxetnghiem.DataSource = (object)myCollection;
            if (comboBox_phieuxetnghiem.Items.Count > 0)
            {
                comboBox_phieuxetnghiem.SelectedIndex = 0;
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
            Hashtable currentObject = get_CurrentObject(idBenhnhan);
            if (currentObject.Count == 0)
            {
                return;
            }
            int idPhieukhambenh = int.Parse(currentObject["idPhieukhambenh"].ToString());
            load_Thongtinhanhchinh(idBenhnhan);
            load_Dieutri(idBenhnhan);
            load_Dientienbenh(idBenhnhan);
            load_Ylenh(idBenhnhan);
            load_Phieuxetnhgiem(idBenhnhan, idPhieukhambenh);
            load_Xetnhgiem(-1);
        }

        private void textBox_search_benhnhan_TextChanged(object sender, EventArgs e)
        {
            Show_danhsachbenhnhan();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///  In Bênh an  ngoai tru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Inbenhanngoaitru_Click(object sender, EventArgs e)
        {
            frmMain.frmReport = new ReportForm();
            frmMain.frmReport.frmMain = this.frmMain;
            frmMain.frmReport.MdiParent = this.frmMain;
            frmMain.frmReport.arrReport = new ArrayList();
            frmMain.frmReport.typeReport = "benhanngoaitru";
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = int.Parse(textBox_MaBN.Text);
                com.CommandText = "SELECT * FROM phieukhambenh pkb LEFT OUTER JOIN benhnhan bn ON pkb.Benhnhan_id=bn.id LEFT OUTER JOIN ngoaitru ngt ON pkb.id = ngt.Phieukhambenh_id WHERE ngt.phieukhambenh_id=@id";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    Benhanngoaitru bant = new Benhanngoaitru();
                    bant.Tenbenhnhan = read["Ten"].ToString();
                    bant.Ngaysinh = DateTime.Parse(read["Ngaysinh"].ToString());
                    bant.Tuoi = DateTime.Today.Year - DateTime.Parse(read["Ngaysinh"].ToString()).Year;
                    bant.Gioitinh = bool.Parse(read["Gioitinh"].ToString()) ? 1 : 2;
                    bant.Nghenghiep = read["Nghenghiep"].ToString();
                    bant.Dantoc = read["Dantoc"].ToString();
                    bant.Ngoaikieu = read["Ngoaikieu"].ToString();
                    bant.Sonha = read["Sonha"].ToString();
                    bant.Duong = read["Duong"].ToString();
                    bant.Phuong = read["Phuong"].ToString();
                    bant.Quan = read["Quan"].ToString();
                    bant.Thanhpho = read["Thanhpho"].ToString();
                    bant.Noilamviec = read["Noilamviec"].ToString();
                    bant.Doituong = int.Parse(read["Doituong"].ToString());
                    bant.Bhytgiatritu = read["Bhytgiatritu"].ToString();
                    bant.Bhytgiatritu = read["Bhytgiatritu"].ToString();
                    bant.Sobhyt = read["Sobhyt"].ToString();
                    bant.Nguoithan = read["Nguoithan"].ToString();
                    bant.Diachinguoithan = read["Diachinguoithan"].ToString();
                    bant.Dienthoai = read["Dienthoai"].ToString();
                    bant.Thoigiandenkham = read["Thoigiandenkham"].ToString();
                    bant.Noigioithieu = read["Noigioithieu"].ToString();
                    bant.Lydovaovien = read["Lydovaovien"].ToString();
                    bant.Quatrinhbenhly = read["Quatrinhbenhly"].ToString();
                    bant.Tiensubenhbanthan = read["Tiensubenhbanthan"].ToString();
                    bant.Tiensubenhgiadinh = read["Tiensubenhgiadinh"].ToString();
                    bant.Mach = read["Mach"].ToString();
                    bant.Nhietdo = read["Nhietdo"].ToString();
                    bant.Huyetap = read["Huyetap"].ToString();
                    bant.Nhiptho = read["Nhiptho"].ToString();
                    bant.Trongluong = read["Trongluong"].ToString();
                    bant.Toanthan = read["Toanthan"].ToString();
                    bant.Cacbophan = read["Cacbophan"].ToString();
                    bant.Tomtatketqualamsan = read["Tomtatketqualamsan"].ToString();
                    bant.Chuandoanvaovien = read["Chuandoanvaovien"].ToString();
                    bant.Xuli = read["Xuli"].ToString();
                    bant.Dieutritaikhoa = read["Dieutritaikhoa"].ToString();
                    bant.Chuy = read["Chuy"].ToString();

                    frmMain.frmReport.arrReport.Add(bant);
                }
                Util.con.Close();
                frmMain.frmReport.Show();
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }
        public void load_Thongtinbenh(int idBenhnhan)
        {
            // richTextBox_dientienbenh.Text = "";
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
                    dateTimePicker_Ngaykham.Value = DateTime.Parse(read["Thoigiandenkham"].ToString());

        private void button_create_phieuxetnghiem_Click(object sender, EventArgs e)
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
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;

                com.Parameters.Add("@ngayxetnghiem", MySqlDbType.DateTime).Value = DateTime.Now;
                com.Parameters.Add("@phieukhambenh_id", MySqlDbType.Int32, 11).Value = int.Parse(currentObject["idPhieukhambenh"].ToString());

                com.CommandText = @"INSERT INTO phieuxetnghiem(Ngayxetnghiem, Phieukhambenh_id) 
                                        VALUES (@ngayxetnghiem, @phieukhambenh_id)";
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

        private void comboBox_phieuxetnghiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPhieuxetnghiem = -1;
            try
            {
                idPhieuxetnghiem = int.Parse(comboBox_phieuxetnghiem.SelectedValue.ToString());
            }
            catch (Exception)
            {

            }
            load_Xetnhgiem(idPhieuxetnghiem);
        }


       
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
                    //textBox_Chuandoan.Text = read["Chuandoanvaovien"].ToString();


                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        /// cấp thuốc






































        private void textBox_tenthuoc_TextChanged(object sender, EventArgs e)
        {
            //Util.con.Open();
            
            MySqlCommand com = new MySqlCommand();
            com.Connection = Util.con;
            com.Parameters.Add("@tenthuoc", MySqlDbType.VarChar, 100);
            com.CommandText = "select * from Thuoc where Tenthuoc  like '" + textBox_tenthuoc.Text +"%'";
            Util.con.Open();
            MySqlDataReader read = com.ExecuteReader();
            listView_thuoc.Items.Clear();
            while (read.Read())
            {
                int i = listView_thuoc.Items.Count;
                listView_thuoc.Items.Add(read["id"].ToString());
                listView_thuoc.Items[i].SubItems.Add(read["Tenthuoc"].ToString());
                listView_thuoc.Items[i].SubItems.Add(read["Hamluong"].ToString());
                listView_thuoc.Items[i].SubItems.Add(read["Dang"].ToString());
                listView_thuoc.Items[i].SubItems.Add(read["Duongdung"].ToString());
            }
            read.Close();
            //textBox_tenthuoc.AutoCompleteCustomSource = list;
            Util.con.Close();

        }
        public void autocomplete_thuoc()
        {
            textBox_tenthuoc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_tenthuoc.AutoCompleteSource = AutoCompleteSource.CustomSource;
           
            MySqlCommand com = new MySqlCommand();
            com.Connection = Util.con;
            com.CommandText = "select * from Thuoc";
            Util.con.Open();
            MySqlDataReader read = com.ExecuteReader();
            AutoCompleteStringCollection list = new AutoCompleteStringCollection();
            while (read.Read())
            {
                list.Add(read["Tenthuoc"].ToString() + " " + read["Hamluong"].ToString() + " " + read["Duongdung"].ToString());
            }
            read.Close();
            textBox_tenthuoc.AutoCompleteCustomSource = list;
            Util.con.Close();
        }
        private void textBox_thuocsongay_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_toathuocsongay.Text != null)
                    {
                        dateTimePicker_thuocdenngay.Value = dateTimePicker_thuoctungay.Value.AddDays(int.Parse(textBox_toathuocsongay.Text));
                        this.textBox_tenthuoc.Focus();
                    }
                    // this.textBox_idICDkemtheo.Focus();
                    //richTextBox_Chuandoan.Text = textBox_Benhchinh.Text;

                }
                else return;
            }
            catch (MySqlException sqlE)
            {

                return;
            }
        }
// tao toa thuoc moi
        private void button_thuoc_moi_Click(object sender, EventArgs e)
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
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.CommandText = @"INSERT Toathuoc (id,Tungay,Denngay,Loidan,Bacsi,Phieukhambenh_id)
                                    valuse (null,null,null,'Hạn lạt, hạn chế trái cây. Đo huyết áp hằng ngày.'," + textBox_thuoc_tenbacsi.Text + "," + currentObject["idphieukhambenh"].ToString() + ")";
                Util.con.Open();
                MessageBox.Show(com.CommandText.ToString());
                Util.con.Close();
                MessageBox.Show("tao toa thuoc thanh cong "); 
                textBox_tenthuoc.Focus();

        }

        private void button_thuoc_in_Click(object sender, EventArgs e)
        {

        }

        private void button_thuoc_huy_Click(object sender, EventArgs e)
        {

        }

        private void button_thuoc_sua_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void listView_thuoc_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView_thuoc.SelectedItems.Count < 1)
            {
                return;
            }
           
            
                textBox_idthuoc.Text = listView_thuoc.SelectedItems[0].SubItems[0].Text;
                textBox_tenthuoc.Text = listView_thuoc.SelectedItems[0].SubItems[1].Text;
               // textBox_donvitinh.Text = listView_thuoc.SelectedItems[0].SubItems[3].Text;
                textBox_tenthuoc.Focus();
        }



    }     

}
