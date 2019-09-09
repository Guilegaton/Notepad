using Notepad.Models;
using Notepad.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.DAL.Interfaces
{
    interface IFileRepository : IRepository<File>
    {
    }
}
