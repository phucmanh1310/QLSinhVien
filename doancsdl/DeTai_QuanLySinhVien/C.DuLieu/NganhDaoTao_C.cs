using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using D.ThongTin;

namespace C.DuLieu
{
    public class NganhDaoTao_C
    {
        private IMongoCollection<BsonDocument> collection;

        public NganhDaoTao_C()
        {
            // Kết nối MongoDB
            var connectionString = System.Configuration.ConfigurationManager.AppSettings["MongoDBConnectionString"];
            var databaseName = System.Configuration.ConfigurationManager.AppSettings["MongoDBDatabaseName"];

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            // Kết nối tới collection "NganhDaoTao"
            collection = database.GetCollection<BsonDocument>("NganhDaoTao");
        }

        // Lấy danh sách ngành đào tạo
        public List<BsonDocument> DanhSachNganhDaoTao()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        // Tìm kiếm ngành đào tạo
        public List<BsonDocument> TimKiemNganhDaoTao(string tenNganh)
        {
            var filter = Builders<BsonDocument>.Filter.Regex("TenNganh", new BsonRegularExpression(tenNganh, "i"));
            return collection.Find(filter).ToList();
        }

        // Lấy danh sách thông tin đầy đủ ngành đào tạo
        public List<BsonDocument> DanhSachThongTinNganhDaoTao()
        {
            var pipeline = new[]
            {
        // Bước 1: Join collection "Khoa"
        new BsonDocument("$lookup", new BsonDocument
        {
            { "from", "Khoa" },               // Tên collection cần join
            { "localField", "MaKhoa" },       // Trường từ collection NganhDaoTao
            { "foreignField", "MaKhoa" },     // Trường từ collection Khoa
            { "as", "Khoa_Info" }             // Alias để lưu kết quả join
        }),

        // Bước 2: Giải nén dữ liệu từ mảng Khoa_Info
        new BsonDocument("$unwind", new BsonDocument
        {
            { "path", "$Khoa_Info" },
            { "preserveNullAndEmptyArrays", true }
        }),

        // Bước 3: Chọn dữ liệu hiển thị
        new BsonDocument("$project", new BsonDocument
        {
            { "MaNganh", 1 },                          // Mã ngành
            { "TenNganh", 1 },                         // Tên ngành
            { "MaKhoa", "$Khoa_Info.MaKhoa" },         // Mã khoa từ join (để truy vấn)
            { "TenKhoa", "$Khoa_Info.TenKhoa" }        // Tên khoa từ join (hiển thị)
        })
    };

            // Thực thi pipeline
            return collection.Aggregate<BsonDocument>(pipeline).ToList();
        }



        // Xóa một ngành đào tạo
        public void XoaNganhDaoTao(string maNganh)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaNganh", maNganh);
            collection.DeleteOne(filter);
        }

        // Thêm một ngành đào tạo
        public void ThemNganhDaoTao(NganhDaoTao_ThongTin NDT)
        {
            var document = new BsonDocument
            {
                { "MaNganh", NDT.MaNganh },
                { "TenNganh", NDT.TenNganh },
                { "MaKhoa", NDT.MaKhoa }
            };
            collection.InsertOne(document);
        }

        // Sửa một ngành đào tạo
        public void SuaNganhDaoTao(NganhDaoTao_ThongTin NDT)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaNganh", NDT.MaNganh);
            var update = Builders<BsonDocument>.Update
                .Set("TenNganh", NDT.TenNganh)
                .Set("MaKhoa", NDT.MaKhoa);
            collection.UpdateOne(filter, update);
        }

        // Tìm kiếm thông tin đầy đủ ngành đào tạo
        public List<BsonDocument> TimKiemThongTinNganhDaoTao(string maNganh)
        {
            var filter = Builders<BsonDocument>.Filter.Regex("MaNganh", new BsonRegularExpression(maNganh, "i"));
            return collection.Find(filter).ToList();
        }

    }
}
