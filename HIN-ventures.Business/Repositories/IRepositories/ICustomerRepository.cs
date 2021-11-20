using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIN_ventures.Models;

namespace HIN_ventures.Business.Repositories.IRepositories
{
    interface ICustomerRepository
    {
        public Task<CustomerDto> GetCustomer(int? CustomerId);
        public Task<IEnumerable<CustomerDto>> GetAllCustomers();

        public Task<CustomerDto> CreateCustomer(CustomerDto customerDto);
        public Task<int> DeleteCustomer(int CustomerId);
        public Task<CustomerDto> UpdateCustomer(CustomerDto customerDto);
    }
}
