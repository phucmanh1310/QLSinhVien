using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Configuration;

namespace C.DuLieu
{
    class KetNoi_CSDL
    {
        private static MongoClient _client;
        private static IMongoDatabase _database;

        public KetNoi_CSDL()
        {
            // Lấy chuỗi kết nối từ app.config
            string connectionString = ConfigurationManager.AppSettings["MongoDBConnectionString"];
            string databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];

            // Kết nối MongoDB
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(databaseName);
        }

        // Phương thức lấy dữ liệu từ collection
        public List<BsonDocument> LayDuLieu(string collectionName, FilterDefinition<BsonDocument> filter = null)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            return collection.Find(filter ?? FilterDefinition<BsonDocument>.Empty).ToList();
        }

        // Phương thức thêm dữ liệu vào collection
        public void ThemDuLieu(string collectionName, BsonDocument document)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.InsertOne(document);
        }

        // Phương thức cập nhật dữ liệu
        public void CapNhatDuLieu(string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.UpdateOne(filter, update);
        }

        // Phương thức xóa dữ liệu
        public void XoaDuLieu(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.DeleteOne(filter);
        }
    }
}
