using AutoMapper;
using FileServer.App.Interfaces;
using FileServer.App.Model;
using FileServer.Interfaces;
using FileServer.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileServer.Service
{
    public class FileFrontService : IFileFrontService
    {
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public FileFrontService(IFileService fileService,IMapper mapper)
        {
            _fileService = fileService;
            _mapper = mapper;
        }
        public async Task<FileViewModel> CreateFile(IFormFile file)
        {
            var nc = new FileModel()
            {
                Name = file.FileName,
                Size = file.Length,
                UploadDate = DateTime.Now,
                Type = Path.GetExtension(file.FileName)
            };

            using (var dataStream = new MemoryStream())
            {
                await file.CopyToAsync(dataStream);
                nc.FileData = dataStream.ToArray();
            }

            var entityDto = await _fileService.Create(nc);
            var mappedViewModel = _mapper.Map<FileViewModel>(entityDto);
            return mappedViewModel;
        }

        public async Task<IEnumerable<FileWrapperViewModel>> GetFiles()
        {
            var fileList = await _fileService.GetFileList();
            var items = new List<FileWrapperViewModel>();
            foreach (var item in fileList)
            {
                var file = new FileViewModel
                {
                    Name = item.Name,
                    Size = item.Size,
                    Type = item.Type,
                    UploadDate = item.UploadDate
                };

                var subList = items.Find(i => i.Type == file.Type);

                if (subList != null)
                {
                    subList.files.Add(file);
                }
                else
                {
                    items.Add(new FileWrapperViewModel() { Type = file.Type, files = new List<FileViewModel>() { file } });
                }
            }

            return items;
        }
    }
}
