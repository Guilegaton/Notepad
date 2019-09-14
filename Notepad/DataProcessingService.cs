using Notepad.DAL.Interfaces;
using Notepad.Helpers;
using Notepad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notepad
{
    public class DataProcessingService : IDisposable
    {
        #region Private Fields

        private readonly IFileRepository _repository;
        private bool _isDisposed = false;

        #endregion Private Fields

        #region Public Constructors

        public DataProcessingService(IFileRepository repository)
        {
            _repository = repository;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<bool> RemoveFile(FileViewModel file)
        {
            var result = false;
            if (await _repository.IsEntityExists(file.Id))
            {
                await _repository.DeleteByIdAsync(file.Id);
                result = true;
            }

            return result;
        }

        public async Task<bool> SaveFile(FileViewModel sFile)
        {
            var result = false;
            if (!(await _repository.IsFileExists(sFile.Name)))
            {
                var file = new File()
                {
                    Name = sFile.Name,
                    Data = sFile.TextData.ToByteArray(sFile.Name, 9)
                };
                await _repository.CreateAsync(file);
                result = true;
            }

            return result;
        }

        public async Task<bool> UpdateFile(FileViewModel fileModel)
        {
            var result = false;
            var file = await _repository.GetByIdAsync(fileModel.Id);
            if (file != null)
            {
                file.Data = fileModel.TextData.ToByteArray(fileModel.Name, 9);
                await _repository.UpdateAsync(file);
                result = true;
            }

            return result;
        }

        public Dictionary<long, string> GetListOfFileNames()
        {
            return _repository.GetAll().ToDictionary(file => file.Id, file => file.Name);
        }

        public async Task<FileViewModel> LoadFile(long id)
        {
            var result = default(FileViewModel);
            if(await _repository.IsEntityExists(id))
            {
                File file = await _repository.GetByIdAsync(id);
                result = new FileViewModel
                {
                    Id = file.Id,
                    Name = file.Name,
                    TextData = file.Data.ToStringText()
                };
            }

            return result;
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                _repository.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        #endregion Public Methods
    }
}