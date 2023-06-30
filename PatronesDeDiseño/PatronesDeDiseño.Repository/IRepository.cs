using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.Repository
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> Get();

        TEntity Get(int id);

        void Add(TEntity data);

        void Update(TEntity data);

        void Delete(int id);

        void Save();
    }
}
