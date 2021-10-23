using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Reso.Core.BaseConnect;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VuonDau.Business.Requests;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Common.Constants;
using VuonDau.Data.Repositories;

namespace VuonDau.Business.Services
{
    public partial interface IAdminService
    {
        Task<string> Login(AdminLoginRequest loginRequest, IConfiguration configuration);
    }


    public partial class AdminService
    {
        private readonly AutoMapper.IConfigurationProvider _mapper;

        public AdminService(IUnitOfWork unitOfWork, IAdminRepository repository, IMapper mapper) : base(unitOfWork,
            repository)
        {
            _mapper = mapper.ConfigurationProvider;
        }

        public async Task<string> Login(AdminLoginRequest loginRequest, IConfiguration configuration)
        {
            string username = loginRequest.Username;
            string password = loginRequest.Password;

            var adminResult = await Get(adminTemp => (adminTemp.UserName.Equals(username) && adminTemp.Password.Equals(password))).ProjectTo<AdminViewModel>(_mapper).FirstOrDefaultAsync();
            if (adminResult == null) throw new ErrorResponse((int)HttpStatusCode.Forbidden, "Wrong username or password");

            string token = TokenService.GenerateAdminJWTWebToken(adminResult, configuration);

            return await Task.Run(() => token);
        }
    }
}
