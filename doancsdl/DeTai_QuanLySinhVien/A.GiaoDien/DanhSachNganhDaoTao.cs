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
    public partial class DanhSachNganhDaoTao : Form
    {
        //KHAI BÁO DÙNG CHUNG
        NganhDaoTao_B cls_NganhDaoTao = new NganhDaoTao_B();
        //
        string ChucNang = null;
        int DongChon = 0;
        int XacNhanXoa = 0;
        string MaKhoa = null;
        public DanhSachNganhDaoTao()
        {
            InitializeComponent();
        }
        //SAU KHI KHỞI TẠO
        private void DanhSachNganhDaoTao_Load(object sender, EventArgs e)
        {
            LoadDanhSachNganhDaoTao();
            txtTimKiem.Focus();
        }
        private void LoadDanhSachNganhDaoTao()
        {
            try
            {
                var data = cls_NganhDaoTao.DanhSachThongTinNganhDaoTao();
                tbNganhDaoTao.DataSource = DataConversion1.ConvertToDataTable1(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //LẤY DỮ LIỆU GỬI VỀ.
        public void LayDuLieu(NganhDaoTao_ThongTin NDT)
        {
            LoadDanhSachNganhDaoTao(); // Làm mới dữ liệu
            txtTimKiem.Focus();
        }

        //KHI KÍCH BUTTON THÊM
        private void ThemNganhDaoTao()
        {
            ChucNang = "F9";
            NganhDaoTao_ThongTin NDT = new NganhDaoTao_ThongTin();
            A.GiaoDien.QuanLyNganhDaoTao QLNDT = new A.GiaoDien.QuanLyNganhDaoTao(ChucNang, NDT);
            QLNDT.DuLieu = new QuanLyNganhDaoTao.DuLieuTruyenVe(LayDuLieu);
            QLNDT.ShowDialog(this);

            // Làm mới danh sách
            LoadDanhSachNganhDaoTao();
        }
        //
        private void btThem_Click(object sender, EventArgs e)
        {
            ThemNganhDaoTao();
            txtTimKiem.Focus();
        }
        //KHI KÍCH BUTTON SỬA THÔNG TIN
        private void SuaNganhDaoTao()
        {
            if (DongChon >= 0) // Kiểm tra dòng hợp lệ
            {
                // Lấy dữ liệu từ DataGridView
                string maNganh = tbNganhDaoTao.Rows[DongChon].Cells["ColumnMaNganh"].Value.ToString();
                string tenNganh = tbNganhDaoTao.Rows[DongChon].Cells["ColumnTenNganh"].Value.ToString();
                string maKhoa = tbNganhDaoTao.Rows[DongChon].Cells["ColumnMaKhoa"].Value?.ToString();
                // In ra để kiểm tra
                Console.WriteLine($"MaNganh: {maNganh}, TenNganh: {tenNganh}, MaKhoa: {maKhoa}");
                if (string.IsNullOrEmpty(maKhoa))
                {
                    MessageBox.Show("Không lấy được Mã Khoa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Truyền dữ liệu sang form sửa
                NganhDaoTao_ThongTin NDT = new NganhDaoTao_ThongTin
                {
                    MaNganh = maNganh,
                    TenNganh = tenNganh,
                    MaKhoa = maKhoa
                };

                QuanLyNganhDaoTao QLNDT = new QuanLyNganhDaoTao("F10", NDT);
                QLNDT.ShowDialog(this);

                // Làm mới danh sách
                LoadDanhSachNganhDaoTao();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng hợp lệ để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbNganhDaoTao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DongChon = e.RowIndex;
            XacNhanXoa = 1;
            txtTimKiem.Focus();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            SuaNganhDaoTao();
        }
        //XÓA NGÀNH ĐÀO TẠO.
        private void XoaNganhDaoTao()
        {
            if (XacNhanXoa == 1)
            {
                string maNganh = tbNganhDaoTao.Rows[DongChon].Cells["ColumnMaNganh"].Value.ToString();
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa ngành {maNganh} không?",
                                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        cls_NganhDaoTao.XoaNganhDaoTao(maNganh);
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Làm mới danh sách
                        LoadDanhSachNganhDaoTao();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ngành đào tạo cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            XoaNganhDaoTao();
        }

        private void KhiAnTimKiem(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string maNganh = txtTimKiem.Text.Trim();
                try
                {
                    var data = cls_NganhDaoTao.TimKiemThongTinNganhDaoTao(maNganh);
                    tbNganhDaoTao.DataSource = DataConversion1.ConvertToDataTable1(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void KhiKichDupChuot(object sender, MouseEventArgs e)
        {
            SuaNganhDaoTao();
            txtTimKiem.Focus();
        }

     /*   private void btInBaoCao_Click(object sender, EventArgs e)
        {
            NganhDaoTao_ThongTin NDT = new NganhDaoTao_ThongTin();
            NDT.MaNganh = txtTimKiem.Text;
            BaoCao.BaoCao.DuLieu = cls_NganhDaoTao.TimKiemThongTinNganhDaoTao(NDT);
            BaoCao.BaoCao.Kieu = "TimKiemNganhDaoTao";
            BaoCao.BaoCao BC = new BaoCao.BaoCao();
            BC.ShowDialog();
        }*/
    }
}
