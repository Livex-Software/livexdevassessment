using LivexDevTechnicalAssessment.Contracts;
using LivexDevTechnicalAssessment.Entities.Models;
using Microsoft.Extensions.Configuration;

namespace LivexDevTechnicalAssessment.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly InventoryDbContext _repoContext;
        private readonly IConfiguration? _configuration;

        private IInventoryRepository? _inventoryRepository;
        private ICustomerInventoryRepository? _customerInventoryRepository;
        private ICustomerRepository? _customerRepository;

        public RepositoryWrapper(InventoryDbContext repositoryContext, IConfiguration configuration)
        {
            _repoContext = repositoryContext;
            _configuration = configuration;
        }

        public RepositoryWrapper(InventoryDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        
        public ICustomerInventoryRepository CustomerInventoryRepository
        {
            get
            {
                _customerInventoryRepository ??= new CustomerInventoryRepository(_repoContext);
                return _customerInventoryRepository;
            }
        }
        
        public ICustomerRepository CustomerRepository
        {
            get
            {
                _customerRepository ??= new CustomerRepository(_repoContext);
                return _customerRepository;
            }
        }
        
        public IInventoryRepository InventoryRepository
        {
            get
            {
                _inventoryRepository ??= new InventoryRepository(_repoContext);
                return _inventoryRepository;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}