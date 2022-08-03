using DataStore.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApiApp.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly BugsContext db;

        public ProjectsController(BugsContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Projects.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var projects = db.Projects.Find(id);


            if (projects == null)
            {
                return NotFound();
            }
            return Ok(projects);
        }


        [HttpGet]
        [Route("{projectId}/tickets")]
        public IActionResult GetProjectTickets(int projectId)
        {
            var tickets = db.Tickets.Where(project => project.ProjectId == projectId).ToList();
            if (tickets == null || tickets.Count <=0)
            {
                return NotFound();
            }
            return Ok(tickets);
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
