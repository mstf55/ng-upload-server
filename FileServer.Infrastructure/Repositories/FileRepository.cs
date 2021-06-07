using FileServer.Core.Entities;
using FileServer.Core.Repositories;
using FileServer.Infrastructure.Data;
using FileServer.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastructure.Repositories
{
    public class FileRepository: Repository<UploadedFile>, IFileRepository
    {
        public FileRepository(FileDbContext dbContext):base(dbContext)
        {

        }

        public async Task<IList<UploadedFile>> GetFileByNameAsync(string fileName)
        {
            return await _dbContext.Files
              .Where(f => f.Name == fileName)
              .ToListAsync();
        }
    }
}
