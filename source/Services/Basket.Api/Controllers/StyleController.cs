using Basket.Api.Entities;
using Basket.Api.Repositories;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StyleController : BaseController
    {
        private readonly IStyleRepository _styleRepository;
        public StyleController(IStyleRepository styleRepository)
        {
            _styleRepository = styleRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Style), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateStyle([FromBody] Style style)
        {
            try
            {
                var updatedStyle = await _styleRepository.UpdateStyle(style);
                return CustomResult("Data updated successfully", updatedStyle);
            }

            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(Style),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetStyle(string userName)
        {
            try
            {
                var style = await _styleRepository.GetStyle(userName);
                return CustomResult("Data loaded successfully", style);
            }

            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        

        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteStyle(string userName)
        {
            try
            {
                await _styleRepository.DeleteStyle(userName);
                return CustomResult("Data deleted successfully");
            }

            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
