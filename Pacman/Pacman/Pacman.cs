using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Pacman : Character
    {
        public int score;
        public int life;
        public string previous;

        public Pacman(int x, int y) : base (x,y)
        {
            previous = "";
            life = 3;
            score = 0;
        }
    }
}
