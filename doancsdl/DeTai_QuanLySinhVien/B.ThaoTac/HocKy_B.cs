using System.Collections.Generic;
using MongoDB.Bson;
using D.ThongTin;
using C.DuLieu;

namespace B.ThaoTac
{
    public class HocKy_B
    {
        HocKy_C cls = new HocKy_C();

        // Lấy danh sách học kỳ
        public List<BsonDocument> DanhSachHocKy()
        {
            return cls.DanhSachHocKy();
        }

        // Lấy danh sách thông tin đầy đủ về học kỳ
        public List<BsonDocument> DanhSachThongTinHocKy()
        {
            return cls.DanhSachThongTinHocKy();
        }

        // Xóa một học kỳ
        public void XoaHocKy(HocKy_ThongTin HK)
        {
            cls.XoaHocKy(HK);
        }

        // Thêm một học kỳ
        public void ThemHocKy(HocKy_ThongTin HK)
        {
            cls.ThemHocKy(HK);
        }

        // Sửa một học kỳ
        public void SuaHocKy(HocKy_ThongTin HK)
        {
            cls.SuaHocKy(HK);
        }

        // Tìm kiếm học kỳ
        public List<BsonDocument> TimKiemHocKy(HocKy_ThongTin HK)
        {
            return cls.TimKiemHocKy(HK);
        }
    }
}
