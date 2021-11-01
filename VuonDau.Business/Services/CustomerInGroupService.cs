using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.CustomerInGroup;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Reso.Core.Utilities;

namespace VuonDau.Business.Services
{
    public partial interface ICustomerInGroupService
    {
        Task<List<CustomerInGroupViewModel>> GetAllCustomerInGroups(CustomerInGroupViewModel filter);
        Task<CustomerInGroupViewModel> GetCustomerInGroupById(Guid id);
        Task<CustomerInGroupViewModel> CreateCustomerInGroup(CreateCustomerInGroupRequest request);
        Task<CustomerInGroupViewModel> UpdateCustomerInGroup(Guid id, UpdateCustomerInGroupRequest request);
        Task<int> DeleteCustomerInGroup(Guid id);
    }


    public partial class CustomerInGroupService
    {
        private readonly IConfigurationProvider _mapper;

        public CustomerInGroupService(IUnitOfWork unitOfWork, ICustomerInGroupRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

         public async Task<List<CustomerInGroupViewModel>> GetAllCustomerInGroups(CustomerInGroupViewModel filter)
        {
            return await Get().ProjectTo<CustomerInGroupViewModel>(_mapper).DynamicFilter(filter).ToListAsync();
        }

        public async Task<CustomerInGroupViewModel> GetCustomerInGroupById(Guid id)
        {
            return await Get(p => p.CustomerId == id ).ProjectTo<CustomerInGroupViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<CustomerInGroupViewModel> CreateCustomerInGroup(CreateCustomerInGroupRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var customerInGroup = mapper.Map<CustomerInGroup>(request);
            await CreateAsyn(customerInGroup);
            var customerInGroupViewModel = mapper.Map<CustomerInGroupViewModel>(customerInGroup);
            return customerInGroupViewModel;
        }

        public async Task<CustomerInGroupViewModel> UpdateCustomerInGroup(Guid id, UpdateCustomerInGroupRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var customerInGroupInRequest = mapper.Map<CustomerInGroup>(request);
            var customerInGroup = await Get(p => p.CustomerId == id).FirstOrDefaultAsync();
            if (customerInGroup == null)
            {
                return null;
            }
            customerInGroup.CustomerGroupId = customerInGroupInRequest.CustomerGroupId;
            customerInGroup.JoinDate = customerInGroupInRequest.JoinDate;
            await UpdateAsyn(customerInGroup);
            return mapper.Map<CustomerInGroupViewModel>(customerInGroup);
        }

        public async Task<int> DeleteCustomerInGroup(Guid id)
        {
            var customerInGroup = await Get(p => p.CustomerId == id).FirstOrDefaultAsync();

            if (customerInGroup == null)
            {
                return 0;
            }

            await UpdateAsyn(customerInGroup);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
