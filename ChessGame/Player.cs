namespace ChessGame
{
    public class Player
    {
            public bool temp; //если 1, то белые, иначе черные;
            public string side;
            public bool flag;
            public Player(bool d)
            {
                setSide(d);
            }

            public void setSide(bool n)
            {
                temp = n;
                if (temp == true) side = "w";
                else side = "b";
            }
    }
}