using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidSnake
{
    public class wall
    {
        public List<Point> coord_wall;
        public char stena;
        public ConsoleColor color;
        public int shirina;
        public int visota;
        public wall()
        {
            stena = '#';
            coord_wall = new List<Point>();
            color = ConsoleColor.White;
        }
        public void LoadLevel(int level)
        {
            coord_wall.Clear();

            string path = string.Format(@"C:\Users\Daur\Desktop\c# kbtu pp 2\lab 5\SolidSnake\level{0}.txt", level);
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string pole = sr.ReadToEnd();
            string[] lines = pole.Split('\n');
            shirina = lines[0].Length;
            visota = lines.Length;
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '#')
                    {
                        coord_wall.Add(new Point(j, i));
                    }
                }
            }
            sr.Close();
            fs.Close();
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in coord_wall)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(stena);
            }
        }
    }
}
