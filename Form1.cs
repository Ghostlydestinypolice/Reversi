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
        uint score1;
        uint score2;
        int arrayrij;
        int arraycol;
        bool[,] magzet = new bool [bordgrootte, bordgrootte];
        int startpunt = bordgrootte / 2 - 1;
        bool zetgedaan;

        public MainClass()
        {
            InitializeComponent();
        }

        public void startpositie()
        {
            panelarray[startpunt, startpunt] = steenspeler1;
            panelarray[startpunt + 1, startpunt + 1] = steenspeler1;
            panelarray[startpunt + 1, startpunt] = steenspeler2;
            panelarray[startpunt, startpunt + 1] = steenspeler2;
        }
        private void PanelTeken(object sender, PaintEventArgs pea)
        {
            Graphics gr = pea.Graphics;
            //speelbord
            startpositie();
            for (int n = 0; n <= bordgrootte; n++)
            {
                gr.DrawLine(Pens.Black, 0 + speelbord.Width / bordgrootte * n, 0, speelbord.Width / bordgrootte * n, speelbord.Height);
                gr.DrawLine(Pens.Black, 0, (speelbord.Height -1)/ bordgrootte * n, speelbord.Width, (speelbord.Height -1)/ bordgrootte * n); //Speelbord.Height -1, omdat hij anders buiten het kader valt.
            }

            //Stenen tekenen
            {
                Pen bluePen = new Pen(Color.Blue, 3);
                Pen redPen = new Pen(Color.Red, 3);

                for (int t = 0; t < bordgrootte; t++)
                {
                    for (int i = 0; i < bordgrootte; i++)
                    {
                        /* 
                        ///TODO:
                        int a = 133;
                        int b = 129;

                        int c = 200;
                        int d = 129;

                        int e = 133;
                        int f = 193;

                        max x = 332
                        max y = 321

                        speelbord.Width = 400
                        speelbord.Height = 390
                        */
                        int width = 63;
                        int height = 63;
                        int positiex = t * 67 - 1; ///TODO finetunen
                        int positiey = i * 64 + 1;


                        if (panelarray[t,i] == 1)
                        {
                            gr.DrawEllipse(bluePen, positiex, positiey, width, height);
                        }
                        else if (panelarray[t,i] == 2)
                        {
                            gr.DrawEllipse(redPen, positiex, positiey, width, height);
                        }

                    }
                }

            }
            score();

        }



        private void speelbord_MouseKlik(object sender, MouseEventArgs mea) //Zetmethode
        {
            zetgedaan = false;
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
            zetgedaan = true;

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
            Beurtlabel.Text = beurt.ToString();
        }

        public void BordBerekenen()
        {
            for (arraycol = 0; arraycol < bordgrootte; arraycol++)
            {
                for (arrayrij = 0; arrayrij < bordgrootte; arrayrij++)
                {
                    if (panelarray[arrayrij, arraycol] == 0)
                    {
                        richtingentest(arrayrij, arraycol, true);
                    }
                    else if (panelarray[arrayrij, arraycol] == beurt && zetgedaan == true)
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
            int Orij = rij; //orginele positie
            int Ocol = col;
            uint resultaat;
            uint[,] gepasseerd = new uint[bordgrootte, bordgrootte];
            bool bewaar = true; //variabel om bij te houden of er gedraait wordt.
                for (int drij = -1; drij < 2; drij++)
                {
                    for (int dcol = -1; dcol < 2; dcol++) //in 9 richtingen: gewonnen snelheid niet opweegt tegen de verloren leesbaarheid
                    {
                        rij = Orij + drij;
                        col = Ocol + dcol;
                        if (rij < bordgrootte && col < bordgrootte && rij >= 0 && col >= 0)
                        {
                        resultaat = panelarray[rij, col];
                        }
                        else
                        {
                        resultaat = 0;
                        }


                        if (resultaat != beurt && resultaat != 0)
                        {
                            gepasseerd[rij, col] = 3;
                            uint omgekeerdebeurt = resultaat; //resultaat zal nooit iets anders dan de steen van ander zijn 
                            while (resultaat == omgekeerdebeurt)
                            {
                                rij += drij;
                                col += dcol;
                                if (rij < bordgrootte && col < bordgrootte && rij >= 0 && col >= 0)
                                {
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
                    
                        for (int t = 0; t < bordgrootte; t++) //gepasseerd-array langs gaan
                        {
                            for (int i = 0; i < bordgrootte; i++)
                            {
                                if (bewaar == true && virtueel == false) //test om te draaien
                                {
                                    if (gepasseerd [t,i] == 3)
                                    {
                                        panelarray[t, i] = gepasseerd[t, i];
                                        gepasseerd[t, i] = 0;
                                    }
                                }
                                else if (bewaar == false) //opgeslagen data wissen
                                {
                                    gepasseerd [t,i] = 0;
                                }
                                else if (virtueel == true && bewaar == true) //test of een zet mag
                                {
                                    magzet[Orij, Ocol] = true;
                                    gepasseerd[t, i] = 0;
                                }
                            }
                        }
                    }
                }
        }
        

        public void draaien ()
        {
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
            helptekst += "zie: https://www.jijbent.nl/spelregels/reversi.php";
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
            startpositie();
            this.Invalidate();
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
            Score1.Text = score1.ToString();
            Score2.Text = score2.ToString();
        }

    }
} 


