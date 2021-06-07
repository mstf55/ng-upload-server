using FileServer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileServer.Infrastructure.Data
{
    public class FileDbContext : DbContext
    {
        public FileDbContext(DbContextOptions<FileDbContext> options)
           : base(options)
        {
        }
        public DbSet<UploadedFile> Files { get; set; }
    }
}
