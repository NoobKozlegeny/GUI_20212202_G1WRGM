using Data;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class MapRepository : IMapRepository
    {
        DudeDbContext dudeDb;
        public MapRepository(DudeDbContext dudeDb)
        {
            this.dudeDb = dudeDb;
        }
        public void Create(int level)
        {
            dudeDb.MapTable.Add(new Map() { Level = level});
            dudeDb.SaveChanges();
        }

        public void Delete(int level)
        {
            dudeDb.MapTable.Remove(Read(level));
            dudeDb.SaveChanges();
        }

        public Map Read(int level)
        {
            return dudeDb.MapTable.FirstOrDefault(map => map.Level == level);
        }

        public IQueryable<Map> ReadAll()
        {
            return dudeDb.MapTable;
        }
    }
}
