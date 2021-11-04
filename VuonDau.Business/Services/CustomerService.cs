using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.Customer;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using VuonDau.Business.Requests;
using Microsoft.Extensions.Configuration;
<<<<<<< HEAD
=======
using Reso.Core.Utilities;
>>>>>>> b80301f358fce8737aa58cbd3a6ad0d1fecf2c06

namespace VuonDau.Business.Services
{
    public partial interface ICustomerService
    {
        Task<List<CustomerViewModel>> GetAllCustomers(CustomerViewModel filter);
        Task<CustomerViewModel> GetCustomerById(Guid id);
        Task<List<CustomerViewModel>> GetCustomerByType(Guid id);
        Task<CustomerViewModel> CreateCustomer(CreateCustomerRequest request, IConfiguration configuration);
        Task<CustomerViewModel> UpdateCustomer(Guid id, UpdateCustomerRequest request);
        Task<int> DeleteCustomer(Guid id);
        Task<CustomerViewModel> GetByMail(string mail);
    }


    public partial class CustomerService
    {
        private readonly AutoMapper.IConfigurationProvider _mapper;

        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<CustomerViewModel>> GetAllCustomers(CustomerViewModel filter)
        {
            return await Get().ProjectTo<CustomerViewModel>(_mapper).DynamicFilter(filter).ToListAsync();
        }

        public async Task<CustomerViewModel> GetByMail(string mail)
        {
            return await Get(c => c.Email.Equals(mail)).ProjectTo<CustomerViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<CustomerViewModel> GetCustomerById(Guid id)
        {
            return await Get(p => p.Id == id ).ProjectTo<CustomerViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<List<CustomerViewModel>> GetCustomerByType(Guid CustomerTypeId)
        {
            return await Get(p => p.CustomerType == CustomerTypeId).ProjectTo<CustomerViewModel>(_mapper).ToListAsync();
        }
        public async Task<CustomerViewModel> CreateCustomer(CreateCustomerRequest request, IConfiguration configuration)
            {
            var mapper = _mapper.CreateMapper();
            var customer = mapper.Map<Customer>(request);
            customer.Status = (int)Status.Active;
            customer.DateOfCreate = DateTime.UtcNow;
            await CreateAsyn(customer);
            var customerViewModel = mapper.Map<CustomerViewModel>(customer);
            customerViewModel.jwtToken = TokenService.GenerateCustomerJWTWebToken(customerViewModel, configuration);
            return customerViewModel;
        }
        public async Task<CustomerViewModel> UpdateCustomer(Guid id, UpdateCustomerRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var customerInRequest = mapper.Map<Customer>(request);
            var customer = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (customer == null)
            {
                return null;
            }
            customer.CustomerType = customerInRequest.CustomerType;
            customer.FirstName = customerInRequest.FirstName;
            customer.LastName = customerInRequest.LastName;
            customer.Password = customerInRequest.Password;
            customer.Phone = customerInRequest.Phone;
            customer.Birthday = customerInRequest.Birthday;
            customer.Gender = customerInRequest.Gender;
            customer.Status = customerInRequest.Status;
            await UpdateAsyn(customer);
            return mapper.Map<CustomerViewModel>(customer);
        }

        public async Task<int> DeleteCustomer(Guid id)
        {
            var customer = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (customer == null)
            {
                return 0;
            }

            customer.Status = (int)Status.Inactive;
            await UpdateAsyn(customer);

            return 1;
        }
<<<<<<< HEAD
<<<<<<< HEAD

<<<<<<< HEAD
        public async Task<string> Login(UserLoginRequest loginRequest, IConfiguration configuration)
        {
            FirebaseToken token = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(loginRequest.AccessToken); // re-check access token with firebase
            object email;
            token.Claims.TryGetValue("email", out email); // get email from the above re-check step, then check the email whether it's matched the request email
            CustomerViewModel result = await GetByMail(email.ToString());
            if (result != null)
            {
                string verifyRequestToken = TokenService.GenerateCustomerJWTWebToken(result, configuration);
                return await Task.Run(() => verifyRequestToken); // return if everything is done
            }
            throw new ErrorResponse((int)ResponseStatusConstants.CREATED, "Email's not existed in database yet.");
        }
=======
>>>>>>> update-database
=======
>>>>>>> b80301f358fce8737aa58cbd3a6ad0d1fecf2c06
=======

>>>>>>> 2a68c653fee721c9c8133eebbb6a46552a6c8b43
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
