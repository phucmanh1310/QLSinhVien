using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using D.ThongTin;
using System.Linq;

namespace C.DuLieu
{
    public class DangNhap_C
    {
        private IMongoCollection<BsonDocument> collection;

        public DangNhap_C()
        {
            // Kết nối tới MongoDB
            var connectionString = System.Configuration.ConfigurationManager.AppSettings["MongoDBConnectionString"];
            var databaseName = System.Configuration.ConfigurationManager.AppSettings["MongoDBDatabaseName"];

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            // Kết nối đến collection "ThongTinDanhNhap"
            collection = database.GetCollection<BsonDocument>("ThongTinDangNhap");

        }

        // Kiểm tra đăng nhập
        public List<BsonDocument> KiemTraDangNhap(DangNhap_ThongTin DN)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("TaiKhoan", DN.TaiKhoan) &
                         Builders<BsonDocument>.Filter.Eq("MatKhau", DN.MatKhau);
            return collection.Find(filter).ToList();
        }

        // Cập nhật trạng thái
        public void UpDateTrangThai(DangNhap_ThongTin DN)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("TaiKhoan", DN.TaiKhoan);
            var update = Builders<BsonDocument>.Update.Set("TrangThai", DN.TrangThai);
            collection.UpdateOne(filter, update);
        }

        // Danh sách tài khoản
        public List<BsonDocument> DanhSachTaiKhoan()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        // Xóa tài khoản
        public void XoaTaiKhoan(DangNhap_ThongTin DN)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("TaiKhoan", DN.TaiKhoan);
            collection.DeleteOne(filter);
        }

        // Thêm tài khoản
        public void ThemTaiKhoan(DangNhap_ThongTin DN)
        {
            var document = new BsonDocument
            {
                { "TaiKhoan", DN.TaiKhoan },
                { "Quyen", DN.Quyen },
                { "MatKhau", DN.MatKhau }, // Thêm mật khẩu người dùng nhập vào
                { "TrangThai", false }
            };
            collection.InsertOne(document);
        }

        // Chỉnh sửa quyền
        public void ChinhSuaQuyen(DangNhap_ThongTin DN)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("TaiKhoan", DN.TaiKhoan);
            var update = Builders<BsonDocument>.Update.Set("Quyen", DN.Quyen);
            collection.UpdateOne(filter, update);
        }

        // Tìm kiếm tài khoản
        public List<BsonDocument> TimKiemTaiKhoan(DangNhap_ThongTin DN)
        {
            var filter = Builders<BsonDocument>.Filter.Regex("TaiKhoan", new BsonRegularExpression(DN.TaiKhoan, "i"));
            return collection.Find(filter).ToList();
        }
        // Cập nhật trong lớp DangNhap_C
        public List<string> DanhSachQuyen()
        {
            var database = collection.Database;
            var quyenCollection = database.GetCollection<BsonDocument>("Quyen");

            // Truy vấn và lấy danh sách TenQuyen
            var quyenList = quyenCollection.Find(new BsonDocument())
                                           .ToList()
                                           .Select(doc => doc["TenQuyen"]?.AsString) // Lấy giá trị "TenQuyen"
                                           .Where(q => !string.IsNullOrEmpty(q))    // Lọc bỏ giá trị rỗng
                                           .ToList();

            return quyenList;
        }
        public void UpDateMatKhau(DangNhap_ThongTin DN)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("TaiKhoan", DN.TaiKhoan);
            var update = Builders<BsonDocument>.Update.Set("MatKhau", DN.MatKhau);
            collection.UpdateOne(filter, update);
        }

    }
}
