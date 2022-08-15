namespace WebApiOnAzure.Models
{
    public class ITShopDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ShopsCollectionName { get; set; } = null!;
    }
}
