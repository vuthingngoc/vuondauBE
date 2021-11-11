using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.CustomerType;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Reso.Core.Utilities;

namespace VuonDau.Business.Services
{
    public partial interface ICustomerTypeService
    {
        Task<List<CustomerTypeViewModel>> GetAllCustomerTypes(string name);
        Task<CustomerTypeViewModel> GetCustomerTypeById(Guid id);
        Task<CustomerTypeViewModel> CreateCustomerType(CreateCustomerTypeRequest request);
        Task<CustomerTypeViewModel> UpdateCustomerType(Guid id, UpdateCustomerTypeRequest request);
        Task<int> DeleteCustomerType(Guid id);
    }


    public partial class CustomerTypeService
    {
        private readonly IConfigurationProvider _mapper;

        public CustomerTypeService(IUnitOfWork unitOfWork, ICustomerTypeRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<CustomerTypeViewModel>> GetAllCustomerTypes(string name)
        {
            name = name == null ? "" : name;
            return await Get(c => c.Name.Contains(name)).ProjectTo<CustomerTypeViewModel>(_mapper).ToListAsync();
        }

        public async Task<CustomerTypeViewModel> GetCustomerTypeById(Guid id)
        {
            return await Get(p => p.Id == id ).ProjectTo<CustomerTypeViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<CustomerTypeViewModel> CreateCustomerType(CreateCustomerTypeRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var customerType = mapper.Map<CustomerType>(request);
            await CreateAsyn(customerType);
            var customerTypeViewModel = mapper.Map<CustomerTypeViewModel>(customerType);
            return customerTypeViewModel;
        }

        public async Task<CustomerTypeViewModel> UpdateCustomerType(Guid id, UpdateCustomerTypeRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var customerTypeInRequest = mapper.Map<CustomerType>(request);
            var customerType = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (customerType == null)
            {
                return null;
            }
            customerType.Name = customerTypeInRequest.Name;
            customerType.Description = customerTypeInRequest.Description;
            await UpdateAsyn(customerType);
            return mapper.Map<CustomerTypeViewModel>(customerType);
        }

        public async Task<int> DeleteCustomerType(Guid id)
        {
            var customerType = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (customerType == null)
            {
                return 0;
            }

            //customer.Status = (int)Status.Inactive;
            await UpdateAsyn(customerType);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
