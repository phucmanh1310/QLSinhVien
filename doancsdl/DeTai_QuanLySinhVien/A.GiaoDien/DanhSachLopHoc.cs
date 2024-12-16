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
    public partial class DanhSachLopHoc : Form
    {
        //KHAI BÁO DÙNG CHUNG.
        //BẢNG LỚP HOC.
        Lop_B cls_Lop = new Lop_B();

        int DongChon = 0;
        string ChucNang = null;
        string MaLop = null;
        public DanhSachLopHoc()
        {
            InitializeComponent();
        }
        private void DanhSachLopHoc_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            txtTimKiem.Focus();
        }
        public void LoadDataGridView()
        {
            try
            {
                var data = cls_Lop.DanhSach_ThongTin_DayDu();
                var dataTable = DataConversion1.ConvertToDataTable1(data);
                tbDanhSachLopHoc.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //KHI KICH DUP CHUỘT CHỌN LỚP NHẬP ĐIỂM.
        private void NhapDiemChoLop()
        {
            ChucNang = "F1";
            BangDiem_ThongTin BD = new BangDiem_ThongTin();
            string MaLop = tbDanhSachLopHoc.Rows[DongChon].Cells[0].Value.ToString();
            A.GiaoDien.NhapDiem ND = new A.GiaoDien.NhapDiem(ChucNang, MaLop, BD);
            ND.ShowDialog(this);
            XacNhanXoa = "0";
            txtTimKiem.Focus();
        }
        private void KhiChonLopNhapDiem(object sender, MouseEventArgs e)
        {
            NhapDiemChoLop();
        }
        
        //KHI CHỌN LỚP HỌC.
        private void tbDanhSachLopHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            XacNhanXoa = "1";
            DongChon = e.RowIndex;
            txtTimKiem.Focus();
        }
        //KHI CHỌN NHẬP ĐIỂM
        private void btNhapDiem_Click(object sender, EventArgs e)
        {
            NhapDiemChoLop();
        }
        //TÌM KIẾM VÀ PHÍM TẮT
        private void KhiTimKiem_PhimTat(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Nhấn Enter
            {
                try
                {
                    Lop_ThongTin Lop = new Lop_ThongTin();
                    Lop.TenLop = txtTimKiem.Text;

                    // Gọi hàm tìm kiếm từ lớp B
                    var data = cls_Lop.TimKiemLopHoc(Lop);
                    var dataTable = DataConversion1.ConvertToDataTable1(data);

                    tbDanhSachLopHoc.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //KÍCH CHỌN THÊM LỚP HỌC MỚI.
        private void ThemLopHoc()
        {
            ChucNang = "F9";
            Lop_ThongTin Lop = new Lop_ThongTin();
            QuanLyLopHoc QLLH = new QuanLyLopHoc(ChucNang, Lop);
            QLLH.DuLieu = new QuanLyLopHoc.DuLieuTruyenVe(LayDuLieu);
            QLLH.ShowDialog(this);
            LoadDataGridView();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            ThemLopHoc();
        }
        //LẤY DỮ LIỆU TRUYỀN VỀ.
        public void LayDuLieu(Lop_ThongTin Lop)
        {
            this.MaLop = Lop.MaLop;
            if (!MaLop.Equals(""))
            {
                tbDanhSachLopHoc.DataSource = cls_Lop.DanhSach_ThongTin_Lop();
            }
        }
        //KÍCH CHỌN SỬA THÔNG TIN LỚP HỌC.
        private void SuaThongTinLopHoc()
        {
            ChucNang = "F10";
            Lop_ThongTin Lop = new Lop_ThongTin
            {
                MaLop = tbDanhSachLopHoc.Rows[DongChon].Cells[0].Value.ToString(),
                TenLop = tbDanhSachLopHoc.Rows[DongChon].Cells[1].Value.ToString(),
                MaKhoaHoc = tbDanhSachLopHoc.Rows[DongChon].Cells[2].Value.ToString(),
                MaHeDaoTao = tbDanhSachLopHoc.Rows[DongChon].Cells[3].Value.ToString(),
                MaNganh = tbDanhSachLopHoc.Rows[DongChon].Cells[4].Value.ToString()
            };

            QuanLyLopHoc QLLH = new QuanLyLopHoc(ChucNang, Lop);
            QLLH.DuLieu = new QuanLyLopHoc.DuLieuTruyenVe(LayDuLieu);
            QLLH.ShowDialog(this);
            LoadDataGridView();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            SuaThongTinLopHoc();
        }
        string XacNhanXoa = "0";
        //XÓA LỚP HỌC
        private void XoaLopHoc()
        {
            if (XacNhanXoa == "1")
            {
                var Lop = new Lop_ThongTin
                {
                    MaLop = tbDanhSachLopHoc.Rows[DongChon].Cells[0].Value.ToString()
                };

                if (MessageBox.Show($"Bạn có thật sự muốn xóa lớp học {Lop.MaLop}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        cls_Lop.XoaLopHoc(Lop);
                        MessageBox.Show("Xóa lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa lớp học: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lớp học muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btXoa_Click(object sender, EventArgs e)
        {
            XoaLopHoc();
        }
        //IN BÁO CÁO
     /*   private void btInBaoCao_Click(object sender, EventArgs e)
        {
            Lop_ThongTin Lop = new Lop_ThongTin();
            Lop.MaLop = txtTimKiem.Text;
            BaoCao.BaoCao.DuLieu = cls_Lop.TimKiemLopHoc(Lop);
            BaoCao.BaoCao.Kieu = "TimKiemLopHoc";
            BaoCao.BaoCao BC = new BaoCao.BaoCao();
            BC.ShowDialog();
        }*/
    }
}
