using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace button_color
{
    public partial class Form1 : Form
    {
        public int i = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click (object sender, EventArgs e)
        {
            if (i == 0)
            {
                button1.BackColor = Color.Red;
            }
            else if (i == 1)
            {
                button1.BackColor = Color.Yellow;
            }
            else
            {
                i = -1;
                button1.BackColor = Color.Blue;
            }
            i++;
        }
    }
}
