namespace QLBV_normal
{
    partial class SearchPhieukhambenhForm
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
            this.listView_searchresult = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox_filter = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.button_choose = new System.Windows.Forms.Button();
            this.button_print = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView_searchresult
            // 
            this.listView_searchresult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView_searchresult.FullRowSelect = true;
            this.listView_searchresult.GridLines = true;
            this.listView_searchresult.HideSelection = false;
            this.listView_searchresult.Location = new System.Drawing.Point(12, 74);
            this.listView_searchresult.Name = "listView_searchresult";
            this.listView_searchresult.ShowItemToolTips = true;
            this.listView_searchresult.Size = new System.Drawing.Size(742, 269);
            this.listView_searchresult.TabIndex = 0;
            this.listView_searchresult.UseCompatibleStateImageBehavior = false;
            this.listView_searchresult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã phiếu";
            this.columnHeader1.Width = 84;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Bệnh nhân";
            this.columnHeader2.Width = 191;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giới tính";
            this.columnHeader3.Width = 54;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "CMND";
            this.columnHeader4.Width = 96;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Người thân";
            this.columnHeader5.Width = 187;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Điện thoại";
            this.columnHeader6.Width = 93;
            // 
            // textBox_filter
            // 
            this.textBox_filter.Location = new System.Drawing.Point(12, 31);
            this.textBox_filter.Name = "textBox_filter";
            this.textBox_filter.Size = new System.Drawing.Size(247, 20);
            this.textBox_filter.TabIndex = 1;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(265, 29);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(66, 23);
            this.button_search.TabIndex = 2;
            this.button_search.Text = "Tìm";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // button_choose
            // 
            this.button_choose.Location = new System.Drawing.Point(12, 363);
            this.button_choose.Name = "button_choose";
            this.button_choose.Size = new System.Drawing.Size(75, 23);
            this.button_choose.TabIndex = 3;
            this.button_choose.Text = "Chọn";
            this.button_choose.UseVisualStyleBackColor = true;
            this.button_choose.Click += new System.EventHandler(this.button_choose_Click);
            // 
            // button_print
            // 
            this.button_print.Location = new System.Drawing.Point(125, 363);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(121, 23);
            this.button_print.TabIndex = 4;
            this.button_print.Text = "In phiếu khám bệnh";
            this.button_print.UseVisualStyleBackColor = true;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // SearchPhieukhambenhForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 398);
            this.Controls.Add(this.button_print);
            this.Controls.Add(this.button_choose);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_filter);
            this.Controls.Add(this.listView_searchresult);
            this.Name = "SearchPhieukhambenhForm";
            this.Text = "Tìm phiếu khám bệnh";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_searchresult;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button button_choose;
        public System.Windows.Forms.TextBox textBox_filter;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button button_print;
    }
}