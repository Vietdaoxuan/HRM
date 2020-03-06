using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace HRM.Models
{
    public class EmployeeCVAction
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        /// <summary>
        /// Hàm lấy tất cả dữ liệu trong bảng
        /// </summary>
        /// <param name="spname">tên SP</param>
        /// <returns></returns>
        public DataSet GetData(string spname, SqlParameter[] prms)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spname, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                    }
                }
            }
            return ds;
        }

        /// <summary>
        /// lấy dữ liệu theo ID
        /// </summary>
        /// <param name="spname">tên SP</param>
        /// <param name="id">biến id trong model</param>
        /// <param name="param_sp">param của SP</param>
        /// <returns></returns>
        public DataSet SelectByID(string spname, string id, string param_sp)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(spname, conn);                       
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(param_sp, id);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sp_name"></param>
        /// <param name="prms_sp"></param>
        /// <returns></returns>
        public string getOutPut(string sp_name, string prms_sp)
        {
            string result;
            SqlConnection conn = new SqlConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sp_name, conn))
            {
                try
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter newSqlParam = new SqlParameter(prms_sp,SqlDbType.NVarChar,12);
                    newSqlParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(newSqlParam);
                    cmd.ExecuteNonQuery();
                    result = cmd.Parameters[prms_sp].Value.ToString();
                }
                catch (Exception ex)
                {
                    string msg = ex.ToString();
                    result = "";
                }
            }            
            return result;
        }

        /// <summary>
        /// Hàm thêm dữ liệu
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public string InsertData(string spname, SqlParameter[] prms = null)
        {
            string result;
            SqlConnection conn = new SqlConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(spname, conn))
            {
                //prms[0].Value = getOutPut(spname_genid, prms_sp);
                cmd.Parameters.AddRange(prms);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                result = cmd.ExecuteNonQuery().ToString();
                conn.Close();
                return result;
            }                                           
        }

        public DataSet UpdateData(string spname, SqlParameter[] prms =  null)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(spname, conn);
            if (prms != null)
            {
                cmd.Parameters.AddRange(prms);
            }
            SqlDataAdapter da = new SqlDataAdapter();
            //conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            //cmd.ExecuteNonQuery();
            //conn.Close();
            return ds;
        }

        public DataSet DeleteData(string spname, SqlParameter[] prms = null)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(spname))
                {
                    //if (prms != null)
                        cmd.Parameters.AddRange(prms);
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                    }
                }
                return ds;
            }
        }
    }
}