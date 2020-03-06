using HRM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult GetAllCompany(int PageNumber = 1, int PageSize = 3)
        {
            LSCompanyModel com = new LSCompanyModel();
            GenericService act = new GenericService();
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSCompanyID",SqlDbType.NVarChar,12){ Value = com.LSCompanyID ?? (object)DBNull.Value},
                new SqlParameter("@LSCompanyCode",SqlDbType.NVarChar,100){ Value = com.LSCompanyCode ?? (object)DBNull.Value},
                new SqlParameter("@ShortName",SqlDbType.NVarChar,100){ Value = com.ShortName ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,50){ Value = com.Name ?? (object)DBNull.Value},
                new SqlParameter("@Address",SqlDbType.NVarChar,50){ Value = com.Address ?? (object)DBNull.Value},
                new SqlParameter("@Phone",SqlDbType.NVarChar,1){ Value = com.Phone ?? (object)DBNull.Value},
                new SqlParameter("@Fax",SqlDbType.NVarChar,50){ Value = com.Fax ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.NVarChar,50){ Value = com.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,50){ Value = com.Note ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.NVarChar,50){ Value = com.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@WorkingPlace",SqlDbType.NVarChar,50){ Value = com.WorkingPlace ?? (object)DBNull.Value},
                new SqlParameter("@Creater",SqlDbType.NVarChar,50){ Value = com.Creater ?? (object)DBNull.Value},
                new SqlParameter("@CreateTime",SqlDbType.NVarChar,50){ Value = com.CreateTime ?? (object)DBNull.Value},
                new SqlParameter("@Editer",SqlDbType.NVarChar,50){ Value = com.Editer ?? (object)DBNull.Value},
                new SqlParameter("@EditTime",SqlDbType.NVarChar,50){ Value = com.EditTime ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","SelectAll")
                //new SqlParameter("@PageNumber",PageNumber),
                //new SqlParameter("@PageSize",PageSize)
            };
            //DataSet ds = act.crud("sp_InsertUpdateDelete_tblEmpCV", parameters);
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSCompany", parameters);
            ViewBag.com = ds.Tables[0];
            return View(new LSCompanyModel());
        }
    }
}