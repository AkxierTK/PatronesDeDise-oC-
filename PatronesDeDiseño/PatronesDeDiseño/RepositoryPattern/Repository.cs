using Microsoft.EntityFrameworkCore;
using PatronesDeDiseño.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.RepositoryPattern
{
    //Where indica lo que quieres que sea si o si TEntity

    //Al usar TEntity nos permite trabajar con cualquiera de las tablas de la base de datos que esten modeladas sin necesidad de saber su clase
    public class Repository<TEntity> : IRepositoryGenerics<TEntity> where TEntity : class
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
            _dbSet.Entry(data).State= EntityState.Modified;
        }
    }
}
