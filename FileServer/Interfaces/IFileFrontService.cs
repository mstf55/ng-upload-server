using FileServer.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileServer.Interfaces
{
    public interface IFileFrontService
    {
        Task<IEnumerable<FileWrapperViewModel>> GetFiles();
        Task<FileViewModel> CreateFile(IFormFile productViewModel);
    }
}
