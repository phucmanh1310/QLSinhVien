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
    public partial class QuanLyTaiKhoan : Form
    {
        //KHAI BÁO DÙNG CHUNG
        DangNhap_B cls_DangNhap = new DangNhap_B();
        //
        string ChucNang = null;
        public QuanLyTaiKhoan(string ChucNang, DangNhap_ThongTin DN)
        {
            InitializeComponent();

            // Lấy danh sách quyền từ MongoDB
            var quyenList = cls_DangNhap.DanhSachQuyen();

            if (quyenList != null && quyenList.Count > 0)
            {
                cbQuyen.DataSource = quyenList;
                cbQuyen.SelectedIndex = 0;       // Chọn giá trị mặc định đầu tiên
            }
            else
            {
                MessageBox.Show("Danh sách quyền rỗng, không thể hiển thị!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cbQuyen.DataSource = quyenList;
            this.ChucNang = ChucNang;

            if (this.ChucNang.Equals("F9"))
            {
                txtTaiKhoan.Focus();
                btHoanTat.Enabled = false;
            }
            if (this.ChucNang.Equals("F10")) // Chế độ sửa tài khoản
            {
                txtTaiKhoan.Text = DN.TaiKhoan;
                cbQuyen.SelectedItem = DN.Quyen;
                txtMatKhau.Text = DN.MatKhau; // Hiển thị mật khẩu vào txtMatKhau
                btHoanTat.Enabled = false;
                txtTaiKhoan.Enabled = false;
            }
        }

        //DỮ LIỆU TRUYỀN VỀ.
        public delegate void DuLieuTruyenVe(DangNhap_ThongTin DN);
        public DuLieuTruyenVe DuLieu;
        //THÊM TÀI KHOẢN MỚI.
        private void ThemTaiKhoan()
        {
            DangNhap_ThongTin DN = new DangNhap_ThongTin();
            DN.TaiKhoan = txtTaiKhoan.Text.Trim(); // Lấy giá trị từ TextBox TaiKhoan

            // Kiểm tra giá trị của ComboBox Quyền
            if (cbQuyen.SelectedItem == null || string.IsNullOrEmpty(cbQuyen.SelectedItem.ToString()))
            {
                MessageBox.Show("Vui lòng chọn quyền trước khi thêm tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DN.Quyen = cbQuyen.SelectedItem.ToString();

            // Lấy giá trị mật khẩu từ txtMatKhau
            if (string.IsNullOrEmpty(txtMatKhau.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                return;
            }
            DN.MatKhau = txtMatKhau.Text.Trim();

            try
            {
                if (!string.IsNullOrEmpty(DN.TaiKhoan))
                {
                    cls_DangNhap.ThemTaiKhoan(DN);
                    MessageBox.Show($"Thêm tài khoản '{DN.TaiKhoan}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hãy nhập tên tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTaiKhoan.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //CHỈNH SỬA TÀI KHOẢN.
        private void SuaTaiKhoan()
        {
            DangNhap_ThongTin DN = new DangNhap_ThongTin
            {
                TaiKhoan = txtTaiKhoan.Text,
                Quyen = cbQuyen.SelectedValue.ToString()
            };
            if (cbQuyen.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn quyền hợp lệ trước khi sửa tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DN.Quyen = cbQuyen.SelectedValue.ToString();

            try
            {
                cls_DangNhap.ChinhSuaQuyen(DN);
                MessageBox.Show($"Chỉnh sửa tài khoản '{DN.TaiKhoan}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DuLieu?.Invoke(DN); // Gửi dữ liệu về form cha
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chỉnh sửa tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btHoanTat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Focus();
        }

        private void btXacNhan_Click(object sender, EventArgs e)
        {
            if (this.ChucNang.Equals("F9"))
            {
                ThemTaiKhoan();
            }
            if (this.ChucNang.Equals("F10"))
            {
                SuaTaiKhoan();
            }
        }
    }
}
