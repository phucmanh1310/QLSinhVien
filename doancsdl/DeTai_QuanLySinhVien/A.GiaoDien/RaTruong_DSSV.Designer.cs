namespace A.GiaoDien
{
    partial class RaTruong_DSSV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaTruong_DSSV));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btDSSV_RaTruong = new System.Windows.Forms.ToolStripButton();
            this.btDSSV_NhanBang = new System.Windows.Forms.ToolStripButton();
            this.btDSSV_KhongNhanBang = new System.Windows.Forms.ToolStripButton();
            this.btInBaoCao = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDanhSachSinhVien = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDanhSachSinhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btDSSV_RaTruong,
            this.btDSSV_NhanBang,
            this.btDSSV_KhongNhanBang,
            this.btInBaoCao});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(857, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btDSSV_RaTruong
            // 
            this.btDSSV_RaTruong.Image = ((System.Drawing.Image)(resources.GetObject("btDSSV_RaTruong.Image")));
            this.btDSSV_RaTruong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDSSV_RaTruong.Name = "btDSSV_RaTruong";
            this.btDSSV_RaTruong.Size = new System.Drawing.Size(112, 22);
            this.btDSSV_RaTruong.Text = "DSSV Ra Trường";
            this.btDSSV_RaTruong.Click += new System.EventHandler(this.btDSSV_RaTruong_Click);
            // 
            // btDSSV_NhanBang
            // 
            this.btDSSV_NhanBang.Image = ((System.Drawing.Image)(resources.GetObject("btDSSV_NhanBang.Image")));
            this.btDSSV_NhanBang.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDSSV_NhanBang.Name = "btDSSV_NhanBang";
            this.btDSSV_NhanBang.Size = new System.Drawing.Size(147, 22);
            this.btDSSV_NhanBang.Text = "DSSV Được Nhận Bằng";
            this.btDSSV_NhanBang.Click += new System.EventHandler(this.btDSSV_NhanBang_Click);
            // 
            // btDSSV_KhongNhanBang
            // 
            this.btDSSV_KhongNhanBang.Image = ((System.Drawing.Image)(resources.GetObject("btDSSV_KhongNhanBang.Image")));
            this.btDSSV_KhongNhanBang.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDSSV_KhongNhanBang.Name = "btDSSV_KhongNhanBang";
            this.btDSSV_KhongNhanBang.Size = new System.Drawing.Size(185, 22);
            this.btDSSV_KhongNhanBang.Text = "DSSV Không Được Nhận Bằng";
            this.btDSSV_KhongNhanBang.Click += new System.EventHandler(this.btDSSV_KhongNhanBang_Click);
            // 
            // btInBaoCao
            // 
            this.btInBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("btInBaoCao.Image")));
            this.btInBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInBaoCao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btInBaoCao.Name = "btInBaoCao";
            this.btInBaoCao.Size = new System.Drawing.Size(84, 22);
            this.btInBaoCao.Text = "In Báo Cáo";
            this.btInBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            /*this.btInBaoCao.Click += new System.EventHandler(this.btInBaoCao_Click);*/
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDanhSachSinhVien);
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(857, 558);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Sinh Viên.";
            // 
            // tbDanhSachSinhVien
            // 
            this.tbDanhSachSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbDanhSachSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbDanhSachSinhVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.tbDanhSachSinhVien.Location = new System.Drawing.Point(6, 19);
            this.tbDanhSachSinhVien.Name = "tbDanhSachSinhVien";
            this.tbDanhSachSinhVien.RowHeadersVisible = false;
            this.tbDanhSachSinhVien.Size = new System.Drawing.Size(845, 531);
            this.tbDanhSachSinhVien.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaSinhVien";
            this.Column1.HeaderText = "Mã Sinh Viên";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenSinhVien";
            this.Column2.HeaderText = "Tên Sinh Viên";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "GioiTinh";
            this.Column3.HeaderText = "Giới Tính";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TenLop";
            this.Column4.HeaderText = "Tên Lớp";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "MaKhoaHoc";
            this.Column5.HeaderText = "Mã Khóa Học";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "TenHe";
            this.Column6.HeaderText = "Tên Hệ";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "TenNganh";
            this.Column7.HeaderText = "Tên Ngành";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "TenKhoa";
            this.Column8.HeaderText = "Tên Khoa";
            this.Column8.Name = "Column8";
            // 
            // RaTruong_DSSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 590);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RaTruong_DSSV";
            this.Text = "RaTruong_DSSV";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbDanhSachSinhVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btDSSV_RaTruong;
        private System.Windows.Forms.ToolStripButton btDSSV_NhanBang;
        private System.Windows.Forms.ToolStripButton btDSSV_KhongNhanBang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView tbDanhSachSinhVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.ToolStripButton btInBaoCao;
    }
}