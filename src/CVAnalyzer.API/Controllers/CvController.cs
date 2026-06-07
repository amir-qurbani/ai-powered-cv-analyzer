using System.Threading.Tasks;
using CVAnalyzer.Application.Services;
using CVAnalyzer.Core.Entities;
using CVAnalyzer.Core.Interfaces;
using CVAnalyzer.Infrastructure.Repositories;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

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
    }
}