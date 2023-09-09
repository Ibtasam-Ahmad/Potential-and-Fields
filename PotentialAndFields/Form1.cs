using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PotentialAndFields
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = 10;
            double[,] v = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    v[0, j] = 1;
                    v[i, 0] = 1;

                    v[size - 1, j] = 1;
                    v[i, size - 1] = 1;
                }
            }

            Graphics gg = CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Black);
            Font f = new System.Drawing.Font("Arial", 15);

            while(true)
            {
                for (int i = 1; i < size - 1; i++)
                {
                    for (int j = 1; j < size - 1; j++)
                    {
                        v[i, j] = 1.0 / 4.0 * (v[i + 1, j] + v[i - 1, j] + v[i, j + 1] + v[i, j - 1]);
                    }
                }

                this.Refresh();

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Point p = new Point(150 + i * 90, 150 + j * 30);
                        gg.DrawString(Math.Round(v[i, j], 3).ToString(), f, sb, p);
                    }
                }
                Thread.Sleep(5);
            }
        }
    }
}
