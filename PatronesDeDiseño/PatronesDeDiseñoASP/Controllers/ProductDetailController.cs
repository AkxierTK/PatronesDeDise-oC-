using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace PatronesDeDiseñoASP.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index(decimal total)
        {

            LocalEarnFactory localEarnFactory = new LocalEarnFactory(0.20m);


            var localEarn = localEarnFactory.GetEarn();

            ViewBag.total = total + localEarn.Earn(total);

            EarnFactory foreingFactorr = new ForeingFactory(0.30m, 50);

            var foreingEarn = foreingFactorr.GetEarn();

            ViewBag.foreintTotal = total + foreingEarn.Earn(total);

            return View();
        }
    }
}
