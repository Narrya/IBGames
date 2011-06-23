using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Resources;
using System.Media;
using System.Diagnostics;

namespace projekt
{
    public partial class Tetris : Form
    {
        public Tetris()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            Inicjuj();
        }

        public int points, level;
        public bool szybciej, gra, pauza;
        private Plansza Plansza_tetris;
        private Plansza next_klocek;

        private void Inicjuj()
        {
            level = 1;
            points = 0;
            szybciej = false;
            gra = false;
            pauza = false;
            licznik.Interval = 1000;
            
            this.Plansza_tetris = new Plansza(18, 26);
            this.Plansza_tetris.Location = new System.Drawing.Point(150, 30);
            this.Plansza_tetris.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Plansza_tetris.Name = "Plansza_tetris";
            this.Plansza_tetris.TabIndex = 0;
            this.Plansza_tetris.Paint += new PaintEventHandler(this.Plansza_Paint);
            this.Controls.Add(this.Plansza_tetris);

            this.next_klocek = new Plansza(4, 4);
            this.next_klocek.Location = new System.Drawing.Point(30, 30);
            this.next_klocek.Name = "next_klocek";
            this.next_klocek.TabIndex = 0;
            this.next_klocek.Paint += new PaintEventHandler(this.Plansza_Paint);
            next.Controls.Add(this.next_klocek);
                       
        }
                         

        private void licznik_tick_1(object sender, EventArgs e)
        {
            if (!Plansza_tetris.wdol())
            {
                if (szybciej)
                {
                    szybciej = false;
                    if (level < 11)
                        licznik.Interval = 1000 - 100 * (level - 1);
                    else if (level < 21)
                        licznik.Interval = 100 - 10 * (level - 1);
                    else licznik.Interval = 10;
                }
                int pkt = Plansza_tetris.linie();
                points += (pkt * pkt);
                punkty.Text = points.ToString();
                if (points >= level * 10)
                {
                    level++;
                    Assembly assembly;
                    SoundPlayer dzwiek;
                    assembly = Assembly.GetExecutingAssembly();
                    dzwiek = new SoundPlayer(assembly.GetManifestResourceStream("projekt.error.wav"));
                    dzwiek.Play();
                    poziom.Text = level.ToString();
                    if (level < 11)
                        licznik.Interval -= 100;
                    else if (level < 21)
                        licznik.Interval -= 10;
                    else licznik.Interval = 10;
                }
                element_big f = next_klocek.getelement();
                if (!Plansza_tetris.rysujklocek(5, 0, f))
                {
                    licznik.Stop();
                    licznik.Interval = 1000;
                    MessageBox.Show("GAME OVER\n"
                                    + "Points:" + points + "\n"
                                    + "Level:" + level + "\n" );
                    gra = false;
                    f = null;
                    Plansza_tetris.reset();
                    next_klocek.reset();
                    level = 1;
                    points = 0;
                    punkty.Text = "0";
                    poziom.Text = "1";
                    return;
                }
                next_klocek.reset();
                next_klocek.rysujklocek(0, 0, new element_big());
            }
        }

        private void Plansza_Paint(object sender, PaintEventArgs e)
        {
            Plansza p = (Plansza)sender;
            p.refresh();
         }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !gra)
            {
                gra = true;
                licznik.Start();
                Assembly assembly;
                SoundPlayer dzwiek;
                assembly = Assembly.GetExecutingAssembly();
                dzwiek = new SoundPlayer(assembly.GetManifestResourceStream("projekt.chord.wav"));
                dzwiek.Play();
                Plansza_tetris.rysujklocek(5, 0, new element_big());
                next_klocek.rysujklocek(0, 0, new element_big());
                
            }
            else if (e.KeyCode == Keys.F1 && !pauza)
            {
                if (gra)
                {
                    licznik.Stop();
                    pauza = true;
                    DialogResult result;
                    result = MessageBox.Show("Enter - Start\n"
                                         + "Esc - Koniec\n"
                                         + "Spacja - Pauza\n"
                                         + "Strzałka w lewo - lewo\n"
                                         + "Strzałka w prawo - prawo\n"
                                         + "Strzałka w górę - obrot\n"
                                         + "Strzałka w dół - przyspieszenie (pierwsze naciśnięcie),\n"
                                         + "                         zwolnienie (drugie naciśnięcie)\n", "INSTRUCTION", MessageBoxButtons.OK);

                    if (result == DialogResult.OK)
                    {
                        licznik.Start();
                        pauza = false;
                    }
                }
                else if (!gra)
                {
                    DialogResult result;
                    result = MessageBox.Show("Enter - Start\n"
                                         + "Esc - Koniec\n"
                                         + "Spacja - Pauza\n"
                                         + "Strzałka w lewo - lewo\n"
                                         + "Strzałka w prawo - prawo\n"
                                         + "Strzałka w górę - obrot\n"
                                         + "Strzałka w dół - przyspieszenie (pierwsze naciśnięcie),\n"
                                         + "                         zwolnienie (drugie naciśnięcie)\n", "INSTRUCTION", MessageBoxButtons.OK);

                }

            }
            else if (e.KeyCode == Keys.Escape && gra)
            {
                gra = false;
                Plansza_tetris.reset();
                next_klocek.reset();
                level = 1;
                points = 0;
                poziom.Text = "1";
                punkty.Text = "0";
                licznik.Stop();
                licznik.Interval = 1000;
            }
            else if (e.KeyCode == Keys.Space && gra)
            {
                if (pauza)
                {
                    licznik.Start();
                    pauza = false;
                }
                else
                {
                    licznik.Stop();
                    pauza = true;
                }
            }
            else if (e.KeyCode == Keys.Left && gra && !pauza) Plansza_tetris.wlewo();
            else if (e.KeyCode == Keys.Right && gra && !pauza) Plansza_tetris.wprawo();
            else if (e.KeyCode == Keys.Up && gra && !pauza) Plansza_tetris.obroc();
            else if (e.KeyCode == Keys.Down && gra && !pauza)
            {
                if (szybciej)
                {
                    licznik.Interval= 1000 - 100 * (level - 1);
                    szybciej = false;
                }
                else if (!szybciej)
                {
                    licznik.Interval = 10;
                    szybciej = true;
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

             
    }
}