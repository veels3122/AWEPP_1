using AWEPP.Model;

namespace AWEPP.Services
{
    public interface ITypeProductsServices
    {
        Task<IEnumerable<TypeProducts>> GetAllTypeProductsAsync();
        Task<TypeProducts> GetTypeProductsByIdAsync(int Id);
        Task CreateTypeProductsAsync(TypeProducts TypeProducts);
        Task UpdateTypeProductsAsync(TypeProducts TypeProducts);
        Task SoftDeleteTypeProductsAsync(int Id);
    }
}
