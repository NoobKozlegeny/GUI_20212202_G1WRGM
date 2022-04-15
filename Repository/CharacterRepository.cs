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
        public void Create(Character character)
        {
            dudeDb.CharacterTable.Add(character);
            dudeDb.SaveChanges();
        }

        public void Delete(int level, string name)
        {
            dudeDb.CharacterTable.Remove(Read(level, name));
            dudeDb.SaveChanges();
        }

        public Character Read(int level, string name)
        {
            return dudeDb.CharacterTable
                .Where(character => character.MapLevel.Equals(level) && character.Name.Equals(name))
                .FirstOrDefault();
        }

        public IQueryable<Character> ReadAll()
        {
            return dudeDb.CharacterTable;
        }
    }
}
