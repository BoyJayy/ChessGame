using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private struct Board
        {
            public int data;
            public bool flag;
            public string s;
            public Label lbl;
            public Rectangle rect;
            public PictureBox pic;
        }
        private const int n = 8;
        private const int size = 70;
        private Board[,] chessBoard = new Board[n, n];
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        Pen blackPen = new Pen(Color.Black);
        Graphics g;
        private void fillBoard()
        {
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (i == 0 || i == 1 || i == 6 || i == 7) chessBoard[i, j].flag = true;
                    else chessBoard[i, j].flag = false;
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = Application.OpenForms[0].CreateGraphics();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    chessBoard[i, j].rect = new Rectangle(i * size, j * size, size, size);
                    Brush col = (i + j) % 2 != 0 ? Brushes.Green : Brushes.Azure;
                    g.FillRectangle(col, chessBoard[i, j].rect);
                    g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                }
            }
        }
    }
}
