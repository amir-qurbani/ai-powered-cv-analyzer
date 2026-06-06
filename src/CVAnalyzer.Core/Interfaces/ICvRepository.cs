using CVAnalyzer.Core.Entities;

namespace CVAnalyzer.Core.Interfaces
{
    public interface ICvRepository
    {
        Task<CV?> GetCvByIdAsync(int id);
        Task<IEnumerable<CV>> GetAllCvsAsync();
        Task AddCvAsync(CV cv);
        Task DeleteCvAsync(int id);
        Task UpdateCvAsync(CV cv);
    }
}