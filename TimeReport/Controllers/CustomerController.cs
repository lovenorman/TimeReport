﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeReport.Data;
using TimeReport.Data.DB;
using TimeReport.DTO;
using TimeReport.DTO.CustomerDTO;

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
            return Ok(_context.Customers./*Include(p => p.Projects).ThenInclude(p => p.TimeReports).*/Select(c => _mapper.Map<OneCustomerDTO>(c)));

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(_mapper.Map<OneCustomerDTO>(customer));
        }

        [HttpPost]
        public IActionResult Create(CreateCustomerDTO advertisement)
        {
            var customer = _mapper.Map<Customer>(advertisement);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            var customerDTO = _mapper.Map<OneCustomerDTO>(customer);

            return CreatedAtAction(nameof(GetOne), new { id = customer.Id }, customerDTO);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateCustomerDTO advertisement)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            
            if (customer == null)
                return NotFound();

            _mapper.Map<OneCustomerDTO>(customer);

            _context.SaveChanges();
            return NoContent();
        }
    }
}
