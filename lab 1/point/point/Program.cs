using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace point
{
    class point
    {
        public int x;
        public int y;
        public point()
        {
            /*string po = Console.ReadLine();
            string[] sos = po.Split(' ');
            x = int.Parse(sos[0]);
            y = int.Parse(sos[1]);*/
            string sx = Console.ReadLine();
            x = int.Parse(sx);
            string sy = Console.ReadLine();
            y = int.Parse(sy);
        }
        public point(int hx, int hy)
        {
            x = hx;
            y = hy;
        }
        public override string ToString()
        {
            return x + "\n" + y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            point p = new point();
            // point p = new point(4,5);
            Console.WriteLine(p);
            Console.ReadKey();
        }
    }
}
