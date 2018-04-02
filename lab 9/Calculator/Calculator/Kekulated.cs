using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Kekulated
    {
        public double f_num = 0, s_num = 0, result = 0;
        public string operation = "";
        public void kekulate()
        {
            switch (operation)
            {
                case "+":
                    result = f_num + s_num;
                    break;
                case "-":
                    result = f_num - s_num;
                    break;
                case "x":
                    result = f_num * s_num;
                    break;
                case "/":
                    result = f_num / s_num;
                    break;
                case "x mod y":
                    result = f_num % s_num;
                    break;
                case "x^(1/y)":
                    result = Math.Pow(f_num, 1 / s_num);
                    break;
                case "x^y":
                    result = Math.Pow(f_num, s_num);
                    break;
                case "log x base y":
                    result = Math.Log(f_num, s_num);
                    break;
                
            }
        }
    }
}
