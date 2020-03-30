using RelationApp.Core.Entities;
using RelationApp.Core.Interfaces.Repositories;


namespace RelationApp.Infrastructure.Repositories
{
    public class RelationCategoryRepository : GenericRepository<RelationCategory>, IRelationCategoryRepository
    {
        public RelationCategoryRepository(RelationDBContext context) : base(context) { }
    }
}
