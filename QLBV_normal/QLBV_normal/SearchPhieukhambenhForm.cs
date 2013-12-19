using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
                com.CommandText = "SELECT pkb.idPhieukhambenh, bn.ten, bn.gioitinh, bn.CMND, bn.Nguoithan, bn.Dienthoai FROM phieukhambenh pkb LEFT OUTER JOIN benhnhan bn ON pkb.Benhnhan_idBenhnhan=bn.idBenhnhan WHERE pkb.idPhieukhambenh LIKE @id";
                Util.con.Open();
                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    int i = listView_searchresult.Items.Count;
                    listView_searchresult.Items.Add(read["idPhieukhambenh"].ToString());
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

    }
}
