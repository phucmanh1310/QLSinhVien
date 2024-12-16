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
using MongoDB.Bson;

namespace A.GiaoDien
{
    public partial class KetQuaHocTapCuaSinhVien : Form
    {
        //KHAI BÁO DÙNG CHUNG
        //BẢNG HỌC KỲ
        HocKy_B cls_HK = new HocKy_B();
        //BẢNG ĐIỂM
        BangDiem_B cls_BD = new BangDiem_B();

        int DongChon = 0;
        string ChucNang = null;
        string Ma = null;
        int XacNhanIn = 0;

        public KetQuaHocTapCuaSinhVien(SinhVien_ThongTin SV)
        {
            InitializeComponent();
            //LẤY DỮ LIỆU TỪ DANH SÁCH SINH VIÊN ĐỔ VỀ Ô TEXT.
            txtMaSo.Text = SV.MaSinhVien;
            txtHoTen.Text = SV.TenSinhVien;
            txtLop.Text = SV.Lop;
            //LOAD TOÀN BỘ DỮ LIỆU LÊN COMBOBOX.
            cbHocKy.DataSource = cls_HK.DanhSachHocKy();
            cbHocKy.DisplayMember = "TenHocKy";
            cbHocKy.ValueMember = "MaHocKy";
            //LẤY RA TOÀN BỘ KẾT QUẢ HỌC TẬP CỦA SINH VIÊN.
            string maSinhVien = txtMaSo.Text;
            tbKetQuaHocTap.DataSource = DataConversion1.ConvertToDataTable1(cls_BD.LayKetQuaHocTap(maSinhVien));

            //HIỂN THỊ KẾT QUẢ HỌC TẬP - ĐÀO TẠO CỦA SINH VIÊN.
            DataTable Bang = new DataTable();
            DataRow Hang;
            BangDiem_ThongTin BD = new BangDiem_ThongTin
            {
                MaSinhVien = txtMaSo.Text
            };
            var result = cls_BD.KetQuaTongKetDaoTao(BD.MaSinhVien);
            Bang = DataConversion1.ConvertToDataTable1(new List<BsonDocument> { result });
            Hang = Bang.Rows[0];
            txtSoTCTichLuy.Text = Hang[0].ToString();
            txtDiemTLHe10.Text = Hang[1].ToString();
            txtDiemTLHe4.Text = Hang[2].ToString();

            XacNhanIn = 0;
        }

        private void ChonKyHoc_LoadDiem(object sender, EventArgs e)
        {
            string maSinhVien = txtMaSo.Text;
            string maHocKy = cbHocKy.SelectedValue.ToString();

            // Lấy dữ liệu điểm theo kỳ và hiển thị
            tbKetQuaHocTap.DataSource = DataConversion1.ConvertToDataTable1(cls_BD.LayDiemTheoKySinhVien(maSinhVien, maHocKy));

            // Lấy thông tin số tín chỉ đạt
            var soTinChi = cls_BD.SoTinChiDat(maSinhVien, maHocKy);
            txtSoTCDat.Text = soTinChi["SoTCDat"].ToString();

            // Lấy thông tin tổng kết học kỳ
            var ketQuaHocKy = cls_BD.KetQuaTongKetHocKy(maSinhVien, maHocKy);
            txtDiemTBHe10.Text = ketQuaHocKy["DiemTBHe10"].ToString();
            txtDiemTBHe4.Text = ketQuaHocKy["DiemTBHe4"].ToString();

        }
        //KÍCH CHỌN XEM TẤT CẢ KẾT QUẢ HỌC TẬP.
        private void btAll_Click(object sender, EventArgs e)
        {
            string maSinhVien = txtMaSo.Text;
            string maHocKy = cbHocKy.SelectedValue.ToString();

            tbKetQuaHocTap.DataSource = DataConversion1.ConvertToDataTable1(cls_BD.LayDiemTheoKySinhVien(maSinhVien, maHocKy));

            var soTinChi = cls_BD.SoTinChiDat(maSinhVien, maHocKy);
            txtSoTCDat.Text = soTinChi["SoTCDat"].ToString();

            var ketQuaHocKy = cls_BD.KetQuaTongKetHocKy(maSinhVien, maHocKy);
            txtDiemTBHe10.Text = ketQuaHocKy["DiemTBHe10"].ToString();
            txtDiemTBHe4.Text = ketQuaHocKy["DiemTBHe4"].ToString();

            XacNhanIn = 0;
        }
        //LẤY RA DÒNG ĐƯỢC CHỌN.
        private void tbKetQuaHocTap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DongChon = e.RowIndex;
        }
        //KHI KÍCH ĐÚP CHUỘT VÀO BẢNG CHUYỂN ĐẾN TRANG CHỈNH SỬA ĐIỂM.
        private void KichDup_ChinhSuaDiemCuaSinhVien(object sender, MouseEventArgs e)
        {
            ChucNang = "ChinhSua";
            string MaLop = txtLop.Text;

            BangDiem_ThongTin BD = new BangDiem_ThongTin
            {
                MaSinhVien = txtMaSo.Text,
                Stt = int.Parse(tbKetQuaHocTap.Rows[DongChon].Cells[0].Value.ToString()),
                MaMonHoc = tbKetQuaHocTap.Rows[DongChon].Cells[2].Value.ToString(),
                MaHocKy = tbKetQuaHocTap.Rows[DongChon].Cells[1].Value.ToString(),
                DiemQuaTrinh = float.Parse(tbKetQuaHocTap.Rows[DongChon].Cells[5].Value.ToString()),
                DiemThi = float.Parse(tbKetQuaHocTap.Rows[DongChon].Cells[6].Value.ToString())
            };

            // Gọi form NhapDiem và truyền dữ liệu
            A.GiaoDien.NhapDiem ND = new A.GiaoDien.NhapDiem(ChucNang, MaLop, BD);
            ND.DuLieu = LayDuLieu; // Truyền callback để nhận dữ liệu trả về
            ND.ShowDialog(this);
        }


