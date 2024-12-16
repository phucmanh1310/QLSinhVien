using System;
using System.Windows.Forms;
using D.ThongTin;
using B.ThaoTac;

namespace A.GiaoDien
{
    public partial class QuanLyHocKy : Form
    {
        // KHAI BÁO DÙNG CHUNG
        HocKy_B cls_HocKy = new HocKy_B();
        string ChucNang = null;

        public QuanLyHocKy(string ChucNang, HocKy_ThongTin HK)
        {
            InitializeComponent();
            this.ChucNang = ChucNang;

            if (this.ChucNang.Equals("F9")) // Thêm học kỳ
            {
                txtMaHocKy.Enabled = true;
                txtMaHocKy.Focus();
                btHoanTat.Enabled = false;
            }
            else if (this.ChucNang.Equals("F10")) // Sửa học kỳ
            {
                txtMaHocKy.Text = HK.MaHocKy;
                txtTenHocKy.Text = HK.TenHocKy;
                txtMaHocKy.Enabled = false; // Không cho sửa mã học kỳ
                txtTenHocKy.Focus();
            }
        }

        // DỮ LIỆU TRUYỀN VỀ
        // Delegate để truyền dữ liệu về form cha
        public delegate void DuLieuTruyenVe(HocKy_ThongTin HK);
        public DuLieuTruyenVe DuLieu;

        // THÊM HỌC KỲ MỚI
        private void ThemHocKy()
        {
            if (string.IsNullOrWhiteSpace(txtMaHocKy.Text) || string.IsNullOrWhiteSpace(txtTenHocKy.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã học kỳ và tên học kỳ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HocKy_ThongTin HK = new HocKy_ThongTin
            {
                MaHocKy = txtMaHocKy.Text.Trim(),
                TenHocKy = txtTenHocKy.Text.Trim()
            };

            try
            {
                cls_HocKy.ThemHocKy(HK);
                MessageBox.Show($"Thêm học kỳ {HK.MaHocKy} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gửi dữ liệu về form cha
                DuLieu?.Invoke(HK);
                this.Close(); // Đóng form sau khi thêm thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm học kỳ: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // CHỈNH SỬA HỌC KỲ
        private void SuaHocKy()
        {
            if (string.IsNullOrWhiteSpace(txtTenHocKy.Text))
            {
                MessageBox.Show("Vui lòng nhập tên học kỳ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HocKy_ThongTin HK = new HocKy_ThongTin
            {
                MaHocKy = txtMaHocKy.Text.Trim(),
                TenHocKy = txtTenHocKy.Text.Trim()
            };

            try
            {
                cls_HocKy.SuaHocKy(HK);
                MessageBox.Show($"Chỉnh sửa học kỳ {HK.MaHocKy} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gửi dữ liệu về form cha
                DuLieu?.Invoke(HK);
                this.Close(); // Đóng form sau khi sửa thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chỉnh sửa học kỳ: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btXacNhan_Click(object sender, EventArgs e)
        {
            if (this.ChucNang.Equals("F9"))
            {
                ThemHocKy();
            }
            else if (this.ChucNang.Equals("F10"))
            {
                SuaHocKy();
            }
        }

        // CLICK HỦY
        private void btHoanTat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuanLyHocKy_Load(object sender, EventArgs e)
        {
            txtMaHocKy.Focus();
        }
    }
}
