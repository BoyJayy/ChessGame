namespace ChessGame
{
    internal class Player
    {
        private class PlayerSide
        {
            public bool side; //если 1, то белые, иначе черные;

            private void setSide(bool n)
            {
                side = n;
            }
        }
    }
}