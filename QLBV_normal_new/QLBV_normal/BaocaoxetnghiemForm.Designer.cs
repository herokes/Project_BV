namespace QLBV_normal
{
    partial class BaocaoxetnghiemForm
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
            this.button_Baocao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Baocao
            // 
            this.button_Baocao.Location = new System.Drawing.Point(276, 84);
            this.button_Baocao.Name = "button_Baocao";
            this.button_Baocao.Size = new System.Drawing.Size(75, 23);
            this.button_Baocao.TabIndex = 0;
            this.button_Baocao.Text = "Báo cáo";
            this.button_Baocao.UseVisualStyleBackColor = true;
            this.button_Baocao.Click += new System.EventHandler(this.button_Baocao_Click);
            // 
            // BaocaoxetnghiemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 352);
            this.Controls.Add(this.button_Baocao);
            this.Name = "BaocaoxetnghiemForm";
            this.Text = "BaocaoxetnghiemForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Baocao;
    }
}