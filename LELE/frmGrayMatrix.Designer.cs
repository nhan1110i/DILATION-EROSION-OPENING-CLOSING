namespace LELE
{
    partial class frmGrayMatrix
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
            this.label2 = new System.Windows.Forms.Label();
            this.nubDoRong = new System.Windows.Forms.NumericUpDown();
            this.nubGiaTri = new System.Windows.Forms.NumericUpDown();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnShow = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.nubDoRong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nubGiaTri)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Banner", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhập độ rộng Ma trận";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Banner", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nhập giá trị phần tử";
            // 
            // nubDoRong
            // 
            this.nubDoRong.Location = new System.Drawing.Point(143, 9);
            this.nubDoRong.Name = "nubDoRong";
            this.nubDoRong.Size = new System.Drawing.Size(110, 21);
            this.nubDoRong.TabIndex = 4;
            // 
            // nubGiaTri
            // 
            this.nubGiaTri.Location = new System.Drawing.Point(143, 54);
            this.nubGiaTri.Name = "nubGiaTri";
            this.nubGiaTri.Size = new System.Drawing.Size(110, 21);
            this.nubGiaTri.TabIndex = 5;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Sitka Banner", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Location = new System.Drawing.Point(200, 92);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(52, 23);
            this.simpleButton3.TabIndex = 8;
            this.simpleButton3.Text = "Canel";
            // 
            // btnShow
            // 
            this.btnShow.Appearance.Font = new System.Drawing.Font("Sitka Banner", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Appearance.Options.UseFont = true;
            this.btnShow.Location = new System.Drawing.Point(132, 92);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(52, 23);
            this.btnShow.TabIndex = 7;
            this.btnShow.Text = "Show";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("Sitka Banner", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(64, 92);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(52, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmGrayMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 136);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nubGiaTri);
            this.Controls.Add(this.nubDoRong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGrayMatrix";
            this.Text = "GRAY";
            ((System.ComponentModel.ISupportInitialize)(this.nubDoRong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nubGiaTri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nubDoRong;
        private System.Windows.Forms.NumericUpDown nubGiaTri;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton btnShow;
        private DevExpress.XtraEditors.SimpleButton btnOK;

    }
}