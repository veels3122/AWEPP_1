using AWEPP.Model;
using AWEPP.Modelo;

namespace AWEPP.Repositories
{
    public interface ITypeProductsRepository
    {
        Task<IEnumerable<TypeProducts>> GetAllTypeProductsAsync();
        Task<TypeProducts> GetTypeProductsByIdAsync(int Id);
        Task CreateTypeProductsAsync(TypeProducts TypeProducts);
        Task UpdateTypeProductsAsync(TypeProducts TypeProducts);
        Task SoftDeleteTypeProductsAsync(int Id);
    }
}
