using System;
using System.Drawing;
using System.Numerics;

namespace Models
{
    public class Character
    {
        private static int JUMPINGTIME = 500; 
        public Character()
        {
            this.jumpCounter = 0;
        }
        public string Name { get; set; }
        public int HealthPoints { get; set; }
        public int Armour { get; set; }
        public int Speed { get; set; }
        public Uri PathToImg { get; set; }
        public Size Size { get; set; }
        public Point Position { get; set; }
        public bool IsGrounded { get; set; }
        public bool IsJumping{ get => JUMPINGTIME <= this.jumpCounter;  }
        // Pk for EF
        public int Id { get; set; }
        // Fk + Navigation prop for EF
        public int? MapLevel { get; set; }
        public virtual Map Map { get; set; }
        //True: It should transform, False: nope
        public bool IsTransform { get; set; }

        public bool isJumping(int deltatime)
        {
            if (IsGrounded && JUMPINGTIME > this.jumpCounter)
                return false;
            this.jumpCounter += deltatime;
            if (IsJumping)
            {
                return false;
            }
            return true;
        }

        public void Grounded()
        {
            IsGrounded = true;
            this.jumpCounter = 0;
        }
        private int jumpCounter;
    }
}
