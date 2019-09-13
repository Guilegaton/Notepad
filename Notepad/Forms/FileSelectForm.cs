using Notepad.Models;
using Notepad.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad.Forms
{
    public partial class FileSelectForm : Form
    {
        private readonly IRepository<File> _repository;

        public FileSelectForm(IRepository<File> repository)
        {
            _repository = repository;

            InitializeComponent();
        }
    }
}
