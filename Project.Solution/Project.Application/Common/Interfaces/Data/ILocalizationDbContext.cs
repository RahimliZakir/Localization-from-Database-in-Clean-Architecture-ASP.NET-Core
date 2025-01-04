using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;

namespace Project.Application.Common.Interfaces.Data
{
    public interface ILocalizationDbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Translation> Translations { get; set; }
    }
}
