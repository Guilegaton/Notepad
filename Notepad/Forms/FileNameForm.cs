using Notepad.Models;
using System;
using System.Windows.Forms;

namespace Notepad.Forms
{
    public partial class FileNameForm : Form
    {
        #region Protected Internal Fields

        protected internal bool IsFileSaved;

        #endregion Protected Internal Fields

        #region Private Fields

        private FileViewModel _currentFile;
        private DataProcessingService _processingService;

        #endregion Private Fields

        #region Public Constructors

        public FileNameForm(DataProcessingService dataProcessingService)
        {
            _processingService = dataProcessingService;

            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Methods

        public void ProcessTextData(string text)
        {
            IsFileSaved = false;
            _currentFile = new FileViewModel
            {
                TextData = text
            };
        }

        #endregion Public Methods

        #region Private Methods

        private async void SaveBTN_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FileNameTB.Text))
            {
                _currentFile.Name = FileNameTB.Text;
                if (await _processingService.SaveFile(_currentFile))
                {
                    IsFileSaved = true;
                    this.Close();
                    FileNameTB.Clear();
                }
                else
                {
                    MessageBox.Show("File with the same name already exists!", "Error");
                }
            }
            else
            {
                MessageBox.Show("File name is empty!", "Error");
            }
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            _currentFile = null;
            this.Close();
        }

        #endregion Private Methods

    }
}