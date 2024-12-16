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
    public partial class KhoaHoc : Form
    {
        //KHAI BÁO DÙNG CHUNG
        //KHÓA HỌC
        KhoaHoc_B cls_KhoaHoc = new KhoaHoc_B();
        string ChucNang = null;
        public KhoaHoc(string ChucNang, KhoaHoc_ThongTin KhoaHoc)
        {
            InitializeComponent();
            this.ChucNang = ChucNang;
            if (this.ChucNang.Equals("F9"))
            {
                txtMaKhoaHoc.Focus();
                btHoanTat.Enabled = false;
            }
            if (this.ChucNang.Equals("F10"))
            {
                txtMaKhoaHoc.Text = KhoaHoc.MaKhoaHoc;

                // Sử dụng ConvertBsonDateTimeToDateTime để chuyển đổi ngày
                txtNgayBatDau.Value = DataConversion1.ConvertBsonDateTimeToDateTime(new BsonDateTime(KhoaHoc.NgayBatDau));
                txtNgayKetThuc.Value = DataConversion1.ConvertBsonDateTimeToDateTime(new BsonDateTime(KhoaHoc.NgayKetThuc));

                btHoanTat.Enabled = false;
                txtMaKhoaHoc.Enabled = false;
            }
        }
        //DỮ LIỆU TRUYỀN VỀ.
        public delegate void DuLieuTruyenVe(KhoaHoc_ThongTin KhoaHoc);
        public DuLieuTruyenVe DuLieu;
        //THÊM KHÓA HỌC MỚI.
        private void ThemKhoaHoc()
        {
            KhoaHoc_ThongTin KH = new KhoaHoc_ThongTin();
            KH.MaKhoaHoc = txtMaKhoaHoc.Text;
            KH.NgayBatDau = txtNgayBatDau.Value;
            KH.NgayKetThuc = txtNgayKetThuc.Value;

            try
            {
                if (string.IsNullOrWhiteSpace(KH.MaKhoaHoc))
                {
                    MessageBox.Show("Hãy nhập mã khóa học", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaKhoaHoc.Focus();
                    return;
                }

                // Kiểm tra ngày hợp lệ
                if (KH.NgayBatDau >= KH.NgayKetThuc)
                {
                    MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgayBatDau.Focus();
                    return;
                }

                cls_KhoaHoc.ThemKhoaHoc(KH);
                MessageBox.Show($"Đã thêm khóa học {KH.MaKhoaHoc} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm mới, lỗi: " + ex.Message, "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtMaKhoaHoc.Text = "";
            txtMaKhoaHoc.Focus();
            btHoanTat.Enabled = true;

            DuLieu?.Invoke(KH); // Truyền dữ liệu về form cha
        }

        //CHỈNH SỬA KHÓA HỌC.
        private void ChinhSuaKhoaHoc()
        {
            KhoaHoc_ThongTin KH = new KhoaHoc_ThongTin();
            KH.MaKhoaHoc = txtMaKhoaHoc.Text;
            KH.NgayBatDau = txtNgayBatDau.Value;
            KH.NgayKetThuc = txtNgayKetThuc.Value;

            try
            {
                if (KH.NgayBatDau >= KH.NgayKetThuc)
                {
                    MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgayBatDau.Focus();
                    return;
                }

                cls_KhoaHoc.ChinhSuaKhoaHoc(KH);
                MessageBox.Show($"Đã cập nhật thông tin khóa học {KH.MaKhoaHoc} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể chỉnh sửa, lỗi: " + ex.Message, "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DuLieu?.Invoke(KH); // Truyền dữ liệu về form cha
            this.Hide();
        }

        //KHI CLICK XÁC NHẬN.
        private void btXacNhan_Click(object sender, EventArgs e)
        {
            if (this.ChucNang.Equals("F9"))
            {
                ThemKhoaHoc();
            }
            if (this.ChucNang.Equals("F10"))
            {
                ChinhSuaKhoaHoc();
            }
        }

        private void btHoanTat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
