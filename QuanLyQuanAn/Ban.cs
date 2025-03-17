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
using System.Windows.Forms;

namespace QuanLyQuanAn
{
    public partial class Ban: Form
    {
        string taikhoan;
        public Ban(string taikhoan)
        {
            InitializeComponent();
            this.taikhoan = taikhoan;
        }
        string connection = ConfigurationManager.ConnectionStrings["QuanLyQuanAn"].ConnectionString;

        DungChung dc = new DungChung();
        private void Ban_Load(object sender, EventArgs e)
        {
            dc.KhoiTaoKetNoi();
            dc.PhanQuyen(taikhoan, menuStrip1);
            dc.DuLieuDataGridView_sql("v_Ban", dgvBan);
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

        private void dgvBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBan.Text = dgvBan.CurrentRow.Cells["STT Bàn"].Value.ToString();txtBan.Enabled = false;
            string trangthai = dgvBan.CurrentRow.Cells["Trạng thái"].Value.ToString();
            if (trangthai == "Có người") rdbCo.Checked = true;
            else if (trangthai == "Trống") rdbTrong.Checked = true;
        }

        private void dgvBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBan_CellContentClick(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBan.Text))
            {
                MessageBox.Show("Bạn hãy điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(!int.TryParse(txtBan.Text,out int maban))
                {
                    MessageBox.Show("Số bàn phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    try
                    {
                        using (SqlConnection cnn = new SqlConnection(connection))
                        {
                            using (SqlCommand cmd = new SqlCommand("sp_CapNhatTrangThaiBan", cnn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@maban", txtBan.Text);
                                cmd.Parameters.AddWithValue("@trangthai", rdbCo.Checked ? "Có người ": "Trống");
                                cnn.Open();
                                int i = cmd.ExecuteNonQuery();

                                if (i > 0) MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dc.DuLieuDataGridView_sql("v_Ban", dgvBan);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi: Không có bàn "+txtBan.Text, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBan.Text = "";txtBan.Enabled = true;
            txtTim.Text = "";
            dc.DuLieuDataGridView_sql("v_Ban", dgvBan);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(txtTim.Text == "")
            {
                MessageBox.Show("Hãy điền trạng thái bàn cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string tim = txtTim.Text;
                
                if(tim == "Có người"||tim == "Trống")
                {
                    using (SqlConnection cnn = new SqlConnection(connection))
                    {
                        cnn.Open();
                        DataTable dt = new DataTable();
                        using (SqlCommand cmd = new SqlCommand("sp_TimBanTheoTrangThai", cnn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;       
                            cmd.Parameters.AddWithValue("@trangthai", txtTim.Text);
                           
                            using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                            {
                                ad.Fill(dt);
                                dgvBan.DataSource = dt;
                            }

                            //HienDSBan();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Chí có 2 trạng thái Có người hoặc Trống , hãy thử lại", "Thông báo");
                }
            }
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
