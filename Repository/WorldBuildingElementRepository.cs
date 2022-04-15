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
    public class WorldBuildingElementRepository : IWorldBuildingElementRepository
    {
        DudeDbContext dudeDb;

        public WorldBuildingElementRepository(DudeDbContext dudeDb)
        {
            this.dudeDb = dudeDb;
        }

        public void Create(int id)
        {
            dudeDb.WorldBuildingElementTable.Add(new WorldBuildingElement { Id=id });
            dudeDb.SaveChanges();
        }

        public void Delete(int id)
        {
            dudeDb.WorldBuildingElementTable.Remove(Read(id));
            dudeDb.SaveChanges();
        }

        public WorldBuildingElement Read(int id)
        {
            return dudeDb.WorldBuildingElementTable.FirstOrDefault(worldBuildingElement => worldBuildingElement.Id == id);
        }

        public IQueryable<WorldBuildingElement> ReadAll()
        {
            return dudeDb.WorldBuildingElementTable;
        }
    }
}
