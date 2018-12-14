using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalServiceDL;
using System.Configuration;


namespace CarRentalServiceBL
{
    public class CustomerMethods
    {
        static private CarRentalServicesDBContext _context = new CarRentalServicesDBContext();

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Where(x => x.Id == id).FirstOrDefault();
        }

        public Customer GetCustomer(string option, string term)
        {
            switch (option)
            {
                case "firstname":
                    return _context.Customers.Where(x => x.FirstName == term).FirstOrDefault();
                case "lastname":
                    return _context.Customers.Where(x => x.LastName == term).FirstOrDefault();
                default:
                    return new Customer { };
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public void AddCustomer(Customer newCust)
        {
            Customer cust = new Customer
            {
                FirstName = newCust.FirstName,
                LastName = newCust.LastName,
                Phone = newCust.Phone,
                Email = newCust.Email
            };
            _context.Customers.Add(cust);
            _context.SaveChanges();

        }

        public void RemoveCustomer(string option, string name)
        {
            Customer customer = GetCustomer(option, name);
            try
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("fuck");
            }

        }

        public void ChangeCustomer(Customer customer)
        {
            var oldCustomer = _context.Customers.Where(x => x.Id == customer.Id).FirstOrDefault();
            _context.Customers.Remove(oldCustomer);
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("fuck");
            }

            
        }
    }
}
