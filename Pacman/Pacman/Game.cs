using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public sealed class Game
    {
        string[,] matrix; //A Creer par ligne
        int size;
        int score_max;
        int safety = 6;
        int fixe_safety = 6;
        Pacman p;
        Monster m1;
        Monster m2;
        Monster m3;

        public Game()
        {
            p = new Pacman(0,0);
        }

        public void init()
        {
            m1 = new Monster("red", 0, matrix.GetLength(0) - 1);
            if (size > 70)
            {
                int[] inim2 = ini_m2();
                m2 = new Monster("blue", inim2[0], inim2[1]);
                m2.previous = "down";
            }
            if (size > 140)
            {
                int[] inim3 = ini_m3();
                m3 = new Monster("green", inim3[0], inim3[1]);
                m3.previous = "up";
            }

        }

        public int count_matrix(string[,] matrix)
        {
            int comp = 0;
            foreach(string element in matrix)
            {
                if (element == "* ") { comp++; }
            }
            return comp;
        }

        public void matrix_creation_8x8()
        {
            string[,] mat = { { "P ", "* ", "* ", "* ", "* ", "* ", "* ", "* " }, { "* ", "- ", "* ", "- ", "* ", "- ", "- ", "* " }, { "* ", "- ", "* ", "* ", "* ", "* ", "* ", "* " }, { "* ", "- ", "* ", "- ", "* ", "- ", "* ", "- " }, { "* ", "* ", "* ", "* ", "* ", "- ", "* ", "* " }, { "* ", "- ", "- ", "- ", "* ", "- ", "- ", "* " }, { "* ", "- ", "* ", "* ", "* ", "- ", "* ", "* " }, { "* ", "* ", "* ", "- ", "* ", "* ", "* ", "- " } };
            matrix = mat;
            score_max = count_matrix(matrix) - 1;
            size = matrix.GetLength(0) * matrix.GetLength(1);
        }

        public void matrix_creation_14x12()
        {
            string[,] mat = { { "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ","* ", "* " }, { "* ", "- ", "- ", "* ", "- ", "- ", "* ", "- ", "* ", "- ", "- ", "* " ,"- ", "* "}, { "* ", "- ", "* ", "* ", "* ", "- ", "* ", "* ", "* ", "- ", "- ", "* ", "* ", "* " }, { "* ", "* ", "* ", "- ", "* ", "- ", "* ", "- ", "- ", "- ", "* ", "* ", "- ","* " }, { "* ", "- ", "- ", "- ", "* ", "* ", "* ", "* ", "* ", "- ", "* ", "- " , "- ", "* " }, { "* ", "* ", "* ", "* ", "* ", "- ", "- ", "- ", "* ", "* ", "* ", "* ", "* ", "* " }, { "* ", "- ", "* ", "- ", "* ", "* ", "* ", "* ", "* ", "- ", "- ", "- ", "- ", "* " }, { "* ", "- ", "* ", "- ", "- ", "- ", "* ", "- ", "* ", "* ", "* ", "* ", "* ", "* " }, { "* ", "* ", "* ", "- ", "* ", "* ", "* ", "- ", "* ", "- ", "* ", "- ","- ", "* " }, { "* ", "- ", "* ", "* ", "* ", "- ", "* ", "* ", "* ", "- ", "* ", "* ","- ", "* " }, { "* ", "- ", "- ", "- ", "- ", "- ", "* ", "- ", "* ", "- ", "- ", "* ","- ", "* " }, { "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* " } };
            matrix = mat;
            score_max = count_matrix(matrix) - 1;
            size = matrix.GetLength(0) * matrix.GetLength(1);
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
                if (c.cover != "M ") { matrix[c.y, c.x] = c.cover; }
                c.cover = matrix[c.y + 1, c.x];
                matrix[c.y + 1, c.x] = "M ";
                c.y++;
                return;
            }
            if (direction == "up")
            {
                if (c.cover != "M ") { matrix[c.y, c.x] = c.cover; }
                c.cover = matrix[c.y - 1, c.x];
                matrix[c.y - 1, c.x] = "M ";
                c.y--;
                return;
            }
            if (direction == "left")
            {
                if (c.cover != "M ") { matrix[c.y, c.x] = c.cover; }
                c.cover = matrix[c.y, c.x - 1];
                matrix[c.y, c.x - 1] = "M ";
                c.x--;
                return;
            }
            if (direction == "right")
            {
                if (c.cover != "M ") { matrix[c.y, c.x] = c.cover; }
                c.cover = matrix[c.y, c.x + 1];
                matrix[c.y, c.x + 1] = "M ";
                c.x++;
                return;
            }
        }

        public int[] ini_m2()
        {
            int range = 2;
            int circle = 0;
            string previous = "up";
            int[] retour = new int[2];
            int inix = matrix.GetLength(1) / 2;
            int iniy = matrix.GetLength(0) / 2;
            if (matrix[iniy,inix] != "- ") { retour[0] = inix; retour[1] = iniy; }
            else
            {
                inix--;
                if (matrix[iniy,inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                else
                {
                    while (circle < 3)
                    {
                        if (previous == "up")
                        {
                            for(int i = 0; i < range; i++)
                            {
                                inix++;
                                if (matrix[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                            }
                            previous = "right";
                        }
                        if (previous == "right")
                        {
                            for (int i = 0; i < range; i++)
                            {
                                iniy++;
                                if (matrix[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                            }
                            previous = "down";
                        }
                        if (previous == "down")
                        {
                            for (int i = 0; i < range; i++)
                            {
                                iniy++;
                                if (matrix[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                            }
                            previous = "left";
                        }
                        if (previous == "left")
                        {
                            range++;
                            for (int i = 0; i < range; i++)
                            {
                                iniy++;
                                if (matrix[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                            }
                            previous = "up";
                        }
                        circle++;
                    }
                }
            }
            return retour;
        }

        public int[] ini_m3()
        {
            int range = 2;
            int circle = 0;
            string previous = "up";
            int[] retour = new int[2];
            int inix = matrix.GetLength(1) / 4;
            int iniy = matrix.GetLength(0) / 4;
            if (matrix[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; }
            else
            {
                inix--;
                if (matrix[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                else
                {
                    while (circle < 3)
                    {
                        if (previous == "up")
                        {
                            for (int i = 0; i < range; i++)
                            {
                                inix++;
                                if (matrix[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                            }
                            previous = "right";
                        }
                        if (previous == "right")
                        {
                            for (int i = 0; i < range; i++)
                            {
                                iniy++;
                                if (matrix[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                            }
                            previous = "down";
                        }
                        if (previous == "down")
                        {
                            for (int i = 0; i < range; i++)
                            {
                                iniy++;
                                if (matrix[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                            }
                            previous = "left";
                        }
                        if (previous == "left")
                        {
                            range++;
                            for (int i = 0; i < range; i++)
                            {
                                iniy++;
                                if (matrix[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                            }
                            previous = "up";
                        }
                        circle++;
                    }
                }
            }
            return retour;
        }

        public bool end()
        {
            if (p.x == m1.x && p.y == m1.y) { Console.WriteLine("Game Over"); return true; }
            //if (p.x == m2.x && p.y == m2.y) { Console.WriteLine("Game Over"); return true; }
            //if (p.x == m3.x && p.y == m3.y) { Console.WriteLine("Game Over"); return true; }
            else if (p.score >= score_max) { Console.WriteLine("Win !"); return true; }
            else { return false; }
        }

        public void m1_move()
        {
            if (m1.x == 0 && m1.y != 0) { move_monster("up", m1); return; }
            if (m1.x != matrix.GetLength(1)-1 && m1.y == 0) { move_monster("right", m1); return; }
            if (m1.x == matrix.GetLength(1) - 1 && m1.y != matrix.GetLength(0)-1) { move_monster("down", m1); return; }
            if (m1.x != 0 && m1.y == matrix.GetLength(0) - 1) { move_monster("left", m1); return; }


        }

        public void m2_move(Monster m)
        {
            if (m.previous == "right")
            {
                if (can_move(m, "down"))
                {
                    move_monster("down", m);
                    m.previous = "down";
                    return;
                }
                else if (can_move(m, "right"))
                {
                    move_monster("right", m);
                    return;
                }
                else
                {
                    move_monster("up", m);
                    return;
                }
            }
            if (m.previous == "down")
            {
                if (can_move(m, "left"))
                {
                    move_monster("left", m);
                    m.previous = "left";
                    return;
                }
                else if (can_move(m, "down"))
                {
                    move_monster("down", m);
                    return;
                }
                else
                {
                    move_monster("right", m);
                    return;
                }
            }
            if (m.previous == "left")
            {
                if (can_move(m, "up"))
                {
                    move_monster("up", m);
                    m.previous = "up";
                    return;
                }
                else if (can_move(m, "left"))
                {
                    move_monster("left", m);
                    return;
                }
                else
                {
                    move_monster("down", m);
                    return;
                }
            }
            if (m.previous == "up")
            {
                if (can_move(m, "right"))
                {
                    move_monster("right", m);
                    m.previous = "right";
                    return;
                }
                else if (can_move(m, "up"))
                {
                    move_monster("up", m);
                    return;
                }
                else
                {
                    move_monster("left", m);
                    return;
                }
            }
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
                if (i > 4) { div = 2; }
                int u = way_list.Count;
                for (int k = 0; k < u ; k++)
                {
                      Way wayt = way_list[k];
                      if (can_move(wayt, "up") && wayt.list[wayt.list.Count-1] != "down")
                      {
                        Way way = new Way(wayt);
                        way.y -= 1;
                        if (matrix[way.y,way.x] == "* ") { way.score += (1 / div); }
                        if (matrix[way.y, way.x] == "M " && wayt.list.Count < safety)
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
                        if (matrix[way.y, way.x] == "M " && wayt.list.Count < safety) { fuite.Add(wayt.list[0]); }
                        way.list.Add("down");
                        way_list.Add(way);
                    }
                    if (can_move(wayt, "left") && wayt.list[wayt.list.Count - 1] != "right")
                    {
                        Way way = new Way(wayt);
                        way.x -= 1;
                        if (matrix[way.y, way.x] == "* ") { way.score += (1 / div); }
                        if (matrix[way.y, way.x] == "M " && wayt.list.Count < safety) { fuite.Add(wayt.list[0]); }
                        way.list.Add("left");
                        way_list.Add(way);
                    }
                    if (can_move(wayt, "right") && wayt.list[wayt.list.Count - 1] != "left")
                    {
                        Way way = new Way(wayt);
                        way.x += 1;
                        if (matrix[way.y, way.x] == "* ") { way.score += (1 / div); }
                        if (matrix[way.y, way.x] == "M " && wayt.list.Count < safety)
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
            if (way_list.Count < 1)
            {
                safety--;
                string temp = best_way(power);
                safety = fixe_safety;
                return temp;
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
            int range = matrix.GetLength(0) + matrix.GetLength(1);
            while (end() == false)
            {
                m1_move();
                if (size > 70) { m2_move(m2); }
                if (size > 140) { m2_move(m3); }
                matrix_display();
                if (p.x == m1.x && p.y == m1.y) { Console.WriteLine("Game Over"); break; }
                Console.ReadKey();
                string way = best_way(range);
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
