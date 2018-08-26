using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using suzuha.moth.Game;

namespace suzuha.moth
{
    class Moth
    {

        public void StartNewGame()
        {
            var player = new Player();
            // player.MakeTurn();
        }

        public static void PrintTitle()
        {
            Console.WriteLine("Moth v0.01 - Decision-based story experience .. something like that ..");
        }

        public static void PrintMessage()
        {
            string msg = "Ich hab noch keinen Inhalt heisst muss ich noch dazu schreiben aber hey" +
                         " Programm mal schicken funktioniert schon mal ^^";
            Console.WriteLine(msg);
        }
    }
}
