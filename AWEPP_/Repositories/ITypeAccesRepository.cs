using AWEPP.Model;

namespace AWEPP.Repositories
{
    public interface ITypeAccesRepository

    {
        Task<IEnumerable<Acces>> GetAllAccesAsync();
        Task<Acces> GetAccesByIdAsync(int Id);
        Task CreateAccesAsync(Acces acces);
        Task UpdateAccesAsync(Acces acces);
        Task SoftDeleteAccessAsync(int Id);
    }

}
