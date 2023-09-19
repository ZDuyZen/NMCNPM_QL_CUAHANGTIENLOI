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
    public partial class frmHanghoa : Form
    {
        private DataTable tblHH;

        public frmHanghoa()
        {
            InitializeComponent();
        }

        private void frmHanghoa_Load(object sender, EventArgs e)
        {
            dtpNSX.Format = DateTimePickerFormat.Custom;
            dtpNSX.CustomFormat = "dd-MM-yyyy";
            dtpHSD.Format = DateTimePickerFormat.Custom;
            dtpHSD.CustomFormat = "dd-MM-yyyy";
            string sql;
            sql = "Select MALOAISP, TENLOAISP From LOAISANPHAM";
            Functions.FillCombo(sql, cbMaLoaiHH, "MALOAISP", "TENLOAISP");
            LoadDataGridView();
            ResetValues();
        }

        private void ResetValues()
        {
            txtMaHH.Text = "";
            txtTenHH.Text = "";
            txtNCC.Text = "";
            txtGia.Text="";
            
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from HANGHOA";
            tblHH = Functions.GetDataTable(sql);
            dgvHangHoa.DataSource = tblHH;
            
            dgvHangHoa.AllowUserToAddRows = false;
            dgvHangHoa.EditMode = DataGridViewEditMode.EditProgrammatically;
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvHangHoa_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            String MaHH = txtMaHH.Text;
            String TenHH = txtTenHH.Text.Trim();
            String MaLoaiSP = cbMaLoaiHH.SelectedValue.ToString();
            DateTime NSX = dtpNSX.Value;
            DateTime HSD = dtpHSD.Value;
            String DVT = txtDVT.Text;
            string format = "yyyy-MM-dd HH:mm:ss";

            string sql;
            if (MaHH.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHH.Focus();
                return;
            }
            if (TenHH.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHH.Focus();
                return;
            }
            sql = "SELECT MAHH FROM HANGHOA WHERE MAHH=N'" + txtMaHH.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHH.Focus();
                return;
            }

            string[] hsdUocTinh = dtpHSD.Text.Split('-');
            string[] nsx = dtpNSX.Text.Split('-');
            int namHSD = 0;

            if (hsdUocTinh[2] != nsx[2])
            {
                namHSD = Convert.ToInt32(hsdUocTinh[2]) - Convert.ToInt32(nsx[2]);
            }

            if (namHSD < 0)
            {
                MessageBox.Show("Hạn sử dụng phải lớn hơn ngày sản xuất");
                return;
            }
            int thangNSX = Convert.ToInt32(nsx[1]);

            int thangHSD = Convert.ToInt32(hsdUocTinh[1]);
            int ngayHSD = Convert.ToInt32(hsdUocTinh[0]);
            int ngayNSX = Convert.ToInt32(nsx[0]);
            if (namHSD == 0)
            {
                if (thangNSX == thangHSD && ngayHSD <= ngayNSX)
                {
                    MessageBox.Show("Hạn sử dụng phải lớn hơn ngày sản xuất");
                    return;
                }
                else if (thangNSX > thangHSD)
                {
                    MessageBox.Show("Hạn sử dụng phải lớn hơn ngày sản xuất");
                    return;
                }
                thangHSD = thangHSD - thangNSX;
            }
            else if (namHSD != 0)
            {

                if (ngayHSD < ngayNSX)
                {
                    if (ngayNSX == 31 && ngayHSD == 30)
                    {
                        if (thangHSD == 4 || thangHSD == 6 || thangHSD == 9 || thangHSD == 11)
                        {
                        }
                        else
                        {
                            thangHSD -= 1;
                        }
                    }
                    else
                        thangHSD -= 1;
                }
                thangHSD = (thangHSD + (12 * namHSD)) - thangNSX;


            }

            string chuoiHSD = thangHSD.ToString().Trim() + " Tháng";
            if (thangHSD % 12 == 0 && thangHSD != 0)
            {
                int chuoi = thangHSD / 12;
                chuoiHSD = chuoi.ToString().Trim() + " Năm";
            }


            try
            {
                String NhaCungCap = txtNCC.Text;
                Double GiaMua = Convert.ToDouble(txtGia.Text);
                sql = "INSERT INTO HANGHOA(MAHH, TENHH, MALOAISP, NGAYSX, HSD, NCC, GIA, DVT) VALUES(N'" + MaHH + "',N'" + TenHH + "','" + MaLoaiSP + "','" + NSX.ToString(format) + "', N'" + chuoiHSD + "', N'" + NhaCungCap + "'," + GiaMua + ",N'"+DVT+"')";

                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại");
                return;
            }
        }

        

        //private void btnHuy_Click(object sender, EventArgs e)
        //{
        //    ResetValues();
        //    btnXoa.Enabled = true;
        //    btnSua.Enabled = true;
        //    btnThem.Enabled = true;
        //    btnHuy.Enabled = false;
            
            
        //}

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblHH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "DELETE HANGHOA WHERE MAHH=N'" + txtMaHH.Text + "'";
                    Functions.RunSqlDel(sql);
                    LoadDataGridView();
                    ResetValues();
                    MessageBox.Show("Xóa thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại");
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            string sql;
            if (tblHH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenHH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHH.Focus();
                return;
            }


            string[] hsdUocTinh = dtpHSD.Text.Split('-');
            string[] nsx = dtpNSX.Text.Split('-');
            int namHSD = 0;

            if (hsdUocTinh[2] != nsx[2])
            {
                namHSD = Convert.ToInt32(hsdUocTinh[2]) - Convert.ToInt32(nsx[2]);
            }

            if (namHSD < 0)
            {
                MessageBox.Show("Hạn sử dụng phải lớn hơn ngày sản xuất");
                return;
            }
            int thangNSX = Convert.ToInt32(nsx[1]);

            int thangHSD = Convert.ToInt32(hsdUocTinh[1]);
            int ngayHSD = Convert.ToInt32(hsdUocTinh[0]);
            int ngayNSX = Convert.ToInt32(nsx[0]);
            if (namHSD == 0)
            {
                if (thangNSX == thangHSD && ngayHSD <= ngayNSX)
                {
                    MessageBox.Show("Hạn sử dụng phải lớn hơn ngày sản xuất");
                    return;
                }
                else if (thangNSX > thangHSD)
                {
                    MessageBox.Show("Hạn sử dụng phải lớn hơn ngày sản xuất");
                    return;
                }
                thangHSD = thangHSD - thangNSX;
            }
            else if (namHSD != 0)
            {

                if (ngayHSD < ngayNSX)
                {
                    if (ngayNSX == 31 && ngayHSD == 30)
                    {
                        if (thangHSD == 4 || thangHSD == 6 || thangHSD == 9 || thangHSD == 11)
                        {
                        }
                        else
                        {
                            thangHSD -= 1;
                        }
                    }
                    else
                        thangHSD -= 1;
                }
                thangHSD = (thangHSD + (12 * namHSD)) - thangNSX;


            }

            string chuoiHSD = thangHSD.ToString().Trim() + " Tháng";
            if (thangHSD % 12 == 0 && thangHSD != 0)
            {
                int chuoi = thangHSD / 12;
                chuoiHSD = chuoi.ToString().Trim() + " Năm";
            }



            try
            {
                sql = "UPDATE HANGHOA SET TENHH=N'" + txtTenHH.Text.ToString() + "',MALOAISP=N'" + cbMaLoaiHH.SelectedValue.ToString() + "',NGAYSX='" + dtpNSX.Value.ToString(format) + "',HSD = N'" + chuoiHSD + "',NCC=N'" + txtNCC.Text.ToString() + "',GIA='" + txtGia.Text.ToString() + "',DVT=N'"+txtDVT.Text.ToString()+"' WHERE MAHH=N'" + txtMaHH.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
                MessageBox.Show("Sửa thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thất bại");
                return;
            }
        }

        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow row = dgvHangHoa.Rows[e.RowIndex];

            try
            {

                txtMaHH.Text = row.Cells[0].Value.ToString();
                txtTenHH.Text = row.Cells[1].Value.ToString();
                cbMaLoaiHH.SelectedValue = row.Cells[2].Value.ToString();
                dtpNSX.Text = Convert.ToDateTime(row.Cells[3].Value).ToString("dd-MM-yyyy");
                string[] tam = dtpNSX.Text.Split('-');
                int ngayNSX = Convert.ToInt32(tam[0]);
                int namNSX = Convert.ToInt32(tam[2]);
                int monthNSX = Convert.ToInt32(tam[1]);
                string[] tam2 = row.Cells[4].Value.ToString().Split(' ');
                int montHSD = Convert.ToInt32(tam2[0]);
                int thangHT = monthNSX + montHSD;
                int namHT = namNSX;
                {
                    int nam = (thangHT) / 12;
                    namHT = namNSX + nam;
                    if (thangHT > 12)
                        thangHT = thangHT - 12;
                    if (ngayNSX == 29 && thangHT == 2)
                    {
                        ngayNSX = 28;
                    }
                }
                string chuoiTG = ngayNSX.ToString().Trim() + "-" + thangHT.ToString().Trim() + "-" + Convert.ToString(namHT);
                DateTime dt = DateTime.Parse(chuoiTG);


                dtpHSD.Text = dt.ToString("dd-MM-yyy");
                txtNCC.Text = row.Cells[5].Value.ToString();
                txtGia.Text = row.Cells[6].Value.ToString();
                txtDVT.Text = row.Cells[7].Value.ToString();
                //btnSua.Enabled = true;
                //btnXoa.Enabled = true;           
                //btnThem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu trên dòng đang dgv bị lỗi");
                return;
            }
            
        }
        private void SearchDataGridView()
        {
            dgvHangHoa.DataSource = null;
            String Ten = txtTimSP.Text;
            if(Ten!="")
            {
                string sql;
                sql = "SELECT * FROM HANGHOA WHERE TENHH LIKE N'%" + Ten + "%'";
                DataTable dataTable = Functions.GetDataTable(sql);
                if (dataTable.Rows.Count > 0)
                {
                    dgvHangHoa.DataSource = dataTable;
                }

            }
            else
            {
                LoadDataGridView();
            }
        }
        private void txtTimSP_TextChanged(object sender, EventArgs e)
        {
            SearchDataGridView();
        }

        private void txtMaHH_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
