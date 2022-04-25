using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_G1WRGM.Logic
{
    public interface IGameControl
    {
        public void OneTick();

        public void AI();

        public void Move(Character character, int x, int y);

        public void Jump(Character character);

        public void Roll(Player character);

        public void Fire(Character character, Vector2 direction);

        public void Reload(Character character);

        public void Strike(Character character);
    }
}
