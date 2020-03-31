using RelationApp.Core.Entities;
using System;
using System.Threading.Tasks;

namespace RelationApp.Core.Interfaces.Repositories
{
    public interface IRelationAddressRepository : IGenericRepository<RelationAddress>
    {
        Task<RelationAddress> GetAddressByRelationIdAsync(Guid Id);
    }
}
