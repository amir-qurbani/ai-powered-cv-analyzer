
using CVAnalyzer.Core.Entities;
using CVAnalyzer.Core.Interfaces;
using CVAnalyzer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CVAnalyzer.Infrastructure.Repositories
{
    public class CvRepository : ICvRepository
    {
        private readonly AppDbContext _context;

        public CvRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CV> GetCvByIdAsync(int id)
        {
            return await _context.Cvs.FindAsync(id);
        }

        public async Task<IEnumerable<CV>> GetAllCvsAsync()
        {
            return await _context.Cvs.ToListAsync();
        }

        public async Task AddCvAsync(CV cv)
        {
            await _context.Cvs.AddAsync(cv);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCvAsync(int id)
        {
            var cv = await _context.Cvs.FindAsync(id);
            if (cv != null)
            {
                _context.Cvs.Remove(cv);
                await _context.SaveChangesAsync();
            }
        }
    }
}