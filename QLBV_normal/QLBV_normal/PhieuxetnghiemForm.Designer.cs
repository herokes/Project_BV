namespace QLBV_normal
{
    partial class PhieuxetnghiemForm
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
            this.listView_xetnghiem = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_benhnhan = new System.Windows.Forms.TextBox();
            this.button_print = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView_xetnghiem
            // 
            this.listView_xetnghiem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_xetnghiem.FullRowSelect = true;
            this.listView_xetnghiem.GridLines = true;
            this.listView_xetnghiem.Location = new System.Drawing.Point(12, 83);
            this.listView_xetnghiem.Name = "listView_xetnghiem";
            this.listView_xetnghiem.Size = new System.Drawing.Size(397, 279);
            this.listView_xetnghiem.TabIndex = 0;
            this.listView_xetnghiem.UseCompatibleStateImageBehavior = false;
            this.listView_xetnghiem.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Xét nghiệm";
            this.columnHeader1.Width = 145;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Trị số bình thường";
            this.columnHeader2.Width = 104;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Kết quả";
            this.columnHeader3.Width = 121;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "Tìm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_benhnhan
            // 
            this.textBox_benhnhan.Location = new System.Drawing.Point(12, 57);
            this.textBox_benhnhan.Name = "textBox_benhnhan";
            this.textBox_benhnhan.Size = new System.Drawing.Size(146, 20);
            this.textBox_benhnhan.TabIndex = 2;
            // 
            // button_print
            // 
            this.button_print.Location = new System.Drawing.Point(294, 56);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(115, 23);
            this.button_print.TabIndex = 3;
            this.button_print.Text = "In phiếu xét nghiệm";
            this.button_print.UseVisualStyleBackColor = true;
            // 
            // PhieuxetnghiemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 374);
            this.Controls.Add(this.button_print);
            this.Controls.Add(this.textBox_benhnhan);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView_xetnghiem);
            this.Name = "PhieuxetnghiemForm";
            this.Text = "PhieuxetnghiemForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_xetnghiem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_benhnhan;
        private System.Windows.Forms.Button button_print;
    }
}