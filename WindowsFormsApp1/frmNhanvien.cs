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
    public partial class frmNhanvien : Form
    {
        private DataTable tblNV;
        public frmNhanvien()
        {
            InitializeComponent();
        }

        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd-MM-yyyy";
            dtpNgayVaoLam.Format = DateTimePickerFormat.Custom;
            dtpNgayVaoLam.CustomFormat = "dd-MM-yyyy";
            LoadDataGridView();
            string sql;
            sql = "Select MACHUCVU, TENCHUCVU From CHUCVU";
            Functions.FillCombo(sql, cbbChucVu, "MACHUCVU", "TENCHUCVU");
            sql = "Select MALOAINV, TENLOAINV From LOAINV";
            Functions.FillCombo(sql, cbbLoaiNV, "MALOAINV", "TENLOAINV");
        }
        public void LoadDataGridView()
        {
            try
            {
                dgvNhanVien.DataSource = null;
                string sql;
                sql = "Select MANV, TEN, CCCD, GIOITINH, STK, TENNGANHANG, NGAYSINH, NGAYVAOLAM, HINHANH, TENCHUCVU, TENLOAINV From CHUCVU, LOAINV, NHANVIEN where CHUCVU.MACHUCVU = NHANVIEN.MACHUCVU and NHANVIEN.MALOAINV = LOAINV.MALOAINV\r\n";

                tblNV = Functions.GetDataTable(sql);
                // lấy dữ liệu
                dgvNhanVien.DataSource = tblNV;
                dgvNhanVien.AllowUserToAddRows = false;
                dgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            
            String GioiTinh;
            if (txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return;
            }
            
            
            if (radioButton1.Checked == true)
            {
                GioiTinh = "Nam";
            }
            else
            {
                GioiTinh = "Nữ";
            }
            string sql = "SELECT MANV FROM NHANVIEN WHERE MANV = N'" + txtMaNV.Text + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên đã có. Nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
                txtMaNV.Text = "";
                return;
            }
            
            String MaNV = txtMaNV.Text;
            String TenNV = txtTenNV.Text;
            String CCCD = txtCCCD.Text;
            String HinhAnh = txtHinhAnh.Text;
            String ChucVu = cbbChucVu.SelectedValue.ToString().Trim();
            String LoaiNV = cbbLoaiNV.SelectedValue.ToString().Trim();
            String SoTK = txtSTK.Text;
            String TenNH = txtTenNH.Text;
            DateTime NgaySinh = dtpNgaySinh.Value;
            DateTime NgayVaoLam = dtpNgayVaoLam.Value;

            if(NgaySinh>=NgayVaoLam)
            {
                MessageBox.Show("Ngày sinh phải lớn hơn ngày vào làm");
                return;
            }    


            try
            {
                string format = "yyyy-MM-dd HH:mm:ss";
                sql = "INSERT INTO NHANVIEN(MANV, TEN, CCCD, GIOITINH, STK, TENNGANHANG, NGAYSINH, NGAYVAOLAM, HINHANH, MACHUCVU, MALOAINV) VALUES (N'" + MaNV + "', N'" + TenNV + "',N'" + CCCD + "',N'" + GioiTinh + "',N'" + SoTK + "',N'" + TenNH + "','" + NgaySinh.ToString(format) + "' ,'" + NgayVaoLam.ToString(format) + "','" + HinhAnh + "', '" + ChucVu + "', '" + LoaiNV + "')";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
            
            
            //btnSua.Enabled = false;
            //btnXoa.Enabled = false;
            //btnHuy.Enabled = true;
            //btnThem.Enabled = false;
            //btnLuu.Enabled = true;
            //ResetValues();
            //txtMaNV.Enabled = true;
            //txtMaNV.Focus();

        }

        private void ResetValues()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            radioButton1.Checked = true;
            txtSTK.Text = "";
            txtSDT.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Hãy nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    sql = "DELETE NHANVIEN WHERE MANV=N'" + txtMaNV.Text + "'";
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            String GioiTinh;
            if (txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            


            if (radioButton1.Checked == true)
            {
                GioiTinh = "Nam";
            }
            else
            {
                GioiTinh = "Nữ";
            }
            string sql = "SELECT MANV FROM NHANVIEN WHERE MANV = N'" + txtMaNV.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                MessageBox.Show("Không tim thấy mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
                txtMaNV.Text = "";
                return;
            }

            String MaNV = txtMaNV.Text;
            String TenNV = txtTenNV.Text;
            String CCCD = txtCCCD.Text;
            String HinhAnh = txtHinhAnh.Text;
            String ChucVu = cbbChucVu.SelectedValue.ToString().Trim();
            String LoaiNV = cbbLoaiNV.SelectedValue.ToString().Trim();
            String SoTK = txtSTK.Text;
            String TenNH = txtTenNH.Text;
            DateTime NgaySinh = dtpNgaySinh.Value;
            DateTime NgayVaoLam = dtpNgayVaoLam.Value;

            if (NgaySinh >= NgayVaoLam)
            {
                MessageBox.Show("Ngày sinh phải lớn hơn ngày vào làm");
                return;
            }

            string format = "yyyy-MM-dd HH:mm:ss";
            try
            {
                sql = "INSERT INTO NHANVIEN(MANV, TEN, CCCD, GIOITINH, STK, TENNGANHANG, NGAYSINH, NGAYVAOLAM, HINHANH, MACHUCVU, MALOAINV) VALUES (N'" + MaNV + "', N'" + TenNV + "',N'" + CCCD + "',N'" + GioiTinh + "',N'" + SoTK + "',N'" + TenNH + "','" + NgaySinh.ToString(format) + "' ,'" + NgayVaoLam.ToString(format) + "','" + HinhAnh + "','" + ChucVu + "',N'" + LoaiNV + "')";
                sql = "Update NHANVIEN set Ten= N'" + TenNV + "', CCCD=N'" + CCCD + "',GIOITINH= N'" + GioiTinh + "',STK='" + SoTK + "',TENNGANHANG=N'" + TenNH + "',NGAYSINH='" + NgaySinh.ToString(format) + "',NGAYVAOLAM='" + NgayVaoLam.ToString(format) + "',HINHANH='" + HinhAnh + "',MACHUCVU='" + ChucVu + "',MALOAINV=N'" + LoaiNV + "' where MANV='" + MaNV + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Sửa thất bại. Hãy thử lại!");
            }
            

            //btnSua.Enabled = false;
            //btnXoa.Enabled = false;
            //btnHuy.Enabled = true;
            //btnThem.Enabled = false;
            //btnLuu.Enabled = true;
            //ResetValues();
            //txtMaNV.Enabled = true;
            //txtMaNV.Focus();

        }
        public void SearchDataGridView()
        {
            
            dgvNhanVien.DataSource = null;
            String Ten = txtTimKiem.Text;
            if (Ten != "")
            {
                string sql;
                try
                {
                    sql = "SELECT * FROM NHANVIEN WHERE TEN LIKE N'%" + Ten + "%'";

                    tblNV = Functions.GetDataTable(sql);
                    // lấy dữ liệu
                    dgvNhanVien.DataSource = tblNV;

                    dgvNhanVien.AllowUserToAddRows = false; // ngăn chặn người dùng thêm cột mới
                    dgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;

                }
                catch
                {
                    MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                    return;
                }
                
            }
            else
            {
                LoadDataGridView();
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchDataGridView();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SearchDataGridView();

        }

        

        private void dgvNhanVien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

            try
            {
                txtMaNV.Text = row.Cells[0].Value.ToString().Trim();
                txtTenNV.Text = row.Cells[1].Value.ToString().Trim();
                txtCCCD.Text = row.Cells[2].Value.ToString().Trim();
                if (row.Cells[3].Value.ToString() == "Nam")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                txtSTK.Text = row.Cells[4].Value.ToString().Trim();
                txtTenNH.Text = row.Cells[5].Value.ToString().Trim();
                dtpNgaySinh.Text = row.Cells[6].Value.ToString().Trim();
                dtpNgayVaoLam.Text = row.Cells[7].Value.ToString();
                txtHinhAnh.Text = row.Cells[8].Value.ToString();
                string chucvu1 = row.Cells[9].Value.ToString();
                cbbChucVu.SelectedIndex = cbbChucVu.FindStringExact(chucvu1);
                string loaiNV1 = row.Cells[10].Value.ToString();
                cbbLoaiNV.SelectedIndex= cbbLoaiNV.FindStringExact(loaiNV1);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu này bị lỗi. Không thể hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
