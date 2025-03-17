using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn
{
    public partial class TrangChu: Form
    {
        string taikhoan;
        public TrangChu(string tendn)
        {
            InitializeComponent();
            this.taikhoan = tendn;
            //dangNhapToolStripMenuItem.Text = tendn;
        }

        DungChung dc = new DungChung();
        private void quanlyMonToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.Hide();
           Mon frmMon = new Mon(taikhoan);
           frmMon.ShowDialog();
           this.Close();
        }

        private void quanlyBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ban frmBan = new Ban(taikhoan);
            frmBan.ShowDialog();
            this.Close();
        }

        private void quanlyHDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HoaDon frmHD = new HoaDon(taikhoan);
            frmHD.ShowDialog();
            this.Close();
        }

       

        private void thongKeHoaDonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongKeDoanhThu thongKeHD = new ThongKeDoanhThu(taikhoan);
            thongKeHD.ShowDialog();
            this.Close();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            dc.KhoiTaoKetNoi();
            dc.PhanQuyen(taikhoan, menuStrip1);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            this.Hide();
            DangNhap frmDangNhap = new DangNhap();
            frmDangNhap.ShowDialog();
            this.Close();
        }

        //private void quanLyTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    TaiKhoan frmTK = new TaiKhoan();
        //    frmTK.ShowDialog();
        //    this.Close();
        //}

        private void thongKeDatMonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormThongKeSoLuongDat frm = new FormThongKeSoLuongDat(taikhoan);
            frm.ShowDialog();
            this.Close();
        }

        private void quanLyTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            TaiKhoan frmTK = new TaiKhoan(taikhoan);
            frmTK.ShowDialog();
            this.Close();
        }
    }
}
