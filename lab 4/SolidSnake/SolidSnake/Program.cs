using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidSnake
{
    class Point
    {
        public int pos_x, pos_y;
    }
    class food
    {
        Point nyam;
        public food()
        {
            Random rnd = new Random();
            nyam.pos_x = rnd.Next
        }
    }
    class field
    {
        List<Point> pole;
        char sign = '+';
        public int x_size = 12, y_size = 12;
        public field()
        {
            int q = 0;
            for (int i = 0; i < x_size; i++)
            {
                for (int j = 0; j < y_size; j++)
                {
                    pole[q].pos_x = i;
                    pole[q].pos_y = j;
                    q++;
                }
            }
        }
        public void draw()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
