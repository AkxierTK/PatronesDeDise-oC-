using PatronesDeDiseño.Repository;
using PatronesDeDiseñoASP.Models.ViewModels;

namespace PatronesDeDiseñoASP.Strategies
{
    public class BeerContext
    {
        private IBeerStrategy _strategy;

        public IBeerStrategy Strategy
        {
            set { _strategy = value; }
        }

        public BeerContext(IBeerStrategy strategy)
        {
            _strategy = strategy;
        }

        public void add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork) 
        {
            _strategy.Add(beerVM, unitOfWork);
        }


    }
}
