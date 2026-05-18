using CVAnalyzer.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVAnalyzer.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CV> Cvs { get; set; }
    }
}