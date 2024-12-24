namespace FayShop.Catalog.Settings
{
    public class DatabaseSettings:IDatabaseSettings
    {
        public string CategoryCollactionName { set; get; }

        public string ProductCollactionName { set; get; }

        public string ProductDetailCollactionName { set; get; }

        public string ProductImageCollectionName { set; get; }

        public string ConnectionString { set; get; }

        public string DatabaseName { set; get; }
    }
}
