﻿using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create()
        {
            return Ok("Creating a ticket.");
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok("Updating a ticket.");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting ticket: #{id}");
        }
    }
}
