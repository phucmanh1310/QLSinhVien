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
    public partial class QuanLySinhVien : Form
    {
        //KHAI BÁO DÙNG CHUNG.
        //BẢNG LỚP
        Lop_B cls_Lop = new Lop_B();
        //BẢNG SINH VIÊN.
        SinhVien_B cls_SinhVien = new SinhVien_B();

        bool GioiTinh;
        bool DienUuTien;
        string ChucNang = null;
        public QuanLySinhVien(string ChucNang, SinhVien_ThongTin SV)
        {
            InitializeComponent();

            var danhSachLop = cls_Lop.DanhSachLop();
            var dataTable = DataConversion1.ConvertToDataTable1(danhSachLop);

            // Load danh sách lớp
            if (dataTable != null && dataTable.Columns.Contains("TenLop") && dataTable.Columns.Contains("MaLop"))
            {
                cbLop.DataSource = dataTable;
                cbLop.DisplayMember = "TenLop";
                cbLop.ValueMember = "MaLop";
            }
            else
            {
                MessageBox.Show("Dữ liệu lớp không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.ChucNang = ChucNang;

            if (ChucNang.Equals("F10")) // Sửa thông tin sinh viên
            {
                txtMaSinhVien.Enabled = false;
                txtMaSinhVien.Text = SV.MaSinhVien;
                txtTenSinhVien.Text = SV.TenSinhVien;
                txtNgaySinh.Value = SV.NgaySinh;

                if (SV.GioiTinh)
                    raNam.Checked = true;
                else
                    raNu.Checked = true;

                // Gán lớp mặc định (kiểm tra trước khi gán)
                if (!string.IsNullOrEmpty(SV.Lop))
                    cbLop.SelectedValue = SV.Lop;

                // Gán địa chỉ (kiểm tra trước khi gán)
                txtDiaChi.Text = SV.DiaChi ?? ""; // Đảm bảo không bị null

                if (SV.ChinhSachUuTien)
                    raCo.Checked = true;
                else
                    raKhong.Checked = true;
            }
        }





        private void QuanLySinhVien_Load(object sender, EventArgs e)
        {
            txtMaSinhVien.Focus();
            btHoanTat.Enabled = false;
        }
        //TRUYỀN DỮ LIỆU - THÊM SỬA XÓA SINH VIÊN.
        public delegate void DuLieuTruyenVe(SinhVien_ThongTin SV);
        public DuLieuTruyenVe DuLieu;
        private void SuaThongTinSinhVien()
        {
            SinhVien_ThongTin SV = new SinhVien_ThongTin
            {
                MaSinhVien = txtMaSinhVien.Text,
                TenSinhVien = txtTenSinhVien.Text,
                NgaySinh = txtNgaySinh.Value,
                GioiTinh = raNam.Checked,
                Lop = cbLop.SelectedValue.ToString(),
                DiaChi = txtDiaChi.Text,
                ChinhSachUuTien = raCo.Checked
            };

            try
            {
                cls_SinhVien.SuaThongTinSinhVien(SV);
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
        }


        //
        private void btThem_Click(object sender, EventArgs e)
        {
            if (ChucNang.Equals("F9"))
            {
                btHoanTat.Enabled = true;
                et1.Enabled = false;
                et2.Enabled = false;
                try
                {
                    SinhVien_ThongTin SV = new SinhVien_ThongTin();
                    SV.MaSinhVien = txtMaSinhVien.Text;
                    SV.TenSinhVien = txtTenSinhVien.Text;
                    SV.NgaySinh = txtNgaySinh.Value;
                    SV.GioiTinh = GioiTinh;
                    SV.Lop = cbLop.SelectedValue.ToString();
                    SV.DiaChi = txtDiaChi.Text;
                    SV.ChinhSachUuTien = DienUuTien;               
                    cls_SinhVien.ThemSinhVien(SV);
                    MessageBox.Show($"Thêm mới thành công sinh viên {SV.TenSinhVien}, mã số {SV.MaSinhVien}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTrang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm sinh viên: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (ChucNang.Equals("F10"))
            {
                SuaThongTinSinhVien();
            }
        }
        //LOAD MỚI 1 TRANG
        public void LoadTrang()
        {
            txtMaSinhVien.Focus();
            txtMaSinhVien.Text = "";
            txtTenSinhVien.Text = "";
            txtNgaySinh.Text = "";
            cbLop.Text = "";
            txtDiaChi.Text = "";
            raCo.Checked = false;
            raKhong.Checked = false;
            raNam.Checked = false;
            raNu.Checked = false;
        }       
        //CÁC BIẾN CỜ.
        private void raCo_CheckedChanged(object sender, EventArgs e)
        {
            DienUuTien = true;
        }

        private void raKhong_CheckedChanged(object sender, EventArgs e)
        {
            DienUuTien = false;
        }

        private void raNam_CheckedChanged(object sender, EventArgs e)
        {
            GioiTinh = true;
        }

        private void raNu_CheckedChanged(object sender, EventArgs e)
        {
            GioiTinh = false;
        }
        //KHI THÊM MỚI XONG
        private void btHoanTat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void EnterTenSinhVien(object sender, KeyEventArgs e)
        {
            if (ChucNang.Equals("F10"))
            {
                if (e.KeyValue.ToString() == "13")
                {
                    SuaThongTinSinhVien();
                }
            }
        }

        private void EnterDiaChi(object sender, KeyEventArgs e)
        {
            if (ChucNang.Equals("F10"))
            {
                if (e.KeyValue.ToString() == "13")
                {
                    SuaThongTinSinhVien();
                }
            }
        }
    }
}
