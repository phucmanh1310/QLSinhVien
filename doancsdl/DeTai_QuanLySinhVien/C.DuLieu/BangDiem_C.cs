using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using D.ThongTin;

namespace C.DuLieu
{
    public class BangDiem_C
    {
        private IMongoCollection<BsonDocument> collection;

        public BangDiem_C()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("QLSinhVien");
            collection = database.GetCollection<BsonDocument>("BangDiem");
        }

        // Lấy điểm trong 1 học kỳ của sinh viên
        public List<BsonDocument> LayDiemTheoKySinhVien(string maSinhVien, string maHocKy)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("MaSinhVien", maSinhVien),
                Builders<BsonDocument>.Filter.Eq("MaHocKy", maHocKy)
            );
            return collection.Find(filter).ToList();
        }

        // Thêm kết quả học tập
        public void ThemKetQua(BangDiem_ThongTin BD)
        {
            var document = new BsonDocument
            {
                { "MaSinhVien", BD.MaSinhVien },
                { "MaMonHoc", BD.MaMonHoc },
                { "MaHocKy", BD.MaHocKy },
                { "DiemQuaTrinh", BD.DiemQuaTrinh },
                { "DiemThi", BD.DiemThi }
            };
            collection.InsertOne(document);
        }

        // Xóa kết quả học tập
        public void XoaKetQua(int stt)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", stt);
            collection.DeleteOne(filter);
        }

        // Cập nhật điểm quá trình và điểm thi
        public void CapNhatDiem(BangDiem_ThongTin BD)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("MaSinhVien", BD.MaSinhVien),
                Builders<BsonDocument>.Filter.Eq("MaMonHoc", BD.MaMonHoc),
                Builders<BsonDocument>.Filter.Eq("MaHocKy", BD.MaHocKy)
            );

            var update = Builders<BsonDocument>.Update
                .Set("DiemQuaTrinh", BD.DiemQuaTrinh)
                .Set("DiemThi", BD.DiemThi);

            collection.UpdateOne(filter, update);
        }

        // Lấy kết quả học tập tổng quát
        public List<BsonDocument> LayKetQuaHocTap(string maSinhVien)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaSinhVien", maSinhVien);
            return collection.Find(filter).ToList();
        }

        // Kết quả tổng kết đào tạo
        public BsonDocument KetQuaTongKetDaoTao(string maSinhVien)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaSinhVien", maSinhVien);
            return collection.Aggregate()
                .Match(filter)
                .Group(new BsonDocument {
                    { "_id", "$MaSinhVien" },
                    { "SoTCTichLuy", new BsonDocument("$sum", "$SoTinChi") },
                    { "DiemTBHe10", new BsonDocument("$avg", "$DiemHe10") },
                    { "DiemTBHe4", new BsonDocument("$avg", "$DiemHe4") }
                })
                .FirstOrDefault();
        }

        // Số tín chỉ đạt trong kỳ
        public BsonDocument SoTinChiDat(string maSinhVien, string maHocKy)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("MaSinhVien", maSinhVien),
                Builders<BsonDocument>.Filter.Eq("MaHocKy", maHocKy),
                Builders<BsonDocument>.Filter.Gte("DiemThi", 5)
            );

            return collection.Aggregate()
                .Match(filter)
                .Group(new BsonDocument {
                    { "_id", "$MaHocKy" },
                    { "SoTCDat", new BsonDocument("$sum", "$SoTinChi") }
                })
                .FirstOrDefault();
        }

        // Kết quả tổng kết học kỳ
        public BsonDocument KetQuaTongKetHocKy(string maSinhVien, string maHocKy)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("MaSinhVien", maSinhVien),
                Builders<BsonDocument>.Filter.Eq("MaHocKy", maHocKy)
            );

            return collection.Aggregate()
                .Match(filter)
                .Group(new BsonDocument {
                    { "_id", "$MaHocKy" },
                    { "DiemTBHe10", new BsonDocument("$avg", "$DiemHe10") },
                    { "DiemTBHe4", new BsonDocument("$avg", "$DiemHe4") }
                })
                .FirstOrDefault();
        }
        public List<BsonDocument> DanhSachSinhVienXetHocBong(string maHocKy)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaHocKy", maHocKy);
            return collection.Find(filter).ToList();
        }

        public List<BsonDocument> DanhSachSinhVienXetHocBong_Khoa(string maHocKy, string maKhoa)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("MaHocKy", maHocKy),
                Builders<BsonDocument>.Filter.Eq("MaKhoa", maKhoa)
            );
            return collection.Find(filter).ToList();
        }

        public List<BsonDocument> DanhSachSinhVienXetHocBong_Khoa_Top(string maHocKy, string maKhoa, int top)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("MaHocKy", maHocKy),
                Builders<BsonDocument>.Filter.Eq("MaKhoa", maKhoa)
            );

            var sort = Builders<BsonDocument>.Sort.Descending("DiemTB");
            return collection.Find(filter).Sort(sort).Limit(top).ToList();
        }

    }
}
