using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using BitcoGG_API.Services;
using BitcoGG_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitcoGG_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload/{id}")]
        public async Task <IActionResult> Upload([FromForm(Name = "file")] IFormFile file, int id)  
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    try
                    {
                        _fileService.Upload(id, memoryStream.ToArray());
                    }
                    catch (Exception e)
                    {
                        return BadRequest(new {message = e.Message});
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                    return BadRequest();
                }
            }

            return Ok();
        }
    }
}
