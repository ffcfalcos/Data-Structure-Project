using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public sealed class Game
    {
        string[,] matrix;
        int score_max = 44;
        Pacman p;
        Monster m1 = new Monster("red", 0, 3);
        Monster m2 = new Monster("blue", 4, 2);

        public Game()
        {
            p = new Pacman(0,0);
            matrix_creation();
        }

        public void matrix_creation()
        {
            string[,] mat = { { "P ", "* ", "* ", "* ", "* ", "* ", "* ", "* " }, { "* ", "- ", "* ", "- ", "* ", "- ", "- ", "* " }, { "* ", "- ", "* ", "* ", "M ", "* ", "* ", "* " }, { "* ", "- ", "* ", "- ", "* ", "- ", "* ", "- " }, { "* ", "* ", "* ", "* ", "* ", "- ", "* ", "* " }, { "* ", "- ", "- ", "- ", "* ", "- ", "- ", "* " }, { "* ", "- ", "* ", "* ", "* ", "- ", "* ", "* " }, { "* ", "* ", "* ", "- ", "* ", "* ", "* ", "- " } };
            matrix = mat;
        }

        public void matrix_display()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    Console.Write(matrix[i, k]);
                }
                Console.WriteLine();
            }

        }

        public void move(string direction)
        {
            if (direction == "down")
            {
                if(matrix[p.y + 1, p.x] == "* ") { p.score++; }
                matrix[p.y + 1, p.x] = "P ";
                matrix[p.y, p.x] = ". ";
                p.y++;
            }
            if (direction == "up")
            {
                if (matrix[p.y - 1, p.x] == "* ") { p.score++; }
                matrix[p.y - 1, p.x] = "P ";
                matrix[p.y, p.x] = ". ";
                p.y--;
            }
            if (direction == "left")
            {
                if (matrix[p.y, p.x - 1] == "* ") { p.score++; }
                matrix[p.y, p.x - 1] = "P ";
                matrix[p.y, p.x] = ". ";
                p.x--;
            }
            if (direction == "right")
            {
                if (matrix[p.y, p.x + 1] == "* ") { p.score++; }
                matrix[p.y, p.x + 1] = "P ";
                matrix[p.y, p.x] = ". ";
                p.x++;
            }
        }

        public void move_monster(string direction, Monster c)
        {
            if (direction == "down")
            {
                matrix[c.y, c.x] = c.cover;
                c.cover = matrix[c.y + 1, c.x];
                matrix[c.y + 1, c.x] = "M ";
                c.y++;
                return;
            }
            if (direction == "up")
            {
                matrix[c.y, c.x] = c.cover;
                c.cover = matrix[c.y - 1, c.x];
                matrix[c.y - 1, c.x] = "M ";
                c.y--;
                return;
            }
            if (direction == "left")
            {
                matrix[c.y, c.x] = c.cover;
                c.cover = matrix[c.y, c.x - 1];
                matrix[c.y, c.x - 1] = "M ";
                c.x--;
                return;
            }
            if (direction == "right")
            {
                matrix[c.y, c.x] = c.cover;
                c.cover = matrix[c.y, c.x + 1];
                matrix[c.y, c.x + 1] = "M ";
                c.x++;
                return;
            }
        }

        public bool end()
        {
            if (p.x == m1.x && p.y == m1.y) { Console.WriteLine("Game Over"); return true; }
            else if (p.score >= score_max) { Console.WriteLine("Win !"); return true; }
            else { return false; }
        }

        public void red_move()
        {
            if (m1.x == 6 && m1.y == 6) { move_monster("down", m1); return; }
            if (m1.x == 6 && m1.y == 7) { move_monster("left", m1); return; }
            if (m1.x == 5 && m1.y == 7) { move_monster("left", m1); return; }
            if (m1.x == 4 && m1.y == 7) { move_monster("up", m1); return; }
            if (m1.x == 4 && m1.y == 6) { move_monster("left", m1); return; }
            if (m1.x == 3 && m1.y == 6) { move_monster("left", m1); return; }
            if (m1.x == 2 && m1.y == 6) { move_monster("down", m1); return; }
            if (m1.x == 2 && m1.y == 7) { move_monster("left", m1); return; }
            if (m1.x == 1 && m1.y == 7) { move_monster("left", m1); return; }
            if (m1.x == 0 && m1.y != 0) { move_monster("up", m1); return; }
            if (m1.x != 7 && m1.y == 0) { move_monster("right", m1); return; }
            if (m1.x == 7 && m1.y == 0) { move_monster("down", m1); return; }
            if (m1.x == 7 && m1.y == 1) { move_monster("down", m1); return; }
            if (m1.x == 7 && m1.y == 2) { move_monster("left", m1); return; }
            if (m1.x == 6 && m1.y == 2) { move_monster("down", m1); return; }
            if (m1.x == 6 && m1.y == 3) { move_monster("down", m1); return; }
            if (m1.x == 6 && m1.y == 4) { move_monster("right", m1); return; }
            if (m1.x == 7 && m1.y == 4) { move_monster("down", m1); return; }
            if (m1.x == 7 && m1.y == 5) { move_monster("down", m1); return; }
            if (m1.x == 7 && m1.y == 6) { move_monster("left", m1); return; }

        }

        public void blue_move()
        {
            if (m2.y == 4 && m2.x != 2) { move_monster("left", m2); return; }
            if (m2.x == 2 && m2.y != 2) { move_monster("up", m2); return; }
            if (m2.y == 2 && m2.x != 4) { move_monster("right", m2); return; }
            if (m2.x == 4 && m2.y != 4) { move_monster("down", m2); return; }
        }

        public bool can_move(Character c, string direction)
        {
            if (direction == "up")
            {
                if (c.y == 0 || matrix[c.y - 1 , c.x] == "- ") { return false; }
                else { return true; }
            }
            if (direction == "down")
            {
                if (c.y + 1 == matrix.GetLength(0) || matrix[c.y + 1, c.x] == "- ")
                { return false; }
                else { return true; }
            }
            if (direction == "left")
            {
                if (c.x == 0 || matrix[c.y , c.x - 1] == "- ") { return false; }
                else { return true; }
            }
            if (direction == "right")
            {
                if (c.x + 1== matrix.GetLength(1) || matrix[c.y , c.x + 1] == "- ") { return false; }
                else { return true; }
            }
            return false;
        }

        public bool can_move(Way way, string direction)
        {
            if (direction == "up")
            {
                if (way.y == 0 || matrix[way.y - 1, way.x] == "- ") { return false; }
                else { return true; }
            }
            if (direction == "down")
            {
                if (way.y + 1 == matrix.GetLength(0) || matrix[way.y + 1, way.x] == "- ")
                { return false; }
                else { return true; }
            }
            if (direction == "left")
            {
                if (way.x == 0 || matrix[way.y, way.x - 1] == "- ") { return false; }
                else { return true; }
            }
            if (direction == "right")
            {
                if (way.x + 1 == matrix.GetLength(1) || matrix[way.y, way.x + 1] == "- ") { return false; }
                else { return true; }
            }
            return false;
        }

        public string best_way(int power)
        {
            List<string> fuite = new List<string>();
            List<Way> way_list = new List<Way>();
            if(can_move(p,"up") && matrix[p.y - 1, p.x] != "M ")
            {
                Way way = new Way(p.x, p.y - 1);
                if (matrix[way.y, way.x] == "* ") { way.score++; }
                if (p.previous == "down") { way.score -= 8; }
                way.list.Add("up");
                way_list.Add(way);
            }
            if (can_move(p, "down") && matrix[p.y+1,p.x] != "M ")
            {
                Way way = new Way(p.x, p.y + 1);
                if (matrix[way.y, way.x] == "* ") { way.score++; }
                if (p.previous == "up") { way.score -= 8; }
                way.list.Add("down");
                way_list.Add(way);
            }
            if (can_move(p, "left") && matrix[p.y, p.x - 1] != "M ")
            {
                Way way = new Way(p.x - 1, p.y);
                if (matrix[way.y, way.x] == "* ") { way.score++; }
                if (p.previous == "right") { way.score -= 8; }
                way.list.Add("left");
                way_list.Add(way);
            }
            if (can_move(p, "right") && matrix[p.y, p.x + 1] != "M ")
            {
                Way way = new Way(p.x + 1, p.y);
                if (matrix[way.y, way.x] == "* ") { way.score++; }
                if (p.previous == "left") { way.score -= 8; }
                way.list.Add("right");
                way_list.Add(way);
            }
            int div = 1;
            int i = 0;
            while (i <= power)
            {
                if (i > 6) { div = 2; }
                int u = way_list.Count;
                for (int k = 0; k < u ; k++)
                {
                      Way wayt = way_list[k];
                      if (can_move(wayt, "up") && wayt.list[wayt.list.Count-1] != "down")
                      {
                        Way way = new Way(wayt);
                        way.y -= 1;
                        if (matrix[way.y,way.x] == "* ") { way.score += (1 / div); }
                        if (matrix[way.y, way.x] == "M " && wayt.list.Count < 2)
                        {
                            fuite.Add(wayt.list[0]);
                        }
                        way.list.Add("up");
                        way_list.Add(way);
                    }
                    if (can_move(wayt, "down") && wayt.list[wayt.list.Count - 1] != "up")
                    {
                        Way way = new Way(wayt);
                        way.y += 1;
                        if (matrix[way.y, way.x] == "* ") { way.score += (1 / div); }
                        if (matrix[way.y, way.x] == "M " && wayt.list.Count < 2) { fuite.Add(wayt.list[0]); }
                        way.list.Add("down");
                        way_list.Add(way);
                    }
                    if (can_move(wayt, "left") && wayt.list[wayt.list.Count - 1] != "right")
                    {
                        Way way = new Way(wayt);
                        way.x -= 1;
                        if (matrix[way.y, way.x] == "* ") { way.score += (1 / div); }
                        if (matrix[way.y, way.x] == "M " && wayt.list.Count < 2) { fuite.Add(wayt.list[0]); }
                        way.list.Add("left");
                        way_list.Add(way);
                    }
                    if (can_move(wayt, "right") && wayt.list[wayt.list.Count - 1] != "left")
                    {
                        Way way = new Way(wayt);
                        way.x += 1;
                        if (matrix[way.y, way.x] == "* ") { way.score += (1 / div); }
                        if (matrix[way.y, way.x] == "M " && wayt.list.Count < 2)
                        { fuite.Add(wayt.list[0]); }
                        way.list.Add("right");
                        way_list.Add(way);
                    }
                }
                way_list.RemoveRange(0, u);
                i++;
            }
            //fuite = table_unique(fuite);
            if (fuite.Count > 0)
            {
                foreach (string element in fuite)
                {
                    for (int k = way_list.Count-1; k >= 0; k--)
                    {
                        if (way_list[k].list[0] == element)
                        {
                            way_list.RemoveAt(k);
                        }
                    }
                }
            }
            Way Wayt = way_list[0];
            foreach (Way way in way_list)
            {
                if (way.score > Wayt.score)
                {
                    Wayt = way;
                }
            }
            return Wayt.list[0];

        }

        public void auto_deplacement()
        {
            while (end() == false)
            {
                red_move();
                blue_move();
                matrix_display();
                if (p.x == m1.x && p.y == m1.y) { Console.WriteLine("Game Over"); break; }
                Console.ReadKey();
                string way = best_way(16);
                move(way);
                p.previous = way;
                Console.WriteLine();
            }
            matrix_display();
            Console.WriteLine("End Game");
            Console.ReadKey();
        }

        private static List<string> table_unique(List<string> list)
        {
            List<string> retour = new List<string>();
            foreach (string temp in list)
            {
                bool test = false;
                foreach(string temp2 in list)
                {
                    if (temp == temp2) { test = true; }
                }
                if (!test) { retour.Add(temp); }
            }
            return retour;
        }
    }
}
