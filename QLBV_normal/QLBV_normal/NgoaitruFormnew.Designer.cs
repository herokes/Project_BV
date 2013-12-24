namespace QLBV_normal
{
    partial class NgoaitruFormnew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView_danhsachbenhnhan = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.radioButton_dieutri = new System.Windows.Forms.RadioButton();
            this.radioButton_xuatvien = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView_danhsachbenhnhan
            // 
            this.listView_danhsachbenhnhan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView_danhsachbenhnhan.GridLines = true;
            this.listView_danhsachbenhnhan.Location = new System.Drawing.Point(7, 54);
            this.listView_danhsachbenhnhan.Name = "listView_danhsachbenhnhan";
            this.listView_danhsachbenhnhan.Size = new System.Drawing.Size(196, 400);
            this.listView_danhsachbenhnhan.TabIndex = 0;
            this.listView_danhsachbenhnhan.UseCompatibleStateImageBehavior = false;
            this.listView_danhsachbenhnhan.View = System.Windows.Forms.View.Details;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(222, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 71);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hành chính";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(222, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 293);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(506, 255);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(498, 229);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Diễn biến bệnh";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(498, 229);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Xét nghiệm";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Danh sách bệnh nhân";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã BN";
            this.columnHeader1.Width = 69;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên bệnh nhân";
            this.columnHeader2.Width = 125;
            // 
            // radioButton_dieutri
            // 
            this.radioButton_dieutri.AutoSize = true;
            this.radioButton_dieutri.Checked = true;
            this.radioButton_dieutri.Location = new System.Drawing.Point(13, 33);
            this.radioButton_dieutri.Name = "radioButton_dieutri";
            this.radioButton_dieutri.Size = new System.Drawing.Size(58, 17);
            this.radioButton_dieutri.TabIndex = 4;
            this.radioButton_dieutri.TabStop = true;
            this.radioButton_dieutri.Text = "Điều trị";
            this.radioButton_dieutri.UseVisualStyleBackColor = true;
            // 
            // radioButton_xuatvien
            // 
            this.radioButton_xuatvien.AutoSize = true;
            this.radioButton_xuatvien.Location = new System.Drawing.Point(105, 33);
            this.radioButton_xuatvien.Name = "radioButton_xuatvien";
            this.radioButton_xuatvien.Size = new System.Drawing.Size(70, 17);
            this.radioButton_xuatvien.TabIndex = 5;
            this.radioButton_xuatvien.Text = "Xuất viện";
            this.radioButton_xuatvien.UseVisualStyleBackColor = true;
            // 
            // NgoaitruFormnew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 420);
            this.Controls.Add(this.radioButton_xuatvien);
            this.Controls.Add(this.radioButton_dieutri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listView_danhsachbenhnhan);
            this.Name = "NgoaitruFormnew";
            this.Text = "NgoaitruFormnew";
            this.Load += new System.EventHandler(this.NgoaitruFormnew_Load);
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_danhsachbenhnhan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_dieutri;
        private System.Windows.Forms.RadioButton radioButton_xuatvien;
    }
}