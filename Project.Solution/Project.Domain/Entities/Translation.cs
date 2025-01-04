using Project.Domain.Common;

namespace Project.Domain.Entities
{
    public class Translation : BaseEntity
    {
        public required string Name { get; set; }
        public int LanguageId { get; set; }
        public int ResourceId { get; set; }
        public virtual Language? Language { get; set; }
        public virtual Resource? Resource { get; set; }
    }
}
