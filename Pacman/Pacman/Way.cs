using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public sealed class Way
    {
        public int x;
        public int y;
        public int score;
        public List<string> list;
        public enum direction { left, right, down, up }

        public Way(int ini_x, int ini_y)
        {
            score = 0;
            this.x = ini_x;
            this.y = ini_y;
            list = new List<string>();
        }

        public Way()
        {
            score = 0;
            list = new List<string>();
        }

        public Way(Way way)
        {
            score = 0;
            x = way.x;
            y = way.y;
            score = way.score;
            list = new List<string>();
            list.AddRange(way.list);
        }

    }
}
