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
            return Ok(_context.Projects.Include(c => c.Customer)
                .Select(_mapper.Map<Project, AllProjectsDTO>)
                .ToList());

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            var project = _context.Projects.Include(c => c.TimeRegistrations).FirstOrDefault(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }  

            return Ok(_mapper.Map<OneProjectDTO>(project));
        }

        [HttpPost]
        public IActionResult Create(CreateProject createdProject)
        {
            if (ModelState.IsValid)
            {
                var project = _mapper.Map<Project>(createdProject);
                project.Customer = _context.Customers.First(cust => cust.Id == createdProject.CustomerId);

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
                {
                    return NotFound();
                } 

                _mapper.Map(updatedProject, project);

                _context.SaveChanges();
                return Ok(updatedProject);
            }
            return NotFound("Wrong input");
        }
    }
}
