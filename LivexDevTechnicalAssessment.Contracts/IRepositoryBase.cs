using System.Linq.Expressions;

namespace LivexDevTechnicalAssessment.Contracts
{
    public interface IRepositoryBase<T>
    {
        Task<IAsyncEnumerable<T>> FindAllAsync();
        Task<IAsyncEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T?> FindByIdAsync(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveAsync();
    }
}