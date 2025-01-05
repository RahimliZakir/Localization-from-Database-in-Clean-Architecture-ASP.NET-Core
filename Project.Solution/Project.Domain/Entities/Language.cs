using Project.Domain.Common;

namespace Project.Domain.Entities
{
    public class Language : BaseEntity
    {
        public required string Name { get; set; }
        public required string Abbr { get; set; }
        public required string Culture { get; set; }
    }
}
