using PatronesDeDiseño.Models.Data;
using PatronesDeDiseño.Repository;
using PatronesDeDiseñoASP.Models.ViewModels;

namespace PatronesDeDiseñoASP.Strategies
{
    public class BeerStrategy : IBeerStrategy
    {
        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork)
        {
            var beer = new Beer();

            beer.Name=beerVM.Name;
            beer.Style=beerVM.Style;
            beer.BrandId= (Guid)beerVM.BrandId;

            unitOfWork.Beers.Add(beer);

            unitOfWork.save();

        }
    }
}
