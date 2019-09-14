using Notepad.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Notepad.Forms
{
    public partial class FileSelectForm : Form
    {
        #region Protected Internal Fields

        protected internal FileViewModel SelectedFile;

        #endregion Protected Internal Fields

        #region Private Fields

        private readonly DataProcessingService _processingService;

        #endregion Private Fields

        #region Public Constructors

        public FileSelectForm(DataProcessingService processingService)
        {
            _processingService = processingService;

            InitializeComponent();
            FillData();
        }

        #endregion Public Constructors

        #region Public Methods

        public void UpdateData()
        {
            FillData();
        }

        #endregion Public Methods

        #region Private Methods

        private async void FilesLSB_DoubleClick(object sender, EventArgs e)
        {
            var chosenElement = (KeyValuePair<long, string>?)FilesLSB.SelectedItem;
            if (chosenElement != null)
            {
                SelectedFile = await _processingService.LoadFile(chosenElement.Value.Key);
                this.Close();
            }
        }

        private void FillData()
        {
            FilesLSB.DataSource = new string[0];
            Dictionary<long, string> files = _processingService.GetListOfFileNames();
            if (files.Count > 0)
            {
                FilesLSB.DataSource = new BindingSource(files, null);
                FilesLSB.DisplayMember = "Value";
                FilesLSB.ValueMember = "Key";
            }
        }

        #endregion Private Methods
    }
}