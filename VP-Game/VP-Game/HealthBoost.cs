using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Game
{
    [Serializable]
    class HealthBoost : Boost
    {

       private int healthBoost = 20;

       public HealthBoost(Shooter shooter) : base(shooter)
        {
            this.setImage(Image.FromFile("Images/healthboost.png"));
        }

        private void boostShooterHealth()
        {
            this.getShooter().Health += this.healthBoost;
            if(this.getShooter().Health > 100)
            {
                this.getShooter().Health = 100;
            }
        }


        public override void doBoost()
        {
            this.boostShooterHealth();
        }
    }
}
