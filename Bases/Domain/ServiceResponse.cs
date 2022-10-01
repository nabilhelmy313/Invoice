
namespace Bases.Domain
{
    public class ServiceResponse<Entity>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Entity Data { get; set; }
    }
}
