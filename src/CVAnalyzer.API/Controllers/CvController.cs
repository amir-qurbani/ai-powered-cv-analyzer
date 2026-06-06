using System.Threading.Tasks;
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
        private readonly ICvRepository _cvRepository;
        public CvController(ICvRepository cvRepository)
        {
            _cvRepository = cvRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCvs()
        {
            var cvs = await _cvRepository.GetAllCvsAsync();
            return Ok(cvs);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCvs(CV cv)
        {
            await _cvRepository.AddCvAsync(cv);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCvs(int id)
        {
            await _cvRepository.DeleteCvAsync(id);
            return Ok();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateCvs(CV cv)
        {
            await _cvRepository.UpdateCvAsync(cv);
            return Ok();

        }
    }
}