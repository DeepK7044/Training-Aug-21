using Day14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day14.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();

        Customer GetCustomer(int Id);

        Customer AddCustomer(Customer customer);

        void DeleteCustomer(Customer customer);

        Customer EditCustomer(Customer customer);

    }
}
