using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeReport.Data;
using TimeReport.Data.DB;
using TimeReport.DTO;
using TimeReport.DTO.ProjectDTO;

namespace TimeReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public ProjectController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]//Deafult
        public IActionResult Index()//GetAll
        {
            return Ok(_context.Projects.Select(c => _mapper.Map<AllProjectsDTO>(c)));

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            var project = _context.Projects.Include(t => t.TimeRegistrations).FirstOrDefault(x => x.Id == id);
            if (project == null)
                return NotFound();

            return Ok(_mapper.Map<OneProjectDTO>(project));
        }

        [HttpPost]
        public IActionResult Create(CreateProject createdProject)
        {
            if (ModelState.IsValid)
            {
                var cust = _context.Customers.First(c => c.Id == createdProject.CustomerId);
                var project = _mapper.Map<Project>(createdProject);
                

                _context.Projects.Add(project);
                _context.SaveChanges();

                var projectDTO = _mapper.Map<OneProjectDTO>(project);

                return CreatedAtAction(nameof(GetOne), new { id = project.Id }, projectDTO);
            }
            return NotFound("Wrong input");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateProjectDTO updatedProject)
        {
            if (ModelState.IsValid)
            {
                var project = _context.Projects.FirstOrDefault(x => x.Id == id);

                if (project == null)
                    return NotFound();

                _mapper.Map<UpdateProjectDTO>(project);

                _context.SaveChanges();
                return Ok(updatedProject);
            }
            return NotFound("Wrong input");
        }
    }
}
