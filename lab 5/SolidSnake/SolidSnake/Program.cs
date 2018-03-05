using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SolidSnake
{
    public class Point
    {
        public int x, y;
        public Point()
        {

        }
        public Point(int cx,int cy)
        {
            x = cx;
            y = cy;
        }
    }
    
    class Program
    {
        static string naprav = "Right";
        static string buff = "Right";
        static int speed = 200;
        static bool leave = false;
        static bool saved = false;

        static void Drawer(object state)
        {
            while (!Game.GameOver)
            {
                if (saved == true)
                {
                    saved = false;
                    Console.ReadKey();
                }
                switch (naprav)
                {
                    case "Right":
                        Game.snake.Move(1, 0);
                        break;
                    case "Left":
                        Game.snake.Move(-1, 0);
                        break;
                    case "Up":
                        Game.snake.Move(0, -1);
                        break;
                    case "Down":
                        Game.snake.Move(0, 1);
                        break;
                }
                if (Game.snake.CanEat() == true)
                {
                    Game.food.SetRandomPosition(Game.wall.shirina - 2, Game.wall.visota - 2);
                    Game.score++;
                }
                if (Game.snake.collision_wall() || Game.snake.collision_snake())
                {
                    Game.GameOver = true;
                }
                
                if (Game.score!=0 && Game.score % 10 == 0)
                {
                    Game.level = 1;
                    Console.Clear();
                    Console.WriteLine("New level, you get 1 additional point");
                    Console.WriteLine("Get Ready");
                    Console.WriteLine("Press Any Key To Continue");
                    Console.ReadKey();
                    Game.score++;
                    Game.wall.LoadLevel(Game.level);
                }
                Game.Draw();
                Thread.Sleep(speed);
            }
        }
        static void Main(string[] args)
        {
            Game main_g = new Game();
            Console.WriteLine("Welcome");
            Console.WriteLine("To Load last save press L");
            Console.WriteLine("To start a new game press any other Key");
            ConsoleKeyInfo butt = Console.ReadKey();
            switch (butt.Key)
            {
                case ConsoleKey.L:
                    Game.load();
                    break;
            }
            Game.Init();
            Game.wall.LoadLevel(Game.level);
            Thread t = new Thread(Drawer);
            t.Start();
            Game.food.SetRandomPosition(Game.wall.shirina - 2, Game.wall.visota - 2);
            while (Game.GameOver == false)
            {
                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        naprav = "Up";
                        if (buff == "Down")
                        {
                            naprav = buff;
                        }
                        else buff = "Up";
                        break;
                    case ConsoleKey.RightArrow:
                        naprav = "Right";
                        if (buff == "Left")
                        {
                            naprav = buff;
                        }
                        else buff = "Right";
                        break;
                    case ConsoleKey.LeftArrow:
                        naprav = "Left";
                        if (buff == "Right")
                        {
                            naprav = buff;
                        }
                        else buff = "Left";
                        break;
                    case ConsoleKey.DownArrow:
                        naprav = "Down";
                        if (buff == "Up")
                        {
                            naprav = buff;
                        }
                        else buff = "Down";
                        break;
                    case ConsoleKey.Escape:
                        Game.GameOver = true;
                        leave = true;
                        break;
                    case ConsoleKey.S:

                        Game.save();
                        Console.SetCursorPosition(0, Game.wall.visota + 5);
                        Console.WriteLine("Game Successfully Saved");
                        Console.WriteLine("Press Any Key To Continue");
                        // dlya pauzy
                        saved = true;
                        break;
                }
            }
            Console.Clear();
            if (leave == false)
            {
                Console.WriteLine("You Lost, Bad Luck");
            }
            Console.WriteLine("Bye Bye");
            Console.ReadKey();
        }
    }
}
