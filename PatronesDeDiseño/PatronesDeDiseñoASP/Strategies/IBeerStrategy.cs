using PatronesDeDiseño.Repository;
using PatronesDeDiseñoASP.Models.ViewModels;

namespace PatronesDeDiseñoASP.Strategies
{
    public interface IBeerStrategy
    {
        public void Add(FormBeerViewModel beer, IUnitOfWork unitOfWork);

    }
}
