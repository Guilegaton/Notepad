using Notepad.Models;
using System.Data.Entity;

namespace Notepad.DAL
{
    public class ApplicationContext : DbContext
    {
        #region Public Constructors

        public ApplicationContext() : base("LocalConnection")
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public DbSet<File> Files { get; set; }

        #endregion Public Properties
    }
}