using CVAnalyzer.Core.Entities;
using CVAnalyzer.Core.Interfaces;

namespace CVAnalyzer.Application.Services
{
    public class CvService
    {
        private readonly ICvRepository _cvRepository;
        public CvService (ICvRepository cvRepository)
        {
            _cvRepository = cvRepository;
        }
        public async Task<IEnumerable<CV>> GetAllCvAsync()
        {
            return await _cvRepository.GetAllCvsAsync();
        }
        public async Task AddCvAsync(CV cv)
        {
            await _cvRepository.AddCvAsync(cv);
        }
        public async Task DeleteCvAsync(int id)
        {
            await _cvRepository.DeleteCvAsync(id);
        }
        public async Task UpdateCvAsync(CV cv)
        {
            await _cvRepository.UpdateCvAsync(cv);
        }
    }
}