using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Class;
using Rijndael256;
namespace WindowsFormsApp1
{
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadTaiKhoanToGridView();
            string sql;
            sql = "Select * from LOAITAIKHOAN";
            Functions.FillCombo(sql, cbbLoaiTK, "LOAI", "TENLOAI");
            sql = "Select * from NHANVIEN";
            Functions.FillCombo(sql, cbb_nhanvien, "MANV", "MANV");
        }
        private void LoadTaiKhoanToGridView()
        {
            try
            {
                string sql;
                sql = "SELECT TAIKHOAN.MANV, TEN, MATKHAU, TENLOAI FROM TAIKHOAN, LOAITAIKHOAN, NHANVIEN WHERE TAIKHOAN.MANV=NHANVIEN.MANV AND TAIKHOAN.LOAI = LOAITAIKHOAN.LOAI";
                DataTable tb = Functions.GetDataTable(sql);
                dgvTaiKhoan.DataSource = tb;
                dgvTaiKhoan.AllowUserToAddRows = false;
                dgvTaiKhoan.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            String MatKhau = Rijndael.Encrypt(txtMatKhau.Text, "0369033543", KeySize.Aes128);
            String TaiKhoan = cbb_nhanvien.SelectedValue.ToString().Trim();
            try
            {
                String sql = "Insert into TAIKHOAN values('" + TaiKhoan + "','" + MatKhau + "', " + cbbLoaiTK.SelectedValue + ")";
                Functions.RunSQL(sql);
                MessageBox.Show("Thêm thành công");
                LoadTaiKhoanToGridView();
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String TaiKhoan = cbb_nhanvien.SelectedValue.ToString().Trim();
            String MatKhau = txtMatKhau.Text;
            try
            {
                String GiaiMa = Functions.GetFieldValues("Select MatKhau from TAIKHOAN where MANV = '" + TaiKhoan + "'");
                GiaiMa = Rijndael.Decrypt(GiaiMa, "0369033543", KeySize.Aes128);
                if (TaiKhoan == "" || MatKhau == "")
                {
                    MessageBox.Show("Bạn chưa chọn tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (GiaiMa!="")
                {
                    //String sql = "Delete from TAIKHOAN where MANV= '" + TaiKhoan + "'";
                    //Functions.RunSQL(sql);
                    string sql = "DELETE TAIKHOAN WHERE MANV=N'" + TaiKhoan + "'";
                    Functions.RunSqlDel(sql);
                    MessageBox.Show("Xóa thành công");
                    LoadTaiKhoanToGridView();
                }
                else
                {
                    MessageBox.Show("Mật khẩu không đúng");
                }
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
            
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];
            cbb_nhanvien.SelectedValue = row.Cells[0].Value.ToString().Trim();    
            txtMatKhau.Text = row.Cells[2].Value.ToString();

        }
    }
}
