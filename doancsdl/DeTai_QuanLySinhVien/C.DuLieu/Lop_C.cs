using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using D.ThongTin;

namespace C.DuLieu
{
    public class Lop_C
    {
        private IMongoCollection<BsonDocument> collection;

        public Lop_C()
        {
            // Kết nối MongoDB
            var connectionString = System.Configuration.ConfigurationManager.AppSettings["MongoDBConnectionString"];
            var databaseName = System.Configuration.ConfigurationManager.AppSettings["MongoDBDatabaseName"];

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            // Kết nối tới collection "Lop"
            collection = database.GetCollection<BsonDocument>("Lop");
        }

        // Lấy danh sách lớp học
        public List<BsonDocument> DanhSachLop()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        // Lấy danh sách thông tin đầy đủ lớp học
        public List<BsonDocument> DanhSach_ThongTin_Lop()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        // Thêm lớp học mới
        public void ThemLopHocMoi(Lop_ThongTin Lop)
        {
            var document = new BsonDocument
            {
                { "MaLop", Lop.MaLop },
                { "TenLop", Lop.TenLop },
                { "MaKhoaHoc", Lop.MaKhoaHoc },
                { "MaHeDaoTao", Lop.MaHeDaoTao },
                { "MaNganh", Lop.MaNganh }
            };
            collection.InsertOne(document);
        }

        // Sửa thông tin lớp học
        public void SuaThongTinLopHoc(Lop_ThongTin Lop)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaLop", Lop.MaLop);
            var update = Builders<BsonDocument>.Update
                .Set("TenLop", Lop.TenLop)
                .Set("MaKhoaHoc", Lop.MaKhoaHoc)
                .Set("MaHeDaoTao", Lop.MaHeDaoTao)
                .Set("MaNganh", Lop.MaNganh);
            collection.UpdateOne(filter, update);
        }

        // Xóa lớp học
        public void XoaLopHoc(Lop_ThongTin Lop)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaLop", Lop.MaLop);
            collection.DeleteOne(filter);
        }

        // Tìm kiếm lớp học
        public List<BsonDocument> TimKiemLopHoc(Lop_ThongTin Lop)
        {
            var filter = Builders<BsonDocument>.Filter.Regex("MaLop", new BsonRegularExpression(Lop.MaLop, "i"));
            return collection.Find(filter).ToList();
        }
    }
}
