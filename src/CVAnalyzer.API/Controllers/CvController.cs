using System.Threading.Tasks;
using CVAnalyzer.Core.Interfaces;
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
    }
}