﻿using System;
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
using System.Collections;

namespace QLBV_normal
{
    public partial class DangkyForm : Form
    {
        public MainForm frmMain;
        public ReportForm frmReport;
        int tt = 0;
        ArrayList arricd = new ArrayList();
        string benhkemtheo;
        public DangkyForm()
        {
            InitializeComponent();
        }

        private void DangkyForm_Load(object sender, EventArgs e)
        {
           
            Show_Combobox_Bacsi();
            

        }
        public bool Kiemtrabenhnhanxuatvien(String mabn)
        {
            MySqlCommand com1 = new MySqlCommand();
            com1.Connection = Util.con;
            com1.CommandText = "select ngoaitru.Tinhtrangravien from ngoaitru, phieukhambenh "+
                                "where ngoaitru.Phieukhambenh_id= phieukhambenh.id "+ 
                                "and ngoaitru.Tinhtrangravien=0 "+
                                "and phieukhambenh.Benhnhan_id= " + mabn;
            Util.con.Open();
            MySqlDataReader read = com1.ExecuteReader();
            //Util.con.Close();
            if (read.Read())
            {
                Util.con.Close();
                return false;//  benh nhan chua xuat vien
                
            }
            else
                Util.con.Close();
                return true;   // benh nhan da xuat vien      
        }


