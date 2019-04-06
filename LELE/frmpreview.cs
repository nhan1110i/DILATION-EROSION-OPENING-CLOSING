using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace LELE
{
    public partial class frmpreview : DevExpress.XtraEditors.XtraForm
    {
        public frmpreview()
        {
            InitializeComponent();
        }

        private void frmpreview_Load(object sender, EventArgs e)
        {
            if (frmMain.preview != null) {
                ptrprev.Image = frmMain.preview;
                this.Text = "NewNew";
            }
        }
    }
}