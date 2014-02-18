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
        private int idpxn;
        private int control;
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
            load_Bacsi();
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
                    Hashtable hash = new Hashtable();
                    hash.Add("id", read["id"].ToString());
                    ListViewItem item = new ListViewItem();
                    item.Text = DateTime.Parse(read["Ngaygio"].ToString()).ToString("dd/MM/yyyy h\\h mm");
                    item.Tag = hash;
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
                    //////////////////// thong tin dien bien benh////////////
                    textBox_Quatrinhbenhly.Text = read["Quatrinhbenhly"].ToString();
                    richTextBox_phuongphapdieutri.Text = read["Xuli"].ToString();
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
                    richTextBox_phuongphapdieutri.Text = read["Xuli"].ToString();
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
                ////////////////////////////////hoi chuan /////////////////////
                string ketluanhochuan = " + Dùng thuốc tạo máu : \r Liều: \t ui/tuần \n+Truyền đạm: \t lần/tuần\n+Truyền Fe:\t lần/tuần";
                richTextBox_ketluanhoichuan_hoichuan.Text = ketluanhochuan;
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
            if (idBenhnhan == -1)
            {
                return;
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
                    obj.Mabenhnhan = idBenhnhan;
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

        public void load_ChitietPhieuxetnghiem(int idPhieuxetnghiem)
        {
            if (idPhieuxetnghiem == -1)
            {
                return;
            }
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@idPhieuxetnghiem", MySqlDbType.Int32, 11).Value = idPhieuxetnghiem;
                com.CommandText = @"SELECT *
                                        FROM phieuxetnghiem
                                        WHERE id=@idPhieuxetnghiem";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    comboBox_bacsi_phieuxetnghiem.SelectedValue = read["Bacsi_id"].ToString();
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Load chi tiết phiếu xét nghiệm");
                return;
            }
        }

        public void load_Xetnghiem()
        {
            textBox_tenxetnghiem.Text = 
            textBox_ketquaxetnghiem.Text = "";
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
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Load xét nghiệm mặc định");
                return;
            }
        }

        public void load_Ketquaxetnghiem(int idPhieuxetnghiem)
        {
            listView_ketquaxetnghiem.Items.Clear();
            if (idPhieuxetnghiem == -1)
            {
                return;
            }
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@idPhieuxetnghiem", MySqlDbType.Int32, 11).Value = idPhieuxetnghiem;
                com.CommandText = @"SELECT *
                                        FROM xetnghiem_phieuxetnghiem
                                        LEFT OUTER JOIN xetnghiem
                                        	ON xetnghiem_phieuxetnghiem.Xetnghiem_id = xetnghiem.id
                                        WHERE Phieuxetnghiem_id=@idPhieuxetnghiem";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
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
                //Đồng bộ với list chọn xét nghiệm
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
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Load kết quả xét nghiem");
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
            load_Xetnghiem();
            load_listview_ngayxetnghiem_hoichuan();
            load_Toathuoc(idBenhnhan, idPhieukhambenh);
            load_Chaythan(idBenhnhan, idPhieukhambenh);
            //load_Phieuxetnhgiem_hoichuan(idBenhnhan, idPhieukhambenh);// load xet nghiem vao hoi chuan
            

        }

        private void textBox_search_benhnhan_TextChanged(object sender, EventArgs e)
        {
            Show_danhsachbenhnhan();
        }

//Phiếu xét nghiệm section---------------------------------------------------------------------------------------------------------------------------------------------------------------------
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
                com.Parameters.Add("@bacsi_id", MySqlDbType.Int32, 11).Value = int.Parse(comboBox_bacsi_phieuxetnghiem.SelectedValue.ToString());

                com.CommandText = @"INSERT INTO phieuxetnghiem(Ngayxetnghiem, Phieukhambenh_id, Bacsi_id) 
                                        VALUES (@ngayxetnghiem, @phieukhambenh_id, @bacsi_id)";
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
            load_ChitietPhieuxetnghiem(idPhieuxetnghiem);
            load_Xetnghiem();
            load_Ketquaxetnghiem(idPhieuxetnghiem);
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
                load_Ketquaxetnghiem(idPhieuxetnghiem);
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
                int idBacsi = int.Parse(comboBox_bacsi_phieuxetnghiem.SelectedValue.ToString());
                updateYlenh(1, idPhieuxetnghiem, idPhieukhambenh, idBacsi);
                load_Ylenh(idBenhnhan);
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }

        private void button_refresh_xetnghiem_status_Click(object sender, EventArgs e)
        {
            load_Xetnghiem();
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
            textBox_tenxetnghiem.Text =
            textBox_ketquaxetnghiem.Text = "";
            if (listView_ketquaxetnghiem.SelectedItems.Count < 1)
            {
                return;
            }
            Hashtable hash = (Hashtable)listView_ketquaxetnghiem.SelectedItems[0].Tag;
            textBox_tenxetnghiem.Text = listView_ketquaxetnghiem.SelectedItems[0].SubItems[0].Text;
            textBox_ketquaxetnghiem.Text = hash["thongsoxetnghiem"].ToString();
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

                com.CommandText = @"UPDATE xetnghiem_phieuxetnghiem SET Thongsoxetnghiem = CASE Xetnghiem_id" + valueString1 + " END WHERE Xetnghiem_id IN (" + valueString2 + ") AND Phieuxetnghiem_id=@phieuxetnghiem_id";

                if (MessageBox.Show("Bạn có muốn lưu kết quả xét nghiệm này?", "Xác nhận cập nhật kết quả xét nghiệm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Util.con.Open();
                    com.ExecuteNonQuery();
                    Util.con.Close();

                    load_Ketquaxetnghiem(idPhieuxetnghiem);
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
                    int idBacsi = int.Parse(comboBox_bacsi_phieuxetnghiem.SelectedValue.ToString());
                    updateYlenh(2, idPhieuxetnghiem, idPhieukhambenh, idBacsi);
                    load_Ylenh(idBenhnhan);
                    // load combobox ngay hoi chuan
                    load_Phieuxetnhgiem_hoichuan(idBenhnhan, idPhieukhambenh);
                }

            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("update kết quả xét nghiệm");
                return;
            }
        }

        private void listView_ketquaxetnghiem_DoubleClick(object sender, EventArgs e)
        {
            textBox_ketquaxetnghiem.Focus();
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
                string id="";
                if (read[0].ToString() != "")
                {
                    id = read[0].ToString();
                    Util.con.Close();
                }
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
                    ketqua += read["Tenxetnghiem"].ToString() + ":  " + read["Thongsoxetnghiem"].ToString()+ read["Donvi"].ToString() + "\n";
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
            Util.con.Close();
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
            int tinhtrangravien = 0;

            if (radioButton_khoi.Checked)
                tinhtrangravien = 1;
            else
                if (radioButton_dogiam.Checked)
                    tinhtrangravien = 2;
                else
                    if (radioButton_khongdoi.Checked)
                        tinhtrangravien = 3;
                    else
                        if (radioButton_nanghon.Checked)
                            tinhtrangravien = 4;
                        else
                            if (radioButton_tuvong.Checked)
                                tinhtrangravien = 5;

            MySqlCommand com = new MySqlCommand();
            com.Connection = Util.con;
            com.CommandText = @"UPDATE ngoaitru 
            SET Ngaygiovaovien ='" + dateTimePicker_Ngaykham.Value +
            "', Benhchinh ='" + textBox_Benhchinh.Text +
            "', Benhkemtheo = '" + textBox_Benhkemtheo.Text +
            "', Dieutritu = '" + dateTimePicker_Ngaykham.Value +
            "', Dieutriden = '" + DateTime.Today +
            "', Tinhtrangravien =" + tinhtrangravien.ToString() +
            ", Chuandoankhiravien = '" + textBox_Chuandoan.Text +
            "', Huongdieutri = '" + textBox_huongdieutri.Text +
            "', Bacsidieutri ='" + textBox_tenbsdieutri.Text +
            "',Soxquang =" + textBox_soxquang.Text +
            ", Soctscanner = " + textBox_soCtscanner.Text +
            ", Sosieuam = " + textBox_sosieuam.Text +
            ", Soxetnghiem = " + textBox_soxetnghiem.Text +
            ", Sokhac = " + textBox_sokhac.Text +
            "  WHERE ngoaitru.Phieukhambenh_id= " + idpkb;
            //MessageBox.Show(com.CommandText);
            Util.con.Open();
            com.ExecuteNonQuery();
            Util.con.Close();
            MessageBox.Show("update thanhcong va xuat vien thanh cong");
        }

        private void button_Intongketbenhan_Click(object sender, EventArgs e)
        {
            frmMain.frmReport = new ReportForm();
            frmMain.frmReport.frmMain = this.frmMain;
            frmMain.frmReport.MdiParent = this.frmMain;
            frmMain.frmReport.arrReport = new ArrayList();
            frmMain.frmReport.typeReport = "Tongketbenhanngoaitru";
            string ketqualamsang="";
            if(check_xetnghiem(idpkb))
            {
            int idxetnghiem1 = int.Parse(timkiem_idphieuxetnghiem_gannhat(idpkb.ToString()));
                    if (check_xetnghiemketqua(idxetnghiem1))
                    {
                        ketqualamsang = ketqua_xetnghiem_gannhat_chotongketbenh(timkiem_idphieuxetnghiem_gannhat(idpkb.ToString()));
                    }
            }   
                else ketqualamsang= " Chưa có kết quả lâm sàng";
            int soxetnghiem=int.Parse(solanxetnghiem(idpkb.ToString()));
            MySqlCommand com = new MySqlCommand();
            com.Connection = Util.con;
            com.CommandText = @"select * from ngoaitru, phieukhambenh
                                    where  ngoaitru.Phieukhambenh_id= phieukhambenh.id
                                    and ngoaitru.Phieukhambenh_id="+idpkb;
            Util.con.Open();
            MySqlDataReader read = com.ExecuteReader();
            
            while (read.Read())
            {
                Tongketbenhanngoaitru bant = new Tongketbenhanngoaitru();
                bant.Quatrinhbenh = read["Quatrinhbenhly"].ToString();
                bant.Ketqualamsang = ketqualamsang;
                bant.Benhchinh = read["Benhchinh"].ToString();
                bant.Benhkemtheo = read["Benhkemtheo"].ToString(); ;
                
                if (read["Tinhtrangravien"].ToString() == "1")
                    bant.Tinhtrangravien = "Khỏi";
                if (read["Tinhtrangravien"].ToString() == "2")
                    bant.Tinhtrangravien = "Đỡ,Giảm";
                if (read["Tinhtrangravien"].ToString() == "3")
                    bant.Tinhtrangravien = "Không Thay đổi";
                if (read["Tinhtrangravien"].ToString() == "4")
                    bant.Tinhtrangravien = "Nặng hơn";
                if (read["Tinhtrangravien"].ToString() == "5")
                    bant.Tinhtrangravien = "Tử vong";
                else bant.Tinhtrangravien = "BN Chưa ra viện";
                bant.Phuongphapdieutri = read["Xuli"].ToString();
                bant.Huongdieutri = read["Huongdieutri"].ToString();
                bant.SotoXquang = int.Parse(read["Soxquang"].ToString());
                bant.SotoCTscanner = int.Parse(read["Soctscanner"].ToString());
                bant.SotoSieuam = int.Parse(read["Sosieuam"].ToString());
                bant.SotoXetnghiem=soxetnghiem ;
                bant.Khac= int.Parse(read["Sokhac"].ToString());
                bant.Toanbohoso = bant.SotoXquang + bant.SotoCTscanner + bant.SotoSieuam + bant.SotoXetnghiem + bant.Khac;
                bant.Bsdieutri = read["Bacsidieutri"].ToString();
                frmMain.frmReport.arrReport.Add(bant);
            }
            Util.con.Close();
            frmMain.frmReport.Show();
        }

