using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using WindowsFormsApp1.Class;
using DataTable = System.Data.DataTable;

namespace WindowsFormsApp1
{
    public partial class frmTimkiemHD : Form
    {
        public frmTimkiemHD()
        {
            InitializeComponent();
        }
        private void SearchDataToGridView()
        {
            dgvHD.DataSource = null;
            String Ten = txtMaHD.Text;
            if (Ten != "")
            {
                try
                {
                    string sql;
                    sql = "SELECT * FROM HOADON WHERE MAHD LIKE N'%" + Ten + "%'";

                    DataTable table = Functions.GetDataTable(sql);
                    // lấy dữ liệu
                    dgvHD.DataSource = table;

                    dgvHD.AllowUserToAddRows = false; // ngăn chặn người dùng thêm cột mới
                    dgvHD.EditMode = DataGridViewEditMode.EditProgrammatically;

                }
                catch
                {
                    MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                    return;
                }
               
            }
            else
            {
                LoadDataToGridView();
            }
        }
        private void LoadDataToGridView()
        {
            try
            {
                String SDT = txtMaHD.Text;
                String sql = "SELECT * FROM HOADON";
                DataTable table = Class.Functions.GetDataTable(sql);

                if (table.Rows.Count > 0)
                {
                    dgvHD.DataSource = table;
                }
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
            
        }
        private void frmTimkiemHD_Load(object sender, EventArgs e)
        {
           // LoadDataToGridView();
        }

        private void frmTimkiemHD_Load_1(object sender, EventArgs e)
        {
           LoadDataToGridView();
            btnHuyLoc.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                String MaHD = txtMaHD.Text;
                String sql = "SELECT * FROM HOADON WHERE MAHD = '" + MaHD + "'";
                DataTable table = Class.Functions.GetDataTable(sql);

                if (table.Rows.Count > 0)
                {
                    dgvHD.DataSource = table;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn này");

                }
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String id = dgvHD.CurrentRow.Cells["MAHD"].Value.ToString();
                string sql1 = "Select hh.TENHH, SOLUONG, GIA from HANGHOA hh, CHITIETHOADON cthd where MAHD="+id+" and hh.MAHH=cthd.MAHH";
                DataTable table1 = Class.Functions.GetDataTable(sql1);
                dgvCTHD.DataSource = table1;
                string sql2 = "Select kh.TenKH from KHACHHANG kh, HOADON hd where kh.MAKH = hd.MAKH and hd.MAHD=" + id + "";

                txtTenKH.Text = Functions.GetFieldValues(sql2);
                txtMaHD2.Text = id;
                txtTongTien.Text = Functions.GetFieldValues("Select TONGTIEN from HOADON where MAHD=" + id + "");
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu");
                return;
            }
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            SearchDataToGridView();
        }


        private void btnexport_Click(object sender, EventArgs e)
        {
            //Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //app.Application.Workbooks.Add(Type.Missing);
            //app.Cells[1, 1] = "Mã hóa đơn";
            //String id = dgvHD.CurrentRow.Cells["MAHD"].Value.ToString();

            //app.Cells[2,1]=id;
            //app.Cells[3,1]="Tên khách hàng";
            
            //app.Cells[4, 1] = txtTenKH.Text;
            //for (int i = 1; i < dgvCTHD.Columns.Count + 1; i++)
            //{
            //    app.Cells[2, i] = dgvCTHD.Columns[i - 1].HeaderText;
            //}
            //for (int i = 0; i < dgvHD.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dgvCTHD.Columns.Count; j++)
            //    {
            //        if (dgvCTHD.Rows[i].Cells[j].Value != null)
            //        {
            //            app.Cells[i + 3, j + 1] = dgvCTHD.Rows[i].Cells[j].Value.ToString();
            //        }
            //    }
            //}
            //app.Columns.AutoFit();
            //app.Visible = true;

            string maHD = txtMaHD2.Text.Trim();
            if(maHD=="")
            {
                MessageBox.Show("Hãy chọn mã hóa đơn");
                return;
            }
            try
            {
                frm_hoadonThanhToan f = new frm_hoadonThanhToan(maHD);
                f.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi xuất hóa đơn");
                return;
            }

        }
        private void FilterDataGridView()
        {
            try
            {
                String SDT = txtMaHD.Text;
                DateTime TuNgay = dateTimePickerTuNgay.Value;
                DateTime DenNgay = dateTimePickerDenNgay.Value;
                string format = "yyyy-MM-dd";
                String sql = "Select * from HOADON where NGAYXUATHD <='" + DenNgay.ToString(format) + "' and NGAYXUATHD >='" + TuNgay.ToString(format) + "'";
                DataTable table = Class.Functions.GetDataTable(sql);
                dgvHD.DataSource = table;
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
            
            
        }
        private void btnLoc_Click(object sender, EventArgs e)
        {
            
            FilterDataGridView();
            btnHuyLoc.Show();
        }

        private void dateTimePickerTuNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnHuyLoc_Click(object sender, EventArgs e)
        {
            LoadDataToGridView();
            btnHuyLoc.Hide();
        }

        private void dgvCTHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
