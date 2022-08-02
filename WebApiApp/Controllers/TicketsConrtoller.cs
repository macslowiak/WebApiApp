using Microsoft.AspNetCore.Mvc;
using WebApiApp.Filters;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Reading all the tickets.");
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Reading ticket: #{id}");
        }

        [HttpPost]
        public IActionResult CreateV1([FromBody] Ticket ticket)
        {
            return Ok(ticket);
        }

        [HttpPost]
        [Route("/api/v2/tickets")]
        [Ticket_EnsureEnteredDate]
        public IActionResult CreateV2([FromBody] Ticket ticket)
        {
            return Ok(ticket);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Ticket ticket)
        {
            return Ok(ticket);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting ticket: #{id}");
        }
    }
}
