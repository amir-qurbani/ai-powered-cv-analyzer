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
            // 1. Kontrollera att en fil har skickats
            if (file == null || file.Length == 0)
            {
                return BadRequest("Please upload a file.");
            }

            // 2. Kontrollera filändelsen
            if (!file.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Only PDF files are allowed.");
            }

            // 3. Skapa sökvägen till filen
            var filePath = Path.Combine("Uploads", Path.GetFileName(file.FileName));

            // 4. Spara filen på datorn
            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            // 5. Spara filnamnet via Service
            await _cvService.UploadCvAsync(file.FileName);

            // 6. Skicka svar till användaren
            return Ok();
        }
    }
}