        //LẤY DỮ LIỆU TRẢ VỀ
        public void LayDuLieu(BangDiem_ThongTin BD)
        {
            this.Ma = BD.MaSinhVien;
            if (!string.IsNullOrEmpty(this.Ma))
            {
                tbKetQuaHocTap.DataSource = DataConversion1.ConvertToDataTable1(cls_BD.LayDiemTheoKySinhVien(BD.MaSinhVien, BD.MaHocKy));
            }
        }

        //IN BÁO CÁO
        /*  private void btInBaoCao_Click(object sender, EventArgs e)
          {
              if (XacNhanIn == 0)
              {
                  BangDiem_ThongTin BD = new BangDiem_ThongTin();
                  BD.MaSinhVien = txtMaSo.Text;
                  BaoCao.BaoCao.DuLieu = cls_BD.LayKetQuaHocTap(BD);
                  BaoCao.BaoCao.Kieu = "KetQuaRaTruong";
                  BaoCao.BaoCao.TichLuy = txtSoTCTichLuy.Text;
                  BaoCao.BaoCao.He10 = txtDiemTLHe10.Text;
                  BaoCao.BaoCao.He4 = txtDiemTLHe4.Text;
                  BaoCao.BaoCao.HoTen = txtHoTen.Text;
                  BaoCao.BaoCao.MaSinhVien = txtMaSo.Text;
                  BaoCao.BaoCao.Lop = txtLop.Text;
                  BaoCao.BaoCao BC = new BaoCao.BaoCao();
                  BC.ShowDialog();
              }
              if (XacNhanIn == 1)
              {
                  BangDiem_ThongTin BD = new BangDiem_ThongTin();
                  BD.MaSinhVien = txtMaSo.Text;
                  BD.MaHocKy = cbHocKy.SelectedValue.ToString();
                  BaoCao.BaoCao.DuLieu = cls_BD.LayDiemTheoKySinhVien(BD);
                  BaoCao.BaoCao.Kieu = "KetQuaHocKy";
                  BaoCao.BaoCao.TichLuy = txtSoTCDat.Text;
                  BaoCao.BaoCao.He10 = txtDiemTBHe10.Text;
                  BaoCao.BaoCao.He4 = txtDiemTBHe4.Text;
                  BaoCao.BaoCao.HoTen = txtHoTen.Text;
                  BaoCao.BaoCao.MaSinhVien = txtMaSo.Text;
                  BaoCao.BaoCao.Lop = txtLop.Text;
                  BaoCao.BaoCao.HocKy = cbHocKy.Text;
                  BaoCao.BaoCao BC = new BaoCao.BaoCao();
                  BC.ShowDialog();
              }
          }*/
    }
}
