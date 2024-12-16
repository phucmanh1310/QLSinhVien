using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using D.ThongTin;

namespace C.DuLieu
{
    public class MonHoc_C
    {
        private IMongoCollection<BsonDocument> collection;

        public MonHoc_C()
        {
            // Kết nối MongoDB
            var connectionString = System.Configuration.ConfigurationManager.AppSettings["MongoDBConnectionString"];
            var databaseName = System.Configuration.ConfigurationManager.AppSettings["MongoDBDatabaseName"];

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            // Kết nối tới collection "MonHoc"
            collection = database.GetCollection<BsonDocument>("MonHoc");
        }

        // Lấy danh sách môn học
        public List<BsonDocument> DanhSachMonHoc()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        // Tìm kiếm môn học theo tên
        public List<BsonDocument> TimKiemMonHoc(MonHoc_ThongTin MH)
        {
            var filter = Builders<BsonDocument>.Filter.Regex("TenMonHoc", new BsonRegularExpression(MH.TenMonHoc, "i"));
            return collection.Find(filter).ToList();
        }

        // Lấy danh sách môn học toàn trường
        public List<BsonDocument> DanhSachMonHocToanTruong()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        // Xóa môn học
        public void XoaMonHoc(MonHoc_ThongTin MH)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaMonHoc", MH.MaMonHoc);
            collection.DeleteOne(filter);
        }

        // Thêm môn học
        public void ThemMonHoc(MonHoc_ThongTin MH)
        {
            var document = new BsonDocument
            {
                { "MaMonHoc", MH.MaMonHoc },
                { "TenMonHoc", MH.TenMonHoc },
                { "SoTinChi", MH.SoTinChi }
            };
            collection.InsertOne(document);
        }

        // Sửa môn học
        public void SuaMonHoc(MonHoc_ThongTin MH)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaMonHoc", MH.MaMonHoc);
            var update = Builders<BsonDocument>.Update
                .Set("TenMonHoc", MH.TenMonHoc)
                .Set("SoTinChi", MH.SoTinChi);
            collection.UpdateOne(filter, update);
        }

        // Tìm kiếm môn học tất tần tật
        public List<BsonDocument> TimMonHoc(MonHoc_ThongTin MH)
        {
            var filter = Builders<BsonDocument>.Filter.Regex("MaMonHoc", new BsonRegularExpression(MH.MaMonHoc, "i"));
            return collection.Find(filter).ToList();
        }
    }
}
