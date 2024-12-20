using System;

namespace D.ThongTin
{
    public class BangDiem_ThongTin
    {
        private int _Stt;
        public int Stt
        {
            get { return _Stt; }
            set { _Stt = value; }
        }

        private string _MaSinhVien;
        public string MaSinhVien
        {
            get { return _MaSinhVien; }
            set { _MaSinhVien = value; }
        }

        private string _MaMonHoc;
        public string MaMonHoc
        {
            get { return _MaMonHoc; }
            set { _MaMonHoc = value; }
        }

        private string _MaHocKy;
        public string MaHocKy
        {
            get { return _MaHocKy; }
            set { _MaHocKy = value; }
        }

        private float _DiemQuaTrinh;
        public float DiemQuaTrinh
        {
            get { return _DiemQuaTrinh; }
            set { _DiemQuaTrinh = value; }
        }

        private float _DiemThi;
        public float DiemThi
        {
            get { return _DiemThi; }
            set { _DiemThi = value; }
        }

        private float _DiemTKHe10;
        public float DiemTKHe10
        {
            get { return _DiemTKHe10; }
            set { _DiemTKHe10 = value; }
        }

        private string _DiemChu;
        public string DiemChu
        {
            get { return _DiemChu; }
            set { _DiemChu = value; }
        }

        private float _DiemTKHe4;
        public float DiemTKHe4
        {
            get { return _DiemTKHe4; }
            set { _DiemTKHe4 = value; }
        }

        // Phương thức tính điểm hệ 10
        public static float TinhDiemHe10(float diemQuaTrinh, float diemThi)
        {
            return (diemQuaTrinh * 0.5f) + (diemThi * 0.5f);
        }

        // Phương thức quy đổi điểm hệ 4
        public static float QuyDoiDiemHe4(float diemHe10)
        {
            if (diemHe10 < 4.0f) return 0.0f;
            if (diemHe10 < 5.5f) return 1.0f;
            if (diemHe10 < 7.0f) return 2.0f;
            if (diemHe10 < 8.5f) return 3.0f;
            return 4.0f;
        }

        // Phương thức quy đổi điểm chữ
        public static string QuyDoiDiemChu(float diemHe10)
        {
            if (diemHe10 < 4.0f) return "F";
            if (diemHe10 < 5.5f) return "D";
            if (diemHe10 < 7.0f) return "C";
            if (diemHe10 < 8.5f) return "B";
            return "A";
        }

        // Phương thức cập nhật điểm và tự động tính toán
        public void CapNhatDiem(float diemQuaTrinh, float diemThi)
        {
            DiemQuaTrinh = diemQuaTrinh;
            DiemThi = diemThi;

            // Tính điểm hệ 10, hệ 4 và điểm chữ
            DiemTKHe10 = TinhDiemHe10(DiemQuaTrinh, DiemThi);
            DiemTKHe4 = QuyDoiDiemHe4(DiemTKHe10);
            DiemChu = QuyDoiDiemChu(DiemTKHe10);
        }
    }
}
