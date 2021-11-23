using Day14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day14.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private ToyManufacturingCompanyContext _Context;
        public CustomerRepository(ToyManufacturingCompanyContext ToyContext)
        {
            _Context = ToyContext;
        }

        public Customer AddCustomer(Customer customer)
        {
            _Context.Customers.Add(customer);
            _Context.SaveChanges();
            return customer;
        }

        public void DeleteCustomer(Customer customer)
        {
            var Customer=_Context.Customers.Find(customer.CustomerId);
            if (Customer != null)
            {
                _Context.Customers.Remove(customer);
                _Context.SaveChanges();
            }
        }

        public Customer EditCustomer(Customer customer)
        {
            var existingCustomer = _Context.Customers.SingleOrDefault(Customer => Customer.CustomerId == customer.CustomerId);

            if(existingCustomer!=null)
            {
                existingCustomer.CustomerName = customer.CustomerName;
                existingCustomer.Age = customer.Age;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                _Context.SaveChanges();
            }
                return customer;
        }

        public Customer GetCustomer(int Id)
        {
            return _Context.Customers.SingleOrDefault(customer => customer.CustomerId == Id);
        }

        public List<Customer> GetCustomers()
        {
            return _Context.Customers.ToList();
        }
    }
}
