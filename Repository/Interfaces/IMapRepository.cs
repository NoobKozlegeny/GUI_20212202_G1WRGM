using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IMapRepository
    {
        public Map Read(int level);
        public IQueryable<Map> ReadAll();
        public void Create(int level);
        public void Delete(int level);

    }
}
