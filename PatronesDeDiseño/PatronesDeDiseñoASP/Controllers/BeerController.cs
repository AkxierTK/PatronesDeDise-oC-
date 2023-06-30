using Microsoft.AspNetCore.Mvc;
using PatronesDeDiseño.Repository;
using PatronesDeDiseñoASP.Models.ViewModels;

namespace PatronesDeDiseñoASP.Controllers
{
    public class BeerController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;


        public BeerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            IEnumerable<BeerViewModel> beers = from d in _unitOfWork.Beers.Get()
                                               select new BeerViewModel
                                               {
                                                   id = d.BeerId,
                                                   Name = d.Name,
                                                   Style = d.Style
                                               };
                                                 
                                                 //(IEnumerable<BeerViewModel>)_unitOfWork.Beers.Get();
            return View("Index",beers);
        }
    }
}
