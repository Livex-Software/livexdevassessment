using LivexDevTechnicalAssessment.Contracts;
using LivexDevTechnicalAssessment.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace LivexDevTechnicalAssessment.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public InventoryController(ILogger<InventoryController> logger, IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Inventory model)
        {
            try
            {
                //CASE 1: Add inventory
                var data = await _repositoryWrapper.InventoryRepository.FindByIdAsync(x => x.InventoryId == model.InventoryId);

                if (model.InventoryName != null)
                {
                    data!.InventoryName = model.InventoryName;
                }

                if (model.Sku != null)
                {
                    data!.Sku = model.Sku;
                }

                await _repositoryWrapper.InventoryRepository.UpdateAsync(data!);
                await _repositoryWrapper.InventoryRepository.SaveAsync();

                TempData["response"] = "Inventory updated";
            }
            catch(Exception ex)
            {
                TempData["error"] = "Error updating inventory";
                _logger.LogError(ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }
        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inventory model)
        {
            try
            {
                //CASE 3: Add new inventory
                model.InventoryId = Guid.NewGuid();

                await _repositoryWrapper.InventoryRepository.CreateAsync(model);
                await _repositoryWrapper.InventoryRepository.SaveAsync();

                TempData["response"] = "Inventory added";
            }
            catch(Exception ex)
            {
                TempData["error"] = "Error adding inventory";
                _logger.LogError(ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                //Case 3: Remove inventory
                var inventory = await _repositoryWrapper.InventoryRepository.FindByIdAsync(x => x.InventoryId == id);
                await _repositoryWrapper.InventoryRepository.DeleteAsync(inventory!);
                await _repositoryWrapper.InventoryRepository.SaveAsync();

                TempData["response"] = "Inventory deleted";
            }catch(Exception ex)
            {
                TempData["error"] = "Error deleting inventory";
                _logger.LogError(ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}