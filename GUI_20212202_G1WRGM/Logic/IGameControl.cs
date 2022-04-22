using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_20212202_G1WRGM.Logic
{
    public interface IGameControl
    {
        public void OneTick();

        public void AI(List<Character> enemies);

        public void Move(Character character, int x);

        public void Jump(Character character);

        public void Roll(Character character);

        public void Fire(Character character);

        public void Reload(Character character);

        public void Strike(Character character);
    }
}
