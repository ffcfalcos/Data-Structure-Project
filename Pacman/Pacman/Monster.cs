using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Monster : Character
    {
        public string color;
        public string cover;

        public Monster(string color, int x, int y) : base (x,y)
        {
            this.color = color;
            this.cover = "* ";
        }
    }
}
