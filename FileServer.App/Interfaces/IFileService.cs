using FileServer.App.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.App.Interfaces
{
    public interface IFileService
    {
        Task<IEnumerable<FileModel>> GetFileList();
        Task<FileModel> Create(FileModel productModel);

    }
}
