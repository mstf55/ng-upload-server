using FileServer.App.Interfaces;
using FileServer.App.Mapper;
using FileServer.App.Model;
using FileServer.Core.Entities;
using FileServer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.App.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<FileModel> Create(FileModel fileModel)
        {
            await ValidateProductIfExist(fileModel);

            var mappedEntity = ObjectMapper.Mapper.Map<UploadedFile>(fileModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _fileRepository.AddAsync(mappedEntity);

            var newMappedEntity = ObjectMapper.Mapper.Map<FileModel>(newEntity);
            return newMappedEntity;
        }

        public async Task<IEnumerable<FileModel>> GetFileList()
        {
            var fileList = await _fileRepository.GetAllAsync();
            var mappedList = ObjectMapper.Mapper.Map<IEnumerable<FileModel>>(fileList);
            return mappedList;
        }

        private async Task ValidateProductIfExist(FileModel fileModel)
        {
            var existingEntity = await _fileRepository.GetFileByNameAsync(fileModel.Name);
            if (existingEntity.Count > 0)
                throw new ApplicationException($"{fileModel.Name} - this file exists");
        }
    }
}
