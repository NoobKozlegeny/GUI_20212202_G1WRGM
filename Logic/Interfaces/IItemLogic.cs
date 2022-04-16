using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IItemLogic
    {
        public void Create(int id);
        public Item Read(int id);
        public IQueryable<Item> ReadAll();
        public void Delete(int id);
    }
}
