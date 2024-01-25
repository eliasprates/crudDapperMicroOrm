using crudDapperMicroOrm.Models;
using crudDapperMicroOrm.Repositories.Interfaces;

namespace crudDapperMicroOrm.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        public Task<Student> AddAsync(Student entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Student?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
