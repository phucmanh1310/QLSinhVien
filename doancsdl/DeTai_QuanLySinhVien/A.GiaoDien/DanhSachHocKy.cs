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
            if (!this.MaHocKy.Equals(""))
            {
                try
                {
                    tbDanhSachHocKy.DataSource = cls_HocKy.DanhSachThongTinHocKy();
                }
                catch { }
            }
            txtTimKiem.Focus();
        }
        //KHI KÍCH BUTTON THÊM
        private void ThemHocKy()
        {
            ChucNang = "F9";
            HocKy_ThongTin HK = new HocKy_ThongTin();
            A.GiaoDien.QuanLyHocKy QLHK = new A.GiaoDien.QuanLyHocKy(ChucNang, HK);

            // Đăng ký delegate để làm mới dữ liệu
            QLHK.DuLieu = new QuanLyHocKy.DuLieuTruyenVe(LayDuLieu);
            QLHK.ShowDialog(this);

            RefreshDanhSach();
        }

        // Làm mới danh sách học kỳ
        private void RefreshDanhSach()
        {
            try
            {
                var data = cls_HocKy.DanhSachThongTinHocKy();

                if (data != null && data.Count > 0)
                {
                    // Kiểm tra và chuyển đổi dữ liệu đúng định dạng
                    var validData = data.Select(doc =>
                    {
                        // Tạo bản sao dữ liệu mới
                        var newDoc = new BsonDocument();
                        foreach (var field in doc.Elements)
                        {
                            if (field.Value.IsBsonBoolean) // Kiểm tra nếu là Boolean
                                newDoc.Add(field.Name, field.Value.AsBoolean.ToString());
                            else if (field.Value.IsBsonNull) // Xử lý null
                                newDoc.Add(field.Name, string.Empty);
                            else if (field.Value.IsBsonArray || field.Value.IsBsonDocument)
                                newDoc.Add(field.Name, field.Value.ToJson());
                            else
                                newDoc.Add(field.Name, field.Value.ToString());
                        }
                        return newDoc;
                    }).ToList();

                    tbDanhSachHocKy.DataSource = DataConversion1.ConvertToDataTable1(validData);
                }
                else
                {
                    tbDanhSachHocKy.DataSource = null;
                    MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi làm mới danh sách: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ChucNang = "F10";
            HocKy_ThongTin HK = new HocKy_ThongTin
            {
                MaHocKy = tbDanhSachHocKy.Rows[DongChon].Cells[0].Value.ToString(),
                TenHocKy = tbDanhSachHocKy.Rows[DongChon].Cells[1].Value.ToString()
            };

            A.GiaoDien.QuanLyHocKy QLHK = new A.GiaoDien.QuanLyHocKy(ChucNang, HK);

            // Đăng ký delegate để làm mới dữ liệu
            QLHK.DuLieu = new QuanLyHocKy.DuLieuTruyenVe(LayDuLieu);
            QLHK.ShowDialog(this);

            RefreshDanhSach();
        }

        //KÍCH VÀO BẢNG
        private void tbDanhSachHocKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DongChon = e.RowIndex;
                XacNhanXoa = 1; // Đánh dấu dòng đã chọn
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
                HocKy_ThongTin HocKy = new HocKy_ThongTin();
                HocKy.MaHocKy = tbDanhSachHocKy.Rows[DongChon].Cells[0].Value.ToString();

                if (MessageBox.Show($"Bạn có thật sự muốn xóa học kỳ {HocKy.MaHocKy} không?",
                                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        cls_HocKy.XoaHocKy(HocKy);
                        MessageBox.Show("Xóa học kỳ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDanhSach(); // Làm mới danh sách
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa học kỳ: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                XacNhanXoa = 0;
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn khóa học muốn xóa.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
