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
            for (int i=0;i < args.Length; i++)// цикл для читания с args
            {
                bool kek = true;// это как индикатор простого числа
                para = int.Parse(args[i]);// парсим число
                for (int j = 2; j < para; j++)// проверка на прайм
                {
                    if (para % j == 0)
                    {
                        kek = false;// если фолс тогда не прайм
                        break;
                    }
                }
                if (kek == true)// если тру тогда прайм
                {
                    Console.WriteLine(para);// выводим
                }
            }
            Console.ReadKey();// это для того что бы сразу не закрывалось
        }
    }
}
