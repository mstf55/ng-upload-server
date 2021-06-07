using FileServer.App.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileServer.App.Model
{
    public class FileModel : FileBaseModel
    {
        public byte[] FileData { get; set; }
    }
}
