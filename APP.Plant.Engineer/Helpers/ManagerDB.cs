using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace APP.Plant.Engineer.Helpers
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

        public DataTable ValidateUser(string pUser, string pPass)
        {
            try
            {
                DataTable dtResult = new DataTable();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd.CommandText = Constants.QUERY_VALIDATE_USER + " where cod_user = '" + pUser + "' and pass = '" + pPass + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    conn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(dtResult);
                    conn.Close();
                }
                if (dtResult != null)
                    return dtResult;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
                
            }

        }

        public DataTable GetReports()
        {
            try
            {
                DataTable dtResult = new DataTable();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd.CommandText = Constants.QUERY_GET_REPORTS;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    conn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(dtResult);
                    conn.Close();
                }
                if (dtResult != null)
                    return dtResult;
                else
                    return null;
            }
            catch(Exception ex)
            {
                return null;
                throw ex;

            }

        }

        public DataTable GetCatalog(string namCatalog, string Id)
        {
            try
            {
                DataTable dtResult = new DataTable();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd.CommandText = Constants.QUERY_CATALOG(namCatalog, Id);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    conn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(dtResult);
                    conn.Close();
                }
                if (dtResult != null)
                    return dtResult;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;

            }

        }

        public DataTable SelReportOEE(string pStartDate, string pEndDate)
        {
            try
            {
                DataTable dtResult = new DataTable();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd.CommandText = Constants.SP_TABLE_GRAPHIC_OEE;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StartDate", pStartDate);
                    cmd.Parameters.AddWithValue("@EndDate", pEndDate);
                    cmd.Connection = conn;

                    conn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(dtResult);
                    conn.Close();
                }
                if (dtResult != null)
                    return dtResult;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;

            }

        }

        public DataTable SelReportDisponibilidad(string pStartDate, string pEndDate)
        {
            try
            {
                DataTable dtResult = new DataTable();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd.CommandText = Constants.SP_TABLE_GRAPHIC_DISPONIBILIDAD;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StartDate", pStartDate);
                    cmd.Parameters.AddWithValue("@EndDate", pEndDate);
                    cmd.Connection = conn;

                    conn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(dtResult);
                    conn.Close();
                }
                if (dtResult != null)
                    return dtResult;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;

            }

        }

        public DataTable SelReportCostos(string pStartDate, string pEndDate)
        {
            try
            {
                DataTable dtResult = new DataTable();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd.CommandText = Constants.SP_TABLE_COSTOS;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StartDate", pStartDate);
                    cmd.Parameters.AddWithValue("@EndDate", pEndDate);
                    cmd.Connection = conn;

                    conn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(dtResult);
                    conn.Close();
                }
                if (dtResult != null)
                    return dtResult;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;

            }

        }

        public DataTable SelReportCostosPerdida(string pStartDate, string pEndDate)
        {
            try
            {
                DataTable dtResult = new DataTable();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd.CommandText = Constants.SP_TABLE_COSTOS_PERDIDA;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StartDate", pStartDate);
                    cmd.Parameters.AddWithValue("@EndDate", pEndDate);
                    cmd.Connection = conn;

                    conn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(dtResult);
                    conn.Close();
                }
                if (dtResult != null)
                    return dtResult;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;

            }

        }

        public DataTable SelReportCostosPerdidaPorProduccion(string pStartDate, string pEndDate)
        {
            try
            {
                DataTable dtResult = new DataTable();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd.CommandText = Constants.SP_TABLE_COSTOS_PERDIDA_PRODUCCION;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StartDate", pStartDate);
                    cmd.Parameters.AddWithValue("@EndDate", pEndDate);
                    cmd.Connection = conn;

                    conn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(dtResult);
                    conn.Close();
                }
                if (dtResult != null)
                    return dtResult;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;

            }

        }

    }
}