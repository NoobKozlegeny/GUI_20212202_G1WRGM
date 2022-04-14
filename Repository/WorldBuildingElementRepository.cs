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
        public void Create(WorldBuildingElement wbe)
        {
            dudeDb.WorldBuildingElementTable.Add(wbe);
            dudeDb.SaveChanges();
        }

        public void Delete(int level, string name)
        {
            dudeDb.WorldBuildingElementTable.Remove(Read(level, name));
            dudeDb.SaveChanges();
        }

        public WorldBuildingElement Read(int level, string name)
        {
            return dudeDb.WorldBuildingElementTable
                .Where(wbe => wbe.MapLevel.Equals(level) && wbe.Name.Equals(name))
                .FirstOrDefault();
        }

        public IQueryable<WorldBuildingElement> ReadAll()
        {
            return dudeDb.WorldBuildingElementTable;
        }
    }
}
