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
    public partial class PhieuxetnghiemForm : Form
    {
        public MainForm frmMain;
        public PhieuxetnghiemForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string groupName = "";
            textBox_benhnhan.Text = "13004582";
            listView_xetnghiem.Items.Clear();
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@id", MySqlDbType.Int32, 11).Value = textBox_benhnhan.Text.Trim();
                com.CommandText = @"SELECT xn_pxn.Thongsoxetnghiem, xn.* FROM xetnghiem_phieuxetnghiem xn_pxn  
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
                    ListViewItem item = new ListViewItem();
                    if (groupName.Equals(""))
                    {
                        groupName = read["Loaixetnghiem"].ToString();
                    }
                    if (!groupName.Equals(read["Loaixetnghiem"].ToString()))
                    {
                        ListViewGroup group = new ListViewGroup();
                        listView_xetnghiem.Groups.Add(group);
                        groupName = read["Loaixetnghiem"].ToString();
                        item.Group = group;
                    }
                    item.Text = read["Tenxetnghiem"].ToString();
                    item.SubItems.Add(read["Thongsobinhthuong"].ToString());
                    item.SubItems.Add(read["Thongsoxetnghiem"].ToString());
                    listView_xetnghiem.Items.Add(item);
                }
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }


    }
}
