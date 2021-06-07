using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileServer.ViewModels
{
    public class FileWrapperViewModel
    {
        public string Type { get; set; }
        public List<FileViewModel> files { get; set;}
    }
}
