using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using D.ThongTin;
using System;

namespace C.DuLieu
{
    public class SinhVien_C
    {
        private IMongoCollection<BsonDocument> collection;
        private readonly IMongoDatabase database;
        public SinhVien_C()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("QLSINHVIEN");
            collection = database.GetCollection<BsonDocument>("SinhVien");
        }

        // Lấy danh sách sinh viên      
        public List<BsonDocument> DanhSachSinhVien()
        {
            var collection = database.GetCollection<BsonDocument>("SinhVien");
            var result = collection.Find(new BsonDocument()).ToList();
            return result;
        }

        // Tìm kiếm sinh viên
        public List<BsonDocument> TimKiemSinhVien(string maSinhVien)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaSinhVien", maSinhVien);
            return collection.Find(filter).ToList();
        }

        // Thêm sinh viên mới
        public void ThemSinhVien(SinhVien_ThongTin SV)
        {
            var document = new BsonDocument
            {
                { "MaSinhVien", SV.MaSinhVien },
                { "TenSinhVien", SV.TenSinhVien },
                { "NgaySinh", SV.NgaySinh },
                { "GioiTinh", SV.GioiTinh },
                { "Lop", SV.Lop },
                { "DiaChi", SV.DiaChi },
                { "ChinhSachUuTien", SV.ChinhSachUuTien }
            };

            collection.InsertOne(document);
        }


        // Chỉnh sửa thông tin sinh viên
        public void SuaThongTinSinhVien(SinhVien_ThongTin SV)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaSinhVien", SV.MaSinhVien);
            var update = Builders<BsonDocument>.Update
                .Set("TenSinhVien", SV.TenSinhVien)
                .Set("NgaySinh", SV.NgaySinh)
                .Set("GioiTinh", SV.GioiTinh)
                .Set("Lop", SV.Lop)
                .Set("DiaChi", SV.DiaChi)
                .Set("ChinhSachUuTien", SV.ChinhSachUuTien);

            collection.UpdateOne(filter, update);
        }
        // Xóa sinh viên
        public void XoaSinhVien(string maSinhVien)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaSinhVien", maSinhVien);
            collection.DeleteOne(filter);
        }


        // Lấy danh sách sinh viên của lớp
        public List<BsonDocument> DanhSachSinhVienCuaLop(SinhVien_ThongTin SV)
        {
            if (string.IsNullOrEmpty(SV.Lop))
            {
                throw new ArgumentException("Mã lớp không được để trống.");
            }
            // Tạo bộ lọc MongoDB
            var filter = Builders<BsonDocument>.Filter.Eq("Lop", SV.Lop);

            // Truy vấn danh sách sinh viên theo lớp
            try
            {
                return collection.Find(filter).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách sinh viên của lớp: {ex.Message}");
            }
        }

        // Lấy danh sách sinh viên ra trường trong năm
        public List<BsonDocument> DanhSachSinhVienRaTruong()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("TrangThaiRaTruong", true);
            return collection.Find(filter).ToList();
        }

        // Lấy danh sách sinh viên ra trường được nhận bằng
        public List<BsonDocument> DanhSachSinhVienRaTruongDuocNhanBang()
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("TrangThaiRaTruong", true),
                Builders<BsonDocument>.Filter.Eq("NhanBang", true)
            );
            return collection.Find(filter).ToList();
        }

        // Lấy danh sách sinh viên ra trường không được nhận bằng
        public List<BsonDocument> DanhSachSinhVienRaTruongKhongDuocNhanBang()
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("TrangThaiRaTruong", true),
                Builders<BsonDocument>.Filter.Eq("NhanBang", false)
            );
            return collection.Find(filter).ToList();
        }
        public byte[] LayAnhSinhVien(SinhVien_ThongTin SV)
        {
            var collection = database.GetCollection<BsonDocument>("SinhVien");
            var filter = Builders<BsonDocument>.Filter.Eq("MaSinhVien", SV.MaSinhVien);
            var result = collection.Find(filter).FirstOrDefault();

            if (result != null && result.Contains("Anh") && result["Anh"] != BsonNull.Value)
            {
                return result["Anh"].AsByteArray;
            }
            return null; // Trả về null nếu không có ảnh
        }

    }
}
