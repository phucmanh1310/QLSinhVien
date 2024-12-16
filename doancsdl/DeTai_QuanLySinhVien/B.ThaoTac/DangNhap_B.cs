using System.Collections.Generic;
using MongoDB.Bson;
using D.ThongTin;
using C.DuLieu;
using System.Data;

namespace B.ThaoTac
{


    public class DangNhap_B
    {
        DangNhap_C cls = new DangNhap_C();

        public List<BsonDocument> KiemTraDangNhap(DangNhap_ThongTin DN)
        {
            return cls.KiemTraDangNhap(DN);
        }

        public void UpDateTrangThai(DangNhap_ThongTin DN)
        {
            cls.UpDateTrangThai(DN);
        }

        public List<BsonDocument> DanhSachTaiKhoan()
        {
            return cls.DanhSachTaiKhoan();
        }

        public void XoaTaiKhoan(DangNhap_ThongTin DN)
        {
            cls.XoaTaiKhoan(DN);
        }

        public void ThemTaiKhoan(DangNhap_ThongTin DN)
        {
            cls.ThemTaiKhoan(DN);
        }

        public void ChinhSuaQuyen(DangNhap_ThongTin DN)
        {
            cls.ChinhSuaQuyen(DN);
        }

        public List<BsonDocument> TimKiemTaiKhoan(DangNhap_ThongTin DN)
        {
            return cls.TimKiemTaiKhoan(DN);
        }
        public List<BsonDocument> DanhSachQuyen()
        {
            return cls.DanhSachQuyen();
        }
        public void UpDateMatKhau(DangNhap_ThongTin DN)
        {
            cls.UpDateMatKhau(DN);
        }

    }
}
