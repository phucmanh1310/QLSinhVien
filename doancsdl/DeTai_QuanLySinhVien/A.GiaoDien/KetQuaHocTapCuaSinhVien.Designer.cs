namespace A.GiaoDien
{
    partial class KetQuaHocTapCuaSinhVien
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbKetQuaHocTap = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLop = new System.Windows.Forms.TextBox();
            this.txtMaSo = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDiemTBHe4 = new System.Windows.Forms.TextBox();
            this.txtDiemTBHe10 = new System.Windows.Forms.TextBox();
            this.txtSoTCDat = new System.Windows.Forms.TextBox();
            this.btAll = new System.Windows.Forms.Button();
            this.cbHocKy = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtDiemTLHe4 = new System.Windows.Forms.TextBox();
            this.txtDiemTLHe10 = new System.Windows.Forms.TextBox();
            this.txtSoTCTichLuy = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btInBaoCao = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbKetQuaHocTap)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(401, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kết Quả Học Tập";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbKetQuaHocTap);
            this.groupBox1.Location = new System.Drawing.Point(3, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 520);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bảng Điểm - Kết Quả Học Tập.";
            // 
            // tbKetQuaHocTap
            // 
            this.tbKetQuaHocTap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbKetQuaHocTap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbKetQuaHocTap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.tbKetQuaHocTap.Location = new System.Drawing.Point(6, 19);
            this.tbKetQuaHocTap.Name = "tbKetQuaHocTap";
            this.tbKetQuaHocTap.RowHeadersVisible = false;
            this.tbKetQuaHocTap.Size = new System.Drawing.Size(720, 495);
            this.tbKetQuaHocTap.TabIndex = 0;
            this.tbKetQuaHocTap.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbKetQuaHocTap_CellContentClick);
            this.tbKetQuaHocTap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.KichDup_ChinhSuaDiemCuaSinhVien);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "STT";
            this.Column1.HeaderText = "STT";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MaHocKy";
            this.Column2.HeaderText = "Mã Học Kỳ";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "MaMonHoc";
            this.Column3.HeaderText = "Mã Môn Học";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TenMonHoc";
            this.Column4.HeaderText = "Tên Môn Học";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "SoTinChi";
            this.Column5.HeaderText = "Số Tín Chỉ";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "DiemQuaTrinh";
            this.Column6.HeaderText = "Điểm Quá Trình";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "DiemThi";
            this.Column7.HeaderText = "Điểm Thi";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Diem Tong Ket";
            this.Column8.HeaderText = "Điểm Tổng Kết";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Diem Chu";
            this.Column9.HeaderText = "Điểm Chữ";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Diem Tich Luy";
            this.Column10.HeaderText = "Điểm Tích Lũy";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "KetLuan";
            this.Column11.HeaderText = "Kết Luận";
            this.Column11.Name = "Column11";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLop);
            this.groupBox2.Controls.Add(this.txtMaSo);
            this.groupBox2.Controls.Add(this.txtHoTen);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(741, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 144);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Sinh Viên.";
            // 
            // txtLop
            // 
            this.txtLop.Location = new System.Drawing.Point(106, 104);
            this.txtLop.Multiline = true;
            this.txtLop.Name = "txtLop";
            this.txtLop.Size = new System.Drawing.Size(150, 20);
            this.txtLop.TabIndex = 1;
            // 
            // txtMaSo
            // 
            this.txtMaSo.Location = new System.Drawing.Point(106, 61);
            this.txtMaSo.Multiline = true;
            this.txtMaSo.Name = "txtMaSo";
            this.txtMaSo.Size = new System.Drawing.Size(150, 20);
            this.txtMaSo.TabIndex = 1;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(106, 19);
            this.txtHoTen.Multiline = true;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(150, 20);
            this.txtHoTen.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(49, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Lớp Học:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(59, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã Số:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(54, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ Tên:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDiemTBHe4);
            this.groupBox3.Controls.Add(this.txtDiemTBHe10);
            this.groupBox3.Controls.Add(this.txtSoTCDat);
            this.groupBox3.Controls.Add(this.btAll);
            this.groupBox3.Controls.Add(this.cbHocKy);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(741, 214);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 176);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kết Quả Tổng Kết Học Kỳ.";
            // 
            // txtDiemTBHe4
            // 
            this.txtDiemTBHe4.Location = new System.Drawing.Point(106, 141);
            this.txtDiemTBHe4.Multiline = true;
            this.txtDiemTBHe4.Name = "txtDiemTBHe4";
            this.txtDiemTBHe4.Size = new System.Drawing.Size(150, 20);
            this.txtDiemTBHe4.TabIndex = 3;
            // 
            // txtDiemTBHe10
            // 
            this.txtDiemTBHe10.Location = new System.Drawing.Point(106, 102);
            this.txtDiemTBHe10.Multiline = true;
            this.txtDiemTBHe10.Name = "txtDiemTBHe10";
            this.txtDiemTBHe10.Size = new System.Drawing.Size(150, 20);
            this.txtDiemTBHe10.TabIndex = 3;
            // 
            // txtSoTCDat
            // 
            this.txtSoTCDat.Location = new System.Drawing.Point(106, 61);
            this.txtSoTCDat.Multiline = true;
            this.txtSoTCDat.Name = "txtSoTCDat";
            this.txtSoTCDat.Size = new System.Drawing.Size(150, 20);
            this.txtSoTCDat.TabIndex = 3;
            // 
            // btAll
            // 
            this.btAll.Image = global::A.GiaoDien.Properties.Resources.select;
            this.btAll.Location = new System.Drawing.Point(232, 19);
            this.btAll.Name = "btAll";
            this.btAll.Size = new System.Drawing.Size(24, 23);
            this.btAll.TabIndex = 2;
            this.btAll.UseVisualStyleBackColor = true;
            this.btAll.Click += new System.EventHandler(this.btAll_Click);
            // 
            // cbHocKy
            // 
            this.cbHocKy.FormattingEnabled = true;
            this.cbHocKy.Location = new System.Drawing.Point(106, 20);
            this.cbHocKy.Name = "cbHocKy";
            this.cbHocKy.Size = new System.Drawing.Size(124, 21);
            this.cbHocKy.TabIndex = 1;
            this.cbHocKy.SelectedValueChanged += new System.EventHandler(this.ChonKyHoc_LoadDiem);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(37, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Điểm TB(4):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(31, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Điểm TB(10):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(41, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Số TC Đạt:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(48, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Học Kỳ:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtDiemTLHe4);
            this.groupBox4.Controls.Add(this.txtDiemTLHe10);
            this.groupBox4.Controls.Add(this.txtSoTCTichLuy);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.ForeColor = System.Drawing.Color.Red;
            this.groupBox4.Location = new System.Drawing.Point(745, 419);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(262, 145);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Kết Quả Tổng Kết Đào Tạo.";
            // 
            // txtDiemTLHe4
            // 
            this.txtDiemTLHe4.Location = new System.Drawing.Point(107, 101);
            this.txtDiemTLHe4.Multiline = true;
            this.txtDiemTLHe4.Name = "txtDiemTLHe4";
            this.txtDiemTLHe4.Size = new System.Drawing.Size(149, 20);
            this.txtDiemTLHe4.TabIndex = 3;
            // 
            // txtDiemTLHe10
            // 
            this.txtDiemTLHe10.Location = new System.Drawing.Point(107, 63);
            this.txtDiemTLHe10.Multiline = true;
            this.txtDiemTLHe10.Name = "txtDiemTLHe10";
            this.txtDiemTLHe10.Size = new System.Drawing.Size(149, 20);
            this.txtDiemTLHe10.TabIndex = 3;
            // 
            // txtSoTCTichLuy
            // 
            this.txtSoTCTichLuy.Location = new System.Drawing.Point(107, 26);
            this.txtSoTCTichLuy.Multiline = true;
            this.txtSoTCTichLuy.Name = "txtSoTCTichLuy";
            this.txtSoTCTichLuy.Size = new System.Drawing.Size(149, 20);
            this.txtSoTCTichLuy.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(11, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Điểm Tích Lũy(4):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(6, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Điểm Tích Lũy(10):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(14, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Số TC Tích Lũy:";
            // 
            // btInBaoCao
            // 
            this.btInBaoCao.Image = global::A.GiaoDien.Properties.Resources.printer_21;
            this.btInBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInBaoCao.Location = new System.Drawing.Point(910, 9);
            this.btInBaoCao.Name = "btInBaoCao";
            this.btInBaoCao.Size = new System.Drawing.Size(91, 32);
            this.btInBaoCao.TabIndex = 5;
            this.btInBaoCao.Text = "In Báo Cáo";
            this.btInBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInBaoCao.UseVisualStyleBackColor = true;
           /* this.btInBaoCao.Click += new System.EventHandler(this.btInBaoCao_Click);*/
            // 
            // KetQuaHocTapCuaSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 568);
            this.Controls.Add(this.btInBaoCao);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "KetQuaHocTapCuaSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết Quả Học Tập Của Sinh Viên";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbKetQuaHocTap)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLop;
        private System.Windows.Forms.TextBox txtMaSo;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btAll;
        private System.Windows.Forms.ComboBox cbHocKy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView tbKetQuaHocTap;
        private System.Windows.Forms.TextBox txtDiemTBHe4;
        private System.Windows.Forms.TextBox txtDiemTBHe10;
        private System.Windows.Forms.TextBox txtSoTCDat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiemTLHe4;
        private System.Windows.Forms.TextBox txtDiemTLHe10;
        private System.Windows.Forms.TextBox txtSoTCTichLuy;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Button btInBaoCao;
    }
}