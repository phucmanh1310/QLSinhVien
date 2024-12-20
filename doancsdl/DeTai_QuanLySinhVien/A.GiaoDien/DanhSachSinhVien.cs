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
using A.GiaoDien.BaoCao;
using MongoDB.Bson;

namespace A.GiaoDien
{
    public partial class DanhSachSinhVien : Form
    {
        //KHAI BÁO DÙNG CHUNG.
        //BẢNG SINH VIÊN.
        SinhVien_B cls_SinhVien = new SinhVien_B();

        string ChucNang = null;
        string Ma = null;
        int DongChon = 0;
        int KiemTraXoa = 0;
        public DanhSachSinhVien()
        {
            InitializeComponent();
        }
        //LẤY RA DANH SÁCH SINH VIÊN.
        private void DanhSachSinhVien_Load(object sender, EventArgs e)
        {
            LoadDanhSachSinhVien();
            txtTimKiem.Focus();
        }
        private void LoadDanhSachSinhVien()
        {
            try
            {
                var data = cls_SinhVien.DanhSachSinhVien();
                var dataTable = DataConversion1.ConvertToDataTable1(data);

                // Xóa cột _id nếu có
                if (dataTable.Columns.Contains("_id"))
                    dataTable.Columns.Remove("_id");

                tbDanhSachSinhVien.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //TÌM KIẾM SINH VIÊN THEO MÃ SỐ, HỌ TÊN, LỚP.
        private void TimKiem(object sender, KeyEventArgs e)
        {
            if (!e.KeyValue.ToString().Equals("112") && !e.KeyValue.ToString().Equals("120") && !e.KeyValue.ToString().Equals("121") && !e.KeyValue.ToString().Equals("122") && !e.KeyValue.ToString().Equals("123") && !e.KeyValue.ToString().Equals("13"))
            {
                txtTimKiem.BackColor = Color.White;
                SinhVien_ThongTin SV = new SinhVien_ThongTin();
                SV.MaSinhVien = txtTimKiem.Text;
                tbDanhSachSinhVien.DataSource = cls_SinhVien.TimKiemSinhVien(SV);
            }
            if (e.KeyValue.ToString() == "120")
            {
                ThemSinhVien();
            }
            if (e.KeyValue.ToString() == "121")
            {
                SuaSinhVien();
            }
            if (e.KeyValue.ToString() == "122")
            {
                XoaSinhVien();
            }
            if (e.KeyValue.ToString() == "112")
            {
                XemKetQuaHocTap();
            }
            if (e.KeyValue.ToString() == "123")
            {
                txtTimKiem.BackColor = Color.YellowGreen;
                txtTimKiem.Focus();
            }
        }
        //KHI CHỌN THÊM SINH VIÊN.
        private void ThemSinhVien()
        {
            ChucNang = "F9";
            SinhVien_ThongTin SV = new SinhVien_ThongTin();
            A.GiaoDien.QuanLySinhVien QLSV = new A.GiaoDien.QuanLySinhVien(ChucNang, SV);
            QLSV.DuLieu = new QuanLySinhVien.DuLieuTruyenVe(LayDuLieu);
            QLSV.ShowDialog(this);
            LoadDanhSachSinhVien(); // Tải lại danh sách sau khi thêm
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            ThemSinhVien();
        }
        //#Truyền dữ liệu.
        public void LayDuLieu(SinhVien_ThongTin SV)
        {
            LoadDanhSachSinhVien(); // Làm mới dữ liệu
            txtTimKiem.Focus();
        }

        //KHI CHỌN SỬA THÔNG TIN SINH VIÊN.
        private void SuaSinhVien()
        {
            ChucNang = "F10";
            SinhVien_ThongTin SV = new SinhVien_ThongTin();
            SV.MaSinhVien = tbDanhSachSinhVien.Rows[DongChon].Cells["colMaSinhVien"].Value.ToString();
            SV.TenSinhVien = tbDanhSachSinhVien.Rows[DongChon].Cells["colTenSinhVien"].Value.ToString();
            SV.DiaChi = tbDanhSachSinhVien.Rows[DongChon].Cells["colDiaChi"].Value.ToString();
            SV.NgaySinh = DateTime.Parse(tbDanhSachSinhVien.Rows[DongChon].Cells["colNgaySinh"].Value.ToString());
            SV.Lop = tbDanhSachSinhVien.Rows[DongChon].Cells["colLop"].Value.ToString();

            A.GiaoDien.QuanLySinhVien QLSV = new A.GiaoDien.QuanLySinhVien(ChucNang, SV);
            QLSV.DuLieu = new QuanLySinhVien.DuLieuTruyenVe(LayDuLieu);
            QLSV.ShowDialog(this);
            LoadDanhSachSinhVien(); // Tải lại danh sách sau khi sửa
        }


        private void btSua_Click(object sender, EventArgs e)
        {
            KiemTraXoa = 0;
            SuaSinhVien();
        }
        //KÍCH VÀO BẢNG SINH VIÊN.
        private void tbDanhSachSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            KiemTraXoa = 1;
            DongChon = e.RowIndex;
            txtTimKiem.Focus();
        }
        //XÓA SINH VIÊN.
        private void XoaSinhVien()
        {
            if (KiemTraXoa == 1)
            {
                string maSV = tbDanhSachSinhVien.Rows[DongChon].Cells[0].Value.ToString();
                if (MessageBox.Show($"Bạn có muốn xóa sinh viên {maSV} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        cls_SinhVien.XoaSinhVien(maSV);
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachSinhVien(); // Tải lại danh sách sau khi xóa
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            XoaSinhVien();
            txtTimKiem.Focus();
        }
        //XEM KẾT QUẢ HỌC TẬP CỦA SINH VIÊN
        private void XemKetQuaHocTap()
        {
            SinhVien_ThongTin SV = new SinhVien_ThongTin();
            SV.MaSinhVien = tbDanhSachSinhVien.Rows[DongChon].Cells["colMaSinhVien"].Value.ToString();
            SV.TenSinhVien = tbDanhSachSinhVien.Rows[DongChon].Cells["colTenSinhVien"].Value.ToString();
            SV.Lop = tbDanhSachSinhVien.Rows[DongChon].Cells["colLop"].Value.ToString();

            A.GiaoDien.KetQuaHocTapCuaSinhVien KQHT = new A.GiaoDien.KetQuaHocTapCuaSinhVien(SV);
            KQHT.ShowDialog(this);
            txtTimKiem.Focus();
        }
        //KÍCH ĐÚP CHUỘT
        private void DupChuot_XemKetQuaHocTap(object sender, MouseEventArgs e)
        {
            XemKetQuaHocTap();
        }
        //KÍCH BUTTON XEM ĐIỂM.
        private void btXemDiem_Click(object sender, EventArgs e)
        {
            XemKetQuaHocTap();
        }

        private void tbDanhSachSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu chỉ số dòng hợp lệ
            {
                DongChon = e.RowIndex; // Gán dòng được chọn vào biến DongChon
            }
        }



        //IN BÁO CÁO
        /* private void btInBaoCao_Click(object sender, EventArgs e)
         {
             SinhVien_ThongTin SV = new SinhVien_ThongTin();
             SV.MaSinhVien = txtTimKiem.Text;
             BaoCao.BaoCao.DuLieu = cls_SinhVien.TimKiemSinhVien(SV);
             BaoCao.BaoCao.Kieu = "TimKiemSinhVien";
             BaoCao.BaoCao BC = new BaoCao.BaoCao();
             BC.ShowDialog();
         }*/

    }
}