//Y lệnh section---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void updateYlenh(int loai, int idLoai, int idPhieukhambenh, int idBacsi)
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@idPhieukhambenh", MySqlDbType.Int32, 11).Value = idPhieukhambenh;
                com.Parameters.Add("@idBacsi", MySqlDbType.Int32, 11).Value = idBacsi;
                com.Parameters.Add("@loai", MySqlDbType.Int32, 11).Value = loai;
                com.Parameters.Add("@idLoai", MySqlDbType.Int32, 11).Value = idLoai;
                com.Parameters.Add("@mota", MySqlDbType.Text).Value = formatterYlenh(loai, idLoai);

                com.CommandText = @"SELECT ylenh.*
                                        FROM ylenh
                                        WHERE phieukhambenh_id=@idPhieukhambenh
                                            AND loai=@loai
                                            AND id_loai=@idLoai";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                bool hasYlenh = false;
                int idYlenh = -1;
                if (read.Read())
                {
                    hasYlenh = true;
                    idYlenh = int.Parse(read["id"].ToString());
                }
                Util.con.Close();
                if (hasYlenh)
                {
                    com.CommandText = @"UPDATE ylenh SET Mota=@mota, Bacsi_id=@idBacsi WHERE id=" + idYlenh.ToString();
                    Util.con.Open();
                    com.ExecuteNonQuery();
                    Util.con.Close();
                }
                else
                {
                    bool hasYlenhIncomplete = false;
                    com.CommandText = @"SELECT ylenh.*
                                        FROM ylenh
                                        WHERE phieukhambenh_id=@idPhieukhambenh
                                            AND status=1";
                    Util.con.Open();
                    read = com.ExecuteReader();
                    if (read.Read())
                    {
                        hasYlenhIncomplete = true;
                    }
                    Util.con.Close();
                    if (hasYlenhIncomplete)
                    {
                        if (MessageBox.Show("Bạn có muốn hủy y lệnh chưa hoàn thành trước đó và sử dụng y lệnh vừa tạo?", "Xác nhận xóa y lệnh chưa hoàn thành", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            com.CommandText = "DELETE FROM ylenh WHERE phieukhambenh_id=@idPhieukhambenh AND status=1";
                            Util.con.Open();
                            com.ExecuteNonQuery();
                            Util.con.Close();
                        }
                        else
                        {
                            return;
                        }
                    }
                    com.CommandText = @"INSERT INTO ylenh (loai, id_loai, Mota, Phieukhambenh_id, Bacsi_id) 
                                                VALUES (@loai, @idLoai, @mota, @idPhieukhambenh, @idBacsi)";
                    Util.con.Open();
                    com.ExecuteNonQuery();
                    Util.con.Close();
                }
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Update y lệnh");
                return;
            }
        }

        public string formatterYlenh(int loai, int idLoai)
        {
            string valueString = "";
            MySqlCommand com = new MySqlCommand();
            com.Connection = Util.con;
            com.Parameters.Add("@loai", MySqlDbType.Int32, 11).Value = loai;
            com.Parameters.Add("@idLoai", MySqlDbType.Int32, 11).Value = idLoai;
            MySqlDataReader read;
            switch (loai)
            {
                case 1:
                    valueString = "Xét nghiệm:\n";
                    com.CommandText = @"SELECT xetnghiem_phieuxetnghiem.*, xetnghiem.*
                                        FROM xetnghiem_phieuxetnghiem
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
                case 3:
                    string titleString = "", toathuocString = "";
                    valueString = "Cấp thuốc:\n";
                    com.CommandText = @"SELECT toathuoc_thuoc.*, thuoc.*, toathuoc.*
                                        FROM toathuoc_thuoc
                                        LEFT OUTER JOIN thuoc
                                            ON thuoc.id=toathuoc_thuoc.thuoc_id 
                                        LEFT OUTER JOIN toathuoc
                                            ON toathuoc.id=toathuoc_thuoc.toathuoc_id 
                                        WHERE toathuoc_thuoc.toathuoc_id=@idLoai";
                    Util.con.Open();
                    read = com.ExecuteReader();
                    while (read.Read())
                    {
                        double ngaythuoc = Math.Round((DateTime.Parse(read["denngay"].ToString()) - DateTime.Parse(read["Tungay"].ToString())).TotalDays + 1);
                        string sangStr = "\t\t", truaStr = "\t\t", toiStr = "\t\t";
                        if (read["sang"].ToString() != "" && read["sang"].ToString() != "0")
                        {
                            sangStr = "Sáng " + read["sang"].ToString() + " " + read["Dang"].ToString();
                        }
                        if (read["trua"].ToString() != "" && read["trua"].ToString() != "0")
                        {
                            truaStr = "Trưa " + read["trua"].ToString() + " " + read["Dang"].ToString();
                        }
                        if (read["toi"].ToString() != "" && read["toi"].ToString() != "0")
                        {
                            toiStr = "Tối " + read["toi"].ToString() + " " + read["Dang"].ToString();
                        }
                        double sang = FractionToDouble(read["sang"].ToString() != "" ? read["sang"].ToString() : "0"),
                                trua = FractionToDouble(read["trua"].ToString() != "" ? read["trua"].ToString() : "0"),
                                toi = FractionToDouble(read["toi"].ToString() != "" ? read["toi"].ToString() : "0");
                        double Tongcong = Math.Round(ngaythuoc * (sang + trua + toi));
                        string strTong = Tongcong < 10 ? ("0" + Tongcong.ToString()) : Tongcong.ToString();
                        titleString = "Thuốc đợt\t" + DateTime.Parse(read["Tungay"].ToString()).ToString("dd/MM/yyyy") + "\tđến\t" + DateTime.Parse(read["denngay"].ToString()).ToString("dd/MM/yyyy");
                        toathuocString += "\n" + read["Tenthuoc"].ToString() + " " + read["Hamluong"].ToString() + "\t\t\t\t\t\t    " + strTong + " " + read["Dang"].ToString();
                        toathuocString += "\n   " + read["Duongdung"].ToString() + "\t " + sangStr + "\t " + truaStr + "\t " + toiStr;
                    }
                    Util.con.Close();
                    valueString += titleString + toathuocString;
                    break;
                case 4:
                    valueString = "Chạy thận:\n";
                    com.CommandText = @"SELECT chaythan_thuoc.*, thuoc.*
                                        FROM chaythan_thuoc
                                        LEFT OUTER JOIN thuoc
                                            ON thuoc.id=chaythan_thuoc.thuoc_id
                                        WHERE chaythan_thuoc.chaythan_id=@idLoai";
                    Util.con.Open();
                    read = com.ExecuteReader();
                    while (read.Read())
                    {
                        valueString += read["Tenthuoc"].ToString() + " " + read["Hamluong"].ToString() + " " + read["Soluong"].ToString() + " " + read["Dang"].ToString() + " " + read["Duongdung"].ToString() + "\n";
                    }
                    Util.con.Close();
                    break;
                default:
                    break;
            }
            return valueString;
        }

