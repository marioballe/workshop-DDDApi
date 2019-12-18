using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsBC.Api.RequestObjects;
using ProjectsBC.Domain.Entities;
using ProjectsBC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectsBC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectDbContext _db;
        public ProjectsController(ProjectDbContext db) {
            _db = db;
        }

        [HttpPost]
        [Route ("{projectId}/sprints")]
        public IActionResult AddSprintToPorject(int projectId, SprintDto sprint)
        {
            var sprintToAdd = new Sprint()
            {
                DateRange = new DateRange(sprint.Start.AddDays(sprint.Days))
            };

            var pr = _db.Projects.Include(p => p.Sprints)
                .FirstOrDefault(p => p.Id == projectId);

            if (pr == null)
            {
                return NotFound();
            }

            pr.AddSprint(sprintToAdd);

            _db.SaveChanges();

            return Ok();
        }
    }
}
