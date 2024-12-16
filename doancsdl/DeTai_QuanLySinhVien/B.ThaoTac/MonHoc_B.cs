using System.Collections.Generic;
using MongoDB.Bson;
using D.ThongTin;
using C.DuLieu;

namespace B.ThaoTac
{
    public class MonHoc_B
    {
        MonHoc_C cls = new MonHoc_C();

        // Lấy danh sách môn học
        public List<BsonDocument> DanhSachMonHoc()
        {
            return cls.DanhSachMonHoc();
        }

        // Tìm kiếm môn học
        public List<BsonDocument> TimKiemMonHoc(MonHoc_ThongTin MH)
        {
            return cls.TimKiemMonHoc(MH);
        }

        // Lấy danh sách môn học toàn trường
        public List<BsonDocument> DanhSachMonHocToanTruong()
        {
            return cls.DanhSachMonHocToanTruong();
        }

        // Xóa môn học
        public void XoaMonHoc(MonHoc_ThongTin MH)
        {
            cls.XoaMonHoc(MH);
        }

        // Thêm môn học
        public void ThemMonHoc(MonHoc_ThongTin MH)
        {
            cls.ThemMonHoc(MH);
        }

        // Sửa môn học
        public void SuaMonHoc(MonHoc_ThongTin MH)
        {
            cls.SuaMonHoc(MH);
        }

        // Tìm kiếm môn học tất tần tật
        public List<BsonDocument> TimMonHoc(MonHoc_ThongTin MH)
        {
            return cls.TimMonHoc(MH);
        }
    }
}
