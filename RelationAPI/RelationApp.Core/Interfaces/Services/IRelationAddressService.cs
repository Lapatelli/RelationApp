
namespace RelationApp.Core.Interfaces.Services
{
    public interface IRelationAddressService
    {
        string TransormPostalCode(string postalCode, string postalCodeFormat);
    }
}
