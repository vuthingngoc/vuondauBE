using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.Feedback;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Reso.Core.Utilities;
using System.Linq;

namespace VuonDau.Business.Services
{
    public partial interface IFeedbackService
    {
        Task<List<FeedbackViewModel>> GetAllFeedbacks(SearchFeedbackRequest request);
        Task<FeedbackViewModel> GetFeedbackById(Guid id);
        Task<List<FeedbackViewModel>> GetFeedbackByOrderId(Guid id);
        Task<FeedbackViewModel> CreateFeedback(CreateFeedbackRequest request);
        Task<FeedbackViewModel> UpdateFeedback(Guid id, UpdateFeedbackRequest request);
        Task<int> DeleteFeedback(Guid id);
    }


    public partial class FeedbackService
    {
        private readonly IConfigurationProvider _mapper;

        public FeedbackService(IUnitOfWork unitOfWork, IFeedbackRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<List<FeedbackViewModel>> GetAllFeedbacks(SearchFeedbackRequest request)
        {
            if (request.Status == null) {
                if (request.HarvestId == null)
                {
                    return await Get().ProjectTo<FeedbackViewModel>(_mapper).OrderByDescending(f => f.Status) .ToListAsync();
                }
                else {
                    return await Get(f => f.HarvestId == request.HarvestId).ProjectTo<FeedbackViewModel>(_mapper).OrderByDescending(f => f.Status).ToListAsync();
                }
            } 
            else
            {
                if (request.HarvestId == null)
                {
                    return await Get(f => f.Status == request.Status).ProjectTo<FeedbackViewModel>(_mapper).OrderBy(f => f.Status).ToListAsync();
                }
                else
                {
                    return await Get(f => f.HarvestId == request.HarvestId && f.Status == request.Status)
                        .ProjectTo<FeedbackViewModel>(_mapper).OrderBy(f => f.Status).ToListAsync();
                }
            }
        }

        public async Task<FeedbackViewModel> GetFeedbackById(Guid id)
        {
            return await Get(p => p.Id == id && p.Status == (int)Status.Active).ProjectTo<FeedbackViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<List<FeedbackViewModel>> GetFeedbackByOrderId(Guid OrderId)
        {
            return await Get(p => p.OrderId == OrderId).ProjectTo<FeedbackViewModel>(_mapper).ToListAsync();
        }
        public async Task<FeedbackViewModel> CreateFeedback(CreateFeedbackRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var feedback = mapper.Map<Feedback>(request);
            feedback.Status = (int)Status.Active;
            feedback.DateOfCreate = DateTime.UtcNow;
            await CreateAsyn(feedback);
            var feedbackViewModel = mapper.Map<FeedbackViewModel>(feedback);
            return feedbackViewModel;
        }

        public async Task<FeedbackViewModel> UpdateFeedback(Guid id, UpdateFeedbackRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var feedbackInRequest = mapper.Map<Feedback>(request);
            var feedback = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (feedback == null)
            {
                return null;
            }
            feedback.OrderId = feedbackInRequest.OrderId;
            feedback.HarvestId = feedbackInRequest.HarvestId;
            feedback.FarmerId = feedbackInRequest.FarmerId;
            feedback.Description = feedbackInRequest.Description;
            feedback.Status = feedbackInRequest.Status;
            await UpdateAsyn(feedback);
            return mapper.Map<FeedbackViewModel>(feedback);
        }

        public async Task<int> DeleteFeedback(Guid id)
        {
            var feedback = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (feedback == null)
            {
                return 0;
            }

            feedback.Status = (int)Status.Inactive;
            await UpdateAsyn(feedback);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
