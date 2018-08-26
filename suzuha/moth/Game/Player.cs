using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suzuha.moth.Game
{
    class Player : Character
    {
        public override void MakeTurn()
        {
            Console.WriteLine("" + this.Name + " makes a turn ..");
        }
    }
}
