using LivexDevTechnicalAssessment.Contracts;
using LivexDevTechnicalAssessment.Entities.Models;
using LivexDevTechnicalAssessment.Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LivexDevTechnicalAssessment.Repository
{
    public class CustomerInventoryRepository : RepositoryBase<CustomerInventory>, ICustomerInventoryRepository
    {
        public CustomerInventoryRepository(InventoryDbContext repositoryContext) : base(repositoryContext)
        {

        }

        public IEnumerable<CustomerInventoryModel> GetCustomerInventory(Guid customerId)
        {
            var data = (from a in RepoContext.CustomerInventories 
                        where a.CustomerId == customerId 
                        select a).ToList();

            var inventories = (from a in RepoContext.Inventories 
                               select a).ToList();


            var returnModel = new List<CustomerInventoryModel>();

            foreach (var item in inventories)
            {
                var count = data.Count(x => x.InventoryId == item.InventoryId);

                returnModel.Add(new CustomerInventoryModel
                {
                    InventoryName = item.InventoryName,
                    Quanity = count
                });
            }
            return returnModel;
        }
    }
}