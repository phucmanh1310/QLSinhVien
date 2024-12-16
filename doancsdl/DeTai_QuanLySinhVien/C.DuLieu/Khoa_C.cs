using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using D.ThongTin;

namespace C.DuLieu
{
    public class Khoa_C
    {
        private IMongoCollection<BsonDocument> collection;

        public Khoa_C()
        {
            // Kết nối MongoDB
            var connectionString = System.Configuration.ConfigurationManager.AppSettings["MongoDBConnectionString"];
            var databaseName = System.Configuration.ConfigurationManager.AppSettings["MongoDBDatabaseName"];

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            // Kết nối tới collection "Khoa"
            collection = database.GetCollection<BsonDocument>("Khoa");
        }

        // Lấy danh sách khoa
        public List<BsonDocument> DanhSachKhoa()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        // Xóa khoa
        public void XoaKhoa(Khoa_ThongTin K)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaKhoa", K.MaKhoa);
            collection.DeleteOne(filter);
        }

        // Thêm khoa
        public void ThemKhoa(Khoa_ThongTin K)
        {
            var document = new BsonDocument
            {
                { "MaKhoa", K.MaKhoa },
                { "TenKhoa", K.TenKhoa }
            };
            collection.InsertOne(document);
        }

        // Sửa khoa
        public void SuaKhoa(Khoa_ThongTin K)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaKhoa", K.MaKhoa);
            var update = Builders<BsonDocument>.Update.Set("TenKhoa", K.TenKhoa);
            collection.UpdateOne(filter, update);
        }

        // Tìm kiếm khoa
        public List<BsonDocument> TimKiemKhoa(Khoa_ThongTin K)
        {
            var filter = Builders<BsonDocument>.Filter.Regex("MaKhoa", new BsonRegularExpression(K.MaKhoa, "i"));
            return collection.Find(filter).ToList();
        }
    }
}
