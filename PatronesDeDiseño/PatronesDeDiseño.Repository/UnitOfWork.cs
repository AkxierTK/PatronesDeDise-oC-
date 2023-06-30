using PatronesDeDiseño.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private PatronesDeDiseñoContext _context;

        public IRepository<Beer> beers;
        public IRepository<Brand> brands;

        public UnitOfWork(PatronesDeDiseñoContext context)
        {
            _context = context;
        }


        public IRepository<Beer> Beers
        {
            get
            {
                return beers == null ? new Repository<Beer>(_context) : beers;
            }
        }

        public IRepository<Brand> Brands
        {
            get
            {
                return brands == null ? new Repository<Brand>(_context) : brands;
            }
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
