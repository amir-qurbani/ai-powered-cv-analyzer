using System.Threading.Tasks;
using CVAnalyzer.Application.Services;
using CVAnalyzer.Core.Entities;
using CVAnalyzer.Core.Interfaces;
using CVAnalyzer.Infrastructure.Repositories;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CVAnalyzer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CvController : ControllerBase
    {
        private readonly CvService _cvService;
        public CvController(CvService cvService)
        {
            _cvService = cvService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCvs()
        {
            var cvs = await _cvService.GetAllCvAsync();
            return Ok(cvs);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCvs(CV cv)
        {
            await _cvService.AddCvAsync(cv);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCvs(int id)
        {
            await _cvService.DeleteCvAsync(id);
            return Ok();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateCvs(CV cv)
        {
            await _cvService.UpdateCvAsync(cv);
            return Ok();

        }
        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadCv(IFormFile file)
        {
            var filePath = Path.Combine("Uploads", file.FileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            if (file == null || file.Length == 0)
            {
                return BadRequest("Please upload a PDF file.");
            }

            if (!file.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Only PDF files are allowed.");
            }

            await _cvService.UploadCvAsync(file.FileName);
            return Ok();
        }
    }
}
