using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Common.Constants;
using VuonDau.Data.Repositories;

namespace VuonDau.Business.Services
{
    public static class TokenService
    {
        private static string secretKey;
        private static IStringLocalizer<VuonDau.Data.Resources.Resource> _localize;

        private static void setPrivateKey(IConfiguration configuration)
        {
            secretKey = configuration.GetSection("Security:SecretKey").Value;
        }

        public static string GenerateCustomerJWTWebToken(CustomerViewModel customViewModel, IConfiguration configuration) 
        {
            setPrivateKey(configuration);

            var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(secretKey));

            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(credential);

            var payload = new JwtPayload
            {
               { "ID", customViewModel.Id.ToString()},
               { "Email", customViewModel.Email.ToString()},
               { "FULLNAME", customViewModel.FullName.ToString()},
               { "ROLE", ((int)RoleEnum.Customer).ToString()},
               { "STATUS", customViewModel.Status.ToString()}
            };

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(secToken);
        }

        public static string GenerateFarmerJWTWebToken(FarmerViewModel farmerViewModel, IConfiguration configuration) 
        {
            setPrivateKey(configuration);

            var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(secretKey));

            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var header = new JwtHeader(credential);

            var payload = new JwtPayload
            {
               { "ID", farmerViewModel.Id.ToString()},
               { "Email", farmerViewModel.Email.ToString()},
               { "FULLNAME", farmerViewModel.FullName.ToString()},
               { "ROLE", ((int)RoleEnum.Farmer).ToString()},
               { "STATUS", farmerViewModel.Status.ToString()}
            };

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(secToken);
        }

        public static string GenerateAdminJWTWebToken(AdminViewModel adminViewModel, IConfiguration configuration) // Admin
        {
            setPrivateKey(configuration);

            var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(secretKey));

            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var header = new JwtHeader(credential);

            var payload = new JwtPayload
            {
               { "ID", adminViewModel.Id.ToString()},
               { "Email", adminViewModel.UserName.ToString()},
               { "ROLE", ((int)RoleEnum.Admin).ToString()},
               { "STATUS", adminViewModel.Status.ToString()}
            };

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(secToken);
        }
        public static string GenerateNotExistJWTWebToken(IConfiguration configuration)
        {
            setPrivateKey(configuration);

            var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(secretKey));

            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var header = new JwtHeader(credential);

            var payload = new JwtPayload
            {
               { "ROLE", ((int)RoleEnum.NotExist).ToString()}
            };

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(secToken);
        }
        //public static string GenerateNotExistJWTWebToken(IConfiguration configuration)
        //{
        //    setPrivateKey(configuration);

        //    var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(secretKey));

        //    var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        //    var header = new JwtHeader(credential);

        //    var payload = new JwtPayload
        //    {
        //       { "ROLE", ((int)RoleEnum.NotExist).ToString()}
        //    };

        //    var secToken = new JwtSecurityToken(header, payload);
        //    var handler = new JwtSecurityTokenHandler();

        //    return handler.WriteToken(secToken);
        //}
        public static TokenViewModel ReadJWTTokenToModel(string token, IConfiguration configuration)
        {
            setPrivateKey(configuration);

            bool isValid = IsTokenValid(token);

            if (!isValid)
            {
                throw new MyHttpException(StatusCodes.Status400BadRequest, _localize["Bad Request"]);
            }

            var result = new JwtSecurityTokenHandler().ReadJwtToken(token);

            Guid id = Guid.Parse(result.Claims.First(claim => claim.Type == PayloadKeyConstants.ID).Value);
            string email = result.Claims.First(claim => claim.Type == PayloadKeyConstants.EMAIL).Value;
            string firstName = result.Claims.First(claim => claim.Type == PayloadKeyConstants.FULLNAME).Value;
            int role = int.Parse(result.Claims.First(claim => claim.Type == PayloadKeyConstants.ROLE).Value);
            int status = int.Parse(result.Claims.First(claim => claim.Type == PayloadKeyConstants.STATUS).Value);
            return new TokenViewModel(id, email, firstName, role, status);
        }

        private static SecurityKey GetSymmetricSecurityKey()
        {
            byte[] symmetricKey = Convert.FromBase64String(secretKey);
            return new SymmetricSecurityKey(symmetricKey);
        }

        private static TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = GetSymmetricSecurityKey(),
                ValidateLifetime = false
            };
        }

        private static bool IsTokenValid(string token)
        {
            try
            {
                ClaimsPrincipal tokenValid = new JwtSecurityTokenHandler().ValidateToken(token, GetTokenValidationParameters(), out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
