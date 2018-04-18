using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public partial class Form1 : Form
    {
        Graphics g;
        public List<Point> seed_a = new List<Point>();
        public List<Point> seed_s = new List<Point>();
        public List<Point> seed_slug = new List<Point>();
        public Point seed_ship;
        Label l = new Label();
        public int speed = 50, score = 0, live = 1;
        Timer t = new Timer();
        public bool respawn = true, fst = true;
        Random rnd = new Random();


        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();

            t.Interval = 100;
            t.Tick += t_Tick;

            l.Size = new Size(100, 50);
            l.Location = new Point(Width, 100);
            Controls.Add(l);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Width = 800;
            Height = 500;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            BackColor = Color.Black;

            l.Size = new Size(150, 25);
            l.Location = new Point(Width - (Width/4), 25);
            l.BackColor = Color.White;
            l.Font = new Font(FontFamily.GenericSansSerif, 10);

            seed_ship.X = this.Width / 2;
            seed_ship.Y = this.Height - (this.Height / 4);

            l.Text = "Press Any Key To Begin";
            Controls.Add(l);


        }

        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black,20);
            Pen yellowPen = new Pen(Color.Yellow, 5);

            SolidBrush blueBrush = new SolidBrush(Color.DeepSkyBlue);
            e.Graphics.FillRectangle(blueBrush, 10, 10, this.Width - 35, this.Height - 55);

            SolidBrush whiteBrush = new SolidBrush(Color.WhiteSmoke);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush yellowBrush = new SolidBrush(Color.Wheat);
            SolidBrush greenBrush = new SolidBrush(Color.Green);


            
            for(int i = 0; i < 10; i++)
            {
                if (fst == true)
                {
                    int X = rnd.Next(40, this.Width - 40);
                    int Y = rnd.Next(30, this.Height - 30);
                    seed_s.Add(new Point(X, Y));

                }
                e.Graphics.FillEllipse(whiteBrush, seed_s[i].X, seed_s[i].Y, 30, 30);
            }
            
            for (int i = 0; i < 4; i++)
            {
                if (fst == true)
                {
                    int X = rnd.Next(20, this.Width - 20);
                    int Y = rnd.Next(20, this.Height - 20);
                    seed_a.Add(new Point(X, Y));
                }
                Point[] a_p1 =
                {
                    new Point(seed_a[i].X,      seed_a[i].Y - 17),
                    new Point(seed_a[i].X + 15, seed_a[i].Y + 9),
                    new Point(seed_a[i].X - 15, seed_a[i].Y + 9)
                };
                Point[] a_p2 =
                {
                    new Point(seed_a[i].X,      seed_a[i].Y + 17),
                    new Point(seed_a[i].X + 15, seed_a[i].Y - 9),
                    new Point(seed_a[i].X - 15, seed_a[i].Y - 9)
                };
                e.Graphics.FillPolygon(redBrush, a_p1);
                e.Graphics.FillPolygon(redBrush, a_p2);
            }

            

            Point[] ship_p =
            {
                new Point (seed_ship.X, seed_ship.Y - 20),
                new Point (seed_ship.X + 20, seed_ship.Y - 10),
                new Point (seed_ship.X + 20, seed_ship.Y + 10),
                new Point (seed_ship.X, seed_ship.Y + 20),
                new Point (seed_ship.X - 20, seed_ship.Y + 10),
                new Point (seed_ship.X - 20, seed_ship.Y - 10),
            };
            Point[] gun_p =
            {
                new Point (seed_ship.X, seed_ship.Y - 10),
                new Point (seed_ship.X + 10, seed_ship.Y),
                new Point (seed_ship.X + 5, seed_ship.Y),
                new Point (seed_ship.X + 5, seed_ship.Y + 10),
                new Point (seed_ship.X - 5, seed_ship.Y + 10),
                new Point (seed_ship.X - 5, seed_ship.Y),
                new Point (seed_ship.X - 10, seed_ship.Y),
            };
            e.Graphics.FillPolygon(yellowBrush, ship_p);
            e.Graphics.FillPolygon(greenBrush, gun_p);

            if (seed_slug.Count > 0)
            {
                for (int i = 0; i < seed_slug.Count; i++)
                {
                    Point[] slug_p =
                    {
                    new Point(seed_slug[i].X, seed_slug[i].Y - 9),
                    new Point(seed_slug[i].X + 3, seed_slug[i].Y - 3),
                    new Point(seed_slug[i].X + 9, seed_slug[i].Y),
                    new Point(seed_slug[i].X + 3, seed_slug[i].Y + 3),
                    new Point(seed_slug[i].X, seed_slug[i].Y + 9),
                    new Point(seed_slug[i].X - 3, seed_slug[i].Y + 3),
                    new Point(seed_slug[i].X - 9, seed_slug[i].Y),
                    new Point(seed_slug[i].X - 3, seed_slug[i].Y - 3)
                };
                    e.Graphics.FillPolygon(greenBrush, slug_p);
                }
            }
            

            e.Graphics.DrawRectangle(blackPen, 0, 0, this.Width-15, this.Height-35);
            e.Graphics.DrawRectangle(yellowPen, Width-(Width/4), 25, 150, 25);
            fst = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 'A':
                    seed_ship.X -= 10;
                    this.Invalidate();
                    break;
                case 'D':
                    seed_ship.X += 10;
                    this.Invalidate();
                    break;
                case 'S':
                    seed_ship.Y += 10;
                    this.Invalidate();
                    break;
                case 'W':
                    seed_ship.Y -= 10;
                    this.Invalidate();
                    break;
                case 'E':
                    seed_slug.Add(new Point(seed_ship.X, seed_ship.Y + 10));
                    break;
            }
        }
        private void t_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                Point p = seed_a[i];
                p.Y += 10;
                if (p.Y > this.Width-200)
                {
                    p.Y = rnd.Next(-50, 0);
                }
                seed_a[i] = p;
            }
            if (seed_slug.Count > 0)
            {
                for (int i = 0; i < seed_slug.Count; i++)
                {
                    Point p = seed_slug[i];
                    p.Y -= 50;
                    seed_slug[i] = p;
                    if (p.Y < -10)
                    {
                        seed_slug.Remove(seed_slug[i]);
                    }
                }
            }
            this.Invalidate();
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case ' ':
                    l.Font = new Font(FontFamily.GenericSansSerif, 9);
                    l.Text = "Speed: " + speed + " Score: " + score + " Live: " + live;
                    t.Start();
                    break;
            }
        }
    }
}
