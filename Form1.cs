using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PanelTeken(object sender, PaintEventArgs pea)
        {
            Graphics gr = pea.Graphics;
            int bordgrootte = 6;
            int[,] panelarray = new int [6,6];
            panelarray = new int[bordgrootte, bordgrootte];

            //speelbord begin
            for (int n = 0; n <= bordgrootte; n++)
            {
                gr.DrawLine(Pens.Black, 0 + speelbord.Width / bordgrootte * n, 0, speelbord.Width / bordgrootte * n, speelbord.Height);
                gr.DrawLine(Pens.Black, 0, speelbord.Height / bordgrootte * n, speelbord.Width, speelbord.Height / bordgrootte * n);
            }
        }

        private void HelpKlik(object sender, EventArgs e)
        {
            string helptekst = "";
            MessageBox.Show(helptekst);
        }

        private void NieuwSpelKlik(object o, EventArgs e)
        {

        }
    }
}
