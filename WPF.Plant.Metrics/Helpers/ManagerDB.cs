using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WPF.Plant.Metrics.Helpers
{
    public class ManagerDB
    {
        private string _connectionString { get; }

        protected ManagerDB()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }

        public static new ManagerDB GetInstance()
        {
            return new ManagerDB();
        }

        public DataTable DTExecute(string sql, string startDate, string endDate)
        {
            DataTable dtResult = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                SqlDataAdapter dt = new SqlDataAdapter();
                comm = new SqlCommand(sql);
                comm.CommandText = sql;
                comm.Parameters.Add(new SqlParameter("@StartDate", startDate));
                comm.Parameters.Add(new SqlParameter("@EndDate", endDate));
                comm.CommandType = CommandType.StoredProcedure;
                comm.Connection = conn;
                dt.SelectCommand = comm;
                dt.Fill(dtResult);
                conn.Close();
            }
            return dtResult;
        }
    }
}
