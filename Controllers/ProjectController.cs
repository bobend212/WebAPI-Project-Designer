using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsDbAPI.Models;

namespace ProjectsDbAPI.Controllers
{
    [ApiController]
    [Route("api/project")]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectContext _context;
        private readonly IMapper _mapper;

        public ProjectController(ProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ProjectDetialsDto>> Get()
        {
            var projects = _context.Projects
                .Include(x => x.Department)
                .ToList();

            if (!projects.Any())
                return Content("Brak projektow w bazie!");

            var projectsDto = _mapper.Map<List<ProjectDetialsDto>>(projects);

            return Ok(projectsDto);
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectDetialsDto> GetProject(int id)
        {
            var project = _context.Projects
                .Include(x => x.Department)
                .FirstOrDefault(x => x.Id == id);

            if (project == null)
                return Content("Brak projektu o podanym ID w bazie!");

            var projectDto = _mapper.Map<ProjectDetialsDto>(project);

            return Ok(projectDto);
        }

        [HttpPost]
        public ActionResult Post([FromBody]ProjectDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var project = _mapper.Map<Project>(model);
            _context.Projects.Add(project);
            _context.SaveChanges();

            return Ok(project);
        }

        [HttpPut("{projName}")]
        public ActionResult Put(string projName, [FromBody]ProjectDto model)
        {
            var project = _context.Projects
                .FirstOrDefault(x => x.ProjName == projName);

            if (project == null)
                return Content("Brak projektu o podanej NAZWIE w bazie!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            project.ProjNumber = model.ProjNumber;
            project.ProjName = model.ProjName;
            project.DateStarted = model.DateStarted;
            project.DateFinished = model.DateFinished;
            project.IsFinished = model.IsFinished;
            project.Description = model.Description;

            _context.SaveChanges();
            return Ok(project);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var project = _context.Projects
                .FirstOrDefault(x => x.Id == id);

            if (project == null)
                return Content("Brak projektu o podanym ID w bazie!");

            _context.Projects.Remove(project);
            _context.SaveChanges();

            return Content("Pomyslnie usunieto rekord z bazy!");
        }
    }
}