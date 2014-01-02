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
        /// 
        private int idpkb;
        private int idbn;
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
                //Util.con.Close();
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
                MessageBox.Show("show_dsbenhnhan");
                return;
            }
        }

        private void NgoaitruFormnew_Load(object sender, EventArgs e)
        {
            Show_danhsachbenhnhan();
            //Util.con.Close();
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
                MessageBox.Show("load thong tin hanh chinh");
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
                MessageBox.Show("Load dieutri");
                return;
            }
        }

        public void load_Dientienbenh(int idBenhnhan)
        {
            richTextBox_dientienbenh.Text = "";
            //try
            //{
                if (Util.con.State == ConnectionState.Open)
                    Util.con.Close();
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = idBenhnhan;
                com.CommandText = @"SELECT phieukhambenh.*,ngoaitru.*
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
                    ////////////// thong tin dien bien benh///////
                    textBox_Quatrinhbenhly.Text = read["Quatrinhbenhly"].ToString();
                    textBox_Phuongphapdieutri.Text = read["Xuli"].ToString();
                    dateTimePicker_Ngaykham.Value =DateTime.Parse(read["Thoigiandenkham"].ToString());
                    dateTimePicker_Giokham.Value = dateTimePicker_Ngaykham.Value;
                    comboBox_Doituong.SelectedIndex = int.Parse(read["Doituong"].ToString()) - 1;
                    textBox_NoiDKKCBBD.Text = read["DKKCBBD"].ToString();
                    textBox_Sothe.Text = read["Sobhyt"].ToString();
                    dateTimePicker_Tu.Value = DateTime.Parse(read["Bhytgiatritu"].ToString());
                    dateTimePicker_Den.Value = DateTime.Parse(read["Bhytgiatriden"].ToString());
                    textBox_Nguoithan.Text = read["Nguoithan"].ToString();
                    textBox_Dienthoai.Text = read["Dienthoai"].ToString();
                    textBox_Diachinguoithan.Text = read["Diachinguoithan"].ToString();
                    textBox_Noigioithieu.Text = read["Noigioithieu"].ToString();
                    textBox_Lydovaovien.Text = read["Lydovaovien"].ToString();
                    textBox_Chuandoan.Text = read["Chuandoanvaovien"].ToString();
                    textBox_bskham.Text = read["Bacsikhambenh"].ToString();
                   /////// thong tin xuat vien/////
                    textBox_Quatrinhbenhly.Text= read["Quatrinhbenhly"].ToString();
                    textBox_Benhchinh.Text = read["Benhchinh"].ToString();
                    textBox_Benhkemtheo.Text = read["Benhkemtheo"].ToString();
                    textBox_Phuongphapdieutri.Text = read["Xuli"].ToString();
                    textBox_huongdieutri.Text = read["Huongdieutri"].ToString();
                    textBox_tenbsdieutri.Text = read["Bacsidieutri"].ToString();
                    
                    //richTextBox_tomtatketquaxetnghiem.Text = ketqua_xetnghiem_gannhat_chotongketbenh(timkiem_idphieuxetnghiem_gannhat(idpkb.ToString()));
                }
                Util.con.Close();
                //MessageBox.Show(timkiem_idphieuxetnghiem_gannhat(idpkb.ToString()).Length.ToString());
                if (check_xetnghiem(idpkb))
                {
                    //MessageBox.Show(timkiem_idphieuxetnghiem_gannhat(idpkb.ToString()));
                    int idxetnghiem1 = int.Parse(timkiem_idphieuxetnghiem_gannhat(idpkb.ToString()));
                    if (check_xetnghiemketqua(idxetnghiem1))
                    {
                        richTextBox_tomtatketquaxetnghiem.Text = ketqua_xetnghiem_gannhat_chotongketbenh(timkiem_idphieuxetnghiem_gannhat(idpkb.ToString()));
                    }
                }
                else richTextBox_tomtatketquaxetnghiem.Text = null;
                textBox_soxetnghiem.Text =solanxetnghiem(idpkb.ToString());
                textBox_toanbohoso.Text = (int.Parse(textBox_soxquang.Text) + int.Parse(textBox_soCtscanner.Text) + int.Parse(textBox_sosieuam.Text) + int.Parse(textBox_soxetnghiem.Text) + int.Parse(textBox_sokhac.Text)).ToString(); 
            //}
            //catch (MySqlException sqlE)
            //{
            //    MessageBox.Show("load dien bien benh");
            //    return;
            //}
        }

        public void load_Ylenh(int idBenhnhan)
        {
            richTextBox_ylenh.Text = "";
            try
            {
                if (Util.con.State == ConnectionState.Open)
                    Util.con.Close();
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
                MessageBox.Show("load y lenh");
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
                MessageBox.Show(" get current object");
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
                MessageBox.Show(" get current y lenh");
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
                MessageBox.Show("in to dieu tri");
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
                MessageBox.Show("add dieu tri");
                return;
            }
        }

        public void load_Xetnhgiem(int idPhieuxetnghiem)
        {
            textBox_tenxetnghiem.Text = "";
            textBox_ketquaxetnghiem.Text = "";
            listView_xetnghiem.Items.Clear();
            if (idPhieuxetnghiem != -2)
            {
                listView_ketquaxetnghiem.Items.Clear();
            }
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
                    while (read.Read())
                    {
                        Hashtable hash = new Hashtable();
                        hash.Add("xetnghiem_id", read["Xetnghiem_id"].ToString());
                        hash.Add("phieuxetnghiem_id", read["Phieuxetnghiem_id"].ToString());
                        hash.Add("thongsoxetnghiem", read["Thongsoxetnghiem"].ToString());
                        ListViewItem item = new ListViewItem();
                        item.Text = read["TenXetnghiem"].ToString();
                        item.Tag = hash;
                        item.SubItems.Add(read["Thongsobinhthuong"].ToString());
                        item.SubItems.Add(read["Thongsoxetnghiem"].ToString());
                        item.SubItems.Add(read["Donvi"].ToString());
                        listView_ketquaxetnghiem.Items.Add(item);
                    }
                    Util.con.Close();

                    int listView_xetnghiem_length = listView_xetnghiem.Items.Count;
                    int listView_ketquaxetnghiem_length = listView_ketquaxetnghiem.Items.Count;
                    if (listView_ketquaxetnghiem_length > 0)
                    {
                        for (int i = 0; i < listView_xetnghiem_length; i++)
                        {
                            listView_xetnghiem.Items[i].Checked = false;
                            Hashtable hashi = (Hashtable)listView_xetnghiem.Items[i].Tag;
                            for (int j = 0; j < listView_ketquaxetnghiem_length; j++)
                            {
                                Hashtable hashj = (Hashtable)listView_ketquaxetnghiem.Items[j].Tag;
                                if (hashi["id"].ToString() == hashj["xetnghiem_id"].ToString())
                                {
                                    listView_xetnghiem.Items[i].Checked = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Load xet nghiem");
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
                MessageBox.Show("Load phieu xet nghiem");
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
            idpkb = int.Parse(currentObject["idPhieukhambenh"].ToString());
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
                int idPhieukhambenh = int.Parse(currentObject["idPhieukhambenh"].ToString());
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;

                com.Parameters.Add("@ngayxetnghiem", MySqlDbType.DateTime).Value = DateTime.Now;
                com.Parameters.Add("@phieukhambenh_id", MySqlDbType.Int32, 11).Value = idPhieukhambenh;

                com.CommandText = @"INSERT INTO phieuxetnghiem(Ngayxetnghiem, Phieukhambenh_id) 
                                        VALUES (@ngayxetnghiem, @phieukhambenh_id)";
                Util.con.Open();
                com.ExecuteNonQuery();
                Util.con.Close();

                load_Phieuxetnhgiem(idBenhnhan, idPhieukhambenh);
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("create phieuxet nghiem");
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

        public bool cotrongKetquaxetnghiem(string id)
        {
            int listView_ketquaxetnghiem_length = listView_ketquaxetnghiem.Items.Count;
            for (int i = 0; i < listView_ketquaxetnghiem_length; i++)
            {
                Hashtable hash = (Hashtable)listView_ketquaxetnghiem.Items[i].Tag;
                if (hash["xetnghiem_id"].ToString() == id)
                {
                    return true;
                }
            }
            return false;
        }

        private void button_capnhatxetnghiem_Click(object sender, EventArgs e)
        {
            ArrayList insertArr = new ArrayList();
            ArrayList deleteArr = new ArrayList();
            int listView_xetnghiem_length = listView_xetnghiem.Items.Count;
            for (int i = 0; i < listView_xetnghiem_length; i++)
            {
                Hashtable hash = (Hashtable)listView_xetnghiem.Items[i].Tag;
                if (cotrongKetquaxetnghiem(hash["id"].ToString()))
                {
                    if (!listView_xetnghiem.Items[i].Checked)
                    {
                        deleteArr.Add(hash["id"].ToString());
                    }
                }
                else
                {
                    if (listView_xetnghiem.Items[i].Checked)
                    {
                        insertArr.Add(hash["id"].ToString());
                    }
                }
            }
            try
            {
                int idPhieuxetnghiem = -1;
                try
                {
                    idPhieuxetnghiem = int.Parse(comboBox_phieuxetnghiem.SelectedValue.ToString());
                }
                catch (Exception)
                {

                }
                if (idPhieuxetnghiem < 0)
                {
                    return;
                }
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;

                com.Parameters.Add("@phieuxetnghiem_id", MySqlDbType.Int32, 11).Value = idPhieuxetnghiem;
                if (deleteArr.Count > 0)
                {
                    string valueString = "";
                    int i = 0;
                    foreach (string id in deleteArr)
                    {
                        com.Parameters.Add("@xetnghiem_id" + i.ToString(), MySqlDbType.Int32, 11).Value = int.Parse(id);
                        if (i == 0)
                        {
                            valueString += "xetnghiem_id=@xetnghiem_id" + i.ToString();
                        }
                        else
                        {
                            valueString += " OR xetnghiem_id=@xetnghiem_id" + i.ToString();
                        }
                        i++;
                    }
                    if (MessageBox.Show("Bạn có muốn xóa xét nghiệm trong phiếu xét nghiệm này?", "Xác nhận xóa xét nghiệm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        com.CommandText = @"DELETE FROM xetnghiem_phieuxetnghiem WHERE Phieuxetnghiem_id=@phieuxetnghiem_id AND (" + valueString + ")";
                        Util.con.Open();
                        com.ExecuteNonQuery();
                        Util.con.Close();
                    }
                    else
                    {
                        return;
                    }
                }
                if (insertArr.Count > 0)
                {
                    string valueString = "";
                    int i = 0;
                    foreach (string id in insertArr)
                    {
                        com.Parameters.Add("@xetnghiem_id" + i.ToString(), MySqlDbType.Int32, 11).Value = int.Parse(id);
                        if (i == 0)
                        {
                            valueString += "(@xetnghiem_id" + i.ToString() + ", @phieuxetnghiem_id)";
                        }
                        else
                        {
                            valueString += ",(@xetnghiem_id" + i.ToString() + ", @phieuxetnghiem_id)";
                        }
                        i++;
                    }
                    com.CommandText = @"INSERT INTO xetnghiem_phieuxetnghiem (Xetnghiem_id, Phieuxetnghiem_id)
                                        VALUES " + valueString;
                    Util.con.Open();
                    com.ExecuteNonQuery();
                    Util.con.Close();
                }
                load_Xetnhgiem(idPhieuxetnghiem);
                //load_Phieuxetnhgiem(idBenhnhan, idPhieukhambenh);
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
                updateYlenh(1, idPhieuxetnghiem, idPhieukhambenh);
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }
/// <summary>
///  In Bênh an  ngoai tru
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
/// 
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
                com.CommandText = @"SELECT benhnhan.*,phieukhambenh.*,ngoaitru.*
                                        FROM benhnhan
                                        LEFT OUTER JOIN phieukhambenh 
                                            ON benhnhan.id=phieukhambenh.Benhnhan_id 
                                        LEFT OUTER JOIN ngoaitru
                                            ON phieukhambenh.id=ngoaitru.Phieukhambenh_id
                                        WHERE benhnhan.id=@id AND ngoaitru.Tinhtrangravien=0
                                        GROUP BY benhnhan.id";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    Benhanngoaitru bant = new Benhanngoaitru();
                    bant.Tenbenhnhan = read["Ten"].ToString();
                    bant.Ngaysinh = DateTime.Parse(read["Ngaysinh"].ToString());
                    // ngay thang nam
                    string a;
                    if (bant.Ngaysinh.Day.ToString().Length == 1)
                        a = "0" + bant.Ngaysinh.Day.ToString();
                    else
                        a = bant.Ngaysinh.Day.ToString();
                    bant.Ngay1 = a.Substring(0, 1);
                    bant.Ngay2 = a.Substring(1, 1);
                    if (bant.Ngaysinh.Month.ToString().Length == 1)
                        a = "0" + bant.Ngaysinh.Month.ToString();
                    else
                        a = bant.Ngaysinh.Month.ToString();
                    bant.Thang1 = a.Substring(0, 1);
                    bant.Thang2 = a.Substring(1, 1);
                    bant.Nam1 = bant.Ngaysinh.Year.ToString().Substring(0, 1);
                    bant.Nam2 = bant.Ngaysinh.Year.ToString().Substring(1, 1);
                    bant.Nam3 = bant.Ngaysinh.Year.ToString().Substring(2, 1);
                    bant.Nam4 = bant.Ngaysinh.Year.ToString().Substring(3, 1);
                    bant.Tuoi = DateTime.Today.Year - DateTime.Parse(read["Ngaysinh"].ToString()).Year;
                    if (int.Parse(read["Gioitinh"].ToString()) == 0)
                        bant.Gioitinh = 1;
                    else bant.Gioitinh = 2;
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
                    bant.Dieutritu = DateTime.Parse(read["Dieutritu"].ToString());
                   // bant.Dieutriden = DateTime.Parse(read["Dieutriden"].ToString());
                    bant.Bacsikham= read["Bacsikhambenh"].ToString();
                    frmMain.frmReport.arrReport.Add(bant);
                }
                Util.con.Close();
                frmMain.frmReport.Show();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("in benh an ngoai tru");
                return;
            }
        }

        private void textBox_idbacsi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox_idbacsi.TextLength > 0)
                {
                    MySqlCommand com = new MySqlCommand();
                    com.Connection = Util.con;
                    com.CommandText = "SELECT * FROM bacsi WHERE id= " + textBox_idbacsi.Text;
                    //MessageBox.Show(com.CommandText.te);
                    Util.con.Open();
                    MySqlDataReader read = com.ExecuteReader();
                    if (read.Read())
                    {
                        //MessageBox.Show(read[1].ToString());
                        //comboBox_Bacsikham.Text = read[1].ToString();
                        textBox_tenbsdieutri.Text = read[1].ToString();
                    }
                    Util.con.Close();
                }
            }
            catch (MySqlException sqlE)
            {
                //Util.con.Close();
                MessageBox.Show(sqlE.Source.ToString());
                return;
            }
        }

        private void button_refresh_xetnghiem_status_Click(object sender, EventArgs e)
        {
            load_Xetnhgiem(-1);
        }


        private void button_delete_phieuxetnghiem_Click(object sender, EventArgs e)
        {
            int idPhieuxetnghiem = -1;
            try
            {
                idPhieuxetnghiem = int.Parse(comboBox_phieuxetnghiem.SelectedValue.ToString());
            }
            catch (Exception)
            {

            }
            if (idPhieuxetnghiem != -1)
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
                try
                {
                    MySqlCommand com = new MySqlCommand();
                    com.Connection = Util.con;
                    com.Parameters.Add("@idPhieuxetnghiem", MySqlDbType.Int32, 11).Value = idPhieuxetnghiem;
                    com.CommandText = @"SELECT *
                                        FROM xetnghiem_phieuxetnghiem
                                        WHERE Phieuxetnghiem_id=@idPhieuxetnghiem";
                    Util.con.Open();
                    MySqlDataReader read = com.ExecuteReader();
                    bool hasData = read.Read();
                    Util.con.Close();
                    if (hasData)
                    {
                        if (MessageBox.Show("Phiếu xét nghiệm này vẫn còn kết quả xét nghiệm. Vui lòng xóa các kết quả xét nghiệm trước khi xóa phiếu xét nghiệm này!!!", "Lỗi khi xóa phiếu xét nghiệm", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                        {
                            
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Bạn có muốn xóa phiếu xét nghiệm này?", "Xác nhận xóa phiếu xét nghiệm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Util.con.Open();
                            com.CommandText = @"DELETE FROM phieuxetnghiem WHERE id=@idPhieuxetnghiem";
                            com.ExecuteNonQuery();
                            Util.con.Close();
                            load_Phieuxetnhgiem(idBenhnhan, idPhieukhambenh);
                        }
                    }
                }
                catch (MySqlException mye)
                {

                }
            }
        }

        private void listView_ketquaxetnghiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_ketquaxetnghiem.SelectedItems.Count < 1)
            {
                return;
            }
            textBox_tenxetnghiem.Text = listView_ketquaxetnghiem.SelectedItems[0].SubItems[0].Text;
            textBox_ketquaxetnghiem.Text = listView_ketquaxetnghiem.SelectedItems[0].SubItems[2].Text;
        }

        public string timkiem_idphieuxetnghiem_gannhat(string idphieukhambenh)
        {
            //try
            //{
            if(Util.con.State == ConnectionState.Open)
                Util.con.Close();
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.CommandText = @"select max(phieuxetnghiem.id)
                                    from phieuxetnghiem 
                                    where phieuxetnghiem.Phieukhambenh_id=" + idphieukhambenh;
                Util.con.Open();
                MySqlDataReader read=  com.ExecuteReader();
                read.Read();
                string id= read[0].ToString();
                Util.con.Close();
                //MessageBox.Show(id.ToString());
            //if(id=null) return id= -1;
                return id;
            //}
            //catch (MySqlException sqlE)
            //{
            //    Util.con.Close();
            //    MessageBox.Show(sqlE.Source.ToString());
            //    return null;
            //}
        }
        
        public string ketqua_xetnghiem_gannhat_chotongketbenh (string idphieuxetnghiem)
        {
            //try
            //{
                string ketqua = "";
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.CommandText = @"SELECT xetnghiem_phieuxetnghiem.*, xetnghiem.TenXetnghiem ,xetnghiem.Donvi
                                    FROM xetnghiem_phieuxetnghiem,xetnghiem
                                    WHERE (
                                    xetnghiem_phieuxetnghiem.Xetnghiem_id =3
                                    OR xetnghiem_phieuxetnghiem.Xetnghiem_id =4
                                    OR xetnghiem_phieuxetnghiem.Xetnghiem_id =16
                                    OR xetnghiem_phieuxetnghiem.Xetnghiem_id =17
                                    )
                                    AND xetnghiem_phieuxetnghiem.Phieuxetnghiem_id = " + idphieuxetnghiem +
                                    @" AND xetnghiem_phieuxetnghiem.Xetnghiem_id= xetnghiem.id
                                    ORDER BY xetnghiem.id DESC ";
                                                                                      ;
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
               // Xetnghiem xn = new Xetnghiem();
                while (read.Read())
                {
                    ketqua += read["Tenxetnghiem"].ToString() + ":  " + read["Thongsoxetnghiem"].ToString()+ read["Donvi"].ToString() + "\n ";
                }
                Util.con.Close();
                return ketqua;
            //}
            //catch (MySqlException sqlE)
            //{
            //    Util.con.Close();
            //    MessageBox.Show(sqlE.Source.ToString());
            //    return null;
            //}
        
        }

        public bool check_xetnghiemketqua (int idphieuxetnghiem)
        {
            //string id= timkiem_idphieuxetnghiem_gannhat(idpkb.ToString());
            MySqlCommand com = new MySqlCommand();
            com.Connection = Util.con;
            com.CommandText = @"select COUNT(xetnghiem_phieuxetnghiem.Phieuxetnghiem_id)
                                from xetnghiem_phieuxetnghiem 
                                where xetnghiem_phieuxetnghiem.Phieuxetnghiem_id= " + idphieuxetnghiem;
           
            Util.con.Open();
            MySqlDataReader read = com.ExecuteReader();
            read.Read();
            int b = int.Parse(read[0].ToString());
            Util.con.Close();
            
            if (b > 0) return true;
            return false;
            
        }
        public bool check_xetnghiem(int idphieukhambenh)
        {
            //string id= timkiem_idphieuxetnghiem_gannhat(idpkb.ToString());
            MySqlCommand com = new MySqlCommand();
            com.Connection = Util.con;
            com.CommandText = @"select COUNT(phieuxetnghiem.id)
                                    from phieuxetnghiem
                                    where phieuxetnghiem.Phieukhambenh_id= " + idphieukhambenh;

            Util.con.Open();
            MySqlDataReader read = com.ExecuteReader();
            read.Read();

            if (int.Parse(read[0].ToString()) > 0)
            {
                Util.con.Close();
                return true;
            }
            return false;
            

        }
        private void textBox_soxquang_TextChanged(object sender, EventArgs e)
        {
            textBox_toanbohoso.Text = (int.Parse(textBox_soxquang.Text) + int.Parse(textBox_soCtscanner.Text) + int.Parse(textBox_sosieuam.Text) + int.Parse(textBox_soxetnghiem.Text) + int.Parse(textBox_sokhac.Text)).ToString(); 
        }

        private void textBox_Ctscanner_TextChanged(object sender, EventArgs e)
        {
            textBox_toanbohoso.Text = (int.Parse(textBox_soxquang.Text) + int.Parse(textBox_soCtscanner.Text) + int.Parse(textBox_sosieuam.Text) + int.Parse(textBox_soxetnghiem.Text) + int.Parse(textBox_sokhac.Text)).ToString(); 
        }

        private void textBox_sieuam_TextChanged(object sender, EventArgs e)
        {
            textBox_toanbohoso.Text = (int.Parse(textBox_soxquang.Text) + int.Parse(textBox_soCtscanner.Text) + int.Parse(textBox_sosieuam.Text) + int.Parse(textBox_soxetnghiem.Text) + int.Parse(textBox_sokhac.Text)).ToString(); 
        }
        public string solanxetnghiem(String idphieukhambenh)
        {
            MySqlCommand com = new MySqlCommand();
            com.Connection = Util.con;
            com.CommandText = @"select COUNT(phieuxetnghiem.id)
                                    from phieuxetnghiem
                                    where phieuxetnghiem.Phieukhambenh_id= " + idphieukhambenh;

            Util.con.Open();
            MySqlDataReader read = com.ExecuteReader();
            read.Read();
            int b = int.Parse(read[0].ToString());
            Util.con.Close();
            return b.ToString();
        }
        private void textBox_xetnghiem_TextChanged(object sender, EventArgs e)
        {
            //string id= timkiem_idphieuxetnghiem_gannhat(idpkb.ToString());
            
            textBox_soxetnghiem.Text = solanxetnghiem(idpkb.ToString());
            textBox_toanbohoso.Text = (int.Parse(textBox_soxquang.Text) + int.Parse(textBox_soCtscanner.Text) + int.Parse(textBox_sosieuam.Text) + int.Parse(textBox_soxetnghiem.Text) + int.Parse(textBox_sokhac.Text)).ToString(); 
        }

        private void textBox_khac_TextChanged(object sender, EventArgs e)
        {
            textBox_toanbohoso.Text = (int.Parse(textBox_soxquang.Text) + int.Parse(textBox_soCtscanner.Text) + int.Parse(textBox_sosieuam.Text) + int.Parse(textBox_soxetnghiem.Text) + int.Parse(textBox_sokhac.Text)).ToString(); 
        }
        private void button_Xuatvien_Click(object sender, EventArgs e)
        {
           string a= @"UPDATE ngoaitru 
            SET Ngaygiovaovien = '2014-01-13 00:00:00', 
            `Benhchinh` = 'benh chinh', 
            `Benhkemtheo` = 'benh kem theo', 
            `Dieutritu` = '2014-01-07 00:00:00', 
            `Dieutriden` = '2014-01-21 00:00:00', 
            `Tinhtrangravien` = '2', 
            `Chuandoankhiravien` = 'chuan doan', 
            `Huongdieutri` = 'huong dieu tri', 
            `Bacsikhambenh` = 'bs kham', 
            `Bacsidieutri` = 'bs dieu tri', 
            `Soxquang` = '01', 
            `Soctscanner` = '01', 
            `Sosieuam` = '01', 
            `Soxetnghiem` = '01', 
            `Sokhac` = '01' 
            WHERE `ngoaitru`.`id` = 1";
        }

        private void button_nhapketquaxetnghiem_Click(object sender, EventArgs e)
        {
            int items_count = listView_ketquaxetnghiem.Items.Count;
            if (listView_ketquaxetnghiem.SelectedItems.Count < 1)
            {
                return;
            }
            Hashtable hash = (Hashtable)listView_ketquaxetnghiem.SelectedItems[0].Tag;
            hash["thongsoxetnghiem"] = textBox_ketquaxetnghiem.Text;
            listView_ketquaxetnghiem.SelectedItems[0].SubItems[2].Text = hash["thongsoxetnghiem"].ToString();
            listView_ketquaxetnghiem.SelectedItems[0].Tag = hash;
            int index = listView_ketquaxetnghiem.SelectedIndices[0];
            if (index + 1 < items_count)
            {
                listView_ketquaxetnghiem.Items[index + 1].Selected = true;
                listView_ketquaxetnghiem.Items[index + 1].EnsureVisible();
            }
            textBox_ketquaxetnghiem.Focus();
        }

        private void textBox_ketquaxetnghiem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_nhapketquaxetnghiem_Click(sender, e);
            }
        }

        private void button_save_ketquaxetnghiem_Click(object sender, EventArgs e)
        {
            int idPhieuxetnghiem = -1;
            try
            {
                idPhieuxetnghiem = int.Parse(comboBox_phieuxetnghiem.SelectedValue.ToString());
            }
            catch (Exception)
            {

            }
            if (idPhieuxetnghiem == -1)
            {
                return;
            }
            int listView_ketquaxetnghiem_length = listView_ketquaxetnghiem.Items.Count;
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;

                string valueString1 = "", valueString2 = "";
                for (int i = 0; i < listView_ketquaxetnghiem_length; i++)
                {
                    Hashtable hash = (Hashtable)listView_ketquaxetnghiem.Items[i].Tag;
                    com.Parameters.Add("@xetnghiem_id" + i.ToString(), MySqlDbType.Int32, 11).Value = int.Parse(hash["xetnghiem_id"].ToString());
                    com.Parameters.Add("@thongsoxetnghiem" + i.ToString(), MySqlDbType.VarChar, 45).Value = hash["thongsoxetnghiem"].ToString();
                    valueString1 += " WHEN @xetnghiem_id" + i.ToString() + " THEN @thongsoxetnghiem" + i.ToString();
                    if (i == 0)
                    {
                        valueString2 += "@xetnghiem_id" + i.ToString();
                    }
                    else
                    {
                        valueString2 += ", @xetnghiem_id" + i.ToString();
                    }
                }
                
                com.Parameters.Add("@phieuxetnghiem_id", MySqlDbType.Int32, 11).Value = idPhieuxetnghiem;

                com.CommandText = @"UPDATE xetnghiem_phieuxetnghiem SET Thongsoxetnghiem = CASE Xetnghiem_id" + valueString1 + " END WHERE Xetnghiem_id IN ("+ valueString2 + ") AND Phieuxetnghiem_id=@phieuxetnghiem_id";

                if (MessageBox.Show("Bạn có muốn lưu kết quả xét nghiệm này?", "Xác nhận cập nhật kết quả xét nghiệm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Util.con.Open();
                    com.ExecuteNonQuery();
                    Util.con.Close();

                    load_Xetnhgiem(idPhieuxetnghiem);
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
                    updateYlenh(2, idPhieuxetnghiem, idPhieukhambenh);
                }
                
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("update kết quả xét nghiệm");
                return;
            }
        }

        public void updateYlenh(int loai, int idLoai, int idPhieukhambenh)
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@idPhieukhambenh", MySqlDbType.Int32, 11).Value = idPhieukhambenh;
                com.Parameters.Add("@loai", MySqlDbType.Int32, 11).Value = loai;
                com.Parameters.Add("@idLoai", MySqlDbType.Int32, 11).Value = idLoai;
                com.Parameters.Add("@mota", MySqlDbType.Text).Value = formatterYlenh(loai, idLoai);
                com.CommandText = @"SELECT ylenh.*
                                        FROM ylenh
                                        WHERE phieukhambenh_id=@idPhieukhambenh
                                            AND status=1";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                bool hasYlenhNoComplete = false;
                int idYlenhNoComplete = -1;
                while (read.Read())
                {
                    hasYlenhNoComplete = true;
                    idYlenhNoComplete = int.Parse(read["id"].ToString());
                }
                Util.con.Close();

                if (hasYlenhNoComplete)
                {
                    if (MessageBox.Show("Bạn có muốn hủy y lệnh chưa hoàn thành trước đó và sử dụng y lệnh vừa tạo?", "Xác nhận xóa y lệnh chưa hoàn thành", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        com.Parameters.Add("@idYlenh", MySqlDbType.Int32, 11).Value = idYlenhNoComplete;
                        com.CommandText = "DELETE FROM ylenh WHERE id=@idYlenh";
                        Util.con.Open();
                        com.ExecuteNonQuery();
                        Util.con.Close();
                    }
                }
                com.CommandText = @"INSERT INTO ylenh (loai, id_loai, Phieukhambenh_id, Mota, Bacsi_id) 
                                                VALUES (@loai, @idLoai, @idPhieukhambenh, @mota, 1)";
                Util.con.Open();
                com.ExecuteNonQuery();
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Load phieu xet nghiem");
                return;
            }
        }

        public string formatterYlenh(int loai, int idLoai)
        {
            string valueString = "";
            MySqlCommand com = new MySqlCommand();
            com.Connection = Util.con;
            com.Parameters.Add("@idLoai", MySqlDbType.Int32, 11).Value = idLoai;
            MySqlDataReader read;
            switch (loai)
            {
                case 1:
                    valueString = "Xét nghiệm:\n";
                    com.CommandText = @"SELECT xetnghiem_phieuxetnghiem.*, xetnghiem.*
                                        FROM xetnghiem_phieuxetnghiem
                                        LEFT OUTER JOIN ylenh
                                            ON ylenh.id_loai=xetnghiem_phieuxetnghiem.Phieuxetnghiem_id
                                        LEFT OUTER JOIN xetnghiem
                                            ON xetnghiem.id=xetnghiem_phieuxetnghiem.Xetnghiem_id 
                                        WHERE xetnghiem_phieuxetnghiem.Phieuxetnghiem_id=@idLoai";
                    Util.con.Open();
                    read = com.ExecuteReader();
                    while (read.Read())
                    {
                        valueString += read["Tenxetnghiem"].ToString() + "\n";
                    }
                    Util.con.Close();
                    break;
                case 2:
                    valueString = "Kết quả xét nghiệm:\n";
                    com.CommandText = @"SELECT xetnghiem_phieuxetnghiem.*, xetnghiem.*
                                        FROM xetnghiem_phieuxetnghiem
                                        LEFT OUTER JOIN ylenh
                                            ON ylenh.id_loai=xetnghiem_phieuxetnghiem.Phieuxetnghiem_id
                                        LEFT OUTER JOIN xetnghiem
                                            ON xetnghiem.id=xetnghiem_phieuxetnghiem.Xetnghiem_id 
                                        WHERE xetnghiem_phieuxetnghiem.Phieuxetnghiem_id=@idLoai";
                    Util.con.Open();
                    read = com.ExecuteReader();
                    while (read.Read())
                    {
                        valueString += read["Tenxetnghiem"].ToString() + ": " + read["Thongsoxetnghiem"].ToString() + read["Donvi"].ToString() + "\n";
                    }
                    Util.con.Close();
                    break;
                default:
                    break;
            }
            return valueString;
        }

    }
}
