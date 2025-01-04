using Project.WebUI.Enums;

namespace Project.WebUI.Models.Entities
{
    public class Resource : BaseEntity
    {
        public required string Name { get; set; }
        public required ApplicationType ApplicationType { get; set; }
    }
}
