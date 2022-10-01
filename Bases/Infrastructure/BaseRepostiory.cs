using Bases.Application;
using Bases.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Bases.Infrastructure
{
    public class BaseRepostiory<Entity, IdType, TDbContext> : IBaseRepository<Entity, IdType>
                                                                where Entity : BaseEntity<IdType>
                                                                where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        private static bool _hasIsDeleted = typeof(Entity).GetType() is BaseCommonEntity<IdType>;
        private readonly Expression<Func<Entity, bool>> ignoreDeleted =
            z => _hasIsDeleted ? z.Is_Deleted == false : true;

        public BaseRepostiory(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Entity entity)
        {
            _dbContext.Add(entity);
        }

        public void CreateRange(IEnumerable<Entity> entities)
        {
            _dbContext.Set<Entity>().AddRange(entities);
        }

        public Entity FindByID(IdType Id)
        {
            var entity = _dbContext.Set<Entity>().Where(ignoreDeleted).FirstOrDefault(z => z.Id.Equals(Id));
            return entity!;
        }

        public IQueryable<Entity> GetAllQueryable(Expression<Func<Entity, bool>> predicate = null)
        {
            IQueryable<Entity> entities;
            if (predicate is not null)
                entities = _dbContext.Set<Entity>().Where(ignoreDeleted).Where(predicate).AsQueryable();
            else
                entities = _dbContext.Set<Entity>().Where(ignoreDeleted).AsQueryable();
            return entities;
        }

        public void HardDelete(params IdType[] idList)
        {
            List<Entity> entities = new();
            foreach (var id in idList)
                entities.Add(FindByID(id));
            _dbContext.Set<Entity>().RemoveRange(entities);

        }

        public void SoftDelete(params IdType[] idList)
        {
            _dbContext.Set<Entity>().Where(z => idList.Contains(z.Id)).ForEachAsync(delegate (Entity item)
            {
                item.Is_Deleted = true;
            });
        }
    }
}
