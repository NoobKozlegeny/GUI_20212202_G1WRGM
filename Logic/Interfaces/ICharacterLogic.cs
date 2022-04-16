using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICharacterLogic
    {
        public void Create(int id);
        public Character Read(int id);
        public IQueryable<Character> ReadAll();
        public void Delete(int id);
    }
}
