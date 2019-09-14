using Notepad.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad.Forms
{
    public partial class MainMenuForm : Form
    {
        #region Private Fields

        private readonly DataProcessingService _dataProcessingService;
        private readonly FileSelectForm _deleteFileFrom;
        private readonly FileSelectForm _openFileForm;
        private readonly FileNameForm _saveFileForm;
        private FileViewModel _currentFile;

        #endregion Private Fields

        #region Public Constructors

        public MainMenuForm(FileSelectForm openFileForm, FileSelectForm deleteFileForm, FileNameForm saveFileForm, DataProcessingService dataProcessingService)
        {
            _openFileForm = openFileForm;
            _deleteFileFrom = deleteFileForm;
            _saveFileForm = saveFileForm;
            _dataProcessingService = dataProcessingService;

            InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        private async void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(MainRTB.Text) || _currentFile != null)
            {
                if (MessageBox.Show("Save current file?", "Close File", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await SaveFile();
                }
            }
            MainRTB.Clear();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _openFileForm.UpdateData();
            _openFileForm.ShowDialog();
            if (_openFileForm.SelectedFile != null)
            {
                _currentFile = _openFileForm.SelectedFile;
                this.Text = _currentFile.Name;
                MainRTB.Text = _currentFile.TextData;
                _openFileForm.SelectedFile = null;
            }
        }

        private async void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _deleteFileFrom.UpdateData();
            _deleteFileFrom.ShowDialog();
            if (_deleteFileFrom.SelectedFile != null && MessageBox.Show("Delete this file?", "Remove File", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (!(await _dataProcessingService.RemoveFile(_deleteFileFrom.SelectedFile)))
                {
                    MessageBox.Show("File not removed");
                }
                else if(_deleteFileFrom.SelectedFile.Id == _currentFile.Id)
                {
                    this.Text = "Notepad";
                    _currentFile = null;
                    MainRTB.Clear();
                }

                _deleteFileFrom.SelectedFile = null;
                _openFileForm.SelectedFile = null;
            }
        }

        private async Task SaveFile()
        {
            if (_currentFile == null && !string.IsNullOrEmpty(MainRTB.Text))
            {
                _saveFileForm.ProcessTextData(MainRTB.Text);
                _saveFileForm.ShowDialog();
                if (_saveFileForm.IsFileSaved)
                {
                    MainRTB.Clear();
                }
            }
            else if (_currentFile != null)
            {
                _currentFile.TextData = MainRTB.Text;
                await _dataProcessingService.UpdateFile(_currentFile);
            }
            else
            {
                MessageBox.Show("File is empty!", "Error");
            }
        }

        private async void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await SaveFile();
        }

        #endregion Private Methods
    }
}