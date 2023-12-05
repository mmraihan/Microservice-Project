using Catalog.Api.Manager;
using Catalog.Api.Models;

namespace Catalog.Api.Context
{
    public class CatalogDbContextSeed
    {
        static ProductManager _productManager = new ProductManager();

        public static void Seed()
        {
            var product = _productManager.GetFirstOrDefault(c => true);
            if (product == null)
            {
                _productManager.Add(GetPreconfiguredProducts());
            }
        }

        private static List<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "IPhone 11",
                    Summary = "Total by Verizon iPhone 11, 64GB, Black - Prepaid Smartphone (Locked).",
                    Description = "Take it to 11. Capture amazing photos and videos with the Apple iPhone 11",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Samsung 10",
                    Summary = "Samsung Galaxy S10, 5G, Verizon, 256GB - Majestic Black",
                    Description = "Connect with 5G. Stream movies, play games, and wirelessly cast in 4k resolution.",
                    ImageFile = "product-2.png",
                    Price = 840.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Lenovo IdeaPad Slim",
                    Summary = "Lenovo IdeaPad Slim 3i 15ITL Intel Core i3 1005G1 4GB Ram 256GB SSD 15.6 Inch FHD Display Platinum Grey Laptop.",
                    Description = "Laptop Brand - Lenovo, Laptop Series - IdeaPad, Laptop Model - Lenovo IdeaPad Slim 3i 15IIL, Processor Brand - Intel",
                    ImageFile = "product-3.png",
                    Price = 650.00M,
                    Category = "Laptop"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Name = "Xiaomi Mi 9",
                    Summary = "Xiaomi Mi 9 SE Cell Phone Snapdragon 712 Android Fingerprint Global Version Original Smartphone.",
                    Description = "The sources of all brand products sold in this store include: brand counter display machines",
                    ImageFile = "product-4.png",
                    Price = 470.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "Hp Laptop",
                    Summary = "15.6 PA156 Laptop Computer Win10 Intel N5095 16G 128G/256G/512G Notebook Netbook Backlit Keyboard WIFI HD BT4.0 USB3.0 3.0MP.",
                    Description = "CPU: Intel 8 generation celeron J4125 GPU: Intel Core graphics card 500 Memory: 12GB + 128GB / 256GB /512GB/1TB OS",
                    ImageFile = "product-5.png",
                    Price = 380.00M,
                    Category = "Laptop"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47fa",
                    Name = "DELL Inspiron 7510",
                    Summary = "Vinyl Stickers for DELL Inspiron 7510 7501 7610 7620 5510 Solid Laptop Skin for DELL Inspiron 7420 5310 5418 Decal Film.",
                    Description = "The effect picture shows only one model. Please place an order according to your specific model, not just the picture",
                    ImageFile = "product-6.png",
                    Price = 240.00M,
                    Category = "Laptop"
                }
            };
        }
    }
}
