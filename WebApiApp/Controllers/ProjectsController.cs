using Microsoft.AspNetCore.Mvc;
using WebApiApp.Models;

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

        /// <summary>
        /// api/projects/{pid}/tickets/{tid}
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("{projectId}/tickets")]
        //public IActionResult GetProjectTicket(int projectId, [FromQuery] int ticketId)
        //{
        //    if (ticketId == 0)
        //    {
        //        return Ok($"Reading all the tickets belong to project #{projectId}");
        //    }
        //    return Ok($"Reading project: #{projectId} and ticket #{ticketId}");
        //}


        [HttpGet]
        [Route("{projectid}/tickets")]
        public IActionResult GetProjectTicket([FromQuery] Ticket ticket)
        {
            if (ticket == null)
            {
                return BadRequest("Parameters are not provided properly!");
            }
            if (ticket.TicketId == 0)
            {
                return Ok($"Reading all the tickets belong to project #{ticket.ProjectId}");
            }
            return Ok($"Reading project: #{ticket.ProjectId} and ticket #{ticket.TicketId}" +
                $" ,title: {ticket.Title}, decription: {ticket.Description}");
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
