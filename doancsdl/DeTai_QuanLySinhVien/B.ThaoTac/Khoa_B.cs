using System.Collections.Generic;
using MongoDB.Bson;
using D.ThongTin;
using C.DuLieu;

namespace B.ThaoTac
{
    public class Khoa_B
    {
        Khoa_C cls = new Khoa_C();

        // Lấy danh sách khoa
        public List<BsonDocument> DanhSachKhoa()
        {
            return cls.DanhSachKhoa();
        }

        // Xóa khoa
        public void XoaKhoa(Khoa_ThongTin K)
        {
            cls.XoaKhoa(K);
        }

        // Thêm khoa
        public void ThemKhoa(Khoa_ThongTin K)
        {
            cls.ThemKhoa(K);
        }

        // Sửa khoa
        public void SuaKhoa(Khoa_ThongTin K)
        {
            cls.SuaKhoa(K);
        }

        // Tìm kiếm khoa
        public List<BsonDocument> TimKiemKhoa(Khoa_ThongTin K)
        {
            return cls.TimKiemKhoa(K);
        }
    }
}
