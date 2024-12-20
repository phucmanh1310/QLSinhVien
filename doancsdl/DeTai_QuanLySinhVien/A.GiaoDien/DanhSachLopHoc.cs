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
    public partial class DanhSachLopHoc : Form
    {
        //KHAI BÁO DÙNG CHUNG.
        //BẢNG LỚP HOC.
        Lop_B cls_Lop = new Lop_B();

        int DongChon = 0;
        string ChucNang = null;
        string MaLop = null;
        public DanhSachLopHoc()
        {
            InitializeComponent();
        }
        private void DanhSachLopHoc_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            txtTimKiem.Focus();
        }
        public void LoadDataGridView()
        {
            try
            {
                var data = cls_Lop.DanhSach_ThongTin_DayDu();
                if (data != null && data.Count > 0)
                {
                    var dataTable = DataConversion1.ConvertToDataTable1(data);
                    tbDanhSachLopHoc.AutoGenerateColumns = false; // Ngăn tự tạo cột
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        Console.WriteLine(col.ColumnName); // Debug tên các cột
                    }
                    tbDanhSachLopHoc.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu lớp học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //KHI KICH DUP CHUỘT CHỌN LỚP NHẬP ĐIỂM.
        /* private void NhapDiemChoLop()
         {
             if (DongChon >= 0)
             {
                 string maLop = tbDanhSachLopHoc.Rows[DongChon].Cells["colMaLop"].Value.ToString();
                 var BD = new BangDiem_ThongTin();

                 A.GiaoDien.NhapDiem ND = new A.GiaoDien.NhapDiem("F1", maLop, BD);
                 ND.ShowDialog();
             }
             else
             {
                 MessageBox.Show("Vui lòng chọn một lớp học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
         }*/
        private void NhapDiemChoLop()
        {
            if (DongChon >= 0)
            {
                ChucNang = "F1";
                string maLop = tbDanhSachLopHoc.Rows[DongChon].Cells["colMaLop"].Value?.ToString();
                if (!string.IsNullOrEmpty(maLop))
                {
                    Console.WriteLine($"MaLop: {maLop}"); // Debug giá trị
                    BangDiem_ThongTin BD = new BangDiem_ThongTin();
                    A.GiaoDien.NhapDiem formNhapDiem = new A.GiaoDien.NhapDiem(ChucNang, maLop, BD);
                    formNhapDiem.ShowDialog(this);
                    XacNhanXoa = "0";
                    txtTimKiem.Focus();
                }
                else
                {
                    MessageBox.Show("Mã lớp không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void KhiChonLopNhapDiem(object sender, MouseEventArgs e)
          {
              if (tbDanhSachLopHoc.SelectedRows.Count > 0)
              {
                  NhapDiemChoLop();
              }
              else
              {
                  MessageBox.Show("Vui lòng chọn một lớp học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              }
          }
  
     


        //KHI CHỌN LỚP HỌC.
        private void tbDanhSachLopHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            XacNhanXoa = "1";
            DongChon = e.RowIndex;
            txtTimKiem.Focus();
        }
        //KHI CHỌN NHẬP ĐIỂM
        private void btNhapDiem_Click(object sender, EventArgs e)
        {
            NhapDiemChoLop();
        }
        //TÌM KIẾM VÀ PHÍM TẮT
        private void KhiTimKiem_PhimTat(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Nhấn Enter
            {
                try
                {
                    Lop_ThongTin Lop = new Lop_ThongTin();
                    Lop.TenLop = txtTimKiem.Text;

                    // Gọi hàm tìm kiếm từ lớp B
                    var data = cls_Lop.TimKiemLopHoc(Lop);
                    var dataTable = DataConversion1.ConvertToDataTable1(data);

                    tbDanhSachLopHoc.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //KÍCH CHỌN THÊM LỚP HỌC MỚI.
        private void ThemLopHoc()
        {
            ChucNang = "F9";
            Lop_ThongTin lop = new Lop_ThongTin();
            A.GiaoDien.QuanLyLopHoc QLLH = new QuanLyLopHoc(ChucNang, lop);
            QLLH.DuLieu = new QuanLyLopHoc.DuLieuTruyenVe(LayDuLieu); // Callback để làm mới DataGridView
            QLLH.ShowDialog(this);

            RefreshDataGridView();
            txtTimKiem.Focus();
        }

      

        private void btThem_Click(object sender, EventArgs e)
        {
            ThemLopHoc();
        }
        //LẤY DỮ LIỆU TRUYỀN VỀ.
        public void LayDuLieu(Lop_ThongTin lop)
        {
            this.MaLop = lop.MaLop;
            if (!string.IsNullOrEmpty(MaLop))
            {
                RefreshDataGridView();
            }
        }

    
        //KÍCH CHỌN SỬA THÔNG TIN LỚP HỌC.
        private void SuaThongTinLopHoc()
        {
            if (DongChon >= 0)
            {
                ChucNang = "F10";
                Lop_ThongTin lop = new Lop_ThongTin
                {
                    MaLop = tbDanhSachLopHoc.Rows[DongChon].Cells["colMaLop"].Value.ToString(),
                    TenLop = tbDanhSachLopHoc.Rows[DongChon].Cells["colTenLop"].Value.ToString(),
                    MaKhoaHoc = tbDanhSachLopHoc.Rows[DongChon].Cells["colMaKhoaHoc"].Value.ToString(),
                    MaHeDaoTao = tbDanhSachLopHoc.Rows[DongChon].Cells["colMaHe"].Value.ToString(),
                    MaNganh = tbDanhSachLopHoc.Rows[DongChon].Cells["colMaNganh"].Value.ToString()
                };

                QuanLyLopHoc QLLH = new QuanLyLopHoc(ChucNang, lop);
                QLLH.DuLieu = LayDuLieu; // Callback để làm mới DataGridView
                QLLH.ShowDialog();
                RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một lớp học để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void btSua_Click(object sender, EventArgs e)
        {
            SuaThongTinLopHoc();
        }
        string XacNhanXoa = "0";
        //XÓA LỚP HỌC
        private void XoaLopHoc()
        {
            if (DongChon >= 0)
            {
                var lop = new Lop_ThongTin
                {
                    MaLop = tbDanhSachLopHoc.Rows[DongChon].Cells[0].Value.ToString()
                };

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa lớp học {lop.MaLop}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        cls_Lop.XoaLopHoc(lop);
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDataGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một lớp học để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void RefreshDataGridView()
        {
            try
            {
                tbDanhSachLopHoc.DataSource = null; // Reset DataSource
                var data = cls_Lop.DanhSach_ThongTin_DayDu();
                var dataTable = DataConversion1.ConvertToDataTable1(data);

                // Kiểm tra và xóa cột không cần thiết
                if (dataTable.Columns.Contains("_id"))
                    dataTable.Columns.Remove("_id");

                tbDanhSachLopHoc.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btXoa_Click(object sender, EventArgs e)
        {
            XoaLopHoc();
        }

      private void tbDanhSachLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
{
    if (e.RowIndex >= 0) // Kiểm tra hàng hợp lệ
    {
        DongChon = e.RowIndex; // Lưu chỉ số dòng được chọn
    }
}


        //IN BÁO CÁO
        /*   private void btInBaoCao_Click(object sender, EventArgs e)
           {
               Lop_ThongTin Lop = new Lop_ThongTin();
               Lop.MaLop = txtTimKiem.Text;
               BaoCao.BaoCao.DuLieu = cls_Lop.TimKiemLopHoc(Lop);
               BaoCao.BaoCao.Kieu = "TimKiemLopHoc";
               BaoCao.BaoCao BC = new BaoCao.BaoCao();
               BC.ShowDialog();
           }*/
    }
}
