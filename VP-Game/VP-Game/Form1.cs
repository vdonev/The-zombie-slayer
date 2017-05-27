using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_Game
{
    public partial class Form1 : Form
    {
        Scene Scene;
        int counter = 0;
        int number = 2;
        bool pause = false;
        int health = 4;
        string FileName;
        public Form1(Scene s, string fn)
        {
            InitializeComponent();
            DoubleBuffered = true;
            if (s == null) { 
                Scene = new Scene(Width, Height);
                FileName = "Untitled";
            }else
            {
                Scene = s;
                FileName = fn;
            }
            timer1.Start();
            timer2.Start();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!Scene.gameOver)
            {
                Scene.Draw(e.Graphics);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pause)
            {
                if (e.KeyCode == Keys.Up)
                {
                    Scene.MoveShooter("up");
                }

                if (e.KeyCode == Keys.Down)
                {
                    Scene.MoveShooter("down");
                }

                if (e.KeyCode == Keys.Left)
                {
                    Scene.MoveShooter("left");
                }

                if (e.KeyCode == Keys.Right)
                {
                    Scene.MoveShooter("right");     
                }

                if (e.KeyCode == Keys.Space)
                {
                    Scene.AddBullet();
                }
            }
            
            if(e.KeyCode == Keys.P)
            {
                pause = !pause;
                if (pause)
                {
                    timer1.Stop();
                    timer2.Stop();
                    PauseForm pf = new PauseForm(Scene,FileName);
                    if(pf.ShowDialog() == DialogResult.OK)
                    {
                        timer1.Start();
                        timer2.Start();
                        pause = !pause;
                    }
                    
                }
            }

            Invalidate(true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   
            Scene.MoveBullets();
            Scene.MoveEnemies();

            if (Scene.gameOver)
            {
                timer1.Stop();
                timer2.Stop();
                GameOverForm g = new GameOverForm(Scene.Points);
                if(g.ShowDialog() == DialogResult.OK)
                {
                    Scene = new Scene(Width, Height);
                    timer1.Start();
                    timer2.Start();
                }else 
                {
                    this.Close();
                }
            }
            Invalidate(true);
        }

       
 
        private void timer2_Tick(object sender, EventArgs e)
        {
            counter++;
            if(counter > 5 && counter < 10)
            {
                timer2.Interval = 6000;
                number = 3;
                health = 10;
            }else if (counter > 10 && counter < 15)
            {
                timer2.Interval = 5000;
                number = 4;
                health = 20;
            }else if(counter > 15){
                timer2.Interval = 4000;
                number = 5;
                health = 20;
            }

            Scene.generateEnemies(number,health);
            Invalidate(true);
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            label1.Text = "Score : " + Scene.Points;
        }
    }
}
