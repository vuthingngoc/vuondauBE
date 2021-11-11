using Reso.Core.BaseConnect;
using VuonDau.Data.Repositories;
using VuonDau.Data.Models;
using System.Collections.Generic;
using VuonDau.Data.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VuonDau.Business.ViewModel;
using System;
using VuonDau.Business.Requests.Farm;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Reso.Core.Utilities;
using System.Linq;
using VuonDau.Data.Common.Response;
using VuonDau.Data.Common.Constants;

namespace VuonDau.Business.Services
{
    public partial interface IFarmService
    {
        Task<ModelsResponse<FarmViewModel>> GetAllFarms(SearchFarmRequest request, int page, int size);
        Task<FarmViewModel> GetFarmById(Guid id);
        Task<List<FarmViewModel>> GetFarmByType(Guid id);
        Task<List<FarmViewModel>> GetFarmByFarmerId(Guid id);
        Task<List<FarmViewModel>> GetFarmByAreaId(Guid id);
        Task<FarmViewModel> CreateFarm(CreateFarmRequest request);
        Task<FarmViewModel> UpdateFarm(Guid id, UpdateFarmRequest request);
        Task<FarmViewModel> UpdateFarmStatus(Guid id, int status);
        Task<int> DeleteFarm(Guid id);
    }


    public partial class FarmService 
    {
        private readonly IConfigurationProvider _mapper;

