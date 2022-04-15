using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface IItemRepository
    {
        public Item Read(int level, string name);
        public IQueryable<Item> ReadAll();
        public void Create(Item item);
        public void Delete(int level, string name);
    }
}