//Toa thuốc section---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void load_Toathuoc(int idBenhnhan, int idPhieukhambenh)
        {
            comboBox_toathuoc.DataSource = null;
            comboBox_toathuoc.Text = "";
            comboBox_toathuoc.SelectedIndex = -1;
            comboBox_toathuoc.DisplayMember = "Text";
            comboBox_toathuoc.ValueMember = "Value";
            List<object> myCollection = new List<object>();
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@idBenhnhan", MySqlDbType.Int32, 11).Value = idBenhnhan;
                com.Parameters.Add("@idPhieukhambenh", MySqlDbType.Int32, 11).Value = idPhieukhambenh;
                com.CommandText = @"SELECT toathuoc.*
                                        FROM toathuoc
                                        LEFT OUTER JOIN phieukhambenh
                                            ON toathuoc.Phieukhambenh_id=phieukhambenh.id 
                                        LEFT OUTER JOIN ngoaitru
                                            ON ngoaitru.Phieukhambenh_id=phieukhambenh.id 
                                        LEFT OUTER JOIN benhnhan
                                            ON benhnhan.id=phieukhambenh.Benhnhan_id
                                        WHERE benhnhan.id=@idBenhnhan
                                            AND phieukhambenh.id=@idPhieukhambenh
                                        ORDER BY toathuoc.id DESC";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    myCollection.Add(new { Text = DateTime.Parse(read["Tungay"].ToString()).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(read["Denngay"].ToString()).ToString("dd/MM/yyyy"), Value = read["id"].ToString() });
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Load toa thuốc");
                return;
            }
            comboBox_toathuoc.DataSource = (object)myCollection;
            if (comboBox_toathuoc.Items.Count > 0)
            {
                comboBox_toathuoc.SelectedIndex = 0;
            }
        }

        public void load_ChitietToathuoc(int idToathuoc)
        {
            dateTimePicker_thuoctungay.Value = dateTimePicker_thuocdenngay.Value = DateTime.Now;
            richTextBox_loidan.Text = "";
            if (idToathuoc == -1)
            {
                return;
            }
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;

                com.Parameters.Add("@idToathuoc", MySqlDbType.Int32, 11).Value = idToathuoc;
                com.CommandText = @"SELECT *
                                        FROM toathuoc
                                        WHERE id=@idToathuoc";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    dateTimePicker_thuoctungay.Value = DateTime.Parse(read["Tungay"].ToString());
                    dateTimePicker_thuocdenngay.Value = DateTime.Parse(read["Denngay"].ToString());
                    richTextBox_loidan.Text = read["Loidan"].ToString();
                    comboBox_bacsi_toathuoc.SelectedValue = read["Bacsi_id"].ToString();
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Load chi tiết toa thuốc");
                return;
            }
        }

        public void load_ChitietToathuoc_Thuoc(int idToathuoc)
        {
            listView_chitiettoathuoc.Items.Clear();
            if (idToathuoc == -1)
            {
                return;
            }
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@idToathuoc", MySqlDbType.Int32, 11).Value = idToathuoc;
                com.CommandText = @"SELECT *
                                        FROM toathuoc_thuoc
                                        LEFT OUTER JOIN thuoc
                                            ON toathuoc_thuoc.thuoc_id=thuoc.id
                                        WHERE toathuoc_thuoc.toathuoc_id=@idToathuoc";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                int i = 1;
                while (read.Read())
                {
                    Hashtable hash = new Hashtable();
                    hash.Add("toathuoc_id", read["Toathuoc_id"].ToString());
                    hash.Add("thuoc_id", read["Thuoc_id"].ToString());
                    hash.Add("sang", read["sang"].ToString());
                    hash.Add("trua", read["trua"].ToString());
                    hash.Add("toi", read["toi"].ToString());
                    hash.Add("ghichu", read["ghichu"].ToString());
                    ListViewItem item = new ListViewItem();
                    item.Text = i.ToString();
                    item.Tag = hash;
                    item.SubItems.Add(read["Tenthuoc"].ToString() + " " + read["Hamluong"].ToString());
                    item.SubItems.Add(read["ghichu"].ToString());
                    item.SubItems.Add(read["Duongdung"].ToString());
                    item.SubItems.Add(read["sang"].ToString());
                    item.SubItems.Add(read["trua"].ToString());
                    item.SubItems.Add(read["toi"].ToString());
                    item.SubItems.Add(read["Dang"].ToString());
                    listView_chitiettoathuoc.Items.Add(item);
                    i++;
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Load chi tiết toa thuốc và thuốc");
                return;
            }
        }

        public double soNgaythuoc()
        {
            double ngaythuoc = (dateTimePicker_thuocdenngay.Value - dateTimePicker_thuoctungay.Value).TotalDays + 1;
            return Math.Round(ngaythuoc);          
        }

        private void comboBox_toathuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idToathuoc = -1;
            try
            {
                idToathuoc = int.Parse(comboBox_toathuoc.SelectedValue.ToString());
            }
            catch (Exception)
            {

            }
            load_ChitietToathuoc(idToathuoc);
            load_ChitietToathuoc_Thuoc(idToathuoc);
        }

        private void dateTimePicker_thuoctungay_ValueChanged(object sender, EventArgs e)
        {
            double ngaythuoc = soNgaythuoc();
            if (ngaythuoc > 0)
            {
                textBox_songaythuoc.Text = ngaythuoc.ToString();
            }
            else
            {
                dateTimePicker_thuoctungay.Value = dateTimePicker_thuocdenngay.Value;
            }
        }

        private void dateTimePicker_thuocdenngay_ValueChanged(object sender, EventArgs e)
        {
            double ngaythuoc = soNgaythuoc();
            if (ngaythuoc > 0)
            {
                textBox_songaythuoc.Text = ngaythuoc.ToString();
            }
            else
            {
                dateTimePicker_thuocdenngay.Value = dateTimePicker_thuoctungay.Value;
            }
        }

        private void textBox_searchthuoc_TextChanged(object sender, EventArgs e)
        {
            listView_thuoc.Items.Clear();
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.AddWithValue("@tenthuoc", "%" + textBox_searchthuoc.Text + "%");
                com.CommandText = @"SELECT *
                                        FROM thuoc
                                        WHERE tenthuoc LIKE @tenthuoc";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                int i = 1;
                while (read.Read())
                {
                    Hashtable hash = new Hashtable();
                    hash.Add("thuoc_id", read["id"].ToString());
                    ListViewItem item = new ListViewItem();
                    item.Text = i.ToString();
                    item.Tag = hash;
                    item.SubItems.Add(read["Tenthuoc"].ToString() + " " + read["Hamluong"].ToString());
                    item.SubItems.Add(read["Duongdung"].ToString());
                    item.SubItems.Add(read["Dang"].ToString());
                    listView_thuoc.Items.Add(item);
                    i++;
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Tìm thuốc theo tên thuốc");
                return;
            }
        }

        private void button_addtoToathuoc_Click(object sender, EventArgs e)
        {
            int idToathuoc = -1;
            try
            {
                idToathuoc = int.Parse(comboBox_toathuoc.SelectedValue.ToString());
            }
            catch (Exception)
            {

            }
            if (idToathuoc == -1 || listView_thuoc.SelectedItems.Count < 1)
            {
                return;
            }
            Hashtable hash = (Hashtable)listView_thuoc.SelectedItems[0].Tag;
            int idThuoc = int.Parse(hash["thuoc_id"].ToString());
            if (cotrongToathuoc(idThuoc.ToString()))
            {
                return;
            }
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@idToathuoc", MySqlDbType.Int32, 11).Value = idToathuoc;
                com.Parameters.Add("@idThuoc", MySqlDbType.Int32, 11).Value = idThuoc;
                com.CommandText = @"INSERT INTO `toathuoc_thuoc` (`Toathuoc_id`, `Thuoc_id`) VALUES (@idToathuoc, @idThuoc)";
                Util.con.Open();
                com.ExecuteNonQuery();
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Thêm thuốc vào toa thuốc");
                return;
            }
            load_ChitietToathuoc_Thuoc(idToathuoc);
        }

        public bool cotrongToathuoc(string id)
        {
            int listView_chitiettoathuoc_length = listView_chitiettoathuoc.Items.Count;
            for (int i = 0; i < listView_chitiettoathuoc_length; i++)
            {
                Hashtable hash = (Hashtable)listView_chitiettoathuoc.Items[i].Tag;
                if (hash["thuoc_id"].ToString() == id)
                {
                    return true;
                }
            }
            return false;
        }

        private void listView_chitiettoathuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_tenthuoc.Text =
            textBox_ghichuthuoc.Text =
            textBox_lieusang.Text =
            textBox_lieutrua.Text =
            textBox_lieutoi.Text = "";
            if (listView_chitiettoathuoc.SelectedItems.Count < 1)
            {
                return;
            }
            Hashtable hash = (Hashtable)listView_chitiettoathuoc.SelectedItems[0].Tag;
            textBox_tenthuoc.Text = listView_chitiettoathuoc.SelectedItems[0].SubItems[1].Text;
            textBox_ghichuthuoc.Text = hash["ghichu"].ToString();
            textBox_lieusang.Text = hash["sang"].ToString();
            textBox_lieutrua.Text = hash["trua"].ToString();
            textBox_lieutoi.Text = hash["toi"].ToString();
        }

        private void button_capnhat_chitietthuoc_Click(object sender, EventArgs e)
        {
            int items_count = listView_chitiettoathuoc.Items.Count;
            if (listView_chitiettoathuoc.SelectedItems.Count < 1)
            {
                return;
            }
            Hashtable hash = (Hashtable)listView_chitiettoathuoc.SelectedItems[0].Tag;
            hash["ghichu"] = textBox_ghichuthuoc.Text;
            hash["sang"] = textBox_lieusang.Text;
            hash["trua"] = textBox_lieutrua.Text;
            hash["toi"] = textBox_lieutoi.Text;
            listView_chitiettoathuoc.SelectedItems[0].SubItems[2].Text = hash["ghichu"].ToString();
            listView_chitiettoathuoc.SelectedItems[0].SubItems[4].Text = hash["sang"].ToString();
            listView_chitiettoathuoc.SelectedItems[0].SubItems[5].Text = hash["trua"].ToString();
            listView_chitiettoathuoc.SelectedItems[0].SubItems[6].Text = hash["toi"].ToString();
            listView_chitiettoathuoc.SelectedItems[0].Tag = hash;
            int index = listView_chitiettoathuoc.SelectedIndices[0];
            if (index + 1 < items_count)
            {
                listView_chitiettoathuoc.Items[index + 1].Selected = true;
                listView_chitiettoathuoc.Items[index + 1].EnsureVisible();
            }
            textBox_ghichuthuoc.Focus();
        }

        private void listView_chitiettoathuoc_DoubleClick(object sender, EventArgs e)
        {
            textBox_ghichuthuoc.Focus();
        }

        private void button_save_toathuoc_Click(object sender, EventArgs e)
        {
            int idToathuoc = -1;
            try
            {
                idToathuoc = int.Parse(comboBox_toathuoc.SelectedValue.ToString());
            }
            catch (Exception)
            {

            }
            if (idToathuoc == -1)
            {
                return;
            }
            int listView_chitiettoathuoc_length = listView_chitiettoathuoc.Items.Count;
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;

                string valueString1 = "", valueString2 = "", valueString3 = "", valueString4 = "", valueString5 = "";
                for (int i = 0; i < listView_chitiettoathuoc_length; i++)
                {
                    Hashtable hash = (Hashtable)listView_chitiettoathuoc.Items[i].Tag;
                    com.Parameters.Add("@thuoc_id" + i.ToString(), MySqlDbType.Int32, 11).Value = int.Parse(hash["thuoc_id"].ToString());
                    com.Parameters.Add("@ghichu" + i.ToString(), MySqlDbType.Text).Value = hash["ghichu"].ToString();
                    com.Parameters.Add("@sang" + i.ToString(), MySqlDbType.VarChar, 45).Value = hash["sang"].ToString();
                    com.Parameters.Add("@trua" + i.ToString(), MySqlDbType.VarChar, 45).Value = hash["trua"].ToString();
                    com.Parameters.Add("@toi" + i.ToString(), MySqlDbType.VarChar, 45).Value = hash["toi"].ToString();
                    valueString2 += " WHEN @thuoc_id" + i.ToString() + " THEN @ghichu" + i.ToString();
                    valueString3 += " WHEN @thuoc_id" + i.ToString() + " THEN @sang" + i.ToString();
                    valueString4 += " WHEN @thuoc_id" + i.ToString() + " THEN @trua" + i.ToString();
                    valueString5 += " WHEN @thuoc_id" + i.ToString() + " THEN @toi" + i.ToString();
                    if (i == 0)
                    {
                        valueString1 += "@thuoc_id" + i.ToString();
                    }
                    else
                    {
                        valueString1 += ", @thuoc_id" + i.ToString();
                    }
                }

                com.Parameters.Add("@toathuoc_id", MySqlDbType.Int32, 11).Value = idToathuoc;

                com.CommandText = @"UPDATE toathuoc_thuoc SET ghichu = CASE thuoc_id" + valueString2 + " END, sang = CASE thuoc_id" + valueString3 + " END, trua = CASE thuoc_id" + valueString4 + " END, toi = CASE thuoc_id" + valueString5 + " END WHERE Thuoc_id IN (" + valueString1 + ") AND Toathuoc_id=@toathuoc_id";

                if (MessageBox.Show("Bạn có muốn lưu toa thuốc này?", "Xác nhận cập nhật toa thuốc", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Util.con.Open();
                    com.ExecuteNonQuery();
                    Util.con.Close();

                    load_ChitietToathuoc(idToathuoc);
                    load_ChitietToathuoc_Thuoc(idToathuoc);
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
                    int idBacsi = int.Parse(comboBox_bacsi_toathuoc.SelectedValue.ToString());
                    updateYlenh(3, idToathuoc, idPhieukhambenh, idBacsi);
                    load_Ylenh(idBenhnhan);
                }

            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("update chi tiết toa thuốc");
                return;
            }
        }
