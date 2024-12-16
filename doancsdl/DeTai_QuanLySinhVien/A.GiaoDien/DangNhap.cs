using System;
using System.Windows.Forms;
using D.ThongTin;
using B.ThaoTac;

namespace A.GiaoDien
{
    public partial class DangNhap : Form
    {
        DangNhap_B cls_DangNhap = new DangNhap_B();

        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhapTaiKhoan()
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                MessageBox.Show("Bạn hãy nhập tài khoản của mình", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.None);
                txtTaiKhoan.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Bạn hãy nhập mật khẩu của mình", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.None);
                txtMatKhau.Focus();
                return;
            }

            // Tạo đối tượng thông tin đăng nhập
            DangNhap_ThongTin DN = new DangNhap_ThongTin
            {
                TaiKhoan = txtTaiKhoan.Text,
                MatKhau = txtMatKhau.Text
            };

            try
            {
                // Thực hiện kiểm tra đăng nhập bằng MongoDB
                var result = cls_DangNhap.KiemTraDangNhap(DN);

                if (result != null && result.Count > 0) // Kiểm tra danh sách có dữ liệu không
                {
                    // Lấy thông tin tài khoản từ MongoDB
                    var user = result[0]; // BsonDocument đầu tiên trong danh sách
                    DN.Quyen = user["Quyen"].ToString();
                    DN.TrangThai = true;

                    // Cập nhật trạng thái
                    cls_DangNhap.UpDateTrangThai(DN);

                    // Mở form GiaoDienChinh và truyền thông tin đăng nhập
                    A.GiaoDien.GiaoDienChinh GDC = new A.GiaoDien.GiaoDienChinh(DN);
                    this.Hide(); // Ẩn form đăng nhập
                    GDC.ShowDialog();
                    this.Close(); // Đóng form đăng nhập sau khi GiaoDienChinh đóng
                }
                else
                {
                    // Nếu danh sách rỗng, thông báo lỗi
                    MessageBox.Show("Tài khoản hoặc mật khẩu của bạn bị sai, hãy kiểm tra lại!", "Thông báo lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Text = "";
                    txtTaiKhoan.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btDangNhap_Click(object sender, EventArgs e)
        {
            DangNhapTaiKhoan();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
