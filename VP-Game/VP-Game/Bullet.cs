using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VP_Game
{
    [Serializable]
    public class Bullet
    {
        public Point Position;
        public int speedX;
        public int speedY;
        public Image Image;

        private int damage;

        public Bullet(Point p, int x,int y,int damage)
        {
            this.damage = damage;

            Position = p;
            speedX = x;
            speedY = y;
            if(speedX > 0)
            {
                Image = Image.FromFile("Images/bulletRight.png");
            }
            if(speedX < 0)
            {
                Image = Image.FromFile("Images/bulletLeft.png");
            }
            if(speedY > 0)
            {
                Image = Image.FromFile("Images/bulletDown.png");
            }
            if (speedY < 0)
            {
                Image = Image.FromFile("Images/bulletUp.png");
            }

        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Image, Position);
        }

        public void Move()
        {
            Position.X += speedX;
            Position.Y += speedY;
        }

        public int getDamage()
        {
            return this.damage;
        }
    }
}
