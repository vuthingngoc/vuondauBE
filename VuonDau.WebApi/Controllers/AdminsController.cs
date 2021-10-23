using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests;
using VuonDau.Business.Requests.CustomerGroup;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class AdminsController : ControllerBase
    {

        [HttpPost]
        [Route("~/api/v1/admin")]
        public async Task<IActionResult> Login([FromBody] AdminLoginRequest request)
        {
            string token = await _adminService.Login(request, _configuration);

            return await Task.Run(() => Ok(token));
        }
    }
}
