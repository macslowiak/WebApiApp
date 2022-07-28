using Microsoft.AspNetCore.Mvc;

namespace WebApiApp.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Reading all the projects.");
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Reading project: #{id}");
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok("Creating a project.");
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok("Updating a project.");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting project: #{id}");
        }
    }
}
