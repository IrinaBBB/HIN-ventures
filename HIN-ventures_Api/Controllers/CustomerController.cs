using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIN_ventures.Business.Repositories.IRepositories;
using HIN_ventures.Common;
using HIN_ventures.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;


//Ikke sikkert vi trenger den her...Info om kunden blir opprettet ved brukerregistering og ved registrering av assignment
namespace HIN_ventures_Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers() 
        {
            var customers = await _customerRepository.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(int? customerId)
        {
            if (customerId == null)
            {
                return BadRequest(new ErrorModel()
                {
                    Title = "",
                    ErrorMessage = "Invalid Customer Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var customerDetails = await _customerRepository.GetCustomer(customerId);
            if (customerDetails == null)
            {
                return BadRequest(new ErrorModel()
                {
                    Title = "",
                    ErrorMessage = "Invalid Customer Id",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(customerDetails);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _customerRepository.CreateCustomer(customerDto);
                return Ok(result);
            }
            else
            {
                return BadRequest(new ErrorModel()
                {
                    ErrorMessage = "Error while creating new Customer"
                });
            }
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _customerRepository.UpdateCustomer(id, customerDto);
                return Ok(result);
            }
            else
            {
                return BadRequest(new ErrorModel()
                {
                    ErrorMessage = "Error while Updating new Customer"
                });
            }
        }
    }
}