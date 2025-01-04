using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
    }
}
