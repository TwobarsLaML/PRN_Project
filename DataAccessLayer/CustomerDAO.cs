using BusinessObjects;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        private FuminiHotelManagementContext db = new FuminiHotelManagementContext();
        public List<Customer> GetAllCustomers()
        {
           

            List<Customer> customers = new List<Customer>();
            try
            {
                customers = db.Customers.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customers;
        }

        public Customer GetAdmin()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            string email = configuration["AdminAccount:Email"];
            string password = configuration["AdminAccount:Password"];
            return new Customer { EmailAddress = email, Password = password };
        }

        public Customer getCustomerById(int id)
        {

            Customer customer = null;
            try
            {
                customer = db.Customers.Single(c => c.CustomerId  == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot get customer");
            }
            return customer;

        }

        public Customer GetCustomerByEmail(string email)
        {
            
                Customer customer = null;
                try
                {
                    customer = db.Customers.Single(c => c.EmailAddress == email);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot get customer");
                }
                return customer;
            
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void UpdateCustomer(Customer customer)
        {
            try
            {
                db.Customers.Update(customer);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void DeleteCustomer(int id)
        {
            try
            {
                Customer customer = db.Customers.FirstOrDefault(c => c.CustomerId == id);
                db.Customers.Remove(customer);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public List<Customer> GetCustomersByName(string name)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                customers = db.Customers.Where(c => c.CustomerFullName.ToLower().Contains(name.ToLower())).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot get customer");
            }
            return customers;

        }

    }
}
