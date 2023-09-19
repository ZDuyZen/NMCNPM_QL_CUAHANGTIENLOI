using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmTimkiemKH : Form
    {
        public frmTimkiemKH()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SearchDataToGridView()
        {
            try
            {
                String SDT = txtMaKH.Text;
                String sql = "SELECT * FROM KHACHHANG WHERE SDT LIKE '%" + SDT + "%'";
                DataTable table = Class.Functions.GetDataTable(sql);

                if (table.Rows.Count > 0)
                {
                    dgvKH.DataSource = table;
                }
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
                   
        }
        private void LoadDataToGridView()
        {
            try
            {
                String SDT = txtMaKH.Text;
                String sql = "SELECT * FROM KHACHHANG";
                DataTable table = Class.Functions.GetDataTable(sql);

                if (table.Rows.Count > 0)
                {
                    dgvKH.DataSource = table;
                }
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
           
        }
        private void frmTimkiemKH_Load(object sender, EventArgs e)
        {
            LoadDataToGridView();
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            SearchDataToGridView();
        }
    }
}
