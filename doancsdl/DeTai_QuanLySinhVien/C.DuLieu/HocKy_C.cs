using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using D.ThongTin;
using System;

namespace C.DuLieu
{
    public class HocKy_C
    {
        private IMongoCollection<BsonDocument> collection;

        public HocKy_C()
        {
            try
            {
                var connectionString = System.Configuration.ConfigurationManager.AppSettings["MongoDBConnectionString"];
                var databaseName = System.Configuration.ConfigurationManager.AppSettings["MongoDBDatabaseName"];

                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);

                collection = database.GetCollection<BsonDocument>("HocKy");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kết nối MongoDB: " + ex.Message);
            }
        }


        // Lấy danh sách học kỳ
        public List<BsonDocument> DanhSachHocKy()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        // Lấy danh sách thông tin đầy đủ về học kỳ
        public List<BsonDocument> DanhSachThongTinHocKy()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

       

        // Thêm một học kỳ
        public void ThemHocKy(HocKy_ThongTin HK)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaHocKy", HK.MaHocKy);
            var existing = collection.Find(filter).FirstOrDefault();

            if (existing == null) // Chỉ thêm nếu không tồn tại
            {
                var document = new BsonDocument
        {
            { "MaHocKy", HK.MaHocKy },
            { "TenHocKy", HK.TenHocKy }
        };
                collection.InsertOne(document);
            }
            else
            {
                throw new Exception("Mã học kỳ đã tồn tại!");
            }
        }


        public void SuaHocKy(HocKy_ThongTin HK)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaHocKy", HK.MaHocKy);
            var update = Builders<BsonDocument>.Update.Set("TenHocKy", HK.TenHocKy);
            var result = collection.UpdateOne(filter, update);

            if (result.MatchedCount == 0)
                throw new Exception("Không tìm thấy mã học kỳ để cập nhật.");
        }

        public void XoaHocKy(HocKy_ThongTin HK)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaHocKy", HK.MaHocKy);
            var result = collection.DeleteOne(filter);

            if (result.DeletedCount == 0)
                throw new Exception("Không tìm thấy mã học kỳ để xóa.");
        }

        // Tìm kiếm học kỳ
        public List<BsonDocument> TimKiemHocKy(HocKy_ThongTin HK)
        {
            var filter = Builders<BsonDocument>.Filter.Regex("MaHocKy", new BsonRegularExpression(HK.MaHocKy ?? "", "i"));
            return collection.Find(filter).ToList();
        }
    }
}
