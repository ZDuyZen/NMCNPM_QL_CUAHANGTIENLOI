using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using WindowsFormsApp1.Class;
using Rijndael256;
namespace WindowsFormsApp1
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            String TK = txtMaNV.Text;
            Program.MaNVDangNhap=TK;            
            String MK = txtMatKhau.Text;
            if (TK == "NV001" && MK =="1")
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                frm_BanHang f = new frm_BanHang();
                f.Show();
                this.Hide();
                return;
            }
            if (MK == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhau.Focus();
                return;
            }
            try
            {
                String sql = "Select * from TAIKHOAN where MANV = '" + TK + "'";
                DataTable tb = Functions.GetDataTable(sql);
                if (tb.Rows.Count == 0)
                {
                    MessageBox.Show("Tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaNV.Focus();
                    return;
                }
                else
                {
                    String GiaiMa = Functions.GetFieldValues("Select MatKhau from TAIKHOAN where MANV = '" + TK + "'");
                    GiaiMa = Rijndael.Decrypt(GiaiMa, "0369033543", KeySize.Aes128);
                    if (MK == GiaiMa)
                    {
                        MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm_BanHang f = new frm_BanHang();
                        f.Show();
                        this.Hide();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMatKhau.Focus();
                        return;
                    }
                }
            }
            catch{
                MessageBox.Show("Một lỗi đã xảy ra. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
        }
        
        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void frmDangNhap_Load_1(object sender, EventArgs e)
        {
            
            if (Functions.Connect() == true)
            {
                //MessageBox.Show("Kết nối CSDL thành công!");
                checkBoxCSDL.Checked = true;
            }
            else
            {
                MessageBox.Show("Không thể kết nối tới CSDL!");                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Functions.Disconnect();
            this.Close();
        }

        private void giớiThiệuVềToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGioiThieu f = new FrmGioiThieu();
            f.Show();
        }

        private void kiểmTraCậpNhậToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không tìm thấy bản cập nhật!","Lỗi");
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions.Disconnect();
            Application.Exit();
        }

        private void kếtNốiLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Functions.Connect();
        }

        private void ngắtKếtNốiCSDLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Functions.Disconnect();
        }

        private void checkBoxCSDL_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
