using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VP_Game
{
    [Serializable]
    public class Shooter
    {
        public Point Position;
        public Image Image;
        public string oriented;
        public int Health;

        private int width ;
        private int height ;

        // bullet speed
        private int baseBulletSpeed = 30;
        private int bonusBulletSpeed = 0;

        // bullet damage
        private int baseBulletDamage = 1;
        private int bonusBulletDamage = 0;


        public Shooter(Point pos)
        {
            this.Position = pos;
            oriented = "Right";
            Health = 100;
        }

        public void Draw(Graphics g)
        {
            Image = Image.FromFile("Images/player" + oriented + ".png");
            width = Image.Width;
            height = Image.Height;

            Brush red = new SolidBrush(Color.Red);
            Brush green = new SolidBrush(Color.Green);
            g.FillRectangle(green,20,20,Health,20);
            g.FillRectangle(red, 20 + Health, 20, 100 - Health, 20);
            red.Dispose();
            green.Dispose();
            g.DrawImage(Image, Position);
        }

        public int getTotalBulletSpeed()
        {
            return this.baseBulletSpeed + this.bonusBulletSpeed;
        }

        public void increaseBonusBulletSpeed(int increment)
        {
            this.bonusBulletSpeed += increment;
        }

        public void increaseBonusBulletDamage(int increment)
        {
            this.bonusBulletDamage += increment;
        }

        public int getTotalBulletDamage()
        {
            return this.baseBulletDamage + this.bonusBulletDamage;
        }

        public int getWidth()
        {
            return this.width;
        }

        public int getHeight()
        {
            return this.height;
        }
    }
}
