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
    public partial class DanhSachKhoa : Form
    {
        //KHAI BÁO DÙNG CHUNG
        Khoa_B cls_Khoa = new Khoa_B();
        //
        string ChucNang = null;
        int DongChon = 0;
        int XacNhanXoa = 0;
        string MaKhoa = null;
        public DanhSachKhoa()
        {
            InitializeComponent();
        }
        //SAU KHI KHỞI TẠO
        private void DanhSachKhoa_Load(object sender, EventArgs e)
        {
            try
            {
                var data = cls_Khoa.DanhSachKhoa(); // Lấy dữ liệu MongoDB
                var dataTable = DataConversion1.ConvertToDataTable1(data); // Chuyển đổi dữ liệu
                tbKhoa.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtTimKiem.Focus();
        }

        // Hàm chuyển đổi BsonDocument sang DataTable

        //LẤY DỮ LIỆU GỬI VỀ.
        public void LayDuLieu(Khoa_ThongTin K)
        {
            this.MaKhoa = K.MaKhoa;
            if (!string.IsNullOrEmpty(this.MaKhoa))
            {
                try
                {
                    tbKhoa.DataSource = cls_Khoa.DanhSachKhoa();
                }
                catch { }
            }
            txtTimKiem.Focus();
        }
        //KHI KÍCH BUTTON THÊM
        private void ThemKhoa()
        {
            ChucNang = "F9";
            Khoa_ThongTin Khoa = new Khoa_ThongTin();
            QuanLyKhoa QLHK = new QuanLyKhoa(ChucNang, Khoa);

            if (QLHK.ShowDialog(this) == DialogResult.OK)
            {
                RefreshDanhSach(); // Làm mới danh sách sau khi thêm thành công
            }
        }


        private void btThem_Click(object sender, EventArgs e)
        {
            ThemKhoa();
        }
        //KHI KÍCH BUTTON SỬA THÔNG TIN
        private void SuaKhoa()
        {
            if (DongChon >= 0)
            {
                string maKhoa = tbKhoa.Rows[DongChon].Cells["ColumnMaKhoa"].Value.ToString();
                string tenKhoa = tbKhoa.Rows[DongChon].Cells["ColumnTenKhoa"].Value.ToString();

                Khoa_ThongTin Khoa = new Khoa_ThongTin
                {
                    MaKhoa = maKhoa,
                    TenKhoa = tenKhoa
                };

                ChucNang = "F10";
                QuanLyKhoa QLHK = new QuanLyKhoa(ChucNang, Khoa);

                if (QLHK.ShowDialog(this) == DialogResult.OK)
                {
                    RefreshDanhSach(); // Làm mới danh sách sau khi sửa thành công
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng hợp lệ để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshDanhSach()
        {
            try
            {
                var data = cls_Khoa.DanhSachKhoa(); // Lấy dữ liệu từ MongoDB
                var dataTable = DataConversion1.ConvertToDataTable1(data); // Chuyển đổi dữ liệu sang DataTable
                tbKhoa.DataSource = dataTable; // Gán vào DataGridView

                // Ẩn cột _id nếu tồn tại
                if (tbKhoa.Columns.Contains("_id"))
                {
                    tbKhoa.Columns["_id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lại dữ liệu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tbKhoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DongChon = e.RowIndex;
            XacNhanXoa = 1;
            txtTimKiem.Focus();
        }
        //XÓA KHÓA
        private void XoaKhoa()
        {
            if (DongChon >= 0)
            {
                string maKhoa = tbKhoa.Rows[DongChon].Cells["ColumnMaKhoa"].Value.ToString();
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa khoa có mã {maKhoa}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Khoa_ThongTin Khoa = new Khoa_ThongTin { MaKhoa = maKhoa };
                        cls_Khoa.XoaKhoa(Khoa);
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Làm mới danh sách sau khi xóa
                        RefreshDanhSach();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng hợp lệ để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //
        private void btXoa_Click(object sender, EventArgs e)
        {
            XoaKhoa();
            txtTimKiem.Focus();
        }

        private void KhiAnTimKiem(object sender, KeyEventArgs e)
        {
            if (!e.KeyValue.ToString().Equals("120") && !e.KeyValue.ToString().Equals("121") && !e.KeyValue.ToString().Equals("122") && !e.KeyValue.ToString().Equals("123"))
            {
                txtTimKiem.BackColor = Color.White;
                Khoa_ThongTin K = new Khoa_ThongTin();
                K.MaKhoa = txtTimKiem.Text;
                tbKhoa.DataSource = cls_Khoa.TimKiemKhoa(K);
            }
            if (e.KeyValue.ToString().Equals("120"))
            {
                ThemKhoa();
                txtTimKiem.Focus();
            }
            if (e.KeyValue.ToString().Equals("121"))
            {
                SuaKhoa();
                txtTimKiem.Focus();
            }
            if (e.KeyValue.ToString().Equals("122"))
            {
                XoaKhoa();
                txtTimKiem.Focus();
            }
            if (e.KeyValue.ToString().Equals("123"))
            {
                txtTimKiem.BackColor = Color.YellowGreen;
                txtTimKiem.Focus();
            }
            txtTimKiem.Focus();
        }

        private void KhiKichDupChuot(object sender, MouseEventArgs e)
        {
            SuaKhoa();
            txtTimKiem.Focus();
            XacNhanXoa = 0;
        }
        //KÍCH SỬA
        private void btSua_Click(object sender, EventArgs e)
        {
            SuaKhoa();
        }

        private void tbKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không chọn vào tiêu đề
            {
                DongChon = e.RowIndex;
                XacNhanXoa = 1;
            }
        }

        /*  private void btInBaoCao_Click(object sender, EventArgs e)
          {
              Khoa_ThongTin Khoa = new Khoa_ThongTin();
              Khoa.MaKhoa = txtTimKiem.Text;
              BaoCao.BaoCao.DuLieu = cls_Khoa.TimKiemKhoa(Khoa);
              BaoCao.BaoCao.Kieu = "TimKiemKhoa";
              BaoCao.BaoCao BC = new BaoCao.BaoCao();
              BC.ShowDialog();
          }*/
    }
}
