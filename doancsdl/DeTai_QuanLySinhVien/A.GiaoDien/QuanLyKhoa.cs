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
    public partial class QuanLyKhoa : Form
    {
        //KHAI BÁO DÙNG CHUNG
        //BẢNG KHOA
        Khoa_B cls_Khoa = new Khoa_B();
        //
        string ChucNang = null;
        public QuanLyKhoa(string ChucNang, Khoa_ThongTin K)
        {
            InitializeComponent();
            this.ChucNang = ChucNang;
            if (this.ChucNang.Equals("F9"))
            {
                txtMaKhoa.Focus();
                btHoanTat.Enabled = false;
            }
            if (this.ChucNang.Equals("F10"))
            {
                txtMaKhoa.Text = K.MaKhoa;
                txtTenKhoa.Text = K.TenKhoa;
                btHoanTat.Enabled = false;
                txtMaKhoa.Enabled = false;
                txtTenKhoa.Focus();
            }
        }

        //
        private void QuanLyKhoa_Load(object sender, EventArgs e)
        {
            txtMaKhoa.Focus();
        }
        //DỮ LIỆU TRUYỀN VỀ.
        public delegate void DuLieuTruyenVe(Khoa_ThongTin K);
        public DuLieuTruyenVe DuLieu;
        //THÊM KHOA MỚI.
        private void ThemKhoa()
        {
            Khoa_ThongTin K = new Khoa_ThongTin
            {
                MaKhoa = txtMaKhoa.Text.Trim(),
                TenKhoa = txtTenKhoa.Text.Trim()
            };

            try
            {
                cls_Khoa.ThemKhoa(K);
                MessageBox.Show($"Thêm khoa {K.MaKhoa} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gọi delegate để cập nhật dữ liệu trên form cha
                DuLieu?.Invoke(K);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm khoa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //CHỈNH SỬA KHOA.
        private void SuaKhoa()
        {
            Khoa_ThongTin K = new Khoa_ThongTin
            {
                MaKhoa = txtMaKhoa.Text.Trim(),
                TenKhoa = txtTenKhoa.Text.Trim()
            };

            try
            {
                cls_Khoa.SuaKhoa(K);
                MessageBox.Show($"Chỉnh sửa khoa {K.MaKhoa} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gọi delegate để cập nhật dữ liệu trên form cha
                DuLieu?.Invoke(K);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chỉnh sửa khoa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btHoanTat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btXacNhan_Click(object sender, EventArgs e)
        {
            if (this.ChucNang.Equals("F9"))
            {
                ThemKhoa();
            }
            else if (this.ChucNang.Equals("F10"))
            {
                SuaKhoa();
            }

            // Đặt DialogResult để form cha biết thao tác đã hoàn thành
            this.DialogResult = DialogResult.OK;
            this.Close(); // Đóng form
        }

    }
}
