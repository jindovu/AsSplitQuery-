using Demo.Models;
using Demo.Repository;
using Demo.Repository.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFabricTestRepository _fabricTestRepository;

        public HomeController(ILogger<HomeController> logger, IFabricTestRepository fabricTestRepository)
        {
            _logger = logger;
            _fabricTestRepository = fabricTestRepository;
        }

        public IActionResult Index()
        {
            var model = new FabricTestSearchDto() { SortColumn = new SortColumn() { ColumnName = "testResultTo", IsAsc = true } };
            var result = this._fabricTestRepository.GetAll(model);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
