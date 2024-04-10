using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Figure
    {
        public int data;
        public int posX; public int posY;
        public char tag;
        public bool check_for_pawn = true;
        public Image pic;
        public char col;

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

        public void resetAll()
        {
            data = -1;
            posX = -1;
            posY = -1;
            tag = '0';
            pic = null;
            col = '0';
        }

        public Figure(int tdata, int pos_x, int pos_y, char c)
        {
            setData(tdata);
            setPos(pos_x, pos_y);
            setcol(c);
            if (data == 1)
            { tag = 'p'; check_for_pawn = false; }
            if (data == 2) tag = 'k';
            if (data == 3) tag = 'b';
            if (data == 4) tag = 'r';
            if (data == 5) tag = 'q';
            if (data == 6) tag = 'K';
        }
    }
}
