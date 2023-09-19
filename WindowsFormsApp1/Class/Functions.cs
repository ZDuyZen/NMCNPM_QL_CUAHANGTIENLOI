using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;

namespace WindowsFormsApp1.Class
{
    internal class Functions
    {
        public static SqlConnection con;
        
        public static bool Connect()
        {
            con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.QLBanHangConnectString;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                return true;
            }
            return false;
        }

        public static void Disconnect()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
                con = null;
            }
        }

        public static DataTable GetDataTable(string sql)
        {
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(table);
            return table;
        }

        public static void RunSQL(string sql)
        {
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection= con;
            cmd.CommandText= sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }

        public static bool CheckKey(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            DataTable table= new DataTable();
            dap.Fill(table);
            if(table.Rows.Count > 0 )
            {
                return true;
            }
            else return false;
        }

        public static void RunSqlDel(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Functions.con;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }

        public static string GetFieldValues(string sql)
        {
            
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            string dr1 = "";
            while (dr.Read())
            {
                dr1= dr.GetValue(0).ToString();                
            }
            dr.Close();
            return dr1;

        }

        public static string ConvertDateTime(string date)
        {
            string[] elements = date.Split('/');
            string dt = string.Format("{0}/{1}/{2}", elements[0], elements[1], elements[2]);
            return dt;
        }

        public static void FillCombo(string sql, ComboBox cbb, string ma, string ten)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            dap.Fill(table);
            cbb.DataSource = table;
            cbb.ValueMember = ma;
            cbb.DisplayMember = ten;
        }
    }
}
