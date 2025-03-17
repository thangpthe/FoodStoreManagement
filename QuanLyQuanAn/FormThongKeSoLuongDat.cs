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
    public partial class FormThongKeSoLuongDat : Form
    {
        string taikhoan;
        public FormThongKeSoLuongDat(string taikhoan)
        {
            InitializeComponent();
            this.taikhoan = taikhoan;
        }
        string connection = ConfigurationManager.ConnectionStrings["QuanLyQuanAn"].ConnectionString;
        DungChung dc = new DungChung();
       
        private void FormThongKeSoLuongDat_Load(object sender, EventArgs e)
        {
            dc.KhoiTaoKetNoi();
            dc.PhanQuyen(taikhoan, menuStrip1);
            //dc.DuLieuComboBox_sql("tblMon", cbbMon);
        }

        private void ThongKe()
        {

            using (SqlConnection cnn = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ThongKeSoLuongDat", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@thang", dtpThang.Value.Month);
                    cmd.Parameters.AddWithValue("@nam", dtpNam.Value.Year);

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        ad.Fill(dt);
                        rptThongKeSoLuongDat rpt = new rptThongKeSoLuongDat();
                        rpt.SetDataSource(dt);
                        crystalReportViewer1.ReportSource = rpt;
                        //rpt.SetParameterValue("@thang", dtpThang.Value.Month);
                        //rpt.SetParameterValue("@nam", dtpNam.Value.Year);
                        crystalReportViewer1.Refresh();
                    }
                }

            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKe();
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
