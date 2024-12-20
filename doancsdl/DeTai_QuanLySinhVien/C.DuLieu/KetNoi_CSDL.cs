using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

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

        // Định nghĩa hàm LayDuLieu trong lớp KetNoi_CSDL
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
        public DataTable TimKiem(string collectionName, string[] name, object[] value, int Nparameter)
        {
            // Tạo bộ lọc cho MongoDB
            var filterBuilder = Builders<BsonDocument>.Filter;
            var filters = new List<FilterDefinition<BsonDocument>>();

            for (int i = 0; i < Nparameter; i++)
            {
                filters.Add(filterBuilder.Eq(name[i], value[i]));
            }

            // Kết hợp tất cả các bộ lọc bằng toán tử AND
            var filter = filterBuilder.And(filters);

            // Truy vấn dữ liệu từ MongoDB
            var documents = LayDuLieu(collectionName, filter);

            // Chuyển đổi kết quả sang DataTable
            return DataConversion1.ConvertToDataTable1(documents);
        }

        // Phương thức xóa dữ liệu
        public void XoaDuLieu(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.DeleteOne(filter);
        }
    }
}
