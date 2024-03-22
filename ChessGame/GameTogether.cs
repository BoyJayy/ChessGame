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
                if (temp == true) side = "w";
                else side = "b";
            }
        }

        private class Figure
        {
            public int data;
            private int posX; private int posY;
            private char tag;
            private Image pic;
            private char col;
            private void setcol(char c)
            {
                col = c;
            }

            private void setData(int ddata)
            { data = ddata; }

            private void setPos(int pos_x, int pos_y)
            { posX = pos_x; posY = pos_y; }

            private void setPic(Image img)
            {
                pic = img;
            }
            public Figure(int tdata, int pos_x, int pos_y, char c)
            {
                setData(tdata);
                setPos(pos_x, pos_y);
                setcol(c);
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

        private Image chessSprites = new Bitmap(strCoreData + "\\pics\\chess.png");
        private Image kingW_img = new Bitmap(strCoreData + "\\pics\\kingW.png");
        private Image queenW_img = new Bitmap(strCoreData + "\\pics\\queenW.png");
        private Image rookW_img = new Bitmap(strCoreData + "\\pics\\rookW.png");
        private Image knightW_img = new Bitmap(strCoreData + "\\pics\\knightW.png");
        private Image bishopW_img = new Bitmap(strCoreData + "\\pics\\bishopW.png");
        private Image pawnW_img = new Bitmap(strCoreData + "\\pics\\pawnW.png");

        private Image kingB_img = new Bitmap(strCoreData + "\\pics\\kingB.png");
        private Image queenB_img = new Bitmap(strCoreData + "\\pics\\queenB.png");
        private Image rookB_img = new Bitmap(strCoreData + "\\pics\\rookB.png");
        private Image knightB_img = new Bitmap(strCoreData + "\\pics\\knightB.png");
        private Image bishopB_img = new Bitmap(strCoreData + "\\pics\\bishopB.png");
        private Image pawnB_img = new Bitmap(strCoreData + "\\pics\\pawnB.png");

        private Figure[] array_ofFigs = new Figure[0];

        private void getInfoFromStart()
        {
            //if (Program.ST.blackCheck.Checked == true && Program.ST.whiteCheck.Checked == false)
            //{
            //    Player first = new Player(true);
            //    Player second = new Player(false);
            //}
            //if (Program.ST.blackCheck.Checked == false && Program.ST.whiteCheck.Checked == true)
            //{
            //    Player first = new Player(false);            //    Player second = new Player(true);
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
                    //if else zapolneniye dlya proverki
                    if (i == 0 && j == 7) // WHITE start pos
                    {
                        g.DrawImage(rookW_img, chessBoard[i, j].rect.X + 10, chessBoard[i, j].rect.Y + 12);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(4, i, j, 'w');
                    }
                    if (j == 6)
                    {
                        g.DrawImage(pawnW_img, chessBoard[i, j].rect.X + 15, chessBoard[i, j].rect.Y + 12);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(1, i, j, 'w');
                    }
                    if (i == 1 && j == 7)
                    {
                        g.DrawImage(knightW_img, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 12);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(2, i, j, 'w');
                    }
                    if (i == 2 && j == 7)
                    {
                        g.DrawImage(bishopW_img, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 10);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(3, i, j, 'w');
                    }
                    if (i == 3 && j == 7)
                    {
                        g.DrawImage(queenW_img, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 8);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(5, i, j, 'w');
                    }
                    if (i == 4 && j == 7)
                    {
                        g.DrawImage(kingW_img, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 3);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(6, i, j, 'w');
                    }
                    if (i == 5 && j == 7)
                    {
                        g.DrawImage(bishopW_img, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 10);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(3, i, j, 'w');
                    }
                    if (i == 6 && j == 7)
                    {
                        g.DrawImage(knightW_img, chessBoard[i, j].rect.X + 6, chessBoard[i, j].rect.Y + 10);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(2, i, j, 'w');
                    }
                    if (i == 7 && j == 7)
                    {
                        g.DrawImage(rookW_img, chessBoard[i, j].rect.X + 10, chessBoard[i, j].rect.Y + 12);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(4, i, j, 'w');
                    }


                    if (i == 0 && j == 0) // BLACK start pos
                    {
                        g.DrawImage(rookB_img, chessBoard[i, j].rect.X + 10, chessBoard[i, j].rect.Y + 12);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(4, i, j, 'b');
                    }
                    if (j == 1)
                    {
                        g.DrawImage(pawnB_img, chessBoard[i, j].rect.X + 15, chessBoard[i, j].rect.Y + 12);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(1, i, j, 'b');
                    }
                    if (i == 1 && j == 0)
                    {
                        g.DrawImage(knightB_img, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 12);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(2, i, j, 'b');
                    }
                    if (i == 2 && j == 0)
                    {
                        g.DrawImage(bishopB_img, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 10);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(3, i, j, 'b');
                    }
                    if (i == 3 && j == 0)
                    {
                        g.DrawImage(queenB_img, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 8);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(5, i, j, 'b');
                    }
                    if (i == 4 && j == 0)
                    {
                        g.DrawImage(kingB_img, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 3);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(6, i, j, 'b');
                    }
                    if (i == 5 && j == 0)
                    {
                        g.DrawImage(bishopB_img, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 10);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(3, i, j, 'b');
                    }

                    if (i == 6 && j == 0)
                    {
                        g.DrawImage(knightB_img, chessBoard[i, j].rect.X + 6, chessBoard[i, j].rect.Y + 10);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(2, i, j, 'b');
                    }
                    if (i == 7 && j == 0)
                    {
                        g.DrawImage(rookB_img, chessBoard[i, j].rect.X + 10, chessBoard[i, j].rect.Y + 12);
                        System.Array.Resize(ref array_ofFigs, array_ofFigs.Length + 1);
                        array_ofFigs[array_ofFigs.Length - 1] = new Figure(4, i, j, 'b');
                    }
                    //if (chessBoard[i, j].isFugure == true)
                    //{
                    //    if (j == 1)
                    //    {
                    //        pawn[i] = new Figure(1, i, j, 'b');
                    //    }
                    //}
                }
            }
        }

        private Color defCol;
        private bool isClicked = false;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            g = Application.OpenForms[0].CreateGraphics();
            if (!isClicked) // если не нажато ни разу
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
            else // есть клик по полю
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