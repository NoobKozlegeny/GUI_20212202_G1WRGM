using Logic.Interfaces;
using Models;
using Repository;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class WorldBuildingElementLogic : IWorldBuildingElementLogic
    {
        IWorldBuildingElementRepository worldBuildingElementRepository;

        public WorldBuildingElementLogic(IWorldBuildingElementRepository worldBuildingElementRepository)
        {
            this.worldBuildingElementRepository = worldBuildingElementRepository;
        }

        public void Create(int id)
        {
            worldBuildingElementRepository.Create(id);
        }

        public void Delete(int id)
        {
            worldBuildingElementRepository.Delete(id);
        }

        public WorldBuildingElement Read(int id)
        {
            return worldBuildingElementRepository.Read(id);
        }

        public IQueryable<WorldBuildingElement> ReadAll()
        {
            return worldBuildingElementRepository.ReadAll();
        }
    }
}
