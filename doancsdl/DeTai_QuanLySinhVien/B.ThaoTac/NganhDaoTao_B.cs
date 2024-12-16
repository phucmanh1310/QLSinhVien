using System.Collections.Generic;
using MongoDB.Bson;
using D.ThongTin;
using C.DuLieu;

namespace B.ThaoTac
{
    public class NganhDaoTao_B
    {
        NganhDaoTao_C cls = new NganhDaoTao_C();

        public List<BsonDocument> DanhSachNganhDaoTao()
        {
            return cls.DanhSachNganhDaoTao();
        }

        public List<BsonDocument> TimKiemNganhDaoTao(string tenNganh)
        {
            return cls.TimKiemNganhDaoTao(tenNganh);
        }

        public List<BsonDocument> DanhSachThongTinNganhDaoTao()
        {
            return cls.DanhSachThongTinNganhDaoTao();
        }


        public void XoaNganhDaoTao(string maNganh)
        {
            cls.XoaNganhDaoTao(maNganh);
        }

        public void ThemNganhDaoTao(NganhDaoTao_ThongTin NDT)
        {
            cls.ThemNganhDaoTao(NDT);
        }

        public void SuaNganhDaoTao(NganhDaoTao_ThongTin NDT)
        {
            cls.SuaNganhDaoTao(NDT);
        }

        public List<BsonDocument> TimKiemThongTinNganhDaoTao(string maNganh)
        {
            return cls.TimKiemThongTinNganhDaoTao(maNganh);
        }

    }
}
