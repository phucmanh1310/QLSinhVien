using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using D.ThongTin;
using B.ThaoTac;
using System.Configuration;

namespace A.GiaoDien.BaoCao
{
    public partial class BaoCao : Form
    {
        //KHAI BÁO
        public static string TichLuy, He10, He4, HoTen, MaSinhVien, Lop, HocKy, Khoa, Top;
        public static DataTable DuLieu;
        public static string Kieu;
        public BaoCao()
        {
            InitializeComponent();
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            if (Kieu.Equals("TimKiemHeDaoTao"))
            {
                HeDaoTao HDT = new HeDaoTao();
                HDT.SetDataSource(DuLieu);
                HienThi.ReportSource = HDT;
                HienThi.Refresh();
            }
            if (Kieu.Equals("TimKiemHocKy"))
            {
                HocKy HK = new HocKy();
                HK.SetDataSource(DuLieu);
                HienThi.ReportSource = HK;
                HienThi.Refresh();
            }
            if (Kieu.Equals("TimKiemKhoa"))
            {
                Khoa Khoa = new Khoa();
                Khoa.SetDataSource(DuLieu);
                HienThi.ReportSource = Khoa;
                HienThi.Refresh();
            }
            if (Kieu.Equals("TimKiemKhoaHoc"))
            {
                KhoaHoc KH = new KhoaHoc();
                KH.SetDataSource(DuLieu);
                HienThi.ReportSource = KH;
                HienThi.Refresh();
            }
            if (Kieu.Equals("TimKiemLopHoc"))
            {
                LopHoc Lop = new LopHoc();
                Lop.SetDataSource(DuLieu);
                HienThi.ReportSource = Lop;
                HienThi.Refresh();
            }
            if (Kieu.Equals("TimKiemMonHoc"))
            {
                MonHoc MH = new MonHoc();
                MH.SetDataSource(DuLieu);
                HienThi.ReportSource = MH;
                HienThi.Refresh();
            }
            if (Kieu.Equals("TimKiemNganhDaoTao"))
            {
                NganhDaoTao NDT = new NganhDaoTao();
                NDT.SetDataSource(DuLieu);
                HienThi.ReportSource = NDT;
                HienThi.Refresh();
            }
            if (Kieu.Equals("TimKiemSinhVien"))
            {
                SinhVien SV = new SinhVien();
                SV.SetDataSource(DuLieu);
                HienThi.ReportSource = SV;
                HienThi.Refresh();
            }
            if (Kieu.Equals("TimKiemTaiKhoan"))
            {
                TaiKhoan TK = new TaiKhoan();
                TK.SetDataSource(DuLieu);
                HienThi.ReportSource = TK;
                HienThi.Refresh();
            }
            if (Kieu.Equals("HocBong"))
            {
                HocBong HB = new HocBong();
                HB.SetDataSource(DuLieu);
                HB.SetParameterValue(1, HocKy);
                HienThi.ReportSource = HB;
                HienThi.Refresh();
            }
            if (Kieu.Equals("HocBong_Khoa"))
            {
                HocBong_Khoa HBK = new HocBong_Khoa();
                HBK.SetDataSource(DuLieu);
                HBK.SetParameterValue(2, HocKy);
                HBK.SetParameterValue(3, Khoa);
                HienThi.ReportSource = HBK;
                HienThi.Refresh();
            }
            if (Kieu.Equals("HocBong_Khoa_Top"))
            {
                HocBong_Khoa_Top HBK = new HocBong_Khoa_Top();
                HBK.SetDataSource(DuLieu);
                HBK.SetParameterValue(3, HocKy);
                HBK.SetParameterValue(4, Khoa);
                HBK.SetParameterValue(5, Top);
                HienThi.ReportSource = HBK;
                HienThi.Refresh();
            }
            if (Kieu.Equals("RaTruong"))
            {
                RaTruong RT = new RaTruong();
                RT.SetDataSource(DuLieu);
                HienThi.ReportSource = RT;
                HienThi.Refresh();
            }
            if (Kieu.Equals("RaTruong_NhanBang"))
            {
                RaTruong_NhanBang RTNB = new RaTruong_NhanBang();
                RTNB.SetDataSource(DuLieu);
                HienThi.ReportSource = RTNB;
                HienThi.Refresh();
            }
            if (Kieu.Equals("RaTruong_KhongBang"))
            {
                RaTruong_KhongBang RTKB = new RaTruong_KhongBang();
                RTKB.SetDataSource(DuLieu);
                HienThi.ReportSource = RTKB;
                HienThi.Refresh();
            }
            //
            if (Kieu.Equals("KetQuaRaTruong"))
            {
                KetQuaRaTruong KQRT = new KetQuaRaTruong();
                KQRT.SetDataSource(DuLieu);
                KQRT.SetParameterValue(1, He4);
                KQRT.SetParameterValue(2, He10);
                KQRT.SetParameterValue(3, TichLuy);
                KQRT.SetParameterValue(4, HoTen);
                KQRT.SetParameterValue(5, Lop);
                KQRT.SetParameterValue(6, MaSinhVien);
                HienThi.ReportSource = KQRT;
                HienThi.Refresh();
            }
            if (Kieu.Equals("KetQuaHocKy"))
            {
                KetQuaHocKy KQHK = new KetQuaHocKy();
                KQHK.SetDataSource(DuLieu);
                KQHK.SetParameterValue(2, HoTen);
                KQHK.SetParameterValue(3, Lop);
                KQHK.SetParameterValue(4, MaSinhVien);
                KQHK.SetParameterValue(5, He4);
                KQHK.SetParameterValue(6, He10);
                KQHK.SetParameterValue(7, TichLuy);
                KQHK.SetParameterValue(8, HocKy);
                HienThi.ReportSource = KQHK;
                HienThi.Refresh();
            }
        }
    }
}
