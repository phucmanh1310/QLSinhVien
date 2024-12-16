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
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using System.Collections.ObjectModel;

namespace A.GiaoDien
{
    public partial class DanhSachHocKy : Form
    {
        //KHAI BÁO DÙNG CHUNG
        //HỌC KỲ
        HocKy_B cls_HocKy = new HocKy_B();
        //
        string ChucNang = null;
        int DongChon = 0;
        int XacNhanXoa = 0;
        string MaHocKy = null;
        public DanhSachHocKy()
        {
            InitializeComponent();
        }
        //SAU KHI KHỞI TẠO.
        private void DanhSachHocKy_Load(object sender, EventArgs e)
        {
            try
            {
                List<BsonDocument> documents = cls_HocKy.DanhSachThongTinHocKy();
                if (documents.Count > 0)
                {
                    tbDanhSachHocKy.DataSource = DataConversion1.ConvertToDataTable1(documents);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu học kỳ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //LẤY DỮ LIỆU GỬI VỀ.
        public void LayDuLieu(HocKy_ThongTin HocKy)
        {
            this.MaHocKy = HocKy.MaHocKy;
            if (!string.IsNullOrEmpty(this.MaHocKy))
            {
                try
                {
                    // Gọi hàm RefreshDanhSach để làm sạch dữ liệu
                    RefreshDanhSach();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi làm mới dữ liệu sau khi thêm: {ex.Message}",
                                    "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txtTimKiem.Focus();
        }

        //KHI KÍCH BUTTON THÊM
        private void ThemHocKy()
        {
            ChucNang = "F9";
            HocKy_ThongTin HK = new HocKy_ThongTin();

            // Mở form thêm mới
            A.GiaoDien.QuanLyHocKy QLHK = new A.GiaoDien.QuanLyHocKy(ChucNang, HK);

            // Đăng ký delegate để làm mới dữ liệu
            QLHK.DuLieu = new QuanLyHocKy.DuLieuTruyenVe(LayDuLieu);

            // Hiển thị form thêm học kỳ
            if (QLHK.ShowDialog(this) == DialogResult.OK)
            {
                // Làm mới danh sách
                RefreshDanhSach();
            }
        }


        // Làm mới danh sách học kỳ
        private void RefreshDanhSach()
        {
            try
            {
                var data = cls_HocKy.DanhSachThongTinHocKy();

                if (data != null && data.Count > 0)
                {
                    DataTable table = new DataTable();

                    foreach (var field in data[0].Elements)
                    {
                        table.Columns.Add(field.Name, typeof(string));
                    }

                    foreach (var doc in data)
                    {
                        var row = table.NewRow();
                        foreach (var field in doc.Elements)
                        {
                            switch (field.Value.BsonType)
                            {
                                case BsonType.Boolean:
                                    row[field.Name] = field.Value.AsBoolean.ToString();
                                    break;
                                case BsonType.Null:
                                    row[field.Name] = string.Empty;
                                    break;
                                case BsonType.Array:
                                case BsonType.Document:
                                    row[field.Name] = field.Value.ToJson();
                                    break;
                                default:
                                    row[field.Name] = field.Value.ToString();
                                    break;
                            }
                        }
                        table.Rows.Add(row);
                    }

                    tbDanhSachHocKy.DataSource = table;

                    // Ẩn cột _id nếu có
                    if (tbDanhSachHocKy.Columns.Contains("_id"))
                    {
                        tbDanhSachHocKy.Columns["_id"].Visible = false;
                    }
                }
                else
                {
                    tbDanhSachHocKy.DataSource = null;
                    MessageBox.Show("Không có dữ liệu để hiển thị!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới danh sách: {ex.Message}",
                                "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btThem_Click(object sender, EventArgs e)
        {
            
            ThemHocKy();
            txtTimKiem.Focus();
        }

        //KHI KÍCH BUTTON SỬA THÔNG TIN
        private void SuaHocKy()
        {
            if (DongChon >= 0) // Kiểm tra dòng đã chọn
            {
                try
                {
                    // Chuyển đổi giá trị sang chuỗi
                    string maHocKy = tbDanhSachHocKy.Rows[DongChon].Cells["ColumnMaHocKy"].Value?.ToString() ?? "";
                    string tenHocKy = tbDanhSachHocKy.Rows[DongChon].Cells["ColumnTenHocKy"].Value?.ToString() ?? "";

                    if (string.IsNullOrEmpty(maHocKy))
                    {
                        MessageBox.Show("Không thể xác định mã học kỳ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    ChucNang = "F10";
                    HocKy_ThongTin HK = new HocKy_ThongTin
                    {
                        MaHocKy = maHocKy,
                        TenHocKy = tenHocKy
                    };

                    A.GiaoDien.QuanLyHocKy QLHK = new A.GiaoDien.QuanLyHocKy(ChucNang, HK);

                    // Đăng ký delegate để làm mới dữ liệu
                    QLHK.DuLieu = new QuanLyHocKy.DuLieuTruyenVe(LayDuLieu);
                    QLHK.ShowDialog(this);

                    RefreshDanhSach();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi sửa học kỳ: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }





        //KÍCH VÀO BẢNG
        private void tbDanhSachHocKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DongChon = e.RowIndex;
                XacNhanXoa = 1;

                // Kiểm tra dữ liệu
                string maHocKy = tbDanhSachHocKy.Rows[e.RowIndex].Cells["ColumnMaHocKy"].Value?.ToString();
                Console.WriteLine($"Mã Học Kỳ: {maHocKy}");
            }
        }


        private void tbDanhSachHocKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DongChon = e.RowIndex;
                XacNhanXoa = 1;
            }
        }
        //
        private void btSua_Click(object sender, EventArgs e)
        {
            SuaHocKy();
        }
        //XÓA HỌC KỲ
        private void XoaHocKy()
        {
            if (XacNhanXoa == 1)
            {
                try
                {
                    // Chuyển đổi giá trị sang chuỗi
                    string maHocKy = tbDanhSachHocKy.Rows[DongChon].Cells["ColumnMaHocKy"].Value?.ToString() ?? "";

                    if (string.IsNullOrEmpty(maHocKy))
                    {
                        MessageBox.Show("Không thể xác định mã học kỳ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (MessageBox.Show($"Bạn có thật sự muốn xóa học kỳ {maHocKy} không?",
                                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        HocKy_ThongTin HocKy = new HocKy_ThongTin { MaHocKy = maHocKy };
                        cls_HocKy.XoaHocKy(HocKy);
                        MessageBox.Show("Xóa học kỳ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDanhSach();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa học kỳ: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                XacNhanXoa = 0;
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn khóa học muốn xóa.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }





        //
        private void btXoa_Click(object sender, EventArgs e)
        {
            XoaHocKy();
        }

        private void KhiAnTimKiem(object sender, KeyEventArgs e)
        {
            try
            {
                HocKy_ThongTin HK = new HocKy_ThongTin
                {
                    MaHocKy = txtTimKiem.Text.Trim()
                };
                var results = cls_HocKy.TimKiemHocKy(HK);
                tbDanhSachHocKy.DataSource = DataConversion1.ConvertToDataTable1(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void KichDupChuot(object sender, MouseEventArgs e)
        {
            SuaHocKy();
            txtTimKiem.Focus();
        }

       /* private void btInBaoCao_Click(object sender, EventArgs e)
        {
            HocKy_ThongTin HK = new HocKy_ThongTin();
            HK.MaHocKy = txtTimKiem.Text;
            BaoCao.BaoCao.DuLieu = cls_HocKy.TimKiemHocKy(HK);
            BaoCao.BaoCao.Kieu = "TimKiemHocKy";
            BaoCao.BaoCao BC = new BaoCao.BaoCao();
            BC.ShowDialog();
        }*/
        
    }
}
