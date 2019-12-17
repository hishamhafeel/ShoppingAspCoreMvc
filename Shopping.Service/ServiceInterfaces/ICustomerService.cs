using Shopping.Core.Domain.Customer;
using System.Collections.Generic;

namespace Shopping.Service.ServiceInterfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
    }
}
