﻿using System;
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
    public partial class QuanLyLopHoc : Form
    {
        //KHAI BÁO DÙNG CHUNG
        //BẢNG HÊ ĐÀO TẠO
        HeDaoTao_B cls_HDT = new HeDaoTao_B();
        //BẢNG KHÓA HOC
        KhoaHoc_B cls_KH = new KhoaHoc_B();
        //BẢNG NGÀNH ĐÀO TẠO
        NganhDaoTao_B cls_NDT = new NganhDaoTao_B();
        //Khoa
        Khoa_B cls_Khoa = new Khoa_B();
        //BẢNG LỚP
        Lop_B cls_LOP = new Lop_B();
        string ChucNang = null;
        public QuanLyLopHoc(string ChucNang, Lop_ThongTin Lop)
        {
            InitializeComponent();
            LoadComboBoxData(); // Gọi hàm load dữ liệu cho Combobox

            this.ChucNang = ChucNang;

            if (ChucNang.Equals("F9")) // Thêm mới
            {
                txtMaLop.Focus();
                btHoanTat.Enabled = false;
            }
            else if (ChucNang.Equals("F10")) // Sửa
            {
                // Set dữ liệu lớp học
                txtMaLop.Text = Lop.MaLop;
                txtTenLop.Text = Lop.TenLop;

                // Set SelectedValue cho Combobox
                cbKhoaHoc.SelectedValue = Lop.MaKhoaHoc;
                cbHeDaoTao.SelectedValue = Lop.MaHeDaoTao;
                cbTenNganh.SelectedValue = Lop.MaNganh;

                btHoanTat.Enabled = false;
                txtMaLop.Enabled = false;
                txtTenLop.Focus();
            }
        }


        private void LoadComboBoxData()
        {
            try
            {
                // Load Hệ Đào Tạo
                var heDaoTaoData = cls_HDT.DanhSachHeDaoTao();

                if (heDaoTaoData != null && heDaoTaoData.Rows.Count > 0)
                {
                    cbHeDaoTao.DataSource = heDaoTaoData;
                    cbHeDaoTao.DisplayMember = "TenHe";
                    cbHeDaoTao.ValueMember = "MaHe";
                }

                // Load Khóa Học
                var khoaHocData = cls_KH.DanhSachKhoaHoc();
                var khoaHocTable = DataConversion1.ConvertToDataTable1(khoaHocData);

                if (khoaHocTable != null && khoaHocTable.Rows.Count > 0)
                {
                    cbKhoaHoc.DataSource = khoaHocTable;
                    cbKhoaHoc.DisplayMember = "MaKhoaHoc";
                    cbKhoaHoc.ValueMember = "MaKhoaHoc";
                }

                // Load Ngành Đào Tạo
                var nganhDaoTaoData = cls_NDT.DanhSachNganhDaoTao();
                var nganhDaoTaoTable = DataConversion1.ConvertToDataTable1(nganhDaoTaoData);

                if (nganhDaoTaoTable != null && nganhDaoTaoTable.Rows.Count > 0)
                {
                    cbTenNganh.DataSource = nganhDaoTaoTable;
                    cbTenNganh.DisplayMember = "TenNganh";
                    cbTenNganh.ValueMember = "MaNganh";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //DỮ LIỆU TRUYỀN VỀ.
        public delegate void DuLieuTruyenVe(Lop_ThongTin Lop);
        public DuLieuTruyenVe DuLieu;
        //
        private void QuanLyLopHoc_Load(object sender, EventArgs e)
        {

        }
        //THÊM LỚP HỌC MỚI.
        private void ThemMoiLopHoc()
        {
            Lop_ThongTin LOP = new Lop_ThongTin();
            LOP.MaLop = txtMaLop.Text;
            LOP.TenLop = txtTenLop.Text;
            LOP.MaKhoaHoc = cbKhoaHoc.SelectedValue.ToString();
            LOP.MaHeDaoTao = cbHeDaoTao.SelectedValue.ToString();
            LOP.MaNganh = cbTenNganh.SelectedValue.ToString();
            try
            {
                cls_LOP.ThemLopHocMoi(LOP);
                MessageBox.Show("Bạn đã thêm lớp học " + LOP.TenLop + " với mã " + LOP.MaLop + " vào hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);

                // Xóa dữ liệu input cũ
                txtMaLop.Text = "";
                txtTenLop.Text = "";
                txtMaLop.Focus();
                var KhoaHocData = cls_KH.DanhSachKhoaHoc();
                if (KhoaHocData != null && KhoaHocData.Count > 0)
                {
                    cbHeDaoTao.DataSource = KhoaHocData;
                    cbHeDaoTao.DisplayMember = "MaKhoaHoc"; // Tên hiển thị
                    cbHeDaoTao.ValueMember = "MaKhoaHoc";   // Giá trị thực tế
                }
                else
                {
                    MessageBox.Show("Dữ liệu Hệ Đào Tạo không hợp lệ.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                var heDaoTaoData = cls_HDT.DanhSachHeDaoTao();
                if (heDaoTaoData != null )
                {
                    cbHeDaoTao.DataSource = heDaoTaoData;
                    /* cbHeDaoTao.DisplayMember = "TenHe"; // Tên hiển thị
                     cbHeDaoTao.ValueMember = "MaHe";  // Giá trị thực tế*/

                    cbHeDaoTao.DisplayMember = "MaHe"; // Tên hiển thị
                    cbHeDaoTao.ValueMember = "MaHe";  // Giá trị thực tế
                }
                else
                {
                    MessageBox.Show("Dữ liệu Hệ Đào Tạo không hợp lệ.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                /*               // Load lại ComboBox để tránh lỗi binding
                               cbHeDaoTao.DataSource = cls_HDT.DanhSachHeDaoTao();
                               cbHeDaoTao.DisplayMember = "TenHe";
                               cbHeDaoTao.ValueMember = "MaHe";*/
               
                /*     cbKhoaHoc.DataSource = cls_KH.DanhSachKhoaHoc();
                     cbKhoaHoc.DisplayMember = "MaKhoaHoc";
                     cbKhoaHoc.ValueMember = "MaKhoaHoc";*/
                var Nganh = cls_NDT.DanhSachNganhDaoTao();
                if (Nganh != null && Nganh.Count > 0)
                {
                    cbHeDaoTao.DataSource = KhoaHocData;
                    /*  cbHeDaoTao.DisplayMember = "TenNganh"; // Tên hiển thị
                      cbHeDaoTao.ValueMember = "MaNganh";   // Giá trị thực tế*/
                    cbHeDaoTao.DisplayMember = "TenNganh"; // Tên hiển thị
                    cbHeDaoTao.ValueMember = "MaNganh";   // Giá trị thực tế
                }
                else
                {
                    MessageBox.Show("Dữ liệu Hệ Đào Tạo không hợp lệ.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                var KhoaData = cls_Khoa.DanhSachKhoa();
                if (KhoaData != null && KhoaData.Count > 0)
                {
                    cbHeDaoTao.DataSource = KhoaHocData;
                    /*  cbHeDaoTao.DisplayMember = "TenNganh"; // Tên hiển thị
                      cbHeDaoTao.ValueMember = "MaNganh";   // Giá trị thực tế*/
                    cbHeDaoTao.DisplayMember = "TenKhoa"; // Tên hiển thị
                    cbHeDaoTao.ValueMember = "MaKhoa";   // Giá trị thực tế
                }
                else
                {
                    MessageBox.Show("Dữ liệu Hệ Đào Tạo không hợp lệ.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*  cbTenNganh.DataSource = cls_NDT.DanhSachNganhDaoTao();
                  cbTenNganh.DisplayMember = "TenNganh";
                  cbTenNganh.ValueMember = "MaNganh";*/

                btHoanTat.Enabled = true;

                if (DuLieu != null)
                {
                    DuLieu(LOP);
                }
            }
            catch
            {
                MessageBox.Show("Không thể thêm mới, hãy xem xét lại!.", "Thông báo lỗi.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //SỬA THÔNG TIN LỚP HỌC.
        private void SuaThongTinLopHoc()
        {
            Lop_ThongTin LOP = new Lop_ThongTin();
            LOP.MaLop = txtMaLop.Text;
            LOP.TenLop = txtTenLop.Text;
            LOP.MaKhoaHoc = cbKhoaHoc.SelectedValue.ToString();
            LOP.MaHeDaoTao = cbHeDaoTao.SelectedValue.ToString();
            LOP.MaNganh = cbTenNganh.SelectedValue.ToString();
            try
            {
                cls_LOP.SuaThongTinLopHoc(LOP);
                MessageBox.Show("Bạn sửa thông tin lớp học có mã " + LOP.MaLop + " trong hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                if (DuLieu != null)
                {
                    DuLieu(LOP);
                }
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Không thể chỉnh sửa, hãy xem xét lại!.", "Thông báo lỗi.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //KHI ẤN NÚT XÁC NHẬN
        private void btXacNhan_Click(object sender, EventArgs e)
        {
            if (ChucNang.Equals("F9")) // Thêm mới
            {
                ThemMoiLopHoc();
            }
            else if (ChucNang.Equals("F10")) // Sửa
            {
                SuaThongTinLopHoc();
            }
        }


        //TẮT.
        private void btHoanTat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //PHÍM TẮT ENTER DÙNG KHI SỬA MÔN HỌC.
        private void KhiAnEnTerOTenLop(object sender, KeyEventArgs e)
        {
            if (ChucNang.Equals("F10"))
            {
                if (e.KeyValue.ToString() == "13")
                {
                    SuaThongTinLopHoc();
                }
            }
        }

        private void TimKiemNganhDaoTao(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Nhấn Enter
            {
                string tenNganh = cbTenNganh.Text; // Lấy tên ngành từ ComboBox
                var result = cls_NDT.TimKiemNganhDaoTao(tenNganh); // Gọi phương thức tìm kiếm

                // Chuyển kết quả sang DataTable
                DataTable dataTable = DataConversion1.ConvertToDataTable1(result);

                // Bind dữ liệu
                cbTenNganh.DataSource = dataTable;
                cbTenNganh.DisplayMember = "TenNganh";
                cbTenNganh.ValueMember = "MaNganh";
            }
        }



    }
}
