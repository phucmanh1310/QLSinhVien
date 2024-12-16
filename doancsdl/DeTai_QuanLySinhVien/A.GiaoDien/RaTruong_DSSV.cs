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
    public partial class RaTruong_DSSV : Form
    {
        //KHAI BÁO DÙNG CHUNG
        //BẢNG SINH VIÊN
        SinhVien_B cls_SinhVien = new SinhVien_B();
        //XỬ LÝ IN
        private int RaTruong = 0;
        private int RaTruong_NhanBang = 0;
        private int RaTruong_KhongBang = 0;
        public RaTruong_DSSV()
        {
            InitializeComponent();
            //LOAD TOÀN BỘ DANH SÁCH SINH VIÊN RA TRƯỜNG TRONG NĂM.
            try
            {
                tbDanhSachSinhVien.DataSource = cls_SinhVien.DanhSachSinhVienRaTruong();
            }
            catch { }
            RaTruong = 1;
        }

        private void btDSSV_RaTruong_Click(object sender, EventArgs e)
        {
            //LOAD TOÀN BỘ DANH SÁCH SINH VIÊN RA TRƯỜNG TRONG NĂM.
            try
            {
                tbDanhSachSinhVien.DataSource = cls_SinhVien.DanhSachSinhVienRaTruong();
            }
            catch { }
            RaTruong = 1;
            RaTruong_NhanBang = 0;
            RaTruong_KhongBang = 0;
        }

        private void btDSSV_NhanBang_Click(object sender, EventArgs e)
        {
            //LOAD TOÀN BỘ DANH SÁCH SINH VIÊN RA TRƯỜNG ĐƯỢC NHẬN BẰNG.
            try
            {
                tbDanhSachSinhVien.DataSource = cls_SinhVien.DanhSachSinhVienRaTruongDuocNhanBang();
            }
            catch { }
            RaTruong_NhanBang = 1;
            RaTruong = 0;
            RaTruong_KhongBang = 0;
        }

        private void btDSSV_KhongNhanBang_Click(object sender, EventArgs e)
        {
            //LOAD TOÀN BỘ DANH SÁCH SINH VIÊN RA TRƯỜNG KHÔNG ĐƯỢC NHẬN BẰNG.
            try
            {
                tbDanhSachSinhVien.DataSource = cls_SinhVien.DanhSachSinhVienRaTruongKhongDuocNhanBang();
            }
            catch { }
            RaTruong_KhongBang = 1;
            RaTruong = 0;
            RaTruong_NhanBang = 0;
        }

      /*  private void btInBaoCao_Click(object sender, EventArgs e)
        {
            if (RaTruong == 1)
            {
                BaoCao.BaoCao.DuLieu = cls_SinhVien.DanhSachSinhVienRaTruong();
                BaoCao.BaoCao.Kieu = "RaTruong";
                BaoCao.BaoCao BC = new BaoCao.BaoCao();
                BC.ShowDialog();
            }
            if (RaTruong_NhanBang == 1)
            {
                BaoCao.BaoCao.DuLieu = cls_SinhVien.DanhSachSinhVienRaTruongDuocNhanBang();
                BaoCao.BaoCao.Kieu = "RaTruong_NhanBang";
                BaoCao.BaoCao BC = new BaoCao.BaoCao();
                BC.ShowDialog();
                RaTruong_NhanBang = 0;
            }
            if (RaTruong_KhongBang == 1)
            {
                BaoCao.BaoCao.DuLieu = cls_SinhVien.DanhSachSinhVienRaTruongKhongDuocNhanBang();
                BaoCao.BaoCao.Kieu = "RaTruong_KhongBang";
                BaoCao.BaoCao BC = new BaoCao.BaoCao();
                BC.ShowDialog();
                RaTruong_KhongBang = 0;
            }
        }*/
    }
}
