using System.Collections.Generic;
using MongoDB.Bson;
using D.ThongTin;
using C.DuLieu;

namespace B.ThaoTac
{
    public class Lop_B
    {
        Lop_C cls = new Lop_C();

        // Lấy danh sách lớp học
        public List<BsonDocument> DanhSachLop()
        {
            return cls.DanhSachLop();
        }

        // Lấy danh sách thông tin đầy đủ lớp học
        public List<BsonDocument> DanhSach_ThongTin_Lop()
        {
            return cls.DanhSach_ThongTin_Lop();
        }

        // Thêm lớp học mới
        public void ThemLopHocMoi(Lop_ThongTin Lop)
        {
            cls.ThemLopHocMoi(Lop);
        }

        // Sửa thông tin lớp học
        public void SuaThongTinLopHoc(Lop_ThongTin Lop)
        {
            cls.SuaThongTinLopHoc(Lop);
        }

        // Xóa lớp học
        public void XoaLopHoc(Lop_ThongTin Lop)
        {
            cls.XoaLopHoc(Lop);
        }

        // Tìm kiếm lớp học
        public List<BsonDocument> TimKiemLopHoc(Lop_ThongTin Lop)
        {
            return cls.TimKiemLopHoc(Lop);
        }
        public List<BsonDocument> DanhSach_ThongTin_DayDu()
        {
            return cls.DanhSach_ThongTin_DayDu();
        }

    }
}
