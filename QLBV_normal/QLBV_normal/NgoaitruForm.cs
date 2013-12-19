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
    public partial class NgoaitruForm : Form
    {
        public MainForm frmMain;

        public NgoaitruForm()
        {
            InitializeComponent();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.Connection = Util.con;
                com.Parameters.Add("@ngaygiovaovien", MySqlDbType.DateTime).Value = dateTimePicker_ngaygiovaovien.Value;
                com.Parameters.Add("@benhchinh", MySqlDbType.VarChar, 200).Value = richTextBox_benhchinh.Text.Trim();
                com.Parameters.Add("@benhkemtheo", MySqlDbType.VarChar, 45).Value = textBox_benhkemtheo.Text.Trim();
                com.Parameters.Add("@dieutritu", MySqlDbType.DateTime).Value = dateTimePicker_dieutritu.Value;
                com.Parameters.Add("@dieutriden", MySqlDbType.DateTime).Value = dateTimePicker_dieutriden.Value;
                com.Parameters.Add("@tinhtrangravien", MySqlDbType.VarChar, 45).Value = textBox_tinhtrangravien.Text.Trim();
                com.Parameters.Add("@huongdieutri", MySqlDbType.VarChar, 45).Value = textBox_huongdieutri.Text.Trim();
                com.Parameters.Add("@bacsikhambenh", MySqlDbType.VarChar, 45).Value = textBox_bacsikhambenh.Text.Trim();
                com.Parameters.Add("@bacsidieutri", MySqlDbType.VarChar, 45).Value = textBox_bacsidieutri.Text.Trim();
                com.Parameters.Add("@chaythan", MySqlDbType.Int16, 1).Value = (int)comboBox_chaythan.SelectedValue;
                com.Parameters.Add("@phieukhambenh", MySqlDbType.Int32, 11).Value = int.Parse(textBox_phieukhambenh.Text);
                com.CommandText = "INSERT INTO ngoaitru(ngaygiovaovien, benhchinh, benhkemtheo, dieutritu, dieutriden, tinhtrangravien, huongdieutri, bacsikhambenh, bacsidieutri, chaythan, Phieukhambenh_idPhieukhambenh) values(@ngaygiovaovien, @benhchinh, @benhkemtheo, @dieutritu, @dieutriden, @tinhtrangravien, @huongdieutri, @bacsikhambenh, @bacsidieutri, @chaythan, @phieukhambenh)";
                Util.con.Open();
                com.ExecuteNonQuery();
                Util.con.Close();
            }
            catch (MySqlException sqlE)
            {
                return;
            }
        }

        private void NgoaitruForm_Load(object sender, EventArgs e)
        {
            comboBox_chaythan.DisplayMember = "Text";
            comboBox_chaythan.ValueMember = "Value";
            comboBox_chaythan.DataSource = new[] { 
                new { Text = "Không", Value = 0 }, 
                new { Text = "Có", Value = 1 }
            };
        }

        private void button_choosePhieukhambenh_Click(object sender, EventArgs e)
        {
            if (frmMain.frmSearchPhieukhambenh == null || frmMain.frmSearchPhieukhambenh.IsDisposed)
            {
                frmMain.frmSearchPhieukhambenh = new SearchPhieukhambenhForm();
                frmMain.frmSearchPhieukhambenh.frmMain = this.frmMain;
                frmMain.frmSearchPhieukhambenh.MdiParent = this.frmMain;
                frmMain.frmSearchPhieukhambenh.textBox_filter.Text = textBox_phieukhambenh.Text;
                frmMain.frmSearchPhieukhambenh.Show();
            }
            else
            {
                frmMain.frmSearchPhieukhambenh.Focus();
            }
        }

    }
}
