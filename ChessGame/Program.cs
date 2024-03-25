using System;
using System.Windows.Forms;

namespace ChessGame
{
    internal static class Program
    {
        public static Start ST;

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Start());
        }
    }
}