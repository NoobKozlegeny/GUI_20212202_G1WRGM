using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IWorldBuildingElementRepository
    {
        public WorldBuildingElement Read(int id);
        public IQueryable<WorldBuildingElement> ReadAll();
        public void Create(int id);
        public void Delete(int id);
    }
}
