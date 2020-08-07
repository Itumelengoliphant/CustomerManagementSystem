using CustomerManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagementSystem.Repository
{
    public interface ICustomerRepository : IDisposable
    {
        IEnumerable<User> GetAllCustomers();
        User GetCustomerId(int customerId);
        int AddCustomer(User customerEntity);
        int UpdateCustomer(User customerEntity);
        void DeleteCustomer(int customerId);
        User DisplayCustomerDetails(int customerId);
        List<User> SearchCustomer(string rating, string searchByRating);
    }
}