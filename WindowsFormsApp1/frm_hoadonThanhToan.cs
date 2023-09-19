using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;

namespace WindowsFormsApp1
{
    public partial class frm_hoadonThanhToan : Form
    {
        private string maHD;
        public frm_hoadonThanhToan()
        {
            InitializeComponent();
        }
      
        public frm_hoadonThanhToan(string maHD)
        {
            InitializeComponent();
            this.maHD = maHD;
        }

        private void frm_hoadonThanhToan_Load(object sender, EventArgs e)
        {
            rpt_hoadonThanhtoan rpt = new rpt_hoadonThanhtoan();
            try
            {
                if (maHD != "")
                {


                    ParameterValues maHoaDon = new ParameterValues();
                    ParameterDiscreteValue dismaHD = new ParameterDiscreteValue();
                    dismaHD.Value = maHD;
                    maHoaDon.Add(dismaHD);

                    rpt.DataDefinition.ParameterFields[0].ApplyCurrentValues(maHoaDon);

                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                }
            }
            catch (Exception ex)
            {

                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
                MessageBox.Show("Lỗi xuất hóa đơn");
                return;
            }

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void reportDocument1_InitReport(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
