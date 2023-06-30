using PatronesDeDiseño.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.Repository
{
    public interface IUnitOfWork
    {
        public IRepository<Beer> Beers { get; }

        public IRepository<Brand> Brands { get; }
        public void save();

    }
}
