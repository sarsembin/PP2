using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxi_and_mini_from_file
{
    class Read
    {
        public int mini = 1000000;
        public void maximin()
        {
            FileStream fs = new FileStream(@"C:\Users\Daur\Desktop\c# kbtu pp 2\lab 2\nums.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadLine();
            string[] sos = s.Split(' ');
            for (int i = 0; i < sos.Length; i++)
            {
                int n = int.Parse(sos[i]);
                bool da = true;
                if (n > 0)
                {
                    for (int j = 2; j < n; j++)
                    {
                        if (n % j == 0)
                        {
                            da = false;
                        }
                    }
                }
                else if (n < 0)
                {
                    for (int j = -2; j > n; j--)
                    {
                        if (n % j == 0)
                        {
                            da = false;
                        }
                    }
                }
                if (n < mini && da==true)
                {
                    mini = n;
                }
            }
            fs.Close();
            sr.Close();
        }
        class Program
        {
            static void Main(string[] args)
            {
                Read r = new Read();
                r.maximin();
                Console.WriteLine("Min Prime " + r.mini);
                Console.ReadKey();
            }
        }
    }
}
