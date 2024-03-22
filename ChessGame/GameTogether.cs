using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class GameTogether : Form
    {
        public GameTogether()
        {
            InitializeComponent();
            getInfoFromStart();
        }

        private class Player
        {
            public bool temp; //если 1, то белые, иначе черные;
            public string side;
            public bool flag;
            public Player(bool d)
            {
                setSide(d);
            }

            private void setSide(bool n)
            {
                temp = n;
                if (temp == true) side = "W";
                else side = "B";
            }
        }

        private class Figure
        {
            public int data;
            private int posX; private int posY;
            private char tag;

            private void setData(int ddata)
            { data = ddata; }

            private void setPos(int pos_x, int pos_y)
            { posX = pos_x; posY = pos_y; }

            private Figure(int tdata, int pos_x, int pos_y)
            {
                setData(tdata);
                setPos(pos_x, pos_y);
                if (data == 1) tag = 'p';
                if (data == 2) tag = 'k';
                if (data == 3) tag = 'b';
                if (data == 4) tag = 'r';
                if (data == 5) tag = 'q';
                if (data == 6) tag = 'K';
            }
        }

        private struct Board
        {
            public int counter;
            public bool flag;
            public bool isFugure;
            public string s;
            public Label lbl;
            public Rectangle rect;
            public Color color;
            public Figure fig;
            public PictureBox pic;

            public static Board operator ++(Board r1) //peregruz
            {
                r1.counter++;
                return r1;
            }
        }

        private const int n = 8;
        private const int size = 70;
        private Board[,] chessBoard = new Board[n, n];
        private SolidBrush whiteBrush = new SolidBrush(Color.White);
        private SolidBrush blackBrush = new SolidBrush(Color.Black);
        private SolidBrush lightYellowBrush = new SolidBrush(Color.LightYellow);
        private Pen blackPen = new Pen(Color.Black);
        private Graphics g;
        private Bitmap bmp;
        private static int found = Application.StartupPath.IndexOf("\\bin\\Debug");
        private static string strCoreData = Application.StartupPath.Substring(0, found);
        private Image chessSprites = new Bitmap(strCoreData + "\\chess.png");
        private Image kingW_img = new Bitmap(strCoreData + "\\kingW.png");

        private void getInfoFromStart()
        {
            //if (Program.ST.blackCheck.Checked == true && Program.ST.whiteCheck.Checked == false)
            //{
            //    Player first = new Player(true);
            //    Player second = new Player(false);
            //}
            //if (Program.ST.blackCheck.Checked == false && Program.ST.whiteCheck.Checked == true)
            //{
            //    Player first = new Player(false);
            //    Player second = new Player(true);
            //}
            //if (Program.ST.blackCheck.Checked == true && Program.ST.whiteCheck.Checked == true)
            //{
            //    Player first = new Player(true);
            //    Player second = new Player(false);
            //}
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = Application.OpenForms[0].CreateGraphics();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == 0 || j == 1 || j == 6 || j == 7) chessBoard[i, j].isFugure = true;
                    else chessBoard[i, j].isFugure = false;
                    chessBoard[i, j].rect = new Rectangle(i * size + 20 + 10, j * size + 20, size, size);
                    Brush col = (i + j) % 2 != 0 ? Brushes.DarkOliveGreen : Brushes.Wheat;
                    g.FillRectangle(col, chessBoard[i, j].rect);
                    g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                    chessBoard[i, j].pic = new PictureBox();
                    chessBoard[i, j].pic.Location = new Point(chessBoard[i, j].rect.X, chessBoard[i, j].rect.Y);
                    Controls.Add(chessBoard[i, j].pic);
                    chessBoard[i, j].pic.Image = kingW_img;
                }
            }
        }

        private Color defCol;
        private bool isClicked = false;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isClicked)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (chessBoard[i, j].flag == false && (e.Y >= chessBoard[i, j].rect.Location.Y + 1) &&
                        (e.Y <= (chessBoard[i, j].rect.Location.Y + size)) &&
                        (e.X >= chessBoard[i, j].rect.Location.X + 1) &&
                        (e.X <= (chessBoard[i, j].rect.Location.X + size)) && chessBoard[i, j].isFugure == true)
                        {
                            string s = Application.StartupPath;
                            int found = s.IndexOf("\\bin\\Debug");
                            MessageBox.Show(s.Substring(0, found));
                            defCol = chessBoard[i, j].color;
                            g.FillRectangle(lightYellowBrush, chessBoard[i, j].rect);
                            g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                            chessBoard[i, j].color = Color.LightYellow;
                            chessBoard[i, j].flag = true;
                            isClicked = true;
                            break;
                        }
                        if (chessBoard[i, j].flag == true && (e.Y >= chessBoard[i, j].rect.Location.Y + 1) &&
                        (e.Y <= (chessBoard[i, j].rect.Location.Y + size)) &&
                        (e.X >= chessBoard[i, j].rect.Location.X + 1) &&
                        (e.X <= (chessBoard[i, j].rect.Location.X + size)) && chessBoard[i, j].isFugure == true)
                        {
                            Brush col = (i + j) % 2 != 0 ? Brushes.DarkOliveGreen : Brushes.Wheat;
                            g.FillRectangle(col, chessBoard[i, j].rect);
                            g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                            chessBoard[i, j].flag = false;
                            isClicked = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (chessBoard[i, j].flag == true)
                        {
                            Brush col = (i + j) % 2 != 0 ? Brushes.DarkOliveGreen : Brushes.Wheat;
                            g.FillRectangle(col, chessBoard[i, j].rect);
                            g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                            chessBoard[i, j].flag = false;
                            isClicked = false;
                            for (int k = 0; k < n; k++)
                            {
                                for (int m = 0; m < n; m++)
                                {
                                    if ((e.Y >= chessBoard[k, m].rect.Location.Y + 1) &&
                                    (e.Y <= (chessBoard[k, m].rect.Location.Y + size)) &&
                                    (e.X >= chessBoard[k, m].rect.Location.X + 1) &&
                                    (e.X <= (chessBoard[k, m].rect.Location.X + size)) && chessBoard[k, m].isFugure == false)
                                    {
                                        chessBoard[i, j].isFugure = false;
                                        isClicked = false;
                                        chessBoard[k, m].isFugure = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}