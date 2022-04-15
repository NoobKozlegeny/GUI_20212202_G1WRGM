using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface ICharacterRepository
    {
        public Character Read(int level, string name);
        public IQueryable<Character> ReadAll();
        public void Create(Character character);
        public void Delete(int level, string name);
    }
}
