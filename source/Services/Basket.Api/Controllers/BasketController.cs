using Basket.Api.GrpcServices;
using Basket.Api.Models;
using Basket.Api.Repositories;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : BaseController
    {
        private readonly IBasketRepository _basketRepository;
        DiscountGrpcService _discountGrpcService;
        public BasketController(IBasketRepository basketRepository, DiscountGrpcService discountGrpcService)
        {
            _basketRepository = basketRepository;
            _discountGrpcService = discountGrpcService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBasket(string userName)
        {
            try
            {
                var basket = await _basketRepository.GetBasket(userName);
                return CustomResult("Data loaded successfully", basket);
            }

            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBasket([FromBody] ShoppingCart basket)
        {

            #region Todo

            //Todo: Commmunicate discount.grpc
            //Calculate latest price
            //Create discount grpc service

            #endregion

            try
            {
                foreach (var item in basket.Items)
                {
                    var coupon = await _discountGrpcService.GetDiscount(item.ProductId);
                    item.Price -= coupon.Amount;

                }
                var updatedBasket = await _basketRepository.UpdateBasket(basket);
                return CustomResult("Data updated successfully", updatedBasket);
            }

            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }


        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            try
            {
                await _basketRepository.DeleteBasket(userName);
                return CustomResult("Data deleted successfully");
            }

            catch (Exception ex)
            {

                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
