﻿using System;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            Program.ST = this;
        }

        private void Start_Load(object sender, EventArgs e)
        {
            //var f = new Game();
            //if (f.ShowDialog(this) == DialogResult.OK)
            //{
            //    f.Dispose();
            //}
            //else Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameTogether gmt = new GameTogether();
            gmt.Show();
        }
    }
}