using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VuonDau.Business.Requests;

namespace VuonDau.WebApi.Controllers
{
    public partial class AdminsController : ControllerBase
    {
        [HttpPost]
        [Route("~/api/v1/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            string token = await _adminService.Login(request, _configuration);

            return await Task.Run(() => Ok(token));
        }
    }
}
