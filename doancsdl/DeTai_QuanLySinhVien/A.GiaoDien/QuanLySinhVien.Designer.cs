namespace A.GiaoDien
{
    partial class QuanLySinhVien
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
            this.btThem = new System.Windows.Forms.Button();
            this.ChonAnh = new System.Windows.Forms.Button();
            this.AnhSV = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.raCo = new System.Windows.Forms.RadioButton();
            this.raKhong = new System.Windows.Forms.RadioButton();
            this.txtDiaChi = new System.Windows.Forms.RichTextBox();
            this.cbLop = new System.Windows.Forms.ComboBox();
            this.raNu = new System.Windows.Forms.RadioButton();
            this.raNam = new System.Windows.Forms.RadioButton();
            this.txtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtTenSinhVien = new System.Windows.Forms.TextBox();
            this.txtMaSinhVien = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btHoanTat = new System.Windows.Forms.Button();
            this.et1 = new System.Windows.Forms.Label();
            this.et2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AnhSV)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btThem
            // 
            this.btThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btThem.Image = global::A.GiaoDien.Properties.Resources.camera_test;
            this.btThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThem.Location = new System.Drawing.Point(305, 339);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(116, 37);
            this.btThem.TabIndex = 11;
            this.btThem.Text = "Xác Nhận";
            this.btThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // ChonAnh
            // 
            this.ChonAnh.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChonAnh.ForeColor = System.Drawing.Color.Red;
            this.ChonAnh.Location = new System.Drawing.Point(721, 277);
            this.ChonAnh.Name = "ChonAnh";
            this.ChonAnh.Size = new System.Drawing.Size(75, 23);
            this.ChonAnh.TabIndex = 10;
            this.ChonAnh.Text = "Chọn Ảnh";
            this.ChonAnh.UseVisualStyleBackColor = true;
            this.ChonAnh.Click += new System.EventHandler(this.ChonAnh_Click);
            // 
            // AnhSV
            // 
            this.AnhSV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnhSV.Location = new System.Drawing.Point(702, 129);
            this.AnhSV.Name = "AnhSV";
            this.AnhSV.Size = new System.Drawing.Size(121, 135);
            this.AnhSV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.AnhSV.TabIndex = 35;
            this.AnhSV.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.raCo);
            this.panel1.Controls.Add(this.raKhong);
            this.panel1.Location = new System.Drawing.Point(174, 272);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 27);
            this.panel1.TabIndex = 33;
            // 
            // raCo
            // 
            this.raCo.AutoSize = true;
            this.raCo.Location = new System.Drawing.Point(3, 3);
            this.raCo.Name = "raCo";
            this.raCo.Size = new System.Drawing.Size(38, 17);
            this.raCo.TabIndex = 4;
            this.raCo.TabStop = true;
            this.raCo.Text = "Có";
            this.raCo.UseVisualStyleBackColor = true;
            this.raCo.CheckedChanged += new System.EventHandler(this.raCo_CheckedChanged);
            // 
            // raKhong
            // 
            this.raKhong.AutoSize = true;
            this.raKhong.Location = new System.Drawing.Point(75, 3);
            this.raKhong.Name = "raKhong";
            this.raKhong.Size = new System.Drawing.Size(56, 17);
            this.raKhong.TabIndex = 5;
            this.raKhong.TabStop = true;
            this.raKhong.Text = "Không";
            this.raKhong.UseVisualStyleBackColor = true;
            this.raKhong.CheckedChanged += new System.EventHandler(this.raKhong_CheckedChanged);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(497, 227);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(154, 72);
            this.txtDiaChi.TabIndex = 9;
            this.txtDiaChi.Text = "";
            this.txtDiaChi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EnterDiaChi);
            // 
            // cbLop
            // 
            this.cbLop.FormattingEnabled = true;
            this.cbLop.Location = new System.Drawing.Point(497, 130);
            this.cbLop.Name = "cbLop";
            this.cbLop.Size = new System.Drawing.Size(150, 21);
            this.cbLop.TabIndex = 6;
            // 
            // raNu
            // 
            this.raNu.AutoSize = true;
            this.raNu.Location = new System.Drawing.Point(581, 181);
            this.raNu.Name = "raNu";
            this.raNu.Size = new System.Drawing.Size(39, 17);
            this.raNu.TabIndex = 8;
            this.raNu.TabStop = true;
            this.raNu.Text = "Nữ";
            this.raNu.UseVisualStyleBackColor = true;
            this.raNu.CheckedChanged += new System.EventHandler(this.raNu_CheckedChanged);
            // 
            // raNam
            // 
            this.raNam.AutoSize = true;
            this.raNam.Location = new System.Drawing.Point(497, 182);
            this.raNam.Name = "raNam";
            this.raNam.Size = new System.Drawing.Size(47, 17);
            this.raNam.TabIndex = 7;
            this.raNam.Text = "Nam";
            this.raNam.UseVisualStyleBackColor = true;
            this.raNam.CheckedChanged += new System.EventHandler(this.raNam_CheckedChanged);
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.txtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgaySinh.Location = new System.Drawing.Point(174, 224);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(150, 20);
            this.txtNgaySinh.TabIndex = 3;
            // 
            // txtTenSinhVien
            // 
            this.txtTenSinhVien.Location = new System.Drawing.Point(174, 178);
            this.txtTenSinhVien.Multiline = true;
            this.txtTenSinhVien.Name = "txtTenSinhVien";
            this.txtTenSinhVien.Size = new System.Drawing.Size(150, 20);
            this.txtTenSinhVien.TabIndex = 2;
            this.txtTenSinhVien.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EnterTenSinhVien);
            // 
            // txtMaSinhVien
            // 
            this.txtMaSinhVien.Location = new System.Drawing.Point(174, 129);
            this.txtMaSinhVien.Multiline = true;
            this.txtMaSinhVien.Name = "txtMaSinhVien";
            this.txtMaSinhVien.Size = new System.Drawing.Size(150, 20);
            this.txtMaSinhVien.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Chính Sách Ưu Tiên:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(407, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "Địa Chỉ:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(407, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Lớp:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(395, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Giới Tính:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Ngày Sinh:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Tên Sinh Viên:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(24, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Mã Sinh Viên:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(309, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 32);
            this.label1.TabIndex = 18;
            this.label1.Text = "Thông Tin Sinh Viên.";
            // 
            // btHoanTat
            // 
            this.btHoanTat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHoanTat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btHoanTat.Image = global::A.GiaoDien.Properties.Resources.back_2;
            this.btHoanTat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btHoanTat.Location = new System.Drawing.Point(477, 339);
            this.btHoanTat.Name = "btHoanTat";
            this.btHoanTat.Size = new System.Drawing.Size(116, 37);
            this.btHoanTat.TabIndex = 12;
            this.btHoanTat.Text = "Hoàn Tất";
            this.btHoanTat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btHoanTat.UseVisualStyleBackColor = true;
            this.btHoanTat.Click += new System.EventHandler(this.btHoanTat_Click);
            // 
            // et1
            // 
            this.et1.AutoSize = true;
            this.et1.ForeColor = System.Drawing.Color.Red;
            this.et1.Location = new System.Drawing.Point(331, 182);
            this.et1.Name = "et1";
            this.et1.Size = new System.Drawing.Size(32, 13);
            this.et1.TabIndex = 36;
            this.et1.Text = "Enter";
            // 
            // et2
            // 
            this.et2.AutoSize = true;
            this.et2.ForeColor = System.Drawing.Color.Red;
            this.et2.Location = new System.Drawing.Point(657, 229);
            this.et2.Name = "et2";
            this.et2.Size = new System.Drawing.Size(32, 13);
            this.et2.TabIndex = 36;
            this.et2.Text = "Enter";
            // 
            // QuanLySinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 409);
            this.Controls.Add(this.et2);
            this.Controls.Add(this.et1);
            this.Controls.Add(this.btHoanTat);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.ChonAnh);
            this.Controls.Add(this.AnhSV);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.cbLop);
            this.Controls.Add(this.raNu);
            this.Controls.Add(this.raNam);
            this.Controls.Add(this.txtNgaySinh);
            this.Controls.Add(this.txtTenSinhVien);
            this.Controls.Add(this.txtMaSinhVien);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QuanLySinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Sinh Viên";
            this.Load += new System.EventHandler(this.QuanLySinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AnhSV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button ChonAnh;
        private System.Windows.Forms.PictureBox AnhSV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton raCo;
        private System.Windows.Forms.RadioButton raKhong;
        private System.Windows.Forms.RichTextBox txtDiaChi;
        private System.Windows.Forms.ComboBox cbLop;
        private System.Windows.Forms.RadioButton raNu;
        private System.Windows.Forms.RadioButton raNam;
        private System.Windows.Forms.DateTimePicker txtNgaySinh;
        private System.Windows.Forms.TextBox txtTenSinhVien;
        private System.Windows.Forms.TextBox txtMaSinhVien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btHoanTat;
        private System.Windows.Forms.Label et1;
        private System.Windows.Forms.Label et2;
    }
}