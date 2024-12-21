/*using System;
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
using System.Xml.Linq;
using MongoDB.Driver;

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

        *//*  public KetQuaHocTapCuaSinhVien(SinhVien_ThongTin SV)
          {
              InitializeComponent();
              //LẤY DỮ LIỆU TỪ DANH SÁCH SINH VIÊN ĐỔ VỀ Ô TEXT.
              txtMaSo.Text = SV.MaSinhVien;
              txtHoTen.Text = SV.TenSinhVien;
              txtLop.Text = SV.Lop;
              //LOAD TOÀN BỘ DỮ LIỆU LÊN COMBOBOX.
              cbHocKy.DataSource = DataConversion1.ConvertToDataTable1(cls_HK.DanhSachHocKy());
              cbHocKy.DisplayMember = "TenHocKy";
              cbHocKy.ValueMember = "MaHocKy";
              //LẤY RA TOÀN BỘ KẾT QUẢ HỌC TẬP CỦA SINH VIÊN.
              BangDiem_ThongTin BD = new BangDiem_ThongTin();
               BD.MaSinhVien = txtMaSo.Text;
              tbKetQuaHocTap.DataSource = cls_BD.LayKetQuaHocTap(BD);

              //HIỂN THỊ KẾT QUẢ HỌC TẬP - ĐÀO TẠO CỦA SINH VIÊN.
              DataTable Bang = new DataTable();
              DataRow Hang;
              Bang = cls_BD.KetQuaTongKetDaoTao(BD);
              if (Bang.Rows.Count > 0) // Kiểm tra nếu có dữ liệu
              {
                  Hang = Bang.Rows[0];
                  txtSoTCTichLuy.Text = Hang[0].ToString();
                  txtDiemTLHe10.Text = Hang[1].ToString();
                  txtDiemTLHe4.Text = Hang[2].ToString();
              }
              else
              {
                  txtSoTCTichLuy.Text = "N/A";
                  txtDiemTLHe10.Text = "N/A";
                  txtDiemTLHe4.Text = "N/A";
                  MessageBox.Show("Không có dữ liệu tổng kết đào tạo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }


              XacNhanIn = 0;
          }
  *//*
        public KetQuaHocTapCuaSinhVien(SinhVien_ThongTin SV)
        {
            InitializeComponent();
            //LẤY DỮ LIỆU TỪ DANH SÁCH SINH VIÊN ĐỔ VỀ Ô TEXT.
            txtMaSo.Text = SV.MaSinhVien;
            txtHoTen.Text = SV.TenSinhVien;
            txtLop.Text = SV.Lop;
            //LOAD TOÀN BỘ DỮ LIỆU LÊN COMBOBOX.
            try
            {
                var hocKyData = cls_HK.DanhSachHocKy();
                var hocKyTable = DataConversion1.ConvertToDataTable1(hocKyData);
                if (hocKyTable != null)
                {
                    cbHocKy.DataSource = hocKyTable;
                    cbHocKy.DisplayMember = "TenHocKy";
                    cbHocKy.ValueMember = "MaHocKy";
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu học kỳ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải học kỳ: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            //LẤY RA TOÀN BỘ KẾT QUẢ HỌC TẬP CỦA SINH VIÊN.
            BangDiem_ThongTin BD = new BangDiem_ThongTin();
            BD.MaSinhVien = SV.MaSinhVien;
            tbKetQuaHocTap.DataSource = cls_BD.LayKetQuaHocTap(BD);
            //HIỂN THỊ KẾT QUẢ HỌC TẬP - ĐÀO TẠO CỦA SINH VIÊN.
            DataTable Bang = new DataTable();
            DataRow Hang;
            Bang = cls_BD.KetQuaTongKetDaoTao(BD);
            Hang = Bang.Rows[0];
            txtSoTCTichLuy.Text = Hang[0].ToString();
            txtDiemTLHe10.Text = Hang[1].ToString();
            txtDiemTLHe4.Text = Hang[2].ToString();

            XacNhanIn = 0;
        }

        private void ChonKyHoc_LoadDiem(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaSo.Text) || cbHocKy.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn học kỳ và mã sinh viên hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BangDiem_ThongTin BD = new BangDiem_ThongTin
                {
                    MaSinhVien = txtMaSo.Text,
                    MaHocKy = cbHocKy.SelectedValue.ToString()
                };

                var dataTable = cls_BD.LayDiemTheoKySinhVien(BD);

                if (dataTable.Rows.Count > 0)
                {
                    tbKetQuaHocTap.DataSource = dataTable;
                }
                else
                {
                    tbKetQuaHocTap.DataSource = null;
                    MessageBox.Show("Không có dữ liệu điểm trong kỳ học này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //KÍCH CHỌN XEM TẤT CẢ KẾT QUẢ HỌC TẬP.
        private void btAll_Click(object sender, EventArgs e)
        {
            txtSoTCDat.Text = "";
            txtDiemTBHe10.Text = "";
            txtDiemTBHe4.Text = "";
            SinhVien_ThongTin SV = new SinhVien_ThongTin();
            //LẤY RA TOÀN BỘ KẾT QUẢ HỌC TẬP CỦA SINH VIÊN.
            BangDiem_ThongTin BD = new BangDiem_ThongTin();
            BD.MaSinhVien = txtMaSo.Text;
            tbKetQuaHocTap.DataSource = cls_BD.LayKetQuaHocTap(BD);
            //HIỂN THỊ KẾT QUẢ HỌC TẬP - ĐÀO TẠO CỦA SINH VIÊN.
            DataTable Bang = new DataTable();
            DataRow Hang;
            Bang = cls_BD.KetQuaTongKetDaoTao(BD);
            Hang = Bang.Rows[0];
            txtSoTCTichLuy.Text = Hang[0].ToString();
            txtDiemTLHe10.Text = Hang[1].ToString();
            txtDiemTLHe4.Text = Hang[2].ToString();
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

            if (tbKetQuaHocTap.Rows.Count > 0 && DongChon >= 0 && DongChon < tbKetQuaHocTap.Rows.Count)
            {
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
            else
            {
                MessageBox.Show("Không có dữ liệu để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //LẤY DỮ LIỆU TRẢ VỀ
        public void LayDuLieu(BangDiem_ThongTin BD)
        {
            this.Ma = BD.MaSinhVien;
            if (!this.Ma.Equals(""))
            {
                tbKetQuaHocTap.DataSource = cls_BD.LayDiemTheoKySinhVien(BD);
            }
        }

        //IN BÁO CÁO
        *//*  private void btInBaoCao_Click(object sender, EventArgs e)
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
          }*//*
    }
}
*/
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

            // LẤY DỮ LIỆU TỪ DANH SÁCH SINH VIÊN ĐỔ VỀ Ô TEXT.
            txtMaSo.Text = SV.MaSinhVien;
            txtHoTen.Text = SV.TenSinhVien;
            txtLop.Text = SV.Lop;

            // LOAD TOÀN BỘ DỮ LIỆU HỌC KỲ LÊN COMBOBOX.
            var hocKyData = DataConversion1.ConvertToDataTable1(cls_HK.DanhSachHocKy());
            if (hocKyData != null && hocKyData.Rows.Count > 0)
            {
                cbHocKy.DataSource = hocKyData;
                cbHocKy.DisplayMember = "TenHocKy";
                cbHocKy.ValueMember = "MaHocKy";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu học kỳ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // LẤY TOÀN BỘ KẾT QUẢ HỌC TẬP CỦA SINH VIÊN.
            BangDiem_ThongTin BD = new BangDiem_ThongTin();
            BD.MaSinhVien = SV.MaSinhVien;

            // Hiển thị kết quả học tập
            var data = cls_BD.LayKetQuaHocTap(BD);
            if (data != null && data.Rows.Count > 0)
            {
                tbKetQuaHocTap.DataSource = data;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu kết quả học tập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // HIỂN THỊ KẾT QUẢ HỌC TẬP - ĐÀO TẠO
            var daoTaoData = cls_BD.KetQuaTongKetDaoTao(BD);
            if (daoTaoData != null && daoTaoData.Rows.Count > 0)
            {
                var row = daoTaoData.Rows[0];
                txtSoTCTichLuy.Text = row["SoTinChiTichLuy"].ToString();
                txtDiemTLHe10.Text = row["DiemTBHe10"].ToString();
                txtDiemTLHe4.Text = row["DiemTBHe4"].ToString();
            }
            else
            {
                txtSoTCTichLuy.Text = "0";
                txtDiemTLHe10.Text = "0";
                txtDiemTLHe4.Text = "0";
            }

            XacNhanIn = 0;
        }


        private void ChonKyHoc_LoadDiem(object sender, EventArgs e)
        {
            txtSoTCDat.Text = "";
            txtDiemTBHe10.Text = "";
            txtDiemTBHe4.Text = "";

            BangDiem_ThongTin BD = new BangDiem_ThongTin();
            BD.MaSinhVien = txtMaSo.Text;
            BD.MaHocKy = cbHocKy.SelectedValue.ToString();

            // Hiển thị kết quả học tập theo kỳ
            var data = cls_BD.LayDiemTheoKySinhVien(BD);
            if (data != null && data.Rows.Count > 0)
            {
                tbKetQuaHocTap.DataSource = data;
            }
            else
            {
                tbKetQuaHocTap.DataSource = null;
                MessageBox.Show("Không có dữ liệu điểm cho kỳ học này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // HIỂN THỊ KẾT QUẢ
            var soTinChiDat = cls_BD.SoTinChiDat(BD);
            if (soTinChiDat != null && soTinChiDat.Rows.Count > 0)
            {
                txtSoTCDat.Text = soTinChiDat.Rows[0]["SoTinChi"].ToString();
            }
            else
            {
                txtSoTCDat.Text = "0";
            }

            var tongKetHocKy = cls_BD.KetQuaTongKetHocKy(BD);
            if (tongKetHocKy != null && tongKetHocKy.Rows.Count > 0)
            {
                txtDiemTBHe10.Text = tongKetHocKy.Rows[0]["DiemTBHe10"].ToString();
                txtDiemTBHe4.Text = tongKetHocKy.Rows[0]["DiemTBHe4"].ToString();
            }
            else
            {
                txtDiemTBHe10.Text = "0";
                txtDiemTBHe4.Text = "0";
            }

            XacNhanIn = 1;
        }

        //KÍCH CHỌN XEM TẤT CẢ KẾT QUẢ HỌC TẬP.
        private void btAll_Click(object sender, EventArgs e)
        {
            txtSoTCDat.Text = "";
            txtDiemTBHe10.Text = "";
            txtDiemTBHe4.Text = "";

            BangDiem_ThongTin BD = new BangDiem_ThongTin();
            BD.MaSinhVien = txtMaSo.Text;

            // Hiển thị toàn bộ kết quả học tập
            var data = cls_BD.LayKetQuaHocTap(BD);
            if (data != null && data.Rows.Count > 0)
            {
                tbKetQuaHocTap.DataSource = data;
            }
            else
            {
                tbKetQuaHocTap.DataSource = null;
                MessageBox.Show("Không có dữ liệu kết quả học tập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Hiển thị tổng kết đào tạo
            var daoTaoData = cls_BD.KetQuaTongKetDaoTao(BD);
            if (daoTaoData != null && daoTaoData.Rows.Count > 0)
            {
                var row = daoTaoData.Rows[0];
                txtSoTCTichLuy.Text = row["SoTinChiTichLuy"].ToString();
                txtDiemTLHe10.Text = row["DiemTBHe10"].ToString();
                txtDiemTLHe4.Text = row["DiemTBHe4"].ToString();
            }
            else
            {
                txtSoTCTichLuy.Text = "0";
                txtDiemTLHe10.Text = "0";
                txtDiemTLHe4.Text = "0";
            }

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
            if (DongChon >= 0 && DongChon < tbKetQuaHocTap.Rows.Count)
            {
                ChucNang = "ChinhSua";

                BangDiem_ThongTin BD = new BangDiem_ThongTin
                {
                    MaSinhVien = txtMaSo.Text,
                    Stt = int.Parse(tbKetQuaHocTap.Rows[DongChon].Cells["STT"].Value.ToString()),
                    MaMonHoc = tbKetQuaHocTap.Rows[DongChon].Cells["MaMonHoc"].Value.ToString(),
                    MaHocKy = tbKetQuaHocTap.Rows[DongChon].Cells["MaHocKy"].Value.ToString(),
                    DiemQuaTrinh = float.Parse(tbKetQuaHocTap.Rows[DongChon].Cells["DiemQuaTrinh"].Value.ToString()),
                    DiemThi = float.Parse(tbKetQuaHocTap.Rows[DongChon].Cells["DiemThi"].Value.ToString())
                };

                A.GiaoDien.NhapDiem ND = new A.GiaoDien.NhapDiem(ChucNang, txtLop.Text, BD);
                ND.DuLieu = LayDuLieu;
                ND.ShowDialog(this);
            }
        }

        //LẤY DỮ LIỆU TRẢ VỀ
        public void LayDuLieu(BangDiem_ThongTin BD)
        {
            var data = cls_BD.LayDiemTheoKySinhVien(BD);
            if (data != null && data.Rows.Count > 0)
            {
                tbKetQuaHocTap.DataSource = data;
            }
            else
            {
                tbKetQuaHocTap.DataSource = null;
                MessageBox.Show("Không có dữ liệu điểm cho kỳ học này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        //IN BÁO CÁO
       /* private void btInBaoCao_Click(object sender, EventArgs e)
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
