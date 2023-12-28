using Basket.Api.Data;
using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Api.Repositories
{
    public class StyleRepository : IStyleRepository
    {
        private readonly IDistributedCache _redisCache;

        private readonly TestDbContext _dbContext;
        private int _currentId;
        public StyleRepository(IDistributedCache redisCache, TestDbContext dbContext)
        {
            _redisCache = redisCache;
            _dbContext = dbContext;
            // Retrieve the last used ID from the database during initialization
            _currentId = _dbContext.Styles.Any() ? _dbContext.Styles.Max(s => s.Id) : 0;
        }

        public async Task<Style> GetStyle(string userName)
        {
            var style = await _redisCache.GetStringAsync(userName);

            if (string.IsNullOrEmpty(style))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Style>(style); //string to object
        }

        public async Task<Style> UpdateStyle(Style style)
        {
            
            _currentId++;
            style.Id = _currentId;

            
            await _redisCache.SetStringAsync(style.UserName, JsonConvert.SerializeObject(style));

        
            _dbContext.Styles.Add(style); 
            await _dbContext.SaveChangesAsync();

            return await GetStyle(style.UserName);
        }

        public async Task DeleteStyle(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

    }
}
