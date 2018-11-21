using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    abstract public class Character
    {
        public int x;
        public int y;

        public Character (int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
