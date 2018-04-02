using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mousedrag
{
    public partial class Form1 : Form
    {
        Button btn = new Button();
        public bool a =true , b=true, c=true, d=true,pass = true;
        public int minx = 0, maxx = 500, miny = 0, maxy = 500;
        public Form1()
        {
            
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Width = 570;
            Height = 570;

            btn.Size = new Size(50, 50);
            btn.Text = "btn1";
            btn.Font = new Font(FontFamily.GenericSansSerif, 12);
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.BackColor = Color.Orange;
            btn.ForeColor = Color.White;
            Controls.Add(btn);
            Timer t = new Timer();
            t.Interval = 1;
            t.Tick += t_Tick;
            t.Start();
            
        }
        private void mouse_Move(object sender, MouseEventArgs e)
        {
            //Point a = e.Location;
            //btn.Location = new Point(a.X-25, a.Y-25);
        }
        private void t_Tick(object sender, EventArgs e)
        {
            Point ac = btn.Location;
            if (btn.Location.X==minx && btn.Location.Y == miny || pass == true)
            {
                d = true;
                a = false;
                maxy -= 50;
                BackColor = Color.Blue;
                pass = false;
            }
            else if (btn.Location.Y == maxy && btn.Location.X == minx)
            {
                a = true;
                b = false;
                maxy -= 50;
                BackColor = Color.Green;
            }
            else if (btn.Location.X == maxx && btn.Location.Y == maxy)
            {
                b = true;
                c = false;
                miny += 50;
                BackColor = Color.Yellow;
            }
            else if (btn.Location.Y == miny && btn.Location.X == maxx)
            {
                c = true;
                d = false;
                minx += 50;
                BackColor = Color.Red;
            }
            if (a == false)
            {
                ac.Y++;
            }
            else if (b == false)
            {
                ac.X++;
            }
            else if (c == false)
            {
                ac.Y--;
            }
            else if (d == false)
            {
                ac.X--;
            }
                btn.Location = ac;
        }

    }
}
