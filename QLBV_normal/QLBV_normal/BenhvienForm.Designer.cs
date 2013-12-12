namespace QLBV_normal
{
    partial class BenhvienForm
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
            this.textBox_tenbenhvien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox_ghichu = new System.Windows.Forms.RichTextBox();
            this.button_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ghi chú";
            // 
            // textBox_tenbenhvien
            // 
            this.textBox_tenbenhvien.Location = new System.Drawing.Point(94, 6);
            this.textBox_tenbenhvien.Name = "textBox_tenbenhvien";
            this.textBox_tenbenhvien.Size = new System.Drawing.Size(164, 20);
            this.textBox_tenbenhvien.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên bệnh viện";
            // 
            // richTextBox_ghichu
            // 
            this.richTextBox_ghichu.Location = new System.Drawing.Point(94, 32);
            this.richTextBox_ghichu.Name = "richTextBox_ghichu";
            this.richTextBox_ghichu.Size = new System.Drawing.Size(164, 96);
            this.richTextBox_ghichu.TabIndex = 2;
            this.richTextBox_ghichu.Text = "";
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(94, 148);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 3;
            this.button_add.Text = "Tạo mới";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // BenhvienForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.richTextBox_ghichu);
            this.Controls.Add(this.textBox_tenbenhvien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BenhvienForm";
            this.Text = "Bệnh viện";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_tenbenhvien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox_ghichu;
        private System.Windows.Forms.Button button_add;
    }
}