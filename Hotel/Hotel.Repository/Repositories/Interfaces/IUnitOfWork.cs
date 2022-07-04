using System.Threading.Tasks;

namespace Hotel.Repository.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        DataContext DataContext { get; }

        Task<bool> CommitAsync();
    }
}
