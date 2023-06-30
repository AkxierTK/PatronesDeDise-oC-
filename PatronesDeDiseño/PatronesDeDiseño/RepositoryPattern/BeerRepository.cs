using PatronesDeDiseño.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDeDiseño.RepositoryPattern
{
    //Esta clase coge el contexto base de la app para poder trabajar con los objetos
    internal class BeerRepository : IBeerRepository
    {

        private PatronesDeDiseñoContext _context;



        public BeerRepository(PatronesDeDiseñoContext context)
        {
            _context = context;
        }

        //Si solo tiene una linea se puede hacer así
        //EntityFramework funciona igual que Eloquent
        public void Add(Beer beer) => _context.Beers.Add(beer);

        public void Delete(int id)
        {
            var  beer = _context.Beers.Find(id);  
            _context.Beers.Remove(beer);
        }

        public IEnumerable<Beer> Get() => _context.Beers.ToList();


        public Beer Get(int id) => _context.Beers.Find(id);


        public void Update(Beer beer) => _context.Entry(beer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
