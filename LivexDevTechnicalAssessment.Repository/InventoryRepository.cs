using LivexDevTechnicalAssessment.Contracts;
using LivexDevTechnicalAssessment.Entities.Models;
using LivexDevTechnicalAssessment.Entities.ViewModels;

namespace LivexDevTechnicalAssessment.Repository
{
    public class InventoryRepository : RepositoryBase<Inventory>, IInventoryRepository
    {
        public InventoryRepository(InventoryDbContext repositoryContext) : base(repositoryContext)
        {

        }

        public List<CheckoutModel> GetInventory(Guid customerId)
        {
            return (from a in RepoContext.Inventories
                        select new CheckoutModel
                        {
                            Inventories = a,
                            CustomerId = customerId
                        }).ToList();
        }
    }
}