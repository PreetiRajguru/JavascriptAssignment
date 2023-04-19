using CustomerLocationEF.Data.Models;
using CustomerLocationEF.Data.Context;

namespace CustomerLocation.Services.Services
{
    public interface ICustomer
    {
        List<Customer> GetAll();
        Customer GetCustomer(int id);
        int AddCustomer(Customer customer);
        int UpdateCustomer(int id, Customer updatedCustomer);
        int DeleteCustomer(int id);
    }


    public class CustomerService : ICustomer
    {

        private CustomerDbContext _context;
        public CustomerService(CustomerDbContext newContext)
        {
            _context = newContext;
        }
        public int AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        List<Customer> ICustomer.GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateCustomer(int id, Customer updatedCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
