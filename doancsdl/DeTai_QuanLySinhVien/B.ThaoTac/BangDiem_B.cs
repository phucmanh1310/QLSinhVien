using System.Collections.Generic;
using MongoDB.Bson;
using C.DuLieu;
using D.ThongTin;

namespace B.ThaoTac
{
    public class BangDiem_B
    {
        BangDiem_C cls = new BangDiem_C();

        public List<BsonDocument> LayDiemTheoKySinhVien(string maSinhVien, string maHocKy)
        {
            return cls.LayDiemTheoKySinhVien(maSinhVien, maHocKy);
        }

        public void ThemKetQua(BangDiem_ThongTin BD)
        {
            cls.ThemKetQua(BD);
        }

        public void XoaKetQua(int stt)
        {
            cls.XoaKetQua(stt);
        }

        public void CapNhatDiem(BangDiem_ThongTin BD)
        {
            cls.CapNhatDiem(BD);
        }

        public List<BsonDocument> LayKetQuaHocTap(string maSinhVien)
        {
            return cls.LayKetQuaHocTap(maSinhVien);
        }

        public BsonDocument KetQuaTongKetDaoTao(string maSinhVien)
        {
            return cls.KetQuaTongKetDaoTao(maSinhVien);
        }

        public BsonDocument SoTinChiDat(string maSinhVien, string maHocKy)
        {
            return cls.SoTinChiDat(maSinhVien, maHocKy);
        }

        public BsonDocument KetQuaTongKetHocKy(string maSinhVien, string maHocKy)
        {
            return cls.KetQuaTongKetHocKy(maSinhVien, maHocKy);
        }
        public List<BsonDocument> DanhSachSinhVienXetHocBong(string maHocKy)
        {
            return cls.DanhSachSinhVienXetHocBong(maHocKy);
        }

        public List<BsonDocument> DanhSachSinhVienXetHocBong_Khoa(string maHocKy, string maKhoa)
        {
            return cls.DanhSachSinhVienXetHocBong_Khoa(maHocKy, maKhoa);
        }

        public List<BsonDocument> DanhSachSinhVienXetHocBong_Khoa_Top(string maHocKy, string maKhoa, int top)
        {
            return cls.DanhSachSinhVienXetHocBong_Khoa_Top(maHocKy, maKhoa, top);
        }
        public void UpDateDiemQTVaDiemThi(BangDiem_ThongTin BD)
        {
            cls.CapNhatDiem(BD);
        }

    }
}
