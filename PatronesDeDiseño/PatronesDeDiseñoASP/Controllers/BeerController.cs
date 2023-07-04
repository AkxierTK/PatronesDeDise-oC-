using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PatronesDeDiseño.Models.Data;
using PatronesDeDiseño.Repository;
using PatronesDeDiseñoASP.Models.ViewModels;
using PatronesDeDiseñoASP.Strategies;

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
        [HttpGet]
        public IActionResult Add()
        {

            var brands = _unitOfWork.Brands.Get();

            GetBrandsData();

            return View();
        }


        [HttpPost]
        public IActionResult Add(FormBeerViewModel beerVM)
        {
            //Si no es valido algo de DataNotations(Requerido entra y devuelve los datos)
            if(!ModelState.IsValid)
            {
                GetBrandsData();
                return View("Add", beerVM);
            }

            var context = beerVM.BrandId == null ? new BeerContext(new BeerWithBrand()) : new BeerContext(new BeerStrategy());

            context.add(beerVM, _unitOfWork);
           
            return RedirectToAction("Index");
        }

        #region HELPERS

        private void GetBrandsData()
        {
            var brands = _unitOfWork.Brands.Get();
            ViewBag.Brands = new SelectList(brands, "BrandId", "Name");
        }

        #endregion


    }
}
