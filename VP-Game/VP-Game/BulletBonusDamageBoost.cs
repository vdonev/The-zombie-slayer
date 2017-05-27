using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Game
{
    [Serializable]
    class BulletBonusDamageBoost : Boost
    {
        private int increment = 1;

        public BulletBonusDamageBoost(Shooter shooter):base(shooter)
        {
            this.setImage(Image.FromFile("Images/bulletbonusdamage.png"));
        }

        private void increaseBulletDamage()
        {
            this.getShooter().increaseBonusBulletDamage(this.increment);
        }

        public override void doBoost()
        {
            this.increaseBulletDamage();
        }
    }
}
