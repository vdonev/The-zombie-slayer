using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VP_Game
{
    [Serializable]
    public class Enemy
    {
        private int width ;
        private int height ;

        public Point Position;
        private int Health;
        public int CurrentHealth;
        private int speed;
        public Image Image;
        private int imgNum;
        private static Random r = new Random();

        public Enemy(Point p,int health)
        {
            this.Position = p;
            Health = health;
            CurrentHealth = Health;
            speed = 4;
            imgNum = r.Next(1,4);
            Image = Image.FromFile("Images/zombie"+imgNum+"Right.png");
            width = Image.Width;
            height = Image.Height;

        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Image, Position);
            Brush green = new SolidBrush(Color.Green);
            Brush red = new SolidBrush(Color.Red);
            int w = (CurrentHealth * 100 / Health);
            g.FillRectangle(red, Position.X - 20, Position.Y - 30, 100, 15);
            g.FillRectangle(green, Position.X - 20, Position.Y - 30, w, 15);
            green.Dispose();
            red.Dispose();
        }

        public bool isHit(Bullet b)
        {
            if (b.Position.X >= this.Position.X && b.Position.X <= this.Position.X + this.width && b.Position.Y >= this.Position.Y && b.Position.Y <= this.Position.Y + this.height)
            {
                CurrentHealth -= b.getDamage();
                return true;
            }

            return false;
        }

        public void Move(Point p)
        {  
            if (Position.X < p.X)
            {
                Image = Image.FromFile("Images/zombie"+imgNum+"Right.png");
                Position.X += speed;
                width = Image.Width;
                height = Image.Height;
            }
            else if (Position.X > p.X)
            {
                Image = Image.FromFile("Images/zombie"+imgNum+"Left.png");
                Position.X -= speed;
                width = Image.Width;
                height = Image.Height;
            }
            if (Position.Y < p.Y)
            {
                Position.Y += speed;
            }
            else if (Position.Y > p.Y)
            {
                Position.Y -= speed;
            }
        }
    }
}
