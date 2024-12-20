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
    public partial class QuanLyNganhDaoTao : Form
    {
        //KHAI BÁO DUNG CHUNG
        //BẢNG KHOA
        Khoa_B cls_Khoa = new Khoa_B();
        //BẢNG NGÀNH ĐÀO TẠO
        NganhDaoTao_B cls_NganhDaoTao = new NganhDaoTao_B();
        //
        string ChucNang = null;
        public QuanLyNganhDaoTao(string ChucNang, NganhDaoTao_ThongTin NDT)
        {
            InitializeComponent();
            this.ChucNang = ChucNang;
            if (this.ChucNang.Equals("F9"))
            {
                txtMaNganh.Focus();
                btHoanTat.Enabled = false;
            }
            if (this.ChucNang.Equals("F10"))
            {
                txtMaNganh.Text = NDT.MaNganh;
                txtTenNganh.Text = NDT.TenNganh;
                cbTenKhoa.SelectedValue = NDT.MaKhoa;
                btHoanTat.Enabled = false;
                txtMaNganh.Enabled = false;
                txtTenNganh.Focus();
            }
        }

        private void QuanLyNganhDaoTao_Load(object sender, EventArgs e)
        {
            var data = cls_Khoa.DanhSachKhoa();
            var table = DataConversion1.ConvertToDataTable1(data);
            //LOAD O COMBOBOX
            cbTenKhoa.DataSource = table; // Lấy danh sách khoa
            cbTenKhoa.DisplayMember = "TenKhoa";            // Hiển thị Tên Khoa
            cbTenKhoa.ValueMember = "MaKhoa";               // Giá trị là MaKhoa
            txtMaNganh.Focus();
        }
        //DỮ LIỆU TRUYỀN VỀ.
        public delegate void DuLieuTruyenVe(NganhDaoTao_ThongTin NDT);
        public DuLieuTruyenVe DuLieu;
        //THÊM NGÀNH ĐÀO TẠO MỚI.
        private void ThemNganhDaoTao()
        {
            if (string.IsNullOrWhiteSpace(txtMaNganh.Text) || string.IsNullOrWhiteSpace(txtTenNganh.Text))
            {
                MessageBox.Show("Mã ngành và tên ngành không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NganhDaoTao_ThongTin NDT = new NganhDaoTao_ThongTin
            {
                MaNganh = txtMaNganh.Text.Trim(),
                TenNganh = txtTenNganh.Text.Trim(),
                MaKhoa = cbTenKhoa.SelectedValue.ToString()
            };

            try
            {
                cls_NganhDaoTao.ThemNganhDaoTao(NDT);
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DuLieu?.Invoke(NDT); // Truyền dữ liệu về Form cha
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //CHỈNH SỬA KHOA.
        private void SuaNganhDaoTao()
        {
            NganhDaoTao_ThongTin NDT = new NganhDaoTao_ThongTin
            {
                MaNganh = txtMaNganh.Text.Trim(),
                TenNganh = txtTenNganh.Text.Trim(),
                MaKhoa = cbTenKhoa.SelectedValue.ToString()
            };

            try
            {
                cls_NganhDaoTao.SuaNganhDaoTao(NDT);
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DuLieu?.Invoke(NDT);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        private void btXacNhan_Click(object sender, EventArgs e)
        {
            if (this.ChucNang.Equals("F9"))
            {
                ThemNganhDaoTao();
            }
            if (this.ChucNang.Equals("F10"))
            {
                SuaNganhDaoTao();
            }
        }

        private void btHoanTat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