/// <summary>
/// //////////////////////////////////hoi chuan///////////////////////
/// </summary>
/// <param name="idphieuxetnghiem"></param>
/// <returns></returns>\
        public void load_hoichuan(int idphieuxetnghiem)
        {
            MySqlCommand com = new MySqlCommand();
            com.Connection = Util.con;
            com.Parameters.Add("@idpheiuxetnghiem", MySqlDbType.Int32, 11).Value = idphieuxetnghiem;
            com.CommandText = "SELECT * FROM hoichuan,phieuxetnghiem,bacsi_hoichuan, bacsi WHERE bacsi.id = bacsi_hoichuan.Bacsi_id AND bacsi_hoichuan.Hoichuan_id = hoichuan.id AND hoichuan.phieuxetnghiem_id = phieuxetnghiem.id AND phieuxetnghiem_id=" + idphieuxetnghiem.ToString();
            Util.con.Open();
           MySqlDataReader read = com.ExecuteReader();
           if (read.Read())
           {
               while (read.Read())
               {
                   richTextBox_chuandoan_hoichuan.Text = read["Chuandoan"].ToString();
                   comboBox_thieumaumucdo_hoichuan.Text = read["Mucdothieumau"].ToString();
                   richTextBox_ketluanhoichuan_hoichuan.Text = read["Ketluanhoichuan"].ToString();
                   DateTime thoigianhoichuan = DateTime.Parse(read["Thoigianhoichuan"].ToString());
                   dateTimePicker_ngayhoichuan_hoichuan.Value = thoigianhoichuan;
                   dateTimePicker_giohoichuan_hoichuan.Value = thoigianhoichuan;
                   textBox_idbacsihoichuan.Text = read[11].ToString(); 
                   textBox_bacsihoichuan_hoichuan.Text = read["Tenbacsi"].ToString();

               }
           }
           else
               richTextBox_chuandoan_hoichuan.Text = textBox_Chuandoan.Text;
            Util.con.Close();
            ketqua_xetnghiem_gannhat_chohoichuan(idphieuxetnghiem);
            
        }
        public void load_listview_ngayxetnghiem_hoichuan()
        {
            MySqlCommand com = new MySqlCommand();
            com.Connection = Util.con;
            com.Parameters.Add("@idphieukhambenh", MySqlDbType.Int32, 11).Value = idpkb;
            com.CommandText=@"SELECT phieuxetnghiem.id,phieuxetnghiem.ngayxetnghiem, hoichuan.Thoigianhoichuan
                                FROM phieuxetnghiem
                                LEFT JOIN hoichuan ON phieuxetnghiem.id = hoichuan.phieuxetnghiem_id
                                JOIN phieukhambenh ON phieukhambenh.id = phieuxetnghiem.phieukhambenh_id
                                WHERE phieukhambenh.id = @idphieukhambenh  
                                ORDER BY phieuxetnghiem.ngayxetnghiem DESC" ;
            Util.con.Open();
            MySqlDataReader read = com.ExecuteReader();
            listView_hoichuan.Items.Clear();
          
                while (read.Read())
                {
                    int i= listView_hoichuan.Items.Count;
                    listView_hoichuan.Items.Add(read["ngayxetnghiem"].ToString());
                    if (read["Thoigianhoichuan"].ToString() == "")
                    {
                        listView_hoichuan.Items[i].SubItems.Add("chưa hội chuẩn");
                    }
                    else
                    listView_hoichuan.Items[i].SubItems.Add(read["Thoigianhoichuan"].ToString());
                    listView_hoichuan.Items[i].SubItems.Add(read["id"].ToString());

                }
           
            Util.con.Close();

        }

        /////////////// load combobox ngay xet nghiem//////
        public void load_Phieuxetnhgiem_hoichuan(int idBenhnhan, int idPhieukhambenh)
        {

            comboBox_ngayxetnghiem_hoichuan.DataSource = null;
            comboBox_ngayxetnghiem_hoichuan.Text = "";
            comboBox_ngayxetnghiem_hoichuan.SelectedIndex = -1;
            comboBox_ngayxetnghiem_hoichuan.DisplayMember = "Text";
            comboBox_ngayxetnghiem_hoichuan.ValueMember = "Value";
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
                    myCollection.Add(new { Text = DateTime.Parse(read["Ngayxetnghiem"].ToString()).ToString("dd/MM/yyyy"), Value = read["id"].ToString() });
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Load  combobox ngay xet nghiem");
                return;
            }
            comboBox_ngayxetnghiem_hoichuan.DataSource = (object)myCollection;
            if (comboBox_ngayxetnghiem_hoichuan.Items.Count > 0)
            {
                comboBox_ngayxetnghiem_hoichuan.SelectedIndex = 0;
            }
        }
        public void ketqua_xetnghiem_gannhat_chohoichuan(int idphieuxetnghiem)
        {
            //try
            //{
            string ketqua = "";
            MySqlCommand com = new MySqlCommand();
            com.Connection = Util.con;
            com.CommandText = @"SELECT xetnghiem_phieuxetnghiem.*, xetnghiem.TenXetnghiem ,xetnghiem.Donvi
                                    FROM xetnghiem_phieuxetnghiem,xetnghiem
                                    WHERE (
                                    xetnghiem.Tenxetnghiem='Hb'
                                    OR xetnghiem.Tenxetnghiem='Hct'
                                    OR xetnghiem.Tenxetnghiem='Albumin'
                                    OR xetnghiem.Tenxetnghiem='Fe'
                                    )
                                    AND xetnghiem_phieuxetnghiem.Phieuxetnghiem_id = " + idphieuxetnghiem +
                                @" AND xetnghiem_phieuxetnghiem.Xetnghiem_id= xetnghiem.id
                                    ORDER BY xetnghiem.id DESC ";
            
            Util.con.Open();
            MySqlDataReader read = com.ExecuteReader();
            // Xetnghiem xn = new Xetnghiem();
            while (read.Read())
            {
                ketqua += read["Tenxetnghiem"].ToString() + ":  " + read["Thongsoxetnghiem"].ToString()+" "+ read["Donvi"].ToString() + "\n";
            }
            Util.con.Close();
            richTextBox_ketquaxetnghiem_hoichuan.Text = ketqua;
            //}
            //catch (MySqlException sqlE)
            //{
            //    Util.con.Close();
            //    MessageBox.Show(sqlE.Source.ToString());
            //    return null;
            //}
        }


        

        public bool kiemtrahoichuan_phieuxetnghiem(string idphieuxetnghiem)
        {
            MySqlCommand com = new MySqlCommand();
            com.Connection = Util.con;
            com.Parameters.Add("@idphieuxetnghiem", MySqlDbType.Int32, 11).Value = idpxn;
            com.CommandText = " select phieuxetnghiem_id from hoichuan where phieuxetnghiem_id=@idphieuxetnghiem";

            Util.con.Open();
            MySqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                if (read[0].ToString() == idphieuxetnghiem)
                {
                    Util.con.Close();
                    return true;
                }
                Util.con.Close();
                return false;
            }
            Util.con.Close();
            return false;
        }

        private void button_luu_hoichuan_Click(object sender, EventArgs e)
        {/// sua lai nutluu vi dung id bac si ko dung ten bas si
         /// 
            int idhoichuan=0;
            if (control == 0)
            {
                if (!kiemtrahoichuan_phieuxetnghiem(idpxn.ToString()))
                {
                    
                    MySqlCommand com = new MySqlCommand();
                    com.Connection = Util.con;
                    DateTime thoigianhoichuan = new DateTime(dateTimePicker_ngayhoichuan_hoichuan.Value.Year, dateTimePicker_ngayhoichuan_hoichuan.Value.Month, dateTimePicker_ngayhoichuan_hoichuan.Value.Day, dateTimePicker_giohoichuan_hoichuan.Value.Hour, dateTimePicker_giohoichuan_hoichuan.Value.Minute, dateTimePicker_giohoichuan_hoichuan.Value.Second);
                    com.Parameters.Add("@thoigianhoichuan", MySqlDbType.DateTime, 55).Value = thoigianhoichuan;
                    com.Parameters.Add("@ketluanhoichuan", MySqlDbType.VarChar, 200).Value = richTextBox_ketluanhoichuan_hoichuan.Text;
                    com.Parameters.Add("@idphieuxetnghiem", MySqlDbType.Int32, 11).Value = idpxn;
                    com.Parameters.Add("@idbacsihoichuan", MySqlDbType.Int32 , 45).Value = int.Parse(textBox_idbacsihoichuan.Text);
                    com.Parameters.Add("@mucdo", MySqlDbType.VarChar, 45).Value = comboBox_thieumaumucdo_hoichuan.Text;
                    com.Parameters.Add("@chuandoan", MySqlDbType.VarChar, 45).Value = richTextBox_chuandoan_hoichuan.Text;
                    com.CommandText = " insert into hoichuan value(null,@thoigianhoichuan,@ketluanhoichuan,@idphieuxetnghiem,@mucdo,@chuandoan)";
                    Util.con.Open();
                    com.ExecuteNonQuery();
                    //MessageBox.Show("hoichuan thanh cong");
                    //tim idhoichuancom.Parameters.Add("@mucdo", MySqlDbType.VarChar, 45).Value = comboBox_thieumaumucdo_hoichuan.Text;
                    com.CommandText = "select id from hoichuan where Phieuxetnghiem_id=@idphieuxetnghiem";

                    MySqlDataReader read = com.ExecuteReader();
                  
                        while (read.Read())
                        {
                            idhoichuan = int.Parse(read["id"].ToString());
                        }
                   
                    //MessageBox.Show(idhoichuan.ToString());
                    //insert bacsi_hoichuan
                    read.Close();
                    com.Parameters.Add("@idhoichuan", MySqlDbType.Int32, 11).Value = idhoichuan;
                    com.CommandText = "insert into bacsi_hoichuan values(@idhoichuan,@idbacsihoichuan,@thoigianhoichuan)";
                    com.ExecuteNonQuery();
                    Util.con.Close();
                 
                    //MessageBox.Show("hoichuan_bacsi thanh cong");
                    load_listview_ngayxetnghiem_hoichuan();
                }
                else
                    MessageBox.Show("biên bản hội chuẩn cho phiếu xét nghiệm ngày: " + comboBox_ngayxetnghiem_hoichuan.Text + " tồn tại");
            }
            else
                if (control == 1)
                {
                    //if (!kiemtrahoichuan_phieuxetnghiem(idpxn.ToString()))
                    //{
                        MySqlCommand com = new MySqlCommand();
                        com.Connection = Util.con;
                        DateTime thoigianhoichuan = new DateTime(dateTimePicker_ngayhoichuan_hoichuan.Value.Year, dateTimePicker_ngayhoichuan_hoichuan.Value.Month, dateTimePicker_ngayhoichuan_hoichuan.Value.Day, dateTimePicker_giohoichuan_hoichuan.Value.Hour, dateTimePicker_giohoichuan_hoichuan.Value.Minute, dateTimePicker_giohoichuan_hoichuan.Value.Second);
                        com.Parameters.Add("@thoigianhoichuan", MySqlDbType.DateTime, 55).Value = thoigianhoichuan;
                        com.Parameters.Add("@ketluanhoichuan", MySqlDbType.VarChar, 200).Value = richTextBox_ketluanhoichuan_hoichuan.Text;
                        com.Parameters.Add("@idphieuxetnghiem", MySqlDbType.Int32, 11).Value = idpxn;
                        com.Parameters.Add("@chuandoan", MySqlDbType.VarChar, 45).Value = richTextBox_chuandoan_hoichuan.Text;
                        com.Parameters.Add("@mucdo", MySqlDbType.VarChar, 45).Value = comboBox_thieumaumucdo_hoichuan.Text;
                        com.Parameters.Add("@idbacsi", MySqlDbType.VarChar, 45).Value = textBox_idbacsihoichuan.Text;
                        com.CommandText = " UPDATE  hoichuan SET Thoigianhoichuan=@thoigianhoichuan, Ketluanhoichuan=@ketluanhoichuan,Mucdothieumau=@mucdo, Chuandoan=@chuandoan WHERE Phieuxetnghiem_id="+idpxn;
                        Util.con.Open();
                        com.ExecuteNonQuery();
                        com.CommandText = "select id from hoichuan where Phieuxetnghiem_id=@idphieuxetnghiem";

                        MySqlDataReader read = com.ExecuteReader();

                        while (read.Read())
                        {
                            idhoichuan = int.Parse(read["id"].ToString());
                        }
                        read.Close();
                        com.CommandText = " UPDATE  bacsi_hoichuan SET Bacsi_id=@idbacsi WHERE Hoichuan_id= " + idhoichuan;
                        com.ExecuteNonQuery();
                        Util.con.Close();
                        MessageBox.Show("Hội chuẩn cập nhật thành công");
                        control = 0;
                    //}
                }
        }

        private void comboBox_ngayxetnghiem_hoichuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPhieuxetnghiem = -1;
            try
            {
                idPhieuxetnghiem = int.Parse(comboBox_ngayxetnghiem_hoichuan.SelectedValue.ToString());
                idpxn = int.Parse(comboBox_ngayxetnghiem_hoichuan.SelectedValue.ToString());
                
              
            }
            catch (Exception)
            {

            }
            ketqua_xetnghiem_gannhat_chohoichuan(idPhieuxetnghiem);
            load_hoichuan(idPhieuxetnghiem); 

        }

        private void button_inbienban_hoichuan_Click(object sender, EventArgs e)
        {
            frmMain.frmReport = new ReportForm();
            frmMain.frmReport.frmMain = this.frmMain;
            frmMain.frmReport.MdiParent = this.frmMain;
            frmMain.frmReport.arrReport = new ArrayList();
            frmMain.frmReport.typeReport = "Bienbanhoichuan";

            Bienbanhoichuan bant = new Bienbanhoichuan();
            bant.Mabenhnhan = idbn.ToString();
            bant.Tenbenhnhan = textBox_Ten.Text;
            bant.Ngaysinh = dateTimePicker_Namsinh.Value;
            bant.Chuandoan = textBox_Chuandoan.Text;
            DateTime thoigianhoichuan = new DateTime(dateTimePicker_ngayhoichuan_hoichuan.Value.Year, dateTimePicker_ngayhoichuan_hoichuan.Value.Month, dateTimePicker_ngayhoichuan_hoichuan.Value.Day, dateTimePicker_giohoichuan_hoichuan.Value.Hour, dateTimePicker_giohoichuan_hoichuan.Value.Minute, dateTimePicker_giohoichuan_hoichuan.Value.Second);
            bant.Ngayhoichuan = thoigianhoichuan;
            bant.Mucdothieumau = comboBox_thieumaumucdo_hoichuan.Text;
            bant.Ketquaxetnghiem = richTextBox_ketquaxetnghiem_hoichuan.Text;
            bant.Ketluanhoichuan = richTextBox_ketluanhoichuan_hoichuan.Text;
            bant.Bacsihoichuan = textBox_bacsihoichuan_hoichuan.Text;
            frmMain.frmReport.arrReport.Add(bant);
            frmMain.frmReport.Show();
        }

        private void button_sua_hoichuan_Click(object sender, EventArgs e)
        {
            control = 1;
        }

        private void textBox_idbacsihoichuan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.CommandText = "SELECT * FROM bacsi WHERE id = " + textBox_idbacsihoichuan.Text;
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        textBox_bacsihoichuan_hoichuan.Text = read["TenBacsi"].ToString();
                        
                    }
                Util.con.Close();
 
            }
        }
        private void listView_hoichuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox_chuandoan_hoichuan.Text = "";
            comboBox_thieumaumucdo_hoichuan.Text = "";
            richTextBox_ketquaxetnghiem_hoichuan.Text = "";
            richTextBox_ketluanhoichuan_hoichuan.Text = "";
            int idhoichuan=0;

            if (listView_hoichuan.SelectedItems.Count < 1)
            {
                return;
            }
            string tinhtranghoichuan = listView_hoichuan.SelectedItems[0].SubItems[1].Text;
            string idPhieuxetnghiem = listView_hoichuan.SelectedItems[0].SubItems[2].Text;
            idpxn = int.Parse(listView_hoichuan.SelectedItems[0].SubItems[2].Text);
            if (tinhtranghoichuan != "chưa hội chuẩn")
            {
                
                //MessageBox.Show(idphieuxetnghiem);control 0 insert, 1 update
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@idphieuxetnghiem", MySqlDbType.VarChar,11).Value = idPhieuxetnghiem;
                com.CommandText = "select * from hoichuan where Phieuxetnghiem_id=@idphieuxetnghiem";
                //MessageBox.Show(com.CommandText);
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    richTextBox_chuandoan_hoichuan.Text = read["Chuandoan"].ToString();
                    comboBox_thieumaumucdo_hoichuan.Text = read["Mucdothieumau"].ToString();
                    richTextBox_ketluanhoichuan_hoichuan.Text = read["Ketluanhoichuan"].ToString();
                    DateTime ngayhc = DateTime.Parse(read["Thoigianhoichuan"].ToString());
                    dateTimePicker_ngayhoichuan_hoichuan.Value = ngayhc;
                    dateTimePicker_giohoichuan_hoichuan.Value = ngayhc;
                    idhoichuan = int.Parse(read["id"].ToString());

                }
                
               // MySqlCommand com1 = new MySqlCommand();
                read.Close();
                com.Parameters.Add("@hoichuanid", MySqlDbType.Int32, 11).Value = idhoichuan;
                com.CommandText = "select Bacsi.* from Bacsi,Bacsi_hoichuan where Hoichuan_id=@hoichuanid";
                //Util.con.Open();
                read = com.ExecuteReader();
                while (read.Read())
                {
                    textBox_bacsihoichuan_hoichuan.Text = read["Tenbacsi"].ToString();
                    textBox_idbacsihoichuan.Text = read["id"].ToString();
                }
                Util.con.Close();
            }
           
                
                if (tinhtranghoichuan == "chưa hội chuẩn")
                {
                    richTextBox_chuandoan_hoichuan.Text = textBox_Chuandoan.Text;
                    string ketluanhochuan = " + Dùng thuốc tạo máu : \r Liều: \t ui/tuần \n+Truyền đạm: \t lần/tuần\n+Truyền Fe:\t lần/tuần";
                    richTextBox_ketluanhoichuan_hoichuan.Text = ketluanhochuan;
                    dateTimePicker_ngayhoichuan_hoichuan.Value = DateTime.Today;
                    dateTimePicker_giohoichuan_hoichuan.Value = DateTime.Now;
                    textBox_idbacsihoichuan.Text = "";
                    textBox_bacsihoichuan_hoichuan.Text = "";

                }
                
                ketqua_xetnghiem_gannhat_chohoichuan(int.Parse(idPhieuxetnghiem));


  
        }

      


