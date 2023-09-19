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
    public partial class FrmDoiMK : Form
    {
        public FrmDoiMK()
        {
            InitializeComponent();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            String TK = txtMaNV.Text;
            String MKCu = txtMatKhauCu.Text;
            String MKMoi = txtMatKhauMoi.Text;
            String NhapLai = txtNhapLaiMK.Text;
            
            String sql = "Select MANV, MATKHAU from TAIKHOAN where MANV='" + TK + "'";
            String GiaiMa = Functions.GetFieldValues("Select MatKhau from TAIKHOAN where MANV = '" + TK + "'");
            GiaiMa = Rijndael.Decrypt(GiaiMa, "0369033543", KeySize.Aes128);
            if (TK==""||MKCu==""||MKMoi==""||NhapLai=="")
            {
                MessageBox.Show("Không được để trống","Thông báo");
            }
            else if(MKMoi==MKCu)
            {
                MessageBox.Show("Mật khẩu cũ và mật khẩu mới không được trùng","Lỗi");
            }
            else if(MKCu!=GiaiMa)
            {
                MessageBox.Show("Mật khẩu cũ không đúng", "Lỗi");
            }
            else if(Functions.CheckKey(sql))
            {
                try
                {
                    String MatKhau = Rijndael.Encrypt(MKMoi, "0369033543", KeySize.Aes128);
                    sql = "Update TAIKHOAN set MATKHAU='" + MatKhau + "'";
                    Functions.RunSQL(sql);
                    MessageBox.Show("Xong!");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("Sai thông tin, hãy kiểm tra lại");
            }

        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            txtMaNV.Text=Program.MaNVDangNhap;
        }

        private void FrmDoiMK_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = Program.MaNVDangNhap;
        }
    }
}
