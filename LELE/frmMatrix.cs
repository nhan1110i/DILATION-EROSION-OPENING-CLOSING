﻿using System;
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
    public partial class frmMatrix : DevExpress.XtraEditors.XtraForm
    {
        public frmMatrix()
        {
            InitializeComponent();
        }
        int doRong = 2;
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmMain.n = (int)nubDoRong.Value;
            doRong = (int)nubDoRong.Value;
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            doRong = (int)nubDoRong.Value;
            int[,] mt = new int[2 * doRong +1, 2* doRong +1];
            int i, j;
            for (i = 0; i < 2 * doRong + 1; i++) {
                for (j = 0; j < 2 * doRong + 1; j++) {
                    mt[i, j] = 0;
                }
            }
            for (i = 0; i < 2 * doRong + 1; i++) {
                mt[i, doRong] = 1;
                mt[doRong, i] = 1;
            }
            string mt2 = "";
            for (i = 0; i < 2 * doRong + 1; i++) {
                for (j = 0; j < 2 * doRong + 1; j++) {
                    mt2 = mt2 + mt[i, j].ToString() + " ";
                }
                mt2 = mt2 + "\n";
            }
            MessageBox.Show(mt2);
        }

        private void frmMatrix_Load(object sender, EventArgs e)
        {
        }
    }
}