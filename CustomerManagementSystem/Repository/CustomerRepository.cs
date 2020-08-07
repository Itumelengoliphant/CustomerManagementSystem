using CustomerManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomerManagementSystem.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerDbEntity _context;

        public CustomerRepository(CustomerDbEntity context)
        {
            
            _context = context;
          //  _context.Database.Connection.Open();


        }
        public int AddCustomer(User customerEntity)
        {
            int result = -1;

            if (customerEntity != null)
            {
                _context.Users.Add(customerEntity);
                _context.SaveChanges();
                result = customerEntity.Id;
            }
            return result;
        }

        public void DeleteCustomer(int id)
        {
            User user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllCustomers()
        {
            return _context.Users.ToList();
        }

        public User GetCustomerId(int customerId)
        {
            return _context.Users.Where(x => x.Id == customerId).FirstOrDefault();
        }

        public int UpdateCustomer(User customerEntity)
        {
            int result = -1;

            if (customerEntity != null)
            {
                _context.Entry(customerEntity).State = EntityState.Modified;
                _context.SaveChanges();
                result = customerEntity.Id;
            }
            return result;
        }

       public List<User> SearchCustomer(string rating, string searchByRating)
        {
            int getRating = 0;

            if (searchByRating == "Yes")
            {
                getRating = Convert.ToInt32(rating);

                return _context.Users.Where(x => x.Rating == getRating || searchByRating == null).ToList();
            }
            else
            {
                return _context.Users.ToList();
            }
        }

        public User DisplayCustomerDetails(int id)
        {
            User user = _context.Users.Where(x => x.Id == id).FirstOrDefault();

            return user;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}