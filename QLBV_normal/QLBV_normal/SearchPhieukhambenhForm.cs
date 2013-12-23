using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QLBV_normal.Class;
using System.Collections;

namespace QLBV_normal
{
    public partial class SearchPhieukhambenhForm : Form
    {
        public MainForm frmMain;

        public SearchPhieukhambenhForm()
        {
            InitializeComponent();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            listView_searchresult.Items.Clear();
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.AddWithValue("@id", "%" + textBox_filter.Text.Trim() + "%");
                com.CommandText = "SELECT pkb.id, bn.ten, bn.gioitinh, bn.CMND, pkb.Nguoithan, pkb.Dienthoai FROM phieukhambenh pkb LEFT OUTER JOIN benhnhan bn ON pkb.Benhnhan_id=bn.id WHERE pkb.id LIKE @id";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    int i = listView_searchresult.Items.Count;
                    listView_searchresult.Items.Add(read["id"].ToString());
                    listView_searchresult.Items[i].SubItems.Add(read["ten"].ToString());
                    listView_searchresult.Items[i].SubItems.Add(read["gioitinh"].ToString());
                    listView_searchresult.Items[i].SubItems.Add(read["CMND"].ToString());
                    listView_searchresult.Items[i].SubItems.Add(read["Nguoithan"].ToString());
                    listView_searchresult.Items[i].SubItems.Add(read["Dienthoai"].ToString());
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }

        private void button_choose_Click(object sender, EventArgs e)
        {
            if (listView_searchresult.SelectedItems.Count > 0)
            {
                this.frmMain.frmNgoaitru.textBox_phieukhambenh.Text = listView_searchresult.SelectedItems[0].SubItems[0].Text;
                this.Close();
            }
        }

        private void button_print_Click(object sender, EventArgs e)
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
                com.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = int.Parse(listView_searchresult.SelectedItems[0].SubItems[0].Text);
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

    }
}
