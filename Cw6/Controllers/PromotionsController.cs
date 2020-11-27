using Cw6.DTOs.Requests;
using Cw6.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw6.Controllers
{
    [ApiController]
    [Route("api/enrollments/promotions")]
    public class PromotionsController : ControllerBase
    {
        private readonly IDbStudentService _dbService;

        public PromotionsController(IDbStudentService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost]
        public IActionResult PromoteStudents(PromoteStudentsRequest promoteStudentsRequest)
        {
            var newEnrollment = _dbService.PromoteStudents(promoteStudentsRequest);
            if (newEnrollment != null) return Created("/api/students", newEnrollment);
            return BadRequest($"Nie ma wpisu w bazie danych o kierunku '{promoteStudentsRequest.Studies}' " +
                              $"i semestrze {promoteStudentsRequest.Semester}");
        }
    }
}