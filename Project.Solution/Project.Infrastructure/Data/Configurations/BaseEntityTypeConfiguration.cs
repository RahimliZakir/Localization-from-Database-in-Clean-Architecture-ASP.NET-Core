using Microsoft.EntityFrameworkCore;
using Project.Domain.Common;

namespace Project.Infrastructure.Data.Configurations
{
    public static class BaseEntityTypeConfiguration
    {
        public static void ApplyGeneralConfigurations(this ModelBuilder builder)
        {
            foreach (Type? entity in typeof(BaseEntity).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(BaseEntity))))
            {
                builder.Entity(entity).Property("CreatedDate").HasDefaultValueSql("GETDATE()");
            }
        }
    }
}
