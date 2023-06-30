using Microsoft.EntityFrameworkCore;
using PatronesDeDiseño.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private PatronesDeDiseñoContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(PatronesDeDiseñoContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }


        public void Add(TEntity data) => _dbSet.Add(data);


        public void Delete(int id)
        {
            var dataDelete = _dbSet.Find(id);
            _dbSet.Remove(dataDelete);
        }

        public IEnumerable<TEntity> Get() => _dbSet.ToList();

        public TEntity Get(int id) => _dbSet.Find(id);


        public void Save() => _context.SaveChanges();


        public void Update(TEntity data)
        {
            _dbSet.Attach(data);
            _dbSet.Entry(data).State = EntityState.Modified;
        }
    }
}
