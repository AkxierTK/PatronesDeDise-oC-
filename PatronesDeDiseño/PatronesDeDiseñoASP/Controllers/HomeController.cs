using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PatronesDeDiseño.Models.Data;
using PatronesDeDiseño.Repository;
using PatronesDeDiseñoASP.Configuration;
using PatronesDeDiseñoASP.Models;
using System.Diagnostics;
using Tools;

namespace PatronesDeDiseñoASP.Controllers
{
    public class HomeController : Controller
    {

        private readonly IOptions<MiConfig> _config;

        private readonly IRepository<Beer> _repository;

        public HomeController(IOptions<MiConfig> config, IRepository<Beer> repository)
        {
            _config = config;
            _repository = repository;
        }

        public IActionResult Index()
        {

            IEnumerable <Beer> list = _repository.Get();

            Log.GetInstance(_config.Value.PathLog).Save("Entro a Index");
            return View("Index",list);
        }

        public IActionResult Privacy()
        {
            Log.GetInstance(_config.Value.PathLog).Save("Entro a Privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}