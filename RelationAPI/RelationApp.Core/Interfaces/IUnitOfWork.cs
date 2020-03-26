using RelationApp.Core.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace RelationApp.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoryRepository CategoryRepository { get; set; }

        public IRelationRepository RelationRepository { get; set; }

        public IRelationAddressRepository RelationAddressRepository { get; set; }

        Task<int> CommitAsync();
    }
}
