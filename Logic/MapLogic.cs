using Logic.Interfaces;
using Models;
using Repository.Interfaces;
using System;
using System.Linq;

namespace Logic
{
    public class MapLogic : IMapLogic
    {
        IMapRepository mapRepo;

        public MapLogic(IMapRepository mapRepo)
        {
            this.mapRepo = mapRepo;
        }

        public void Create(int level)
        {
            mapRepo.Create(level);
        }

        public void Delete(int level)
        {
            mapRepo.Delete(level);
        }

        public Map Read(int level)
        {
            return mapRepo.Read(level);
        }

        public IQueryable<Map> ReadAll()
        {
            return mapRepo.ReadAll();
        }
    }
}
