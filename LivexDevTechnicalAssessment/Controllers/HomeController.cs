using LivexDevTechnicalAssessment.Contracts;
using LivexDevTechnicalAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LivexDevTechnicalAssessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public HomeController(ILogger<HomeController> logger, IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IActionResult> Index()
        {
            //CASE 2: Get all inventory from DB
            var data = await _repositoryWrapper.InventoryRepository.FindAllAsync();

            //pass data to view
            return View(data);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var inventory = await _repositoryWrapper.InventoryRepository.FindByIdAsync(x => x.InventoryId == id);

            return View(inventory);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}