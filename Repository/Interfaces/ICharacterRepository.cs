using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICharacterRepository
    {
        public Character Read(int id);
        public IQueryable<Character> ReadAll();
        public void Create(int id);
        public void Delete(int id);
    }
}
