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
        public const int bordgrootte = 6;
        public const int vakgrootte = 100;
        uint[,] panelarray = new uint[bordgrootte, bordgrootte];
        byte steenspeler1 = 1;
        byte steenspeler2 = 2;
        public int beurt;
        bool kleur1 = true;
        bool kleur2 = false;
        int arraycol = 0;
        int arrayrij = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void PanelTeken(object sender, PaintEventArgs pea) //methode om de startpositie te tekenen
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

           
        }

        

        private void speelbord_MouseKlik(object sender, MouseEventArgs mea) //Zetmethode
        {
            int klikx = mea.X;
            int kliky = mea.Y;
            bool Beurt1 = true;
            

            //event voor beurt verzetten
            if (Beurt1 == kleur1)
            {
                Beurt1 = kleur2;
            }
            else if (Beurt1 == kleur2)
            {
                Beurt1 = kleur1;
            }
        }

        public bool mogelijk () //hoeft niet
        {
            bool magzet = false;

            return magzet;
        }

        public bool BordBerekenen() //in acht richtingen zetten berekenen
        {
            for (; arraycol < bordgrootte; arraycol++)
            {
                for (; arrayrij < bordgrootte; arrayrij++)
                {
                    if (panelarray[arraycol, arrayrij] == 0)
                    {
                        //beurtgetal invullen en dan de volgende stap doen
                        //in plaats van methode draaien, magzet naar true.
                    }
                    else if (panelarray[arraycol, arrayrij] == 1)
                    {
                        //acht keer -1/+1 doen.
                        //dan vervolgen in dezelfde richting bij een andere kleur.
                        //dan methode draaien.
                    }
                    else if (panelarray[arraycol, arrayrij] == 2)
                    {
                        //zie vorige
                    }
                }
            }
            this.Invalidate();
            return true;//placeholder
        }

        public void draaien () //Parameters?
        {
            ;
        }

        private void HelpKlik(object sender, EventArgs e)
        {
            string helptekst = ""; //helptekst toevoegen aan lege string
            helptekst += "Zet om en om stenen neer.";
            MessageBox.Show(helptekst);
        }

        private void NieuwSpelKlik(object o, EventArgs e) //moet alle zetten wissen
        {
            for (; arraycol < bordgrootte; arraycol++)
            {
                for (; arrayrij < bordgrootte; arrayrij++)
                {
                    panelarray[arraycol, arrayrij] = 0;
                }
            }    
            this.Invalidate();
            this.speelbord.Paint += this.PanelTeken; //werkt dit?
        }

        public void score ()
        {
            //score berekenen
        }
    }



    public class stenen
    {
        void Tekenstenen (object o, PaintEventArgs pea)
        {
            Graphics gr = pea.Graphics;
            SolidBrush Steenkleur = new SolidBrush(Color.White);
            //Kleur aanpassen met if en for

            gr.FillEllipse(Steenkleur, 20, 20, 20, 20); ///aanpassen beide
            gr.DrawEllipse(Pens.Black, vakgrootte / 5, vakgrootte / 5, vakgrootte / 5, vakgrootte / 5);
        }

        public Color Kleur ()
        {
            return new Color();
        }
    }
}


