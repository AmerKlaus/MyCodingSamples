using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mouse_Event_handling
{
    public partial class Form1 : Form
    {
        bool ShouldPaint { get; set; } = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ShouldPaint = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            ShouldPaint = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ShouldPaint)
            {
                using (Graphics graphics = CreateGraphics())
                {
                    graphics.FillEllipse(
                        new SolidBrush(Color.BlueViolet), e.X, e.Y, 4, 4);
                }
            }
        }
    }
}
