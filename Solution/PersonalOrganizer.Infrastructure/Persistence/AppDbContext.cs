using Microsoft.EntityFrameworkCore;
using PersonalOrganizer.Domain.Entities;

namespace PersonalOrganizer.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
