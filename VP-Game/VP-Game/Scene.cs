using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VP_Game
{
    [Serializable]
    public class Scene
    {
        private Shooter Shooter;
        public List<Bullet> Bullets;
        public List<Enemy> Enemies;
        private List<Boost> Boosts;

        private int width;
        private int height;
        public bool gameOver;
        public int Points;

        public Scene(int w,int h)
        {
            Shooter = new Shooter(new Point(w / 2, h / 2));
            width = w;
            height = h;
            Bullets = new List<Bullet>();
            Enemies = new List<Enemy>();
            Boosts = new List<Boost>();
            Enemies.Add(new Enemy(new Point(width+100,400), 4));
            Enemies.Add(new Enemy(new Point( -50, 350),4));
            gameOver = false;
            Points = 0;

            // spawnBoost(new HealthBoost(this.Shooter),10,10);
       }

        public void Draw(Graphics g) {
            Shooter.Draw(g);

            foreach (Bullet b in Bullets)
            {
                b.Draw(g);
            }

            foreach(Enemy e in Enemies)
            {
                e.Draw(g);
            }

            foreach (Boost b in Boosts)
            {
                b.Draw(g);
            }
        }

        public void AddBullet()
        {
            if(Shooter.oriented == "Up")
            {
                Point p = Shooter.Position;
                p.X += Shooter.Image.Width/2;
                p.Y -= 5;
                Bullets.Add(new Bullet(p, 0, -(Shooter.getTotalBulletSpeed()), this.Shooter.getTotalBulletDamage()));
            }

            if (Shooter.oriented == "Right")
            {
                Point p = Shooter.Position;
                p.X += Shooter.Image.Width;
                p.Y += Shooter.Image.Height / 2 - 1;
                Bullets.Add(new Bullet(p, (Shooter.getTotalBulletSpeed()), 0, this.Shooter.getTotalBulletDamage()));
            }

            if (Shooter.oriented == "Down")
            {
                Point p = Shooter.Position;
                p.X += 5;
                p.Y += Shooter.Image.Height - 5;
                Bullets.Add(new Bullet(p, 0, (Shooter.getTotalBulletSpeed()), this.Shooter.getTotalBulletDamage()));
            }
            if (Shooter.oriented == "Left")
            {
                Point p = Shooter.Position;
                p.Y += Shooter.Image.Height/2;
                Bullets.Add(new Bullet(p, -(Shooter.getTotalBulletSpeed()), 0, this.Shooter.getTotalBulletDamage()));
            }
        }

        public void MoveShooter(string s)
        {
            if (s == "up")
            {
                Shooter.Position.Y -= 7;
                Shooter.oriented = "Up";
                if (Shooter.Position.Y <= 70)
                {
                    Shooter.Position.Y = 70;
                }
            }
            if(s == "down")
            {
                Shooter.Position.Y += 7;
                Shooter.oriented = "Down";
                if (Shooter.Position.Y + 100 >= height)
                {
                    Shooter.Position.Y = height - 100;
                }
            }
            if (s == "left")
            {
                Shooter.Position.X -= 7;
                Shooter.oriented = "Left";
                if (Shooter.Position.X <= 0)
                {
                    Shooter.Position.X = 0;
                }
            }
            if (s == "right")
            {
                Shooter.Position.X += 7;
                Shooter.oriented = "Right";
                if (Shooter.Position.X + 50 >= width)
                {
                    Shooter.Position.X = width - 50;
                }
            }

            checkBoostCollision();
        }

        public void MoveBullets()
        {
            foreach(Bullet b in Bullets)
            {
                b.Move();
            }
           

            foreach(Bullet b in Bullets)
            {
                for(int i = Enemies.Count() - 1; i >= 0; i--)
                {
                    if (Enemies[i].isHit(b))
                    {
                        b.Position.X = width + 30;
                        b.Position.Y = height + 20;

                        if (Enemies[i].CurrentHealth <= 0)
                        {
                            this.generateBoostAtCoordinates(Enemies[i].Position.X, Enemies[i].Position.Y);
                            Enemies.RemoveAt(i);
                            Points += 50;
                        }
                    }
                }
            }

            deleteBullets();
        }

        public void deleteBullets()
        {
            for(int i = Bullets.Count() - 1; i >= 0; i--)
            {
                if(Bullets[i].Position.X > width || Bullets[i].Position.X < 0
                    || Bullets[i].Position.Y < 0 || Bullets[i].Position.Y > height)
                {
                    Bullets.RemoveAt(i);
                }
            }
        }

        public void checkBoostCollision()
        {
            for (int i = 0; i < this.Boosts.Count(); i++)
            {
                Boost b = this.Boosts[i];

                if (b.checkHit(this.Shooter))
                {
                    Console.WriteLine("BOOST HIT!!!");
                    this.Boosts.RemoveAt(i);
                }
            }
        }

        public void generateEnemies(int k,int health)
        {
            Random r = new Random();
            
            
            while (k > 0)
            {
                k--;
                int nasoka = r.Next(3);
               
                if(nasoka == 0)//od desno
                {
                    Point p = new Point(r.Next(width,width+50), r.Next(200,height));
                    Enemies.Add(new Enemy(p,health));
                }
                else if(nasoka == 1)//od dole
                {
                    Point p = new Point(r.Next(width), r.Next(height,height+50));
                    Enemies.Add(new Enemy(p, health));
                }
                else//od levo
                {
                    Point p = new Point(r.Next(-50,0), r.Next(100, height+50));
                    Enemies.Add(new Enemy(p, health));
                }
               
            }
        }

        public void generateBoostAtCoordinates(int x, int y)
        {
            Random r = new Random();

            // chance to get boost
            int chanceLimit = 10;

            int chance = r.Next(100);

            if (chance < chanceLimit)
            {

                int boost = r.Next(3);

                if (boost == 1)
                {
                    //health boost
                    spawnBoost(new HealthBoost(this.Shooter), x, y);
                }
                else
                {
                    //bullet bonus damage boost
                    spawnBoost(new BulletBonusDamageBoost(this.Shooter), x, y);
                }

            }
        }

        private void spawnBoost(Boost boost, int x, int y)
        {
            boost.setX(x);
            boost.setY(y);

            Boosts.Add(boost);
        }

        public void MoveEnemies()
        {
            foreach(Enemy e in Enemies)
            {
                e.Move(Shooter.Position);
            }

            CheckCollisions();
        }

        public void CheckCollisions()
        {
            if(Enemies.Count() > 0)
            {
               int enemyWidth = Enemies[0].Image.Width;
               int enemyHeight = Enemies[0].Image.Height;
                int x = Shooter.Position.X;
                int y = Shooter.Position.Y;
                int swidth = Shooter.Image.Width;
                int sheight = Shooter.Image.Height;
                foreach (Enemy e in Enemies)
               {
                   if(e.Position.X + enemyWidth <= x || e.Position.X >= x + swidth
                        || e.Position.Y + enemyHeight <= y || e.Position.Y >= y + sheight)
                    {
                       //
                    }else
                    {
                        Shooter.Health -= 10;
                        if(Shooter.Health <= 0)
                        {
                            gameOver = true;
                            break;
                        }
                    }
               }
            }
            
        }
    }
}
