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
    public partial class TimSanPham : Form
    {
        public SendMessage send;
        private DataTable tblHH;
        public TimSanPham()
        {
            InitializeComponent();
        }

        private void TimSanPham_Load(object sender, EventArgs e)
        {
            LoadDataToGridView();
        }
        private void LoadDataToGridView()
        {
            try
            {
                string sql;
                sql = "SELECT * from HANGHOA";
                tblHH = Functions.GetDataTable(sql);
                dgvTimHH.DataSource = tblHH;

                dgvTimHH.AllowUserToAddRows = false;
                dgvTimHH.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch
            {
                MessageBox.Show("Hình như có gì đó sai sai. Hãy thử lại!");
                return;
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void SearchDataGridView()
        {
            try
            {
                dgvTimHH.DataSource = null;
                String Ten = txtTimSP.Text;
                if (Ten != "")
                {
                    string sql;
                    sql = "SELECT * FROM HANGHOA Where TENHH LIKE N'%" + Ten + "%'";
                    DataTable dataTable = Functions.GetDataTable(sql);
                    if (dataTable.Rows.Count > 0)
                    {
                        dgvTimHH.DataSource = dataTable;
                    }

                }
                else
                {
                    LoadDataToGridView();
                }
            }
            catch
            {
                return;
            }
            
        }
        private void txtTimSP_TextChanged(object sender, EventArgs e)
        {
            SearchDataGridView();
        }
        
        
            
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }
        public TimSanPham(SendMessage sender)
        {
            InitializeComponent();
            send = sender;
        }
        private void btnThemVaoHD_Click(object sender, EventArgs e)
        {
            this.send(this.txtMaHH.Text);
            this.Close();
        }

        private void txtMaHH_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvTimHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHH.Text= dgvTimHH.CurrentRow.Cells["MAHH"].Value.ToString();
        }
    }
}
