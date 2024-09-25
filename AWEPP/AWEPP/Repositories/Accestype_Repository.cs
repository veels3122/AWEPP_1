namespace AWEPP.Repositories
{
    public class Accestype_Repository
    {
        Task<IEnumerable<Accestype_Repository>> GetAllAccestype_RepositoryAsync();
        Task<Accestype_Repository> GetAccestype_RepositoryByIdAsync(int Id);
        Task CreateAccestype_RepositoryAsync(Accestype_Repository accestype_repository);
        Task CreateAccestype_RepositoryAsync(Accestype_Repository accestype_repository);
        Task SoftDeleteAccestype_RepositoryAsync(int Id);
    }
}
