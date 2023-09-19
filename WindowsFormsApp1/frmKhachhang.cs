using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1
{
    public partial class frmKhachhang : Form
    {
        private DataTable tblKH;

        public frmKhachhang()
        {
            InitializeComponent();
        }

        private void frmKhachhang_Load(object sender, EventArgs e)
        {
            //txtMaKH.Enabled = false;
            //btnHuy.Enabled = false;
            //btnLuu.Enabled = false;
            LoadDataGridView();
            string sql;
            sql = "Select * from LOAIKH";
            Functions.FillCombo(sql, cbbLoaiKH, "LOAIKH", "LOAIKH");
        }

        private void LoadDataGridView()
        {
            try
            {
                string sql;
                sql = "SELECT * from KHACHHANG";
                tblKH = Functions.GetDataTable(sql); //Lấy dữ liệu từ bảng
                dgvKhachHang.DataSource = tblKH; //Hiển thị vào dataGridView
                dgvKhachHang.AllowUserToAddRows = false;
                dgvKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
            
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKH.Text = dgvKhachHang.CurrentRow.Cells["MAKH"].Value.ToString();
            txtTenKH.Text = dgvKhachHang.CurrentRow.Cells["TENKH"].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells["DIACHI"].Value.ToString();
            txtSDT.Text = dgvKhachHang.CurrentRow.Cells["SDT"].Value.ToString();
            cbbLoaiKH.Text = dgvKhachHang.CurrentRow.Cells["LOAIKH"].Value.ToString();
            txtMaKH.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            String MaKH = txtMaKH.Text.Trim();
            String TenKH = txtTenKH.Text.Trim();
            String DiaChi = txtDiaChi.Text.Trim();
            String SDT = txtSDT.Text.Trim();
            String LoaiKH = cbbLoaiKH.SelectedValue.ToString();
            string sql;
            //if (txtMaKH.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtMaKH.Focus();
            //    return;
            //}
            if (txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (txtSDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return;
            }
            //Kiểm tra đã tồn tại mã khách chưa
            sql = "SELECT MAKH FROM KHACHHANG WHERE MAKH=N'" + SDT + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }
            //Chèn thêm
            try
            {
                sql = "INSERT INTO KHACHHANG VALUES (N'" + SDT +
                "',N'" + TenKH + "',N'" + DiaChi + "','" + SDT + "',N'" + LoaiKH + "')";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
            
        }

        private void ResetValues()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            
            txtMaKH.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }
            if (txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (txtSDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return;
            }
            try
            {
                sql = "UPDATE KHACHHANG SET TENKH=N'" + txtTenKH.Text.ToString() +
                "',DIACHI=N'" + txtDiaChi.Text.ToString() + "',SDT='" + txtSDT.Text.ToString() +
                "',LOAIKH=N'" + cbbLoaiKH.SelectedValue.ToString() + "' WHERE MAKH=N'" + txtMaKH.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
            
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKH.Text == "0         ")
            {
                MessageBox.Show("Không thể xóa bản ghi này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            else if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //sql = "Select MaKH from KhachHang where MaKH=N'" + txtMaKH.Text + "'";
                
                if (txtMaKH.Text=="0")
                {
                    MessageBox.Show("Không thể xóa khách hàng này");
                }
                else
                {
                    try
                    {
                        sql = "DELETE KHACHHANG WHERE MAKH=N'" + txtMaKH.Text + "'";
                        Functions.RunSqlDel(sql);
                        LoadDataGridView();
                        ResetValues();
                    }
                    catch
                    {
                        MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                        return;
                    }
                }
                
                
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
