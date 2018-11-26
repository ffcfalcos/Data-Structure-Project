using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    sealed public class Matrix
    {
        public int y_size;
        public int x_size;
        public string[,] mat;
        public int max_score;
        public int size;

        public Matrix()
        {
            max_score = 0;
            size = 0;
        }

        public void creation_8x8()
        {
            string[,] mat = { { "P ", "* ", "* ", "* ", "* ", "* ", "* ", "* " }, { "* ", "- ", "* ", "- ", "* ", "- ", "- ", "* " }, { "* ", "- ", "* ", "* ", "* ", "* ", "* ", "* " }, { "* ", "- ", "* ", "- ", "* ", "- ", "* ", "- " }, { "* ", "* ", "* ", "* ", "* ", "- ", "* ", "* " }, { "* ", "- ", "- ", "- ", "* ", "- ", "- ", "* " }, { "* ", "- ", "* ", "* ", "* ", "- ", "* ", "* " }, { "* ", "* ", "* ", "- ", "* ", "* ", "* ", "- " } };
            this.mat = mat;
            count_matrix();
            y_size = mat.GetLength(0);
            x_size = mat.GetLength(1);
        }

        public void creation_14x12()
        {
            string[,] mat = { { "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* " }, { "* ", "- ", "- ", "* ", "- ", "- ", "* ", "- ", "* ", "- ", "- ", "* ", "- ", "* " }, { "* ", "- ", "* ", "* ", "* ", "- ", "* ", "* ", "* ", "- ", "- ", "* ", "* ", "* " }, { "* ", "* ", "* ", "- ", "* ", "- ", "* ", "- ", "- ", "- ", "* ", "* ", "- ", "* " }, { "* ", "- ", "- ", "- ", "* ", "* ", "* ", "* ", "* ", "- ", "* ", "- ", "- ", "* " }, { "* ", "* ", "* ", "* ", "* ", "- ", "- ", "- ", "* ", "* ", "* ", "* ", "* ", "* " }, { "* ", "- ", "* ", "- ", "* ", "* ", "* ", "* ", "* ", "- ", "- ", "- ", "- ", "* " }, { "* ", "- ", "* ", "- ", "- ", "- ", "* ", "- ", "* ", "* ", "* ", "* ", "* ", "* " }, { "* ", "* ", "* ", "- ", "* ", "* ", "* ", "- ", "* ", "- ", "* ", "- ", "- ", "* " }, { "* ", "- ", "* ", "* ", "* ", "- ", "* ", "* ", "* ", "- ", "* ", "* ", "- ", "* " }, { "* ", "- ", "- ", "- ", "- ", "- ", "* ", "- ", "* ", "- ", "- ", "* ", "- ", "* " }, { "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* ", "* " } };
            this.mat = mat;
            count_matrix();
            y_size = mat.GetLength(0);
            x_size = mat.GetLength(1);
            max_score--;
        }

        public void count_matrix()
        {
            foreach (string element in mat)
            {
                if (element == "* ") { max_score++; }
                size++;
            }
        }

        public void display()
        {
            for (int i = 0; i < y_size; i++)
            {
                for (int k = 0; k < x_size; k++)
                {
                    Console.Write(mat[i, k]);
                }
                Console.WriteLine();
            }
        }

        public int safety ()
        {
            return (y_size + x_size) / 4;
        }
    }
}
