using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PatronesDeDiseño.Models.Data;
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
        [HttpGet]
        public IActionResult Add()
        {

            var brands = _unitOfWork.Brands.Get();

            ViewBag.Brands = new SelectList(brands, "BrandId", "Name");

            return View();
        }


        [HttpPost]
        public IActionResult Add(FormBeerViewModel beerVM)
        {
            //Si no es valido algo de DataNotations(Requerido entra y devuelve los datos)
            if(!ModelState.IsValid)
            {
                var brands = _unitOfWork.Brands.Get();
                ViewBag.Brands = new SelectList(brands, "BrandId", "Name");
                return View("Add", beerVM);
            }

            var beer = new Beer();

            beer.Name= beerVM.Name;

            beer.Style = beerVM.Style;

            if (beerVM.BrandId == null)
            {
                var brand = new Brand();

                brand.Name = beerVM.OtherBrand;
                brand.BrandId = Guid.NewGuid();
                beer.BrandId = brand.BrandId;
                _unitOfWork.Brands.Add(brand);
            }
            else
            {
                beer.BrandId = (Guid)beerVM.BrandId;
            }

            _unitOfWork.Beers.Add(beer);
            _unitOfWork.save();

            return RedirectToAction("Index");
        }


    }
}
