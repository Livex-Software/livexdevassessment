using LivexDevTechnicalAssessment.Contracts;
using LivexDevTechnicalAssessment.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LivexDevTechnicalAssessment.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected InventoryDbContext RepoContext { get; set; }
        public RepositoryBase(InventoryDbContext repositoryContext)
        {
            RepoContext = repositoryContext;
        }

        public async Task CreateAsync(T entity)
        {
            await RepoContext.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            RepoContext.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<IAsyncEnumerable<T>> FindAllAsync()
        {
            await Task.CompletedTask;
            return (IAsyncEnumerable<T>)RepoContext.Set<T>();
        }

        public async Task<IAsyncEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            await Task.CompletedTask;
            return (IAsyncEnumerable<T>)RepoContext.Set<T>().Where(expression);
        }        

        public async Task UpdateAsync(T entity)
        {
            RepoContext.Set<T>().Update(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task<T?> FindByIdAsync(Expression<Func<T, bool>> expression)
        {
            return await RepoContext.Set<T>().SingleOrDefaultAsync(expression);
        }

        public async Task SaveAsync()
        {
            await RepoContext.SaveChangesAsync();
        }
    }
}