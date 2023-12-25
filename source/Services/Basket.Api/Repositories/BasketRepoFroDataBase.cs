using Basket.Api.Context;
using Basket.Api.Models;

namespace Basket.Api.Repositories
{
    public class BasketRepoFroDataBase : IBasketRepository
    {
        private readonly BasketDbContext _context;
        public BasketRepoFroDataBase(BasketDbContext context)
        {
            _context = context;
        }
        public Task DeleteBasket(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> GetBasket(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            throw new NotImplementedException();
        }
    }
}
