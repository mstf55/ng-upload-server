using FileServer.Core.Entities;
using FileServer.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Core.Repositories
{
    public interface IFileRepository : IRepository<UploadedFile>
    {
        Task<IList<UploadedFile>> GetFileByNameAsync(string fileName);
    }
}
