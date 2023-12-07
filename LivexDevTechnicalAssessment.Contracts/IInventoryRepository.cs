using LivexDevTechnicalAssessment.Entities.Models;
using LivexDevTechnicalAssessment.Entities.ViewModels;

namespace LivexDevTechnicalAssessment.Contracts
{
    public interface IInventoryRepository : IRepositoryBase<Inventory>
    {
        public List<CheckoutModel> GetInventory(Guid customerId);
    }
}