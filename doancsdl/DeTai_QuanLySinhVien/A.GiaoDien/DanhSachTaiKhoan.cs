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
    public partial class DanhSachTaiKhoan : Form
    {
        //KHAI BÁO DÙNG CHUNG
        DangNhap_B cls_DangNhap = new DangNhap_B();
        //
        string ChucNang = null;
        int DongChon = 0;
        int XacNhanXoa = 0;
        string TaiKhoan = null;
        public DanhSachTaiKhoan()
        {
            InitializeComponent();
        }
        //SAU KHI KOWIR TẠO
        private void DanhSachTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadDanhSachTaiKhoan();
            txtTimKiem.Focus();
        }
        private void LoadDanhSachTaiKhoan()
        {
            try
            {
                var data = cls_DangNhap.DanhSachTaiKhoan(); // Gọi dữ liệu từ MongoDB
                tbDanhSachTaiKhoan.DataSource = DataConversion1.ConvertToDataTable1(data); // Chuyển đổi BsonDocument sang DataTable
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //LẤY DỮ LIỆU GỬI VỀ.
        public void LayDuLieu(DangNhap_ThongTin DN)
        {
            LoadDanhSachTaiKhoan(); // Làm mới danh sách tài khoản
            txtTimKiem.Focus();
        }

        //KHI KÍCH BUTTON THÊM
        private void ThemTaiKhoan()
        {
            ChucNang = "F9";
            DangNhap_ThongTin DangNhap = new DangNhap_ThongTin(); 
            A.GiaoDien.QuanLyTaiKhoan QLTK = new A.GiaoDien.QuanLyTaiKhoan(ChucNang, DangNhap);
            QLTK.DuLieu = new QuanLyTaiKhoan.DuLieuTruyenVe(LayDuLieu);
            QLTK.ShowDialog(this);
            XacNhanXoa = 0;
            txtTimKiem.Focus();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            ThemTaiKhoan();
            LoadDanhSachTaiKhoan(); // Cập nhật danh sách
            txtTimKiem.Focus();
        }

        //KHI KÍCH BUTTON SỬA THÔNG TIN
        private void SuaTaiKhoan()
        {
            ChucNang = "F10";

            DangNhap_ThongTin DangNhap = new DangNhap_ThongTin
            {
                TaiKhoan = tbDanhSachTaiKhoan.Rows[DongChon].Cells["ColumnTaiKhoan"].Value.ToString(),
                Quyen = tbDanhSachTaiKhoan.Rows[DongChon].Cells["ColumnQuyen"].Value.ToString(),
                MatKhau = tbDanhSachTaiKhoan.Rows[DongChon].Cells["ColumnMatKhau"].Value.ToString() // Lấy mật khẩu từ cột DataGridView
            };

            A.GiaoDien.QuanLyTaiKhoan QLTK = new A.GiaoDien.QuanLyTaiKhoan(ChucNang, DangNhap);
            QLTK.DuLieu = new QuanLyTaiKhoan.DuLieuTruyenVe(LayDuLieu);
            QLTK.ShowDialog(this);
            XacNhanXoa = 0;
            txtTimKiem.Focus();
        }

        //KÍCH SỬA
        private void btSua_Click(object sender, EventArgs e)
        {
            SuaTaiKhoan();
            LoadDanhSachTaiKhoan(); // Cập nhật danh sách
            txtTimKiem.Focus();
        }

        //KÍCH VÀO BẢNG
        private void tbDanhSachTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DongChon = e.RowIndex;
            XacNhanXoa = 1;
            txtTimKiem.Focus();
        }
        //XÓA TÀI KHOẢN
        private void XoaTaiKhoan()
        {
            if (XacNhanXoa == 1)
            {
                DangNhap_ThongTin DangNhap = new DangNhap_ThongTin
                {
                    TaiKhoan = tbDanhSachTaiKhoan.Rows[DongChon].Cells[0].Value.ToString()
                };

                if (MessageBox.Show($"Bạn có chắc muốn xóa tài khoản '{DangNhap.TaiKhoan}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        cls_DangNhap.XoaTaiKhoan(DangNhap);
                        MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachTaiKhoan(); // Cập nhật danh sách
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                XacNhanXoa = 0;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //
        private void btXoa_Click(object sender, EventArgs e)
        {
            XoaTaiKhoan();
        }

        private void KhiAnTimKiem(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap_ThongTin DN = new DangNhap_ThongTin
                {
                    TaiKhoan = txtTimKiem.Text.Trim()
                };

                try
                {
                    var data = cls_DangNhap.TimKiemTaiKhoan(DN);
                    tbDanhSachTaiKhoan.DataSource = DataConversion1.ConvertToDataTable1(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void KichDup(object sender, MouseEventArgs e)
        {
            SuaTaiKhoan();
            txtTimKiem.Focus();
        }

        private void tbDanhSachTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DongChon = e.RowIndex;
            XacNhanXoa = 1;
            txtTimKiem.Focus();
        }

        /* private void btInBaoCao_Click(object sender, EventArgs e)
         {
             DangNhap_ThongTin DN = new DangNhap_ThongTin();
             DN.TaiKhoan = txtTimKiem.Text;
             BaoCao.BaoCao.DuLieu = cls_DangNhap.TimKiemTaiKhoan(DN);
             BaoCao.BaoCao.Kieu = "TimKiemTaiKhoan";
             BaoCao.BaoCao BC = new BaoCao.BaoCao();
             BC.ShowDialog();
         }*/
    }
}
