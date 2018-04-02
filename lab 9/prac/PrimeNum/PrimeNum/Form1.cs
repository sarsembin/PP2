using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeNum
{
    public partial class Form1 : Form
    {
        public TextBox t = new TextBox();
        public Label l = new Label();
        Font f = new Font(FontFamily.GenericSansSerif, 20);
        Color w = Color.White;
        public int a;
        public Form1()
        {
            
            InitializeComponent();
        }
        private void Form1_Load(object sender,EventArgs e)
        {
            Width = 300;
            Height = 300;

            t.Size = new Size(300, 50);
            t.Text = "";
            t.Location = new Point(0, 0);
            t.BackColor = Color.Gray;
            t.Font = f;
            t.ForeColor = w;
            Controls.Add(t);

            Button btn = new Button();
            btn.Size = new Size(50, 50);
            btn.Location = new Point(100, 50);
            btn.Click += button_Clicked;
            Controls.Add(btn);

            l.Size = new Size(300, 50);
            l.Text = "";
            l.Location = new Point(0, 100);
            l.BackColor = Color.Gray;
            l.Font = f;
            l.ForeColor = w;
            Controls.Add(l);


        }
        private void button_Clicked(object sender,EventArgs e)
        {
            bool da = false;
            if (t.Text == "") { }
            else
            {
                a = int.Parse(t.Text);
            }
            for (int i = 2; i < a; i++)
            {
                if (a % i == 0)
                {
                    l.Text = "NO";
                    da = true;
                }
            }
            if (da == false)
            {
                l.Text = "YES";
            }

        }
    }
}
