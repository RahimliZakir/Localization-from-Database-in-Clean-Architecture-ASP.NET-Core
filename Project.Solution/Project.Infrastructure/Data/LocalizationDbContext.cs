using Microsoft.EntityFrameworkCore;
using Project.Domain.Common;
using Project.Domain.Entities;
using Project.Infrastructure.Data.Configurations;

namespace Project.Infrastructure.Data
{
    public class LocalizationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Translation> Translations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyGeneralConfigurations();
        }
    }
}
