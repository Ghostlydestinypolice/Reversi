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
        const int bordgrootte = 6;
        const int vakgrootte = 100;
        int[,] panelarray = new int[bordgrootte, bordgrootte];
        int steenspeler1 = 1;
        int steenspeler2 = 2;
        public int beurt;

        public Form1()
        {
            InitializeComponent();
        }

        private void PanelTeken(object sender, PaintEventArgs pea)
        {
            Graphics gr = pea.Graphics;
            int startpunt = bordgrootte / 2 - 1;
            panelarray[startpunt, startpunt] = steenspeler1;
            panelarray[startpunt + 1, startpunt + 1] = steenspeler1;
            panelarray[startpunt + 1, startpunt] = steenspeler2;
            panelarray[startpunt, startpunt + 1] = steenspeler2;

            //speelbord begin
            for (int n = 0; n <= bordgrootte; n++)
            {
                gr.DrawLine(Pens.Black, 0 + speelbord.Width / bordgrootte * n, 0, speelbord.Width / bordgrootte * n, speelbord.Height);
                gr.DrawLine(Pens.Black, 0, speelbord.Height / bordgrootte * n, speelbord.Width, speelbord.Height / bordgrootte * n);
            }
            //stenentekenen
            for (int arrayx = 0; arrayx < bordgrootte; arrayx++)
            {
                for (int arrayy = 0; arrayy < bordgrootte; arrayy++)
                {
                    if (panelarray[arrayx, arrayy] == 1)
                    {
                        gr.FillEllipse(Brushes.MediumVioletRed, 20, 20, 20, 20); ///aanpassen beide
                        gr.DrawEllipse(Pens.Black, vakgrootte / 5, vakgrootte / 5, vakgrootte / 5, vakgrootte / 5);
                    }
                    else if (panelarray[arrayx, arrayy] == 2)
                    {
                        gr.FillEllipse(Brushes.CadetBlue, 20, 20, 20, 20); ///aanpassen beide
                        gr.DrawEllipse(Pens.Black, vakgrootte / 5, vakgrootte / 5, vakgrootte / 5, vakgrootte / 5);
                    }
                }
            }
        }

        private void HelpKlik(object sender, EventArgs e)
        {
            string helptekst = ""; //helptekst toevoegen aan lege string
            helptekst += "Zet om en om stenen neer.";
            MessageBox.Show(helptekst);
        }

        private void NieuwSpelKlik(object o, EventArgs e) //moet alle zetten wissen
        {
            this.Invalidate();
        }

        private void speelbord_MouseKlik(object sender, MouseEventArgs mea)
        {
            int klikx = mea.X;
            int kliky = mea.Y;
            bool beurt = true;
            if (beurt)
            {
                panelarray[0, 0] = 1; //?
                beurt = false;
            }
            else
            {
                panelarray[0, 0] = 2; //?
                beurt = true;
            }
        }

        public bool toegestaan() //checken of er gedraait wordt.
        {
            bool zet = false;
            if () 
            {
                zet = true;
            }
            return zet;
        }

        public int[,] arrayloop () //moet de array waarde weer geven
        {
            int y [,]  = [1, 1];
            for (int arrayk = 0; arrayk < bordgrootte; arrayk++)
            {
                for (int arrayr = 0; arrayr < bordgrootte; arrayr++)
                {
                    y = panelarray[arrayk, arrayr];
                }
            }
            return y; ///TODO: aanpassen
        }

        public void draaien () //Parameters?
        {
            ;
        }
    }



    public class stenen
    {
        //stenen hun eigen object type maken.
    }
}


