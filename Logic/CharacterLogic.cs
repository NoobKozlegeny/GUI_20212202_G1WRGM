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
    public class CharacterLogic : ICharacterLogic
    {
        ICharacterRepository characterRepository;

        public CharacterLogic(ICharacterRepository characterRepository)
        {
            this.characterRepository = characterRepository;
        }

        public void Create(int id)
        {
            characterRepository.Create(id);
        }

        public void Delete(int id)
        {
            characterRepository.Delete(id);
        }

        public Character Read(int id)
        {
            return characterRepository.Read(id);
        }

        public IQueryable<Character> ReadAll()
        {
            return characterRepository.ReadAll();
        }
    }
}
