using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidSnake
{
    public class snake
    {
        public List<Point> body;
        public ConsoleColor color;
        public char myaso;
        public snake()
        {
            myaso = 'o';
            color = ConsoleColor.Green;
            body = new List<Point>();
            body.Add(new Point(2, 2));
            body.Add(new Point(3, 2));
            body.Add(new Point(4, 2));
            body.Add(new Point(5, 2));
        }
        public void Move(int dx, int dy)
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;
        }
        public bool CanEat()
        {
            if (body[body.Count-1].x == Game.food.location.x && body[body.Count-1].y == Game.food.location.y)
            {
                body.Add(new Point(body[body.Count - 1].x, body[body.Count - 1].y));
                return true;
            }
            return false;
        }
        public bool collision_wall()
        {
            for (int i = 0; i < Game.wall.coord_wall.Count; i++)
            {
                if (body[0].x==Game.wall.coord_wall[i].x && body[0].y == Game.wall.coord_wall[i].y)
                {
                    return true;
                }
            }
            return false;
        }
        public bool collision_snake()
        {
            for (int i = 4; i < body.Count; i++)
            {
                if (body[0].x==body[i].x && body[0].y == body[i].y)
                {
                    return true;
                }
            }
            return false;
        }
        public void collison_borders()
        {
            if (body[0].x >= Game.window_s.x)
            {
                body[0].x = 0;
            }
            else if (body[0].x <= 0)
            {
                body[0].x = Game.window_s.x-1;
            }
            if (body[0].y >= Game.window_s.y)
            {
                body[0].x = 0;
            }
            else if (body[0].y <= 0)
            {
                body[0].y = Game.window_s.y - 1;
            }
        }
        public void Draw()
        {
            int i = 0;
            foreach(Point p in body)
            {
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(p.x, p.y);
                    Console.Write(myaso);
                }
                else
                {
                    Console.ForegroundColor = color;
                    Console.SetCursorPosition(p.x, p.y);
                    Console.Write(myaso);
                }
                i++;
            }
        }
    }
}
