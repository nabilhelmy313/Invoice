using System.ComponentModel.DataAnnotations;
namespace Bases.Domain
{
    public class BaseEntity<IdType>
    {
        [Key]
        public IdType Id { get; set; }
        public bool Is_Deleted { get; set; } = false;
    }
}
