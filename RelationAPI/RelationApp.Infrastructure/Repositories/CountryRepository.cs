using Microsoft.EntityFrameworkCore;
using RelationApp.Core.Entities;
using RelationApp.Core.Interfaces.Repositories;
using System.Threading.Tasks;

namespace RelationApp.Infrastructure.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(RelationDBContext context) : base(context) { }

        public async Task<Country> GetPostalCodeByCountryName(string countryName)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Name == countryName);
        }
    }
}
