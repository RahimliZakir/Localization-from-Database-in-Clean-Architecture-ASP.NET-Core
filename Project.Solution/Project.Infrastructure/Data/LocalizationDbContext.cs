using Microsoft.EntityFrameworkCore;
using Project.Domain.Common;
using Project.Domain.Entities;

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

            foreach (Type? entity in typeof(BaseEntity).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(BaseEntity))))
            {
                builder.Entity(entity).Property("CreatedDate").HasDefaultValueSql("GETDATE()");
            }
        }
    }
}
