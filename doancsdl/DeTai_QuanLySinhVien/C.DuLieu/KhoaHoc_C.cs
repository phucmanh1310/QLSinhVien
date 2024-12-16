using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using D.ThongTin;

namespace C.DuLieu
{
    public class KhoaHoc_C
    {
        private IMongoCollection<BsonDocument> collection;

        public KhoaHoc_C()
        {
            // Kết nối MongoDB
            var connectionString = System.Configuration.ConfigurationManager.AppSettings["MongoDBConnectionString"];
            var databaseName = System.Configuration.ConfigurationManager.AppSettings["MongoDBDatabaseName"];

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            // Kết nối tới collection "KhoaHoc"
            collection = database.GetCollection<BsonDocument>("KhoaHoc");
        }

        // Lấy danh sách khóa học
        public List<BsonDocument> DanhSachKhoaHoc()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        // Lấy danh sách thông tin đầy đủ khóa học
        public List<BsonDocument> DanhSach_ThongTin_KhoaHoc()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        // Thêm khóa học
        public void ThemKhoaHoc(KhoaHoc_ThongTin KH)
        {
            var document = new BsonDocument
            {
                { "MaKhoaHoc", KH.MaKhoaHoc },
                { "NgayBatDau", KH.NgayBatDau },
                { "NgayKetThuc", KH.NgayKetThuc }
            };
            collection.InsertOne(document);
        }

        // Chỉnh sửa khóa học
        public void ChinhSuaKhoaHoc(KhoaHoc_ThongTin KH)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaKhoaHoc", KH.MaKhoaHoc);
            var update = Builders<BsonDocument>.Update
                .Set("NgayBatDau", KH.NgayBatDau)
                .Set("NgayKetThuc", KH.NgayKetThuc);
            collection.UpdateOne(filter, update);
        }

        // Xóa khóa học
        public void XoaKhoaHoc(KhoaHoc_ThongTin KH)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaKhoaHoc", KH.MaKhoaHoc);
            collection.DeleteOne(filter);
        }

        // Tìm kiếm khóa học
        public List<BsonDocument> TimKiemKhoaHoc(KhoaHoc_ThongTin KH)
        {
            var filter = Builders<BsonDocument>.Filter.Regex("MaKhoaHoc", new BsonRegularExpression(KH.MaKhoaHoc, "i"));
            return collection.Find(filter).ToList();
        }
    }
}
