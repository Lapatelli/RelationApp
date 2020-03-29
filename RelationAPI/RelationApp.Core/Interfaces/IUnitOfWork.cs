using RelationApp.Core.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace RelationApp.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRelationCategoryRepository RelationCategoryRepository { get; set; }

        public IRelationRepository RelationRepository { get; set; }

        public IRelationAddressRepository RelationAddressRepository { get; set; }

        public ICountryRepository CountryRepository { get; set; }

        Task<int> CommitAsync();
    }
}
