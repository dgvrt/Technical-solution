using Microsoft.EntityFrameworkCore;

namespace Technical_solution.Models
{
    public class SentencesContext : DbContext
    {
        public DbSet<Sentenсes> sentenсes { get; set; }

        public SentencesContext(DbContextOptions<SentencesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
