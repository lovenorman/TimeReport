using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeReport.Data;
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

        [HttpPost]
        public IActionResult Create(CreateCustomer advertisement)
        {
            var ad = _mapper.Map<Customer>(advertisement);

            //var ad = new Advertisement
            //{
            //    Title = advertisement.Title,
            //    Author = advertisement.Author,
            //    CreateDate = advertisement.CreateDate,
            //    Description = advertisement.Description
            //};

            _context.Customers.Add(ad);
            _context.SaveChanges();

            var adDTO = _mapper.Map<CustomerDTO>(ad);

            return CreatedAtAction(nameof(GetOne), new { id = ad.Id }, adDTO);
        }
    }
}
