using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using VuonDau.Business.Requests.Feedback;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.WebApi.Controllers
{
    public partial class FeedbacksController : ControllerBase
    {
        /// <summary>
        /// Get List Customer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/feedbacks")]
        [SwaggerOperation(Tags = new[] { "Feedbacks" })]
        public async Task<IActionResult> GetFeedbacks([FromQuery] SearchFeedbackRequest request)
        {
            var feedbacks = await _feedbackService.GetAllFeedbacks(request);
            return Ok(feedbacks);
        }

        /// <summary>
        /// Get Customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/feedbacks/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Feedbacks" })]
        public async Task<IActionResult> GetFeedback([FromRoute] Guid id)
        {
            var feedback = await _feedbackService.GetFeedbackById(id);
            if (feedback == null)
            {
                await _feedbackService.GetFeedbackByOrderId(id);
                var feedbacks = await _feedbackService.GetFeedbackByOrderId(id);
                if (feedbacks.Count > 0)
                {
                    return Ok(feedbacks);
                }
                else
                {
                    return NotFound("NOT_FOUND_MESSAGE");
                }
            }
            return Ok(feedback);
        }

        /// <summary>
        /// Tạo mới 1 Customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/feedbacks")]
        [SwaggerOperation(Tags = new[] { "Feedbacks" })]
        public async Task<IActionResult> CreateFeedback([FromBody] CreateFeedbackRequest request)
        {
            var feedback = await _feedbackService.CreateFeedback(request);
            if (feedback == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateFeedback), feedback);
        }

        /// <summary>
        /// Cập nhập 1 Customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/feedbacks/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Feedbacks" })]
        public async Task<IActionResult> UpdateFeedback([FromRoute] Guid id, UpdateFeedbackRequest request)
        {
            var feedback = await _feedbackService.UpdateFeedback(id, request);
            if (feedback == null)
            {
                return NotFound("Message");
            }

            return Ok(feedback);
        }

        /// <summary>
        /// Xóa 1 Customer qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/feedbacks/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Feedbacks" })]
        public async Task<IActionResult> DeleteFeedback([FromRoute] Guid id)
        {
            var resultInt = await _feedbackService.DeleteFeedback(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
