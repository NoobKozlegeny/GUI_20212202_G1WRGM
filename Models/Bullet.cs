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
        public Point Position { get; set; }
        public Size Size { get; set; }
        public double Angle { get; set; }
        public Bullet(int x, int y, int width, int height)
        {
            Position = new Point(x,y);
            Size = new Size(width, height);
        }



        //private Point position;
        //private Vector2 direction;
        //private int damage;
        //private bool isPlayer;

        //public Bullet(Point position, int damage, Vector2 direction, int velocity, bool isPlayer)
        //{
        //    this.position = position;
        //    this.damage = damage;
        //    this.direction = direction * velocity;
        //    this.isPlayer = isPlayer;
        //}

        //public bool IsPlayer
        //{
        //    get { return isPlayer; }
        //    set { isPlayer = value; }
        //}

        //public Point Position
        //{
        //    get { return position; }
        //    set { position = value; }
        //}


        //public Vector2 Direction
        //{
        //    get { return direction; }
        //    set { direction = value; }
        //}


        //public int Damage
        //{
        //    get { return damage; }
        //    set { damage = value; }
        //}
    }
}
