using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeReport.Data.DB;
using TimeReport.DTO.TimeReportDTO;

namespace TimeReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public TimeReportController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]//Deafult
        public IActionResult Index()//GetAll
        {
            return Ok(_context.TimeReports./*Include(p => p.Projects).ThenInclude(p => p.TimeReports).*/Select(c => _mapper.Map<AllTimeReportsDTO>(c)));

        }
    }
}
