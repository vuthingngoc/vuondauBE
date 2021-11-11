using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VuonDau.Business.Requests;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Common.Constants;

namespace VuonDau.WebApi.Controllers
{
    public partial class AdminsController : ControllerBase
    {
        [HttpPost]
        [Route("~/api/v1/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            string token;
            try {
                token = await _adminService.Login(request, _configuration);
            }
            catch (MyHttpException e){
                return Ok(new BaseResponse<string>
                {
                    Code = e.Error.Code,
                    Msg = _localize["Internal Server Error"]
                });
            }
            return Ok(new BaseResponse<string>
            {
                Code = StatusCodes.Status200OK,
                Data = token,
                Msg = _localize["OK"]
            }) ;
        }
    }
}
