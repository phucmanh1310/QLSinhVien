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
using System.Configuration;
using MongoDB.Driver;

namespace A.GiaoDien
{
    public partial class DangNhapCoSoDuLieu : Form
    {
        public DangNhapCoSoDuLieu()
        {
            InitializeComponent();
        }
        private void btTiepTuc_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenServer.Text) || string.IsNullOrEmpty(cbHinhThuc.Text))
                {
                    MessageBox.Show("Thông tin bạn cung cấp chưa đủ, hãy kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mở cấu hình
                Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string connectionString;

                if (cbHinhThuc.Text.Equals("Sử Dụng Tài Khoản"))
                {
                    if (string.IsNullOrEmpty(txtTaiKhoan.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
                    {
                        MessageBox.Show("Thông tin tài khoản chưa đủ, hãy kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Tạo connection string với tài khoản và mật khẩu
                    connectionString = $"mongodb://{txtTaiKhoan.Text}:{txtMatKhau.Text}@{txtTenServer.Text}";
                    _config.AppSettings.Settings["LuaChon"].Value = "Sử Dụng Tài Khoản";
                }
                else
                {
                    // Tạo connection string không cần tài khoản
                    connectionString = $"mongodb://{txtTenServer.Text}";
                    _config.AppSettings.Settings["LuaChon"].Value = "Không Dùng Tài Khoản";
                }

                // Lưu connection string vào appSettings
                _config.AppSettings.Settings["MongoDBConnectionString"].Value = connectionString;
                _config.AppSettings.Settings["MongoDBDatabaseName"].Value = "QLSINHVIEN";
                _config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                // Kiểm tra kết nối
                if (KiemTraKetNoiMongoDB())
                {
                    MessageBox.Show("Kết nối MongoDB thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DangNhap DN = new DangNhap();
                    DN.ShowDialog(this);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kết nối MongoDB thất bại, hãy kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool KiemTraKetNoiMongoDB()
        {
            try
            {
                string connectionString = ConfigurationManager.AppSettings["MongoDBConnectionString"];
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(ConfigurationManager.AppSettings["MongoDBDatabaseName"]);

                // Kiểm tra truy cập database bằng cách liệt kê collection
                var collectionNames = database.ListCollectionNames().ToList();
                return true; // Kết nối thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kết nối thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Kết nối thất bại
            }
        }



        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHinhThuc.Text.Equals("Không Dùng Tài Khoản"))
            {
                txtTaiKhoan.Enabled = false;
                txtMatKhau.Enabled = false;
            }
            if (cbHinhThuc.Text.Equals("Sử Dụng Tài Khoản"))
            {
                txtTaiKhoan.Enabled = true;
                txtMatKhau.Enabled = true;
            }
        }
    }
}
