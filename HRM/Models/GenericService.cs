using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HRM.Models
{
    public class GenericService
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        /// <summary>
        /// Generic operation
        /// </summary>
        /// <param name="spname">tên SP</param>
        /// <param name="prms">param SP</param>
        /// <returns></returns>
        public DataSet Generic(string spname, SqlParameter[] prms = null)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(spname, conn);
            if (prms != null)
            {
                cmd.Parameters.AddRange(prms);
            }
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// hàm lấy giá trị output trong SP
        /// </summary>
        /// <param name="sp_name">tên SP</param>
        /// <param name="prms_sp">param SP</param>
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
                    SqlParameter prms = new SqlParameter(prms_sp, SqlDbType.NVarChar, 12);
                    prms.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(prms);
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
        /// Mã hóa MD5
        /// </summary>
        static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        public static string MD5Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        if (string.IsNullOrEmpty(text))
                        {
                            return null;
                        }
                        else
                        {
                            byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                            byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                            return Convert.ToBase64String(bytes, 0, bytes.Length);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gửi email
        /// </summary>
        /// <param name="toEmailAddress">Email nhận</param>
        /// <param name="subject"></param>
        /// <param name="fromEmailDisplayName">Tên thay thế cho Email gửi đi</param>
        /// <param name="content">Nội dung</param>
        public static void SendMail(string toEmailAddress, string subject, string fromEmailDisplayName, string content)
        {
            string fromEmailAddress = "";
            string fromEmailPassword = "";
            string body = content;
            MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;
            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Port = 587;
            client.Send(message);
        }
    }
}