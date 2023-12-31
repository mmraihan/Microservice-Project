namespace Basket.Api.Entities
{
    public class Style
    {
        public Style()
        {
            
        }

        public Style(string userName)
        {

            UserName = userName;

        }
        public int Id { get; set; }
        public string StyleName { get; set; }
        public string UserName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
