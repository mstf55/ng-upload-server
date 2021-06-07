using System;
using System.Collections.Generic;
using System.Text;

namespace FileServer.App.Model.Base
{
    public abstract class FileBaseModel : BaseModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
