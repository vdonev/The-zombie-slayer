using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Game
{
    [Serializable]
    abstract class Boost
    {
        private Shooter shooter;
        // location on screen
        private int positionX;
        private int positionY;

        // dimensions
        private int width = 32;//px
        private int height = 32;//px

        private String name;
        private Image image;

        public Boost(Shooter shooter)
        {
            this.shooter = shooter;
        }

        public void applyBoost(Shooter shooter)
        {
            this.doBoost();
        }
        
        public abstract void doBoost();

        public Shooter getShooter()
        {
            return this.shooter;
        }

        public void setX(int x)
        {
            this.positionX = x;
        }
        public void setY(int y)
        {
            this.positionY = y;
        }

        public Image getImage()
        {
            return this.image;
        }

        public void setImage(Image image)
        {
            this.image = image;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(this.image, this.positionX, this.positionY);
        }

        public bool checkHit(Shooter s)
        {
            if(s.Position.X < this.positionX + this.width 
                && s.Position.X + s.getWidth() > this.positionX
                && s.Position.Y < this.positionY + this.height
                && s.getHeight() + s.Position.Y > this.positionY)
            {
                this.applyBoost(s);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
