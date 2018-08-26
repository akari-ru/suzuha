using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suzuha.moth.Game
{
    abstract class Character
    {
        int _hp = 10000;
        int _mp = 10000;
        int _resurrectionPasses = 3;

        public string Name { get; } = "Unknown";

        public abstract void MakeTurn();

    }
}
