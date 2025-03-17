namespace QuanLyQuanAn
{
    partial class Mon
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
            this.components = new System.ComponentModel.Container();
            this.dgvMon = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.lblSTT = new System.Windows.Forms.Label();
            this.txtSTT = new System.Windows.Forms.TextBox();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.errSTT = new System.Windows.Forms.ErrorProvider(this.components);
            this.errTenMon = new System.Windows.Forms.ErrorProvider(this.components);
            this.errDonGia = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.errDonViTinh = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.taiKhoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyTaiKhoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanlyMonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanlyBanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanlyHDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongKeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongKeHoaDonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêMónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTenMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDonViTinh)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMon
            // 
            this.dgvMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMon.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMon.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvMon.Location = new System.Drawing.Point(561, 143);
            this.dgvMon.Name = "dgvMon";
            this.dgvMon.RowHeadersWidth = 51;
            this.dgvMon.RowTemplate.Height = 24;
            this.dgvMon.Size = new System.Drawing.Size(909, 349);
            this.dgvMon.TabIndex = 0;
            this.dgvMon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMon_CellClick);
            this.dgvMon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMon_CellContentClick);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(35, 292);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 32);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(135, 292);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 32);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(232, 292);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 32);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(949, 82);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 32);
            this.btnTim.TabIndex = 4;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // lblSTT
            // 
            this.lblSTT.AutoSize = true;
            this.lblSTT.Location = new System.Drawing.Point(32, 60);
            this.lblSTT.Name = "lblSTT";
            this.lblSTT.Size = new System.Drawing.Size(34, 16);
            this.lblSTT.TabIndex = 6;
            this.lblSTT.Text = "STT";
            // 
            // txtSTT
            // 
            this.txtSTT.Location = new System.Drawing.Point(144, 53);
            this.txtSTT.Name = "txtSTT";
            this.txtSTT.Size = new System.Drawing.Size(100, 22);
            this.txtSTT.TabIndex = 7;
            this.txtSTT.Validating += new System.ComponentModel.CancelEventHandler(this.txtSTT_Validating);
            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(144, 98);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(337, 22);
            this.txtTenMon.TabIndex = 9;
            this.txtTenMon.Validating += new System.ComponentModel.CancelEventHandler(this.txtTenMon_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tên món";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Danh mục";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(144, 190);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(169, 22);
            this.txtDonGia.TabIndex = 13;
            this.txtDonGia.Validating += new System.ComponentModel.CancelEventHandler(this.txtDonGia_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Đơn giá";
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(144, 145);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(169, 24);
            this.cboDanhMuc.TabIndex = 14;
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(561, 93);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(337, 22);
            this.txtTim.TabIndex = 16;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(332, 292);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 32);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "Làm lại";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(43, 292);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(0, 16);
            this.lblKetQua.TabIndex = 18;
            // 
            // errSTT
            // 
            this.errSTT.ContainerControl = this;
            // 
            // errTenMon
            // 
            this.errTenMon.ContainerControl = this;
            // 
            // errDonGia
            // 
            this.errDonGia.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Đơn vị tính";
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Location = new System.Drawing.Point(144, 234);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(169, 22);
            this.txtDonViTinh.TabIndex = 20;
            this.txtDonViTinh.Validating += new System.ComponentModel.CancelEventHandler(this.txtDonViTinh_Validating);
            // 
            // errDonViTinh
            // 
            this.errDonViTinh.ContainerControl = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taiKhoanToolStripMenuItem,
            this.quanLyTaiKhoanToolStripMenuItem,
            this.quanlyMonToolStripMenuItem,
            this.quanlyBanToolStripMenuItem,
            this.quanlyHDToolStripMenuItem,
            this.thongKeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1482, 28);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // taiKhoanToolStripMenuItem
            // 
            this.taiKhoanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thoátToolStripMenuItem});
            this.taiKhoanToolStripMenuItem.Name = "taiKhoanToolStripMenuItem";
            this.taiKhoanToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.taiKhoanToolStripMenuItem.Text = "Cài đặt";
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // quanLyTaiKhoanToolStripMenuItem
            // 
            this.quanLyTaiKhoanToolStripMenuItem.Name = "quanLyTaiKhoanToolStripMenuItem";
            this.quanLyTaiKhoanToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.quanLyTaiKhoanToolStripMenuItem.Text = "Quản lý tài khoản";
            this.quanLyTaiKhoanToolStripMenuItem.Click += new System.EventHandler(this.quanLyTaiKhoanToolStripMenuItem_Click);
            // 
            // quanlyMonToolStripMenuItem
            // 
            this.quanlyMonToolStripMenuItem.Name = "quanlyMonToolStripMenuItem";
            this.quanlyMonToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.quanlyMonToolStripMenuItem.Text = "Quản lý món";
            this.quanlyMonToolStripMenuItem.Click += new System.EventHandler(this.quanlyMonToolStripMenuItem_Click);
            // 
            // quanlyBanToolStripMenuItem
            // 
            this.quanlyBanToolStripMenuItem.Name = "quanlyBanToolStripMenuItem";
            this.quanlyBanToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.quanlyBanToolStripMenuItem.Text = "Quản lý bàn";
            this.quanlyBanToolStripMenuItem.Click += new System.EventHandler(this.quanlyBanToolStripMenuItem_Click);
            // 
            // quanlyHDToolStripMenuItem
            // 
            this.quanlyHDToolStripMenuItem.Name = "quanlyHDToolStripMenuItem";
            this.quanlyHDToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.quanlyHDToolStripMenuItem.Text = "Quản lý hóa đơn";
            this.quanlyHDToolStripMenuItem.Click += new System.EventHandler(this.quanlyHDToolStripMenuItem_Click);
            // 
            // thongKeToolStripMenuItem
            // 
            this.thongKeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thongKeHoaDonToolStripMenuItem,
            this.thốngKêMónToolStripMenuItem});
            this.thongKeToolStripMenuItem.Name = "thongKeToolStripMenuItem";
            this.thongKeToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.thongKeToolStripMenuItem.Text = "Thống kê";
            // 
            // thongKeHoaDonToolStripMenuItem
            // 
            this.thongKeHoaDonToolStripMenuItem.Name = "thongKeHoaDonToolStripMenuItem";
            this.thongKeHoaDonToolStripMenuItem.Size = new System.Drawing.Size(275, 26);
            this.thongKeHoaDonToolStripMenuItem.Text = "Thống kê doanh thu";
            this.thongKeHoaDonToolStripMenuItem.Click += new System.EventHandler(this.thongKeHoaDonToolStripMenuItem_Click);
            // 
            // thốngKêMónToolStripMenuItem
            // 
            this.thốngKêMónToolStripMenuItem.Name = "thốngKêMónToolStripMenuItem";
            this.thốngKêMónToolStripMenuItem.Size = new System.Drawing.Size(275, 26);
            this.thốngKêMónToolStripMenuItem.Text = "Thống kê số lượng đặt món";
            this.thốngKêMónToolStripMenuItem.Click += new System.EventHandler(this.thongKeDatMonToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(561, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Nhập tên món ăn cần tìm:";
            // 
            // Mon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 521);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtDonViTinh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.cboDanhMuc);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTenMon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSTT);
            this.Controls.Add(this.lblSTT);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvMon);
            this.Name = "Mon";
            this.Text = "Danh sách món";
            this.Load += new System.EventHandler(this.Mon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTenMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDonViTinh)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMon;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Label lblSTT;
        private System.Windows.Forms.TextBox txtSTT;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.ErrorProvider errSTT;
        private System.Windows.Forms.ErrorProvider errTenMon;
        private System.Windows.Forms.ErrorProvider errDonGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.ErrorProvider errDonViTinh;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem taiKhoanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyTaiKhoanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanlyMonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanlyBanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanlyHDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thongKeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thongKeHoaDonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêMónToolStripMenuItem;
        private System.Windows.Forms.Label label5;
    }
}

