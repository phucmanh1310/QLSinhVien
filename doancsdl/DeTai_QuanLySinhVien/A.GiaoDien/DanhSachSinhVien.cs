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
            txtTimKiem.Focus();

            // Lấy dữ liệu từ MongoDB
            List<BsonDocument> documents = cls_SinhVien.DanhSachSinhVien();

            // Chuyển đổi sang DataTable
            DataTable table = DataConversion1.ConvertToDataTable1(documents);

            // Gán vào DataGridView
            tbDanhSachSinhVien.DataSource = table;
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
            SinhVien_ThongTin SV = new SinhVien_ThongTin();
            ChucNang = "F9";
            A.GiaoDien.QuanLySinhVien QLSV = new A.GiaoDien.QuanLySinhVien(ChucNang, SV);
            QLSV.DuLieu = new QuanLySinhVien.DuLieuTruyenVe(LayDuLieu);
            QLSV.ShowDialog(this);
            txtTimKiem.Focus();
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            ThemSinhVien();
        }
            //#Truyền dữ liệu.
        public void LayDuLieu(SinhVien_ThongTin SV)
        {
            this.Ma = SV.MaSinhVien;
            if (!this.Ma.Equals(""))
            {
                //Load lại bảng.
                tbDanhSachSinhVien.DataSource = cls_SinhVien.DanhSachSinhVien();
            }
        }
        //KHI CHỌN SỬA THÔNG TIN SINH VIÊN.
        private void SuaSinhVien()
        {
            ChucNang = "F10";
            SinhVien_ThongTin SV = new SinhVien_ThongTin();

            SV.MaSinhVien = tbDanhSachSinhVien.Rows[DongChon].Cells[0].Value?.ToString() ?? "";
            SV.TenSinhVien = tbDanhSachSinhVien.Rows[DongChon].Cells[1].Value?.ToString() ?? "";

            DateTime ngaySinh;
            if (DateTime.TryParse(tbDanhSachSinhVien.Rows[DongChon].Cells[2].Value?.ToString(), out ngaySinh))
            {
                SV.NgaySinh = ngaySinh;
            }

            SV.GioiTinh = tbDanhSachSinhVien.Rows[DongChon].Cells[3].Value?.ToString() == "True";
            SV.Lop = tbDanhSachSinhVien.Rows[DongChon].Cells[4].Value?.ToString() ?? "";
            SV.DiaChi = tbDanhSachSinhVien.Rows[DongChon].Cells[5].Value?.ToString() ?? "";
            SV.ChinhSachUuTien = tbDanhSachSinhVien.Rows[DongChon].Cells[6].Value?.ToString() == "True";

            A.GiaoDien.QuanLySinhVien QLSV = new A.GiaoDien.QuanLySinhVien(ChucNang, SV);
            QLSV.DuLieu = new QuanLySinhVien.DuLieuTruyenVe(LayDuLieu);
            QLSV.ShowDialog(this);
            txtTimKiem.Focus();
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
            if (KiemTraXoa == 0)
            {
                MessageBox.Show("Bạn hãy chọn sinh viên muốn xóa.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (KiemTraXoa == 1)
            {
                SinhVien_ThongTin SV = new SinhVien_ThongTin();
                SV.MaSinhVien = tbDanhSachSinhVien.Rows[DongChon].Cells[0].Value.ToString();
                SV.TenSinhVien = tbDanhSachSinhVien.Rows[DongChon].Cells[1].Value.ToString();
                if (MessageBox.Show("Bạn có thật sự muốn xóa thông tin sinh viên " + SV.MaSinhVien + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        cls_SinhVien.XoaSinhVien(SV.MaSinhVien);
                        MessageBox.Show("Bạn đã xóa sinh viên " + SV.TenSinhVien + " có mã " + SV.MaSinhVien + "", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.None);

                    }
                    catch
                    {
                        MessageBox.Show("Không thể xóa dữ liệu này, hãy kiểm tra kết nối!", "Thông báo lỗi.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                tbDanhSachSinhVien.DataSource = cls_SinhVien.DanhSachSinhVien();
                KiemTraXoa = 0;
            }
            txtTimKiem.Focus();
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
            SV.MaSinhVien = tbDanhSachSinhVien.Rows[DongChon].Cells[0].Value.ToString();
            SV.TenSinhVien = tbDanhSachSinhVien.Rows[DongChon].Cells[1].Value.ToString();
            SV.Lop = tbDanhSachSinhVien.Rows[DongChon].Cells[4].Value.ToString();

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
