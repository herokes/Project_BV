namespace QLBV_normal
{
    partial class ThuocForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_tenthuoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox_taduoc = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_hamluong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_duongdung = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_dang = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_soluong = new System.Windows.Forms.TextBox();
            this.button_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên thuốc";
            // 
            // textBox_tenthuoc
            // 
            this.textBox_tenthuoc.Location = new System.Drawing.Point(91, 52);
            this.textBox_tenthuoc.Name = "textBox_tenthuoc";
            this.textBox_tenthuoc.Size = new System.Drawing.Size(209, 20);
            this.textBox_tenthuoc.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tá dược";
            // 
            // richTextBox_taduoc
            // 
            this.richTextBox_taduoc.Location = new System.Drawing.Point(91, 87);
            this.richTextBox_taduoc.Name = "richTextBox_taduoc";
            this.richTextBox_taduoc.Size = new System.Drawing.Size(209, 85);
            this.richTextBox_taduoc.TabIndex = 2;
            this.richTextBox_taduoc.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hàm lượng";
            // 
            // textBox_hamluong
            // 
            this.textBox_hamluong.Location = new System.Drawing.Point(91, 189);
            this.textBox_hamluong.Name = "textBox_hamluong";
            this.textBox_hamluong.Size = new System.Drawing.Size(209, 20);
            this.textBox_hamluong.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Đường dùng";
            // 
            // comboBox_duongdung
            // 
            this.comboBox_duongdung.FormattingEnabled = true;
            this.comboBox_duongdung.Items.AddRange(new object[] {
            "Uống",
            "Dán",
            "Tiêm dưới da",
            "TB",
            "TM"});
            this.comboBox_duongdung.Location = new System.Drawing.Point(91, 219);
            this.comboBox_duongdung.Name = "comboBox_duongdung";
            this.comboBox_duongdung.Size = new System.Drawing.Size(209, 21);
            this.comboBox_duongdung.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Dạng";
            // 
            // comboBox_dang
            // 
            this.comboBox_dang.FormattingEnabled = true;
            this.comboBox_dang.Items.AddRange(new object[] {
            "Viên",
            "Lọ",
            "Ống",
            "Miếng"});
            this.comboBox_dang.Location = new System.Drawing.Point(91, 246);
            this.comboBox_dang.Name = "comboBox_dang";
            this.comboBox_dang.Size = new System.Drawing.Size(209, 21);
            this.comboBox_dang.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Số lượng";
            // 
            // textBox_soluong
            // 
            this.textBox_soluong.Location = new System.Drawing.Point(91, 273);
            this.textBox_soluong.Name = "textBox_soluong";
            this.textBox_soluong.Size = new System.Drawing.Size(209, 20);
            this.textBox_soluong.TabIndex = 1;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(148, 330);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 4;
            this.button_add.Text = "Tạo mới";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // ThuocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 391);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.comboBox_dang);
            this.Controls.Add(this.comboBox_duongdung);
            this.Controls.Add(this.richTextBox_taduoc);
            this.Controls.Add(this.textBox_hamluong);
            this.Controls.Add(this.textBox_soluong);
            this.Controls.Add(this.textBox_tenthuoc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ThuocForm";
            this.Text = "Thuốc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_tenthuoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox_taduoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_hamluong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_duongdung;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_dang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_soluong;
        private System.Windows.Forms.Button button_add;
    }
}