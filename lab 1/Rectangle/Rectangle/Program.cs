using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle
{
    class Rect
    {
        public int width;
        public int height;
        public int S;
        public int P;
        public Rect()
        {
            string w = Console.ReadLine();
            width = int.Parse(w);
            string h = Console.ReadLine();
            height = int.Parse(h);
        }
        public int Area()
        {
            S = width * height;
            return S;
        }
        public int Perim()
        {
            P = 2 * (width + height);
            return P;
        }
        public override string ToString()
        {
            return width+"\n"+height+"\n" + S + "\n" + P;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rect r = new Rect();
            r.Perim();
            r.Area();
            Console.WriteLine(r);
            Console.ReadKey();
        }
    }
}
