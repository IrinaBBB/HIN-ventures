using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIN_ventures.Models;

namespace HIN_ventures_Client.Service.IService
{
    public interface ICustomerService
    {
        public Task<IEnumerable<CustomerDto>> GetCustomers();

        public Task<CustomerDto> GetCustomer(int customerId); 

        public Task<CustomerDto> CreateCustomer(CustomerDto customer);

        public Task<CustomerDto> UpdateCustomer(int customerId, CustomerDto customer);
    }
}