using Shopping.Core.ServiceInterfaces;
using Shopping.Data;
using Shopping.Data.Interfaces;
using Shopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping.Core.Services
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
