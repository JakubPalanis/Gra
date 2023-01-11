using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Jakubostateczniejpwp
{
    public partial class Form1 : Form
    {
        Point startLocation;
        int t = 0;
        int zyc = 3;
        bool goLeft, goRight, goDown, goUp;
        int ruch = 4;
        int czas = 0;
        int najlepczas;
        int najczas;
        int poziom = 1;
        int i = 1;
        int b = 0;
       


        public Form1()
        {
            InitializeComponent();
            pojawSieNaStarcie();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {                                                                //zegar co sekunde odmierza czas i zapisuje go na ekranie jako aktualny czas
            czas++;
            czasomierz.Text = "Czas: " + czas;
        }
        private void timerznikania_Tick(object sender, EventArgs e)
        {
                zniknij();
                if (t == 0)                                                    // ściany znikają co 2 sekundy i spowrotem się pojawiają
            {
                    pojawSie();
                    timerznikania.Interval = 2000;
                    t = 1;
                }
               
                else if (t == 1)
                {
                    zniknijPoz();
                    timerznikania.Interval = 2000;
                    t = 0;
                }
               
        }
        private void czasodmierz_Tick(object sender, EventArgs e)
        {
            //co 20 ms odświeżanie

            if (poziom == 2)                                                    // jeżeli gracz mając 3 poziom przejdzie przez linię mety wyskakuje okienko z informacją o wygranej i czasem końcowym
                                                                                // jeżeli jest on najkrótszy z poprzednich gier jest on zapisywany jako najlepszy czas i wyswietlany na ekranie
            {
                    if (i == 1)
                    {
                        najczas = czas;
                        b = 1;
                    }
                    
                    if(i == 2)
                    {
                        if (b == 1)
                        {
                            najlepczas = czas;
                            if (najlepczas < najczas)
                            {
                                najczas = najlepczas;
                            }
                        }
                        else
                        {
                            najczas = czas;
                        }
                        
                    }

               
                najlepszyczas.Text = "Najlepszy czas: " + najczas;
                czaswchodzenie.Stop();
                timer1.Stop();
                timerznikania.Stop();
                MessageBox.Show("Gratulacje, wygrałeś grę z czasem: " + czas + " sekund" + Environment.NewLine + "Zagraj jeszcze raz");
                restartGry();
            }
            if (zyc == 3)                                                      // jeżeli gracz traci życie znika jedno serduszko z ekranu
            {
                zycie1.Show();
                zycie2.Show();
                zycie3.Show();
            }
            else if (zyc == 2)
            {
                zycie3.Hide();
            }
            else if (zyc == 1)
            {
                zycie2.Hide();
            }
            else if (zyc == 0)                                                 //jeżęli skończą się życia wyskakuje okienko z informacją o przegranej i po kliknięciu ok następuje restart gry
            {
                czaswchodzenie.Stop();
                timer1.Stop();
                timerznikania.Stop();
                MessageBox.Show("Przegrałeś z powodu braku żyć !" + Environment.NewLine + "Spróbuj jeszcze raz");
                restartGry();
                
            }


            if (poziom == 1)
            {
                
                poziomson1.Show();
                poziomson2.Hide();
                poziomson3.Hide();
                if (ludzik.Bounds.IntersectsWith(lab1.Bounds) ||                //jeśli gracz wejdzie w ściane mostu przypisaną do 1 poziomu albo spadnie z mostu traci życie i pojawia się na starcie
                    ludzik.Bounds.IntersectsWith(lab2.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab3.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab4.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab5.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab6.Bounds))
                {
                    zyc--;
                    pojawSieNaStarcie();
                    
                }
            }
            else if (poziom == 2)
            {
                poziomson1.Hide();
                poziomson2.Show();
                poziomson3.Hide();
                if (ludzik.Bounds.IntersectsWith(lab11.Bounds) ||               //jeśli gracz wejdzie w ściane mostu przypisaną do 2 poziomu albo spadnie z mostu traci życie i pojawia się na starcie
                    ludzik.Bounds.IntersectsWith(lab12.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab13.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab14.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab15.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab16.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab17.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab18.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab19.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab199.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab3.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab4.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab5.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab6.Bounds))
                {
                    zyc--;
                    pojawSieNaStarcie();
                    
                }
            }
            else
            {
                poziomson1.Hide();
                poziomson2.Hide();
                poziomson3.Show();
                if (ludzik.Bounds.IntersectsWith(sc1.Bounds) ||                 //jeśli gracz wejdzie w ściane mostu przypisaną do 3 poziomu albo spadnie z mostu traci życie i pojawia się na starcie
                    ludzik.Bounds.IntersectsWith(sc2.Bounds) ||
                    ludzik.Bounds.IntersectsWith(sc3.Bounds) ||
                    ludzik.Bounds.IntersectsWith(sc4.Bounds) ||
                    ludzik.Bounds.IntersectsWith(sc5.Bounds) ||
                    ludzik.Bounds.IntersectsWith(sc6.Bounds) ||
                    ludzik.Bounds.IntersectsWith(sc7.Bounds) ||
                    ludzik.Bounds.IntersectsWith(sc8.Bounds) ||
                    ludzik.Bounds.IntersectsWith(sc9.Bounds) ||
                    ludzik.Bounds.IntersectsWith(sc10.Bounds) ||
                    ludzik.Bounds.IntersectsWith(sc11.Bounds) ||
                    ludzik.Bounds.IntersectsWith(sc12.Bounds) ||
                    ludzik.Bounds.IntersectsWith(sc13.Bounds) ||
                    ludzik.Bounds.IntersectsWith(sc14.Bounds) ||
                    ludzik.Bounds.IntersectsWith(sc15.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab11.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab12.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab199.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab3.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab4.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab5.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab6.Bounds))
                {
                    zyc--;
                    pojawSieNaStarcie();
                    
                }
            }


            if (ludzik.Bounds.IntersectsWith(labfinish.Bounds))                 // jeżeli gracz przejdzie przez most przechodzi do następnego poziomu odnawiają mu się życia jeśli je stracił i pojawia się na starcie
            {
                poziom++;
                pojawSieNaStarcie();
                zyc = 3;
            }


            if (goLeft == true && ludzik.Left > 0)                                          //ruch gracza
            {
                ludzik.Left -= ruch;
            }
            if (goRight == true && ludzik.Left + ludzik.Width < this.ClientSize.Width)
            {
                ludzik.Left += ruch;
            }
            if (goUp == true && ludzik.Top > 0)
            {
                ludzik.Top -= ruch;
            }
            if (goDown == true && ludzik.Top + ludzik.Height < this.ClientSize.Height)
            {
                ludzik.Top += ruch;
            }
        }

        public void restartGry()                                                        
        {
            i=2;
            poziom = 1;
            czas = 0;
            zyc = 3;
            pojawSieNaStarcie();
            czaswchodzenie.Start();
            timer1.Start();
            timerznikania.Start();
            goLeft = false;
            goRight = false;
            goUp = false;
            goDown = false;
        }


        public void pojawSieNaStarcie()
        {
            startLocation = new System.Drawing.Point(-320, 150);
            ludzik.Location = PointToScreen(startLocation);
        }


        private void KeyIsDown(object sender, KeyEventArgs e)                       //jeśli klawisz wciśnięty
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)                         //jeśli klawisz wciśnięty
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void ludzik2_Click(object sender, EventArgs e)                      //zamiana stroju ludzika
        {
            ludzik.Image = ludzik2.Image;
        }

        private void ludzik3_Click(object sender, EventArgs e)
        {
            ludzik.Image = ludzik3.Image;
        }

        private void closebut_Click(object sender, EventArgs e)                     //gdy naciśniemy to gra się wyłączy
        {
            Application.Exit();
        }

        private void restartbut_Click(object sender, EventArgs e)                   //gdy naciśniemy to gra włączy się od początku
        {
            restartGry();
        }

        public void zniknij()                                                       //ustawienie ścian mostu na widoczne dla wszystkich poziomów
        {
            lab1.Hide();
            lab2.Hide();
            lab11.Hide();
            lab12.Hide();
            lab13.Hide();
            lab14.Hide();
            lab15.Hide();
            lab16.Hide();
            lab17.Hide();
            lab18.Hide();
            lab19.Hide();
            lab199.Hide();
            sc1.Hide();
            sc2.Hide();
            sc3.Hide();
            sc4.Hide();
            sc5.Hide();
            sc6.Hide();
            sc7.Hide();
            sc8.Hide();
            sc9.Hide();
            sc10.Hide();
            sc11.Hide();
            sc12.Hide();
            sc13.Hide();
            sc14.Hide();
            sc15.Hide();

        }
        public void pojawSie()                                                      //ustawienie ścian mostu na widoczne dla danego poziomu
        {
            if (poziom == 1)
            {
                lab1.Show();
                lab2.Show();
            }
            else if (poziom == 2)
            {
                lab1.Hide();
                lab2.Hide();
                lab11.Show();
                lab12.Show();
                lab13.Show();
                lab14.Show();
                lab15.Show();
                lab16.Show();
                lab17.Show();
                lab18.Show();
                lab19.Show();
                lab199.Show();

            }
            else
            {
                lab1.Hide();
                lab2.Hide();
                lab11.Hide();
                lab12.Hide();
                lab13.Hide();
                lab14.Hide();
                lab15.Hide();
                lab16.Hide();
                lab17.Hide();
                lab18.Hide();
                lab19.Hide();
                lab199.Hide();
                sc1.Show();
                sc2.Show();
                sc3.Show();
                sc4.Show();
                sc5.Show();
                sc6.Show();
                sc7.Show();
                sc8.Show();
                sc9.Show();
                sc10.Show();
                sc11.Show();
                sc12.Show();
                sc13.Show();
                sc14.Show();
                sc15.Show();
                lab11.Show();
                lab12.Show();
                lab199.Show();
            }

        }
        public void zniknijPoz()                                                //ustawienie ścian mostu na niewidoczne dla danego poziomu
        {
            if (poziom == 1)
            {
                lab1.Hide();
                lab2.Hide();
            }
            else if (poziom == 2)
            {
                lab1.Hide();
                lab2.Hide();
                lab11.Hide();
                lab12.Hide();
                lab13.Hide();
                lab14.Hide();
                lab15.Hide();
                lab16.Hide();
                lab17.Hide();
                lab18.Hide();
                lab19.Hide();
                lab199.Hide();
            }
            else
            {
                sc1.Hide();
                sc2.Hide();
                sc3.Hide();
                sc4.Hide();
                sc5.Hide();
                sc6.Hide();
                sc7.Hide();
                sc8.Hide();
                sc9.Hide();
                sc10.Hide();
                sc11.Hide();
                sc12.Hide();
                sc13.Hide();
                sc14.Hide();
                sc15.Hide();
                lab11.Hide();
                lab12.Hide();
                lab199.Hide();
            }
        }

    }
    
}
