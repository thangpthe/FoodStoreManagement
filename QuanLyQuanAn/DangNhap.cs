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
    public partial class DangNhap: Form
    {
        public DangNhap()
        {
            InitializeComponent();
            //txtMatKhau.PasswordChar = '';
        }
        DungChung dc = new DungChung();
        string connection = ConfigurationManager.ConnectionStrings["QuanLyQuanAn"].ConnectionString;
        private void DangNhap_Load(object sender, EventArgs e)
        {
            dc.KhoiTaoKetNoi();
            //dc.DuLieuComboBox_sql("tblTaiKhoan", cbbTenDN);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(txtTenDN.Text == "" ||txtMatKhau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using(SqlConnection cnn = new SqlConnection(connection))
                {
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_LayTaiKhoan";
                        cmd.Parameters.AddWithValue("@tendn", txtTenDN.Text);
                        cmd.Parameters.AddWithValue("@matkhau", txtMatKhau.Text);
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        ad.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string tendn = dt.Rows[0]["sTendangnhap"].ToString();
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            TrangChu frmTrangChu = new TrangChu(tendn);
                            this.Hide();
                            frmTrangChu.ShowDialog();
                            this.Close();
                        }
                        else if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                
            }
        }

    }
}
