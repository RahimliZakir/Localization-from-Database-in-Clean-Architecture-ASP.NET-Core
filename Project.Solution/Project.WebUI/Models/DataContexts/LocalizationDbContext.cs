using Microsoft.EntityFrameworkCore;
using Project.WebUI.Models.Entities;
using System.Reflection;

namespace Project.WebUI.Models.DataContexts
{
    public class LocalizationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Translation> Translations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (Type? entity in Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(BaseEntity))))
            {
                builder.Entity(entity).Property("CreatedDate").HasDefaultValueSql("GETDATE()");
            }
        }
    }
}
