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
    [Route("api/project/{projectId}/designers")]
    public class DesignerController : ControllerBase
    {
        private readonly ProjectContext _context;
        private readonly IMapper _mapper;

        public DesignerController(ProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get(int projectId)
        {
            var project = _context.Projects
                .Include(x => x.Designers)
                .FirstOrDefault(x => x.Id == projectId);

            if (project == null)
                return Content("Brak projektu o podanym ID w bazie!");

            var designers = _mapper.Map<List<DesignerDto>>(project.Designers);
            return Ok(designers);
        }

        [HttpPost]
        public ActionResult Post(int projectId, [FromBody] DesignerDto model)
        {
            if (!ModelState.IsValid)
                return Content("ModelState is invalid!");

            var project = _context.Projects
                .Include(x => x.Designers)
                .FirstOrDefault(x => x.Id == projectId);

            if (project == null)
                return Content("Brak projektu o podanym ID w bazie!");

            var designer = _mapper.Map<Designer>(model);

            project.Designers.Add(designer);

            _context.SaveChanges();

            return Ok(project);
        }

        [HttpDelete]
        public ActionResult Delete(int projectId)
        {
            var project = _context.Projects
                .Include(x => x.Designers)
                .FirstOrDefault(x => x.Id == projectId);

            if (project == null)
                return Content("Brak projektu o podanym ID w bazie!");

            _context.Designers.RemoveRange(project.Designers);
            _context.SaveChanges();

            return Content("Pomyslnie usunieto wszystkich uczestnikow projektu!");
        }

        [HttpDelete("{designerId}")]
        public ActionResult DeleteDesigner(int projectId, int designerId)
        {
            var project = _context.Projects
                .Include(x => x.Designers)
                .FirstOrDefault(x => x.Id == projectId);

            if (project == null)
                return Content("Brak projektu o podanym ID w bazie!");

            var designer = project.Designers.FirstOrDefault(x => x.Id == designerId);

            if (designer == null)
                return Content("Brak osoby o podanym ID w bazie!");

            _context.Designers.Remove(designer);
            _context.SaveChanges();

            return Content($"Pomyslnie usunieto {designer} z projektu {project}!");
        }

    }
}