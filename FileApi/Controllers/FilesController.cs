using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly string path;
        public FilesController(string path)
        {
            this.path = path;
        }
        // GET: api/<FilesController>
        [HttpGet]
        [Produces("text/csv")]
        public FileContentResult Get()
        {
            return File(System.IO.File.ReadAllBytes(path), "application/octet-stream", "StudentTemplate.csv");
        }
        /*
        [HttpPost] 
        public async Task<IActionResult> UploadFile(IFormFile file) 
        { 
            if (file == null || file.Length == 0) 
            { 
                return Ok("File not selected"); 
            } 
            var path = Path.Combine(Directory.GetCurrentDirectory(), file.FileName); 
            using (var stream = new FileStream(path, FileMode.Create)) 
            {
                await file.CopyToAsync(stream); 
            } 
            return Ok("success"); 
        }*/
    }
}
