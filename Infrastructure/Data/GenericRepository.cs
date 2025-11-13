using Core.Interfaces;
using Core.Specifications;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(Guid id) 
            => await _context.Set<T>().FindAsync(id);

        public async Task<IReadOnlyList<T>> ListAllAsync() 
            => await _context.Set<T>().ToListAsync();

        public async Task<IReadOnlyList<T>> ListAsync(BaseSpecification<T> spec)
            => await ApplySpecification(spec).ToListAsync();

        public async Task<int> CountAsync(BaseSpecification<T> spec)
            => await ApplySpecification(spec).CountAsync();

        private IQueryable<T> ApplySpecification(BaseSpecification<T> spec)
            => SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);

        public async Task AddAsync(T entity)
            => await _context.Set<T>().AddAsync(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
