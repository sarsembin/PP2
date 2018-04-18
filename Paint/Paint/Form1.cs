using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public enum Tool { Pen, Rectangle, Erase, Line, Path, Ellipse, Mouse, Fill }

    public partial class Form1 : Form
    {
        Graphics g;
        Point prev, cur;
        GraphicsPath path;
        Pen pen;
        Bitmap btm;
        Color curColor;
        List<Point> path_p;
        int penWidth;
        Tool tools;
        string tool;

        
        public Form1()
        {
            InitializeComponent();

            curColor = Color.Black;
            penWidth = 1;
            pen = new Pen(curColor, penWidth);
            tools = Tool.Mouse;

            path = new GraphicsPath();

            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = btm;
            path_p = new List<Point>();

            g = Graphics.FromImage(btm);
            g.Clear(Color.White);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Colorbutton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            curColor = btn.BackColor;

            pen = new Pen(curColor, penWidth);
        }

        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            penWidth = trackBar1.Value;
            label1.Text = trackBar1.Value + "";

            pen = new Pen(curColor, penWidth);
        }
        

        
        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(pictureBox1.Width);
                int height = Convert.ToInt32(pictureBox1.Height);
                Bitmap bmp = new Bitmap(width, height);
                pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
            }
        }

        private void open_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(dialog.FileName);
                pictureBox1.Image = bmp;
            }
            pictureBox1.Refresh();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prev = e.Location;
        }

        private void tool_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            path_p.Clear();
            switch (btn.Text)
            {
                case "Pen":
                    tools = Tool.Pen;
                    break;
                case "Rectangle":
                    tools = Tool.Rectangle;
                    break;
                case "Line":
                    tools = Tool.Line;
                    break;
                case "Fill":
                    tools = Tool.Fill;
                    break;
                case "Path":
                    tools = Tool.Path;
                    break;
                case "Erase":
                    tools = Tool.Erase;
                    break;
                case "Mouse":
                    tools = Tool.Mouse;
                    break;
                case "Ellipse":
                    tools = Tool.Ellipse;
                    break;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (path != null)
            {
                g.DrawPath(pen, path);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(pen, path);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
                if (tools == Tool.Path)
                {
                    for (int i =0; i < path_p.Count - 1; i++)
                    {
                        path.AddLine(path_p[i], path_p[i + 1]);
                        pictureBox1.Refresh();
                    }
                    
                }
                pictureBox1.Refresh();
           
            switch (tools)
            {
                case Tool.Fill:
                    Color baseColor = new Color();
                    baseColor = btm.GetPixel(e.X, e.Y);
                    Queue<Point> q = new Queue<Point>();

                    q.Enqueue(new Point(e.X, e.Y));
                    btm.SetPixel(e.X, e.Y, pen.Color);
                    while (q.Count > 0)
                    {
                        Point cur = q.Dequeue();
                        if (cur.X + 1 < pictureBox1.Width && btm.GetPixel(cur.X + 1, cur.Y) == baseColor)
                        {
                            btm.SetPixel(cur.X + 1, cur.Y, pen.Color);
                            q.Enqueue(new Point(cur.X + 1, cur.Y));
                        }
                        if (cur.X - 1 > 0 && btm.GetPixel(cur.X - 1, cur.Y) == baseColor)
                        {
                            btm.SetPixel(cur.X - 1, cur.Y, pen.Color);
                            q.Enqueue(new Point(cur.X - 1, cur.Y));
                        }
                        if (cur.Y - 1 > 0 && btm.GetPixel(cur.X, cur.Y - 1) == baseColor)
                        {
                            btm.SetPixel(cur.X, cur.Y - 1, pen.Color);
                            q.Enqueue(new Point(cur.X, cur.Y - 1));
                        }
                        if (cur.Y + 1 < pictureBox1.Height && btm.GetPixel(cur.X, cur.Y + 1) == baseColor)
                        {
                            btm.SetPixel(cur.X, cur.Y + 1, pen.Color);
                            q.Enqueue(new Point(cur.X, cur.Y + 1));
                        }
                    }
                    pictureBox1.Refresh();
                    break;
                case Tool.Path:
                    prev = e.Location;
                    if (e.Button == MouseButtons.Left)
                    {
                        cur = e.Location;
                        path_p.Add(new Point(e.X, e.Y));
                        path.AddLine(prev, cur);
                        pictureBox1.Refresh();
                        /*for (int i = 0; i < path_p.Count - 1; i++)
                        {
                            path.AddLine(path_p[i], path_p[i + 1]);
                            pictureBox1.Refresh();
                        }*/
                    }
                    break;
            }
                    
                    
            
        }

        

        

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            path.Reset();

            if (e.Button == MouseButtons.Left)
            {
                cur = e.Location;
                
                switch (tools)
                {
                    case Tool.Mouse: // pass
                        break;
                    case Tool.Pen:
                        cur = e.Location;
                        g.DrawLine(pen, prev, cur);
                        prev = cur;

                        pictureBox1.Refresh();
                        break;
                    case Tool.Erase:
                        cur = e.Location;
                        Color buff = pen.Color;
                        pen.Color = Color.White;
                        g.DrawLine(pen, prev, cur);
                        prev = cur;
                        pen.Color = buff;

                        pictureBox1.Refresh();
                        break;
                    case Tool.Line:
                        cur = e.Location;
                        path.AddLine(prev, cur);

                        pictureBox1.Refresh();
                        break;
                    case Tool.Rectangle:
                        cur = e.Location;
                        if (cur.X >= prev.X && cur.Y >= prev.Y)
                        {
                            path.AddRectangle(new Rectangle(prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y));
                        }
                        else if (cur.X <= prev.X && cur.Y >= prev.Y)
                        {
                            path.AddRectangle(new Rectangle(cur.X, prev.Y, prev.X - cur.X , cur.Y - prev.Y));
                        }
                        else if (cur.X <= prev.X && cur.Y <= prev.Y)
                        {
                            path.AddRectangle(new Rectangle(cur.X, cur.Y, prev.X - cur.X, prev.Y - cur.Y));
                        }
                        else
                        {
                            path.AddRectangle(new Rectangle(prev.X, cur.Y, cur.X - prev.X, prev.Y - cur.Y));
                        }

                        pictureBox1.Refresh();
                        break;
                    case Tool.Ellipse:
                        cur = e.Location;
                        if (cur.X >= prev.X && cur.Y >= prev.Y)
                        {
                            path.AddEllipse(new Rectangle(prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y));
                        }
                        else if (cur.X <= prev.X && cur.Y >= prev.Y)
                        {
                            path.AddEllipse(new Rectangle(cur.X, prev.Y, prev.X - cur.X, cur.Y - prev.Y));
                        }
                        else if (cur.X <= prev.X && cur.Y <= prev.Y)
                        {
                            path.AddEllipse(new Rectangle(cur.X, cur.Y, prev.X - cur.X, prev.Y - cur.Y));
                        }
                        else
                        {
                            path.AddEllipse(new Rectangle(prev.X, cur.Y, cur.X - prev.X, prev.Y - cur.Y));
                        }

                        pictureBox1.Refresh();
                        break;
                    
                }

                
            }
        }

    }
}
