using System;
using System.Data;
using System.Windows.Forms;
using D.ThongTin;
using B.ThaoTac;

namespace A.GiaoDien
{
    public partial class NhapDiem : Form
    {
        private BangDiem_B cls_BangDiem = new BangDiem_B();
        private MonHoc_B cls_MonHoc = new MonHoc_B();
        private HocKy_B cls_HocKy = new HocKy_B();
        private BindingSource source;

        private string ChucNang;
        private string MaLop;
        private int BangDiemSTT;
        private BangDiem_ThongTin BD;

        public delegate void DuLieuTruyenVe(BangDiem_ThongTin BD);
        public DuLieuTruyenVe DuLieu;

        public NhapDiem(string chucNang, string maLop, BangDiem_ThongTin bd)
        {
            InitializeComponent();
            this.ChucNang = chucNang;
            this.MaLop = maLop;
            this.BD = bd;

            LoadMonHocHocKy();

            if (ChucNang.Equals("ChinhSua"))
            {
                BangDiemSTT = BD.Stt;
                txtMaSinhVien.Text = BD.MaSinhVien;
                cbHocKy.SelectedValue = BD.MaHocKy;
                cbMonHoc.SelectedValue = BD.MaMonHoc;
                txtDiemQuaTrinh.Text = BD.DiemQuaTrinh.ToString();
                txtDiemThi.Text = BD.DiemThi.ToString();
                btXacNhan_QLD.Enabled = false;
                btChinhSua_QLD.Text = "Lưu lại.";
                txtDiemQuaTrinh.Focus();
            }
        }

        private void LoadMonHocHocKy()
        {
            cbHocKy.DataSource = cls_HocKy.DanhSachHocKy();
            cbHocKy.DisplayMember = "TenHocKy";
            cbHocKy.ValueMember = "MaHocKy";

            cbMonHoc.DataSource = cls_MonHoc.DanhSachMonHoc();
            cbMonHoc.DisplayMember = "TenMonHoc";
            cbMonHoc.ValueMember = "MaMonHoc";
        }

        private void XemDiemTheoKySinhVien()
        {
            try
            {
                var result = cls_BangDiem.LayDiemTheoKySinhVien(txtMaSinhVien.Text, cbHocKy.SelectedValue.ToString());
                tbKetQuaHocTap.DataSource = result; // Phải chuyển đổi sang DataTable nếu cần thiết
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối khi xem điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemKetQuaHocTap()
        {
            try
            {
                BangDiem_ThongTin BD = new BangDiem_ThongTin
                {
                    MaSinhVien = txtMaSinhVien.Text,
                    MaMonHoc = cbMonHoc.SelectedValue.ToString(),
                    MaHocKy = cbHocKy.SelectedValue.ToString(),
                    DiemQuaTrinh = float.Parse(txtDiemQuaTrinh.Text),
                    DiemThi = float.Parse(txtDiemThi.Text)
                };
                cls_BangDiem.ThemKetQua(BD);
                XemDiemTheoKySinhVien();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Thêm thất bại! Kiểm tra dữ liệu nhập vào.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChinhSuaKetQuaHocTap()
        {
            try
            {
                BD.MaHocKy = cbHocKy.SelectedValue.ToString();
                BD.MaMonHoc = cbMonHoc.SelectedValue.ToString();
                BD.DiemQuaTrinh = float.Parse(txtDiemQuaTrinh.Text);
                BD.DiemThi = float.Parse(txtDiemThi.Text);

                cls_BangDiem.UpDateDiemQTVaDiemThi(BD);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                XemDiemTheoKySinhVien();
            }
            catch
            {
                MessageBox.Show("Lỗi khi cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXacNhan_QLD_Click(object sender, EventArgs e)
        {
            ThemKetQuaHocTap();
        }

        private void btChinhSua_QLD_Click(object sender, EventArgs e)
        {
            ChinhSuaKetQuaHocTap();
            DuLieu?.Invoke(BD);
            this.Close();
        }

        private void btDau_Click(object sender, EventArgs e)
        {
            source.MoveFirst();
            ShowRecord();
        }

        private void btTruoc_Click(object sender, EventArgs e)
        {
            source.MovePrevious();
            ShowRecord();
        }

        private void btSau_Click(object sender, EventArgs e)
        {
            source.MoveNext();
            ShowRecord();
        }

        private void brCuoi_Click(object sender, EventArgs e)
        {
            source.MoveLast();
            ShowRecord();
        }

        private void ShowRecord()
        {
            if (source.Current != null)
            {
                DataRow currentRow = (DataRow)source.Current;
                txtMaSinhVien.Text = currentRow["MaSinhVien"].ToString();
                txtTenSinhVien.Text = currentRow["TenSinhVien"].ToString();
            }
        }

        private void tbKetQuaHocTap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtDiemQuaTrinh.Text = tbKetQuaHocTap.Rows[row].Cells[5].Value.ToString();
            txtDiemThi.Text = tbKetQuaHocTap.Rows[row].Cells[6].Value.ToString();
            cbMonHoc.SelectedValue = tbKetQuaHocTap.Rows[row].Cells[2].Value.ToString();
        }
    }
}
