using System.Threading.Tasks;
using DapperCore.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DapperConnectionClosedError.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRespository courseRespository;

        public CoursesController(ICourseRespository courseRespository)
        {
            this.courseRespository = courseRespository;
        }

        [HttpGet()]
        [AllowAnonymous]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await courseRespository.All();

            return Ok(courses);
        }
    }
}