using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeReport.Data;
using TimeReport.Data.DB;
using TimeReport.DTO;
using TimeReport.DTO.TimeRegistrationsDTO;

namespace TimeReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeRegistrationController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public TimeRegistrationController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]//Deafult
        public IActionResult Index()//GetAll
        {
            return Ok(_context.TimeRegistrations.Select(c => _mapper.Map<AllTimeRegistrationsDTO>(c)));

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            var timeRegistration = _context.TimeRegistrations.FirstOrDefault(x => x.Id == id);
            if (timeRegistration == null)
                return NotFound();

            return Ok(_mapper.Map<OneTimeRegistrationDTO>(timeRegistration));
        }

        [HttpPost]
        public IActionResult Create(CreateTimeRegistrationDTO  createdRegistration)
        {
            if(ModelState.IsValid)
            {
                var timeRegistration = _mapper.Map<TimeRegister>(createdRegistration);
                var project = _context.Projects.Find(createdRegistration.ProjectId);

                if (project == null)
                {
                    return NotFound();
                }

                project.TimeRegistrations.Add(timeRegistration);
                _context.SaveChanges();

                var timeRegistrationDTO = _mapper.Map<CreateTimeRegistrationDTO>(timeRegistration);

                return CreatedAtAction(nameof(GetOne), new { id = timeRegistration.Id }, timeRegistrationDTO);
            }
            return NotFound("Wrong input");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateTimeRegistrationDTO updatedTimeRegistration)
        {
            if(ModelState.IsValid)
            {
                var timeRegistration = _context.TimeRegistrations.FirstOrDefault(x => x.Id == id);

                if (timeRegistration == null)
                {
                    return NotFound();
                }

                _mapper.Map(updatedTimeRegistration, timeRegistration);

                _context.SaveChanges();
                return Ok(updatedTimeRegistration);
            }
            return NotFound("Wrong input");
        }
    }
}