        private void button_CapNhat_Click(object sender, EventArgs e)
        {
           
            //// cap nhat phieu kham benh
            //try
            //{
                if (Kiemtrabenhnhanxuatvien(textBox_MaBN.Text) == true)
                {
                    MySqlCommand com1 = new MySqlCommand();
                    com1.Connection = Util.con;
                    if (comboBox_Doituong.Text == "BHYT")
                        com1.Parameters.Add("@doituong", MySqlDbType.Int16, 200).Value = 1;
                    else
                        if (comboBox_Doituong.Text == "THU PHÍ")
                            com1.Parameters.Add("@doituong", MySqlDbType.Int16, 200).Value = 2;
                        else
                            if (comboBox_Doituong.Text == "MIỄN PHÍ")
                                com1.Parameters.Add("@doituong", MySqlDbType.Int16, 200).Value = 3;
                            else
                                if (comboBox_Doituong.Text == "KHÁC")
                                    com1.Parameters.Add("@doituong", MySqlDbType.Int16, 200).Value = 4;

                    com1.Parameters.Add("@noidkkcbbd", MySqlDbType.VarChar, 200).Value = textBox_NoiDKKCBBD.Text;
                    com1.Parameters.Add("@bhytgiatritu", MySqlDbType.Date, 20).Value = dateTimePicker_Tu.Value;
                    com1.Parameters.Add("@bhytgiatriden", MySqlDbType.Date, 20).Value = dateTimePicker_Den.Value;
                    com1.Parameters.Add("@sobhyt", MySqlDbType.VarChar, 30).Value = textBox_Sothe.Text;
                    com1.Parameters.Add("@nguoithan", MySqlDbType.VarChar, 20).Value = textBox_Nguoithan.Text;
                    com1.Parameters.Add("@diachinguoithan", MySqlDbType.VarChar, 100).Value = textBox_Diachinguoithan.Text;
                    com1.Parameters.Add("@dienthoai", MySqlDbType.VarChar, 50).Value = textBox_Dienthoai.Text;
                    DateTime thoigiankham = new DateTime(dateTimePicker_Ngaykham.Value.Year, dateTimePicker_Ngaykham.Value.Month, dateTimePicker_Ngaykham.Value.Day, dateTimePicker_Giokham.Value.Hour, dateTimePicker_Giokham.Value.Minute, dateTimePicker_Giokham.Value.Second);
                    com1.Parameters.Add("@thoigiandenkham", MySqlDbType.DateTime, 50).Value = thoigiankham;
                    com1.Parameters.Add("@noigioithieu", MySqlDbType.VarChar, 100).Value = textBox_Noigioithieu.Text;
                    com1.Parameters.Add("@lydovaovien", MySqlDbType.VarChar, 200).Value = textBox_Lydovaovien.Text;
                    com1.Parameters.Add("@quatrinhbenhly", MySqlDbType.VarChar, 200).Value = textBox_Quatrinhbenhly.Text;
                    com1.Parameters.Add("@tiensubenhbanthan", MySqlDbType.VarChar, 200).Value = textBox_Tiensubenhbanthan.Text;
                    com1.Parameters.Add("@tiensubenhgiadinh", MySqlDbType.VarChar, 200).Value = textBox_tiensubenhgiadinh.Text;
                    com1.Parameters.Add("@mach", MySqlDbType.VarChar, 20).Value = textBox_Mach.Text;
                    com1.Parameters.Add("@nhietdo", MySqlDbType.VarChar, 20).Value = textBox_Nhiet.Text;
                    com1.Parameters.Add("@huyetap", MySqlDbType.VarChar, 20).Value = textBox_Huyetap.Text;
                    com1.Parameters.Add("@nhiptho", MySqlDbType.VarChar, 20).Value = textBox_Nhiptho.Text;
                    com1.Parameters.Add("@trongluong", MySqlDbType.VarChar, 20).Value = textBox_Trongluong.Text;
                    com1.Parameters.Add("@toanthan", MySqlDbType.VarChar, 20).Value = richText_Toanthan.Text;
                    com1.Parameters.Add("@cacbophan", MySqlDbType.VarChar, 200).Value = richTextBox_Cacbophan.Text;
                    com1.Parameters.Add("@tomtat", MySqlDbType.VarChar, 200).Value = richTextBox_Tomtat.Text;
                    com1.Parameters.Add("@chuandoan", MySqlDbType.VarChar, 200).Value = richTextBox_Chuandoan.Text;
                    com1.Parameters.Add("@xuli", MySqlDbType.VarChar, 200).Value = richTextBox_Xuly.Text;
                    com1.Parameters.Add("@dieutritaikhoa", MySqlDbType.VarChar, 200).Value = textBox_Dieutritaikhoa.Text;
                    com1.Parameters.Add("@chuy", MySqlDbType.VarChar, 200).Value = textBox_Chuy.Text;
                    com1.Parameters.Add("@idbenhnhan", MySqlDbType.Int64, 20).Value = textBox_MaBN.Text;



                    com1.CommandText = "insert into phieukhambenh(Doituong,DKKCBBD,Bhytgiatritu,Bhytgiatriden,Sobhyt,Nguoithan" +
                        ",Diachinguoithan,Dienthoai,Thoigiandenkham,Noigioithieu,Lydovaovien,Quatrinhbenhly,Tiensubenhbanthan,Tiensubenhgiadinh" +
                        ",Mach,Nhietdo,Huyetap,Nhiptho,Trongluong,Toanthan,Cacbophan,Tomtatketqualamsan,Chuandoanvaovien" +
                        ",Xuli,Dieutritaikhoa,Chuy,Benhnhan_id) values (@doituong,@noidkkcbbd,@bhytgiatritu,@bhytgiatriden," +
                        "@sobhyt,@nguoithan,@diachinguoithan,@dienthoai,@thoigiandenkham,@noigioithieu,@lydovaovien," +
                        "@quatrinhbenhly,@tiensubenhbanthan,@tiensubenhgiadinh,@mach,@nhietdo,@huyetap,@nhiptho,@trongluong,@toanthan,@cacbophan" +
                        ",@tomtat,@chuandoan,@xuli,@dieutritaikhoa,@chuy,@idbenhnhan)";

                    Util.con.Open();
                    com1.ExecuteNonQuery();
                    Util.con.Close();


                    /// nhap vao ngoai tru hay noi tru 
                    /// lay ma phieu kham benh

                    com1.CommandText = "SELECT MAX( id )FROM phieukhambenh WHERE benhnhan_id =" + textBox_MaBN.Text;
                    //MessageBox.Show("executenonquery select");
                    Util.con.Open();
                    int maphieukhambenh = (int)com1.ExecuteScalar();
                    Util.con.Close();
                    if (comboBox_Loaidieutri.Text == "NGOẠI TRÚ")
                        //MessageBox.Show(maphieukhambenh.ToString());
                        com1.CommandText = "INSERT INTO ngoaitru (`id`, `Ngaygiovaovien`, `Benhchinh`, `Benhkemtheo`, `Dieutritu`, `Dieutriden`, `Tinhtrangravien`, `Chuandoankhiravien`, `Huongdieutri`, `Bacsikhambenh`, `Bacsidieutri`, `Phieukhambenh_id`, `Soxquang`, `Soctscanner`, `Sosieuam`, `Soxetnghiem`, `Sokhac`) VALUES (NULL, '"+ dateTimePicker_Ngaykham.Value +"','"+ textBox_Benhchinh.Text +"', '"+benhkemtheo+"', '"+ dateTimePicker_Ngaykham.Value +"', NULL, '0', '"+ richTextBox_Chuandoan.Text +"', 'Đổi hồ sơ tiếp tục điều trị', '"+textBox_tenbacsikham.Text+"', '"+ textBox_tenbacsikham.Text +"',"+maphieukhambenh+", '0', '0', '0', '0', '0')";
                    // com1.CommandText = "INSERT INTO  ngoaitru (id,Ngaygiovaovien,Benhchinh ,Benhkemtheo,Dieutritu ,Dieutriden ,Tinhtrangravien,Chuandoankhiravien,Huongdieutri ,Bacsikhambenh ,Bacsidieutri  ,Phieukhambenh_id)VALUES (NULL ," + dateTimePicker_Ngaykham.Value +", NULL , NULL ,"+dateTimePicker_Ngaykham.Value +", NULL , 0,'"+ richTextBox_dsbenh.Text + "',NULL,'" + comboBox_Bacsikham.Text + "'," + maphieukhambenh + ")";
                    else com1.CommandText = "INSERT INTO `dbthan`.`noitru` (`id`, `Thoigianvaovien`, `Tructiepvao`, `Vaolanthu`, `Ngaygiovaokhoa`, `Chuyenkhoa`, `Ngaygiochuyenkhoa`, `Chuyenvien`, `Chuyenden`, `Ngaygioravien`, `Loairavien`, `Noichuyenden`, `KKBCapcuu`, `Khivaokhoadieutri`, `Thuthuat`, `Phauthuat`, `Benhchinh`, `Benhkemtheo`, `Taibien`, `Bienchung`, `Ketquadieutri`, `Giaiphaubenh`, `Thoigiantuvong`, `Lydotuvong`, `Nguyennhanchinhtuvong`, `Khamnghiemtuthi`, `Chuandoangiaiphaututhi`, `Diung`, `Matuy`, `Ruoubia`, `Thuocla`, `Thuoclao`, `Khac`, `Tuanhoan`, `Hohap`, `Tieuhoa`, `Thantietnieusinhduc`, `Thankinh`, `Coxuongkhop`, `Taimuihong`, `Ranghammat`, `Mat`, `Noitietdinhduong`, `Tomtatbenhan`, `Tienluong`, `Huongdieutri`, `Phuongphapdieutri`, `BStruongkhoa`, `Bslambenhan`, `BSdieutri`, `Phieukhambenh_id`) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL," + maphieukhambenh + ")";
                    Util.con.Open();
                    com1.ExecuteNonQuery();
                    Util.con.Close();
                    /// nhap chuan doan benh
                    foreach (var i in arricd)
                    {
                        com1.CommandText = "INSERT INTO idc_phieukhambenh(idc_phieukhambenh.IDC_id,idc_phieukhambenh.Phieukhambenh_id) values('" + i.ToString() + "'," + maphieukhambenh + ")";
                        Util.con.Open();
                        com1.ExecuteNonQuery();
                        Util.con.Close();
                    }
                    arricd.Clear();
                    MessageBox.Show("Đăng ký phiếu khám bệnh và nhập khoa thành công");
                }
                else MessageBox.Show(" Bệnh nhân chưa xuất viện");
            //}
            //catch (MySqlException sqlE)
            //{
            //    Util.con.Close();
            //    MessageBox.Show(sqlE.Source.ToString());
            //    return;
            //}
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
            //comboBox_Dantoc.Text = "KINH";
           // comboBox_Ngoaikieu.Text = "";
            //textBox_Sonha.Text = "";
            //textBox_Thanhpho.Text = "";
           // textBox_Quan.Text = "";
            //textBox_Phuong.Text = "";
            //textBox_Noilamviec.Text = "";
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
            textBox_Tiensubenhbanthan.Text = "";
            textBox_Mach.Text = "";
            textBox_Nhiet.Text = "";
            textBox_Huyetap.Text = "";
            textBox_Nhiptho.Text = "";
            textBox_Trongluong.Text = "";
            richText_Toanthan.Text = "";
            richTextBox_Cacbophan.Text = "";
            richTextBox_Tomtat.Text = "";
            textBox_Benhkemtheo.Text = "";
            richTextBox_Xuly.Text = "";
            comboBox_Loaidieutri.Text = "NGOẠI TRÚ CHẠY THẬN";
            textBox_Chuy.Text = "";

          

         // thong tin phieu kham benh
        }
       // public void Show_list
        public  void Show_Combobox_Bacsi ()
        {
            //try
            //{
            //    MySqlCommand com = new MySqlCommand();
            //    com.Connection = Util.con;
            //    com.CommandText = "SELECT * FROM bacsi";
            //    Util.con.Open();
            //    MySqlDataReader read = com.ExecuteReader();
            //    while (read.Read())
            //    {
            //        comboBox_Bacsikham.Items.Add(read["TenBacsi"].ToString());
            //    }

            //    Util.con.Close();
            //}
            //catch (MySqlException sqlE)
            //{
            //    //MessageBox.Show(sqlE.Source.ToString());
            //    return;
            //}
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
                        tt = 1;
                        textBox_Ten.Text = read[1].ToString();
                        dateTimePicker_Namsinh.Value = DateTime.Parse(read[2].ToString());
                        if (read[3].ToString() == "True")
                            comboBox_Gioitinh.Text = "Nam";
                        else comboBox_Gioitinh.Text = "Nữ";
                        comboBox_Nghenghiep.Text = read[4].ToString();
                        //comboBox_Dantoc.Text = read[5].ToString();
                        textBox_CMND.Text = read[6].ToString();
                        //comboBox_Ngoaikieu.Text = read[7].ToString();
                        //textBox_Sonha.Text = read[8].ToString();
                        //textBox_duong.Text = read[9].ToString();
                        //textBox_Phuong.Text = read[10].ToString();
                        //textBox_Quan.Text = read[11].ToString();
                        //textBox_Thanhpho.Text = read[12].ToString();
                        //textBox_Noilamviec.Text = read[13].ToString();

                    }
                    Util.con.Close();
                    Show_listview_caclankhac();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_MaBN.TextLength == 0)
                MessageBox.Show("Bạn chưa nhập mã bệnh nhân");
            else
            if (frmMain.frmReport == null || frmMain.frmReport.IsDisposed)
            {
                
                frmMain.frmReport = new ReportForm();
                frmMain.frmReport.frmMain = this.frmMain;
                frmMain.frmReport.MdiParent = this.frmMain;
                frmMain.frmReport.arrReport = new ArrayList();
                frmMain.frmReport.typeReport = "Phieukhambenh";
                try
                {
                    MySqlCommand com = new MySqlCommand();
                    com.Connection = Util.con;
                    com.CommandText = "select * from benhnhan, phieukhambenh,ngoaitru where benhnhan.id=phieukhambenh.Benhnhan_id and phieukhambenh.id=ngoaitru.Phieukhambenh_id  and benhnhan.id=" + textBox_MaBN.Text;
                    Util.con.Open();
                    MySqlDataReader read = com.ExecuteReader();
                    while (read.Read())
                    {
                        Phieukhambenh bant = new Phieukhambenh();
                        bant.IdBenhnhan=int.Parse(read[0].ToString());
                        bant.Ten = read[1].ToString();
                        bant.Ngaysinh = DateTime.Parse(read[2].ToString());
                        bant.Tuoi = DateTime.Today.Year - bant.Ngaysinh.Year;
                        // ngay thang nam
                        string a;
                        if (bant.Ngaysinh.Day.ToString().Length == 1)
                            a = "0" + bant.Ngaysinh.Day.ToString();
                        else
                            a = bant.Ngaysinh.Day.ToString(); 
                        bant.Ngay1 = a.Substring(0,1);
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
                        //bant.Gioitinh = read[3].ToString(); 
                        bant.Nghenghiep = read[4].ToString();
                        bant.Dantoc = read[5].ToString();
                        bant.CMND = read[6].ToString();
                        bant.Ngoaikieu = read[7].ToString();
                        bant.Sonha = read[8].ToString();
                        bant.Duong = read[9].ToString();
                        bant.Phuong = read[10].ToString();
                        bant.Quan = read[11].ToString();
                        bant.Thanhpho = read[12].ToString();
                        bant.Noilamviec = read[13].ToString();
                        bant.Doituong= int.Parse(read[15].ToString());
                        bant.DKKCBBD = read[16].ToString();
                        bant.BYYTgiatritu = DateTime.Parse(read[17].ToString());
                        bant.BYYTgiatriden = DateTime.Parse(read[18].ToString());
                        bant.Sobhyt = read[19].ToString();
                        bant.Nguoithan = read[20].ToString();
                        bant.Diachinguoithan = read[21].ToString();
                        bant.Dienthoai = read[22].ToString();
                        bant.Thoigiandenkham = DateTime.Parse(read[23].ToString());
                        bant.Noigioithieu = read[24].ToString(); ;
                        bant.Lydovaovien = read[25].ToString();
                        bant.Quatrinhbenhly = read[26].ToString();
                        bant.Tiensubenhbanthan = read[27].ToString();
                        bant.Tiensubenhgiadinh = read[28].ToString();
                        bant.Mach = read[29].ToString();
                        bant.Nhietdo = read[30].ToString();
                        bant.Huyetap = read[31].ToString();
                        bant.Nhiptho = read[32].ToString();
                        bant.Trongluong = read[33].ToString();
                        bant.Toanthan = read[34].ToString();
                        bant.Cacbophan = read[35].ToString();
                        bant.Tomtatketqualamsan = read[36].ToString();
                        bant.Chuandoanvaovien = read[37].ToString();
                        bant.Xuli = read[38].ToString();
                        bant.Dieutritaikhoa = read[39].ToString();
                        bant.Chuy = read[40].ToString();
                        bant.Benhnhan_id = read[41].ToString();
                        bant.Bacsikhambenh = read[50].ToString();
                        frmMain.frmReport.arrReport.Add(bant);
                    }

                    Util.con.Close();
                    frmMain.frmReport.Show();
                }
                catch (MySqlException sqlE)
                {
                    MessageBox.Show(sqlE.Source.ToString());
                    return;
                }
                
               
            }
            else
            {
                frmMain.frmReport.Focus();
            }
        }

        private void textBox_Ten_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.Parse(e.KeyChar.ToString().ToUpper());  
        }

        private void textBox_idbacsikham_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox_idbacsikham.TextLength > 0)
                {
                    MySqlCommand com = new MySqlCommand();
                    com.Connection = Util.con;
                    com.CommandText = "SELECT * FROM bacsi WHERE id= " + textBox_idbacsikham.Text;
                    //MessageBox.Show(com.CommandText.te);
                    Util.con.Open();
                    MySqlDataReader read = com.ExecuteReader();
                    if (read.Read())
                    {
                       
                        textBox_tenbacsikham.Text = read[1].ToString();
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
        private void textBox_idIDCchinh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox_idIDCchinh.TextLength > 0)
                {
                    MySqlCommand com = new MySqlCommand();
                    com.Connection = Util.con;
                    com.CommandText = "select idc.TenIDC from idc where idc.id='" + textBox_idIDCchinh.Text + "'";
                    //MessageBox.Show(com.CommandText.te);
                    Util.con.Open();
                    MySqlDataReader read = com.ExecuteReader();
                    if (read.Read())
                    {
                        textBox_Benhchinh.Text = read[0].ToString();
                        Util.con.Close();
                    }
                    //else MessageBox.Show("Mã ICD Chưa có trong dữ liệu");
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
        private void textBox_maICD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox_idICDkemtheo.TextLength > 0)
                {
                    MySqlCommand com = new MySqlCommand();
                    com.Connection = Util.con;
                    com.CommandText = "select idc.TenIDC from idc where idc.id='"+ textBox_idICDkemtheo.Text+"'" ;
                    //MessageBox.Show(com.CommandText.te);
                    Util.con.Open();
                    MySqlDataReader read = com.ExecuteReader();
                    if (read.Read())
                    {
                        textBox_Benhkemtheo.Text = read[0].ToString();
                        Util.con.Close();
                    }
                    //else MessageBox.Show("Mã ICD Chưa có trong dữ liệu");
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

        private void textBox_idIDCchinh_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                  
                        this.textBox_idICDkemtheo.Focus();
                        richTextBox_Chuandoan.Text = textBox_Benhchinh.Text;
                
                }
                else return;
            }
            catch (MySqlException sqlE)
            {

                return;
            }
        }
        private void textBox_idICD_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_Benhkemtheo.Text.Length > 0)
                    {
                        richTextBox_Chuandoan.Text +=" -" +textBox_Benhkemtheo.Text ;
                        arricd.Add(textBox_idICDkemtheo.Text);
                        textBox_Benhkemtheo.Text = null;
                        textBox_idICDkemtheo.Text = null;
                        this.textBox_idICDkemtheo.Focus();
                    }
                }
                else return;
            }
            catch (MySqlException sqlE)
            {
               
                return;
            }
        }

        public void Show_listview_caclankhac()
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.CommandText = "select phieukhambenh.id, phieukhambenh.Thoigiandenkham from phieukhambenh where phieukhambenh.Benhnhan_id=" + textBox_MaBN.Text + "  ORDER BY phieukhambenh.Thoigiandenkham DESC";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                listView_Caclankhambenh.Items.Clear();
                while (read.Read())
                {
                    int i = listView_Caclankhambenh.Items.Count;
                    listView_Caclankhambenh.Items.Add(read[0].ToString());
                    listView_Caclankhambenh.Items[i].SubItems.Add(read[1].ToString());

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
        private void listView_Caclankhambenh_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (listView_Caclankhambenh.SelectedItems.Count < 1)
                {
                    return;
                }
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                //MessageBox.Show(listView_Caclankhambenh.SelectedItems[0].SubItems[0].Text);
                com.CommandText = "select * from phieukhambenh where phieukhambenh.id=" + listView_Caclankhambenh.SelectedItems[0].SubItems[0].Text; 
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                   comboBox_Doituong.Text= read[1].ToString();
                    textBox_NoiDKKCBBD.Text= read[2].ToString();
                   dateTimePicker_Tu.Value=DateTime.Parse(read[3].ToString());
                    dateTimePicker_Den.Value= DateTime.Parse(read[4].ToString());
                    textBox_Sothe.Text = read[5].ToString();
                    textBox_Nguoithan.Text = read[6].ToString();
                    textBox_Diachinguoithan.Text = read[7].ToString();
                    textBox_Dienthoai.Text = read[8].ToString(); 
                    dateTimePicker_Ngaykham.Value = DateTime.Parse(read[9].ToString());
                    textBox_Noigioithieu.Text = read[10].ToString();
                    textBox_Lydovaovien.Text = read[11].ToString();
                    textBox_Tiensubenhbanthan.Text = read[12].ToString();
                    textBox_tiensubenhgiadinh.Text = read[13].ToString();
                    textBox_Mach.Text = read[14].ToString();
                    textBox_Nhiet.Text = read[15].ToString();
                    textBox_Huyetap.Text = read[16].ToString();
                    textBox_Nhiptho.Text = read[17].ToString();
                    textBox_Trongluong.Text = read[18].ToString();
                    richText_Toanthan.Text = read[19].ToString();
                    richTextBox_Cacbophan.Text = read[20].ToString();
                    richTextBox_Tomtat.Text = read[21].ToString();
                    textBox_Benhkemtheo.Text = read[22].ToString();
                    textBox_Dieutritaikhoa.Text = read[23].ToString();
                    textBox_Chuy.Text = read[24].ToString();
                        
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

        private void textBox_idICD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.Parse(e.KeyChar.ToString().ToUpper());
        }

       

        private void textBox_idIDCchinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void textBox_Benhchinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Benhkemtheo_TextChanged(object sender, EventArgs e)
        {

        }

      



      
    }
}

                 