﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GotCompanion
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

        }

        private void btn_PlayGame_Click(object sender, EventArgs e)
        {
            frmGame gameForm = new frmGame(0);
            gameForm.Show();
            this.Close();
        }
    }
}
