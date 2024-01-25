using crudDapperMicroOrm.Models;
using crudDapperMicroOrm.Repositories.Interfaces;

namespace crudDapperMicroOrm.Repositories.Implementations
{
    public class SchoolRepository : ISchoolRepository
    {
        public Task<School> AddAsync(School entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<School>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<School?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(School entity)
        {
            throw new NotImplementedException();
        }
    }
}
