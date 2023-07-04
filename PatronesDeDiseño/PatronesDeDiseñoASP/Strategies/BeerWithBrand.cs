using PatronesDeDiseño.Models.Data;
using PatronesDeDiseño.Repository;
using PatronesDeDiseñoASP.Models.ViewModels;

namespace PatronesDeDiseñoASP.Strategies
{
    public class BeerWithBrand : IBeerStrategy
    {
        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork)
        {
            var beer = new Beer();

            beer.Name = beerVM.Name;
            beer.Style = beerVM.Style;

            var brand = new Brand();
            brand.Name = beerVM.OtherBrand;
            brand.BrandId= Guid.NewGuid();

            beer.BrandId=brand.BrandId;

            unitOfWork.Brands.Add(brand);
            unitOfWork.Beers.Add(beer);

            unitOfWork.save();
        }
    }
}
