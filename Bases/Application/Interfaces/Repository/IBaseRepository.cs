using System.Linq.Expressions;
namespace Bases.Application
{
    public interface IBaseRepository<Entity,IdType>
    {
        /// <summary>
        /// Get Methods
        /// </summary>
        IQueryable<Entity> GetAllQueryable(Expression<Func<Entity, bool>> predicate = null);
        Entity FindByID(IdType Id);
       
        /// <summary>
        /// Post,Put and delete methods
        /// </summary>
        /// <param name="entity"></param>
        void Create(Entity entity);
        void CreateRange(IEnumerable<Entity> entities);
        void SoftDelete(params IdType[] idList);
        void HardDelete(params IdType[] idList);
    }
}
