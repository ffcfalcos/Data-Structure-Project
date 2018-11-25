using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.matrix_creation_8x8();
            game.init();
            game.auto_deplacement();
            Console.ReadKey();
        }
    }
}
