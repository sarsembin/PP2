using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidSnake
{
    class Point
    {
        int x, y;
        public Point(int cx,int cy)
        {
            x = cx;
            y = cy;
        }
    }
    class wall
    {
        public List<Point> coord_wall;
        public char stena;
        public ConsoleColor color;
        public wall()
        {
            stena = '#';
            coord_wall = new List<Point>();
            color = ConsoleColor.White;
        }
        public void LoadLevel(int level)
        {
            coord_wall.Clear();
            
            string path = string.Format(@"")
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
