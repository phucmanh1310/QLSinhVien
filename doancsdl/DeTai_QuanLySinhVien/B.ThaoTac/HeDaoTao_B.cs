using System.Collections.Generic;
using MongoDB.Bson;
using D.ThongTin;
using C.DuLieu;
using System.Data;

namespace B.ThaoTac
{
    public class HeDaoTao_B
    {
        HeDaoTao_C cls = new HeDaoTao_C();

        public DataTable DanhSachHeDaoTao()
        {
            return cls.DanhSachHeDaoTao();
        }

        public void XoaHeDaoTao(HeDaoTao_ThongTin HDT)
        {
            cls.XoaHeDaoTao(HDT);
        }

        public void ThemHeDaoTao(HeDaoTao_ThongTin HDT)
        {
            cls.ThemHeDaoTao(HDT);
        }

        public void SuaHeDaoTao(HeDaoTao_ThongTin HDT)
        {
            cls.SuaHeDaoTao(HDT);
        }

        public List<BsonDocument> TimKiemHeDaoTao(HeDaoTao_ThongTin HDT)
        {
            return cls.TimKiemHeDaoTao(HDT);
        }
    }
}
