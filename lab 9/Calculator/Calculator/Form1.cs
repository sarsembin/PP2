using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Kekulated kek = new Kekulated();
        public Label nums_win = new Label();
        public bool proshali = false;
        public bool pervy = true;
        public double coef = 1;
        public double sec_num_uni = 0;

        Button btn_rd = new Button();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Width = 365;
            Height = 390;
            //FormBorderStyle = FormBorderStyle.FixedSingle;
            BackColor = Color.Black;
            int num_txt = 1;

            // label 
            nums_win.Size = new Size(350, 50);
            nums_win.Text = "0";
            nums_win.TextAlign = ContentAlignment.MiddleRight;
            nums_win.Location = new Point(0, 0);
            nums_win.Font = new Font(FontFamily.GenericSansSerif, 30);
            nums_win.BackColor = Color.Gray;
            nums_win.ForeColor = Color.White;
            Controls.Add(nums_win);

            // knopoka 1-9
            for (int i = 5; i >= 3; i--)
            {
                for (int j= 0; j < 3; j++)
                {
                    Button btn = new Button();
                    btn.Text = num_txt.ToString();
                    btn.Size = new Size(50, 50);
                    btn.Font = new Font(FontFamily.GenericSansSerif, 20);
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.Black;
                    btn.Location = new Point(j * 50, i * 50);
                    btn.Click += nums_Click;
                    Controls.Add(btn);
                    num_txt++;
                }
            }
            // knopoka 0
            Button btn0 = new Button();
            btn0.Text = "0";
            btn0.Size = new Size(50, 50);
            btn0.Font = new Font(FontFamily.GenericSansSerif, 20);
            btn0.Location = new Point(50,300);
            btn0.BackColor = Color.White;
            btn0.ForeColor = Color.Black;
            btn0.Click += nums_Click;
            Controls.Add(btn0);
            // knopoka +/-
            Button btn_zn = new Button();
            btn_zn.Text = "+/-";
            btn_zn.Size = new Size(50, 50);
            btn_zn.Font = new Font(FontFamily.GenericSansSerif, 15);
            btn_zn.BackColor = Color.White;
            btn_zn.ForeColor = Color.Black;
            btn_zn.Location = new Point(0, 300);
            btn_zn.Click += znak_Click;
            Controls.Add(btn_zn);
            // knopoka .
            Button btn_dt = new Button();
            btn_dt.Text = ",";
            btn_dt.Size = new Size(50, 50);
            btn_dt.Font = new Font(FontFamily.GenericSansSerif, 20);
            btn_dt.BackColor = Color.White;
            btn_dt.ForeColor = Color.Black;
            btn_dt.Location = new Point(100, 300);
            btn_dt.Click += dot_Click;
            Controls.Add(btn_dt);
            // knopoka operator
            string[] ops = { "/","x","-","+" };
            for (int i = 2; i <= 5; i++)
            {
                Button btn = new Button();
                btn.Text = ops[i-2];
                btn.Size = new Size(50, 50);
                btn.Font = new Font(FontFamily.GenericSansSerif, 20);
                btn.BackColor = Color.Orange;
                btn.ForeColor = Color.White;
                btn.Location = new Point(150, i*50);
                btn.Click += operation_Click;
                Controls.Add(btn);
            }
            // knopoka =
            Button btn_eq = new Button();
            btn_eq.Text = "=";
            btn_eq.Size = new Size(100, 50);
            btn_eq.Font = new Font(FontFamily.GenericSansSerif, 20);
            btn_eq.BackColor = Color.Orange;
            btn_eq.ForeColor = Color.White;
            btn_eq.Location = new Point(150, 300);
            btn_eq.Click += result_Click;
            Controls.Add(btn_eq);
            // knopoka AC
            Button btn_ac = new Button();
            btn_ac.Text = "AC";
            btn_ac.Size = new Size(50, 50);
            btn_ac.Font = new Font(FontFamily.GenericSansSerif, 15);
            btn_ac.BackColor = Color.White;
            btn_ac.ForeColor = Color.Black;
            btn_ac.Location = new Point(0, 100);
            btn_ac.Click += ac_Click;
            Controls.Add(btn_ac);
            // knopoka C
            Button btn_c = new Button();
            btn_c.Text = "C";
            btn_c.Size = new Size(50, 50);
            btn_c.Font = new Font(FontFamily.GenericSansSerif, 15);
            btn_c.BackColor = Color.White;
            btn_c.ForeColor = Color.Black;
            btn_c.Location = new Point(50, 100);
            btn_c.Click += c_Click;
            Controls.Add(btn_c);
            // knopoka <-
            Button btn_bk = new Button();
            btn_bk.Size = new Size(50, 50);
            btn_bk.Font = new Font(FontFamily.GenericSansSerif, 15);
            btn_bk.BackColor = Color.White;
            btn_bk.ForeColor = Color.Black;
            btn_bk.Text = "<-";
            btn_bk.Location = new Point(100, 100);
            btn_bk.Click += backspace_Click;
            Controls.Add(btn_bk);
            // knopoka x^2
            Button btn_pw = new Button();
            btn_pw.Size = new Size(50, 50);
            btn_pw.Font = new Font(FontFamily.GenericSansSerif, 15);
            btn_pw.BackColor = Color.White;
            btn_pw.ForeColor = Color.Black;
            btn_pw.Text = "x^2";
            btn_pw.Location = new Point(200, 100);
            btn_pw.Click += power2_Click;
            Controls.Add(btn_pw);
            // knopoka sqrt
            Button btn_sq = new Button();
            btn_sq.Size = new Size(50, 50);
            btn_sq.Font = new Font(FontFamily.GenericSansSerif, 13);
            btn_sq.BackColor = Color.White;
            btn_sq.ForeColor = Color.Black;
            btn_sq.Text = "sqrt";
            btn_sq.Location = new Point(200, 150);
            btn_sq.Click += sqrt_Click;
            Controls.Add(btn_sq);
            // knopoka 1/x
            Button btn_div = new Button();
            btn_div.Size = new Size(50, 50);
            btn_div.Font = new Font(FontFamily.GenericSansSerif, 13);
            btn_div.BackColor = Color.White;
            btn_div.ForeColor = Color.Black;
            btn_div.Text = "1/x";
            btn_div.Location = new Point(200, 200);
            btn_div.Click += div1_Click;
            Controls.Add(btn_div);
            // knopoka %
            Button btn_per = new Button();
            btn_per.Size = new Size(50, 50);
            btn_per.Font = new Font(FontFamily.GenericSansSerif, 13);
            btn_per.BackColor = Color.White;
            btn_per.ForeColor = Color.Black;
            btn_per.Text = "%";
            btn_per.Location = new Point(200, 250);
            btn_per.Click += percent_Click;
            Controls.Add(btn_per);
            // knopoka ms
            Button btn_ms = new Button();
            btn_ms.Size = new Size(50, 50);
            btn_ms.Font = new Font(FontFamily.GenericSansSerif, 13);
            btn_ms.BackColor = Color.White;
            btn_ms.ForeColor = Color.Black;
            btn_ms.Text = "MS";
            btn_ms.Location = new Point(0, 50);
            btn_ms.Click += ms_Click;
            Controls.Add(btn_ms);
            // knopoka mc
            Button btn_mc = new Button();
            btn_mc.Size = new Size(50, 50);
            btn_mc.Font = new Font(FontFamily.GenericSansSerif, 13);
            btn_mc.BackColor = Color.White;
            btn_mc.ForeColor = Color.Black;
            btn_mc.Text = "MC";
            btn_mc.Location = new Point(50, 50);
            btn_mc.Click += mc_Click;
            Controls.Add(btn_mc);
            // knopoka mr
            Button btn_mr = new Button();
            btn_mr.Size = new Size(50, 50);
            btn_mr.Font = new Font(FontFamily.GenericSansSerif, 13);
            btn_mr.BackColor = Color.White;
            btn_mr.ForeColor = Color.Black;
            btn_mr.Text = "MR";
            btn_mr.Location = new Point(100, 50);
            btn_mr.Click += mr_Click;
            Controls.Add(btn_mr);
            // knopoka m+
            Button btn_mp = new Button();
            btn_mp.Size = new Size(50, 50);
            btn_mp.Font = new Font(FontFamily.GenericSansSerif, 13);
            btn_mp.BackColor = Color.White;
            btn_mp.ForeColor = Color.Black;
            btn_mp.Text = "M+";
            btn_mp.Location = new Point(150, 50);
            btn_mp.Click += mp_Click;
            Controls.Add(btn_mp);
            // knopoka m-
            Button btn_mm = new Button();
            btn_mm.Size = new Size(50, 50);
            btn_mm.Font = new Font(FontFamily.GenericSansSerif, 13);
            btn_mm.BackColor = Color.White;
            btn_mm.ForeColor = Color.Black;
            btn_mm.Text = "M-";
            btn_mm.Location = new Point(200, 50);
            btn_mm.Click += mm_Click;
            Controls.Add(btn_mm);
            // knopoka ! factorial
            Button btn_fact = new Button();
            btn_fact.Size = new Size(50, 50);
            btn_fact.Font = new Font(FontFamily.GenericSansSerif, 13);
            btn_fact.BackColor = Color.White;
            btn_fact.ForeColor = Color.Black;
            btn_fact.Text = "x!";
            btn_fact.Location = new Point(250, 50);
            btn_fact.Click += fact_Click;
            Controls.Add(btn_fact);
            // knopoka e power x
            Button btn_epowx = new Button();
            btn_epowx.Size = new Size(50, 50);
            btn_epowx.Font = new Font(FontFamily.GenericSansSerif, 13);
            btn_epowx.BackColor = Color.White;
            btn_epowx.ForeColor = Color.Black;
            btn_epowx.Text = "e^x";
            btn_epowx.Location = new Point(250, 100);
            btn_epowx.Click += e_pow_x_Click;
            Controls.Add(btn_epowx);
            // knopoka x mod y
            Button btn_mod = new Button();
            btn_mod.Size = new Size(50, 50);
            btn_mod.Font = new Font(FontFamily.GenericSansSerif, 9);
            btn_mod.BackColor = Color.White;
            btn_mod.ForeColor = Color.Black;
            btn_mod.Text = "x mod y";
            btn_mod.Location = new Point(250, 150);
            btn_mod.Click += operation_Click;
            Controls.Add(btn_mod);
            // knopoka x pow 1/y
            Button btn_xpow1y = new Button();
            btn_xpow1y.Size = new Size(50, 50);
            btn_xpow1y.Font = new Font(FontFamily.GenericSansSerif, 9);
            btn_xpow1y.BackColor = Color.White;
            btn_xpow1y.ForeColor = Color.Black;
            btn_xpow1y.Text = "x^(1/y)";
            btn_xpow1y.Location = new Point(250, 200);
            btn_xpow1y.Click += operation_Click;
            Controls.Add(btn_xpow1y);
            // knopoka x pow y
            Button btn_xpowy = new Button();
            btn_xpowy.Size = new Size(50, 50);
            btn_xpowy.Font = new Font(FontFamily.GenericSansSerif, 13);
            btn_xpowy.BackColor = Color.White;
            btn_xpowy.ForeColor = Color.Black;
            btn_xpowy.Text = "x^y";
            btn_xpowy.Location = new Point(250, 250);
            btn_xpowy.Click += operation_Click;
            Controls.Add(btn_xpowy);
            // knopoka log x base y
            Button btn_xlogy = new Button();
            btn_xlogy.Size = new Size(100, 50);
            btn_xlogy.Font = new Font(FontFamily.GenericSansSerif, 12);
            btn_xlogy.BackColor = Color.White;
            btn_xlogy.ForeColor = Color.Black;
            btn_xlogy.Text = "log x base y";
            btn_xlogy.Location = new Point(250, 300);
            btn_xlogy.Click += operation_Click;
            Controls.Add(btn_xlogy);
            // knopoka e
            Button btn_e = new Button();
            btn_e.Size = new Size(50, 50);
            btn_e.Font = new Font(FontFamily.GenericSansSerif, 15);
            btn_e.BackColor = Color.White;
            btn_e.ForeColor = Color.Black;
            btn_e.TextAlign = ContentAlignment.MiddleCenter;
            btn_e.Text = "e num";
            btn_e.Location = new Point(300, 250);
            btn_e.Click += e_Click;
            Controls.Add(btn_e);
            // knopoka rad or deg
            btn_rd.Size = new Size(50, 50);
            btn_rd.Font = new Font(FontFamily.GenericSansSerif, 13);
            btn_rd.BackColor = Color.White;
            btn_rd.ForeColor = Color.Black;
            btn_rd.TextAlign = ContentAlignment.MiddleCenter;
            btn_rd.Text = "rad";
            btn_rd.Location = new Point(300, 50);
            btn_rd.Click += rd_Click;
            Controls.Add(btn_rd);
            // knopoka sin
            Button btn_sin = new Button();
            btn_sin.Size = new Size(50, 50);
            btn_sin.Font = new Font(FontFamily.GenericSansSerif, 13);
            btn_sin.BackColor = Color.White;
            btn_sin.ForeColor = Color.Black;
            btn_sin.TextAlign = ContentAlignment.MiddleCenter;
            btn_sin.Text = "sin";
            btn_sin.Location = new Point(300, 100);
            btn_sin.Click += sin_Click;
            Controls.Add(btn_sin);
            // knopoka cos
            Button btn_cos = new Button();
            btn_cos.Size = new Size(50, 50);
            btn_cos.Font = new Font(FontFamily.GenericSansSerif, 13);
            btn_cos.BackColor = Color.White;
            btn_cos.ForeColor = Color.Black;
            btn_cos.TextAlign = ContentAlignment.MiddleCenter;
            btn_cos.Text = "cos";
            btn_cos.Location = new Point(300, 150);
            btn_cos.Click += cos_Click;
            Controls.Add(btn_cos);
            // knopoka tan
            Button btn_tan = new Button();
            btn_tan.Size = new Size(50, 50);
            btn_tan.Font = new Font(FontFamily.GenericSansSerif, 13);
            btn_tan.BackColor = Color.White;
            btn_tan.ForeColor = Color.Black;
            btn_tan.TextAlign = ContentAlignment.MiddleCenter;
            btn_tan.Text = "tan";
            btn_tan.Location = new Point(300, 200);
            btn_tan.Click += tan_Click;
            Controls.Add(btn_tan);
        }
        private void nums_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            // dlya ne ischeznovenya znakov posle knopki operatora
            if (proshali == true)
            {
                nums_win.Text = "";
                proshali = false;
            }
            // dlya noley v nachale i ih ischezainia
            if (pervy == true)
            {
                nums_win.Text = "0";
            }
            if (btn.Text == "0" && pervy == true && nums_win.Text[0] == '0')
            {
                nums_win.Text = nums_win.Text.Remove(0, 1);
            }
            else if (pervy == true && nums_win.Text[0] == '0')
            {
                nums_win.Text = nums_win.Text.Remove(0,1);
                pervy = false;
            }
            if (nums_win.Text.Length > 14) {/* pass */}
            else
            {
                nums_win.Text = nums_win.Text + btn.Text;
            }
        }
        private void operation_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            kek.f_num = double.Parse(nums_win.Text);
            kek.operation = btn.Text;
            proshali = true;

        }
        private void result_Click(object sender, EventArgs e)
        {
            sec_num_uni = kek.s_num;
            kek.s_num = double.Parse(nums_win.Text);
            kek.kekulate();
            kek.f_num = sec_num_uni;

            nums_win.Text = kek.result.ToString();
            pervy = true;
            
            
        }
        private void dot_Click(object sender, EventArgs e)
        {
            if (nums_win.Text.Contains(",")) {/* pass*/}
            else nums_win.Text += ",";
        }
        private void znak_Click(object sender, EventArgs e)
        {
            if (nums_win.Text[0] != '-')
            {
                nums_win.Text = "-" + nums_win.Text;
            }
            else
            {
                nums_win.Text = nums_win.Text.Remove(0, 1);
            }
        }
        private void ac_Click(object sender, EventArgs e)
        {
            nums_win.Text = "0";
            kek.f_num = 0;
            kek.s_num = 0;
            kek.result = 0;
            kek.operation = "";
            pervy = true;
        }
        private void c_Click(object sender, EventArgs e)
        {
            nums_win.Text = "0";
            kek.s_num = 0;
            pervy = true;
        }
        private void backspace_Click(object sender, EventArgs e)
        {
            if (nums_win.Text.Length == 1)
            {
                nums_win.Text = "0";
                pervy = true;
            }
            else if (nums_win.Text[0] == '0' && nums_win.Text.Length==1)
            {
                // pass
            }
            else if (nums_win.Text[nums_win.Text.Length-2] == ',')
            {
                nums_win.Text = nums_win.Text.Remove(nums_win.Text.Length - 2, 2);
            }
            else
            {
                nums_win.Text = nums_win.Text.Remove(nums_win.Text.Length - 1, 1);
            }
        }
        private void power2_Click(object sender, EventArgs e)
        {
            double a = double.Parse(nums_win.Text);
            nums_win.Text = (a * a).ToString();
        }
        private void sqrt_Click(object sender, EventArgs e)
        {
            double a = double.Parse(nums_win.Text);
            nums_win.Text = Math.Sqrt(a).ToString();
        }
        private void div1_Click(object sender, EventArgs e)
        {
            double a = double.Parse(nums_win.Text);
            if (a == 0){ /*pass*/ }
            else nums_win.Text = (1/a).ToString();
        }
        private void percent_Click(object sender, EventArgs e)
        {
            double a = double.Parse(nums_win.Text);
            nums_win.Text = (a/100).ToString();
        }
        private void ms_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"C:\Users\Daur\Desktop\c# kbtu pp 2\lab 9\Calculator\memory.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(nums_win.Text);
            sw.Close();
            fs.Close();
        }
        private void mc_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"C:\Users\Daur\Desktop\c# kbtu pp 2\lab 9\Calculator\memory.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Close();
            fs.Close();
        }
        private void mr_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"C:\Users\Daur\Desktop\c# kbtu pp 2\lab 9\Calculator\memory.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            nums_win.Text = sr.ReadLine();
            sr.Close();
            fs.Close();
        }
        private void mp_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"C:\Users\Daur\Desktop\c# kbtu pp 2\lab 9\Calculator\memory.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            double a = double.Parse(sr.ReadLine());
            double b = double.Parse(nums_win.Text);
            sr.Close();
            fs.Close();
            FileStream fsc = new FileStream(@"C:\Users\Daur\Desktop\c# kbtu pp 2\lab 9\Calculator\memory.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fsc);
            sw.WriteLine(a + b);
            sw.Close();
            fsc.Close();
        }
        private void mm_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"C:\Users\Daur\Desktop\c# kbtu pp 2\lab 9\Calculator\memory.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            double a = double.Parse(sr.ReadLine());
            double b = double.Parse(nums_win.Text);
            sr.Close();
            fs.Close();
            FileStream fsc = new FileStream(@"C:\Users\Daur\Desktop\c# kbtu pp 2\lab 9\Calculator\memory.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fsc);
            sw.WriteLine(a - b);
            sw.Close();
            fsc.Close();
        }
        private void fact_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(nums_win.Text);
                if (a < 0) { /* pass */ }
                else
                {
                    int b = 1;
                    for (int i = 1; i <= a; i++)
                    {
                        b *= i;
                    }
                    nums_win.Text = b + "";
                }
            }
            catch
            {
                /*pass*/
            }
            finally { /* pass */ }
        }
        private void e_pow_x_Click (object sender, EventArgs e)
        {
            nums_win.Text = Math.Pow(Math.E, double.Parse(nums_win.Text)) + "";
        }
        private void e_Click(object sender, EventArgs e)
        {
            nums_win.Text = Math.E + "";
        }
        private void rd_Click(object sender, EventArgs e)
        {
            if (btn_rd.Text == "rad")
            {
                coef = Math.PI / 180;
                btn_rd.Text = "deg";
            }
            else if (btn_rd.Text == "deg")
            {
                coef = 1;
                btn_rd.Text = "rad";
            }
        }
        private void sin_Click(object sender, EventArgs e)
        {
            nums_win.Text = Math.Sin(double.Parse(nums_win.Text) * coef) + "";
        }
        private void cos_Click(object sender, EventArgs e)
        {
            nums_win.Text = Math.Cos(double.Parse(nums_win.Text) * coef) + "";
        }
        private void tan_Click(object sender, EventArgs e)
        {
            nums_win.Text = Math.Tan(double.Parse(nums_win.Text) * coef) + "";
        }
    }
}
