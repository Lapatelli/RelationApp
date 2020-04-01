using RelationApp.Core.Interfaces.Repositories;
using RelationApp.Core.Entities;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace RelationApp.Infrastructure.Repositories
{
    public class RelationAddressRepository : GenericRepository<RelationAddress>, IRelationAddressRepository
    {
        public RelationAddressRepository(RelationDBContext context) : base(context) { }

        public async Task<RelationAddress> GetAddressByRelationIdAsync(Guid Id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.RelationId == Id);
        }
    }
}
