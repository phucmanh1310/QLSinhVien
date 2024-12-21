using System.Collections.Generic;
using MongoDB.Bson;
using C.DuLieu;
using D.ThongTin;
using System.Data;

namespace B.ThaoTac
{
    public class BangDiem_B
    {
        BangDiem_C cls = new BangDiem_C();

        public DataTable LayDiemTheoKySinhVien(BangDiem_ThongTin BD)
        {
            return cls.LayDiemTheoKySinhVien(BD);
        }

        public void ThemKetQua(BangDiem_ThongTin BD)
        {
             cls.ThemKetQua(BD);
        }

        public void XoaKetQua(BangDiem_ThongTin BD)
        {
            cls.XoaDiemCuaSinhVien(BD);
        }

        public void UpDateDiemQTVaDiemThi(BangDiem_ThongTin BD)
        {
            cls.CapNhatDiem(BD);
        }

        public DataTable LayKetQuaHocTap(BangDiem_ThongTin BD)
        {
            return cls.LayKetQuaHocTap(BD);
        }

        public DataTable KetQuaTongKetDaoTao(BangDiem_ThongTin BD)
        {
            return cls.KetQuaTongKetDaoTao(BD);
        }

        public DataTable SoTinChiDat(BangDiem_ThongTin BD)
        {
            return cls.SoTinChiDat(BD);
        }

        public DataTable KetQuaTongKetHocKy(BangDiem_ThongTin BD)
        {
            return cls.KetQuaTongKetHocKy(BD);
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
    }
}
