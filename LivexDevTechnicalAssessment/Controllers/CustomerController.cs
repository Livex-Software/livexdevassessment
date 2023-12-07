using LivexDevTechnicalAssessment.Contracts;
using LivexDevTechnicalAssessment.Entities.Models;
using LivexDevTechnicalAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LivexDevTechnicalAssessment.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CustomerController(ILogger<CustomerController> logger, IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IActionResult> Index()
        {
            //CASE 2: Get all inventory from DB
            var data = await _repositoryWrapper.CustomerRepository.FindAllAsync();

            //pass data to view
            return View(data);
        }
        

        public IActionResult Add()
        {
            return View();
        }
        
        public IActionResult Checkout(Guid id)
        {
            var model = _repositoryWrapper.InventoryRepository.GetInventory(id);

            return View(model);
        }
        public async Task<IActionResult> Create(Customer model)
        {
            try
            {
                //CASE 3: Add new inventory
                model.CustomerId = Guid.NewGuid();

                await _repositoryWrapper.CustomerRepository.CreateAsync(model);
                await _repositoryWrapper.CustomerRepository.SaveAsync();

                TempData["response"] = "Customer added";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error adding customer";
                _logger.LogError(ex.Message);
            }

            return RedirectToAction("Index", "Customer");
        }

        public async Task<IActionResult> CreateCustomerInventory(Guid[] InventoryIdList, Guid customerId)
        {
            try
            {
                foreach (var item in InventoryIdList)
                {
                    await _repositoryWrapper.CustomerInventoryRepository.CreateAsync(new CustomerInventory
                    {
                        CustomerInventoryId = Guid.NewGuid(),
                        CustomerId = customerId,
                        InventoryId = item
                    });
                }

                await _repositoryWrapper.CustomerInventoryRepository.SaveAsync();

                TempData["response"] = "Customer inventory updated";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error updating customer inventory";
                _logger.LogError(ex.Message);
            }

            return RedirectToAction("CustomerInventory", "Customer", new { customerId = customerId});
        }

        public IActionResult CustomerInventory(Guid customerId)
        {

            return View(_repositoryWrapper.CustomerInventoryRepository.GetCustomerInventory(customerId));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}