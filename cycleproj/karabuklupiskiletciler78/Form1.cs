using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cycleproj

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int SeritSayisi = 1, Hiz = 25, Skor = 0;
        Random R = new Random();

        class Random_CAR
        {
            public bool FakeHaveCar = false;
            public PictureBox FakeCar;
            public bool vakit = false;
        }
        
        Random_CAR[] rndCar = new Random_CAR[2];
        
        void BringRandomCar(PictureBox pb)
        {
            int rnd = R.Next(0, 4);
            
            switch (rnd)
            {
                case 0:
                    pb.Image = Properties.Resources.car0;
                    break;
                
                case 1:
                    pb.Image = Properties.Resources.car1;
                    break;
                
                case 2:
                    pb.Image = Properties.Resources.car2;
                    break;
                
                case 3:
                    pb.Image = Properties.Resources.car3;
                    break;

            }
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Aracyeri()
        {
            if(SeritSayisi == 1)
            {
                pisiklet.Location = new Point(310, 410);
            }
            else if (SeritSayisi == 0)
            {
                pisiklet.Location = new Point(78, 410);
            }
            else if (SeritSayisi == 2)
            {
                pisiklet.Location = new Point(522, 410);
            }
            else if (SeritSayisi == 3)
            {
                pisiklet.Location = new Point(722, 410);
            }
            else if (SeritSayisi == 4)
            {
                pisiklet.Location = new Point(934, 410);
            }
        }
  
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (SeritSayisi < 4)
                    SeritSayisi++;

            }
            else if(e.KeyCode == Keys.Left)
            {
                if (SeritSayisi > 0)
                    SeritSayisi--;
            }

            Aracyeri();

        }

        private void RandomMusicEkle()
        {
            int MuzikDeger = R.Next(1, 3);

            axWindowsMediaPlayer1.URL = @"music/track" + MuzikDeger.ToString() + ".mp3";
            axWindowsMediaPlayer1.Ctlcontrols.play();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (var i = 0; i < rndCar.Length; i++)
            {
                rndCar[i] = new Random_CAR();
            }
            rndCar[0].vakit = true;

           Aracyeri();
           RandomMusicEkle();

        }

        bool SesKontrol = true;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (SesKontrol == true )
            {
                SesKontrol = false;
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                pictureBox2.Image = Properties.Resources.volumeOff;
            }
            else if (SesKontrol == false)
            {
                SesKontrol = true;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                pictureBox2.Image = Properties.Resources.volumeON;
            }
        }

        private void timerRandomcar_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < rndCar.Length; i++)
            {
                if (!rndCar[i].FakeHaveCar && rndCar[i].vakit)
                {
                    rndCar[i].FakeCar = new PictureBox();
                    BringRandomCar(rndCar[i].FakeCar);
                    rndCar[i].FakeCar.Size = new Size(90, 150);
                    rndCar[i].FakeCar.Top = -rndCar[i].FakeCar.Height;

                    int Seriteyerlestir = R.Next(0, 6);

                    if (Seriteyerlestir == 0)
                    {
                        rndCar[i].FakeCar.Left = 78;
                    }
                    else if (Seriteyerlestir == 1)
                    {
                        rndCar[i].FakeCar.Left = 310;
                    }
                    else if (Seriteyerlestir == 2)
                    {
                        rndCar[i].FakeCar.Left = 522;
                    }
                    else if (Seriteyerlestir == 3)
                    {
                        rndCar[i].FakeCar.Left = 722;
                    }
                    else if (Seriteyerlestir == 4)
                    {
                        rndCar[i].FakeCar.Left = 934;
                    }

                    this.Controls.Add(rndCar[i].FakeCar);
                    rndCar[i].FakeHaveCar = true;

                }
                else
                {
                    if(rndCar[i].vakit)
                    {
                        rndCar[i].FakeCar.Top += 20;
                        if(rndCar[i].FakeCar.Top >= 154)
                        {
                            for (int j = 0; j < rndCar.Length; j++)
                            {
                                 if (!rndCar[j].vakit)
                                {
                                    rndCar[j].vakit = true;
                                    break;
                                }
                            }
                        }
                    }               
                }
            }
        }

        bool SeritHareket = false;
        
        private void timerSerit_Tick(object sender, EventArgs e)
        {
            if (SeritHareket == false)
            {
                for (int i = 1; i < 6; i++)
                {
                    this.Controls.Find("labelsolserit" + i.ToString(), true)[0].Top -= 25;
                    this.Controls.Find("labelortasolserit" + i.ToString(), true)[0].Top -= 25;
                    this.Controls.Find("labelortasagserit" + i.ToString(), true)[0].Top -= 25;
                    this.Controls.Find("labelsagserit" + i.ToString(), true)[0].Top -= 25;
                    SeritHareket = true;
                }
            }
            else
            {
                for (int i = 1; i < 6; i++)
                {
                    this.Controls.Find("labelsolserit" + i.ToString(), true)[0].Top += 25;
                    this.Controls.Find("labelortasolserit" + i.ToString(), true)[0].Top += 25;
                    this.Controls.Find("labelortasagserit" + i.ToString(), true)[0].Top += 25;
                    this.Controls.Find("labelsagserit" + i.ToString(), true)[0].Top += 25;
                    SeritHareket = false;
                }
            }
        }

    }
}
