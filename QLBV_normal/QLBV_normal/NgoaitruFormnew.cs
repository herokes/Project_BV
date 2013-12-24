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
    public partial class NgoaitruFormnew : Form
    {
        public MainForm frmMain;
        public NgoaitruFormnew()
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
                    sql = "select benhnhan.id, benhnhan.Ten from benhnhan,phieukhambenh,ngoaitru where benhnhan.id= phieukhambenh.Benhnhan_id and phieukhambenh.id= ngoaitru.Phieukhambenh_id and ngoaitru.Tinhtrangravien=0";
                }
                else
                    if(radioButton_xuatvien.Checked== true)
                    {
                        sql = "select benhnhan.id, benhnhan.Ten from benhnhan,phieukhambenh,ngoaitru where benhnhan.id= phieukhambenh.Benhnhan_id and phieukhambenh.id= ngoaitru.Phieukhambenh_id and ngoaitru.Tinhtrangravien!=0";
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
    }
}
