using Project.Domain.Common;
using Project.Domain.Enums;

namespace Project.Domain.Entities
{
    public class Resource : BaseEntity
    {
        public required string Value { get; set; }
        public required ApplicationType ApplicationType { get; set; }
    }
}
