using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace QuanLyQuanAn
{
    public partial class TaiKhoan: Form
    {
        string taikhoan;
        public TaiKhoan(string taikhoan)
        {
            InitializeComponent();
            this.taikhoan = taikhoan;
        }

        string connection = ConfigurationManager.ConnectionStrings["QuanLyQuanAn"].ConnectionString;
        //private void HienDSTaiKhoan()
        //{

        //    using (SqlConnection cnn = new SqlConnection(connection))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("Select * from v_TaiKhoan", cnn))
        //        {

        //            using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
        //            {
        //                DataTable dt = new DataTable();
        //                ad.Fill(dt);
        //                dgvTaiKhoan.DataSource = dt;
        //            }

        //        }
        //    }
        //}
        DungChung dc = new DungChung();
        
        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            //HienDSTaiKhoan();
            dc.KhoiTaoKetNoi();
            dc.DuLieuDataGridView_sql("v_TaiKhoan", dgvTaiKhoan);
            dc.PhanQuyen(taikhoan, menuStrip1);
            
        }


        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenDN.Text = dgvTaiKhoan.CurrentRow.Cells["Tên đăng nhập"].Value.ToString();
            txtTenDN.Enabled = false;
            txtMK.Text = dgvTaiKhoan.CurrentRow.Cells["Mật khẩu"].Value.ToString();
        }
        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTaiKhoan_CellContentClick(sender, e);
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            txtTenDN.Text = "";txtTenDN.Enabled = true;
            txtMK.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDN.Text) || string.IsNullOrEmpty(txtMK.Text))
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (SqlConnection cnn = new SqlConnection(connection))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = cnn;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_ThemTaiKhoan";
                            cmd.Parameters.AddWithValue("@tendn", txtTenDN.Text);
                            cmd.Parameters.AddWithValue("@matkhau", txtMK.Text);                          
                            cnn.Open();
                            int i = cmd.ExecuteNonQuery();

                            if (i > 0) MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else MessageBox.Show("Thêm tài khoản thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dc.DuLieuDataGridView_sql("v_TaiKhoan", dgvTaiKhoan);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: Tài khoản đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDN.Text) || string.IsNullOrEmpty(txtMK.Text))
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (SqlConnection cnn = new SqlConnection(connection))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = cnn;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "sp_SuaTaiKhoan";
                            cmd.Parameters.AddWithValue("@tendn", txtTenDN.Text);
                            cmd.Parameters.AddWithValue("@matkhau", txtMK.Text);
                           
                            cnn.Open();
                            int i = cmd.ExecuteNonQuery();

                            if (i > 0) MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dc.DuLieuDataGridView_sql("v_TaiKhoan", dgvTaiKhoan);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: Tài khoản chưa tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_XoaTaiKhoan";
                    cmd.Parameters.AddWithValue("@tendn", txtTenDN.Text);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0) MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Xóathất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dc.DuLieuDataGridView_sql("v_TaiKhoan", dgvTaiKhoan);
                }
            }
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
    }
}
