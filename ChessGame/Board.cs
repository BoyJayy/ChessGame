using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    struct Board
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
}
