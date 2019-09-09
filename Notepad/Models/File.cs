using Notepad.SharedKernel.Models;

namespace Notepad.Models
{
    public class File : BaseEntity
    {
        #region Public Properties

        public byte[] Data { get; set; }
        public string Name { get; set; }

        #endregion Public Properties
    }
}