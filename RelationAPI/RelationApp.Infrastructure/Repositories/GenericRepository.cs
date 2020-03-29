using Microsoft.EntityFrameworkCore;
using RelationApp.Core.Interfaces.Repositories;
using System.Collections.Generic;
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

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);

            return entity;
        }

        public void Delete(TEntity entity)
        {
            Сontext.Entry(entity).State = EntityState.Deleted;
        }

        public void Update(TEntity entity)
        {
            Сontext.Entry(entity).State = EntityState.Modified;
        }
    }
}
