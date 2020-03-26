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

        public UnitOfWork(ICategoryRepository categoryRepository, IRelationRepository relationRepository, 
            IRelationAddressRepository relationAddressRepository, RelationDBContext context)
        {
            CategoryRepository = categoryRepository;
            RelationRepository = relationRepository;
            RelationAddressRepository = relationAddressRepository;
            _context = context;
        }

        public IRelationRepository RelationRepository { get; set; }
        public IRelationAddressRepository RelationAddressRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }

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
