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
            var filter = new BsonDocument(); // Không lọc, lấy toàn bộ dữ liệu
            return collection.Find(filter).ToList();
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
