namespace LELE
{
    partial class frmpreview
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
            this.ptrprev = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ptrprev.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ptrprev
            // 
            this.ptrprev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptrprev.Location = new System.Drawing.Point(0, 0);
            this.ptrprev.Name = "ptrprev";
            this.ptrprev.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.ptrprev.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.ptrprev.Properties.ZoomAccelerationFactor = 1D;
            this.ptrprev.Size = new System.Drawing.Size(534, 511);
            this.ptrprev.TabIndex = 0;
            // 
            // frmpreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 511);
            this.Controls.Add(this.ptrprev);
            this.Name = "frmpreview";
            this.Text = "Before Converted";
            this.Load += new System.EventHandler(this.frmpreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptrprev.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit ptrprev;
    }
}