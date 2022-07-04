using Hotel.Repository.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Hotel.Repository.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties
        public DataContext DataContext { get; }
        #endregion

        #region Constructors
        public UnitOfWork(DataContext dataContext)
        {
            DataContext = dataContext;
        }
        #endregion

        #region Public Methods

        public async Task<bool> CommitAsync()
        {
            return await DataContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            DataContext.Dispose();
        } 
        #endregion
    }
}
