using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface IWorldBuildingElementRepository
    {
        public WorldBuildingElement Read(int level, string name);
        public IQueryable<WorldBuildingElement> ReadAll();
        public void Create(WorldBuildingElement wbe);
        public void Delete(int level, string name);
    }
}
