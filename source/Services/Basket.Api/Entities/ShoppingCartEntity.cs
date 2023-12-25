namespace Basket.Api.Entities
{
    public class ShoppingCartEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<CartItemEntity> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
