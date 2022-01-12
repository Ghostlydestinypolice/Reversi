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
        int arrayrij;
        int arraycol;
        bool[,] magzet = new bool [bordgrootte, bordgrootte];

        public MainClass()
        {
            InitializeComponent();
        }

        private void PanelTeken(object sender, PaintEventArgs pea)
        {
            Graphics gr = pea.Graphics;
            int startpunt = bordgrootte / 2 - 1;
            panelarray[startpunt, startpunt] = steenspeler1; //verplaatsen
            panelarray[startpunt + 1, startpunt + 1] = steenspeler1;
            panelarray[startpunt + 1, startpunt] = steenspeler2;
            panelarray[startpunt, startpunt + 1] = steenspeler2;

            //speelbord
            for (int n = 0; n <= bordgrootte; n++)
            {
                gr.DrawLine(Pens.Black, 0 + speelbord.Width / bordgrootte * n, 0, speelbord.Width / bordgrootte * n, speelbord.Height);
                gr.DrawLine(Pens.Black, 0, (speelbord.Height -1)/ bordgrootte * n, speelbord.Width, (speelbord.Height -1)/ bordgrootte * n); //Speelbord.Height -1, omdat hij anders buiten het kader valt.
            }

            ///TODO: tekenen
            
            
        }



        private void speelbord_MouseKlik(object sender, MouseEventArgs mea) //Zetmethode
        {
            ///KLIK WERKT NIET
            BordBerekenen();
            int klikx = mea.X;
            int kliky = mea.Y;
            int arrayrijklik = klikx / (speelbord.Width / bordgrootte);
            int arraycolklik = kliky / (speelbord.Height / bordgrootte);
            if (panelarray[arrayrijklik, arraycolklik] == 0 && magzet[arrayrijklik, arraycolklik])
            {
            panelarray[arrayrijklik, arraycolklik] = beurt;
            }
            else if (magzet[arrayrijklik, arraycolklik] == false)
            {
                MessageBox.Show("Er wordt zo geen steen gedraait");
            }
            else if (panelarray[arrayrijklik, arraycolklik] != 0)
            {
                MessageBox.Show("Zet ee steen in een leeg veld");
            }

            //event voor beurt verzetten
            if (beurt == steenspeler1)
            {
                beurt = steenspeler2;
            }
            else if (beurt == steenspeler2)
            {
                beurt = steenspeler1;
            }
            BordBerekenen();
            score();
            Eindspel();
            speelbord.Invalidate();
            Beurtlabel.Invalidate();
        }

        public void BordBerekenen()
        {
            for (arraycol = 0; arraycol < bordgrootte; arraycol++)
            {
                for (arrayrij = 0; arrayrij < bordgrootte; arrayrij++)
                {
                    if (panelarray[arrayrij, arraycol] == 0)
                    {
                        //beurtgetal virtueel invullen en dan de volgende stap doen
                        //in plaats van methode draaien
                        richtingentest(arrayrij, arraycol, true);
                    }
                    else if (panelarray[arrayrij, arraycol] == beurt)
                    {
                        richtingentest(arrayrij, arraycol, false);
                        draaien();
                    }
                }
            }
            this.Invalidate();
        }

        public void richtingentest(int rij, int col, bool virtueel)
        {
            int Orij = rij;
            int Ocol = col;
            uint[,] gepasseerd = new uint[bordgrootte, bordgrootte];
            bool bewaar = true; //variabel om bij te houden of er gedraait wordt.
            // testen of het kan met de bordrand
                for (int drij = -1; drij < 2; drij++)
                {
                    for (int dcol = -1; dcol < 2; dcol++) //in 9 richtingen: gewonnen snelheid niet opweegt tegen de verloren leesbaarheid
                    {
                        rij += drij;
                        col += dcol;
                        uint resultaat = panelarray[rij, col]; //out of bound error

                        if (resultaat != beurt && resultaat != 0)
                        {
                            gepasseerd[rij, col] = 3;
                            uint omgekeerdebeurt = resultaat;
                            while (resultaat == omgekeerdebeurt)
                            {
                                rij += drij;
                                col += dcol;
                                resultaat = panelarray[rij, col];
                                if (resultaat == omgekeerdebeurt)
                                {
                                    gepasseerd[rij, col] = 3;
                                }
                                else if (resultaat == 0)
                                {
                                    bewaar = false;
                                }
                                else if (resultaat == beurt)
                                {
                                    bewaar = true;
                                }

                            }
                        }
                    }
                }
            for (int t = 0; t < bordgrootte; t++)
            {
                for (int i = 0; i < bordgrootte; i++)
                {
                    if (bewaar == true && virtueel == false)
                    {
                        if (gepasseerd [t,i] == 3)
                        {
                            panelarray[t, i] = gepasseerd[t, i];
                        }
                    }
                    else if (bewaar == false)
                    {
                        gepasseerd [t,i] = 0;
                    }
                    else if (virtueel == true && bewaar == true)
                    {
                        magzet[Orij, Ocol] = true;
                        gepasseerd[t, i] = 0;
                    }
                }
            }
        }
        

        public void draaien ()
        {
            ///TODO: steen => beurt
            for (arraycol = 0; arraycol < bordgrootte; arraycol++)
            {
                for (arrayrij = 0; arrayrij < bordgrootte; arrayrij++)
                {
                    if (panelarray[arrayrij, arraycol] == 3)
                    {
                        panelarray[arrayrij, arraycol] = beurt;
                    }
                } 
            }
            this.Invalidate();
        }

        private void HelpKlik(object sender, EventArgs e)
        {
            string helptekst = ""; //helptekst toevoegen aan lege string
            helptekst += "Zet om en om stenen neer. ";
            helptekst += "Iedere zet moet naast een steen van de tegenstander neer zetten. ";
            helptekst += "En bij iedere zet moet er mistens 1 steen gedraait worden. ";
            ///TODO: Hyperlink toevoegen: https://www.jijbent.nl/spelregels/reversi.php
            MessageBox.Show(helptekst);
        }

        private void NieuwSpelKlik(object o, EventArgs e) //moet alle zetten wissen
        {
            for (; arraycol < bordgrootte; arraycol++)
            {
                for (; arrayrij < bordgrootte; arrayrij++)
                {
                    panelarray[arrayrij, arraycol] = 0;
                }
            }    
            this.Invalidate();
            this.speelbord.Paint += this.PanelTeken; //werkt dit?
        }

        public void Eindspel ()
        {
            if (score1 + score2 == bordgrootte * bordgrootte)
            {
                string eindresultaat = "";
                if (score1 > score2)
                {
                    eindresultaat += "Speler 1 heeft gewonnen";              
                }
                else if (score2 > score1)
                {
                    eindresultaat += "Speler 2 heeft gewonnen";
                }
                MessageBox.Show(eindresultaat);
            }
        }

        public void score ()
        {
            //score berekenen
            score1 = 0; //Score resetten voor telling
            score2 = 0;
            for (arraycol = 0; arraycol < bordgrootte; arraycol++)
            {
                for (arrayrij = 0; arrayrij < bordgrootte; arrayrij++)
                {
                    if (panelarray[arrayrij,arraycol] == steenspeler1)
                    {
                        score1++;
                    }
                    else if (panelarray[arrayrij, arraycol] == steenspeler2)
                    {
                        score2++;
                    }
                }
            }
            Score1.Invalidate();
            Score2.Invalidate();
        }

    }
} 


