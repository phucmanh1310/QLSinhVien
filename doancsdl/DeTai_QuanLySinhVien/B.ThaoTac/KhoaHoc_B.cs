using System.Collections.Generic;
using MongoDB.Bson;
using D.ThongTin;
using C.DuLieu;

namespace B.ThaoTac
{
    public class KhoaHoc_B
    {
        KhoaHoc_C cls = new KhoaHoc_C();

        // Lấy danh sách khóa học
        public List<BsonDocument> DanhSachKhoaHoc()
        {
            return cls.DanhSachKhoaHoc();
        }

        // Lấy danh sách thông tin đầy đủ khóa học
        public List<BsonDocument> DanhSach_ThongTin_KhoaHoc()
        {
            return cls.DanhSach_ThongTin_KhoaHoc();
        }

        // Thêm khóa học
        public void ThemKhoaHoc(KhoaHoc_ThongTin KH)
        {
            cls.ThemKhoaHoc(KH);
        }

        // Chỉnh sửa khóa học
        public void ChinhSuaKhoaHoc(KhoaHoc_ThongTin KH)
        {
            cls.ChinhSuaKhoaHoc(KH);
        }

        // Xóa khóa học
        public void XoaKhoaHoc(KhoaHoc_ThongTin KH)
        {
            cls.XoaKhoaHoc(KH);
        }

        // Tìm kiếm khóa học
        public List<BsonDocument> TimKiemKhoaHoc(KhoaHoc_ThongTin KH)
        {
            return cls.TimKiemKhoaHoc(KH);
        }
    }
}
