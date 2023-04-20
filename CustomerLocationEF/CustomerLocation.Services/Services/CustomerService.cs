using CustomerLocationEF.Data.Models;
using CustomerLocationEF.Data.Context;

namespace CustomerLocation.Services.Services
{
    public interface ICustomer
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        int Create(Customer customer);
        int Update(int id, Customer updatedCustomer);
        bool Delete(int id);
    }


    public class CustomerService : ICustomer
    {

        private CustomerDbContext _context;
        public CustomerService(CustomerDbContext newContext)
        {
            _context = newContext;
        }

        List<Customer> ICustomer.GetAll()
        {
            return _context.Customers.Where(c => c.IsDeleted == false).ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public int Create(Customer customer)
        {
            Customer result = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);
            if (result == null)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return customer.Id;
            }
            return -1;
        }

        public int Update(int id, Customer customer)
        {
            Customer existingCustomer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.DateOfBirth = customer.DateOfBirth;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.Email = customer.Email;
                existingCustomer.Address = customer.Address;
            }
            _context.SaveChanges();
            return customer.Id;
        }

        public bool Delete(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                customer.IsDeleted = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
