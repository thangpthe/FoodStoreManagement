namespace QuanLyQuanAn
{
    partial class Ban
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
            this.dgvBan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBan = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.rdbCo = new System.Windows.Forms.RadioButton();
            this.rdbTrong = new System.Windows.Forms.RadioButton();
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
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBan)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBan
            // 
            this.dgvBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBan.Location = new System.Drawing.Point(413, 176);
            this.dgvBan.Name = "dgvBan";
            this.dgvBan.RowHeadersWidth = 51;
            this.dgvBan.RowTemplate.Height = 24;
            this.dgvBan.Size = new System.Drawing.Size(390, 330);
            this.dgvBan.TabIndex = 0;
            this.dgvBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBan_CellClick);
            this.dgvBan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBan_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số bàn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trạng thái";
            // 
            // txtBan
            // 
            this.txtBan.Location = new System.Drawing.Point(150, 81);
            this.txtBan.Name = "txtBan";
            this.txtBan.Size = new System.Drawing.Size(100, 22);
            this.txtBan.TabIndex = 3;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(109, 199);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(96, 32);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Cập nhật";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(728, 118);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 6;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(220, 199);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 32);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(413, 118);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(279, 22);
            this.txtTim.TabIndex = 8;
            // 
            // rdbCo
            // 
            this.rdbCo.AutoSize = true;
            this.rdbCo.Location = new System.Drawing.Point(150, 132);
            this.rdbCo.Name = "rdbCo";
            this.rdbCo.Size = new System.Drawing.Size(81, 20);
            this.rdbCo.TabIndex = 11;
            this.rdbCo.TabStop = true;
            this.rdbCo.Text = "Có người";
            this.rdbCo.UseVisualStyleBackColor = true;
            // 
            // rdbTrong
            // 
            this.rdbTrong.AutoSize = true;
            this.rdbTrong.Location = new System.Drawing.Point(260, 131);
            this.rdbTrong.Name = "rdbTrong";
            this.rdbTrong.Size = new System.Drawing.Size(64, 20);
            this.rdbTrong.TabIndex = 12;
            this.rdbTrong.TabStop = true;
            this.rdbTrong.Text = "Trống";
            this.rdbTrong.UseVisualStyleBackColor = true;
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
            this.menuStrip1.Size = new System.Drawing.Size(837, 28);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // taiKhoanToolStripMenuItem
            // 
            this.taiKhoanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thoátToolStripMenuItem});
            this.taiKhoanToolStripMenuItem.Name = "taiKhoanToolStripMenuItem";
            this.taiKhoanToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.taiKhoanToolStripMenuItem.Text = "Cài đặt";
            this.taiKhoanToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.thoátToolStripMenuItem.Text = "Thoát";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(413, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tìm bàn theo trạng thái";
            // 
            // Ban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 625);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.rdbTrong);
            this.Controls.Add(this.rdbCo);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.txtBan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBan);
            this.Name = "Ban";
            this.Text = "Quản lý bàn";
            this.Load += new System.EventHandler(this.Ban_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBan)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBan;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.RadioButton rdbCo;
        private System.Windows.Forms.RadioButton rdbTrong;
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
        private System.Windows.Forms.Label label3;
    }
}