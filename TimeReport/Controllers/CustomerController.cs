using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeReport.Data.DB;
using TimeReport.DTO;

namespace TimeReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public CustomerController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]//Deafult
        public IActionResult Index()//GetAll
        {
            return Ok(_context.Customers.Include(p => p.Projects).Select(c => _mapper.Map<CustomerDTO>(c)));

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            var ad = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (ad == null)
                return NotFound();

            return Ok(_mapper.Map<CustomerDTO>(ad));
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateAdvertisement advertisement)
        {
            var ad = _context.Customers.FirstOrDefault(x => x.Id == id);

            if (ad == null)
                return NotFound();

            _mapper.Map<CustomerDTO>(ad);

            //ad.Title = advertisement.Title;
            //ad.Author = advertisement.Author;
            //ad.CreateDate = advertisement.CreateDate;
            //ad.Description = advertisement.Description;

            _context.SaveChanges();
            return NoContent();
        }
    }
}
