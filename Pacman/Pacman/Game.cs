using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public sealed class Game
    {
        int safety;
        int fixe_safety;
        int fixe_supermode;
        Pacman p;
        Monster m1;
        Monster m2;
        Monster m3;
        public Matrix matrix;
        public int supermode;

        public Game()
        {
            p = new Pacman(0,0);
            matrix = new Matrix();
            menu();
            init();
            fixe_supermode = (matrix.y_size+matrix.x_size) / 2;
            create_super_coin();
        }

        #region menu

        public void menu()
        {
            Console.WriteLine("Press 1 for a 8x8 matrix");
            Console.WriteLine("Press 2 for a 12x14 matrix");
            ConsoleKey choice = Console.ReadKey().Key;
            {
                if (choice == ConsoleKey.D1 || choice == ConsoleKey.NumPad1)
                {
                    matrix.creation_8x8();
                }
                if (choice == ConsoleKey.D2 || choice == ConsoleKey.NumPad2)
                {
                    matrix.creation_14x12();
                }
            }
            Console.WriteLine();
        }

        #endregion

        #region initialisation 

        public void init()
        {
            m1 = new Monster("red", 0, matrix.y_size - 1);
            m1.previous = "down";
            if (matrix.size > 70)
            {
                int[] inim2 = ini_m2();
                m2 = new Monster("blue", inim2[0], inim2[1]);
                m2.previous = "down";
            }
            if (matrix.size > 140)
            {
                int[] inim3 = ini_m3();
                m3 = new Monster("green", inim3[0], inim3[1]);
                m3.previous = "up";
            }
            fixe_safety = matrix.safety();
            safety = matrix.safety();
        }

        public int[] ini_m2()
        {
            int range = 2;
            int circle = 0;
            string previous = "up";
            int[] retour = new int[2];
            int inix = matrix.x_size / 2;
            int iniy = matrix.y_size / 2;
            if (matrix.mat[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; }
            else
            {
                inix--;
                if (matrix.mat[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                else
                {
                    while (circle < 3)
                    {
                        if (previous == "up")
                        {
                            for (int i = 0; i < range; i++)
                            {
                                inix++;
                                if (matrix.mat[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                            }
                            previous = "right";
                        }
                        if (previous == "right")
                        {
                            for (int i = 0; i < range; i++)
                            {
                                iniy++;
                                if (matrix.mat[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                            }
                            previous = "down";
                        }
                        if (previous == "down")
                        {
                            for (int i = 0; i < range; i++)
                            {
                                iniy++;
                                if (matrix.mat[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                            }
                            previous = "left";
                        }
                        if (previous == "left")
                        {
                            range++;
                            for (int i = 0; i < range; i++)
                            {
                                iniy++;
                                if (matrix.mat[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
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
            int inix = matrix.x_size / 4;
            int iniy = matrix.y_size / 4;
            if (matrix.mat[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; }
            else
            {
                inix--;
                if (matrix.mat[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                else
                {
                    while (circle < 3)
                    {
                        if (previous == "up")
                        {
                            for (int i = 0; i < range; i++)
                            {
                                inix++;
                                if (matrix.mat[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                            }
                            previous = "right";
                        }
                        if (previous == "right")
                        {
                            for (int i = 0; i < range; i++)
                            {
                                iniy++;
                                if (matrix.mat[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                            }
                            previous = "down";
                        }
                        if (previous == "down")
                        {
                            for (int i = 0; i < range; i++)
                            {
                                iniy++;
                                if (matrix.mat[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                            }
                            previous = "left";
                        }
                        if (previous == "left")
                        {
                            range++;
                            for (int i = 0; i < range; i++)
                            {
                                iniy++;
                                if (matrix.mat[iniy, inix] != "- ") { retour[0] = inix; retour[1] = iniy; return retour; }
                            }
                            previous = "up";
                        }
                        circle++;
                    }
                }
            }
            return retour;
        }

        #endregion

        public void create_super_coin()
        {
            int c = 0;
            for (int i = 0; i < matrix.y_size; i++)
            {
                for (int k = 0; k < matrix.x_size; k++)
                {
                    if (c % 30 == 0 && c!= 0)
                    {
                        if (matrix.mat[i, k] == "* ")
                        {
                            matrix.mat[i, k] = "+ ";
                        }
                        else { c--; }
                    }
                    c++;
                }
            }
        }

        public void move(string direction)
        {
            if (direction == "down")
            {
                if(matrix.ic(p.y + 1, p.x)) { p.score++; }
                if(matrix.mat[p.y + 1, p.x] == "+ ") { supermode = fixe_supermode; }
                matrix.mat[p.y + 1, p.x] = "P ";
                matrix.mat[p.y, p.x] = ". ";
                p.y++;
            }
            if (direction == "up")
            {
                if (matrix.ic(p.y - 1, p.x)) { p.score++; }
                if (matrix.mat[p.y - 1, p.x] == "+ ") { supermode = fixe_supermode; }
                matrix.mat[p.y - 1, p.x] = "P ";
                matrix.mat[p.y, p.x] = ". ";
                p.y--;
            }
            if (direction == "left")
            {
                if (matrix.ic(p.y, p.x - 1)) { p.score++; }
                if (matrix.mat[p.y, p.x - 1] == "+ ") { supermode = fixe_supermode; }
                matrix.mat[p.y, p.x - 1] = "P ";
                matrix.mat[p.y, p.x] = ". ";
                p.x--;
            }
            if (direction == "right")
            {
                if (matrix.ic(p.y, p.x + 1)) { p.score++; }
                if (matrix.mat[p.y, p.x + 1] == "+ ") { supermode = fixe_supermode; }
                matrix.mat[p.y, p.x + 1] = "P ";
                matrix.mat[p.y, p.x] = ". ";
                p.x++;
            }
        }

        public void move_monster(string direction, Monster c)
        {
            if (direction == "down")
            {
                if (c.cover != "M ") { matrix.mat[c.y, c.x] = c.cover; }
                if (c.cover == "P ") { matrix.mat[c.y, c.x] = ". "; }
                c.cover = matrix.mat[c.y + 1, c.x];
                matrix.mat[c.y + 1, c.x] = "M ";
                c.y++;
                return;
            }
            if (direction == "up")
            {
                if (c.cover != "M ") { matrix.mat[c.y, c.x] = c.cover; }
                if (c.cover == "P ") { matrix.mat[c.y, c.x] = ". "; }
                c.cover = matrix.mat[c.y - 1, c.x];
                matrix.mat[c.y - 1, c.x] = "M ";
                c.y--;
                return;
            }
            if (direction == "left")
            {
                if (c.cover != "M ") { matrix.mat[c.y, c.x] = c.cover; }
                if (c.cover == "P ") { matrix.mat[c.y, c.x] = ". "; }
                c.cover = matrix.mat[c.y, c.x - 1];
                matrix.mat[c.y, c.x - 1] = "M ";
                c.x--;
                return;
            }
            if (direction == "right")
            {
                if (c.cover != "M ") { matrix.mat[c.y, c.x] = c.cover; }
                if (c.cover == "P ") { matrix.mat[c.y, c.x] = ". "; }
                c.cover = matrix.mat[c.y, c.x + 1];
                matrix.mat[c.y, c.x + 1] = "M ";
                c.x++;
                return;
            }
        }

        public bool end()
        {
            if (supermode == 0)
            {
                if (p.x == m1.x && p.y == m1.y) { Console.WriteLine("Game Over"); return true; }
                if (matrix.size > 70) { if (p.x == m2.x && p.y == m2.y) { Console.WriteLine("Game Over"); return true; } }
                else { goto last; }
                if (matrix.size > 140) { if (p.x == m3.x && p.y == m3.y) { Console.WriteLine("Game Over"); return true; } }
                else { goto last; }
                last:
                if (p.score >= matrix.max_score) { matrix.display(); Console.WriteLine("Win !"); return true; }
                else { return false; }
            }
            else
            {
                if (p.x == m1.x && p.y == m1.y) { if (m1.cover == "* ") { m1.cover = ". "; p.score++; return false; } }
                if (matrix.size > 70) { if (p.x == m2.x && p.y == m2.y) { if (m2.cover == "* ") { m2.cover = ". "; p.score++; return false; } } }
                else { goto last; }
                if (matrix.size > 140) { if (p.x == m3.x && p.y == m3.y) { if (m3.cover == "* ") { m3.cover = ". "; p.score++; return false; } } }
                else { goto last; }
                last:
                if (p.score >= matrix.max_score) { return false; }
                else { return false; }
            }
        }

        public void m1_move()
        {
            if (m1.x == 0 && m1.y != 0) { move_monster("up", m1); return; }
            if (m1.x != matrix.x_size-1 && m1.y == 0) { move_monster("right", m1); return; }
            if (m1.x == matrix.x_size - 1 && m1.y != matrix.y_size-1) { move_monster("down", m1); return; }
            if (m1.x != 0 && m1.y == matrix.y_size - 1) { move_monster("left", m1); return; }
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

        public void monster_random_move(Monster m)
        {
            Random rnd = new Random();
            if (m.previous == "right")
            {
                if (can_move(m,"up") || can_move(m, "left") || can_move(m, "down"))
                {
                    lab1:
                    int rand = rnd.Next(1, 4);
                    if (rand == 1)
                    {
                        if (can_move(m, "up")) { move_monster("up", m); }
                        else { goto lab1; }
                    }
                    if (rand == 2)
                    {
                        if (can_move(m, "left")) { move_monster("left", m); }
                        else { goto lab1; }
                    }
                    if (rand == 3)
                    {
                        if (can_move(m, "down")) { move_monster("down", m); }
                        else { goto lab1; }
                    }
                }
            }
            if (m.previous == "left")
            {
                if (can_move(m, "up") || can_move(m, "right") || can_move(m, "down"))
                {
                    lab2:
                    int rand = rnd.Next(1, 4);
                    if (rand == 1)
                    {
                        if (can_move(m, "up")) { move_monster("up", m); }
                        else { goto lab2; }
                    }
                    if (rand == 2)
                    {
                        if (can_move(m, "right")) { move_monster("right", m); }
                        else { goto lab2; }
                    }
                    if (rand == 3)
                    {
                        if (can_move(m, "down")) { move_monster("down", m); }
                        else { goto lab2; }
                    }
                }
            }
            if (m.previous == "up")
            {
                if (can_move(m, "right") || can_move(m, "left") || can_move(m, "down"))
                {
                    lab3:
                    int rand = rnd.Next(1, 4);
                    if (rand == 1)
                    {
                        if (can_move(m, "right")) { move_monster("right", m); }
                        else { goto lab3; }
                    }
                    if (rand == 2)
                    {
                        if (can_move(m, "left")) { move_monster("left", m); }
                        else { goto lab3; }
                    }
                    if (rand == 3)
                    {
                        if (can_move(m, "down")) { move_monster("down", m); }
                        else { goto lab3; }
                    }
                }
            }
            if (m.previous == "down")
            {
                if (can_move(m, "up") || can_move(m, "left") || can_move(m, "right"))
                {
                    lab4:
                    int rand = rnd.Next(1, 4);
                    if (rand == 1)
                    {
                        if (can_move(m, "up")) { move_monster("up", m); }
                        else { goto lab4; }
                    }
                    if (rand == 2)
                    {
                        if (can_move(m, "left")) { move_monster("left", m); }
                        else { goto lab4; }
                    }
                    if (rand == 3)
                    {
                        if (can_move(m, "right")) { move_monster("right", m); }
                        else { goto lab4; }
                    }
                }
            }
        }

        public bool can_move(Character c, string direction)
        {
            if (direction == "up")
            {
                if (c.y == 0 || matrix.mat[c.y - 1 , c.x] == "- ") { return false; }
                else { return true; }
            }
            if (direction == "down")
            {
                if (c.y + 1 == matrix.y_size || matrix.mat[c.y + 1, c.x] == "- ")
                { return false; }
                else { return true; }
            }
            if (direction == "left")
            {
                if (c.x == 0 || matrix.mat[c.y , c.x - 1] == "- ") { return false; }
                else { return true; }
            }
            if (direction == "right")
            {
                if (c.x + 1== matrix.x_size || matrix.mat[c.y , c.x + 1] == "- ") { return false; }
                else { return true; }
            }
            return false;
        }

        public bool can_move(Way way, string direction)
        {
            if (direction == "up")
            {
                if (way.y == 0 || matrix.mat[way.y - 1, way.x] == "- ") { return false; }
                else { return true; }
            }
            if (direction == "down")
            {
                if (way.y + 1 == matrix.y_size || matrix.mat[way.y + 1, way.x] == "- ")
                { return false; }
                else { return true; }
            }
            if (direction == "left")
            {
                if (way.x == 0 || matrix.mat[way.y, way.x - 1] == "- ") { return false; }
                else { return true; }
            }
            if (direction == "right")
            {
                if (way.x + 1 == matrix.x_size || matrix.mat[way.y, way.x + 1] == "- ") { return false; }
                else { return true; }
            }
            return false;
        }

        public string best_way(int power)
        {
            List<string> fuite = new List<string>();
            List<Way> way_list = new List<Way>();
            if(can_move(p,"up") && matrix.mat[p.y - 1, p.x] != "M ")
            {
                Way way = new Way(p.x, p.y - 1);
                if (matrix.mat[way.y, way.x] == "* ") { way.score++; }
                if (p.previous == "down") { way.score -= 8; }
                way.list.Add("up");
                way_list.Add(way);
            }
            if (can_move(p, "down") && matrix.mat[p.y+1,p.x] != "M ")
            {
                Way way = new Way(p.x, p.y + 1);
                if (matrix.mat[way.y, way.x] == "* ") { way.score++; }
                if (p.previous == "up") { way.score -= 8; }
                way.list.Add("down");
                way_list.Add(way);
            }
            if (can_move(p, "left") && matrix.mat[p.y, p.x - 1] != "M ")
            {
                Way way = new Way(p.x - 1, p.y);
                if (matrix.mat[way.y, way.x] == "* ") { way.score++; }
                if (p.previous == "right") { way.score -= 8; }
                way.list.Add("left");
                way_list.Add(way);
            }
            if (can_move(p, "right") && matrix.mat[p.y, p.x + 1] != "M ")
            {
                Way way = new Way(p.x + 1, p.y);
                if (matrix.mat[way.y, way.x] == "* ") { way.score++; }
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
                        if (matrix.mat[way.y,way.x] == "* ") { way.score += (1 / div); }
                        if (matrix.mat[way.y, way.x] == "M " && wayt.list.Count < safety)
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
                        if (matrix.mat[way.y, way.x] == "* ") { way.score += (1 / div); }
                        if (matrix.mat[way.y, way.x] == "M " && wayt.list.Count < safety) { fuite.Add(wayt.list[0]); }
                        way.list.Add("down");
                        way_list.Add(way);
                    }
                    if (can_move(wayt, "left") && wayt.list[wayt.list.Count - 1] != "right")
                    {
                        Way way = new Way(wayt);
                        way.x -= 1;
                        if (matrix.mat[way.y, way.x] == "* ") { way.score += (1 / div); }
                        if (matrix.mat[way.y, way.x] == "M " && wayt.list.Count < safety) { fuite.Add(wayt.list[0]); }
                        way.list.Add("left");
                        way_list.Add(way);
                    }
                    if (can_move(wayt, "right") && wayt.list[wayt.list.Count - 1] != "left")
                    {
                        Way way = new Way(wayt);
                        way.x += 1;
                        if (matrix.mat[way.y, way.x] == "* ") { way.score += (1 / div); }
                        if (matrix.mat[way.y, way.x] == "M " && wayt.list.Count < safety)
                        { fuite.Add(wayt.list[0]); }
                        way.list.Add("right");
                        way_list.Add(way);
                    }
                }
                way_list.RemoveRange(0, u);
                i++;
            }
            if (fuite.Count > 0 && supermode < fixe_safety - 1)
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
            goto start;
            game:
                p = new Pacman(0, 0);
                matrix = new Matrix();
                menu();
                init();
            start:
            bool unroll = false;
            int range = matrix.y_size + matrix.x_size;
            while (end() == false)
            {
                m1_move();
                if (matrix.size > 70) { m2_move(m2); }
                if (matrix.size > 140) { m2_move(m3); }
                matrix.display();
                if (p.x == m1.x && p.y == m1.y) { Console.WriteLine("Game Over"); break; }
                if (unroll == false)
                {
                    Console.WriteLine("Type < unroll > to unroll or press enter to go step by step");
                    string test = Console.ReadLine();
                    if (test == "unroll") { unroll = true; }
                }
                string way = best_way(range);
                move(way);
                if (supermode != 0) { supermode--; }
                p.previous = way;
                Console.WriteLine();
            }
            goto sortie;
            sortie:
                Console.WriteLine("End Game");
                Console.WriteLine("Type < close > to close or < again > to reset the game");
                string sortie = Console.ReadLine();
            if (sortie == "again") { goto game; }
            if (sortie == "close") { goto close; }
            else goto sortie;
            close: return;
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
