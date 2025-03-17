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
    public partial class ChiTietHoaDon : Form
    {
        string taikhoan;
        public ChiTietHoaDon(string sohd, string ban, string taikhoan)
        {
            InitializeComponent();
            txtMaHD.Text = sohd; txtMaHD.Enabled = false;
            txtBan.Text = ban; txtBan.Enabled = false;
            this.taikhoan = taikhoan;
            //txtTongTien.Text = tongtien;

        }

        string connection = ConfigurationManager.ConnectionStrings["QuanLyQuanAn"].ConnectionString;
        private void LayChiTietHD()
        {
            using (SqlConnection cnn = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_HienChiTietHDTheoMa";
                    cmd.Parameters.AddWithValue("@sohd", txtMaHD.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();


                    dt.Columns.Add("STT", typeof(int));
                    da.Fill(dt);


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["STT"] = i + 1;
                    }

                    dgvChiTietHD.DataSource = dt;
                }
            }
        }


        //private void LayMon()
        //{
        //    using (SqlConnection cnn = new SqlConnection(connection))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("Select * from v_Mon", cnn))
        //        {

        //            using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
        //            {
        //                DataTable dt = new DataTable();
        //                ad.Fill(dt);
        //                dgvMon.DataSource = dt;
        //            }

        //        }
        //    }
        //}

        //private void layMenu()
        //{

        //    using (SqlConnection cnn = new SqlConnection(connection))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("Select * from tblMon", cnn))
        //        {

        //            using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
        //            {
        //                DataTable dt = new System.Data.DataTable();
        //                ad.Fill(dt);
        //                cbbMon.DataSource = dt;
        //                cbbMon.DisplayMember = "sTenmon";
        //                cbbMon.ValueMember = "iMamon";
        //            }

        //        }
        //    }
        //}
        DungChung dc = new DungChung();
        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            dc.KhoiTaoKetNoi();
            LayChiTietHD();           
            dc.DuLieuDataGridView_sql("v_Mon", dgvMon);
            dc.DuLieuComboBox_sql("tblMon", cbbMon);
            dc.PhanQuyen(taikhoan, menuStrip1);
        }

        private void dgvMon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDonGia.Text = dgvMon.CurrentRow.Cells["Đơn giá"].Value.ToString();
            string tenmon = dgvMon.CurrentRow.Cells["Tên món"].Value.ToString();
            foreach (DataRowView item in cbbMon.Items)
            {
                if (item["sTenmon"].ToString() == tenmon)
                {
                    cbbMon.SelectedValue = item["iMamon"];
                    break;
                }
            }

            //nudSoLuong.Value = int.Parse(dgvMon.CurrentRow.Cells["Số lượng"].Value.ToString());

        }

        private void dgvMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvMon_CellContentClick(sender, e);
        }

        private void dgvChiTietHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDonGia.Text = dgvChiTietHD.CurrentRow.Cells["Đơn giá"].Value.ToString();
            string tenmon = dgvChiTietHD.CurrentRow.Cells["Tên món"].Value.ToString();
            foreach (DataRowView item in cbbMon.Items)
            {
                if (item["sTenmon"].ToString() == tenmon)
                {
                    cbbMon.SelectedValue = item["iMamon"];
                    break;
                }
            }
            nudSoLuong.Value = int.Parse(dgvChiTietHD.CurrentRow.Cells["Số lượng"].Value.ToString());

        }

        private void dgvChiTietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvChiTietHD_CellContentClick(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtDonGia.Text == "")
            {
                MessageBox.Show("Hãy điền đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (nudSoLuong.Value == 0)
            {
                MessageBox.Show("Số lượng tối thiểu là 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection cnn = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_ThemChiTietHD";
                        //@mahd varchar(20),@mamon int, @soluong int, @gia float
                        cmd.Parameters.AddWithValue("@mahd", txtMaHD.Text);
                        cmd.Parameters.AddWithValue("@mamon", cbbMon.SelectedValue);
                        cmd.Parameters.AddWithValue("@soluong", nudSoLuong.Value);
                        cmd.Parameters.AddWithValue("@gia", txtDonGia.Text);
                        cnn.Open();
                        int i = cmd.ExecuteNonQuery();

                        if (i > 0) MessageBox.Show("Thêm chi tiết HD thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LayChiTietHD();
                        CapNhatTongTienHoaDon(txtMaHD.Text);
                    }
                }
            }

        }

        void CapNhatTongTienHoaDon(string maHD)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_CapNhatTongTienHoaDon", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mahd", txtMaHD.Text);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa món này khỏi hóa đơn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    cmd.CommandText = "sp_XoaChiTietHD";
                    //@mahd varchar(20),@mamon int, @soluong int, @gia float
                    cmd.Parameters.AddWithValue("@mahd", txtMaHD.Text);
                    cmd.Parameters.AddWithValue("@mamon", cbbMon.SelectedValue);

                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();

                    if (i > 0) MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LayChiTietHD();
                    CapNhatTongTienHoaDon(txtMaHD.Text);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtDonGia.Text == "")
            {
                MessageBox.Show("Hãy điền đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (nudSoLuong.Value == 0)
            {
                MessageBox.Show("Số lượng tối thiểu là 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection cnn = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_SuaChiTietHD";
                        //@mahd varchar(20),@mamon int, @soluong int, @gia float
                        cmd.Parameters.AddWithValue("@mahd", txtMaHD.Text);
                        cmd.Parameters.AddWithValue("@mamon", cbbMon.SelectedValue);
                        cmd.Parameters.AddWithValue("@soluong", nudSoLuong.Value);
                        cmd.Parameters.AddWithValue("@gia", txtDonGia.Text);
                        cnn.Open();
                        int i = cmd.ExecuteNonQuery();

                        if (i > 0) MessageBox.Show("Sửa chi tiết HD thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LayChiTietHD();
                        CapNhatTongTienHoaDon(txtMaHD.Text);
                    }
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


        private void btnInChiTietHd_Click(object sender, EventArgs e)
        {
            FormInChiTietHD frm = new FormInChiTietHD(txtMaHD.Text,taikhoan);
            frm.ShowDialog();
        }
    }
}