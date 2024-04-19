//using System;
//using WMBProject.Data.Entities;
//using WMBProject.Data.Enums;
//using WMBProject.Infrastructure.Bases.RepositoryBase;

//namespace WMBProject.Service.Customers
//{
//    public class CustomerService : ICustomerService
//    {
//        private readonly IGenericRepositoryAsync<Customer> _customerRepository;
//        public CustomerService(IGenericRepositoryAsync<Customer> customerRepository)
//        {
//            _customerRepository = customerRepository;
//        }

//        public Task<CheckCustomer> CheckCreatetCustomer(Customer customer)
//        {
//            var newCustomer = _customerRepository.GetTableNoTracking().Where(x => x.Email == customer.Email).FirstOrDefault();
//            if (newCustomer == null) return Task.FromResult(CheckCustomer.NotExit);
//            return Task.FromResult(CheckCustomer.Exist);
//        }

//        public Task<CheckCustomer> CheckLoginCustomer(string userName, string password)
//        {
//            var customer = _customerRepository.GetTableNoTracking().Where(x => x.Username == userName && x.Password == password).FirstOrDefault();
//            if (customer == null) return Task.FromResult(CheckCustomer.NotExit);
//            return Task.FromResult(CheckCustomer.Exist);
//        }

//        public async Task<Customer> CreateCustomer(Customer customer)
//        {
//           var newCustomer = await _customerRepository.AddAsync(customer);

//            return newCustomer;

//        }

//        public Customer LoginCustomer(string username, string password)
//        {
//            var customer = _customerRepository.GetTableNoTracking().Where(x => x.Username == username && x.Password == password).FirstOrDefault();
//            return customer;
//        }
//    }
//}

