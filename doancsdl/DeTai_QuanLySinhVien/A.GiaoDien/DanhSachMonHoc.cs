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
    public partial class DanhSachMonHoc : Form
    {
        //KHAI BÁO DÙNG CHUNG
        //MÔN HỌC
        MonHoc_B cls_MonHoc = new MonHoc_B();
        //
        string ChucNang = null;
        int DongChon = 0;
        int XacNhanXoa = 0;
        string MaMonHoc = null;
        public DanhSachMonHoc()
        {
            InitializeComponent();
        }
        //SAU KHI KHỞI TẠO
        private void DanhSachMonHoc_Load(object sender, EventArgs e)
        {
            try
            {
                var data = cls_MonHoc.DanhSachMonHocToanTruong();
                var dataTable = DataConversion1.ConvertToDataTable1(data);
                tbDanhSachMonHoc.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //LẤY DỮ LIỆU GỬI VỀ.
        public void LayDuLieu(MonHoc_ThongTin MonHoc )
        {
            // Nếu MonHoc không được truyền hoặc MaMonHoc rỗng, vẫn tải toàn bộ danh sách
            if (MonHoc == null || string.IsNullOrEmpty(MonHoc.MaMonHoc))
            {
                try
                {
                    var data = cls_MonHoc.DanhSachMonHocToanTruong();
                    var dataTable = DataConversion1.ConvertToDataTable1(data);
                    tbDanhSachMonHoc.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Nếu có MaMonHoc, tải theo điều kiện tìm kiếm cụ thể
                try
                {
                    var data = cls_MonHoc.TimMonHoc(MonHoc);
                    var dataTable = DataConversion1.ConvertToDataTable1(data);
                    tbDanhSachMonHoc.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            txtTimKiem.Focus();
        }


        //KHI KÍCH BUTTON THÊM
        private void ThemMonHoc()
        {
            ChucNang = "F9";
            MonHoc_ThongTin MonHoc = new MonHoc_ThongTin
            {
                MaMonHoc = "", // Giá trị mặc định ban đầu
                TenMonHoc = "",
                SoTinChi = 0
            };

            // Mở form thêm dữ liệu
            A.GiaoDien.MonHoc MH = new A.GiaoDien.MonHoc(ChucNang, MonHoc);
            MH.DuLieu = new MonHoc.DuLieuTruyenVe(LayDuLieu);
            MH.ShowDialog(this);

            // Làm mới danh sách từ CSDL
            LoadDanhSachMonHoc();
        }


        private void btThem_Click(object sender, EventArgs e)
        {
            ThemMonHoc();
            txtTimKiem.Focus();
        }
        //KHI KÍCH BUTTON SỬA THÔNG TIN
        private void SuaMonHoc()
        {
            ChucNang = "F10";
            MonHoc_ThongTin MonHoc = new MonHoc_ThongTin
            {
                MaMonHoc = tbDanhSachMonHoc.CurrentRow.Cells["ColumnMaMonHoc"].Value.ToString(),
                TenMonHoc = tbDanhSachMonHoc.CurrentRow.Cells["ColumnTenMonHoc"].Value.ToString(),
                SoTinChi = int.Parse(tbDanhSachMonHoc.CurrentRow.Cells["ColumnSoTinChi"].Value.ToString())
            };

            A.GiaoDien.MonHoc MH = new A.GiaoDien.MonHoc(ChucNang, MonHoc);
            MH.DuLieu = new MonHoc.DuLieuTruyenVe(LayDuLieu);
            MH.ShowDialog(this);

            // Làm mới dữ liệu sau khi sửa
            LoadDanhSachMonHoc();
        }
        private void LoadDanhSachMonHoc()
        {
            try
            {
                var data = cls_MonHoc.DanhSachMonHocToanTruong();
                var dataTable = DataConversion1.ConvertToDataTable1(data);
                tbDanhSachMonHoc.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            SuaMonHoc();
            txtTimKiem.Focus();
        }
        //KÍCH VÀO BẢNG
        private void tbDanhSachMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra chỉ số dòng hợp lệ
            {
                DongChon = e.RowIndex;
                XacNhanXoa = 1;
                txtTimKiem.Focus();
            }
            else
            {
                XacNhanXoa = 0;
            }
        }

        //XÓA MÔN HỌC
        private void XoaMonHoc()
        {
            if (XacNhanXoa == 1)
            {
                MonHoc_ThongTin MonHoc = new MonHoc_ThongTin
                {
                    MaMonHoc = tbDanhSachMonHoc.CurrentRow.Cells["ColumnMaMonHoc"].Value.ToString()
                };

                if (MessageBox.Show($"Bạn có thật sự muốn xóa thông tin môn học {MonHoc.MaMonHoc}?",
                                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        cls_MonHoc.XoaMonHoc(MonHoc);
                        LayDuLieu(new MonHoc_ThongTin());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể xóa dữ liệu này, lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                XacNhanXoa = 0;
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn môn học muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //
        private void btXoa_Click(object sender, EventArgs e)
        {
            XoaMonHoc();
            txtTimKiem.Focus();
        }

        private void KhiAnTimKiem(object sender, KeyEventArgs e)
        {
            if (!e.KeyValue.ToString().Equals("120") && !e.KeyValue.ToString().Equals("121") && !e.KeyValue.ToString().Equals("122") && !e.KeyValue.ToString().Equals("123"))
            {
                txtTimKiem.BackColor = Color.White;
                MonHoc_ThongTin MH = new MonHoc_ThongTin();
                MH.MaMonHoc = txtTimKiem.Text;
                tbDanhSachMonHoc.DataSource = cls_MonHoc.TimMonHoc(MH);
            }
            if (e.KeyValue.ToString().Equals("120"))
            {
                ThemMonHoc();
                txtTimKiem.Focus();
            }
            if (e.KeyValue.ToString().Equals("121"))
            {
                SuaMonHoc();
                txtTimKiem.Focus();
            }
            if (e.KeyValue.ToString().Equals("122"))
            {
                XoaMonHoc();
                txtTimKiem.Focus();
            }
            if (e.KeyValue.ToString().Equals("123"))
            {
                txtTimKiem.BackColor = Color.YellowGreen;
                txtTimKiem.Focus();
            }
            txtTimKiem.Focus();
        }

        private void KichDupChuot(object sender, MouseEventArgs e)
        {
            SuaMonHoc();
            txtTimKiem.Focus();
        }
        private void tbDanhSachMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DongChon = e.RowIndex;
                XacNhanXoa = 1;
            }
            else
            {
                XacNhanXoa = 0;
            }
        }
        /*private void btInBaoCao_Click(object sender, EventArgs e)
        {
            MonHoc_ThongTin MH = new MonHoc_ThongTin();
            MH.MaMonHoc = txtTimKiem.Text;
            BaoCao.BaoCao.DuLieu = cls_MonHoc.TimMonHoc(MH);
            BaoCao.BaoCao.Kieu = "TimKiemMonHoc";
            BaoCao.BaoCao BC = new BaoCao.BaoCao();
            BC.ShowDialog();
        }*/
    }
}
