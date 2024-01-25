using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using crudDapperMicroOrm.Models;
using crudDapperMicroOrm.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using crudDapperMicroOrm.Services.Interfaces;

namespace crudDapperMicroOrm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        // GET: api/Enrollments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollments()
        {
            var enrollments = await _enrollmentService.GetAllEnrollmentsAsync();
            return Ok(enrollments);
        }

        // GET: api/Enrollments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enrollment>> GetEnrollment(int id)
        {
            var enrollment = await _enrollmentService.GetEnrollmentAsync(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return Ok(enrollment);
        }

        // POST: api/Enrollments
        [HttpPost]
        public async Task<ActionResult<Enrollment>> PostEnrollment(Enrollment enrollment)
        {
            var newEnrollment = await _enrollmentService.AddEnrollmentAsync(enrollment);
            return CreatedAtAction("GetEnrollment", new { id = newEnrollment.Id }, newEnrollment);
        }

        // PUT: api/Enrollments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrollment(int id, Enrollment enrollment)
        {
            if (id != enrollment.Id)
            {
                return BadRequest();
            }

            bool updateResult = await _enrollmentService.UpdateEnrollmentAsync(enrollment);

            if (!updateResult)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Enrollments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            bool deleteResult = await _enrollmentService.DeleteEnrollmentAsync(id);

            if (!deleteResult)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
