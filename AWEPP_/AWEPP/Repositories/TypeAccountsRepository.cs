using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class TypeAccountsRepository : ITypeAccountsRepository
    {
        public Task CreateTypeAccountsAsync(TypeAccounts typeAccounts)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TypeAccounts>> GetAllTypeAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TypeAccounts> GetTypeAccountsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteTypeAccountsAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTypeAccountsAsync(TypeAccounts typeAccounts)
        {
            throw new NotImplementedException();
        }
    }
}





