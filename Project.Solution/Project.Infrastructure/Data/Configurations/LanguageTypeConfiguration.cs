using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Configurations
{
    public class LanguageTypeConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.Property(b => b.Name)
                   .HasMaxLength(30);
            builder.Property(b => b.Abbr)
                   .HasMaxLength(3);
            builder.Property(b => b.Culture)
                   .HasMaxLength(10);
        }
    }
}
