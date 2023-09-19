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
namespace WindowsFormsApp1
{
    public delegate void SendMessage(String value);
    public partial class frm_BanHang : Form
    {
        public frm_BanHang()
        { 
            InitializeComponent();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Functions.Disconnect();
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn chưa?", "Đăng xuất", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                frmDangNhap f1 = new frmDangNhap();
                f1.Show();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string NV = Program.MaNVDangNhap;
            string sql = "Select LOAI from TAIKHOAN where MANV = '" + NV + "'";
            if (Functions.GetFieldValues(sql) == "0")
            {
                frmNhanvien frmNhanvien = new frmNhanvien();

                frmNhanvien.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào mục này!");
            }
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string NV = Program.MaNVDangNhap;
            string sql = "Select LOAI from TAIKHOAN where MANV = '" + NV + "'";
            if (Functions.GetFieldValues(sql) == "0")
            {
                frmHanghoa frmHanghoa = new frmHanghoa();
                frmHanghoa.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào mục này!");
            }
        }

        private void kháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmKhachhang frmKhachhang = new frmKhachhang();
            frmKhachhang.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTimkiemHD frmTimkiemHD = new frmTimkiemHD();
            frmTimkiemHD.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimkiemKH f = new frmTimkiemKH();
            f.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDoiMK f = new FrmDoiMK();
            f.Show();
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGioiThieu f = new FrmGioiThieu();
            f.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private void frm_BanHang_Load(object sender, EventArgs e)
        {
            label1.Text= "Xin chào! "+Program.MaNVDangNhap;
            //LoadDataToGridView();
            
        }
        
        private void LoadDataToGridView()
        {
            try
            {
                String MaHD = txtMaHd.Text;
                string sql;
                sql = "Select cthd.MAHH, hh.TENHH, cthd.SOLUONG, hh.DVT, GIA = SOLUONG*hh.GIA\r\nFrom CHITIETHOADON cthd, HANGHOA hh\r\nwhere cthd.MAHH=hh.MAHH and MaHD=" + MaHD + "\r\ngroup by cthd.MAHH, hh.TENHH, cthd.SOLUONG, hh.DVT, GIA";
                DataTable tb = Functions.GetDataTable(sql);
                dgvBanHang.DataSource = tb;
                dgvBanHang.AllowUserToAddRows = false;
                dgvBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //if(txtMaKH.Text=="")
            //{
            //    MessageBox.Show("Hãy thêm mã khách hàng");
            //    return;
            //}    
            //try
            //{
            //    DateTime NgayXuatHD = dtpNgayXuatHD.Value;
            //    string format = "yyyy-MM-dd HH:mm:ss";
            //    string sql = "SET IDENTITY_INSERT dbo.HOADON OFF;   Insert into HOADON(NGAYXUATHD, MAKH) values('" + NgayXuatHD.ToString(format) + "', '"+"Không biết"+"');";
            //    Functions.RunSQL(sql);
            //    txtNgayHD.Text = Functions.GetFieldValues("SELECT NGAYXUATHD FROM HOADON WHERE MAHD = (SELECT MAX(MAHD) FROM HOADON)");

            //    txtMaHd.Text = Functions.GetFieldValues("select max(MAHD) from HOADON");
            //    txtMaNV.Text = Program.MaNVDangNhap;
            //    MessageBox.Show("Tạo hóa đơn thành công");

            //}
            //catch
            //{
            //    MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
            //    return;

            //}
            try
            {
                DateTime NgayXuatHD = dtpNgayXuatHD.Value;
                string format = "yyyy-MM-dd HH:mm:ss";
                string sql = "SET IDENTITY_INSERT dbo.HOADON OFF;   Insert into HOADON(NGAYXUATHD) values('" + NgayXuatHD.ToString(format) + "');";
                Functions.RunSQL(sql);
                MessageBox.Show("Thêm thành công");
                txtMaHd.Text = Functions.GetFieldValues("select max(MAHD) from HOADON");
                txtNgayHD.Text = Functions.GetFieldValues("SELECT NGAYXUATHD FROM HOADON WHERE MAHD = (SELECT MAX(MAHD) FROM HOADON)");
                txtMaNV.Text = Program.MaNVDangNhap;
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;

            }

        }

        private void dgvBanHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            String MaSP=txtMaHH.Text;
            String SoLuong = txtSoLuong.Text;
            String MAHD = txtMaHd.Text;
            if (txtMaHd.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn");
                txtMaHd.Focus();
                return;
            }
            if (MaSP.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHH.Focus();
                return;
            }
            if (SoLuong=="")
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return;
            }
            try
            {
                string sql = "select TENHH FROM HANGHOA";
                string tenHang = Functions.GetFieldValues(sql).Trim();
                sql = "select SOLUONG FROM CHITIETHOADON WHERE MAHD = '"+ txtMaHd.Text +"' AND MAHH = '"+txtMaHH.Text+"' ";
                if(Functions.CheckKey(sql) == true)
                {
                    string soluongcu = Functions.GetFieldValues(sql);
                    int soluongmoi = Convert.ToInt32(soluongcu) + Convert.ToInt32(txtSoLuong.Text);
                    sql = "UPDATE CHITIETHOADON SET SOLUONG = "+ soluongmoi +" WHERE MAHD = " + txtMaHd.Text + " AND MAHH = '" + txtMaHH.Text + "' ";
                    Functions.RunSQL(sql);
                    LoadDataToGridView();
                }
                else
                {
                    sql = "INSERT INTO CHITIETHOADON VALUES (" + MAHD + ",'" + MaSP + "'," + SoLuong + ")";
                    Functions.RunSQL(sql);
                    LoadDataToGridView();
                }    
              
                //ResetValues();
                txtTienTamTinh.Text = Functions.GetFieldValues("Select SUM(SOLUONG*hh.GIA)\r\nFrom CHITIETHOADON cthd, HANGHOA hh\r\nwhere cthd.MAHH=hh.MAHH and MAHD=" + MAHD + "");
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String MAHD=txtMaHd.Text;
            string sql;
            if (txtMaHH.Text=="" && txtSoLuong.Text=="")
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                //sql = "DELETE CHITIETHOADON WHERE MAHH=N'" + txtMaHH.Text + "' and SOLUONG=" + txtSoLuong.Text + "";
                sql = "DELETE CHITIETHOADON WHERE MAHD = '" + MAHD + "' and MAHH=N'" + txtMaHH.Text + "' and SOLUONG=" + txtSoLuong.Text + "";
                Functions.RunSqlDel(sql);
                LoadDataToGridView();
                // ResetValues();
                txtTienTamTinh.Text = Functions.GetFieldValues("Select SUM(SOLUONG*hh.GIA)\r\nFrom CHITIETHOADON cthd, HANGHOA hh\r\nwhere cthd.MAHH=hh.MAHH and MAHD=" + MAHD + "");
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
            
        }

