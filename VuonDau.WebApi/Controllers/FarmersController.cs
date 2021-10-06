﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests;
using VuonDau.Business.Gens.Services;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    [ApiController]
    public partial class FarmersController : ControllerBase
    {
        private readonly IFarmerService _farmerService;
        private readonly IConfigurationProvider _mapper;
        public FarmersController(IFarmerService farmerService, IMapper mapper)
        {
            _farmerService = farmerService;
            _mapper = mapper.ConfigurationProvider;
        }
        /// <summary>
        /// Get List Farmers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/farmers")]
        [SwaggerOperation(Tags = new[] { "Farmers" })]
        public async Task<IActionResult> GetFarmers()
        {
            await _farmerService.GetAllFarmers();
            var farmers = await _farmerService.GetAllFarmers();
            return Ok(farmers);
        }

        /// <summary>
        /// Get Farmer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/farmers/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Farmers" })]
        public async Task<IActionResult> GetFarmer([FromRoute] int id)
        {
            var farmer = await _farmerService.GetFarmerById(id);
            if (farmer == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }

            return Ok(farmer);
        }

        /// <summary>
        /// Tạo mới 1 farmer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/farmers")]
        [SwaggerOperation(Tags = new[] { "Farmers" })]
        public async Task<IActionResult> CreateFarmer([FromBody] CreateFarmerRequest request)
        {
            var farmer = await _farmerService.CreateFarmer(request);
            if (farmer == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateFarmer), farmer);
        }

        /// <summary>
        /// Cập nhập 1 farmer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/farmers/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Farmers" })]
        public async Task<IActionResult> UpdateFarmer([FromRoute] int id, UpdateFarmerRequest request)
        {
            var farmer = await _farmerService.UpdateFarmer(id, request);
            if (farmer == null)
            {
                return NotFound("Message");
            }

            return Ok(farmer);
        }

        /// <summary>
        /// Xóa 1 farmer qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/farmers/{id:int}")]
        [SwaggerOperation(Tags = new[] { "Farmers" })]
        public async Task<IActionResult> DeleteFarmer([FromRoute] int id)
        {
            var resultInt = await _farmerService.DeleteFarmer(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
