using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HIN_ventures.Business.Repositories.IRepositories;
using HIN_ventures.DataAccess.Data;
using HIN_ventures.DataAccess.Entities;
using HIN_ventures.Models;
using Microsoft.EntityFrameworkCore;

namespace HIN_ventures.Business.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CustomerRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            
            var addedCustomer = await _db.Customers.AddAsync(customer);
            await _db.SaveChangesAsync();
            return _mapper.Map<Customer, CustomerDto>(addedCustomer.Entity);
        }

        public async Task<int> DeleteCustomer(int CustomerId)
        {
            var customer = await _db.Customers.FindAsync(CustomerId);

            if (customer != null)
            {
                _db.Customers.Remove(customer);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            try
            {
                IEnumerable<CustomerDto> customerDtos =
                    _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>
                        (_db.Customers
                            .Include(x => x.Assignments)
                            .Include(x => x.Ratings)
                        );

                return await Task.FromResult(customerDtos);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        public async Task<CustomerDto> GetCustomer(int? CustomerId)
        {
            try
            {
                CustomerDto customer = _mapper.Map<Customer, CustomerDto>(
                    await _db.Customers
                        .Include(x => x.Assignments)
                        .Include(x => x.Ratings)
                        .FirstOrDefaultAsync(x => x.CustomerId == CustomerId));

                return customer;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return null;
            }
        }

        public async Task<CustomerDto> UpdateCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);

            var customerToUpdate = _db.Customers.Update(customer);
            await _db.SaveChangesAsync();
            
            return _mapper.Map<Customer, CustomerDto>(customerToUpdate.Entity);
        }
    }
}
