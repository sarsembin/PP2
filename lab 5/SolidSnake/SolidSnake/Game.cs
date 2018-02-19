using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidSnake
{
    [Serializable]
    public class Game
    {
        public static snake snake;
        public static Food food;
        public static wall wall;
        public static bool GameOver;
        public static int score;
        public static int level;
        public static Point window_s;

        public Game()
        {
            score = 0;
            level = 0;
            snake = new snake();
        }
        public static void Init()
        {
            GameOver = false;
            Console.CursorVisible = false;
            window_s = new Point(70, 30);
            Console.SetWindowSize(window_s.x, window_s.y);
            food = new Food();
            wall = new wall();
        }
        public static  void draw_comments()
        {
            Console.SetCursorPosition(0, wall.visota + 1);
            Console.WriteLine("score: " + score);
            Console.WriteLine("level: " + level);
            Console.WriteLine("press Esc to leave");
            Console.WriteLine("press S to save the game");
        }
        public static void Draw()
        {
            Console.Clear();
            draw_comments();
            food.Draw();
            snake.Draw();
            wall.Draw();
        }
    }
}
