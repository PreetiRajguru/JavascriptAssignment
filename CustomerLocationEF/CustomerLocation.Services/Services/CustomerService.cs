using CustomerLocationEF.Data.Context;
using CustomerLocationEF.Data.Models;

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
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer.Id;
        }

        public int Update(int id, Customer customer)
        {
            //_context.Customers.Update(customer);
            //_context.SaveChanges();

            //return customer.Id;

            Customer existingCustomer = _context.Customers.FirstOrDefault(c => c.Email == customer.Email);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.DateOfBirth = customer.DateOfBirth;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.Email = customer.Email;
                existingCustomer.Address = customer.Address;
                _context.SaveChanges();

                return customer.Id;
            }
            return 1;
        }

        public bool Delete(int id)
        {
            //_context.Customers.Remove(customer);
            //_context.SaveChanges();

            //return customer.Id;

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
