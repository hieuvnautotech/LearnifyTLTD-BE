using System.Collections.Generic;
using System.Threading.Tasks;
using Entity;

namespace Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<Category>> ListAllAsync();
    }
}
