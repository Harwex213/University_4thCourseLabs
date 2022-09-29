using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04_Client_WinForm
{
    public partial class Form2 : Form
    {
        private SimplexProxy.Simplex simplex;

        public Form2()
        {
            simplex = new SimplexProxy.Simplex();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s1 = a1_s.Text;
            var s2 = a2_s.Text;
            var k1 = int.Parse(a1_k.Text);
            var k2 = int.Parse(a2_k.Text);
            var f1 = float.Parse(a1_f.Text);
            var f2 = float.Parse(a2_f.Text);

            var a1 = new SimplexProxy.A { s = s1, k = k1, f = f1 };
            var a2 = new SimplexProxy.A { s = s2, k = k2, f = f2 };

            var res = simplex.Sum(a1, a2);

            res_s.Text = res.s;
            res_k.Text = res.k.ToString();
            res_f.Text = res.f.ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var x = int.Parse(add_x.Text);
            var y = int.Parse(add_y.Text);

            var result = simplex.Add(x, y);

            addResult.Text = result.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var s = concat_s.Text;
            var d = double.Parse(concat_d.Text);

            var result = simplex.Concat(s, d);

            concatResult.Text = result.ToString();
        }
    }
}
