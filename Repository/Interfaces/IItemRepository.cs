using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IItemRepository
    {
        public Item Read(int id);
        public IQueryable<Item> ReadAll();
        public void Create(int id);
        public void Delete(int id);
    }
}
