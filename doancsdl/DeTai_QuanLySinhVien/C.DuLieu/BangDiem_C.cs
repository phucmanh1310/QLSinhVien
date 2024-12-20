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
            var database = client.GetDatabase("QLSinhVien");
            collection = database.GetCollection<BsonDocument>("BangDiem");
        }

        // Lấy điểm trong 1 học kỳ của sinh viên
       public DataTable LayDiemTheoKySinhVien(BangDiem_ThongTin BD)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("MaSinhVien", BD.MaSinhVien),
                Builders<BsonDocument>.Filter.Eq("MaHocKy", BD.MaHocKy)
            );
            var documents = cls.LayDuLieu("BangDiem", filter);
            return DataConversion1.ConvertToDataTable1(documents);
        }


        // Thêm kết quả học tập
        public void ThemKetQua(BangDiem_ThongTin BD)
        {
            BD.DiemTKHe10 = BangDiem_ThongTin.TinhDiemHe10(BD.DiemQuaTrinh, BD.DiemThi);
            BD.DiemTKHe4 = BangDiem_ThongTin.QuyDoiDiemHe4(BD.DiemTKHe10);

            var document = new BsonDocument
            {
                { "MaSinhVien", BD.MaSinhVien },
                { "MaMonHoc", BD.MaMonHoc },
                { "MaHocKy", BD.MaHocKy },
                { "DiemQuaTrinh", BD.DiemQuaTrinh },
                { "DiemThi", BD.DiemThi },
                { "DiemTKHe10", BD.DiemTKHe10 },
                { "DiemTKHe4", BD.DiemTKHe4 }
            };
            cls.ThemDuLieu("BangDiem", document);

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
        public List<BsonDocument> LayKetQuaHocTap(BangDiem_ThongTin BD)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaSinhVien", BD.MaSinhVien);
            return collection.Find(filter).ToList();
        }// khi sử dụng dạng table phải chuyển đổi nó

        // Kết quả tổng kết đào tạo
        public DataTable KetQuaTongKetDaoTao(BangDiem_ThongTin BD)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MaSinhVien", BD.MaSinhVien);
            var documents = cls.LayDuLieu("BangDiem", filter);
            return DataConversion1.ConvertToDataTable1(documents);
        }


        // Số tín chỉ đạt trong kỳ
        public DataTable SoTinChiDat(BangDiem_ThongTin BD)
        {
            int Nparameter = 2;
            string[] name = new string[Nparameter];
            object[] value = new object[Nparameter];
            name[0] = "@MaSinhVien";
            value[0] = BD.MaSinhVien;
            name[1] = "@MaHocKy";
            value[1] = BD.MaHocKy;
            return cls.TimKiem("SoTinChiDat", name, value, Nparameter);
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
