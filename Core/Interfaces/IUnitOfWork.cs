using Core.Interfaces;

namespace Learnify.Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        // add other repos: IOrderRepository Orders { get; }
        Task<int> SaveChangesAsync();
    }
}
