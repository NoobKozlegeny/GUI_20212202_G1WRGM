using Data;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ItemRepository : IItemRepository
    {
        DudeDbContext dudeDb;
        public ItemRepository(DudeDbContext dudeDb)
        {
            this.dudeDb = dudeDb;
        }
        public void Create(Item item)
        {
            dudeDb.ItemTable.Add(item);
            dudeDb.SaveChanges();
        }

        public void Delete(int level, string name)
        {
            dudeDb.ItemTable.Remove(Read(level, name));
            dudeDb.SaveChanges();
        }

        public Item Read(int level, string name)
        {
            return dudeDb.ItemTable
                .Where(item => item.MapLevel.Equals(level) && item.Name.Equals(name))
                .FirstOrDefault();
        }

        public IQueryable<Item> ReadAll()
        {
            return dudeDb.ItemTable;
        }
    }
}
