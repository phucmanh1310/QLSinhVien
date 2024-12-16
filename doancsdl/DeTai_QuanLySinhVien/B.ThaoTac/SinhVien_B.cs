using MongoDB.Bson;
using System.Collections.Generic;
using C.DuLieu;
using D.ThongTin;
using MongoDB.Driver;
using System.Configuration;

namespace B.ThaoTac
{
    public class SinhVien_B
    {
        SinhVien_C cls = new SinhVien_C();
        private readonly IMongoDatabase database;
        public SinhVien_B()
        {
            // Kết nối tới MongoDB
            var connectionString = ConfigurationManager.AppSettings["MongoDBConnectionString"];
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }

        // Lấy danh sách sinh viên
        public List<BsonDocument> DanhSachSinhVien()
        {
            var collection = database.GetCollection<BsonDocument>("SinhVien");
            return collection.Find(new BsonDocument()).ToList();
        }


        // Tìm kiếm sinh viên
        public List<BsonDocument> TimKiemSinhVien(SinhVien_ThongTin SV)
        {
            return cls.TimKiemSinhVien(SV.MaSinhVien); // Chỉ truyền MaSinhVien làm tham số
        }


        // Thêm sinh viên mới
        public void ThemSinhVien(SinhVien_ThongTin SV)
        {
            cls.ThemSinhVien(SV);
        }

        // Chỉnh sửa thông tin sinh viên
        public void SuaThongTinSinhVien(SinhVien_ThongTin SV)
        {
            cls.SuaThongTinSinhVien(SV);
        }

        // Xóa sinh viên
        public void XoaSinhVien(string maSinhVien)
        {
            cls.XoaSinhVien(maSinhVien); // Gọi phương thức trong tầng dữ liệu
        }

        // Lấy danh sách sinh viên của lớp
        public List<BsonDocument> DanhSachSinhVienCuaLop(string lop)
        {
            return cls.DanhSachSinhVienCuaLop(lop);
        }

        // Lấy danh sách sinh viên ra trường trong năm
        public List<BsonDocument> DanhSachSinhVienRaTruong()
        {
            return cls.DanhSachSinhVienRaTruong();
        }

        // Lấy danh sách sinh viên ra trường được nhận bằng
        public List<BsonDocument> DanhSachSinhVienRaTruongDuocNhanBang()
        {
            return cls.DanhSachSinhVienRaTruongDuocNhanBang();
        }

        // Lấy danh sách sinh viên ra trường không được nhận bằng
        public List<BsonDocument> DanhSachSinhVienRaTruongKhongDuocNhanBang()
        {
            return cls.DanhSachSinhVienRaTruongKhongDuocNhanBang();
        }

    }
}
