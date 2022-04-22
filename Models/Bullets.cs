using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bullets
    {
        private Size position;
        private Vector2 direction;
        private int damage;

        public Bullets(Size position, int damage, Vector2 direction, int velocity)
        {
            this.position = position;
            this.damage = damage;
            this.direction = direction * velocity;
        }

        public Size Position
        {
            get { return position; }
            set { position = value; }
        }


        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
        }


        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

    }
}
