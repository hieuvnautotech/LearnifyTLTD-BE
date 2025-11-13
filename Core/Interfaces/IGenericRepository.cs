using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();

        Task<IReadOnlyList<T>> ListAsync(BaseSpecification<T> spec);
        Task<int> CountAsync(BaseSpecification<T> spec);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveChangesAsync();
    }
}
