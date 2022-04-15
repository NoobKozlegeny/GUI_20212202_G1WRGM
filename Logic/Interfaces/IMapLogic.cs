using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IMapLogic
    {
        public void Create(int level);
        public Map Read(int level);
        public IQueryable<Map> ReadAll();
        public void Delete(int level);


    }
}
