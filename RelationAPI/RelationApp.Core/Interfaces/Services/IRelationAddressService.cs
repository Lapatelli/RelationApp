using RelationApp.Core.Entities;
using System.Threading.Tasks;

namespace RelationApp.Core.Interfaces.Services
{
    public interface IRelationAddressService
    {
        string TransormPostalCode(string postalCode, string postalCodeFormat);
    }
}
