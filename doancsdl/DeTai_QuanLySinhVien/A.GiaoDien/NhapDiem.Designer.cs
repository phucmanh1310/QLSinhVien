﻿namespace A.GiaoDien
{
    partial class NhapDiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbKetQuaHocTap = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btXoa = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDiemThi = new System.Windows.Forms.TextBox();
            this.btChinhSua_QLD = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btXacNhan_QLD = new System.Windows.Forms.Button();
            this.txtDiemQuaTrinh = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbHocKy = new System.Windows.Forms.ComboBox();
            this.cbMonHoc = new System.Windows.Forms.ComboBox();
            this.txtTenSinhVien = new System.Windows.Forms.TextBox();
            this.txtMaSinhVien = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.brCuoi = new System.Windows.Forms.Button();
            this.btSau = new System.Windows.Forms.Button();
            this.btTruoc = new System.Windows.Forms.Button();
            this.btDau = new System.Windows.Forms.Button();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaHocKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaMonHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMonHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoTinChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemQuaTrinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKetLuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbKetQuaHocTap)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbKetQuaHocTap);
            this.groupBox6.Location = new System.Drawing.Point(15, 297);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(701, 286);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Kết Quả Học Tập Trong Kỳ.";
            // 
            // tbKetQuaHocTap
            // 
            this.tbKetQuaHocTap.AllowUserToAddRows = false;
            this.tbKetQuaHocTap.AllowUserToDeleteRows = false;
            this.tbKetQuaHocTap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbKetQuaHocTap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbKetQuaHocTap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colMaHocKy,
            this.colMaMonHoc,
            this.colTenMonHoc,
            this.colSoTinChi,
            this.colDiemQuaTrinh,
            this.colDiemThi,
            this.colDiemChu,
            this.colKetLuan});
            this.tbKetQuaHocTap.Location = new System.Drawing.Point(7, 20);
            this.tbKetQuaHocTap.Name = "tbKetQuaHocTap";
            this.tbKetQuaHocTap.ReadOnly = true;
            this.tbKetQuaHocTap.Size = new System.Drawing.Size(688, 260);
            this.tbKetQuaHocTap.TabIndex = 0;
            this.tbKetQuaHocTap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbKetQuaHocTap_CellClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btXoa);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.txtDiemThi);
            this.groupBox4.Controls.Add(this.btChinhSua_QLD);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.btXacNhan_QLD);
            this.groupBox4.Controls.Add(this.txtDiemQuaTrinh);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(15, 159);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(695, 94);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Điểm Quá Trình Và Điểm Thi.";
            // 
            // btXoa
            // 
            this.btXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btXoa.Image = global::A.GiaoDien.Properties.Resources.deletered32;
            this.btXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btXoa.Location = new System.Drawing.Point(461, 45);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(109, 42);
            this.btXoa.TabIndex = 10;
            this.btXoa.Text = "Xóa";
            this.btXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click_1);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(646, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 13);
            this.label20.TabIndex = 9;
            this.label20.Text = "Enter";
            // 
            // txtDiemThi
            // 
            this.txtDiemThi.Location = new System.Drawing.Point(490, 19);
            this.txtDiemThi.Name = "txtDiemThi";
            this.txtDiemThi.Size = new System.Drawing.Size(150, 20);
            this.txtDiemThi.TabIndex = 2;
            // 
            // btChinhSua_QLD
            // 
            this.btChinhSua_QLD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btChinhSua_QLD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btChinhSua_QLD.Image = global::A.GiaoDien.Properties.Resources.pencil_22;
            this.btChinhSua_QLD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btChinhSua_QLD.Location = new System.Drawing.Point(292, 45);
            this.btChinhSua_QLD.Name = "btChinhSua_QLD";
            this.btChinhSua_QLD.Size = new System.Drawing.Size(121, 42);
            this.btChinhSua_QLD.TabIndex = 4;
            this.btChinhSua_QLD.Text = "Chỉnh Sửa";
            this.btChinhSua_QLD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btChinhSua_QLD.UseVisualStyleBackColor = true;
            this.btChinhSua_QLD.Click += new System.EventHandler(this.btChinhSua_QLD_Click);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(384, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 20);
            this.label15.TabIndex = 2;
            this.label15.Text = "Điểm Thi(*):";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btXacNhan_QLD
            // 
            this.btXacNhan_QLD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXacNhan_QLD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btXacNhan_QLD.Image = global::A.GiaoDien.Properties.Resources.camera_test;
            this.btXacNhan_QLD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btXacNhan_QLD.Location = new System.Drawing.Point(140, 45);
            this.btXacNhan_QLD.Name = "btXacNhan_QLD";
            this.btXacNhan_QLD.Size = new System.Drawing.Size(116, 42);
            this.btXacNhan_QLD.TabIndex = 3;
            this.btXacNhan_QLD.Text = "Xác Nhận";
            this.btXacNhan_QLD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btXacNhan_QLD.UseVisualStyleBackColor = true;
            this.btXacNhan_QLD.Click += new System.EventHandler(this.btXacNhan_QLD_Click);
            // 
            // txtDiemQuaTrinh
            // 
            this.txtDiemQuaTrinh.Location = new System.Drawing.Point(118, 21);
            this.txtDiemQuaTrinh.Name = "txtDiemQuaTrinh";
            this.txtDiemQuaTrinh.Size = new System.Drawing.Size(150, 20);
            this.txtDiemQuaTrinh.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(9, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "Điểm Quá Trình(*):";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.cbHocKy);
            this.groupBox3.Controls.Add(this.cbMonHoc);
            this.groupBox3.Controls.Add(this.txtTenSinhVien);
            this.groupBox3.Controls.Add(this.txtMaSinhVien);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(15, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(701, 98);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Điền Và Chọn Những Thông Tin Cần Thiết.";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(646, 69);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 13);
            this.label21.TabIndex = 9;
            this.label21.Text = "Enter";
            // 
            // cbHocKy
            // 
            this.cbHocKy.FormattingEnabled = true;
            this.cbHocKy.Location = new System.Drawing.Point(119, 58);
            this.cbHocKy.Name = "cbHocKy";
            this.cbHocKy.Size = new System.Drawing.Size(150, 21);
            this.cbHocKy.TabIndex = 3;
            // 
            // cbMonHoc
            // 
            this.cbMonHoc.FormattingEnabled = true;
            this.cbMonHoc.Location = new System.Drawing.Point(490, 63);
            this.cbMonHoc.Name = "cbMonHoc";
            this.cbMonHoc.Size = new System.Drawing.Size(150, 21);
            this.cbMonHoc.TabIndex = 4;
            // 
            // txtTenSinhVien
            // 
            this.txtTenSinhVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSinhVien.ForeColor = System.Drawing.Color.Green;
            this.txtTenSinhVien.Location = new System.Drawing.Point(490, 22);
            this.txtTenSinhVien.Name = "txtTenSinhVien";
            this.txtTenSinhVien.Size = new System.Drawing.Size(150, 20);
            this.txtTenSinhVien.TabIndex = 2;
            // 
            // txtMaSinhVien
            // 
            this.txtMaSinhVien.Location = new System.Drawing.Point(118, 21);
            this.txtMaSinhVien.Name = "txtMaSinhVien";
            this.txtMaSinhVien.Size = new System.Drawing.Size(150, 20);
            this.txtMaSinhVien.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(12, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "Học Kỳ(*):";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(380, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Môn Học(*):";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(12, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "Mã Sinh Viên(*):";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(383, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tên Sinh Viên:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(218, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(320, 32);
            this.label9.TabIndex = 8;
            this.label9.Text = "Quản Lý Điểm Sinh Viên";
            // 
            // brCuoi
            // 
            this.brCuoi.Image = global::A.GiaoDien.Properties.Resources.Cuoi;
            this.brCuoi.Location = new System.Drawing.Point(489, 256);
            this.brCuoi.Name = "brCuoi";
            this.brCuoi.Size = new System.Drawing.Size(50, 39);
            this.brCuoi.TabIndex = 4;
            this.brCuoi.Text = ".";
            this.brCuoi.UseVisualStyleBackColor = true;
            this.brCuoi.Click += new System.EventHandler(this.brCuoi_Click);
            // 
            // btSau
            // 
            this.btSau.Image = global::A.GiaoDien.Properties.Resources.Tiep;
            this.btSau.Location = new System.Drawing.Point(398, 256);
            this.btSau.Name = "btSau";
            this.btSau.Size = new System.Drawing.Size(50, 39);
            this.btSau.TabIndex = 3;
            this.btSau.Text = ".";
            this.btSau.UseVisualStyleBackColor = true;
            this.btSau.Click += new System.EventHandler(this.btSau_Click);
            // 
            // btTruoc
            // 
            this.btTruoc.Image = global::A.GiaoDien.Properties.Resources.Sau;
            this.btTruoc.Location = new System.Drawing.Point(307, 256);
            this.btTruoc.Name = "btTruoc";
            this.btTruoc.Size = new System.Drawing.Size(50, 39);
            this.btTruoc.TabIndex = 2;
            this.btTruoc.Text = ".";
            this.btTruoc.UseVisualStyleBackColor = true;
            this.btTruoc.Click += new System.EventHandler(this.btTruoc_Click);
            // 
            // btDau
            // 
            this.btDau.Image = global::A.GiaoDien.Properties.Resources.Dau;
            this.btDau.Location = new System.Drawing.Point(221, 256);
            this.btDau.Name = "btDau";
            this.btDau.Size = new System.Drawing.Size(50, 39);
            this.btDau.TabIndex = 1;
            this.btDau.Text = ".";
            this.btDau.UseVisualStyleBackColor = true;
            this.btDau.Click += new System.EventHandler(this.btDau_Click);
            // 
            // colSTT
            // 
            this.colSTT.DataPropertyName = "STT";
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            // 
            // colMaHocKy
            // 
            this.colMaHocKy.DataPropertyName = "MaHocKy";
            this.colMaHocKy.HeaderText = "Mã Học Kỳ";
            this.colMaHocKy.Name = "colMaHocKy";
            this.colMaHocKy.ReadOnly = true;
            // 
            // colMaMonHoc
            // 
            this.colMaMonHoc.DataPropertyName = "MaMonHoc";
            this.colMaMonHoc.HeaderText = "Mã Môn Học";
            this.colMaMonHoc.Name = "colMaMonHoc";
            this.colMaMonHoc.ReadOnly = true;
            // 
            // colTenMonHoc
            // 
            this.colTenMonHoc.DataPropertyName = "TenMonHoc";
            this.colTenMonHoc.HeaderText = "Tên Môn Học";
            this.colTenMonHoc.Name = "colTenMonHoc";
            this.colTenMonHoc.ReadOnly = true;
            // 
            // colSoTinChi
            // 
            this.colSoTinChi.DataPropertyName = "SoTinChi";
            this.colSoTinChi.HeaderText = "Số Tín Chỉ";
            this.colSoTinChi.Name = "colSoTinChi";
            this.colSoTinChi.ReadOnly = true;
            // 
            // colDiemQuaTrinh
            // 
            this.colDiemQuaTrinh.DataPropertyName = "DiemQuaTrinh";
            this.colDiemQuaTrinh.HeaderText = "Điểm Quá Trình";
            this.colDiemQuaTrinh.Name = "colDiemQuaTrinh";
            this.colDiemQuaTrinh.ReadOnly = true;
            // 
            // colDiemThi
            // 
            this.colDiemThi.DataPropertyName = "DiemThi";
            this.colDiemThi.HeaderText = "Điểm Thi";
            this.colDiemThi.Name = "colDiemThi";
            this.colDiemThi.ReadOnly = true;
            // 
            // colDiemChu
            // 
            this.colDiemChu.DataPropertyName = "DiemChu";
            this.colDiemChu.HeaderText = "Điểm Chữ";
            this.colDiemChu.Name = "colDiemChu";
            this.colDiemChu.ReadOnly = true;
            // 
            // colKetLuan
            // 
            this.colKetLuan.DataPropertyName = "KetLuan";
            this.colKetLuan.HeaderText = "Kết Luận";
            this.colKetLuan.Name = "colKetLuan";
            this.colKetLuan.ReadOnly = true;
            // 
            // NhapDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 593);
            this.Controls.Add(this.brCuoi);
            this.Controls.Add(this.btSau);
            this.Controls.Add(this.btTruoc);
            this.Controls.Add(this.btDau);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label9);
            this.Name = "NhapDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Điểm";
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbKetQuaHocTap)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button brCuoi;
        private System.Windows.Forms.Button btSau;
        private System.Windows.Forms.Button btTruoc;
        private System.Windows.Forms.Button btDau;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView tbKetQuaHocTap;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDiemThi;
        private System.Windows.Forms.Button btChinhSua_QLD;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btXacNhan_QLD;
        private System.Windows.Forms.TextBox txtDiemQuaTrinh;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbHocKy;
        private System.Windows.Forms.ComboBox cbMonHoc;
        private System.Windows.Forms.TextBox txtTenSinhVien;
        private System.Windows.Forms.TextBox txtMaSinhVien;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHocKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTinChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemQuaTrinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKetLuan;
    }
}