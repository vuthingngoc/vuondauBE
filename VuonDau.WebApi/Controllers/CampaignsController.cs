using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests;
using VuonDau.Business.Requests.Campaign;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class CampaignsController : ControllerBase
    {

        /// <summary>
        /// Get List Campaign
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/campaigns")]
        [SwaggerOperation(Tags = new[] { "Campaigns" })]
        public async Task<IActionResult> GetCampaigns([FromQuery] CampaignViewModel filter)
        {
            var campaigns = await _campaignService.GetAllCampaigns(filter);
            return Ok(campaigns);
        }
        /// <summary>
        /// Get Campaign by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/campaigns/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Campaigns" })]
        public async Task<IActionResult> GetCampaign([FromRoute] Guid id)
        {
            var campaign = await _campaignService.GetCampaignById(id);
            if (campaign == null)
            {
                await _campaignService.GetCampaignByHarvestSellingId(id);
                var campaigns = await _campaignService.GetCampaignByHarvestSellingId(id);
                if (campaigns.Count > 0)
                {
                    return Ok(campaigns);
                }
                else
                {
                    await _campaignService.GetCampaignByOrderId(id);
                    campaigns = await _campaignService.GetCampaignByOrderId(id);
                    if (campaigns.Count > 0)
                    {
                        return Ok(campaigns);
                    }
                    else
                    {
                        return NotFound("NOT_FOUND_MESSAGE");
                    }
                }
            }

            return Ok(campaign);
        }


        ///// <summary>
        ///// Get Campaign by id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("~/api/v1/campaigns/{id:Guid}")]
        //[SwaggerOperation(Tags = new[] { "Campaigns" })]
        //public async Task<IActionResult> GetCampaign([FromRoute] Guid id)
        //{
        //    var campaign = await _campaignService.GetCampaignById(id);
        //    if (campaign == null)
        //    {
        //        return NotFound("NOT_FOUND_MESSAGE");
        //    }

        //    return Ok(campaign);
        //}

        /// <summary>
        /// Tạo mới 1 Campaign
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/campaigns")]
        [SwaggerOperation(Tags = new[] { "Campaigns" })]
        public async Task<IActionResult> CreateCampaign([FromBody] CreateCampaignRequest request)
        {
            var campaign = await _campaignService.CreateCampaign(request);
            if (campaign == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateCampaign), campaign);
        }

        /// <summary>
        /// Cập nhập 1 Campaign
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/campaigns/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Campaigns" })]
        public async Task<IActionResult> UpdateCampaign([FromRoute] Guid id, UpdateCampaignRequest request)
        {
            var campaign = await _campaignService.UpdateCampaign(id, request);
            if (campaign == null)
            {
                return NotFound("Message");
            }

            return Ok(campaign);
        }

        /// <summary>
        /// Xóa 1 Campaign qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/campaigns/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Campaigns" })]
        public async Task<IActionResult> DeleteCampaign([FromRoute] Guid id)
        {
            var resultInt = await _campaignService.DeleteCampaign(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
