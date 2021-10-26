//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using FirebaseAdmin.Auth;
//using Microsoft.Extensions.Configuration;
//using Reso.Core.BaseConnect;
//using VuonDau.Business.Requests;
//using VuonDau.Business.ViewModel;
//using VuonDau.Data.Common.Constants;

//namespace VuonDau.Business.Services
//{
//    public partial interface ILoginService
//    {
//        Task<string> Login(LoginRequest loginRequest, IConfiguration configuration);
//    }
//    public partial class LoginService
//    {
//        private readonly ICustomerService _customerService;
//        private readonly IFarmerService _farmerService;
//        private readonly IAdminService _adminService;
//        public LoginService(IUnitOfWork unitOfWork, ICustomerService customerService, IFarmerService farmerService, IAdminService adminService) : base(unitOfWork,
//            repository)
//        {
//            _customerService = customerService;
//            _farmerService = farmerService;
//            _adminService = adminService;
//        }
//        public async Task<string> Login(LoginRequest loginRequest, IConfiguration configuration)
//        {
//            FirebaseToken token = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(loginRequest.AccessToken); // re-check access token with firebase
//            object email;
//            token.Claims.TryGetValue("email", out email); // get email from the above re-check step, then check the email whether it's matched the request email
//            var result1 = await _customerService.GetByMail(email.ToString());
//            if (result1 == null)
//            {
//                var result2 = await _farmerService.GetByMail(email.ToString());
//                if (result2 == null)
//                {
//                    var result3 = await _adminService.GetByMail(email.ToString());
//                    if (result3 != null)
//                    {
//                        string verifyRequestToken = TokenService.GenerateAdminJWTWebToken(result3, configuration);
//                        return await Task.Run(() => verifyRequestToken); // return if everything is done
//                    }
//                    throw new ErrorResponse((int)ResponseStatusConstants.CREATED, "Email's not existed in database yet.");
//                }
//                else
//                {
//                    string verifyRequestToken = TokenService.GenerateFarmerJWTWebToken(result2, configuration);
//                    return await Task.Run(() => verifyRequestToken); // return if everything is done
//                }
//            }
//            else
//            {
//                string verifyRequestToken = TokenService.GenerateCustomerJWTWebToken(result1, configuration);
//                return await Task.Run(() => verifyRequestToken); // return if everything is done
//            }
//        }
//    }
//}
