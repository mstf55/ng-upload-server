using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileServer.ViewModels
{
    public class FileViewModel
    {
        public long Size { get; set; }
        public string Name { get; set; }
        public DateTime UploadDate { get; set; }
        public string Type { get; set; }

    }
}
