using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*class Rect
    {
        public int w, h;
        //private int h;

    }*/
    class Program
    {
        static void Main(string[] args)
        {
            //Rect r = new Rect();
            //string s = Console.ReadLine();
            //string[] sos = s.Split(' ');
            int para;
            for (int i=0;i < args.Length; i++)
            {
                bool kek = true;
                para = int.Parse(args[i]);
                for (int j = 2; j < para; j++)
                {
                    if (para % j == 0)
                    {
                        kek = false;
                        break;
                    }
                }
                if (kek == true)
                {
                    Console.WriteLine(para); 
                }
            }
            Console.ReadKey();
        }
    }
}
