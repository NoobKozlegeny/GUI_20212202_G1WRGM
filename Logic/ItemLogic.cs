using Logic.Interfaces;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ItemLogic : IItemLogic
    {
        IItemRepository itemRepository;

        public ItemLogic(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public void Create(int id)
        {
            itemRepository.Create(id);
        }

        public void Delete(int id)
        {
            itemRepository.Delete(id);
        }

        public Item Read(int id)
        {
            return itemRepository.Read(id);
        }

        public IQueryable<Item> ReadAll()
        {
            return itemRepository.ReadAll();
        }
    }
}
