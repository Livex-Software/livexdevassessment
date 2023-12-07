using LivexDevTechnicalAssessment.Entities.Models;
using LivexDevTechnicalAssessment.Entities.ViewModels;

namespace LivexDevTechnicalAssessment.Contracts
{
    public interface ICustomerInventoryRepository : IRepositoryBase<CustomerInventory>
    {
        public IEnumerable<CustomerInventoryModel> GetCustomerInventory(Guid customerId);
    }
}