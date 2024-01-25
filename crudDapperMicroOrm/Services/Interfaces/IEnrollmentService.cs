using crudDapperMicroOrm.Models;

namespace crudDapperMicroOrm.Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment);
        Task<bool> DeleteEnrollmentAsync(int id);
        Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync();
        Task<Enrollment> GetEnrollmentAsync(int id);
        Task<bool> UpdateEnrollmentAsync(Enrollment enrollment);
    }
}