        private void dgvBanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow row = dgvBanHang.Rows[e.RowIndex];
            if(dgvBanHang.DataSource==null)
            {
                return;
            }
            else
            {
                try
                {
                    txtMaHH.Text = row.Cells[0].Value.ToString();
                    txtSoLuong.Text = row.Cells[2].Value.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi dữ liệu");
                    return;

                }
            }
            

        }
        Double results = 0;
        String operation = "";
        bool enter_value = false;
        private void btn1_Click(object sender, EventArgs e)
        {

        }

        private void btn0000_Click(object sender, EventArgs e)
        {
            if ((txtTienKhachDua.Text == "0") || (enter_value))
                txtTienKhachDua.Text = "";
            enter_value = false;

            Button num = (Button)sender;
            if (num.Text == ".")
            {
                if (!txtTienKhachDua.Text.Contains("."))
                    txtTienKhachDua.Text = txtTienKhachDua.Text + num.Text;
            }
            else
                txtTienKhachDua.Text = txtTienKhachDua.Text + num.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtTienKhachDua.Text = "0";
            
        }

        private void txtTienThoiLai_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            
            Double tientamtinh = 0;
            Double tienkhachdua = 0;
            if (txtTienKhachDua.Text == "")
            {
                tienkhachdua = 0;
            }
            else
            {
                tientamtinh = Double.Parse(txtTienTamTinh.Text);
                tienkhachdua = Double.Parse(txtTienKhachDua.Text);
                Double tienthoilai = tienkhachdua - tientamtinh;
                txtTienThoiLai.Text = tienthoilai.ToString();
            }
            
            
        }

        private void txtTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void ResetValue()
        {
            txtMaHd.Text = "";
            txtMaNV.Text = "";
            txtNgayHD.Text = "";
            txtMaHH.Text = "";
            txtSoLuong.Text = "";
            txtTienTamTinh.Text = "0";
            txtTienKhachDua.Text = "0";
            txtTienThoiLai.Text = "0";
            
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int tienKhach = Convert.ToInt32(txtTienKhachDua.Text);
            int tienTam = Convert.ToInt32(txtTienTamTinh.Text);
            int tienThoi = Convert.ToInt32(txtTienThoiLai.Text);
            if(tienKhach<tienTam)
            {
                MessageBox.Show("Tiền khách đưa phải lớn hơn bằng tiền tiền thanh toán của sản phẩm");
                return;
            }    

            if (radioButtonTienMat.Checked == true)
            {
                if (txtMaKH.Text == "")
                {
                    
                    try
                    {

                        String MaHD = txtMaHd.Text;
                        String MaNV = txtMaNV.Text;
                        String MaKh = txtMaKH.Text;
                        if (MaKh == "")
                            MaKh = "NULL";
                        String TongTien = txtTienTamTinh.Text;
                        String sql = "Update HOADON SET MAKH='0', MANV='" + MaNV + "', TONGTIEN=" + TongTien + ", TIENKHACHDUA = "+tienKhach+", TIENTHOILAI = "+tienThoi+", TinhTrang='Đã thanh toán'\r\nWhere MAHD=" + MaHD + "";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Thanh toán thành công");
                        ResetValue();
                        dgvBanHang.DataSource = null;
                        frm_hoadonThanhToan f = new frm_hoadonThanhToan(MaHD);
                        f.ShowDialog();
                    }
                    catch
                    {
                        MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                        return;
                    }
                }
                else
                {
                    try
                    {

                        String MaHD = txtMaHd.Text;
                        String MaNV = txtMaNV.Text;
                        String MaKh = txtMaKH.Text;
                        if (MaKh == "")
                            MaKh = "NULL";
                        String TongTien = txtTienTamTinh.Text;
                        String sql = "Update HOADON\r\nSET MAKH='" + MaKh + "', MANV='" + MaNV + "', TIENKHACHDUA = " + tienKhach + ", TIENTHOILAI = " + tienThoi + ", TONGTIEN=" + TongTien + ",TinhTrang='Đã thanh toán'\r\nWhere MAHD=" + MaHD + "";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Thanh toán thành công");
                        ResetValue();
                        dgvBanHang.DataSource = null;
                        frm_hoadonThanhToan f = new frm_hoadonThanhToan(MaHD);
                        f.ShowDialog();
                    }
                    catch
                    {
                        MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                        return;
                    }
                }
                
                
            }
            else
            {
                MessageBox.Show("Chưa chọn hình thức thanh toán");
            }
        }

        private void hàngHóaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TimSanPham f = new TimSanPham();
            f.Show();
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            TimSanPham f2 = new TimSanPham(SetValue);
            f2.ShowDialog();
        }
        public void SetValue(String value)
        {
            this.txtMaHH.Text=value;
        }
        
        private void txtMaHH_TextChanged(object sender, EventArgs e)
        {
        }
            

        private void txtMaHH_TextAlignChanged(object sender, EventArgs e)
        {
       
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string NV = Program.MaNVDangNhap;
            string sql = "Select LOAI from TAIKHOAN where MANV = '" + NV + "'";
            if (Functions.GetFieldValues(sql) == "0")
            {
                frmTaiKhoan f = new frmTaiKhoan();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào mục này!");
            }
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            if (radioButtonTienMat.Checked == true)
            {
                if(txtMaKH.Text=="")
                {
                    try
                    {
                        String MaHD = txtMaHd.Text;
                        String MaNV = txtMaNV.Text;
                        String MaKh = txtMaKH.Text;
                        if (MaKh == "")
                            MaKh = "NULL";
                        String TongTien = txtTienTamTinh.Text;
                        String sql = "Update HOADON SET MANV='" + MaNV + "', TONGTIEN=" + TongTien + ",TinhTrang='Đã hủy'\r\nWhere MAHD=" + MaHD + "";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Đã hủy thành công thành công");
                        ResetValue();
                        dgvBanHang.DataSource = null;
                    }
                    catch
                    {
                        MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                        return;
                    }
                }
                else
                {
                    try
                    {
                        String MaHD = txtMaHd.Text;
                        String MaNV = txtMaNV.Text;
                        String MaKh = txtMaKH.Text;
                        if (MaKh == "")
                            MaKh = "NULL";
                        String TongTien = txtTienTamTinh.Text;
                        String sql = "Update HOADON SET MAKH='" + MaKh + "', MANV='" + MaNV + "', TONGTIEN=" + TongTien + ",TinhTrang='Đã hủy'\r\nWhere MAHD=" + MaHD + "";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Đã hủy thành công thành công");
                        ResetValue();
                        dgvBanHang.DataSource = null;
                    }
                    catch
                    {
                        MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                        return;
                    }
                }
                
                
            }
            else
            {
                MessageBox.Show("Chưa chọn hình thức thanh toán");
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            String MaSP = txtMaHH.Text;
            String SoLuong = txtSoLuong.Text;
            String MAHD = txtMaHd.Text;
            if (txtMaHd.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn");
                txtMaHd.Focus();
                return;
            }
            if (MaSP.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHH.Focus();
                return;
            }
            if (SoLuong == "")
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return;
            }
            try
            {
                string sql = "select TENHH FROM HANGHOA";
                string tenHang = Functions.GetFieldValues(sql).Trim();
                sql = "select SOLUONG FROM CHITIETHOADON WHERE MAHD = '" + txtMaHd.Text + "' AND MAHH = '" + txtMaHH.Text + "' ";
                if (Functions.CheckKey(sql) == true)
                {
                    int soluongmoi =  Convert.ToInt32(txtSoLuong.Text);
                    sql = "UPDATE CHITIETHOADON SET SOLUONG = " + soluongmoi + " WHERE MAHD = " + txtMaHd.Text + " AND MAHH = '" + txtMaHH.Text + "' ";
                    Functions.RunSQL(sql);
                    LoadDataToGridView();
                    MessageBox.Show("Sửa số lượng sản phẩm " + tenHang + " thành " + txtSoLuong.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Chưa có sản phẩm "+ tenHang + " trong hóa đơn");
                    return;
                }

                //ResetValues();
                txtTienTamTinh.Text = Functions.GetFieldValues("Select SUM(SOLUONG*hh.GIA)\r\nFrom CHITIETHOADON cthd, HANGHOA hh\r\nwhere cthd.MAHH=hh.MAHH and MAHD=" + MAHD + "");
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