        public FarmService(IUnitOfWork unitOfWork, IFarmRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<ModelsResponse<FarmViewModel>> GetAllFarms(SearchFarmRequest request, int page, int size)
        {
            request.Name = request.Name == null ? "" : request.Name;
            if (request.Status == null)
            {
                if (request.FarmTypeId == null)
                {
                    if (request.FarmerId == null)
                    {
                        if (request.AreaId == null)
                        {
                            var result = Get(f => f.Name.ToLower().Contains(request.Name.ToLower()))
                                    .OrderBy(f => f.Name).OrderByDescending(f => f.Status).ProjectTo<FarmViewModel>(_mapper)
                                    .PagingIQueryable(page, size, PageConstants.LimitPaging, PageConstants.DefaultPage);
                            return new ModelsResponse<FarmViewModel>
                            {
                                Data = await result.Item2.ToListAsync(),
                            };
                        }
                        else
                        {
                            var result = Get(f => f.Name.ToLower().Contains(request.Name.ToLower()) && f.AreaId == request.AreaId)
                                    .OrderBy(f => f.Name).OrderByDescending(f => f.Status).ProjectTo<FarmViewModel>(_mapper)
                                    .PagingIQueryable(page, size, PageConstants.LimitPaging, PageConstants.DefaultPage);
                            return new ModelsResponse<FarmViewModel>
                            {
                                Data = await result.Item2.ToListAsync(),
                            };
                        }
                    }
                    else
                    {
                        if (request.AreaId == null)
                        {
                            var result = Get(f => f.Name.ToLower().Contains(request.Name.ToLower()) 
                                    && f.FarmerId == request.FarmerId)
                                    .OrderBy(f => f.Name).OrderByDescending(f => f.Status).ProjectTo<FarmViewModel>(_mapper)
                                    .PagingIQueryable(page, size, PageConstants.LimitPaging, PageConstants.DefaultPage);
                            return new ModelsResponse<FarmViewModel>
                            {
                                Data = await result.Item2.ToListAsync(),
                            };
                        }
                        else
                        {
                            var result = Get(f => f.Name.ToLower().Contains(request.Name.ToLower())
                                    && f.FarmerId == request.FarmerId && f.AreaId == request.AreaId)
                                    .OrderBy(f => f.Name).OrderByDescending(f => f.Status).ProjectTo<FarmViewModel>(_mapper)
                                    .PagingIQueryable(page, size, PageConstants.LimitPaging, PageConstants.DefaultPage);
                            return new ModelsResponse<FarmViewModel>
                            {
                                Data = await result.Item2.ToListAsync(),
                            };

                        }
                    }
                }
                else
                {
                    if (request.FarmerId == null)
                    {
                        if (request.AreaId == null)
                        {
                            var result = Get(f => f.Name.ToLower().Contains(request.Name.ToLower()) && f.FarmTypeId == request.FarmTypeId)
                                    .OrderBy(f => f.Name).OrderByDescending(f => f.Status).ProjectTo<FarmViewModel>(_mapper)
                                    .PagingIQueryable(page, size, PageConstants.LimitPaging, PageConstants.DefaultPage);
                            return new ModelsResponse<FarmViewModel>
                            {
                                Data = await result.Item2.ToListAsync(),
                            };
                        }
                        else
                        {
                            var result = Get(f => f.Name.ToLower().Contains(request.Name.ToLower()) && f.FarmTypeId == request.FarmTypeId
                                    && f.AreaId == request.AreaId).OrderByDescending(f => f.Status).OrderBy(f => f.Name)
                                    .ProjectTo<FarmViewModel>(_mapper).PagingIQueryable(page, size, PageConstants.LimitPaging, PageConstants.DefaultPage);
                            return new ModelsResponse<FarmViewModel>
                            {
                                Data = await result.Item2.ToListAsync(),
                            };
                        }
                    }
                    else
                    {
                        if (request.AreaId == null)
                        {
                            var result = Get(f => f.Name.ToLower().Contains(request.Name.ToLower()) && f.FarmTypeId == request.FarmTypeId
                                    && f.FarmerId == request.FarmerId).OrderByDescending(f => f.Status).OrderBy(f => f.Name)
                                    .ProjectTo<FarmViewModel>(_mapper).PagingIQueryable(page, size, PageConstants.LimitPaging, PageConstants.DefaultPage);
                            return new ModelsResponse<FarmViewModel>
                            {
                                Data = await result.Item2.ToListAsync(),
                            };
                        }
                        else
                        {
                            var result = Get(f => f.Name.ToLower().Contains(request.Name.ToLower()) && f.FarmTypeId == request.FarmTypeId
                                    && f.FarmerId == request.FarmerId && f.AreaId == request.AreaId)
                                    .OrderBy(f => f.Name).OrderByDescending(f => f.Status).ProjectTo<FarmViewModel>(_mapper)
                                    .PagingIQueryable(page, size, PageConstants.LimitPaging, PageConstants.DefaultPage);
                            return new ModelsResponse<FarmViewModel>
                            {
                                Data = await result.Item2.ToListAsync(),
                            };
                        }
                    }
                }
            }
            else {
                if (request.FarmTypeId == null)
                {
                    if (request.FarmerId == null)
                    {
                        if (request.AreaId == null)
                        {
                            var result = Get(f => f.Name.ToLower().Contains(request.Name.ToLower()) && f.Status == request.Status)
                                    .OrderBy(f => f.Name).OrderByDescending(f => f.Status).ProjectTo<FarmViewModel>(_mapper)
                                    .PagingIQueryable(page, size, PageConstants.LimitPaging, PageConstants.DefaultPage);
                            return new ModelsResponse<FarmViewModel>
                            {
                                Data = await result.Item2.ToListAsync(),
                            };
                        }
                        else
                        {
                            var result = Get(f => f.Name.ToLower().Contains(request.Name.ToLower())
                                     && f.AreaId == request.AreaId && f.Status == request.Status)
                                    .OrderBy(f => f.Name).OrderByDescending(f => f.Status).ProjectTo<FarmViewModel>(_mapper)
                                    .PagingIQueryable(page, size, PageConstants.LimitPaging, PageConstants.DefaultPage);
                            return new ModelsResponse<FarmViewModel>
                            {
                                Data = await result.Item2.ToListAsync(),
                            };
                        }
                    }
                    else
                    {
                        if (request.AreaId == null)
                        {
                            var result = Get(f => f.Name.ToLower().Contains(request.Name.ToLower())
                                    && f.FarmerId == request.FarmerId && f.Status == request.Status)
                                    .OrderBy(f => f.Name).OrderByDescending(f => f.Status).ProjectTo<FarmViewModel>(_mapper)
                                    .PagingIQueryable(page, size, PageConstants.LimitPaging, PageConstants.DefaultPage);
                            return new ModelsResponse<FarmViewModel>
                            {
                                Data = await result.Item2.ToListAsync(),
                            };
                        }
                        else
                        {
                            var result = Get(f => f.Name.ToLower().Contains(request.Name.ToLower())
                                    && f.FarmerId == request.FarmerId && f.AreaId == request.AreaId && f.Status == request.Status)
                                    .OrderBy(f => f.Name).OrderByDescending(f => f.Status).ProjectTo<FarmViewModel>(_mapper)
                                    .PagingIQueryable(page, size, PageConstants.LimitPaging, PageConstants.DefaultPage);
                            return new ModelsResponse<FarmViewModel>
                            {
                                Data = await result.Item2.ToListAsync(),
                            };
                        }
                    }
                }
                else
                {
                        if (request.FarmerId == null)
                        {
                            if (request.AreaId == null)
                            {
                                var result = Get(f => f.Name.ToLower().Contains(request.Name.ToLower()) && f.FarmTypeId == request.FarmTypeId
                                        && f.Status == request.Status)
                                        .OrderBy(f => f.Name).OrderByDescending(f => f.Status).ProjectTo<FarmViewModel>(_mapper)
                                        .PagingIQueryable(page, size, PageConstants.LimitPaging, PageConstants.DefaultPage);
                            return new ModelsResponse<FarmViewModel>
                            {
                                Data = await result.Item2.ToListAsync(), 
                            };
                        }
                            else
                            {
                                var result = Get(f => f.Name.ToLower().Contains(request.Name.ToLower()) && f.FarmTypeId == request.FarmTypeId
                                        && f.AreaId == request.AreaId && f.Status == request.Status)
                                        .OrderBy(f => f.Name).OrderByDescending(f => f.Status).ProjectTo<FarmViewModel>(_mapper)
                                        .PagingIQueryable(page, size, PageConstants.LimitPaging, PageConstants.DefaultPage);
                            return new ModelsResponse<FarmViewModel>
                            {
                                Data = await result.Item2.ToListAsync(),
                            };
                        }
                        }
                        else
                        {
                            if (request.AreaId == null)
                            {
                                var result = Get(f => f.Name.ToLower().Contains(request.Name.ToLower()) && f.FarmTypeId == request.FarmTypeId
                                        && f.FarmerId == request.FarmerId && f.Status == request.Status)
                                        .OrderBy(f => f.Name).OrderByDescending(f => f.Status).ProjectTo<FarmViewModel>(_mapper)
                                        .PagingIQueryable(page, size, PageConstants.LimitPaging, PageConstants.DefaultPage);
                            return new ModelsResponse<FarmViewModel>
                            {
                                Data = await result.Item2.ToListAsync(),
                            };
                        }
                            else
                            {
                                var result = Get(f => f.Name.ToLower().Contains(request.Name.ToLower()) && f.FarmTypeId == request.FarmTypeId
                                        && f.FarmerId == request.FarmerId && f.AreaId == request.AreaId && f.Status == request.Status)
                                        .OrderBy(f => f.Name).OrderByDescending(f => f.Status).ProjectTo<FarmViewModel>(_mapper)
                                        .PagingIQueryable(page, size, PageConstants.LimitPaging, PageConstants.DefaultPage);
                            return new ModelsResponse<FarmViewModel>
                            {
                                Data = await result.Item2.ToListAsync(),
                            };
                        }
                    }
                }
            }
        }

        public async Task<FarmViewModel> GetFarmById(Guid id)
        {
            return await Get(p => p.Id == id ).ProjectTo<FarmViewModel>(_mapper).FirstOrDefaultAsync();
        }
        public async Task<List<FarmViewModel>> GetFarmByType(Guid FarmTypeId)
        {
            return await Get(p => p.FarmTypeId == FarmTypeId).ProjectTo<FarmViewModel>(_mapper).ToListAsync();
        }
        public async Task<List<FarmViewModel>> GetFarmByFarmerId(Guid FarmerId)
        {
            return await Get(p => p.FarmerId == FarmerId).ProjectTo<FarmViewModel>(_mapper).ToListAsync();
        }
        public async Task<List<FarmViewModel>> GetFarmByAreaId(Guid AreaId)
        {
            return await Get(p => p.AreaId == AreaId).ProjectTo<FarmViewModel>(_mapper).ToListAsync();
        }
        public async Task<FarmViewModel> CreateFarm(CreateFarmRequest request)
            {
            var mapper = _mapper.CreateMapper();
            var farm = mapper.Map<Farm>(request);
            farm.Status = (int)Status.NotApprove;
            farm.DateOfCreate = DateTime.UtcNow;
            await CreateAsyn(farm);
            var farmViewModel = mapper.Map<FarmViewModel>(farm);
            return farmViewModel;
        }

        public async Task<FarmViewModel> UpdateFarm(Guid id, UpdateFarmRequest request)
        {
            var mapper = _mapper.CreateMapper();
            var farmInRequest = mapper.Map<Farm>(request);
            var farm = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (farm == null)
            {
                return null;
            }
            farm.FarmTypeId = farmInRequest.FarmTypeId;
            farm.FarmerId = farmInRequest.FarmerId;
            farm.Name = farmInRequest.Name;
            farm.AreaId = farmInRequest.AreaId;
            farm.Address = farmInRequest.Address;
            farm.Description = farmInRequest.Description;
            farm.DateUpdate = DateTime.UtcNow;
            farm.Status = farmInRequest.Status;
            await UpdateAsyn(farm);
            return mapper.Map<FarmViewModel>(farm);
        }

        public async Task<FarmViewModel> UpdateFarmStatus(Guid id, int status)
        {
            var mapper = _mapper.CreateMapper();
            var farm = await Get(p => p.Id == id).FirstOrDefaultAsync();
            if (farm == null)
            {
                return null;
            }
            farm.Status = status;
            await UpdateAsyn(farm);
            return mapper.Map<FarmViewModel>(farm);
        }

        public async Task<int> DeleteFarm(Guid id)
        {
            var farm = await Get(p => p.Id == id).FirstOrDefaultAsync();

            if (farm == null)
            {
                return 0;
            }
            farm.Status = (int)Status.Inactive;
            await UpdateAsyn(farm);

            return 1;
        }
        //public override bool Equals(object obj)
        //{
        //    return obj is FarmerService service &&
        //           EqualityComparer<IConfigurationProvider>.Default.Equals(this._mapper, service._mapper);
        //}
    }
}
