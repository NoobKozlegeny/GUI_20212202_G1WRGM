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

        public void Create(int id)
        {
            dudeDb.ItemTable.Add(new Item { Id=id });
            dudeDb.SaveChanges();
        }

        public void Delete(int id)
        {
            dudeDb.ItemTable.Remove(Read(id));
            dudeDb.SaveChanges();
        }

        public Item Read(int id)
        {
            return dudeDb.ItemTable.FirstOrDefault(item => item.Id == id);
        }

        public IQueryable<Item> ReadAll()
        {
            return dudeDb.ItemTable;
        }
    }
}
