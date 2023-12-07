namespace LivexDevTechnicalAssessment.Contracts
{
    public interface IRepositoryWrapper
    {
        IInventoryRepository InventoryRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        ICustomerInventoryRepository CustomerInventoryRepository { get; }
        void Save();
    }
}