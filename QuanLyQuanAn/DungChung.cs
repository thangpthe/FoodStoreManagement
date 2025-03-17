using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn
{
    class DungChung
    {
        public SqlConnection connection;
        public void KhoiTaoKetNoi()
        {
            connection = new SqlConnection(@"Data Source = DESKTOP-BRN63RS\SQLEXPRESS;Integrated Security = True;Initial Catalog=QuanLyQuanAn");
        }

        public DataTable LayDuLieu_sql(string tenbang)
        {
            try
            {
                connection.Open();
                string sql = "select * from " + tenbang;
                SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);
                    return dt;
                }
                catch
                {
                    MessageBox.Show("Lỗi lấy dữ liệu");
                    return null;
                }
                finally
                {
                    connection.Close();
                    da.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối CSDL");
                return null;
            }
        }

        public DataTable LayDuLieu_cmd(SqlCommand cmd)
        {
            try
            {
                connection.Open();
                cmd.Connection = connection;
                //string cmd = "select * from " + tenbang + "" ;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);
                    return dt;
                }
                catch
                {
                    //MessageBox.Show("Lỗi lấy dữ liệu");
                    return null;
                }
                finally
                {
                    connection.Close();
                    da.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối CSDL");
                return null;
            }
        }
        public void DuLieuComboBox_sql(string tenbang, ComboBox cbo)
        {
            DataTable tbl = LayDuLieu_sql(tenbang);
            cbo.DataSource = tbl;
            cbo.ValueMember = tbl.Columns[0].ColumnName;
            cbo.DisplayMember = tbl.Columns[1].ColumnName;
        }

        public void DuLieuComboBox(SqlCommand cmd, ComboBox cbo)
        {
            DataTable tbl = LayDuLieu_cmd(cmd);
            cbo.DataSource = tbl;
            cbo.ValueMember = tbl.Columns[0].ColumnName;
            cbo.DisplayMember = tbl.Columns[1].ColumnName;
        }


        public void DuLieuDataGridView_sql(string tenbang, DataGridView dgv)
        {
            try
            {
                DataTable tbl = LayDuLieu_sql(tenbang);
                dgv.DataSource = tbl;
                //dgv.AutoResizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                tbl.Dispose();
            }
            catch
            {
                MessageBox.Show("Lỗi hiện dữ liệu", "Thông báo");
                return;
            }
        }

        public void PhanQuyen(string taikhoan,MenuStrip menu)
        {
            if (taikhoan != "admin")
            {
                foreach (ToolStripItem item in menu.Items)
                {
                if (item is ToolStripMenuItem menuItem)
                {
                    if (menuItem.Name == "quanlyMonToolStripMenuItem" || menuItem.Name == "thongKeToolStripMenuItem"|| menuItem.Name == "quanLyTaiKhoanToolStripMenuItem")
                    {
                            menuItem.Visible = false;
                    }
                   
                }
            }
        }
        }
    }
}
