using LivexDevTechnicalAssessment.Contracts;
using LivexDevTechnicalAssessment.Entities.Models;

namespace LivexDevTechnicalAssessment.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(InventoryDbContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}