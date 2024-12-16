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
    public partial class DanhSachHeDaoTao : Form
    {
        //KHAI BÁO DÙNG CHUNG
        HeDaoTao_B cls_HeDaoTao = new HeDaoTao_B();
        //
        string ChucNang = null;
        int DongChon = 0;
        int XacNhanXoa = 0;
        string MaHe = null;
        public DanhSachHeDaoTao()
        {
            InitializeComponent();
        }
        //SAU KHI KHỞI TẠO
        private void DanhSachHeDaoTao_Load(object sender, EventArgs e)
        {
            try
            {
                var data = cls_HeDaoTao.DanhSachHeDaoTao(); // Lấy dữ liệu từ MongoDB
                var dataTable = DataConversion1.ConvertToDataTable1(data); // Chuyển đổi sang DataTable
                tbHeDaoTao.DataSource = dataTable; // Gán dữ liệu cho DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtTimKiem.Focus();
        }



        //LẤY DỮ LIỆU GỬI VỀ.
        public void LayDuLieu(HeDaoTao_ThongTin HDT)
        {
            this.MaHe = HDT.MaHe;
            if (!string.IsNullOrEmpty(this.MaHe))
            {
                try
                {
                    var data = cls_HeDaoTao.DanhSachHeDaoTao(); // Lấy dữ liệu từ MongoDB
                    var sanitizedData = SanitizeBsonDocuments(data); // Làm sạch dữ liệu
                    var dataTable = DataConversion1.ConvertToDataTable1(sanitizedData);
                    tbHeDaoTao.DataSource = dataTable; // Gán dữ liệu cho DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txtTimKiem.Focus();
        }
        // Hàm làm sạch dữ liệu (tránh BsonDocument)
        private List<BsonDocument> SanitizeBsonDocuments(List<BsonDocument> documents)
        {
            foreach (var doc in documents)
            {
                foreach (var element in doc.Elements.ToList())
                {
                    if (element.Value.IsBsonDocument || element.Value.IsBsonArray)
                    {
                        doc[element.Name] = element.Value.ToString(); // Chuyển về chuỗi
                    }
                }
            }
            return documents;
        }


        //KHI KÍCH BUTTON THÊM
        private void ThemHeDaoTao()
        {
            ChucNang = "F9";
            HeDaoTao_ThongTin HDT = new HeDaoTao_ThongTin();
            A.GiaoDien.QuanLyHeDaoTao QLHDT = new A.GiaoDien.QuanLyHeDaoTao(ChucNang, HDT);
            QLHDT.DuLieu = new QuanLyHeDaoTao.DuLieuTruyenVe(LayDuLieu);
            QLHDT.ShowDialog(this);
            XacNhanXoa = 0;
            txtTimKiem.Focus();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            ThemHeDaoTao();
        }
        //KHI KÍCH BUTTON SỬA THÔNG TIN
        private void SuaHeDaoTao()
        {
            ChucNang = "F10";
            HeDaoTao_ThongTin HDT = new HeDaoTao_ThongTin();
            HDT.MaHe = tbHeDaoTao.Rows[DongChon].Cells[0].Value.ToString();
            HDT.TenHe = tbHeDaoTao.Rows[DongChon].Cells[1].Value.ToString();
            A.GiaoDien.QuanLyHeDaoTao QLHDT = new A.GiaoDien.QuanLyHeDaoTao(ChucNang, HDT);
            QLHDT.DuLieu = new QuanLyHeDaoTao.DuLieuTruyenVe(LayDuLieu);
            QLHDT.ShowDialog(this);
            XacNhanXoa = 0;
            txtTimKiem.Focus();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            SuaHeDaoTao();
            txtTimKiem.Focus();
        }
        //KÍCH VÀO BẢNG
        private void tbHeDaoTao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DongChon = e.RowIndex;
            XacNhanXoa = 1;
            txtTimKiem.Focus();
        }
        //XÓA HỆ ĐÀO TẠO
        private void XoaHeDaoTao()
        {
            if (XacNhanXoa == 1)
            {
                HeDaoTao_ThongTin HDT = new HeDaoTao_ThongTin();
                HDT.MaHe = tbHeDaoTao.Rows[DongChon].Cells[0].Value.ToString();
                if (MessageBox.Show("Bạn có thật sự muốn xóa thông tin hệ đào tạo có mã " + HDT.MaHe + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        cls_HeDaoTao.XoaHeDaoTao(HDT);
                        tbHeDaoTao.DataSource = cls_HeDaoTao.DanhSachHeDaoTao();
                    }
                    catch
                    {
                        MessageBox.Show("Không thể xóa dữ liệu này, hãy kiểm tra lại.!", "Thông báo lỗi.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                XacNhanXoa = 1;
                txtTimKiem.Focus();
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn khóa học muốn xóa.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTimKiem.Focus();
            }
        }
        //
        private void btXoa_Click(object sender, EventArgs e)
        {
            XoaHeDaoTao();
            txtTimKiem.Focus();
        }

        private void KhiAnTimKiem(object sender, KeyEventArgs e)
        {
            if (!e.KeyValue.ToString().Equals("120") && !e.KeyValue.ToString().Equals("121") && !e.KeyValue.ToString().Equals("122") && !e.KeyValue.ToString().Equals("123"))
            {
                txtTimKiem.BackColor = Color.White;
                HeDaoTao_ThongTin HDT = new HeDaoTao_ThongTin();
                HDT.MaHe = txtTimKiem.Text;
                tbHeDaoTao.DataSource = cls_HeDaoTao.TimKiemHeDaoTao(HDT);
            }
            if (e.KeyValue.ToString().Equals("120"))
            {
                ThemHeDaoTao();
                txtTimKiem.Focus();
            }
            if (e.KeyValue.ToString().Equals("121"))
            {
                SuaHeDaoTao();
                txtTimKiem.Focus();
            }
            if (e.KeyValue.ToString().Equals("122"))
            {
                XoaHeDaoTao();
                txtTimKiem.Focus();
            }
            if (e.KeyValue.ToString().Equals("123"))
            {
                txtTimKiem.BackColor = Color.YellowGreen;
                txtTimKiem.Focus();
            }
            txtTimKiem.Focus();
        }

        private void KhiKichDupChuot(object sender, MouseEventArgs e)
        {
            SuaHeDaoTao();
            txtTimKiem.Focus();
        }

        private void tbHeDaoTao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không click vào header
            {
                DongChon = e.RowIndex; // Cập nhật dòng được chọn
                XacNhanXoa = 1; // Đánh dấu đã chọn dòng
            }
        }


        /*private void btInBaoCao_Click(object sender, EventArgs e)
        {
            HeDaoTao_ThongTin HDT = new HeDaoTao_ThongTin();
            HDT.MaHe = txtTimKiem.Text;
            BaoCao.BaoCao.DuLieu = cls_HeDaoTao.TimKiemHeDaoTao(HDT);
            BaoCao.BaoCao.Kieu = "TimKiemHeDaoTao";
            BaoCao.BaoCao BC = new BaoCao.BaoCao();
            BC.ShowDialog();
        }*/
    }
}
