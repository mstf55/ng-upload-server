using System;
using System.Collections.Generic;
using System.Text;

namespace FileServer.Core.Entities
{
    public class UploadedFile:Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
        public DateTime UploadDate { get; set; }
        public byte[] FileData { get; set; }
    }
}
