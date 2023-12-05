using Catalog.Api.Context;
using Catalog.Api.Interfaces.Repository;
using Catalog.Api.Models;
using MongoRepo.Repository;

namespace Catalog.Api.Repository
{
    public class ProductRepository : CommonRepository<Product>, IProductRepository
    {
        public ProductRepository() : base(new CatalogDbContext())
        {
        }
    }
}
