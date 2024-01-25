using crudDapperMicroOrm.Models;
using crudDapperMicroOrm.Repositories.Interfaces;

namespace crudDapperMicroOrm.Repositories.Implementations
{
    public class TeacherRepository : ITeacherRepository
    {
        public Task<Teacher> AddAsync(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Teacher>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Teacher?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Teacher entity)
        {
            throw new NotImplementedException();
        }
    }
}
