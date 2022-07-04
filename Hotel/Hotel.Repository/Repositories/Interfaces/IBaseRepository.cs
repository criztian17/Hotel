using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// IQueryable T
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Get T by Id
        /// </summary>
        /// <param name="id">T id</param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Create T
        /// </summary>
        /// <param name="entity">T Entity</param>
        /// <returns>T Entity</returns>
        Task<T> CreateAsync(T entity);

        /// <summary>
        /// Update T
        /// </summary>
        /// <param name="entity">T Entity</param>
        /// <returns>bool</returns>
        Task<bool> UpdateAsync(T entity);

        /// <summary>
        /// Delete T
        /// </summary>
        /// <param name="entity">T entity</param>
        /// <returns>bool</returns>
        Task<bool> DeleteAsync(T entity);

        /// <summary>
        /// Validate if exist T by Id
        /// </summary>
        /// <param name="id">T id</param>
        /// <returns>bool</returns>
        Task<bool> ExistAsync(int id);
    }
}
