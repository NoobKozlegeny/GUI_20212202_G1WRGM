using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bullet 
    {
        
        private Vector2 position;
        private Vector2 direction;
        private int damage;
        private bool isPlayer;

        public Bullet(Vector2 position, int damage, Vector2 direction, int velocity, bool isPlayer)
        {
            this.position = position;
            this.damage = damage;
            this.direction = direction * velocity;
            this.isPlayer = isPlayer;
        }

        public bool IsPlayer
        {
            get { return isPlayer; }
            set { isPlayer = value; }
        }

        public Vector2 Position
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
