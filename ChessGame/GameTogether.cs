using System;
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

        public Player p1;
        private const int n = 8;
        private const int size = 70;

        private Board[,] chessBoard = new Board[n, n];

        private SolidBrush whiteBrush = new SolidBrush(Color.White);
        private SolidBrush blackBrush = new SolidBrush(Color.Black);
        private SolidBrush lightYellowBrush = new SolidBrush(Color.LightYellow);
        private Pen blackPen = new Pen(Color.Black);

        private Graphics g;
        private Bitmap bmp;

        private bool checkW = false;
        private bool checkB = false;
        private bool mateW = false;
        private bool mateB = false;

        //private static int found = Application.StartupPath.IndexOf("\\bin\\Debug");
        //private static string strCoreData = Application.StartupPath.Substring(0, found);

        //private Image chessSprites = new Bitmap(strCoreData + "\\pics\\chess.png");
        //private Image kingW_img = new Bitmap(strCoreData + "\\pics\\kingW.png");
        //private Image queenW_img = new Bitmap(strCoreData + "\\pics\\queenW.png");
        //private Image rookW_img = new Bitmap(strCoreData + "\\pics\\rookW.png");
        //private Image knightW_img = new Bitmap(strCoreData + "\\pics\\knightW.png");
        //private Image bishopW_img = new Bitmap(strCoreData + "\\pics\\bishopW.png");
        //private Image pawnW_img = new Bitmap(strCoreData + "\\pics\\pawnW.png");

        //private Image kingB_img = new Bitmap(strCoreData + "\\pics\\kingB.png");
        //private Image queenB_img = new Bitmap(strCoreData + "\\pics\\queenB.png");
        //private Image rookB_img = new Bitmap(strCoreData + "\\pics\\rookB.png");
        //private Image knightB_img = new Bitmap(strCoreData + "\\pics\\knightB.png");
        //private Image bishopB_img = new Bitmap(strCoreData + "\\pics\\bishopB.png");
        //private Image pawnB_img = new Bitmap(strCoreData + "\\pics\\pawnB.png");

        private System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        public static bool moveTurn = true;

        //private static Player Main = new Player(Program.ST.whiteCheck.Checked);

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
            g = ActiveForm.CreateGraphics();
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
                    if (i == 0 && j == 7) // WHITE start pos
                    {
                        g.DrawImage(Properties.Resources.rookW, chessBoard[i, j].rect.X + 10, chessBoard[i, j].rect.Y + 12);
                        chessBoard[i, j].fig = new Figure(4, i, j, 'w');
                    }
                    if (j == 6)
                    {
                        g.DrawImage(Properties.Resources.pawnW, chessBoard[i, j].rect.X + 15, chessBoard[i, j].rect.Y + 12);
                        chessBoard[i, j].fig = new Figure(1, i, j, 'w');
                    }
                    if (i == 1 && j == 7)
                    {
                        g.DrawImage(Properties.Resources.knightW, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 12);
                        chessBoard[i, j].fig = new Figure(2, i, j, 'w');
                    }
                    if (i == 2 && j == 7)
                    {
                        g.DrawImage(Properties.Resources.bishopW, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 10);
                        chessBoard[i, j].fig = new Figure(3, i, j, 'w');
                    }
                    if (i == 3 && j == 7)
                    {
                        g.DrawImage(Properties.Resources.queenW, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 8);
                        chessBoard[i, j].fig = new Figure(5, i, j, 'w');
                    }
                    if (i == 4 && j == 7)
                    {
                        g.DrawImage(Properties.Resources.kingW, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 3);
                        chessBoard[i, j].fig = new Figure(6, i, j, 'w');
                    }
                    if (i == 5 && j == 7)
                    {
                        g.DrawImage(Properties.Resources.bishopW, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 10);
                        chessBoard[i, j].fig = new Figure(3, i, j, 'w');
                    }
                    if (i == 6 && j == 7)
                    {
                        g.DrawImage(Properties.Resources.knightW, chessBoard[i, j].rect.X + 6, chessBoard[i, j].rect.Y + 10);
                        chessBoard[i, j].fig = new Figure(2, i, j, 'w');
                    }
                    if (i == 7 && j == 7)
                    {
                        g.DrawImage(Properties.Resources.rookW, chessBoard[i, j].rect.X + 10, chessBoard[i, j].rect.Y + 12);
                        chessBoard[i, j].fig = new Figure(4, i, j, 'w');
                    }

                    if (i == 0 && j == 0) // BLACK start pos
                    {
                        g.DrawImage(Properties.Resources.rookB, chessBoard[i, j].rect.X + 10, chessBoard[i, j].rect.Y + 12);
                        chessBoard[i, j].fig = new Figure(4, i, j, 'b');
                    }
                    if (j == 1)
                    {
                        g.DrawImage(Properties.Resources.pawnB, chessBoard[i, j].rect.X + 15, chessBoard[i, j].rect.Y + 12);
                        chessBoard[i, j].fig = new Figure(1, i, j, 'b');
                    }
                    if (i == 1 && j == 0)
                    {
                        g.DrawImage(Properties.Resources.knightB, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 12);
                        chessBoard[i, j].fig = new Figure(2, i, j, 'b');
                    }
                    if (i == 2 && j == 0)
                    {
                        g.DrawImage(Properties.Resources.bishopB, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 10);
                        chessBoard[i, j].fig = new Figure(3, i, j, 'b');
                    }
                    if (i == 3 && j == 0)
                    {
                        g.DrawImage(Properties.Resources.queenB, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 8);
                        chessBoard[i, j].fig = new Figure(5, i, j, 'b');
                    }
                    if (i == 4 && j == 0)
                    {
                        g.DrawImage(Properties.Resources.kingB, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 3);
                        chessBoard[i, j].fig = new Figure(6, i, j, 'b');
                    }
                    if (i == 5 && j == 0)
                    {
                        g.DrawImage(Properties.Resources.bishopB, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 10);
                        chessBoard[i, j].fig = new Figure(3, i, j, 'b');
                    }
                    if (i == 6 && j == 0)
                    {
                        g.DrawImage(Properties.Resources.knightB, chessBoard[i, j].rect.X + 6, chessBoard[i, j].rect.Y + 10);
                        chessBoard[i, j].fig = new Figure(2, i, j, 'b');
                    }
                    if (i == 7 && j == 0)
                    {
                        g.DrawImage(Properties.Resources.rookB, chessBoard[i, j].rect.X + 10, chessBoard[i, j].rect.Y + 12);
                        chessBoard[i, j].fig = new Figure(4, i, j, 'b');
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
        private Graphics f;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            g = ActiveForm.CreateGraphics();
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
                            if (chessBoard[i, j].fig.data == 1 && chessBoard[i, j].fig.col == 'b') // BLACk
                            {
                                g.DrawImage(Properties.Resources.pawnB, chessBoard[i, j].rect.X + 15, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = true;
                                isClicked = true;
                            }
                            if (chessBoard[i, j].fig.data == 2 && chessBoard[i, j].fig.col == 'b')
                            {
                                g.DrawImage(Properties.Resources.knightB, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = true;
                                isClicked = true;
                            }
                            if (chessBoard[i, j].fig.data == 3 && chessBoard[i, j].fig.col == 'b')
                            {
                                g.DrawImage(Properties.Resources.bishopB, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 8);
                                chessBoard[i, j].flag = true;
                                isClicked = true;
                            }
                            if (chessBoard[i, j].fig.data == 4 && chessBoard[i, j].fig.col == 'b')
                            {
                                g.DrawImage(Properties.Resources.rookB, chessBoard[i, j].rect.X + 10, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = true;
                                isClicked = true;
                            }
                            if (chessBoard[i, j].fig.data == 5 && chessBoard[i, j].fig.col == 'b')
                            {
                                g.DrawImage(Properties.Resources.queenB, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 8);
                                chessBoard[i, j].flag = true;
                                isClicked = true;
                            }
                            if (chessBoard[i, j].fig.data == 6 && chessBoard[i, j].fig.col == 'b')
                            {
                                g.DrawImage(Properties.Resources.kingB, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 4);
                                chessBoard[i, j].flag = true;
                                isClicked = true;
                            }

                            if (chessBoard[i, j].fig.data == 1 && chessBoard[i, j].fig.col == 'w') // WHITE
                            {
                                g.DrawImage(Properties.Resources.pawnW, chessBoard[i, j].rect.X + 15, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = true;
                                isClicked = true;
                            }
                            if (chessBoard[i, j].fig.data == 2 && chessBoard[i, j].fig.col == 'w')
                            {
                                g.DrawImage(Properties.Resources.knightW, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = true;
                                isClicked = true;
                            }
                            if (chessBoard[i, j].fig.data == 3 && chessBoard[i, j].fig.col == 'w')
                            {
                                g.DrawImage(Properties.Resources.bishopW, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 8);
                                chessBoard[i, j].flag = true;
                                isClicked = true;
                            }
                            if (chessBoard[i, j].fig.data == 4 && chessBoard[i, j].fig.col == 'w')
                            {
                                g.DrawImage(Properties.Resources.rookW, chessBoard[i, j].rect.X + 10, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = true;
                                isClicked = true;
                            }
                            if (chessBoard[i, j].fig.data == 5 && chessBoard[i, j].fig.col == 'w')
                            {
                                g.DrawImage(Properties.Resources.queenW, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 8);
                                chessBoard[i, j].flag = true;
                                isClicked = true;
                            }
                            if (chessBoard[i, j].fig.data == 6 && chessBoard[i, j].fig.col == 'w')
                            {
                                g.DrawImage(Properties.Resources.kingW, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 4);
                                chessBoard[i, j].flag = true;
                                isClicked = true;
                            }
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
                            if (chessBoard[i, j].fig.data == 1 && chessBoard[i, j].fig.col == 'b') // BLACK
                            {
                                g.DrawImage(Properties.Resources.pawnB, chessBoard[i, j].rect.X + 15, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 2 && chessBoard[i, j].fig.col == 'b')
                            {
                                g.DrawImage(Properties.Resources.knightB, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 3 && chessBoard[i, j].fig.col == 'b')
                            {
                                g.DrawImage(Properties.Resources.bishopB, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 4 && chessBoard[i, j].fig.col == 'b')
                            {
                                g.DrawImage(Properties.Resources.rookB, chessBoard[i, j].rect.X + 10, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 5 && chessBoard[i, j].fig.col == 'b')
                            {
                                g.DrawImage(Properties.Resources.queenB, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 8);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 6 && chessBoard[i, j].fig.col == 'b')
                            {
                                g.DrawImage(Properties.Resources.kingB, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 4);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }

                            if (chessBoard[i, j].fig.data == 1 && chessBoard[i, j].fig.col == 'w') // WHITE
                            {
                                g.DrawImage(Properties.Resources.pawnW, chessBoard[i, j].rect.X + 15, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 2 && chessBoard[i, j].fig.col == 'w')
                            {
                                g.DrawImage(Properties.Resources.knightW, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 3 && chessBoard[i, j].fig.col == 'w')
                            {
                                g.DrawImage(Properties.Resources.bishopW, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 8);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 4 && chessBoard[i, j].fig.col == 'w')
                            {
                                g.DrawImage(Properties.Resources.rookW, chessBoard[i, j].rect.X + 10, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 5 && chessBoard[i, j].fig.col == 'w')
                            {
                                g.DrawImage(Properties.Resources.queenW, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 8);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 6 && chessBoard[i, j].fig.col == 'w')
                            {
                                g.DrawImage(Properties.Resources.kingW, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 4);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
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
                            Brush revcol = (i + j) % 2 != 0 ? Brushes.Wheat : Brushes.DarkOliveGreen;
                            g.FillRectangle(col, chessBoard[i, j].rect);
                            g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                            if (chessBoard[i, j].fig.data == 1 && chessBoard[i, j].fig.col == 'b') // BLACK
                            {
                                g.DrawImage(Properties.Resources.pawnB, chessBoard[i, j].rect.X + 15, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 2 && chessBoard[i, j].fig.col == 'b')
                            {
                                g.DrawImage(Properties.Resources.knightB, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 3 && chessBoard[i, j].fig.col == 'b')
                            {
                                g.DrawImage(Properties.Resources.bishopB, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 8);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 4 && chessBoard[i, j].fig.col == 'b')
                            {
                                g.DrawImage(Properties.Resources.rookB, chessBoard[i, j].rect.X + 10, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 5 && chessBoard[i, j].fig.col == 'b')
                            {
                                g.DrawImage(Properties.Resources.queenB, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 8);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 6 && chessBoard[i, j].fig.col == 'b')
                            {
                                g.DrawImage(Properties.Resources.kingB, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 4);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }

                            if (chessBoard[i, j].fig.data == 1 && chessBoard[i, j].fig.col == 'w') // WHITE
                            {
                                g.DrawImage(Properties.Resources.pawnW, chessBoard[i, j].rect.X + 15, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 2 && chessBoard[i, j].fig.col == 'w')
                            {
                                g.DrawImage(Properties.Resources.knightW, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 3 && chessBoard[i, j].fig.col == 'w')
                            {
                                g.DrawImage(Properties.Resources.bishopW, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 8);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 4 && chessBoard[i, j].fig.col == 'w')
                            {
                                g.DrawImage(Properties.Resources.rookW, chessBoard[i, j].rect.X + 10, chessBoard[i, j].rect.Y + 12);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 5 && chessBoard[i, j].fig.col == 'w')
                            {
                                g.DrawImage(Properties.Resources.queenW, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 8);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            if (chessBoard[i, j].fig.data == 6 && chessBoard[i, j].fig.col == 'w')
                            {
                                g.DrawImage(Properties.Resources.kingW, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 4);
                                chessBoard[i, j].flag = false;
                                isClicked = false;
                            }
                            for (int k = 0; k < n; k++)
                            {
                                for (int m = 0; m < n; m++)
                                {
                                    Brush col2 = (k + m) % 2 != 0 ? Brushes.DarkOliveGreen : Brushes.Wheat;
                                    if ((e.Y >= chessBoard[k, m].rect.Location.Y + 1) &&
                                    (e.Y <= (chessBoard[k, m].rect.Location.Y + size)) &&
                                    (e.X >= chessBoard[k, m].rect.Location.X + 1) &&
                                    (e.X <= (chessBoard[k, m].rect.Location.X + size)) /*&& chessBoard[k, m].isFugure == false*/)
                                    {
                                        if (chessBoard[i, j].fig.data == 1 && chessBoard[i, j].fig.col == 'b' && k - i == 0 && m - j > 0 && m - j <= 2 && chessBoard[i, j].fig.check_for_pawn == false)
                                        {
                                            bool f = true;
                                            for (int y = m; y > j; y--)
                                            {
                                                if (chessBoard[k, y].isFugure)
                                                {
                                                    f = false;
                                                }
                                            }
                                            if (f)
                                            {
                                                g.DrawImage(Properties.Resources.pawnB, chessBoard[k, m].rect.X + 15, chessBoard[k, m].rect.Y + 12);
                                                chessBoard[k, m].fig = new Figure(1, i, j, 'b');
                                                chessBoard[i, j].fig.resetAll();
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                //player.Play();
                                                chessBoard[i, j].isFugure = false;
                                                isClicked = false;
                                                chessBoard[k, m].isFugure = true;
                                                chessBoard[k, m].fig.check_for_pawn = true;
                                            }
                                            else
                                            {
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                g.DrawImage(Properties.Resources.pawnB, chessBoard[i, j].rect.X + 15, chessBoard[i, j].rect.Y + 12);
                                            }
                                        }
                                        if (chessBoard[i, j].fig.data == 1 && chessBoard[i, j].fig.col == 'b' && k - i == 0 && m - j > 0 && m - j <= 1 && chessBoard[i, j].fig.check_for_pawn == true)
                                        {
                                            bool f = true;
                                            for (int y = m; y > j; y--)
                                            {
                                                if (chessBoard[k, y].isFugure)
                                                {
                                                    f = false;
                                                }
                                            }
                                            if (f)
                                            {
                                                g.DrawImage(Properties.Resources.pawnB, chessBoard[k, m].rect.X + 15, chessBoard[k, m].rect.Y + 12);
                                                chessBoard[k, m].fig = new Figure(1, i, j, 'b');
                                                chessBoard[i, j].fig.resetAll();
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                //player.Play();
                                                chessBoard[i, j].isFugure = false;
                                                isClicked = false;
                                                chessBoard[k, m].isFugure = true;
                                                chessBoard[k, m].fig.check_for_pawn = true;
                                            }
                                            else
                                            {
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                g.DrawImage(Properties.Resources.pawnB, chessBoard[i, j].rect.X + 15, chessBoard[i, j].rect.Y + 12);
                                            }
                                        }

                                        if (chessBoard[i, j].fig.data == 1 && chessBoard[i, j].fig.col == 'b' && Math.Abs(k - i) == 1  && m - j == 1 && chessBoard[k, m].isFugure)
                                        {
                                            g.FillRectangle(col, chessBoard[k, m].rect);
                                            g.DrawRectangle(blackPen, chessBoard[k, m].rect);
                                            g.DrawImage(Properties.Resources.pawnB, chessBoard[k, m].rect.X + 15, chessBoard[k, m].rect.Y + 12);
                                            chessBoard[k, m].fig = new Figure(1, i, j, 'b');
                                            chessBoard[i, j].fig.resetAll();
                                            //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                            //player.Play();
                                            chessBoard[i, j].isFugure = false;
                                            isClicked = false;
                                            chessBoard[k, m].isFugure = true;
                                            chessBoard[k, m].fig.check_for_pawn = true;
                                            g.FillRectangle(col, chessBoard[i, j].rect);
                                            g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                        }



                                        if (chessBoard[i, j].fig.data == 2 && chessBoard[i, j].fig.col == 'b' &&
                                            ((k - i == 1 || k - i == -1) && (m - j == 2 || m - j == -2) ||
                                            (k - i == 2 || k - i == -2) && (m - j == 1 || m - j == -1)))
                                        {
                                            if (chessBoard[k, m].isFugure == true)
                                            {
                                                if (chessBoard[k, m].fig.col == 'w')
                                                {
                                                    chessBoard[k, m].fig.resetAll();
                                                    chessBoard[k, m].fig = new Figure(2, i, j, 'b');
                                                    g.FillRectangle(col2, chessBoard[k, m].rect);
                                                    g.DrawRectangle(blackPen, chessBoard[k, m].rect);
                                                    g.DrawImage(Properties.Resources.knightB, chessBoard[k, m].rect.X + 8, chessBoard[k, m].rect.Y + 12);
                                                    chessBoard[i, j].fig.resetAll();
                                                    g.FillRectangle(col, chessBoard[i, j].rect);
                                                    g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                    //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                    //player.Play();
                                                    chessBoard[i, j].isFugure = false;
                                                    isClicked = false;
                                                    chessBoard[k, m].isFugure = true;
                                                }
                                            }
                                            else
                                            {
                                                g.DrawImage(Properties.Resources.knightB, chessBoard[k, m].rect.X + 8, chessBoard[k, m].rect.Y + 12);
                                                chessBoard[k, m].fig = new Figure(2, i, j, 'b');
                                                chessBoard[i, j].fig.resetAll();
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                //player.Play();
                                                chessBoard[i, j].isFugure = false;
                                                isClicked = false;
                                                chessBoard[k, m].isFugure = true;
                                            }
                                        }
                                        if (chessBoard[i, j].fig.data == 3 && chessBoard[i, j].fig.col == 'b' && Math.Abs(k - i) == Math.Abs(m - j))
                                        {
                                            bool f = true;
                                            if (m > j && k > i)
                                            {
                                                for (int x = Math.Abs(m - j - 1); x > 0; x--)
                                                {
                                                    if (chessBoard[i + x, j + x].isFugure == true)
                                                        f = false;
                                                }
                                            }
                                            if (m > j && k < i)
                                            {
                                                for (int x = Math.Abs(m - j - 1); x > 0; x--)
                                                {
                                                    if (chessBoard[i - x, j + x].isFugure == true)
                                                        f = false;
                                                }
                                            }
                                            if (m < j && k > i)
                                            {
                                                for (int x = Math.Abs(m - j + 1); x > 0; x--)
                                                {
                                                    if (chessBoard[i + x, j - x].isFugure == true)
                                                        f = false;
                                                }
                                            }
                                            if (m < j && k < i)
                                            {
                                                for (int x = Math.Abs(m - j + 1); x > 0; x--)
                                                {
                                                    if (chessBoard[i - x, j - x].isFugure == true)
                                                        f = false;
                                                }
                                            }
                                            if (f)
                                            {
                                                if (chessBoard[k, m].isFugure == true)
                                                {
                                                    if (chessBoard[k, m].fig.col == 'w')
                                                    {
                                                        chessBoard[k, m].fig.resetAll();
                                                        chessBoard[k, m].fig = new Figure(3, i, j, 'b');
                                                        g.FillRectangle(col2, chessBoard[k, m].rect);
                                                        g.DrawRectangle(blackPen, chessBoard[k, m].rect);
                                                        g.DrawImage(Properties.Resources.bishopB, chessBoard[k, m].rect.X + 8, chessBoard[k, m].rect.Y + 8);
                                                        chessBoard[k, m].fig = new Figure(3, i, j, 'b');
                                                        chessBoard[i, j].fig.resetAll();
                                                        g.FillRectangle(col, chessBoard[i, j].rect);
                                                        g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                        //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                        //player.Play();
                                                        chessBoard[i, j].isFugure = false;
                                                        isClicked = false;
                                                        chessBoard[k, m].isFugure = true;
                                                    }
                                                }
                                                else
                                                {
                                                    g.DrawImage(Properties.Resources.bishopB, chessBoard[k, m].rect.X + 8, chessBoard[k, m].rect.Y + 8);
                                                    chessBoard[k, m].fig = new Figure(3, i, j, 'b');
                                                    chessBoard[i, j].fig.resetAll();
                                                    g.FillRectangle(col, chessBoard[i, j].rect);
                                                    g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                    //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                    //player.Play();
                                                    chessBoard[i, j].isFugure = false;
                                                    isClicked = false;
                                                    chessBoard[k, m].isFugure = true;
                                                }
                                            }
                                            else
                                            {
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                g.DrawImage(Properties.Resources.bishopB, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 8);
                                            }
                                        }
                                        if (chessBoard[i, j].fig.data == 4 && chessBoard[i, j].fig.col == 'b' && ((k == i && m != j) || (m == j && k != i)))
                                        {
                                            bool f = true;
                                            if (k == i && m != j && m > j)
                                            {
                                                for (int y = m - 1; y > j; y--)
                                                {
                                                    if (chessBoard[k, y].isFugure)
                                                    {
                                                        f = false;
                                                    }
                                                }
                                            }
                                            if (k == i && m != j && m > j)
                                            {
                                                for (int y = m + 1; y < j; y++)
                                                {
                                                    if (chessBoard[k, y].isFugure)
                                                    {
                                                        f = false;
                                                    }
                                                }
                                            }
                                            if (m == j && k != i && k > i)
                                            {
                                                for (int y = k - 1; y > i; y--)
                                                {
                                                    if (chessBoard[y, m].isFugure)
                                                    {
                                                        f = false;
                                                    }
                                                }
                                            }
                                            if (m == j && k != i && k < i)
                                            {
                                                for (int y = k + 1; y < i; y++)
                                                {
                                                    if (chessBoard[y, m].isFugure)
                                                    {
                                                        f = false;
                                                    }
                                                }
                                            }

                                            if (f)
                                            {
                                                if (chessBoard[k, m].isFugure == true)
                                                {
                                                    if (chessBoard[k, m].fig.col == 'w')
                                                    {
                                                        chessBoard[k, m].fig.resetAll();
                                                        chessBoard[k, m].fig = new Figure(4, i, j, 'b');
                                                        g.FillRectangle(col2, chessBoard[k, m].rect);
                                                        g.DrawRectangle(blackPen, chessBoard[k, m].rect);
                                                        g.DrawImage(Properties.Resources.rookB, chessBoard[k, m].rect.X + 10, chessBoard[k, m].rect.Y + 12);
                                                        chessBoard[k, m].fig = new Figure(4, i, j, 'b');
                                                        chessBoard[i, j].fig.resetAll();
                                                        g.FillRectangle(col, chessBoard[i, j].rect);
                                                        g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                        //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                        //player.Play();
                                                        chessBoard[i, j].isFugure = false;
                                                        isClicked = false;
                                                        chessBoard[k, m].isFugure = true;
                                                    }
                                                }
                                                else
                                                {
                                                    g.DrawImage(Properties.Resources.rookB, chessBoard[k, m].rect.X + 10, chessBoard[k, m].rect.Y + 12);
                                                    chessBoard[k, m].fig = new Figure(4, i, j, 'b');
                                                    chessBoard[i, j].fig.resetAll();
                                                    g.FillRectangle(col, chessBoard[i, j].rect);
                                                    g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                    //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                    //player.Play();
                                                    chessBoard[i, j].isFugure = false;
                                                    isClicked = false;
                                                    chessBoard[k, m].isFugure = true;
                                                }
                                            }
                                            else
                                            {
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                g.DrawImage(Properties.Resources.rookB, chessBoard[i, j].rect.X + 10, chessBoard[i, j].rect.Y + 12);
                                            }
                                        }
                                        if (chessBoard[i, j].fig.data == 5 && chessBoard[i, j].fig.col == 'b' && (((k == i && m != j) || (m == j && k != i)) || (Math.Abs(k - i) == Math.Abs(m - j))))
                                        {
                                            bool f = true;
                                            if (m > j && k > i)
                                            {
                                                for (int x = Math.Abs(m - j - 1); x > 0; x--)
                                                {
                                                    if (chessBoard[i + x, j + x].isFugure == true)
                                                        f = false;
                                                }
                                            }
                                            if (m > j && k < i)
                                            {
                                                for (int x = Math.Abs(m - j - 1); x > 0; x--)
                                                {
                                                    if (chessBoard[i - x, j + x].isFugure == true)
                                                        f = false;
                                                }
                                            }
                                            if (m < j && k > i)
                                            {
                                                for (int x = Math.Abs(m - j + 1); x > 0; x--)
                                                {
                                                    if (chessBoard[i + x, j - x].isFugure == true)
                                                        f = false;
                                                }
                                            }
                                            if (m < j && k < i)
                                            {
                                                for (int x = Math.Abs(m - j + 1); x > 0; x--)
                                                {
                                                    if (chessBoard[i - x, j - x].isFugure == true)
                                                        f = false;
                                                }
                                            }
                                            if (k == i && m != j && m > j)
                                            {
                                                for (int y = m - 1; y > j; y--)
                                                {
                                                    if (chessBoard[k, y].isFugure)
                                                    {
                                                        f = false;
                                                    }
                                                }
                                            }
                                            if (k == i && m != j && m > j)
                                            {
                                                for (int y = m + 1; y < j; y++)
                                                {
                                                    if (chessBoard[k, y].isFugure)
                                                    {
                                                        f = false;
                                                    }
                                                }
                                            }
                                            if (m == j && k != i && k > i)
                                            {
                                                for (int y = k - 1; y > i; y--)
                                                {
                                                    if (chessBoard[y, m].isFugure)
                                                    {
                                                        f = false;
                                                    }
                                                }
                                            }
                                            if (m == j && k != i && k < i)
                                            {
                                                for (int y = k + 1; y < i; y++)
                                                {
                                                    if (chessBoard[y, m].isFugure)
                                                    {
                                                        f = false;
                                                    }
                                                }
                                            }
                                            if (f)
                                            {
                                                if (chessBoard[k, m].isFugure == true)
                                                {
                                                    if (chessBoard[k, m].fig.col == 'w')
                                                    {
                                                        chessBoard[k, m].fig.resetAll();
                                                        chessBoard[k, m].fig = new Figure(5, i, j, 'b');
                                                        g.FillRectangle(col2, chessBoard[k, m].rect);
                                                        g.DrawRectangle(blackPen, chessBoard[k, m].rect);
                                                        g.DrawImage(Properties.Resources.queenB, chessBoard[k, m].rect.X + 5, chessBoard[k, m].rect.Y + 8);
                                                        chessBoard[i, j].fig.resetAll();
                                                        g.FillRectangle(col, chessBoard[i, j].rect);
                                                        g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                        //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                        //player.Play();
                                                        chessBoard[i, j].isFugure = false;
                                                        isClicked = false;
                                                        chessBoard[k, m].isFugure = true;
                                                    }
                                                }
                                                else
                                                {
                                                    g.DrawImage(Properties.Resources.queenB, chessBoard[k, m].rect.X + 5, chessBoard[k, m].rect.Y + 8);
                                                    chessBoard[k, m].fig = new Figure(5, i, j, 'b');
                                                    chessBoard[i, j].fig.resetAll();
                                                    g.FillRectangle(col, chessBoard[i, j].rect);
                                                    g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                    //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                    //player.Play();
                                                    chessBoard[i, j].isFugure = false;
                                                    isClicked = false;
                                                    chessBoard[k, m].isFugure = true;
                                                }
                                            }
                                            else
                                            {
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                g.DrawImage(Properties.Resources.queenB, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 8);
                                            }
                                        }
                                        if (chessBoard[i, j].fig.data == 6 && chessBoard[i, j].fig.col == 'b' && Math.Abs(k - i) <= 1 && Math.Abs(m - j) <= 1)
                                        {
                                            if (chessBoard[k, m].isFugure == true)
                                            {
                                                if (chessBoard[k, m].fig.col == 'w')
                                                {
                                                    chessBoard[k, m].fig.resetAll();
                                                    chessBoard[k, m].fig = new Figure(6, i, j, 'b');
                                                    g.FillRectangle(col2, chessBoard[k, m].rect);
                                                    g.DrawRectangle(blackPen, chessBoard[k, m].rect);
                                                    g.DrawImage(Properties.Resources.kingB, chessBoard[k, m].rect.X + 5, chessBoard[k, m].rect.Y + 4);
                                                    chessBoard[i, j].fig.resetAll();
                                                    g.FillRectangle(col, chessBoard[i, j].rect);
                                                    g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                    //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                    //player.Play();
                                                    chessBoard[i, j].isFugure = false;
                                                    isClicked = false;
                                                    chessBoard[k, m].isFugure = true;
                                                }
                                            }
                                            else
                                            {
                                                g.DrawImage(Properties.Resources.kingB, chessBoard[k, m].rect.X + 5, chessBoard[k, m].rect.Y + 4);
                                                chessBoard[k, m].fig = new Figure(6, i, j, 'b');
                                                chessBoard[i, j].fig.resetAll();
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                //player.Play();
                                                chessBoard[i, j].isFugure = false;
                                                isClicked = false;
                                                chessBoard[k, m].isFugure = true;
                                            }
                                        }

                                        if (chessBoard[i, j].fig.data == 1 && chessBoard[i, j].fig.col == 'w' && k - i == 0 && m - j < 0 && m - j >= -2 && chessBoard[i, j].fig.check_for_pawn == false) // WHITE
                                        {
                                            bool f = true;
                                            for (int y = m; y < j; y++)
                                            {
                                                if (chessBoard[k, y].isFugure)
                                                {
                                                    f = false;
                                                }
                                            }
                                            if (f)
                                            {
                                                g.DrawImage(Properties.Resources.pawnW, chessBoard[k, m].rect.X + 15, chessBoard[k, m].rect.Y + 12);
                                                chessBoard[k, m].fig = new Figure(1, i, j, 'w');
                                                chessBoard[i, j].fig.resetAll();
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                //player.Play();
                                                chessBoard[i, j].isFugure = false;
                                                isClicked = false;
                                                chessBoard[k, m].isFugure = true;
                                                chessBoard[k, m].fig.check_for_pawn = true;
                                            }
                                            else
                                            {
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                g.DrawImage(Properties.Resources.pawnW, chessBoard[i, j].rect.X + 15, chessBoard[i, j].rect.Y + 12);
                                            }
                                        }
                                        if (chessBoard[i, j].fig.data == 1 && chessBoard[i, j].fig.col == 'w' && k - i == 0 && m - j < 0 && m - j >= -1 && chessBoard[i, j].fig.check_for_pawn == true)
                                        {
                                            bool f = true;
                                            for (int y = m; y < j; y++)
                                            {
                                                if (chessBoard[k, y].isFugure)
                                                {
                                                    f = false;
                                                }
                                            }
                                            if (f)
                                            {
                                                g.DrawImage(Properties.Resources.pawnW, chessBoard[k, m].rect.X + 15, chessBoard[k, m].rect.Y + 12);
                                                chessBoard[k, m].fig = new Figure(1, i, j, 'w');
                                                chessBoard[i, j].fig.resetAll();
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                //player.Play();
                                                chessBoard[i, j].isFugure = false;
                                                isClicked = false;
                                                chessBoard[k, m].isFugure = true;
                                                chessBoard[k, m].fig.check_for_pawn = true;
                                            }
                                            else
                                            {
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                g.DrawImage(Properties.Resources.pawnW, chessBoard[i, j].rect.X + 15, chessBoard[i, j].rect.Y + 12);
                                            }
                                        }

                                        if (chessBoard[i, j].fig.data == 1 && chessBoard[i, j].fig.col == 'w' && Math.Abs(k - i) == 1 && m - j == -1 && chessBoard[k, m].isFugure)
                                        {
                                            g.FillRectangle(col, chessBoard[k, m].rect);
                                            g.DrawRectangle(blackPen, chessBoard[k, m].rect);
                                            g.DrawImage(Properties.Resources.pawnW, chessBoard[k, m].rect.X + 15, chessBoard[k, m].rect.Y + 12);
                                            chessBoard[k, m].fig = new Figure(1, i, j, 'w');
                                            chessBoard[i, j].fig.resetAll();
                                            //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                            //player.Play();
                                            chessBoard[i, j].isFugure = false;
                                            isClicked = false;
                                            chessBoard[k, m].isFugure = true;
                                            chessBoard[k, m].fig.check_for_pawn = true;
                                            g.FillRectangle(col, chessBoard[i, j].rect);
                                            g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                        }

                                        if (chessBoard[i, j].fig.data == 2 && chessBoard[i, j].fig.col == 'w' &&
                                            ((k - i == 1 || k - i == -1) && (m - j == 2 || m - j == -2) ||
                                            (k - i == 2 || k - i == -2) && (m - j == 1 || m - j == -1)))
                                        {
                                            if (chessBoard[k, m].isFugure == true)
                                            {
                                                if (chessBoard[k, m].fig.col == 'b')
                                                {
                                                    chessBoard[k, m].fig.resetAll();
                                                    chessBoard[k, m].fig = new Figure(2, i, j, 'w');
                                                    g.FillRectangle(col2, chessBoard[k, m].rect);
                                                    g.DrawRectangle(blackPen, chessBoard[k, m].rect);
                                                    g.DrawImage(Properties.Resources.knightW, chessBoard[k, m].rect.X + 8, chessBoard[k, m].rect.Y + 12);
                                                    chessBoard[i, j].fig.resetAll();
                                                    g.FillRectangle(col, chessBoard[i, j].rect);
                                                    g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                    //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                    //player.Play();
                                                    chessBoard[i, j].isFugure = false;
                                                    isClicked = false;
                                                    chessBoard[k, m].isFugure = true;
                                                }
                                            }
                                            else
                                            {
                                                g.DrawImage(Properties.Resources.knightW, chessBoard[k, m].rect.X + 8, chessBoard[k, m].rect.Y + 12);
                                                chessBoard[k, m].fig = new Figure(2, i, j, 'w');
                                                chessBoard[i, j].fig.resetAll();
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                //player.Play();
                                                chessBoard[i, j].isFugure = false;
                                                isClicked = false;
                                                chessBoard[k, m].isFugure = true;
                                            }
                                        }
                                        if (chessBoard[i, j].fig.data == 3 && chessBoard[i, j].fig.col == 'w' && Math.Abs(k - i) == Math.Abs(m - j))
                                        {
                                            bool f = true;
                                            if (m > j && k > i)
                                            {
                                                for (int x = Math.Abs(m - j - 1); x > 0; x--)
                                                {
                                                    if (chessBoard[i + x, j + x].isFugure == true)
                                                        f = false;
                                                }
                                            }
                                            if (m > j && k < i)
                                            {
                                                for (int x = Math.Abs(m - j - 1); x > 0; x--)
                                                {
                                                    if (chessBoard[i - x, j + x].isFugure == true)
                                                        f = false;
                                                }
                                            }
                                            if (m < j && k > i)
                                            {
                                                for (int x = Math.Abs(m - j + 1); x > 0; x--)
                                                {
                                                    if (chessBoard[i + x, j - x].isFugure == true)
                                                        f = false;
                                                }
                                            }
                                            if (m < j && k < i)
                                            {
                                                for (int x = Math.Abs(m - j + 1); x > 0; x--)
                                                {
                                                    if (chessBoard[i - x, j - x].isFugure == true)
                                                        f = false;
                                                }
                                            }
                                            if (f)
                                            {
                                                g.FillRectangle(col2, chessBoard[k, m].rect);
                                                g.DrawRectangle(blackPen, chessBoard[k, m].rect);
                                                g.DrawImage(Properties.Resources.bishopW, chessBoard[k, m].rect.X + 8, chessBoard[k, m].rect.Y + 8);
                                                chessBoard[k, m].fig = new Figure(3, i, j, 'w');
                                                chessBoard[i, j].fig.resetAll();
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                //player.Play();
                                                chessBoard[i, j].isFugure = false;
                                                isClicked = false;
                                                chessBoard[k, m].isFugure = true;
                                            }
                                            else
                                            {
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                g.DrawImage(Properties.Resources.bishopW, chessBoard[i, j].rect.X + 8, chessBoard[i, j].rect.Y + 8);
                                            }
                                        }
                                        if (chessBoard[i, j].fig.data == 4 && chessBoard[i, j].fig.col == 'w' && ((k == i && m != j) || (m == j && k != i)))
                                        {
                                            bool f = true;
                                            if (k == i && m != j && m > j)
                                            {
                                                for (int y = m - 1; y > j; y--)
                                                {
                                                    if (chessBoard[k, y].isFugure)
                                                    {
                                                        f = false;
                                                    }
                                                }
                                            }
                                            if (k == i && m != j && m < j)
                                            {
                                                for (int y = m + 1; y < j; y++)
                                                {
                                                    if (chessBoard[k, y].isFugure)
                                                    {
                                                        f = false;
                                                    }
                                                }
                                            }
                                            if (m == j && k != i && k > i)
                                            {
                                                for (int y = k - 1; y > i; y--)
                                                {
                                                    if (chessBoard[y, m].isFugure)
                                                    {
                                                        f = false;
                                                    }
                                                }
                                            }
                                            if (m == j && k != i && k < i)
                                            {
                                                for (int y = k + 1; y < i; y++)
                                                {
                                                    if (chessBoard[y, m].isFugure)
                                                    {
                                                        f = false;
                                                    }
                                                }
                                            }
                                            if (f)
                                            {
                                                if (chessBoard[k, m].isFugure == true)
                                                {
                                                    if (chessBoard[k, m].fig.col == 'b')
                                                    {
                                                        chessBoard[k, m].fig.resetAll();
                                                        chessBoard[k, m].fig = new Figure(4, i, j, 'w');
                                                        g.FillRectangle(col2, chessBoard[k, m].rect);
                                                        g.DrawRectangle(blackPen, chessBoard[k, m].rect);
                                                        g.DrawImage(Properties.Resources.rookW, chessBoard[k, m].rect.X + 10, chessBoard[k, m].rect.Y + 12);
                                                        chessBoard[i, j].fig.resetAll();
                                                        g.FillRectangle(col, chessBoard[i, j].rect);
                                                        g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                        //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                        //player.Play();
                                                        chessBoard[i, j].isFugure = false;
                                                        isClicked = false;
                                                        chessBoard[k, m].isFugure = true;
                                                    }
                                                }
                                                else
                                                {
                                                    g.DrawImage(Properties.Resources.rookW, chessBoard[k, m].rect.X + 10, chessBoard[k, m].rect.Y + 12);
                                                    chessBoard[k, m].fig = new Figure(4, i, j, 'w');
                                                    chessBoard[i, j].fig.resetAll();
                                                    g.FillRectangle(col, chessBoard[i, j].rect);
                                                    g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                    //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                    //player.Play();
                                                    chessBoard[i, j].isFugure = false;
                                                    isClicked = false;
                                                    chessBoard[k, m].isFugure = true;
                                                }
                                            }
                                            else
                                            {
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                g.DrawImage(Properties.Resources.rookW, chessBoard[i, j].rect.X + 10, chessBoard[i, j].rect.Y + 12);
                                            }
                                        }
                                        if (chessBoard[i, j].fig.data == 5 && chessBoard[i, j].fig.col == 'w' && (((k == i && m != j) || (m == j && k != i)) || (Math.Abs(k - i) == Math.Abs(m - j))))
                                        {
                                            bool f = true;
                                            if (m > j && k > i)
                                            {
                                                for (int x = Math.Abs(m - j - 1); x > 0; x--)
                                                {
                                                    if (chessBoard[i + x, j + x].isFugure == true)
                                                        f = false;
                                                }
                                            }
                                            if (m > j && k < i)
                                            {
                                                for (int x = Math.Abs(m - j - 1); x > 0; x--)
                                                {
                                                    if (chessBoard[i - x, j + x].isFugure == true)
                                                        f = false;
                                                }
                                            }
                                            if (m < j && k > i)
                                            {
                                                for (int x = Math.Abs(m - j + 1); x > 0; x--)
                                                {
                                                    if (chessBoard[i + x, j - x].isFugure == true)
                                                        f = false;
                                                }
                                            }
                                            if (m < j && k < i)
                                            {
                                                for (int x = Math.Abs(m - j + 1); x > 0; x--)
                                                {
                                                    if (chessBoard[i - x, j - x].isFugure == true)
                                                        f = false;
                                                }
                                            }
                                            if (k == i && m != j && m > j)
                                            {
                                                for (int y = m - 1; y > j; y--)
                                                {
                                                    if (chessBoard[k, y].isFugure)
                                                    {
                                                        f = false;
                                                    }
                                                }
                                            }
                                            if (k == i && m != j && m < j)
                                            {
                                                for (int y = m + 1; y < j; y++)
                                                {
                                                    if (chessBoard[k, y].isFugure)
                                                    {
                                                        f = false;
                                                    }
                                                }
                                            }
                                            if (m == j && k != i && k > i)
                                            {
                                                for (int y = k - 1; y > i; y--)
                                                {
                                                    if (chessBoard[y, m].isFugure)
                                                    {
                                                        f = false;
                                                    }
                                                }
                                            }
                                            if (m == j && k != i && k < i)
                                            {
                                                for (int y = k + 1; y < i; y++)
                                                {
                                                    if (chessBoard[y, m].isFugure)
                                                    {
                                                        f = false;
                                                    }
                                                }
                                            }
                                            if (f)
                                            {
                                                if (chessBoard[k, m].isFugure == true)
                                                {
                                                    if (chessBoard[k, m].fig.col == 'b')
                                                    {
                                                        chessBoard[k, m].fig.resetAll();
                                                        chessBoard[k, m].fig = new Figure(5, i, j, 'w');
                                                        g.FillRectangle(col2, chessBoard[k, m].rect);
                                                        g.DrawRectangle(blackPen, chessBoard[k, m].rect);
                                                        g.DrawImage(Properties.Resources.queenW, chessBoard[k, m].rect.X + 5, chessBoard[k, m].rect.Y + 8);
                                                        chessBoard[i, j].fig.resetAll();
                                                        g.FillRectangle(col, chessBoard[i, j].rect);
                                                        g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                        //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                        //player.Play();
                                                        chessBoard[i, j].isFugure = false;
                                                        isClicked = false;
                                                        chessBoard[k, m].isFugure = true;
                                                    }
                                                }
                                                else
                                                {
                                                    g.DrawImage(Properties.Resources.queenW, chessBoard[k, m].rect.X + 5, chessBoard[k, m].rect.Y + 8);
                                                    chessBoard[k, m].fig = new Figure(5, i, j, 'w');
                                                    chessBoard[i, j].fig.resetAll();
                                                    g.FillRectangle(col, chessBoard[i, j].rect);
                                                    g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                    //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                    //player.Play();
                                                    chessBoard[i, j].isFugure = false;
                                                    isClicked = false;
                                                    chessBoard[k, m].isFugure = true;
                                                }
                                            }
                                            else
                                            {
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                g.DrawImage(Properties.Resources.queenW, chessBoard[i, j].rect.X + 5, chessBoard[i, j].rect.Y + 8);
                                            }
                                        }
                                        if (chessBoard[i, j].fig.data == 6 && chessBoard[i, j].fig.col == 'w' && Math.Abs(k - i) <= 1 && Math.Abs(m - j) <= 1)
                                        {
                                            if (chessBoard[k, m].isFugure == true)
                                            {
                                                if (chessBoard[k, m].fig.col == 'b')
                                                {
                                                    chessBoard[k, m].fig.resetAll();
                                                    chessBoard[k, m].fig = new Figure(6, i, j, 'w');
                                                    g.FillRectangle(col2, chessBoard[k, m].rect);
                                                    g.DrawRectangle(blackPen, chessBoard[k, m].rect);
                                                    g.DrawImage(Properties.Resources.kingW, chessBoard[k, m].rect.X + 5, chessBoard[k, m].rect.Y + 4);
                                                    chessBoard[i, j].fig.resetAll();
                                                    g.FillRectangle(col, chessBoard[i, j].rect);
                                                    g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                    //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                    //player.Play();
                                                    chessBoard[i, j].isFugure = false;
                                                    isClicked = false;
                                                    chessBoard[k, m].isFugure = true;
                                                }
                                            }
                                            else
                                            {
                                                g.DrawImage(Properties.Resources.kingW, chessBoard[k, m].rect.X + 5, chessBoard[k, m].rect.Y + 4);
                                                chessBoard[k, m].fig = new Figure(6, i, j, 'w');
                                                chessBoard[i, j].fig.resetAll();
                                                g.FillRectangle(col, chessBoard[i, j].rect);
                                                g.DrawRectangle(blackPen, chessBoard[i, j].rect);
                                                //player.SoundLocation = @strCoreData + "\\sounds\\move.wav";
                                                //player.Play();
                                                chessBoard[i, j].isFugure = false;
                                                isClicked = false;
                                                chessBoard[k, m].isFugure = true;
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void GameTogether_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Show();
        }
    }
}