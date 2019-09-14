using System;
using System.Linq;
using System.Threading.Tasks;

namespace Notepad.SharedKernel.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        #region Public Methods

        Task CreateAsync(T item);

        Task DeleteByIdAsync(long id);

        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(long id);

        Task UpdateAsync(T item);

        Task<bool> IsEntityExists(long id);

        #endregion Public Methods
    }
}