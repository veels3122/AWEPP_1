using AWEPP.Context;
using AWEPP.Modelo;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class SavingRepository : ISavingRepository
    {
        public Task CreateSavingAsync(Saving saving)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Saving>> GetAllSavingAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Saving> GetSavingByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteSavingAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSavingAsync(Saving saving)
        {
            throw new NotImplementedException();
        }
    }
}
    
