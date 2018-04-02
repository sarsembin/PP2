using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evade
{
    public partial class Form1 : Form
    {
        Label l = new Label();
        public List<Label> rock;
        Timer t = new Timer();


        public Form1()
        {
            InitializeComponent();
            rock = new List<Label>();
            Point p = new Point();
            Random rnd = new Random();
            for (int i = 0; i < 15; i++)
            {
                Label lb = new Label();
                lb.Size = new Size(25, 25);
                lb.Text = "";
                lb.BackColor = Color.SeaShell;
                rock.Add(lb);

                p.X = rnd.Next(0, Width - 25);
                p.Y = rnd.Next(-400, -25);
                rock[i].Location = p;

                Controls.Add(rock[i]);
            }

            t.Interval = 50;
            t.Tick += t_Tick;
            t.Enabled = true;
            //this.t = new System.Windows.Forms.Timer(this.components);
            t.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Width = 500;
            Height = 500;
            BackColor = Color.SandyBrown;

            l.Size = new Size(75,20);
            l.Location = new Point(200, 350);
            l.BackColor = Color.DeepSkyBlue;
            l.Font = new Font(FontFamily.GenericSansSerif, 12);
            l.Text = "";
            Controls.Add(l);

}

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            Point p = l.Location;
            switch (e.KeyValue)
            {
                case 'A':
                    p.X -= 5 ;
                    break;
                case 'D':
                    p.X += 5;
                    break;
            }
            if (p.X < -l.Width)
            {
                p.X = Width;
            }
            else if (p.X > Width)
            {
                p.X = 0;
            }
            l.Location = p;
        }
        private void t_Tick(object sender, EventArgs e)
        {
            Random rnd1 = new Random();
            Point pos = new Point();
            for (int i = 0; i < 15; i++)
            {
                
                pos = rock[i].Location;
                pos.Y += 5;
                if (pos.Y > Height + 25)
                {
                    pos.X = rnd1.Next(0, Width);
                    pos.Y = rnd1.Next(-300, -25);
                }
                if ((pos.Y + 25 > l.Location.Y && pos.Y < l.Location.Y + 25) && (pos.X + 25 > l.Location.X && pos.X + 25 < l.Location.X + 75))
                {
                    l.Text = "You Lost";
                }
                if ((pos.Y + 25 > l.Location.Y && pos.Y < l.Location.Y + 25) && (pos.X > l.Location.X && pos.X < l.Location.X + 75))
                {
                    l.Text = "You Lost";
                }
                rock[i].Location = pos;
            }
        }
    }
}