///////////////////////////////////////////////////////////////////////////////////////////////////////////
 
        public void load_Bacsi() {
            comboBox_bacsi_toathuoc.DataSource = comboBox_bacsi_phieuxetnghiem.DataSource = comboBox_bacsi_chaythan.DataSource = null;
            comboBox_bacsi_toathuoc.Text = comboBox_bacsi_phieuxetnghiem.Text = comboBox_bacsi_chaythan.Text = "";
            comboBox_bacsi_toathuoc.SelectedIndex = comboBox_bacsi_phieuxetnghiem.SelectedIndex = comboBox_bacsi_chaythan.SelectedIndex = -1;
            comboBox_bacsi_toathuoc.DisplayMember = comboBox_bacsi_phieuxetnghiem.DisplayMember = comboBox_bacsi_chaythan.DisplayMember = "Text";
            comboBox_bacsi_toathuoc.ValueMember = comboBox_bacsi_phieuxetnghiem.ValueMember = comboBox_bacsi_chaythan.ValueMember = "Value";
            List<object> myCollection = new List<object>();
            List<object> myCollection1 = new List<object>();
            List<object> myCollection2 = new List<object>();
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.CommandText = @"SELECT *
                                        FROM bacsi
                                        ORDER BY TenBacsi ASC";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    myCollection.Add(new { Text = read["TenBacsi"].ToString(), Value = read["id"].ToString() });
                    myCollection1.Add(new { Text = read["TenBacsi"].ToString(), Value = read["id"].ToString() });
                    myCollection2.Add(new { Text = read["TenBacsi"].ToString(), Value = read["id"].ToString() });
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Load bác sĩ");
                return;
            }
            comboBox_bacsi_toathuoc.DataSource = (object)myCollection;
            comboBox_bacsi_phieuxetnghiem.DataSource = (object)myCollection1;
            comboBox_bacsi_chaythan.DataSource = (object)myCollection2;
            if (comboBox_bacsi_toathuoc.Items.Count > 0)
            {
                comboBox_bacsi_toathuoc.SelectedIndex = 0;
            }
            if (comboBox_bacsi_phieuxetnghiem.Items.Count > 0)
            {
                comboBox_bacsi_phieuxetnghiem.SelectedIndex = 0;
            }
            if (comboBox_bacsi_chaythan.Items.Count > 0)
            {
                comboBox_bacsi_chaythan.SelectedIndex = 0;
            }
        }

        private void button_addnew_toathuoc_Click(object sender, EventArgs e)
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

                com.Parameters.Add("@tungay", MySqlDbType.DateTime).Value = dateTimePicker_thuoctungay.Value;
                com.Parameters.Add("@denngay", MySqlDbType.DateTime).Value = dateTimePicker_thuocdenngay.Value;
                com.Parameters.Add("@loidan", MySqlDbType.Text).Value = richTextBox_loidan.Text;
                com.Parameters.Add("@phieukhambenh_id", MySqlDbType.Int32, 11).Value = idPhieukhambenh;
                com.Parameters.Add("@bacsi_id", MySqlDbType.Int32, 11).Value = int.Parse(comboBox_bacsi_toathuoc.SelectedValue.ToString());

                com.CommandText = @"INSERT INTO toathuoc(tungay, denngay, loidan, Phieukhambenh_id, Bacsi_id) 
                                        VALUES (@tungay, @denngay, @loidan, @phieukhambenh_id, @bacsi_id)";
                Util.con.Open();
                com.ExecuteNonQuery();
                Util.con.Close();

                load_Toathuoc(idBenhnhan, idPhieukhambenh);
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("create Toa thuốc");
                return;
            }
        }

        private void button_fix_toathuoc_Click(object sender, EventArgs e)
        {
            int idToathuoc = -1;
            try
            {
                idToathuoc = int.Parse(comboBox_toathuoc.SelectedValue.ToString());
            }
            catch (Exception ex)
            {

            }
            if (idToathuoc == -1)
            {
                return;
            }
            if (MessageBox.Show("Bạn có muốn sửa thông tin toa thuốc này?", "Xác nhận cập nhật toa thuốc", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    MySqlCommand com = new MySqlCommand();
                    com.Connection = Util.con;

                    com.Parameters.Add("@tungay", MySqlDbType.DateTime).Value = dateTimePicker_thuoctungay.Value;
                    com.Parameters.Add("@denngay", MySqlDbType.DateTime).Value = dateTimePicker_thuocdenngay.Value;
                    com.Parameters.Add("@loidan", MySqlDbType.Text).Value = richTextBox_loidan.Text;
                    com.Parameters.Add("@idToathuoc", MySqlDbType.Int32, 11).Value = idToathuoc;
                    com.Parameters.Add("@idBacsi", MySqlDbType.Int32, 11).Value = int.Parse(comboBox_bacsi_toathuoc.SelectedValue.ToString());

                    com.CommandText = @"UPDATE toathuoc SET tungay=@tungay, denngay=@denngay, loidan=@loidan, bacsi_id=@idBacsi WHERE id=@idToathuoc";
                    Util.con.Open();
                    if (com.ExecuteNonQuery() != 0)
                    {
                        MessageBox.Show("Sửa thông tin thành công!!!");
                    }
                    else
                    {
                        MessageBox.Show("Sửa thông tin thất bại!!! Vui lòng kiểm tra lại");
                    }
                    Util.con.Close();
                }
                catch (MySqlException sqlE)
                {
                    MessageBox.Show("fix Toa thuốc");
                    return;
                }
            }
        }

        private void button_del_toathuoc_Click(object sender, EventArgs e)
        {
            int idToathuoc = -1;
            try
            {
                idToathuoc = int.Parse(comboBox_toathuoc.SelectedValue.ToString());
            }
            catch (Exception ex)
            {

            }
            if (idToathuoc == -1)
            {
                return;
            }

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
                com.Parameters.Add("@idToathuoc", MySqlDbType.Int32, 11).Value = idToathuoc;
                com.CommandText = @"SELECT *
                                        FROM toathuoc_thuoc
                                        WHERE Toathuoc_id=@idToathuoc";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                bool hasData = read.Read();
                Util.con.Close();
                if (hasData)
                {
                    if (MessageBox.Show("Toa thuốc này vẫn còn thuốc. Vui lòng xóa các thuốc trước khi xóa toa thuốc này!!!", "Lỗi khi xóa toa thuốc", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {

                    }
                }
                else
                {
                    if (MessageBox.Show("Bạn có muốn xóa toa thuốc này?", "Xác nhận xóa toa thuốc", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Util.con.Open();
                        com.CommandText = @"DELETE FROM toathuoc WHERE id=@idToathuoc";
                        com.ExecuteNonQuery();
                        Util.con.Close();
                        load_Toathuoc(idBenhnhan, idPhieukhambenh);
                    }
                }
            }
            catch (MySqlException mye)
            {

            }
        }

        private void button_xoa_thuoc_toathuoc_Click(object sender, EventArgs e)
        {
            int listView_chitiettoathuoc_select_length = listView_chitiettoathuoc.SelectedItems.Count;
            int idToathuoc = -1;
            try
            {
                idToathuoc = int.Parse(comboBox_toathuoc.SelectedValue.ToString());
            }
            catch (Exception)
            {

            }
            if (idToathuoc == -1 || listView_chitiettoathuoc_select_length == 0)
            {
                return;
            }

            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;

                com.Parameters.Add("@toathuoc_id", MySqlDbType.Int32, 11).Value = idToathuoc;
                string valueString = "";
                for (int i = 0; i < listView_chitiettoathuoc_select_length; i++)
                {
                    Hashtable hash = (Hashtable)listView_chitiettoathuoc.SelectedItems[i].Tag;
                    com.Parameters.Add("@thuoc_id" + i.ToString(), MySqlDbType.Int32, 11).Value = int.Parse(hash["thuoc_id"].ToString());
                    if (i == 0)
                    {
                        valueString += "thuoc_id=@thuoc_id" + i.ToString();
                    }
                    else
                    {
                        valueString += " OR thuoc_id=@thuoc_id" + i.ToString();
                    }
                }

                if (MessageBox.Show("Bạn có muốn xóa thuốc trong toa thuốc này?", "Xác nhận xóa thuốc", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    com.CommandText = @"DELETE FROM toathuoc_thuoc WHERE Toathuoc_id=@toathuoc_id AND (" + valueString + ")";
                    Util.con.Open();
                    com.ExecuteNonQuery();
                    Util.con.Close();
                }
                else
                {
                    return;
                }

                load_ChitietToathuoc_Thuoc(idToathuoc);
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
                int idBacsi = int.Parse(comboBox_bacsi_toathuoc.SelectedValue.ToString());
                updateYlenh(3, idToathuoc, idPhieukhambenh, idBacsi);
                load_Ylenh(idBenhnhan);
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }

        private void button_intoathuoc_Click(object sender, EventArgs e)
        {
            int idToathuoc = -1;
            try
            {
                idToathuoc = int.Parse(comboBox_toathuoc.SelectedValue.ToString());
            }
            catch (Exception ex)
            {

            }
            if (idToathuoc == -1)
            {
                return;
            }
            frmMain.frmReport = new ReportForm();
            frmMain.frmReport.frmMain = this.frmMain;
            frmMain.frmReport.MdiParent = this.frmMain;
            frmMain.frmReport.arrReport = new ArrayList();
            frmMain.frmReport.typeReport = "toathuoc";
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@toathuoc_id", MySqlDbType.Int32, 11).Value = idToathuoc;
                com.CommandText = @"SELECT benhnhan.*, phieukhambenh.*, ngoaitru.*, toathuoc.*, bacsi.TenBacsi, thuoc.*, toathuoc_thuoc.*
                                        FROM toathuoc_thuoc 
                                        LEFT OUTER JOIN toathuoc
                                            ON toathuoc_thuoc.Toathuoc_id=toathuoc.id 
                                        LEFT OUTER JOIN thuoc
                                            ON toathuoc_thuoc.Thuoc_id=thuoc.id
                                        LEFT OUTER JOIN phieukhambenh 
                                            ON phieukhambenh.id=toathuoc.Phieukhambenh_id 
                                        LEFT OUTER JOIN ngoaitru
                                            ON ngoaitru.Phieukhambenh_id=phieukhambenh.id 
                                        LEFT OUTER JOIN benhnhan
                                            ON benhnhan.id=phieukhambenh.Benhnhan_id 
                                        LEFT OUTER JOIN bacsi
                                            ON bacsi.id=toathuoc.Bacsi_id                                         
                                        WHERE toathuoc_thuoc.Toathuoc_id=@toathuoc_id";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    Toathuoc obj = new Toathuoc();
                    obj.Tungay = DateTime.Parse(read["Tungay"].ToString());
                    obj.Denngay = DateTime.Parse(read["Denngay"].ToString());
                    obj.Tenbenhnhan = read["Ten"].ToString();
                    obj.Ngaysinh = DateTime.Parse(read["Ngaysinh"].ToString());
                    obj.Gioitinh = int.Parse(read["Gioitinh"].ToString());
                    obj.Diachi = read["Sonha"].ToString() + " " + read["Duong"].ToString() + ", Phường " + read["Phuong"].ToString() + ", Quận " + read["Quan"].ToString() + ", TP. " + read["Thanhpho"].ToString();
                    obj.Bhyt = read["Sobhyt"].ToString();
                    obj.Bhytgiatriden = DateTime.Parse(read["Bhytgiatriden"].ToString());
                    obj.Dkkcbbd = read["DKKCBBD"].ToString();
                    obj.Chandoan = read["Benhchinh"].ToString() + " - " + read["Benhkemtheo"].ToString();
                    obj.Tenthuoc = read["Tenthuoc"].ToString() + " " + read["Hamluong"].ToString() + (read["ghichu"].ToString() != "" ? (" (" + read["ghichu"].ToString() + ")") : "");
                    obj.Duongdung = read["Duongdung"].ToString();
                    obj.Sang = read["sang"].ToString();
                    obj.Trua = read["trua"].ToString();
                    obj.Toi = read["toi"].ToString();
                    obj.Dang = read["Dang"].ToString();
                    obj.Loidan = read["Loidan"].ToString();
                    obj.Bacsi = read["TenBacsi"].ToString();
                    double sang = FractionToDouble(read["sang"].ToString() != "" ? read["sang"].ToString() : "0"),
                            trua = FractionToDouble(read["trua"].ToString() != "" ? read["trua"].ToString() : "0"),
                            toi = FractionToDouble(read["toi"].ToString() != "" ? read["toi"].ToString() : "0");
                    obj.Tongcong = Math.Round((obj.Denngay - obj.Tungay).TotalDays + 1) * (sang + trua + toi);
                    frmMain.frmReport.arrReport.Add(obj);
                }
                Util.con.Close();
                frmMain.frmReport.Show();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("in toa thuoc");
                return;
            }
        }

        public double FractionToDouble(string fraction)
        {
            double result;

            if (double.TryParse(fraction, out result))
            {
                return result;
            }

            string[] split = fraction.Split(new char[] { ' ', '/' });

            if (split.Length == 2 || split.Length == 3)
            {
                int a, b;

                if (int.TryParse(split[0], out a) && int.TryParse(split[1], out b))
                {
                    if (split.Length == 2)
                    {
                        return (double)a / b;
                    }

                    int c;

                    if (int.TryParse(split[2], out c))
                    {
                        return a + (double)b / c;
                    }
                }
            }

            throw new FormatException("Not a valid fraction.");
        }
//Chạy thận section----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void load_Chaythan(int idBenhnhan, int idPhieukhambenh)
        {
            comboBox_chaythan.DataSource = null;
            comboBox_chaythan.Text = "";
            comboBox_chaythan.SelectedIndex = -1;
            comboBox_chaythan.DisplayMember = "Text";
            comboBox_chaythan.ValueMember = "Value";
            List<object> myCollection = new List<object>();
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@idBenhnhan", MySqlDbType.Int32, 11).Value = idBenhnhan;
                com.Parameters.Add("@idPhieukhambenh", MySqlDbType.Int32, 11).Value = idPhieukhambenh;
                com.CommandText = @"SELECT chaythan.*
                                        FROM chaythan
                                        LEFT OUTER JOIN phieukhambenh
                                            ON chaythan.Phieukhambenh_id=phieukhambenh.id 
                                        LEFT OUTER JOIN ngoaitru
                                            ON ngoaitru.Phieukhambenh_id=phieukhambenh.id 
                                        LEFT OUTER JOIN benhnhan
                                            ON benhnhan.id=phieukhambenh.Benhnhan_id
                                        WHERE benhnhan.id=@idBenhnhan
                                            AND phieukhambenh.id=@idPhieukhambenh
                                        ORDER BY chaythan.id ASC";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                int i = 1;
                while (read.Read())
                {
                    myCollection.Add(new { Text = "Lần " + i.ToString(), Value = read["id"].ToString() });
                    i++;
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Load chạy thận");
                return;
            }
            comboBox_chaythan.DataSource = (object)myCollection;
            if (comboBox_chaythan.Items.Count > 0)
            {
                comboBox_chaythan.SelectedIndex = comboBox_chaythan.Items.Count - 1;
            }
        }

        public void load_ChitietChaythan(int idChaythan)
        {
            if (idChaythan == -1)
            {
                return;
            }
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;

                com.Parameters.Add("@idChaythan", MySqlDbType.Int32, 11).Value = idChaythan;
                com.CommandText = @"SELECT *
                                        FROM chaythan
                                        WHERE id=@idChaythan";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    comboBox_bacsi_chaythan.SelectedValue = read["Bacsi_id"].ToString();
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Load chi tiết chạy thận");
                return;
            }
        }

        public void load_ChitietChaythan_Thuoc(int idChaythan)
        {
            listView_chitiet_thuoc_chaythan.Items.Clear();
            if (idChaythan == -1)
            {
                return;
            }
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@idChaythan", MySqlDbType.Int32, 11).Value = idChaythan;
                com.CommandText = @"SELECT *
                                        FROM chaythan_thuoc
                                        LEFT OUTER JOIN thuoc
                                            ON chaythan_thuoc.thuoc_id=thuoc.id
                                        WHERE chaythan_thuoc.chaythan_id=@idChaythan";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                int i = 1;
                while (read.Read())
                {
                    Hashtable hash = new Hashtable();
                    hash.Add("chaythan_id", read["chaythan_id"].ToString());
                    hash.Add("thuoc_id", read["Thuoc_id"].ToString());
                    hash.Add("soluong", read["soluong"].ToString());
                    ListViewItem item = new ListViewItem();
                    item.Text = i.ToString();
                    item.Tag = hash;
                    item.SubItems.Add(read["Tenthuoc"].ToString() + " " + read["Hamluong"].ToString());
                    item.SubItems.Add(read["Duongdung"].ToString());
                    item.SubItems.Add(read["soluong"].ToString());
                    item.SubItems.Add(read["Dang"].ToString());
                    listView_chitiet_thuoc_chaythan.Items.Add(item);
                    i++;
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Load chi tiết chạy thận và thuốc");
                return;
            }
        }

        private void textBox_search_thuoc_chaythan_TextChanged(object sender, EventArgs e)
        {
            listView_search_thuoc_chaythan.Items.Clear();
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.AddWithValue("@tenthuoc", "%" + textBox_searchthuoc.Text + "%");
                com.CommandText = @"SELECT *
                                        FROM thuoc
                                        WHERE tenthuoc LIKE @tenthuoc";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                int i = 1;
                while (read.Read())
                {
                    Hashtable hash = new Hashtable();
                    hash.Add("thuoc_id", read["id"].ToString());
                    ListViewItem item = new ListViewItem();
                    item.Text = i.ToString();
                    item.Tag = hash;
                    item.SubItems.Add(read["Tenthuoc"].ToString() + " " + read["Hamluong"].ToString());
                    item.SubItems.Add(read["Duongdung"].ToString());
                    item.SubItems.Add(read["Dang"].ToString());
                    listView_search_thuoc_chaythan.Items.Add(item);
                    i++;
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Tìm thuốc theo tên thuốc");
                return;
            }
        }

        private void button_nhap_thuoc_chaythan_Click(object sender, EventArgs e)
        {
            int idChaythan = -1;
            try
            {
                idChaythan = int.Parse(comboBox_chaythan.SelectedValue.ToString());
            }
            catch (Exception)
            {

            }
            if (idChaythan == -1 || listView_search_thuoc_chaythan.SelectedItems.Count < 1)
            {
                return;
            }
            Hashtable hash = (Hashtable)listView_search_thuoc_chaythan.SelectedItems[0].Tag;
            int idThuoc = int.Parse(hash["thuoc_id"].ToString());
            if (cotrongChaythan(idThuoc.ToString()))
            {
                return;
            }
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@idChaythan", MySqlDbType.Int32, 11).Value = idChaythan;
                com.Parameters.Add("@idThuoc", MySqlDbType.Int32, 11).Value = idThuoc;
                com.CommandText = @"INSERT INTO `chaythan_thuoc` (`Chaythan_id`, `Thuoc_id`) VALUES (@idChaythan, @idThuoc)";
                Util.con.Open();
                com.ExecuteNonQuery();
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("Thêm thuốc vào chạy thận");
                return;
            }
            load_ChitietChaythan_Thuoc(idChaythan);
        }

        public bool cotrongChaythan(string id)
        {
            int listView_chitiet_thuoc_chaythan_length = listView_chitiet_thuoc_chaythan.Items.Count;
            for (int i = 0; i < listView_chitiet_thuoc_chaythan_length; i++)
            {
                Hashtable hash = (Hashtable)listView_chitiet_thuoc_chaythan.Items[i].Tag;
                if (hash["thuoc_id"].ToString() == id)
                {
                    return true;
                }
            }
            return false;
        }

        private void button_create_chaythan_Click(object sender, EventArgs e)
        {
            int idBenhnhan = -1;
            try
            {
                idBenhnhan = int.Parse(textBox_MaBN.Text);
            }
            catch (Exception ex)
            {

            }
            if (idBenhnhan == -1)
            {
                return;
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

                com.Parameters.Add("@phieukhambenh_id", MySqlDbType.Int32, 11).Value = idPhieukhambenh;
                com.Parameters.Add("@bacsi_id", MySqlDbType.Int32, 11).Value = int.Parse(comboBox_bacsi_chaythan.SelectedValue.ToString());

                com.CommandText = @"INSERT INTO chaythan(Phieukhambenh_id, Bacsi_id) 
                                        VALUES (@phieukhambenh_id, @bacsi_id)";
                Util.con.Open();
                com.ExecuteNonQuery();
                Util.con.Close();

                load_Chaythan(idBenhnhan, idPhieukhambenh);
            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("create Chạy thận");
                return;
            }
        }

        private void button_fix_chaythan_Click(object sender, EventArgs e)
        {
            int idChaythan = -1;
            try
            {
                idChaythan = int.Parse(comboBox_chaythan.SelectedValue.ToString());
            }
            catch (Exception ex)
            {

            }
            if (idChaythan == -1)
            {
                return;
            }
            if (MessageBox.Show("Bạn có muốn sửa thông tin chạy thận này?", "Xác nhận cập nhật chạy thận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    MySqlCommand com = new MySqlCommand();
                    com.Connection = Util.con;

                    com.Parameters.Add("@idChaythan", MySqlDbType.Int32, 11).Value = idChaythan;
                    com.Parameters.Add("@idBacsi", MySqlDbType.Int32, 11).Value = int.Parse(comboBox_bacsi_chaythan.SelectedValue.ToString());

                    com.CommandText = @"UPDATE chaythan SET Bacsi_id=@idBacsi WHERE id=@idChaythan";
                    Util.con.Open();
                    if (com.ExecuteNonQuery() != 0)
                    {
                        MessageBox.Show("Sửa thông tin thành công!!!");
                    }
                    else
                    {
                        MessageBox.Show("Sửa thông tin thất bại!!! Vui lòng kiểm tra lại");
                    }
                    Util.con.Close();
                }
                catch (MySqlException sqlE)
                {
                    MessageBox.Show("fix chạy thận");
                    return;
                }
            }
        }

        private void comboBox_chaythan_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idChaythan = -1;
            try
            {
                idChaythan = int.Parse(comboBox_chaythan.SelectedValue.ToString());
            }
            catch (Exception)
            {

            }
            load_ChitietChaythan(idChaythan);
            load_ChitietChaythan_Thuoc(idChaythan);
        }

        private void button_del_chaythan_Click(object sender, EventArgs e)
        {
            int idChaythan = -1;
            try
            {
                idChaythan = int.Parse(comboBox_chaythan.SelectedValue.ToString());
            }
            catch (Exception ex)
            {

            }
            if (idChaythan == -1)
            {
                return;
            }

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
                com.Parameters.Add("@idChaythan", MySqlDbType.Int32, 11).Value = idChaythan;
                com.CommandText = @"SELECT *
                                        FROM chaythan_thuoc
                                        WHERE Chaythan_id=@idChaythan";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                bool hasData = read.Read();
                Util.con.Close();
                if (hasData)
                {
                    if (MessageBox.Show("Chạy thận này vẫn còn thuốc. Vui lòng xóa các thuốc trước khi xóa chạy thận này!!!", "Lỗi khi xóa chạy thận", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {

                    }
                }
                else
                {
                    if (MessageBox.Show("Bạn có muốn xóa chạy thận này?", "Xác nhận xóa chạy thận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Util.con.Open();
                        com.CommandText = @"DELETE FROM chaythan WHERE id=@idChaythan";
                        com.ExecuteNonQuery();
                        Util.con.Close();
                        load_Chaythan(idBenhnhan, idPhieukhambenh);
                    }
                }
            }
            catch (MySqlException mye)
            {

            }
        }

        private void listView_chitiet_thuoc_chaythan_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_tenthuoc_chaythan.Text = "";
            textBox_soluong_thuoc_chaythan.Text = "";
            if (listView_chitiet_thuoc_chaythan.SelectedItems.Count < 1)
            {
                return;
            }
            Hashtable hash = (Hashtable)listView_chitiet_thuoc_chaythan.SelectedItems[0].Tag;
            textBox_tenthuoc_chaythan.Text = listView_chitiet_thuoc_chaythan.SelectedItems[0].SubItems[1].Text;
            textBox_soluong_thuoc_chaythan.Text = hash["soluong"].ToString();
        }

        private void button_capnhat_chitiet_thuoc_chaythan_Click(object sender, EventArgs e)
        {
            int items_count = listView_chitiet_thuoc_chaythan.Items.Count;
            if (listView_chitiet_thuoc_chaythan.SelectedItems.Count < 1)
            {
                return;
            }
            Hashtable hash = (Hashtable)listView_chitiet_thuoc_chaythan.SelectedItems[0].Tag;
            hash["soluong"] = textBox_soluong_thuoc_chaythan.Text;
            listView_chitiet_thuoc_chaythan.SelectedItems[0].SubItems[3].Text = hash["soluong"].ToString();
            listView_chitiet_thuoc_chaythan.SelectedItems[0].Tag = hash;
            int index = listView_chitiet_thuoc_chaythan.SelectedIndices[0];
            if (index + 1 < items_count)
            {
                listView_chitiet_thuoc_chaythan.Items[index + 1].Selected = true;
                listView_chitiet_thuoc_chaythan.Items[index + 1].EnsureVisible();
            }
            textBox_soluong_thuoc_chaythan.Focus();
        }

        private void textBox_soluong_thuoc_chaythan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_capnhat_chitiet_thuoc_chaythan_Click(sender, e);
            }
        }

        private void button_save_thuoc_chaythan_Click(object sender, EventArgs e)
        {
            int idChaythan = -1;
            try
            {
                idChaythan = int.Parse(comboBox_chaythan.SelectedValue.ToString());
            }
            catch (Exception)
            {

            }
            if (idChaythan == -1)
            {
                return;
            }
            int listView_chitiet_thuoc_chaythan_length = listView_chitiet_thuoc_chaythan.Items.Count;
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;

                string valueString1 = "", valueString2 = "";
                for (int i = 0; i < listView_chitiet_thuoc_chaythan_length; i++)
                {
                    Hashtable hash = (Hashtable)listView_chitiet_thuoc_chaythan.Items[i].Tag;
                    com.Parameters.Add("@thuoc_id" + i.ToString(), MySqlDbType.Int32, 11).Value = int.Parse(hash["thuoc_id"].ToString());
                    com.Parameters.Add("@soluong" + i.ToString(), MySqlDbType.VarChar, 45).Value = hash["soluong"].ToString();
                    valueString2 += " WHEN @thuoc_id" + i.ToString() + " THEN @soluong" + i.ToString();
                    if (i == 0)
                    {
                        valueString1 += "@thuoc_id" + i.ToString();
                    }
                    else
                    {
                        valueString1 += ", @thuoc_id" + i.ToString();
                    }
                }

                com.Parameters.Add("@chaythan_id", MySqlDbType.Int32, 11).Value = idChaythan;

                com.CommandText = @"UPDATE chaythan_thuoc SET soluong = CASE thuoc_id" + valueString2 + " END WHERE Thuoc_id IN (" + valueString1 + ") AND Chaythan_id=@chaythan_id";

                if (MessageBox.Show("Bạn có muốn lưu thuốc chạy thận này?", "Xác nhận cập nhật thuốc chạy thận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Util.con.Open();
                    com.ExecuteNonQuery();
                    Util.con.Close();

                    load_ChitietChaythan(idChaythan);
                    load_ChitietChaythan_Thuoc(idChaythan);
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
                    int idBacsi = int.Parse(comboBox_bacsi_toathuoc.SelectedValue.ToString());
                    updateYlenh(4, idChaythan, idPhieukhambenh, idBacsi);
                    load_Ylenh(idBenhnhan);
                }

            }
            catch (MySqlException sqlE)
            {
                MessageBox.Show("update chi tiết thuốc chạy thận");
                return;
            }
        }

        private void button_del_thuoc_chaythan_Click(object sender, EventArgs e)
        {
            int listView_chitiet_thuoc_chaythan_select_length = listView_chitiet_thuoc_chaythan.SelectedItems.Count;
            int idChaythan = -1;
            try
            {
                idChaythan = int.Parse(comboBox_chaythan.SelectedValue.ToString());
            }
            catch (Exception)
            {

            }
            if (idChaythan == -1 || listView_chitiet_thuoc_chaythan_select_length == 0)
            {
                return;
            }

            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;

                com.Parameters.Add("@chaythan_id", MySqlDbType.Int32, 11).Value = idChaythan;
                string valueString = "";
                for (int i = 0; i < listView_chitiet_thuoc_chaythan_select_length; i++)
                {
                    Hashtable hash = (Hashtable)listView_chitiet_thuoc_chaythan.SelectedItems[i].Tag;
                    com.Parameters.Add("@thuoc_id" + i.ToString(), MySqlDbType.Int32, 11).Value = int.Parse(hash["thuoc_id"].ToString());
                    if (i == 0)
                    {
                        valueString += "thuoc_id=@thuoc_id" + i.ToString();
                    }
                    else
                    {
                        valueString += " OR thuoc_id=@thuoc_id" + i.ToString();
                    }
                }

                if (MessageBox.Show("Bạn có muốn xóa thuốc trong chạy thận này?", "Xác nhận xóa thuốc chạy thận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    com.CommandText = @"DELETE FROM chaythan_thuoc WHERE Chaythan_id=@chaythan_id AND (" + valueString + ")";
                    Util.con.Open();
                    com.ExecuteNonQuery();
                    Util.con.Close();
                }
                else
                {
                    return;
                }

                load_ChitietChaythan_Thuoc(idChaythan);
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
                int idBacsi = int.Parse(comboBox_bacsi_toathuoc.SelectedValue.ToString());
                updateYlenh(4, idChaythan, idPhieukhambenh, idBacsi);
                load_Ylenh(idBenhnhan);
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }

        private void button_del_dieutri_Click(object sender, EventArgs e)
        {
            int listView_dieutri_select_length = listView_dieutri.SelectedItems.Count;
            if (listView_dieutri_select_length == 0)
            {
                return;
            }
            string valueString = "";
            for (int i = 0; i < listView_dieutri_select_length; i++)
            {
                Hashtable hash = (Hashtable)listView_dieutri.SelectedItems[i].Tag;
                if (i == 0)
                {
                    valueString += hash["id"].ToString();
                }
                else
                {
                    valueString += ", " + hash["id"].ToString();
                }
            }
            if (MessageBox.Show("Bạn có muốn xóa nội dung tờ điều trị này?", "Xác nhận xóa nội dung tờ diều trị", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    MySqlCommand com = new MySqlCommand();
                    com.Connection = Util.con;
                    com.CommandText = @"DELETE FROM todieutri_noidung WHERE id IN (" + valueString + ")";
                    Util.con.Open();
                    com.ExecuteNonQuery();
                    Util.con.Close();
                }
                catch (MySqlException sqlE)
                {
                    return;
                }

                int idBenhnhan = -1;
                try
                {
                    idBenhnhan = int.Parse(textBox_MaBN.Text);
                }
                catch (Exception ex)
                {

                }
                load_Dieutri(idBenhnhan);
            }
        }

        



    }
}
