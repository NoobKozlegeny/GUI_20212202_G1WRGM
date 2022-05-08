using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Weapon : Item
    {
        private int fireRateResetter;
        public Weapon()
        {

        }
        public Weapon(int fireRate)
        {
            fireRateResetter = fireRate;
            NumericFireRate = fireRate;
        }


        public int Damage { get; set; }
        public int NumericFireRate { get; set; }
        public TimeSpan FireRate { get; set; }
        public TimeSpan ReloadRedy { get; set; }
        public int AmmoAmount { get; set; }
        public int MaxAmmo { get; }
        public Uri PathToBulletImg { get; set; }

        public void ResetFireRate()
        {
            NumericFireRate = fireRateResetter;
        }
    }
}
