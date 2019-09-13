using Notepad.Models;
using Notepad.SharedKernel.Interfaces;
using System.Threading.Tasks;

namespace Notepad.DAL.Interfaces
{
    public interface IFileRepository : IRepository<File>
    {
        #region Public Methods

        Task<bool> IsFileExists(string fileName);

        #endregion Public Methods
    }
}