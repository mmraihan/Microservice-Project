using Basket.Api.Entities;
using Basket.Api.Models;

namespace Basket.Api.Repositories
{
    public interface IStyleRepository
    {
        Task<Style> GetStyle(string userName);
        Task<Style> UpdateStyle(Style style);
        Task DeleteStyle(string userName);
    }
}
