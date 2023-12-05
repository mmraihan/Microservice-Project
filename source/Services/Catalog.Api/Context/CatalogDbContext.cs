using MongoRepo.Context;

namespace Catalog.Api.Context
{
    public class CatalogDbContext : ApplicationDbContext
    {
        //Get Data from the appsetting.json

        static IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
        //static string connectionString = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional:true,reloadOnChange:true).Build().GetConnectionString("Catalog.API");
        static string connectionString = configuration.GetConnectionString("Catalog.Api");
        static string databaseName = configuration.GetValue<string>("DatabaseName");
        public CatalogDbContext() : base(connectionString, databaseName)
        {
        }
    }
}
