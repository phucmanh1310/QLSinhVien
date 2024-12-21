using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using D.ThongTin;
using System;
using System.Data;

namespace C.DuLieu
{
    public class BangDiem_C
    {
        private IMongoCollection<BsonDocument> collection;
        KetNoi_CSDL cls = new KetNoi_CSDL();
        public BangDiem_C()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("QLSINHVIEN");
            collection = database.GetCollection<BsonDocument>("BangDiem");
        }

        // Lấy điểm trong 1 học kỳ của sinh viên
      /* public DataTable LayDiemTheoKySinhVien(BangDiem_ThongTin BD)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("MaSinhVien", BD.MaSinhVien),
                Builders<BsonDocument>.Filter.Eq("MaHocKy", BD.MaHocKy)
            );
            var documents = cls.LayDuLieu("BangDiem", filter);
            return DataConversion1.ConvertToDataTable1(documents);
        }*/
        public DataTable LayDiemTheoKySinhVien(BangDiem_ThongTin BD)
        {
            // Lấy dữ liệu từ MongoDB và thực hiện lookup
            var aggregate = collection.Aggregate()
                .Match(Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("MaSinhVien", BD.MaSinhVien),
                    Builders<BsonDocument>.Filter.Eq("MaHocKy", BD.MaHocKy)
                ))
                .Lookup("MonHoc", "MaMonHoc", "MaMonHoc", "MonHocInfo")
                .Unwind("MonHocInfo")
                .Lookup("DoiDiem", "DiemTKHe4", "DiemSo", "DoiDiemInfo")
                .Unwind("DoiDiemInfo")
                .Project(new BsonDocument
                {
            { "STT", 1 },
            { "MaHocKy", 1 },
            {"MaMonHoc",1 },
            { "TenMonHoc", "$MonHocInfo.TenMonHoc" },
            { "SoTinChi", "$MonHocInfo.SoTinChi" },
            { "DiemQuaTrinh", 1 },
            { "DiemThi", 1 },
            {"DiemTKHe10",1 },
            { "DiemTKHe4", 1 },
            { "DiemChu", "$DoiDiemInfo.DiemChu" },
            { "KetLuan", "$DoiDiemInfo.KetLuan" }
                });

            // Chuyển đổi kết quả sang DataTable
            var results = aggregate.ToList();
            if (results.Count == 0)
            {
                Console.WriteLine("Không có dữ liệu nào được trả về.");
            }
            return DataConversion1.ConvertToDataTable1(results);
        }


        // Thêm kết quả học tập
        public void ThemKetQua(BangDiem_ThongTin BD)
        {
            try
            {
                // Lấy số lượng bản ghi hiện có
                var filter = Builders<BsonDocument>.Filter.Eq("MaSinhVien", BD.MaSinhVien);
                var count = collection.CountDocuments(filter);

                // Tăng STT dựa trên số lượng bản ghi
                BD.Stt = (int)count + 1;

                // Tạo document mới
                var document = new BsonDocument
                {
                    { "STT", BD.Stt },
                    { "MaSinhVien", BD.MaSinhVien },
                    { "MaMonHoc", BD.MaMonHoc },
                    { "MaHocKy", BD.MaHocKy },
                    { "DiemQuaTrinh", BD.DiemQuaTrinh },
                    { "DiemThi", BD.DiemThi },
                    { "DiemTKHe10", BangDiem_ThongTin.TinhDiemHe10(BD.DiemQuaTrinh, BD.DiemThi) },
                    { "DiemTKHe4", BangDiem_ThongTin.QuyDoiDiemHe4(BD.DiemQuaTrinh) }
                };

                collection.InsertOne(document);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm kết quả: " + ex.Message);
            }
        }




        // Xóa kết quả học tập
        public void XoaDiemCuaSinhVien(BangDiem_ThongTin BD)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("STT", BD.Stt);
            cls.XoaDuLieu("BangDiem", filter);
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

            cls.CapNhatDuLieu("BangDiem", filter, update);
        }

        // Lấy kết quả học tập tổng quát
        public DataTable LayKetQuaHocTap(BangDiem_ThongTin BD)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaSinhVien", BD.MaSinhVien);

            var results = collection.Find(filter).ToList();
            return DataConversion1.ConvertToDataTable1(results);
        }


        // Kết quả tổng kết đào tạo
        public DataTable KetQuaTongKetDaoTao(BangDiem_ThongTin BD)
        {
            var aggregate = collection.Aggregate()
                .Match(Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("MaSinhVien", BD.MaSinhVien),
                Builders<BsonDocument>.Filter.Eq("MaHocKy", BD.MaHocKy)
                        ))
                .Group(new BsonDocument
                {
            { "_id", "$MaSinhVien" },
            { "SoTinChiTichLuy", new BsonDocument("$sum", "$SoTinChi") },
            { "DiemTBHe10", new BsonDocument("$avg", "$DiemTKHe10") },
            { "DiemTBHe4", new BsonDocument("$avg", "$DiemTKHe4") }
                });

            var results = aggregate.ToList();
            return DataConversion1.ConvertToDataTable1(results);
        }



        // Số tín chỉ đạt trong kỳ
        public DataTable SoTinChiDat(BangDiem_ThongTin BD)
        {
            var aggregate = collection.Aggregate()
                .Match(Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("MaSinhVien", BD.MaSinhVien),
                    Builders<BsonDocument>.Filter.Eq("MaHocKy", BD.MaHocKy),
                    Builders<BsonDocument>.Filter.Gte("DiemChu", "D") // Giả định điểm từ D trở lên được tính là đạt
                ))
                .Group(new BsonDocument
                {
            { "_id", "$MaHocKy" },
            { "SoTinChi", new BsonDocument("$sum", "$SoTinChi") }
                });

            var results = aggregate.ToList();
            return DataConversion1.ConvertToDataTable1(results);
        }

        // Kết quả tổng kết học kỳ
        public DataTable KetQuaTongKetHocKy(BangDiem_ThongTin BD)
        {
            int Nparameter = 2;
            string[] name = new string[Nparameter];
            object[] value = new object[Nparameter];
            name[0] = "@MaSinhVien";
            value[0] = BD.MaSinhVien;
            name[1] = "@MaHocKy";
            value[1] = BD.MaHocKy;
            return cls.TimKiem("KetQuaTongKetHocKy", name, value, Nparameter);
        }
        public List<BsonDocument> DanhSachSinhVienXetHocBong(string maHocKy)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaHocKy", maHocKy);
            return collection.Find(filter).ToList();
        }//còn sai sót

        public List<BsonDocument> DanhSachSinhVienXetHocBong_Khoa(string maHocKy, string maKhoa)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("MaHocKy", maHocKy),
                Builders<BsonDocument>.Filter.Eq("MaKhoa", maKhoa)
            );
            return collection.Find(filter).ToList();
        }//còn sai sót

        public List<BsonDocument> DanhSachSinhVienXetHocBong_Khoa_Top(string maHocKy, string maKhoa, int top)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("MaHocKy", maHocKy),
                Builders<BsonDocument>.Filter.Eq("MaKhoa", maKhoa)
            );

            var sort = Builders<BsonDocument>.Sort.Descending("DiemTB");
            return collection.Find(filter).Sort(sort).Limit(top).ToList();
        }//còn sai sót

    }
}
