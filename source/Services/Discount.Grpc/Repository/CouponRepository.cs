using Dapper;
using Discount.Grpc.Models;
using Npgsql;

namespace Discount.Grpc.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly IConfiguration _configuration;
        public CouponRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Coupon> GetDiscount(string productId)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDb"));
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>(
             "SELECT * FROM public.\"Coupon\" WHERE \"ProductId\" = @ProductId",
             new { ProductId = productId });

            if (coupon == null)
            {
                return new Coupon()
                {
                    Amount=0,
                    ProductName="No Discount"
                };
                
            }
            return coupon;
        }
        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDb"));

            var affectedRows = await connection.ExecuteAsync(
               @"INSERT INTO public.""Coupon""(""ProductId"", ""ProductName"", ""Description"", ""Amount"")
                  VALUES (@ProductId, @ProductName, @Description, @Amount)",
               new
               {
                   coupon.ProductId,
                   coupon.ProductName,
                   coupon.Description,
                   coupon.Amount
               });

            if (affectedRows > 0)
            {
                return true;
            }
            return false;
        }

      
        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDb"));

            var affectedRows = await connection.ExecuteAsync(
                 @"UPDATE public.""Coupon"" 
                  SET ""ProductName"" = @ProductName, 
                      ""Description"" = @Description, 
                      ""Amount"" = @Amount
                  WHERE ""id"" = @id",
                 new
                 {
                     coupon.ProductId,
                     coupon.ProductName,
                     coupon.Description,
                     coupon.Amount
                 });

            if (affectedRows > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteDiscount(string productId)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDb"));
            var affected = await connection.ExecuteAsync("DELETE FROM Coupon WHERE ProductId=@ProductId", new { ProductId = productId });
            if (affected > 0)
            {
                return true;
            }
            return false;
        }
    }
}
