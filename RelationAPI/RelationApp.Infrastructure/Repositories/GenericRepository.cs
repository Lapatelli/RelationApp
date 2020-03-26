using Microsoft.EntityFrameworkCore;
using RelationApp.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationApp.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly RelationDBContext Сontext;
        protected readonly DbSet<TEntity> DbSet;

        public GenericRepository(RelationDBContext context)
        {
            Сontext = context;
            DbSet = Сontext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await DbSet.ToListAsync();

            return entities;
        }

        public void Add(TEntity entity)
        {
            //DbSet.AddAsync(entity);
            Сontext.Entry(entity).State = EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            //DbSet.Remove(entity);
            Сontext.Entry(entity).State = EntityState.Deleted;
        }

        public void Update(TEntity entity)
        {
            Сontext.Entry(entity).State = EntityState.Modified;
        }

        public virtual IEnumerable<TEntity> Sorting(IEnumerable<TEntity> entities, string sortedProp, bool ascending)
        {
            var propertyInfo = typeof(TEntity).GetProperty(sortedProp);

            var result = ascending ? entities.OrderBy(sort => propertyInfo.GetValue(sort)).ToList() :
                                     entities.OrderByDescending(sort => propertyInfo.GetValue(sort)).ToList();

            return result;
        }
    }
}
