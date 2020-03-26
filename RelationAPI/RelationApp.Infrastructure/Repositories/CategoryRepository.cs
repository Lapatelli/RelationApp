using RelationApp.Core.Entities;
using RelationApp.Core.Interfaces.Repositories;


namespace RelationApp.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(RelationDBContext context) : base(context)
        {

        }
    }
}
