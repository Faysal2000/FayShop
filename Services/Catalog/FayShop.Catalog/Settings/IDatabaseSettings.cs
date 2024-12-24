using MongoDB.Driver;

namespace FayShop.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        

        public string CategoryCollactionName { set; get; }

        public string ProductCollactionName { set; get; }

        public string ProductDetailCollactionName { set; get; }

        public string ProductImageCollectionName { set; get; }

        public string ConnectionString { set; get; }

        public string DatabaseName { set; get; }
        MongoClientSettings ConntectionString { get; }
    }
}
