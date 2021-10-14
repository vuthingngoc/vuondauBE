using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.CustomerGroup;
using AutoMapper.QueryableExtensions;
using AutoMapper;
namespace VuonDau.Business.Services
{
    public partial interface ICustomerGroupService
    {
        Task<List<CustomerGroupViewModel>> GetAllCustomerGroups();
        Task<CustomerGroupViewModel> GetCustomerGroupById(Guid id);
        Task<CustomerGroupViewModel> CreateCustomerGroup(CreateCustomerGroupRequest request);
        Task<CustomerGroupViewModel> UpdateCustomerGroup(Guid id, UpdateCustomerGroupRequest request);
        Task<int> DeleteCustomerGroup(Guid id);
    }


    public partial class CustomerGroupService
    {
        private readonly IConfigurationProvider _mapper;

        public CustomerGroupService(IUnitOfWork unitOfWork, ICustomerGroupRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<CustomerGroupViewModel>> GetAllCustomerGroups()
        {
            return await Get().ProjectTo<CustomerGroupViewModel>(_mapper).ToListAsync();
        }

        public async Task<CustomerGroupViewModel> GetCustomerGroupById(Guid id)
        {
            return await Get(p => p.Id == id ).ProjectTo<CustomerGroupViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<CustomerGroupViewModel> CreateCustomerGroup(CreateCustomerGroupRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var customerGroup = mapper.Map<CustomerGroup>(request);
            await CreateAsyn(customerGroup);
            var customerGroupViewModel = mapper.Map<CustomerGroupViewModel>(customerGroup);
            return customerGroupViewModel;
        }

        public async Task<CustomerGroupViewModel> UpdateCustomerGroup(Guid id, UpdateCustomerGroupRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var customerGroupInRequest = mapper.Map<CustomerGroup>(request);
            var customerGroup = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (customerGroup == null)
            {
                return null;
            }
            customerGroup.Name = customerGroupInRequest.Name;
            customerGroup.Location = customerGroupInRequest.Location;
            customerGroup.HarvestSellingId = customerGroupInRequest.HarvestSellingId;
            await UpdateAsyn(customerGroup);
            return mapper.Map<CustomerGroupViewModel>(customerGroup);
        }

        public async Task<int> DeleteCustomerGroup(Guid id)
        {
            var customerGroup = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (customerGroup == null)
            {
                return 0;
            }

            await UpdateAsyn(customerGroup);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
