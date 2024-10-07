using AWEPP.Model;

namespace AWEPP.Repositories
{
    public interface TypeIdentysRepository

    {
        Task<IEnumerable<Identys>> GetAllIdentysAsync();
        Task<Identys> GetIdentysByIdAsync(int Id);
        Task CreateIdentysAsync(Identys identys);
        Task UpdateIdentysAsync(Identys identys);
        Task SoftDeleteIdentysAsync(int Id);
    }

}
