using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn
{
    public partial class HoaDon: Form
    {
        string taikhoan;
        public HoaDon(string taikhoan)
        {
            InitializeComponent();
            this.taikhoan = taikhoan;
        }
        string connection = ConfigurationManager.ConnectionStrings["QuanLyQuanAn"].ConnectionString;
        private void LayHD()
        {
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("Select sMaHD from tblHoaDon", cnn))
                {

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        ad.Fill(dt);
                        cbbMaHD.DataSource = dt;
                        cbbMaHD.DisplayMember = "sMaHD";
                        cbbMaHD.ValueMember = "sMaHD";
                    }

                }
            }
        }

        DungChung dc = new DungChung();

        private void HoaDon_Load(object sender, EventArgs e)
        {
            //LayHD();
            dc.KhoiTaoKetNoi();
            dc.PhanQuyen(taikhoan, menuStrip1);
            dc.DuLieuDataGridView_sql("v_HoaDon", dgvHoaDon);
            //dc.DuLieuComboBox_sql("tblHoaDon", cbbMaHD);
            LayHD();
        }


        private string TaoMaHoaDon()
        {
            string maHDMoi = "HD001";

            using (SqlConnection cnn = new SqlConnection(connection))
            {
                string query = "SELECT TOP 1 sMaHD FROM tblHoaDon ORDER BY sMaHD DESC"; //lấy ra mã HD cuối trong db

                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cnn.Open();
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string maHDHienTai = result.ToString(); //mã hd cuối
                        string soPhan = maHDHienTai.Substring(2); //lấy ra phần số của mã HD 
                        int soMoi = int.Parse(soPhan) + 1; //tăng lên 1
                        maHDMoi = "HD" + soMoi.ToString("D3"); //D3 (3 chữ số nếu là 5 sẽ thành 005)
                    }
                }
            }

            return maHDMoi;
        }
        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string trangthai = dgvHoaDon.CurrentRow.Cells[4].Value.ToString();
            txtSoHD.Text = dgvHoaDon.CurrentRow.Cells["Mã HD"].Value.ToString();
            txtBan.Text = dgvHoaDon.CurrentRow.Cells["Bàn"].Value.ToString();
            txtKhuyenMai.Text = dgvHoaDon.CurrentRow.Cells["Khuyến mãi"].Value.ToString();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvHoaDon_CellContentClick(sender, e);
            string trangthai = dgvHoaDon.CurrentRow.Cells[4].Value.ToString();
            if (trangthai == "Chưa thanh toán") rdbNo.Checked = true;
            else rdoYes.Checked = true;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string sohd = dgvHoaDon.CurrentRow.Cells["Mã HD"].Value.ToString();
            string ban = dgvHoaDon.CurrentRow.Cells["Bàn"].Value.ToString();
            //string tongtien = dgvHoaDon.CurrentRow.Cells["Tổng tiền"].Value.ToString();
            this.Hide();
            ChiTietHoaDon frmChiTietHD = new ChiTietHoaDon(sohd,ban,taikhoan);
            frmChiTietHD.ShowDialog();
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoHD.Text) || string.IsNullOrEmpty(txtBan.Text))
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
                            cmd.CommandText = "sp_ThemHoaDon";
                            cmd.Parameters.AddWithValue("@mahd", txtSoHD.Text);
                            cmd.Parameters.AddWithValue("@maban", txtBan.Text);
                            cmd.Parameters.AddWithValue("@thoigianvao", DateTime.Now);
                            cmd.Parameters.AddWithValue("@trangthaihd", rdoYes.Checked ? "Đã thanh toán" :"Chưa thanh toán");
                            cmd.Parameters.AddWithValue("@khuyenmai", 0);
                            cnn.Open();
                            int i = cmd.ExecuteNonQuery();

                            if (i > 0) MessageBox.Show("Thêm hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else MessageBox.Show("Thêm hóa đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dc.DuLieuDataGridView_sql("v_HoaDon", dgvHoaDon);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: Mã hóa đơn đã có hệ thống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoHD.Text) || string.IsNullOrEmpty(txtBan.Text)||string.IsNullOrEmpty(txtKhuyenMai.Text))
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(!float.TryParse(txtKhuyenMai.Text,out float khuyenmai))
            {
                MessageBox.Show("Khuyến mãi phải là số ");
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
                            cmd.CommandText = "sp_SuaHoaDon";
                            cmd.Parameters.AddWithValue("@mahd", txtSoHD.Text);
                            cmd.Parameters.AddWithValue("@maban", txtBan.Text);
                            cmd.Parameters.AddWithValue("@thoigianra", DateTime.Now);
                            cmd.Parameters.AddWithValue("@trangthaihd", rdoYes.Checked ? "Đã thanh toán" : "Chưa thanh toán");
                            cmd.Parameters.AddWithValue("@khuyenmai", txtKhuyenMai.Text);
                            cnn.Open();
                            int i = cmd.ExecuteNonQuery();

                            if (i > 0) MessageBox.Show("Sửa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else MessageBox.Show("Sửa hóa đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dc.DuLieuDataGridView_sql("v_HoaDon", dgvHoaDon);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: Mã hóa đơn đã có hệ thống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            txtSoHD.Text = TaoMaHoaDon();
            txtBan.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.No)
            {
                return;
            }
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_XoaHoaDon";
                    cmd.Parameters.AddWithValue("@mahd", txtSoHD.Text);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0) MessageBox.Show("Xóa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Xóa hóa đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dc.DuLieuDataGridView_sql("v_HoaDon", dgvHoaDon);
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                cnn.Open();
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand("sp_TimHDTheoMa", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mahd",cbbMaHD.SelectedValue);

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        ad.Fill(dt);
                        dgvHoaDon.DataSource = dt;
                    }

                    //HienDSBan();
                }
            }
        }
    }
}
