using RelationApp.Core.Entities;
using System;
using System.Threading.Tasks;

namespace RelationApp.Core.Interfaces.Repositories
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task<Country> GetPostalCodeByCountryName(string CountryName);
    }
}
