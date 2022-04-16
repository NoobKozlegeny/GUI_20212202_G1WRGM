using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IWorldBuildingElementLogic
    {
        public void Create(int id);
        public WorldBuildingElement Read(int id);
        public IQueryable<WorldBuildingElement> ReadAll();
        public void Delete(int id);
    }
}
