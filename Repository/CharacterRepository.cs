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
    public class CharacterRepository : ICharacterRepository
    {
        DudeDbContext dudeDb;

        public CharacterRepository(DudeDbContext dudeDb)
        {
            this.dudeDb = dudeDb;
        }

        public void Create(int id)
        {
            dudeDb.CharacterTable.Add(new Character { Id=id });
            dudeDb.SaveChanges();
        }

        public void Delete(int id)
        {
            dudeDb.CharacterTable.Remove(Read(id));
            dudeDb.SaveChanges();
        }

        public Character Read(int id)
        {
            return dudeDb.CharacterTable.FirstOrDefault(character => character.Id == id);
        }

        public IQueryable<Character> ReadAll()
        {
            return dudeDb.CharacterTable;
        }
    }
}
