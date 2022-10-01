

namespace Bases.Domain
{
    public class BaseEntity<IdType>
    {
        public IdType Id { get; set; }
        public bool Is_Deleted { get; set; } = false;
    }
}
