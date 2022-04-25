using GUI_20212202_G1WRGM.Logic;
using Models;
using Models.SystemComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace GUI_20212202_G1WRGM.Controller
{
    public enum MoveSet
    {
        None,
        Jump,
        Fire,
        Strike
    }

    public class GameController : IGameControl, IGameModel
    {
        private static int JumpTimeAmount = 400;
        private static int JumpVelocity = 1;
        private List<Item> items;
        private Player player;
        private List<NPC> enemies;
        private List<Bullet> bullets;
        private int fireRate;
        private DispatcherTimer timeClock;
        

        public List<Item> Items { get => this.items; set => this.items = value; }
        public Player Player { get => this.player; set => this.player = value; }
        public List<NPC> Enemies { get => this.enemies; set => this.enemies = value; }
        public List<Bullet> Bullets { get => this.bullets; set => this.bullets = value; }
        public DispatcherTimer Time => this.timeClock;

        public GameController()
        {
            this.SetupLogic();

            // for testing
            this.player.Position = new Point(100, 100);
        }

        public void AI()
        {
            Random rnd = new Random();
            int chance = 0;
           // List<NPC> list = new List<NPC>();
            foreach (NPC item in Enemies)
            {
               // NPC npc = item;
                chance = rnd.Next(0, 101);
                if (chance <= 40)
                {
                    switch (item.Direction)
                    {
                        default:
                        case Direction.Left:
                            item.Direction = Direction.Right;
                            break;
                        case Direction.Right:
                            item.Direction = Direction.Left;
                            break;
                    }
                }
                switch (item.Direction)
                {
                    default:
                    case Direction.Left:
                        Move(item, -1, 0);
                        break;
                    case Direction.Right:
                        Move(item, 1, 0);
                        break;
                }
                chance = rnd.Next(0, 101);
                if (chance> 80)
                {
                    // Do nothing
                }else if(chance > 50)
                {
                    item.IsGrounded = false;
                }
                else
                {
                    Vector2 playervec = new Vector2(Player.Position.X, Player.Position.Y);
                    Vector2 enemyvec = new Vector2(item.Position.X, item.Position.Y);
                    Vector2 dir = Vector2.Subtract(playervec, enemyvec);
                    Fire(item, Vector2.Normalize(dir));
                }

                if (item.FireArm.AmmoAmount == 0)
                {
                    item.FireArm.AmmoAmount = item.FireArm.MaxAmmo;
                }
                //list.Add(npc);
            }
            //Enemies.Clear();
            //Enemies.AddRange(list);
            //foreach (NPC item in Enemies)
            //{
            //    switch (item.Direction)
            //    {
            //        default:
            //        case Direction.Left:
            //            Move(item, -1, 0);
            //            break;
            //        case Direction.Right:
            //            Move(item, 1, 0);
            //            break;
            //    }
            //    if (item.FireArm.AmmoAmount == 0)
            //    {
            //        item.FireArm.AmmoAmount = item.FireArm.MaxAmmo;
            //    }
            //}

        }

        public void Fire(Character character, Vector2 direction)
        {
            if (character is Player)
            {
                Player currentPlayer = character as Player;
                Weapon currentWeapon = currentPlayer.SelectedItem as Weapon;

                if (this.WeaponCheck(currentWeapon))
                {
                    currentWeapon.NumericFireRate--;
                    Bullet bullet = new Bullet(new Vector2(currentWeapon.Position.X, currentWeapon.Position.Y), currentWeapon.Damage, direction, 2,true);
                    this.Bullets.Add(bullet);
                }
               
            }
            else
            {
                NPC currentEnemy = character as NPC;

                if (this.WeaponCheck(currentEnemy.FireArm))
                {
                    currentEnemy.FireArm.NumericFireRate--;
                    Bullet bullet = new Bullet(new Vector2(currentEnemy.FireArm.Position.X, currentEnemy.FireArm.Position.Y), currentEnemy.FireArm.Damage, direction, 2,false);
                    this.Bullets.Add(bullet);
                }
            }
        }

        public void Jump(Character character)
        {
            if (character is Player)
            {
                if (this.Player.IsGrounded)
                {
                    character.IsGrounded = false;
                }
            }
            else
            {
                Enemies.Remove(character as NPC);
                character.IsGrounded = false;
                Enemies.Add(character as NPC);
            }
        }

        public void Move(Character character, int x, int y)
        {
            // x =>
            // y lefelé
            Point newPosition = new Point(character.Position.X + (x * character.Speed), character.Position.Y + (y * character.Speed));
            character.Position = newPosition;
        }

        public void OneTick()
        {
            AI();
            Physics();
        }

        private void Physics()
        {
            if (Player.IsGrounded && !Player.IsJumping)
            {
                Point newPos = new Point(Player.Position.X, Player.Position.Y + 1);
                Player.Position = newPos;
            }
            foreach (NPC item in Enemies)
            {
                if (item.IsGrounded && !item.IsJumping)
                {
                    Point newPos = new Point(item.Position.X, item.Position.Y + 1);
                    item.Position = newPos;
                }
            }
            foreach (Bullet item in Bullets)
            {
                Vector2 newPos = Vector2.Add(item.Position, item.Direction);
                item.Position = newPos;
            }
            // Movable object
        }

        public void Reload(Character character)
        {
            if (character is Player)
            {
                Player currentPlayer = character as Player;
                Weapon currentWeapon = currentPlayer.Inventory.SelectedItem as Weapon;

                if (currentWeapon != null)
                {
                    currentWeapon.AmmoAmount = currentWeapon.MaxAmmo;
                }
            }
            else
            {
                NPC currentEnemy = character as NPC;
                currentEnemy.FireArm.AmmoAmount = currentEnemy.FireArm.MaxAmmo;
            }
        }

        public void Roll(Player character)
        {
            if(character.DoRoll())
            {
                player.IsInvincibly = true;
            }
        }

        public void Strike(Character character)
        {
            if (character is Player)
            {
                float mindistance = 9000000;
                NPC nPC = null;
                foreach (NPC item in Enemies)
                {
                    
                    Vector2 playervec = new Vector2(character.Position.X, character.Position.Y);
                    Vector2 enemyvec = new Vector2(item.Position.X, item.Position.Y);
                    float currentDistance = Vector2.DistanceSquared(playervec, enemyvec);
                    if (mindistance < currentDistance)
                    {
                        mindistance = currentDistance;
                        nPC = item;
                    }
                }
                if(mindistance<100)
                {
                    this.DoDamage(nPC);
                }
            }
            else
            {
                Vector2 enemyvec = new Vector2(character.Position.X, character.Position.Y);
                Vector2 playervec = new Vector2(Player.Position.X, Player.Position.Y);
                float distanc = Vector2.DistanceSquared(enemyvec, playervec);
                if (distanc < 100)
                {
                    DoDamage(Player);
                }
            }
        }

        private void DoDamage(Character character)
        {
           if(character is Player)
            {
                Player.HealthPoints -= 5;
            }
            else
            {
                NPC nPC = character as NPC;
                Enemies.Remove(nPC);
                nPC.HealthPoints -= 5;
                Enemies.Add(nPC);
            }
        }

        private void SetupLogic()
        {
            this.player = new Player();
            this.enemies = new List<NPC>();
            this.items = new List<Item>();
            this.bullets = new List<Bullet>();
            this.fireRate = 0;
            timeClock = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(1) };
            timeClock.Start();
        }

        private void TimeClock_Tick(object sender, EventArgs e)
        {
            this.Jumping();
            this.Rolling();
            this.FIreRateReset();
        }

        private void FIreRateReset()
        {
            this.fireRate++;
            if (this.fireRate == 100)
            {
                this.fireRate = 0;
                if (Player.SelectedItem is Weapon)
                {
                    (Player.SelectedItem as Weapon).ResetFireRate();
                }
                foreach (NPC item in Enemies)
                {
                    item.FireArm.ResetFireRate();
                }
                this.fireRate = 0;
            }
        }

        private void Rolling()
        {
            if(Player.isRolling(1))
            {
                Vector2 point = new Vector2(Player.Position.X + (1 * (Player.Speed * 2)), Player.Position.Y);
            }
        }

        private void Jumping()
        {
            if (Player.isJumping(1))
            {
                Vector2 point = new Vector2(Player.Position.X, Player.Position.Y - 1);
            }
            List<NPC> nPCs = new List<NPC>();
            nPCs.AddRange(Enemies);
            foreach (NPC item in Enemies)
            {
                if (item.isJumping(1))
                {
                    item.Position = new Point(item.Position.X, item.Position.Y - 1);
                }
            }
            //foreach (NPC item in nPCs)
            //{
            //    if (item.isJumping(1))
            //    {
            //        Vector2 point = new Vector2(item.Position.X, item.Position.Y - 1);
            //        Enemies.FirstOrDefault(x => x.Id == item.Id).Position = new Vector2(point.X, point.Y);
            //    }
            //}
        }


        private bool WeaponCheck(Weapon currentWeapon)
        {
            if (currentWeapon != null && currentWeapon.AmmoAmount > 0 && currentWeapon.NumericFireRate > 0)
                return true;
            return false;
        }
    }
  
}
