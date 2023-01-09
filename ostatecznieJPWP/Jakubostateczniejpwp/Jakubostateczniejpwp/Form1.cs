using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        int poziom = 1;
        
        public Form1()
        {
            InitializeComponent();
            pojawSieNaStarcie();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //co sekunde
            czas++;
            czasomierz.Text = "Czas: " + czas;
           
        }
        private void timerznikania_Tick(object sender, EventArgs e)
        {
            if (poziom == 1)

            {
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
                

                if (t == 0)
                {
                    timerznikania.Interval = 2000;
                    lab1.Show();
                    lab2.Show();
                    t = 1;


                }
                else if (t == 1)
                {
                    lab1.Hide();
                    lab2.Hide();
                    t = 0;
                }
            }
            else
                    if (t == 0)
            {
                lab1.Hide();
                lab2.Hide();

                timerznikania.Interval = 2000;

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
                t = 1;

            }
            else if (t == 1)
            {
                lab1.Hide();
                lab2.Hide();

                timerznikania.Interval = 2000;

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
                t = 0;
            }
        }
        private void czasodmierz_Tick(object sender, EventArgs e)
        {
            //co 20 ms
            

            if (zyc == 3)
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
            else if (zyc == 0)
            {
                zycie1.Hide();
            }

            level.Text = "Poziom: " + poziom;
            if (poziom == 1)
            {
                if (ludzik.Bounds.IntersectsWith(lab1.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab2.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab3.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab4.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab5.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab6.Bounds)
                       )
                {                                                               //wchodzenie w picture boxa
                    zyc--;
                    pojawSieNaStarcie();


                    if (zyc == 0)
                    {
                        Application.Exit();
                    }
                }
            }
            else
            {
                if (ludzik.Bounds.IntersectsWith(lab11.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab12.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab13.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab14.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab15.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab16.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab17.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab18.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab19.Bounds) ||
                    ludzik.Bounds.IntersectsWith(lab199.Bounds)

                    )
                {                                                               //wchodzenie w picture boxa
                    zyc--;
                    pojawSieNaStarcie();
                   

                    if (zyc == 0)
                    {
                        Application.Exit();
                    }
                }
            }


            if (ludzik.Bounds.IntersectsWith(labfinish.Bounds))
            {
                poziom++;
                pojawSieNaStarcie();
                
                zyc = 3;
            }
            

            if (goLeft == true && ludzik.Left > 0)
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

    

        public void pojawSieNaStarcie()
        {
            startLocation = new System.Drawing.Point(-320,150);
            ludzik.Location = PointToScreen(startLocation);
        }
  

        private void KeyIsDown(object sender, KeyEventArgs e)
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

        private void KeyIsUp(object sender, KeyEventArgs e)
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
    }
}
