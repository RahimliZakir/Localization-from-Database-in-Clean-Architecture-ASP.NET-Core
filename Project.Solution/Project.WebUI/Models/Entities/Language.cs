namespace Project.WebUI.Models.Entities
{
    public class Language : BaseEntity
    {
        public required string Name { get; set; }
        public required string CultureInfo { get; set; }
    }
}
