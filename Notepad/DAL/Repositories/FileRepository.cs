using Notepad.DAL.Interfaces;
using Notepad.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Notepad.DAL.Repositories
{
    public class FileRepository : IFileRepository
    {
        #region Private Fields

        private readonly ApplicationContext _context;

        #endregion Private Fields

        #region Public Constructors

        public FileRepository(ApplicationContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task CreateAsync(File item)
        {
            _context.Files.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(long id)
        {
            var item = await GetByIdAsync(id);
            _context.Files.Remove(item);

            await _context.SaveChangesAsync();
        }

        public IQueryable<File> GetAll()
        {
            return _context.Files.AsQueryable();
        }

        public async Task<File> GetByIdAsync(long id)
        {
            return await _context.Files.FirstOrDefaultAsync(file => file.Id == id);
        }

        public async Task UpdateAsync(File item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        #endregion Public Methods
    }
}