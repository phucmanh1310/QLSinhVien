﻿namespace A.GiaoDien
{
    partial class QuanLyNganhDaoTao
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
            this.btXacNhan = new System.Windows.Forms.Button();
            this.btHoanTat = new System.Windows.Forms.Button();
            this.txtMaNganh = new System.Windows.Forms.TextBox();
            this.txtTenNganh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTenKhoa = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btXacNhan
            // 
            this.btXacNhan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXacNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btXacNhan.Image = global::A.GiaoDien.Properties.Resources.camera_test;
            this.btXacNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btXacNhan.Location = new System.Drawing.Point(45, 181);
            this.btXacNhan.Name = "btXacNhan";
            this.btXacNhan.Size = new System.Drawing.Size(109, 34);
            this.btXacNhan.TabIndex = 27;
            this.btXacNhan.Text = "Xác Nhận";
            this.btXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btXacNhan.UseVisualStyleBackColor = true;
            this.btXacNhan.Click += new System.EventHandler(this.btXacNhan_Click);
            // 
            // btHoanTat
            // 
            this.btHoanTat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHoanTat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btHoanTat.Image = global::A.GiaoDien.Properties.Resources.back_2;
            this.btHoanTat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btHoanTat.Location = new System.Drawing.Point(164, 181);
            this.btHoanTat.Name = "btHoanTat";
            this.btHoanTat.Size = new System.Drawing.Size(109, 34);
            this.btHoanTat.TabIndex = 28;
            this.btHoanTat.Text = "Hoàn Tất";
            this.btHoanTat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btHoanTat.UseVisualStyleBackColor = true;
            this.btHoanTat.Click += new System.EventHandler(this.btHoanTat_Click);
            // 
            // txtMaNganh
            // 
            this.txtMaNganh.Location = new System.Drawing.Point(123, 58);
            this.txtMaNganh.Name = "txtMaNganh";
            this.txtMaNganh.Size = new System.Drawing.Size(150, 20);
            this.txtMaNganh.TabIndex = 25;
            // 
            // txtTenNganh
            // 
            this.txtTenNganh.Location = new System.Drawing.Point(123, 96);
            this.txtTenNganh.Name = "txtTenNganh";
            this.txtTenNganh.Size = new System.Drawing.Size(150, 20);
            this.txtTenNganh.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(17, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Tên Ngành:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Mã Ngành:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 33);
            this.label1.TabIndex = 24;
            this.label1.Text = "Quản Lý Ngành Đào Tạo";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(17, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Tên Khoa:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbTenKhoa
            // 
            this.cbTenKhoa.FormattingEnabled = true;
            this.cbTenKhoa.Location = new System.Drawing.Point(124, 138);
            this.cbTenKhoa.Name = "cbTenKhoa";
            this.cbTenKhoa.Size = new System.Drawing.Size(149, 21);
            this.cbTenKhoa.TabIndex = 29;
            // 
            // QuanLyNganhDaoTao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 238);
            this.Controls.Add(this.cbTenKhoa);
            this.Controls.Add(this.btXacNhan);
            this.Controls.Add(this.btHoanTat);
            this.Controls.Add(this.txtMaNganh);
            this.Controls.Add(this.txtTenNganh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QuanLyNganhDaoTao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Ngành Đào Tạo";
            this.Load += new System.EventHandler(this.QuanLyNganhDaoTao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btXacNhan;
        private System.Windows.Forms.Button btHoanTat;
        private System.Windows.Forms.TextBox txtMaNganh;
        private System.Windows.Forms.TextBox txtTenNganh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTenKhoa;
    }
}