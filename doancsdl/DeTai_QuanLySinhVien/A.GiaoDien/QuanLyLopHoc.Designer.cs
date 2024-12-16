namespace A.GiaoDien
{
    partial class QuanLyLopHoc
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.cbHeDaoTao = new System.Windows.Forms.ComboBox();
            this.cbTenNganh = new System.Windows.Forms.ComboBox();
            this.cbKhoaHoc = new System.Windows.Forms.ComboBox();
            this.et1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btHoanTat = new System.Windows.Forms.Button();
            this.btXacNhan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(189, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Lớp Học";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Lớp:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên Lớp:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(291, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Hệ Đào Tạo:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Khóa Học:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(291, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tên Ngành:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaLop
            // 
            this.txtMaLop.Location = new System.Drawing.Point(119, 58);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Size = new System.Drawing.Size(150, 20);
            this.txtMaLop.TabIndex = 1;
            // 
            // txtTenLop
            // 
            this.txtTenLop.Location = new System.Drawing.Point(119, 103);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(150, 20);
            this.txtTenLop.TabIndex = 2;
            this.txtTenLop.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KhiAnEnTerOTenLop);
            // 
            // cbHeDaoTao
            // 
            this.cbHeDaoTao.FormattingEnabled = true;
            this.cbHeDaoTao.Location = new System.Drawing.Point(398, 56);
            this.cbHeDaoTao.Name = "cbHeDaoTao";
            this.cbHeDaoTao.Size = new System.Drawing.Size(150, 21);
            this.cbHeDaoTao.TabIndex = 4;
            // 
            // cbTenNganh
            // 
            this.cbTenNganh.FormattingEnabled = true;
            this.cbTenNganh.Location = new System.Drawing.Point(398, 101);
            this.cbTenNganh.Name = "cbTenNganh";
            this.cbTenNganh.Size = new System.Drawing.Size(150, 21);
            this.cbTenNganh.TabIndex = 5;
            this.cbTenNganh.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimKiemNganhDaoTao);
            // 
            // cbKhoaHoc
            // 
            this.cbKhoaHoc.FormattingEnabled = true;
            this.cbKhoaHoc.Location = new System.Drawing.Point(119, 148);
            this.cbKhoaHoc.Name = "cbKhoaHoc";
            this.cbKhoaHoc.Size = new System.Drawing.Size(150, 21);
            this.cbKhoaHoc.TabIndex = 3;
            // 
            // et1
            // 
            this.et1.AutoSize = true;
            this.et1.ForeColor = System.Drawing.Color.Red;
            this.et1.Location = new System.Drawing.Point(275, 106);
            this.et1.Name = "et1";
            this.et1.Size = new System.Drawing.Size(32, 13);
            this.et1.TabIndex = 37;
            this.et1.Text = "Enter";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(554, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Enter";
            // 
            // btHoanTat
            // 
            this.btHoanTat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHoanTat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btHoanTat.Image = global::A.GiaoDien.Properties.Resources.back_2;
            this.btHoanTat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btHoanTat.Location = new System.Drawing.Point(322, 191);
            this.btHoanTat.Name = "btHoanTat";
            this.btHoanTat.Size = new System.Drawing.Size(114, 41);
            this.btHoanTat.TabIndex = 7;
            this.btHoanTat.Text = "Hoàn Tất";
            this.btHoanTat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btHoanTat.UseVisualStyleBackColor = true;
            this.btHoanTat.Click += new System.EventHandler(this.btHoanTat_Click);
            // 
            // btXacNhan
            // 
            this.btXacNhan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXacNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btXacNhan.Image = global::A.GiaoDien.Properties.Resources.camera_test;
            this.btXacNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btXacNhan.Location = new System.Drawing.Point(163, 191);
            this.btXacNhan.Name = "btXacNhan";
            this.btXacNhan.Size = new System.Drawing.Size(106, 41);
            this.btXacNhan.TabIndex = 6;
            this.btXacNhan.Text = "Xác Nhận";
            this.btXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btXacNhan.UseVisualStyleBackColor = true;
            this.btXacNhan.Click += new System.EventHandler(this.btXacNhan_Click);
            // 
            // QuanLyLopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 244);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.et1);
            this.Controls.Add(this.btHoanTat);
            this.Controls.Add(this.btXacNhan);
            this.Controls.Add(this.cbKhoaHoc);
            this.Controls.Add(this.cbTenNganh);
            this.Controls.Add(this.cbHeDaoTao);
            this.Controls.Add(this.txtTenLop);
            this.Controls.Add(this.txtMaLop);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QuanLyLopHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Lớp Học";
            this.Load += new System.EventHandler(this.QuanLyLopHoc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.ComboBox cbHeDaoTao;
        private System.Windows.Forms.ComboBox cbTenNganh;
        private System.Windows.Forms.ComboBox cbKhoaHoc;
        private System.Windows.Forms.Button btXacNhan;
        private System.Windows.Forms.Button btHoanTat;
        private System.Windows.Forms.Label et1;
        private System.Windows.Forms.Label label7;
    }
}