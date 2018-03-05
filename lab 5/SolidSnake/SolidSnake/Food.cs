using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SolidSnake
{
    [Serializable]
    public class Food
    {
        public Point location;
        public char sign;
        public ConsoleColor color;
        public Food()
        {
            sign = '@';
            color = ConsoleColor.Red;
            location = new Point();
        }
        public void SetRandomPosition(int shirina,int visota)
        {
            bool nevzmee = true;
            bool nevstene = true;
            while (true)
            {
                int x = new Random().Next(2, shirina);
                int y = new Random().Next(2, visota);
                for (int i = 0; i < Game.snake.body.Count; i++)
                {
                    if (x == Game.snake.body[i].x && y == Game.snake.body[i].y)
                    {
                        nevzmee = false;
                        break;
                    }
                }
                for (int i = 0; i < Game.wall.coord_wall.Count; i++)
                {
                    if (x == Game.wall.coord_wall[i].x && y == Game.wall.coord_wall[i].y)
                    {
                        nevstene = false;
                        break;
                    }
                }
                if (nevzmee == true && nevstene == true)
                {
                    location = new Point(x, y);
                    break;
                }
            }
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(location.x, location.y);
            Console.Write(sign);
        }
        public static void save()
        {
            FileStream fs = new FileStream(@"C:\Users\Daur\Desktop\c# kbtu pp 2\lab 5\SolidSnake\last_save_food.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Food));
            try
            {
                xs.Serialize(fs, Game.food);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        public static void load()
        {
            FileStream fs = new FileStream(@"C:\Users\Daur\Desktop\c# kbtu pp 2\lab 5\SolidSnake\last_save_food.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Food));
            try
            {
                Game.food = xs.Deserialize(fs) as Food;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
