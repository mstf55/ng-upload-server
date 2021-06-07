using FileServer.InputModel;
using FileServer.Interfaces;
using FileServer.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FileServer.Controllers
{
    [Route("api")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileFrontService _fileFronService;


        public FileController(IFileFrontService fileFrontService)
        {
            _fileFronService = fileFrontService;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("files")]
        public async Task<IActionResult> Upload([FromForm]FileInputModel inputModel)
        {
            var addedFile = await _fileFronService.CreateFile(inputModel.File);
            return Ok(addedFile);
        }
  
        [HttpGet, DisableRequestSizeLimit]
        [Route("files")]
        public async Task<IActionResult> GetFiles()
        {
            var allFilesSegmented = await _fileFronService.GetFiles();
            return Ok(allFilesSegmented);
        }
    }
}
