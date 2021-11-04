using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.Campaign;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using VuonDau.Business.Requests;
using Microsoft.Extensions.Configuration;
using FirebaseAdmin.Auth;
using VuonDau.Data.Common.Constants;
using Reso.Core.Utilities;

namespace VuonDau.Business.Services
{
    public partial interface ICampaignService
    {
        Task<List<CampaignViewModel>> GetAllCampaigns(CampaignViewModel filter);
        Task<CampaignViewModel> GetCampaignById(Guid id);
        Task<List<CampaignViewModel>> GetCampaignByHarvestSellingId(Guid id);
        Task<List<CampaignViewModel>> GetCampaignByOrderId(Guid id);
        Task<CampaignViewModel> CreateCampaign(CreateCampaignRequest request);
        Task<CampaignViewModel> UpdateCampaign(Guid id, UpdateCampaignRequest request);
        Task<int> DeleteCampaign(Guid id);
    }


    public partial class CampaignService
    {
        private readonly AutoMapper.IConfigurationProvider _mapper;

        public CampaignService(IUnitOfWork unitOfWork, ICampaignRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<CampaignViewModel>> GetAllCampaigns(CampaignViewModel filter)
        {
            return await Get().ProjectTo<CampaignViewModel>(_mapper).DynamicFilter(filter).ToListAsync();
        }


        public async Task<CampaignViewModel> GetCampaignById(Guid id)
        {
            return await Get(p => p.Id == id ).ProjectTo<CampaignViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<List<CampaignViewModel>> GetCampaignByHarvestSellingId(Guid HarvestSellingId)
        {
            return await Get(p => p.HarvestSellingId == HarvestSellingId).ProjectTo<CampaignViewModel>(_mapper).ToListAsync();
        }
        public async Task<List<CampaignViewModel>> GetCampaignByOrderId(Guid OrderId)
        {
            return await Get(p => p.OrderId == OrderId).ProjectTo<CampaignViewModel>(_mapper).ToListAsync();
        }
        public async Task<CampaignViewModel> CreateCampaign(CreateCampaignRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var campaign = mapper.Map<Campaign>(request);
            campaign.Status = (int)Status.Active;
            await CreateAsyn(campaign);
            var campaignViewModel = mapper.Map<CampaignViewModel>(campaign);
            return campaignViewModel;
        }

        public async Task<CampaignViewModel> UpdateCampaign(Guid id, UpdateCampaignRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var campaignInRequest = mapper.Map<Campaign>(request);
            var campaign = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (campaign == null)
            {
                return null;
            }
            campaign.HarvestSellingId = campaignInRequest.HarvestSellingId;
            campaign.OrderId = campaignInRequest.OrderId;
            campaign.StartTime = campaignInRequest.StartTime;
            campaign.EndTime = campaignInRequest.EndTime;
            campaign.MinOrderAmount = campaignInRequest.MinOrderAmount;
            campaign.Status = campaignInRequest.Status;
            await UpdateAsyn(campaign);
            return mapper.Map<CampaignViewModel>(campaign);
        }

        public async Task<int> DeleteCampaign(Guid id)
        {
            var campaign = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (campaign == null)
            {
                return 0;
            }

            campaign.Status = (int)Status.Inactive;
            await UpdateAsyn(campaign);

            return 1;
        }


        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
