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
    public partial class Mon : Form
    {
        string taikhoan;
        public Mon(string taikhoan)
        {
            InitializeComponent();
            this.taikhoan = taikhoan;
            //lblTenND.Text += " "+tendn;

        }
        string connection = ConfigurationManager.ConnectionStrings["QuanLyQuanAn"].ConnectionString;
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

        //private void layDanhMuc()
        //{

        //    using (SqlConnection cnn = new SqlConnection(connection))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("Select * from tblDanhMucMon", cnn))
        //        {

        //            using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
        //            {
        //                DataTable dt = new System.Data.DataTable();
        //                ad.Fill(dt);
        //                cboDanhMuc.DataSource = dt;
        //                cboDanhMuc.DisplayMember = "sTendanhmuc";
        //                cboDanhMuc.ValueMember = "iMadanhmuc";
        //            }

        //        }
        //    }
        //}
        DungChung dc = new DungChung();

        private void Mon_Load(object sender, EventArgs e)
        {
            dc.KhoiTaoKetNoi();
            dc.PhanQuyen(taikhoan, menuStrip1);
            dc.DuLieuDataGridView_sql("v_Mon", dgvMon);
            dc.DuLieuComboBox_sql("tblDanhMucMon", cboDanhMuc);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSTT.Text) || string.IsNullOrEmpty(txtTenMon.Text) || string.IsNullOrEmpty(txtDonGia.Text)||string.IsNullOrEmpty(txtDonViTinh.Text))
            {
                MessageBox.Show("Bạn hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(!int.TryParse(txtSTT.Text,out int stt))
            {
                MessageBox.Show("STT phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                            cmd.CommandText = "sp_ThemMon";
                            cmd.Parameters.AddWithValue("@mamon", txtSTT.Text);
                            cmd.Parameters.AddWithValue("@tenmon", txtTenMon.Text);
                            cmd.Parameters.AddWithValue("@madanhmuc", cboDanhMuc.SelectedValue);
                            cmd.Parameters.AddWithValue("@dongia", txtDonGia.Text);
                            cmd.Parameters.AddWithValue("@donvitinh", txtDonViTinh.Text);
                            cnn.Open();
                            int i = cmd.ExecuteNonQuery();

                            if (i > 0) MessageBox.Show("Thêm món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else MessageBox.Show("Thêm món thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dc.DuLieuDataGridView_sql("v_Mon", dgvMon);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: Món này đã có trong danh mục", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        private void dgvMon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSTT.Text = dgvMon.CurrentRow.Cells["STT"].Value.ToString(); txtSTT.Enabled = false;
            txtTenMon.Text = dgvMon.CurrentRow.Cells["Tên món"].Value.ToString();
            string danhmuc = dgvMon.CurrentRow.Cells["Danh mục"].Value.ToString();
            foreach (DataRowView item in cboDanhMuc.Items)
            {
                if (item["sTendanhmuc"].ToString() == danhmuc)
                {
                    cboDanhMuc.SelectedValue = item["iMadanhmuc"];
                    break;
                }
            }
            txtDonGia.Text = dgvMon.CurrentRow.Cells["Đơn giá"].Value.ToString();
            txtDonViTinh.Text = dgvMon.CurrentRow.Cells["Đơn vị tính"].Value.ToString();
        }

        private void dgvMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvMon_CellContentClick(sender, e);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
            {
                MessageBox.Show("Tên món cần tìm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection cnn = new SqlConnection(connection))
                {
                    cnn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("sp_timMonTheoTen", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tenmon", txtTim.Text);
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            ad.Fill(dt);
                            dgvMon.DataSource = dt;
                        }
                    }
                    //lblKetQua.Text = "Tìm thấy món ăn có chứa " + txtTim.Text + ".";
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSTT.Enabled = true;
            txtSTT.Text = "";
            txtTenMon.Text = "";
            txtDonGia.Text = "";
            txtDonViTinh.Text = "";
            txtTim.Text = "";
            lblKetQua.Text = "";
            dc.DuLieuDataGridView_sql("v_Mon", dgvMon);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa món này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


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
                    cmd.CommandText = "sp_XoaMon";
                    cmd.Parameters.AddWithValue("@mamon", txtSTT.Text);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Xóa món thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSTT.Enabled = true;
                        txtSTT.Text = "";
                        txtTenMon.Text = "";
                        txtDonGia.Text = "";
                        txtDonViTinh.Text = "";

                    }
                    else MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dc.DuLieuDataGridView_sql("v_Mon", dgvMon);
                }
            }
        }

        private void txtSTT_Validating(object sender, CancelEventArgs e)
        {
            if (txtSTT.Text == "")
            {
                errSTT.SetError(txtSTT, "Không được để trống STT");
            }
            else
            {
                string stt = txtSTT.Text;
                if (!int.TryParse(stt, out int i))
                {
                    errSTT.SetError(txtSTT, "STT nhập vào phải là số");
                }
                else
                {
                    errSTT.SetError(txtSTT, "");
                }
            }
        }

        private void txtTenMon_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenMon.Text == "") { 
                errTenMon.SetError(txtTenMon, "Tên món không được để trống"); 
            }
            else
            {
                errTenMon.SetError(txtTenMon, "");

            }
        }

        private void txtDonGia_Validating(object sender, CancelEventArgs e)
        {
            if (txtDonGia.Text == "")
            {
                errDonGia.SetError(txtDonGia, "Không được để trống đơn giá");
            }
            else
            {
                string gia = txtDonGia.Text;
                if (!float.TryParse(gia, out float i)||float.Parse(gia) <= 0)
                {
                    errDonGia.SetError(txtDonGia, "Đơn giá nhập vào phải là số dương");
                }
                else
                {
                    errDonGia.SetError(txtDonGia, "");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSTT.Text) || string.IsNullOrEmpty(txtTenMon.Text) || string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Bạn hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!int.TryParse(txtSTT.Text, out int stt))
            {
                MessageBox.Show("STT phải là số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (!float.TryParse(txtDonGia.Text, out float gia) || float.Parse(txtDonGia.Text) <= 0)
                {
                    MessageBox.Show("Đơn giá phải là số dương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        using (SqlConnection cnn = new SqlConnection(connection))
                        {
                            using (SqlCommand cmd = new SqlCommand("sp_SuaMon", cnn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@mamon", txtSTT.Text);
                                cmd.Parameters.AddWithValue("@tenmon", txtTenMon.Text);
                                cmd.Parameters.AddWithValue("@madanhmuc", cboDanhMuc.SelectedValue);
                                cmd.Parameters.AddWithValue("@dongia", txtDonGia.Text);
                                cmd.Parameters.AddWithValue("@donvitinh", txtDonViTinh.Text);
                                cnn.Open();
                                int i = cmd.ExecuteNonQuery();

                                if (i > 0) MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dc.DuLieuDataGridView_sql("v_Mon", dgvMon);
                            }
                        }
                    }catch(SqlException ex)
                    {
                        MessageBox.Show("Lỗi: Món này hiện chưa có trong CSDL", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
        }

        private void txtDonViTinh_Validating(object sender, CancelEventArgs e)
        {
            if(txtDonViTinh.Text == "")
            {
                errDonViTinh.SetError(txtDonViTinh, "Không được để trống đơn vị tính");
            }
            else
            {
                errDonViTinh.SetError(txtDonViTinh, "");
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
