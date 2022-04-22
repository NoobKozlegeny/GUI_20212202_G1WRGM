using GUI_20212202_G1WRGM.Logic;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_G1WRGM.Controller
{
    public class GameController : IGameControl, IGameModel
    {
        private List<Item> staticObject;
        private List<Item> movingObject;
        private Character player;
        private List<Character> enemies;
        private List<Bullets> bullets;

        public List<Item> StaticObject { get => this.staticObject; set => this.staticObject = value; }
        public List<Item> MovingObject { get => this.movingObject; set => this.movingObject = value; }
        public Character Player { get => this.player; set => this.player = value; }
        public List<Character> Enemies { get => this.enemies; set => this.enemies = value; }
        public List<Bullets> Bullets { get => this.bullets; set => this.bullets = value; }

        public void AI(List<Character> enemies)
        {
            throw new NotImplementedException();
        }

        public void Fire(Character character)
        {
            throw new NotImplementedException();
        }

        public void Jump(Character character)
        {
            throw new NotImplementedException();
        }

        public void Move(Character character, int x)
        {
            throw new NotImplementedException();
        }

        public void OneTick()
        {
            throw new NotImplementedException();
        }

        public void Reload(Character character)
        {
            throw new NotImplementedException();
        }

        public void Roll(Character character)
        {
            throw new NotImplementedException();
        }

        public void Strike(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
