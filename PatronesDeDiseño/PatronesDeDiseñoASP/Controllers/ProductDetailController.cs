using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace PatronesDeDiseñoASP.Controllers
{
    public class ProductDetailController : Controller
    {

        private EarnFactory _localEarnFactory;


        public ProductDetailController(LocalEarnFactory localEarnFactory)
        {
            _localEarnFactory = localEarnFactory;
        }

        public IActionResult Index(decimal total)
        {

          


            var localEarn = _localEarnFactory.GetEarn();

            ViewBag.total = total + localEarn.Earn(total);

            EarnFactory foreingFactorr = new ForeingFactory(0.30m, 50);

            var foreingEarn = foreingFactorr.GetEarn();

            ViewBag.foreintTotal = total + foreingEarn.Earn(total);

            return View();
        }
    }
}
