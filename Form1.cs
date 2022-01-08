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
    public partial class MainClass : Form 
    {
        public const int bordgrootte = 6;
        public const int vakgrootte = 100;
        uint[,] panelarray = new uint[bordgrootte, bordgrootte];
        byte steenspeler1 = 1;
        byte steenspeler2 = 2;
        public uint beurt = 1;
        uint score1 = 0;
        uint score2 = 0;
        int arraycol;
        int arrayrij;

        public MainClass()
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

            //speelbord
            for (int n = 0; n <= bordgrootte; n++)
            {
                gr.DrawLine(Pens.Black, 0 + speelbord.Width / bordgrootte * n, 0, speelbord.Width / bordgrootte * n, speelbord.Height);
                gr.DrawLine(Pens.Black, 0, (speelbord.Height -1)/ bordgrootte * n, speelbord.Width, (speelbord.Height -1)/ bordgrootte * n); //Speelbord.Height -1, omdat hij anders buiten het kader valt.
            }

            foreach(uint getal in panelarray)
            {
                if (getal == steenspeler1)
                {
                    steen s1 = new steen(); //door een andere klasse laten tekenen?
                }
                else if (getal == steenspeler2)
                {
                    steen s2 = new steen();
                }
            }
            //iets doen met plekken waar een zet mag

        }

        

        private void speelbord_MouseKlik(object sender, MouseEventArgs mea) //Zetmethode
        {
            int klikx = mea.X;
            int kliky = mea.Y;
            int arrayrijklik = klikx / (speelbord.Width / bordgrootte);
            int arraycolklik = kliky / (speelbord.Height /  bordgrootte);
            panelarray[arrayrijklik, arraycolklik] = beurt;

            //event voor beurt verzetten
            if (beurt == steenspeler1)
            {
                beurt = steenspeler2;
            }
            else if (beurt == steenspeler2)
            {
                beurt = steenspeler1;
            }
            this.Invalidate();
        }

        public bool mogelijk () //hoeft niet?
        {
            bool magzet = false;

            return magzet;
        }

        public void BordBerekenen() //in acht richtingen zetten berekenen
        {
            for (arraycol = 0; arraycol < bordgrootte; arraycol++)
            {
                for (arrayrij = 0; arrayrij < bordgrootte; arrayrij++)
                {
                    if (panelarray[arraycol, arrayrij] == 0)
                    {
                        //beurtgetal virtueel invullen en dan de volgende stap doen
                        //in plaats van methode draaien, magzet naar true.
                    }
                    else if (panelarray[arraycol, arrayrij] == beurt)
                    {
                        //acht keer -1/+1 doen.
                        //dan vervolgen in dezelfde richting bij een andere kleur.
                        //dan methode draaien.
                        for (bool doorgaan = true; doorgaan;)//kan beter?
                        {
                            //Checkt buren
                            if (panelarray[arraycol,arrayrij] != beurt && panelarray[arraycol, arrayrij] != 0)
                            {
                                //doorgaan met dezelfde "formule"
                            }
                        }
                    }
                }
            }
            this.Invalidate();
        }

        public void draaien ()
        {
            //steen => beurt
            this.Invalidate();
        }

        private void HelpKlik(object sender, EventArgs e)
        {
            string helptekst = ""; //helptekst toevoegen aan lege string
            helptekst += "Zet om en om stenen neer. ";
            helptekst += "Iedere zet moet naast een steen van de tegenstander neer zetten. ";
            helptekst += "En bij iedere zet moet er mistens 1 steen gedraait worden. ";
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

        public string score (int typescore)
        {
            //score berekenen
            score1 = 0; //Score resetten voor telling
            score2 = 0;
            string resultaat = "";
            for (arraycol = 0; arraycol < bordgrootte; arraycol++)
            {
                for (arrayrij = 0; arrayrij < bordgrootte; arrayrij++)
                {
                    if (panelarray[arraycol,arrayrij] == steenspeler1)
                    {
                        score1++;
                    }
                    else if (panelarray[arraycol, arrayrij] == steenspeler2)
                    {
                        score2++;
                    }

                    if (typescore == steenspeler1)
                    {
                        resultaat = score1.ToString();
                    }
                    else if(typescore == steenspeler2)
                    {
                        resultaat = score2.ToString();
                    }
                }
            }
            return resultaat;
        }

    }



    public class steen : MainClass
    {
        void Tekenstenen (object o, PaintEventArgs pea)
        {
            Graphics gr = pea.Graphics;
            SolidBrush Steenkleur = new SolidBrush(Color.White);
            //Kleur aanpassen met if en for

            gr.FillEllipse(Steenkleur, 20, 20, 20, 20); ///aanpassen beide
            gr.DrawEllipse(Pens.Black, vakgrootte / 5, vakgrootte / 5, vakgrootte / 5, vakgrootte / 5);
        }

        public Color Kleur (int steenbezit)
        {
            int r = 0, b = 0, g = 0;
            if (steenbezit == 1)
            {
                r = 0;
                b = 0;
                g = 0;
            }
            else if (steenbezit == 2)
            {
                r = 255;
                b = 255;
                g = 255;
            }
            Color steenkleur = new Color();
            steenkleur = Color.FromArgb(r, b, g);


            return new Color();
        }
    }
}


