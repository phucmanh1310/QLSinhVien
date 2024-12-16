using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using D.ThongTin;
using B.ThaoTac;

namespace A.GiaoDien
{
    public partial class HocBong_DSSV : Form
    {
        // KHAI BÁO DÙNG CHUNG.
        BangDiem_B cls_BangDiem = new BangDiem_B();
        HocKy_B cls_HocKy = new HocKy_B();
        Khoa_B cls_Khoa = new Khoa_B();

        private int HocKy = 0;
        private int Khoa = 0;
        private int Top = 0;

        public HocBong_DSSV()
        {
            InitializeComponent();
            HocKy = 1;

            try
            {
                cbHocKy.DataSource = DataConversion1.ConvertToDataTable1(cls_HocKy.DanhSachHocKy());
                cbHocKy.DisplayMember = "TenHocKy";
                cbHocKy.ValueMember = "MaHocKy";

                cbKhoa.DataSource = DataConversion1.ConvertToDataTable1(cls_Khoa.DanhSachKhoa());
                cbKhoa.DisplayMember = "TenKhoa";
                cbKhoa.ValueMember = "MaKhoa";
            }
            catch
            {
                MessageBox.Show("Không thể load dữ liệu lên các ô combobox. Hãy kiểm tra kết nối!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DanhSachSinhVienDatHocBongTheoKy(null, null);
        }

        // DANH SÁCH SINH VIÊN ĐẠT HỌC BỔNG THEO KỲ
        private void DanhSachSinhVienDatHocBongTheoKy(object sender, EventArgs e)
        {
            try
            {
                string maHocKy = cbHocKy.SelectedValue.ToString();
                var documents = cls_BangDiem.DanhSachSinhVienXetHocBong(maHocKy);
                tbHocBong_DSSV.DataSource = DataConversion1.ConvertToDataTable1(documents);
            }
            catch
            {
                MessageBox.Show("Không thể load dữ liệu lên bảng. Hãy kiểm tra kết nối!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            HocKy = 1;
        }

        // DANH SÁCH SINH VIÊN CỦA KHOA
        private void DanhSachSinhVienDatHocBongCuaKhoa(object sender, EventArgs e)
        {
            try
            {
                string maHocKy = cbHocKy.SelectedValue.ToString();
                string maKhoa = cbKhoa.SelectedValue.ToString();

                var documents = cls_BangDiem.DanhSachSinhVienXetHocBong_Khoa(maHocKy, maKhoa);
                tbHocBong_DSSV.DataSource = DataConversion1.ConvertToDataTable1(documents);
            }
            catch
            {
                MessageBox.Show("Không thể load dữ liệu lên bảng. Hãy kiểm tra kết nối!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DANH SÁCH SINH VIÊN CỦA KHOA THEO TOP
        private void LayTopSinhVienCuaKhoa(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) // Phím Enter
            {
                try
                {
                    string maHocKy = cbHocKy.SelectedValue.ToString();
                    string maKhoa = cbKhoa.SelectedValue.ToString();
                    int top = int.Parse(txtTop.Text);

                    var documents = cls_BangDiem.DanhSachSinhVienXetHocBong_Khoa_Top(maHocKy, maKhoa, top);
                    tbHocBong_DSSV.DataSource = DataConversion1.ConvertToDataTable1(documents);
                }
                catch
                {
                    MessageBox.Show("Không thể load dữ liệu lên bảng. Hãy kiểm tra kết nối!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Top = 1;
            }
        }

        // IN BÁO CÁO
      /*  private void btInBaoCao_Click(object sender, EventArgs e)
        {
            string maHocKy = cbHocKy.SelectedValue.ToString();
            string maKhoa = cbKhoa.SelectedValue.ToString();
            int top = string.IsNullOrEmpty(txtTop.Text) ? 0 : int.Parse(txtTop.Text);

            if (HocKy == 1 && Khoa == 0 && Top == 0)
            {
                BaoCao.BaoCao.DuLieu = cls_BangDiem.DanhSachSinhVienXetHocBong(maHocKy);
                BaoCao.BaoCao.Kieu = "HocBong";
            }
            else if (HocKy == 1 && Khoa == 1 && Top == 0)
            {
                BaoCao.BaoCao.DuLieu = cls_BangDiem.DanhSachSinhVienXetHocBong_Khoa(maHocKy, maKhoa);
                BaoCao.BaoCao.Kieu = "HocBong_Khoa";
            }
            else if (HocKy == 1 && Khoa == 1 && Top == 1)
            {
                BaoCao.BaoCao.DuLieu = cls_BangDiem.DanhSachSinhVienXetHocBong_Khoa_Top(maHocKy, maKhoa, top);
                BaoCao.BaoCao.Kieu = "HocBong_Khoa_Top";
            }

            BaoCao.BaoCao.HocKy = cbHocKy.Text;
            BaoCao.BaoCao.Khoa = cbKhoa.Text;
            BaoCao.BaoCao.Top = txtTop.Text;

            BaoCao.BaoCao BC = new BaoCao.BaoCao();
            BC.ShowDialog();

            Khoa = 0;
            Top = 0;
        }*/

        private void cbKhoa_MouseMove(object sender, MouseEventArgs e)
        {
            Khoa = 1;
        }
    }
}
