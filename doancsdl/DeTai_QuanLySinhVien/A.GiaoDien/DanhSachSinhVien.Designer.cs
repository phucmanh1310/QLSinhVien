namespace A.GiaoDien
{
    partial class DanhSachSinhVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanhSachSinhVien));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.btThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.btSua = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.btXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.lbTimKiem = new System.Windows.Forms.ToolStripLabel();
            this.txtTimKiem = new System.Windows.Forms.ToolStripTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDanhSachSinhVien = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btXemDiem = new System.Windows.Forms.ToolStripButton();
            this.btInBaoCao = new System.Windows.Forms.ToolStripButton();
            this.colMaSinhVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSinhVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChinhSachUuTien = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDanhSachSinhVien)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.btThem,
            this.toolStripLabel2,
            this.btSua,
            this.toolStripLabel4,
            this.btXoa,
            this.toolStripLabel5,
            this.lbTimKiem,
            this.txtTimKiem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(857, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel3.Text = "(F9)>";
            // 
            // btThem
            // 
            this.btThem.Image = ((System.Drawing.Image)(resources.GetObject("btThem.Image")));
            this.btThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(112, 22);
            this.btThem.Text = "Thêm Sinh Viên.";
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(41, 22);
            this.toolStripLabel2.Text = "(F10)>";
            // 
            // btSua
            // 
            this.btSua.Image = ((System.Drawing.Image)(resources.GetObject("btSua.Image")));
            this.btSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(105, 22);
            this.btSua.Text = "Sửa Thông Tin.";
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(41, 22);
            this.toolStripLabel4.Text = "(F11)>";
            // 
            // btXoa
            // 
            this.btXoa.Image = ((System.Drawing.Image)(resources.GetObject("btXoa.Image")));
            this.btXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(102, 22);
            this.btXoa.Text = "Xóa Sinh Viên.";
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(41, 22);
            this.toolStripLabel5.Text = "(F12)>";
            // 
            // lbTimKiem
            // 
            this.lbTimKiem.Name = "lbTimKiem";
            this.lbTimKiem.Size = new System.Drawing.Size(173, 22);
            this.lbTimKiem.Text = "Tìm Kiếm (Mã Số, Họ Tên, Lớp):";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(150, 25);
            this.txtTimKiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimKiem);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDanhSachSinhVien);
            this.groupBox1.Location = new System.Drawing.Point(1, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(856, 535);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Sinh Viên.";
            // 
            // tbDanhSachSinhVien
            // 
            this.tbDanhSachSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbDanhSachSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbDanhSachSinhVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSinhVien,
            this.colTenSinhVien,
            this.colNgaySinh,
            this.GioiTinh,
            this.colLop,
            this.colDiaChi,
            this.ChinhSachUuTien});
            this.tbDanhSachSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDanhSachSinhVien.Location = new System.Drawing.Point(3, 16);
            this.tbDanhSachSinhVien.Name = "tbDanhSachSinhVien";
            this.tbDanhSachSinhVien.RowHeadersVisible = false;
            this.tbDanhSachSinhVien.Size = new System.Drawing.Size(850, 516);
            this.tbDanhSachSinhVien.TabIndex = 0;
            this.tbDanhSachSinhVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbDanhSachSinhVien_CellClick);
            this.tbDanhSachSinhVien.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DupChuot_XemKetQuaHocTap);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.btXemDiem,
            this.btInBaoCao});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(857, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel1.Text = "(F1)>";
            // 
            // btXemDiem
            // 
            this.btXemDiem.Image = ((System.Drawing.Image)(resources.GetObject("btXemDiem.Image")));
            this.btXemDiem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btXemDiem.Name = "btXemDiem";
            this.btXemDiem.Size = new System.Drawing.Size(85, 22);
            this.btXemDiem.Text = "Xem Điểm.";
            this.btXemDiem.Click += new System.EventHandler(this.btXemDiem_Click);
            // 
            // btInBaoCao
            // 
            this.btInBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("btInBaoCao.Image")));
            this.btInBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInBaoCao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btInBaoCao.Name = "btInBaoCao";
            this.btInBaoCao.Size = new System.Drawing.Size(84, 22);
            this.btInBaoCao.Text = "In Báo Cáo";
            // 
            // colMaSinhVien
            // 
            this.colMaSinhVien.DataPropertyName = "MaSinhVien";
            this.colMaSinhVien.HeaderText = "Mã Sinh Viên";
            this.colMaSinhVien.Name = "colMaSinhVien";
            // 
            // colTenSinhVien
            // 
            this.colTenSinhVien.DataPropertyName = "TenSinhVien";
            this.colTenSinhVien.HeaderText = "Tên Sinh Viên";
            this.colTenSinhVien.Name = "colTenSinhVien";
            this.colTenSinhVien.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.DataPropertyName = "NgaySinh";
            this.colNgaySinh.HeaderText = "Ngày Sinh";
            this.colNgaySinh.Name = "colNgaySinh";
            // 
            // GioiTinh
            // 
            this.GioiTinh.DataPropertyName = "GioiTinh";
            this.GioiTinh.HeaderText = "Giới Tính";
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GioiTinh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colLop
            // 
            this.colLop.DataPropertyName = "Lop";
            this.colLop.HeaderText = "Lớp";
            this.colLop.Name = "colLop";
            // 
            // colDiaChi
            // 
            this.colDiaChi.DataPropertyName = "DiaChi";
            this.colDiaChi.HeaderText = "Địa Chỉ";
            this.colDiaChi.Name = "colDiaChi";
            // 
            // ChinhSachUuTien
            // 
            this.ChinhSachUuTien.DataPropertyName = "ChinhSachUuTien";
            this.ChinhSachUuTien.HeaderText = "Chính Sách Ưu Tiên";
            this.ChinhSachUuTien.Name = "ChinhSachUuTien";
            this.ChinhSachUuTien.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ChinhSachUuTien.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DanhSachSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 590);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DanhSachSinhVien";
            this.Text = "DanhSachSinhVien";
            this.Load += new System.EventHandler(this.DanhSachSinhVien_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbDanhSachSinhVien)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btThem;
        private System.Windows.Forms.ToolStripButton btSua;
        private System.Windows.Forms.ToolStripButton btXoa;
        private System.Windows.Forms.ToolStripLabel lbTimKiem;
        private System.Windows.Forms.ToolStripTextBox txtTimKiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView tbDanhSachSinhVien;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btXemDiem;
        private System.Windows.Forms.ToolStripButton btInBaoCao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSinhVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSinhVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgaySinh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiaChi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChinhSachUuTien;
    }
}