using Shopping.Core.Domain.Customer;
using Shopping.Data.Interfaces;
using Shopping.Service.ServiceInterfaces;
using System.Collections.Generic;

namespace Shopping.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        //private readonly IGenericRepository<Customer> customerRepository;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            //customerRepository = unitOfWork.CustomerRepository;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var result = unitOfWork.CustomerRepository.GetAll();
            return result;
        }

        public Customer GetCustomerById(int id)
        {
            return unitOfWork.CustomerRepository.GetById(id);
        }
    }
}
