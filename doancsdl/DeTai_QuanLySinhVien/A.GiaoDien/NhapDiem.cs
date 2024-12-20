using System;
using System.Data;
using System.Windows.Forms;
using D.ThongTin;
using B.ThaoTac;
using System.Linq;
using System.Threading.Tasks;

namespace A.GiaoDien
{
    public partial class NhapDiem : Form
    {
        //KHAI BÁO DÙNG CHUNG.
        //BẢNG MÔN HOC.
        MonHoc_B cls_MonHoc = new MonHoc_B();
        //BẢNG HỌC KỲ.
        HocKy_B cls_HocKy = new HocKy_B();
        //BẢNG SINH VIÊN
        SinhVien_B cls_SinhVien = new SinhVien_B();
        //BẢNG ĐIỂM
        BangDiem_B cls_BangDiem = new BangDiem_B();

        BindingSource source;
        
        private string ChucNang=null;
        private int BangDiemSTT;

        public delegate void DuLieuTruyenVe(BangDiem_ThongTin BD);
        public DuLieuTruyenVe DuLieu;

        public NhapDiem(string chucNang, string maLop, BangDiem_ThongTin bd)
        {
            InitializeComponent();
            this.ChucNang = chucNang;
            LoadMonHocHocKy(); // Gọi hàm sau khi khởi tạo                                                
            // Lấy danh sách sinh viên của lớp
                   
            if (ChucNang.Equals("F1"))
            {
                LoadDanhSachSinhVienCuaLop(maLop);
            }
            if (ChucNang.Equals("ChinhSua"))
            {
                BangDiemSTT = bd.Stt;
                txtMaSinhVien.Text = bd.MaSinhVien;
                cbHocKy.SelectedValue = bd.MaHocKy;
                cbMonHoc.SelectedValue = bd.MaMonHoc;
                txtDiemQuaTrinh.Text = bd.DiemQuaTrinh.ToString();
                txtDiemThi.Text = bd.DiemThi.ToString();
                ChinhSua = "1";
                XacNhanXoa = "1";
                btXacNhan_QLD.Enabled = false;
                btChinhSua_QLD.Text = "Lưu lại.";
                txtDiemQuaTrinh.Focus();
            }
            txtDiemQuaTrinh.Focus();
        }
        private async void LoadDanhSachSinhVienCuaLop(String MaLop)
        {
            try
            {
                SinhVien_ThongTin SV = new SinhVien_ThongTin();
                SV.Lop = MaLop;            
                var sinhVienData = await Task.Run(() => cls_SinhVien.DanhSachSinhVienCuaLop(SV));
                if (sinhVienData == null || sinhVienData.Count == 0)
                {
                    MessageBox.Show("Không có sinh viên trong lớp này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sinhVienTable = DataConversion1.ConvertToDataTable1(sinhVienData);
                if (sinhVienTable == null || sinhVienTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu sau khi chuyển đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Invoke(new Action(() =>
                {
                    source = new BindingSource();
                    foreach (DataRow row in sinhVienTable.Rows)
                    {
                        source.Add(row);
                    }
                    foreach (DataRow Hang in sinhVienTable.Rows)
                    source.Add(Hang);
                    //LẤY RA GIÁ TRỊ ĐẦU TIÊN.
                    source.MoveFirst();
                    ShowRecord();
                    XemDiemTheoKySinhVien();
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadMonHocHocKy()
        {
            var hocKyData = cls_HocKy.DanhSachHocKy();
            if (hocKyData == null || hocKyData.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu học kỳ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var hocKytable = DataConversion1.ConvertToDataTable1(hocKyData);
            if (hocKytable != null)
            {
                cbHocKy.DataSource = hocKytable;
                cbHocKy.DisplayMember = "TenHocKy";
                cbHocKy.ValueMember = "MaHocKy";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu học kỳ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var monHocData = cls_MonHoc.DanhSachMonHoc();
            if (monHocData == null || monHocData.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu môn học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var monHoctable = DataConversion1.ConvertToDataTable1(monHocData);
            if (monHoctable != null )
            {
                cbMonHoc.DataSource = monHoctable;
                cbMonHoc.DisplayMember = "TenMonHoc";
                cbMonHoc.ValueMember = "MaMonHoc";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu môn học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //XEM ĐIỂM THEO 1 KỲ NÀO ĐÓ CỦA SINH VIÊN.
        public void XemDiemTheoKySinhVien()
        {
            try
            {
                BangDiem_ThongTin BD = new BangDiem_ThongTin();
                BD.MaSinhVien = txtMaSinhVien.Text;
                BD.MaHocKy = cbHocKy.SelectedValue.ToString();
                tbKetQuaHocTap.DataSource = cls_BangDiem.LayDiemTheoKySinhVien(BD);
            }
            catch
            {
                MessageBox.Show("Lỗi khi xem điểm sinh viên theo kỳ, bạn hãy kiểm tra lại.", "Thông báo lỗi.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ThemKetQuaHocTap()
        {
            try
            {
                BangDiem_ThongTin BD = new BangDiem_ThongTin
                {
                    MaSinhVien = txtMaSinhVien.Text,
                    MaMonHoc = cbMonHoc.SelectedValue?.ToString(),
                    MaHocKy = cbHocKy.SelectedValue?.ToString(),
                    DiemQuaTrinh = float.Parse(txtDiemQuaTrinh.Text),
                    DiemThi = float.Parse(txtDiemThi.Text)
                };

                cls_BangDiem.ThemKetQua(BD);
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                XemDiemTheoKySinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void ChinhSuaKetQuaHocTap()
        {
            try
            {
                // Tạo đối tượng BangDiem_ThongTin
                BangDiem_ThongTin BD = new BangDiem_ThongTin
                {
                    MaSinhVien = txtMaSinhVien.Text,
                    MaMonHoc = cbMonHoc.SelectedValue.ToString(),
                    MaHocKy = cbHocKy.SelectedValue.ToString()
                };

                // Gọi phương thức CapNhatDiem để tính toán tự động
                BD.CapNhatDiem(float.Parse(txtDiemQuaTrinh.Text), float.Parse(txtDiemThi.Text));

                // Cập nhật dữ liệu vào MongoDB
                cls_BangDiem.UpDateDiemQTVaDiemThi(BD);

                // Thông báo thành công
                MessageBox.Show($"Cập nhật thành công! Điểm chữ mới: {BD.DiemChu}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại danh sách
                XemDiemTheoKySinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật điểm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXacNhan_QLD_Click(object sender, EventArgs e)
        {
            ThemKetQuaHocTap();
        }
        string ChinhSua = "0";
        private void btChinhSua_QLD_Click(object sender, EventArgs e)
        {
            if (ChinhSua.Equals("0"))
            {
                ChinhSua = "1";
                btXacNhan_QLD.Enabled = false;
                btChinhSua_QLD.Text = "Lưu lại.";
                txtTenSinhVien.Text = "";
                txtMaSinhVien.Text = "";
                cbHocKy.Text = "";
                cbMonHoc.Text = "";
                txtDiemQuaTrinh.Text = "";
                txtDiemThi.Text = "";
                txtMaSinhVien.Focus();
            }
            else
            {
                ChinhSuaKetQuaHocTap();
            }       
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
        string XacNhanXoa = "0";
        int row;
        private void tbKetQuaHocTap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu chỉ số dòng hợp lệ
            {
                row = e.RowIndex;
                ChinhSua = "1";
                XacNhanXoa = "1";
                btXacNhan_QLD.Enabled = false;
                btChinhSua_QLD.Text = "Lưu lại.";
                txtDiemQuaTrinh.Focus();
                txtDiemQuaTrinh.Text = tbKetQuaHocTap.Rows[row].Cells["DiemQuaTrinh"].Value?.ToString();
                txtDiemThi.Text = tbKetQuaHocTap.Rows[row].Cells["DiemThi"].Value?.ToString();
                cbMonHoc.SelectedValue = tbKetQuaHocTap.Rows[row].Cells["MaMonHoc"].Value?.ToString();
            }
        }
        //XÓA KẾT QUẢ HỌC TẬP
        private void btXoa_Click_1(object sender, EventArgs e)
        {
            if (XacNhanXoa.Equals("1"))
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        BangDiem_ThongTin BD = new BangDiem_ThongTin();
                        if (ChucNang.Equals("ChinhSua"))
                        {
                            BD.Stt = BangDiemSTT;
                            cls_BangDiem.XoaKetQua(BD);
                            MessageBox.Show("Bạn đã hủy kết quả môn " + cbMonHoc.Text + " của sinh viên có mã " + txtMaSinhVien.Text + ".", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.None);
                            if (DuLieu != null)
                            {
                                BD.MaSinhVien = txtMaSinhVien.Text;
                                BD.MaHocKy = cbHocKy.SelectedValue.ToString();
                                DuLieu(BD);
                            }
                            this.Hide();
                        }
                        else
                        {
                            BD.Stt = int.Parse(tbKetQuaHocTap.Rows[row].Cells[0].Value.ToString());
                            cls_BangDiem.XoaKetQua(BD);
                        }
                        XemDiemTheoKySinhVien();
                        txtDiemQuaTrinh.Text = "";
                        txtDiemThi.Text = "";
                        txtDiemQuaTrinh.Focus();
                        XacNhanXoa = "0";
                        ChinhSua = "0";
                        btChinhSua_QLD.Text = "Chỉnh sửa";
                        btXacNhan_QLD.Enabled = true;
                    }
                    catch
                    {
                        MessageBox.Show("Không thể xóa, bạn hãy kiểm tra lại.", "Thông báo lỗi.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn bản ghi muốn xóa.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }
        //##### ================== =============== ==================#####//
    }
}
