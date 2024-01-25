using crudDapperMicroOrm.Models;
using crudDapperMicroOrm.Repositories.Interfaces;
using crudDapperMicroOrm.Services.Interfaces;

namespace crudDapperMicroOrm.Services.Implementations
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment)
        {
            return await _enrollmentRepository.AddAsync(enrollment);
        }

        public async Task<bool> DeleteEnrollmentAsync(int id)
        {
            return await _enrollmentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _enrollmentRepository.GetAllAsync();
        }

        public async Task<Enrollment> GetEnrollmentAsync(int id)
        {
            return await _enrollmentRepository.GetAsync(id);
        }

        public async Task<bool> UpdateEnrollmentAsync(Enrollment enrollment)
        {
            return await _enrollmentRepository.UpdateAsync(enrollment);
        }
    }
}
