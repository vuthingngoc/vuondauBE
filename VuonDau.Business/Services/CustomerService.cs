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
using FirebaseAdmin.Auth;
using VuonDau.Data.Common.Constants;

namespace VuonDau.Business.Services
{
    public partial interface ICustomerService
    {
        Task<List<CustomerFullViewModel>> GetAllCustomers();
        Task<CustomerFullViewModel> GetCustomerById(Guid id);
        Task<CustomerFullViewModel> CreateCustomer(CreateCustomerRequest request);
        Task<CustomerFullViewModel> UpdateCustomer(Guid id, UpdateCustomerRequest request);
        Task<int> DeleteCustomer(Guid id);
        Task<string> Login(UserLoginRequest loginRequest, IConfiguration configuration);
    }


    public partial class CustomerService
    {
        private readonly AutoMapper.IConfigurationProvider _mapper;

        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<CustomerFullViewModel>> GetAllCustomers()
        {
            return await Get().ProjectTo<CustomerFullViewModel>(_mapper).ToListAsync();
        }

        public async Task<CustomerFullViewModel> GetByMail(string mail)
        {
            return await Get(c => c.Email.Equals(mail)).ProjectTo<CustomerFullViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<CustomerFullViewModel> GetCustomerById(Guid id)
        {
            return await Get(p => p.Id == id ).ProjectTo<CustomerFullViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<CustomerFullViewModel> CreateCustomer(CreateCustomerRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var customer = mapper.Map<Customer>(request);
            customer.Status = (int)Status.Active;
            customer.DateOfCreate = DateTime.UtcNow;
            await CreateAsyn(customer);
            var customerViewModel = mapper.Map<CustomerFullViewModel>(customer);
            return customerViewModel;
        }

        public async Task<CustomerFullViewModel> UpdateCustomer(Guid id, UpdateCustomerRequest request)
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
            return mapper.Map<CustomerFullViewModel>(customer);
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

        public async Task<string> Login(UserLoginRequest loginRequest, IConfiguration configuration)
        {
            UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(loginRequest.GoogleId); // get user by request's guid
            CustomerViewModel result = await GetByMail(userRecord.Email);

            if (result != null) // if email existed in local database
            {
                FirebaseToken token = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(loginRequest.AccessToken); // re-check access token with firebase
                object email;
                token.Claims.TryGetValue("email", out email); // get email from the above re-check step, then check the email whether it's matched the request email
                if (userRecord.Email.Equals(email))
                {
                    string verifyRequestToken = TokenService.GenerateCustomerJWTWebToken(result, configuration);

                    return await Task.Run(() => verifyRequestToken); // return if everything is done
                }
                throw new ErrorResponse((int)ResponseStatusConstants.FORBIDDEN, "Email from request and the one from access token is not matched."); // return if this email's not existed yet in database - FE foward to sign up page
            }
            var claim = new Dictionary<string, object> { { "email", userRecord.Email } };
            await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(loginRequest.GoogleId, claim);

            throw new ErrorResponse((int)ResponseStatusConstants.CREATED, "Email's not existed in database yet.");
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
