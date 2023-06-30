using PatronesDeDiseño.DependencyInjectionPattern;
using PatronesDeDiseño.Models;
using PatronesDeDiseño.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beer = PatronesDeDiseño.Models.Beer;

namespace PatronesDeDiseño.UnityOfWorkPattern
{
    public interface IUnitOfWork
    {

        public IRepositoryGenerics<Beer> Beers { get; }

        public IRepositoryGenerics<Brand> Brands { get; }


        public void save();

    }
}
