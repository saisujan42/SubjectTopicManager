using Microsoft.EntityFrameworkCore;
using SubjectTopicsApp.Models;

namespace SubjectTopicsApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<SubTopic> SubTopics { get; set; }
    }
}
