using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeReport.Data.DB;
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
            var customer = _context.Projects.FirstOrDefault(x => x.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(_mapper.Map<OneProjectDTO>(customer));
        }
    }
}
