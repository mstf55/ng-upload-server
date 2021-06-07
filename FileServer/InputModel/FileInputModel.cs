using FileServer.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileServer.InputModel
{
    public class FileInputModel
    {
        [Required(ErrorMessage = "Select a file.")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".jpg", ".png",".pdf"})]
        public IFormFile File { get; set; }
    }
}
