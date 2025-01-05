using Microsoft.EntityFrameworkCore;
using Project.Application.Common.Interfaces.Data;
using Project.Domain.Entities;
using Project.Infrastructure.Data.Configurations;
using System.Reflection;

namespace Project.Infrastructure.Data
{
    public class LocalizationDbContext(DbContextOptions options) : DbContext(options), ILocalizationDbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Translation> Translations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyGeneralConfigurations();

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
