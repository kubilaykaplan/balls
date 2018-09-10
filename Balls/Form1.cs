using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            RadioButton rdb = new RadioButton();
            rdb.Text = "";
            rdb.Width = rdb.Height;
            rdb.Left = e.X;
            rdb.Top = e.Y;
            rdb.Tag = new Point(2, 2);
            this.Controls.Add(rdb);
        }
        bool TopXCarpti(RadioButton top)
        {
            foreach (RadioButton tp in this.Controls)
            {
                if (top != tp && (top.Left <= tp.Right && top.Left >= tp.Left && top.Top >= tp.Top && top.Top <= tp.Bottom))
                    return true;
            }
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (RadioButton top in this.Controls)
            {
                Point p = (Point)top.Tag;
                top.Left += p.X;
                top.Top += p.Y;

                if (top.Left <= 0 || top.Right >= this.ClientSize.Width || TopXCarpti(top))
                    p.X *= -1;
                if (top.Top <= 0 || top.Bottom >= this.ClientSize.Height||TopXCarpti(top))
                    p.Y *= -1;

                top.Left += p.X;
                top.Top += p.Y;
                top.Tag = p;
            }
        }
    }
}
