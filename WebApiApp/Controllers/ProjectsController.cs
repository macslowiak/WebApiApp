﻿using Core.Models;
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
            if (tickets == null || tickets.Count <= 0)
            {
                return NotFound();
            }
            return Ok(tickets);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = project.ProjectId },
                project
                );
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Project project)
        {
            if (id != project.ProjectId) return BadRequest();

            db.Entry(project).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch
            {
                if (db.Projects.Find(id) == null)
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }
            db.Projects.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }
    }
}
