using RelationApp.Core.Interfaces;
using RelationApp.Core.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace RelationApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RelationDBContext _context;
        private bool disposed;

        public UnitOfWork(IRelationCategoryRepository relationCategoryRepository, IRelationRepository relationRepository,
            IRelationAddressRepository relationAddressRepository, RelationDBContext context, ICountryRepository countryRepository)
        {
            RelationCategoryRepository = relationCategoryRepository;
            RelationRepository = relationRepository;
            RelationAddressRepository = relationAddressRepository;
            CountryRepository = countryRepository;
            _context = context;
        }

        public IRelationRepository RelationRepository { get; set; }
        public IRelationAddressRepository RelationAddressRepository { get; set; }
        public IRelationCategoryRepository RelationCategoryRepository { get; set; }
        public ICountryRepository CountryRepository { get; set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _context.Dispose();
            }
            disposed = true;
        }
    }
}
