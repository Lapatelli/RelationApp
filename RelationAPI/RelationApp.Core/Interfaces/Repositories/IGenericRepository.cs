using System.Collections.Generic;
using System.Threading.Tasks;

namespace RelationApp.Core.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        IEnumerable<TEntity> Sorting(IEnumerable<TEntity> entities, string sortedProp, bool ascending);
    }
}
