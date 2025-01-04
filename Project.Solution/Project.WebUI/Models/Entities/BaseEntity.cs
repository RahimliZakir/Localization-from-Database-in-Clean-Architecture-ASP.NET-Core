using System.ComponentModel.DataAnnotations.Schema;

namespace Project.WebUI.Models.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
    }
}
