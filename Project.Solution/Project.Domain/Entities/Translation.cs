using Project.Domain.Common;

namespace Project.Domain.Entities
{
    public class Translation : BaseEntity
    {
        public required string Name { get; set; }
        public required int LanguageId { get; set; }
        public required int ResourceId { get; set; }
        public virtual Language Language { get; set; } = null!;
        public virtual Resource Resource { get; set; } = null!;
    }
}
