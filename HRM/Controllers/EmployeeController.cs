using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRM.Models;

namespace HRM.Controllers
{
    public class EmployeeController : Controller
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        // GET: Employee
        [HttpGet]
        public ActionResult GetAllEmp(int PageNumber = 1, int PageSize = 3)
        {
            EmployeeCVModel emp = new EmployeeCVModel();
            GenericService act = new GenericService();
            SqlParameter[] parameters =
            {
                new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = emp.EmpID ?? (object)DBNull.Value},
                new SqlParameter("@VLastName",SqlDbType.NVarChar,100){ Value = emp.VLastName ?? (object)DBNull.Value},
                new SqlParameter("@VFirstName",SqlDbType.NVarChar,100){ Value = emp.VFirstName ?? (object)DBNull.Value},
                new SqlParameter("@NickName",SqlDbType.NVarChar,50){ Value = emp.NickName ?? (object)DBNull.Value},
                new SqlParameter("@DOB",SqlDbType.NVarChar,50){ Value = emp.DOB ?? (object)DBNull.Value},
                new SqlParameter("@Gender",SqlDbType.NVarChar,1){ Value = emp.Gender ?? (object)DBNull.Value},
                new SqlParameter("@Email",SqlDbType.NVarChar,50){ Value = emp.Email ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","SelectAll")
                //new SqlParameter("@PageNumber",PageNumber),
                //new SqlParameter("@PageSize",PageSize)
            };
            //DataSet ds = act.crud("sp_InsertUpdateDelete_tblEmpCV", parameters);
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblEmpCV", parameters);
            ViewBag.emp = ds.Tables[0];
            return View(new EmployeeCVModel());
        }

        [HttpPost]
        public ActionResult GetAllEmp(EmployeeCVModel emp)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);

            GenericService act = new GenericService();
            if (emp.searchtxt != null)
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Searchtext",SqlDbType.NVarChar,50){ Value = emp.searchtxt ?? (object)DBNull.Value}
                };
                DataSet ds = act.Generic("sp_SearchData_EmpCV", parameters);
                ViewBag.emp = ds.Tables[0];
                return View(new EmployeeCVModel());
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult CreateEmp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmp(EmployeeCVModel emp)
        {
            GenericService act = new GenericService();
            emp.EmpID = act.getOutPut("sp_AutoGenID_Emp_Test", "@EmpID");
            SqlParameter[] parameters =
            {
                new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = emp.EmpID ?? (object)DBNull.Value},
                new SqlParameter("@VLastName",SqlDbType.NVarChar,100){ Value = emp.VLastName ?? (object)DBNull.Value},
                new SqlParameter("@VFirstName",SqlDbType.NVarChar,100){ Value = emp.VFirstName ?? (object)DBNull.Value},
                new SqlParameter("@NickName",SqlDbType.NVarChar,50){ Value = emp.NickName ?? (object)DBNull.Value},
                new SqlParameter("@DOB",SqlDbType.NVarChar,50){ Value = emp.DOB ?? (object)DBNull.Value},
                new SqlParameter("@Gender",SqlDbType.NVarChar,1){ Value = emp.Gender ?? (object)DBNull.Value},
                new SqlParameter("@Email",SqlDbType.NVarChar,50){ Value = emp.Email ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Insert")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblEmpCV", parameters);
            return RedirectToAction("GetAllEmp");
        }


        [HttpGet]
        public ActionResult UpdateEmp(string id)
        {

            EmployeeCVModel emp = new EmployeeCVModel();
            GenericService act = new GenericService();
            emp.EmpID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = emp.EmpID ?? (object)DBNull.Value},
                new SqlParameter("@VLastName",SqlDbType.NVarChar,100){ Value = emp.VLastName ?? (object)DBNull.Value},
                new SqlParameter("@VFirstName",SqlDbType.NVarChar,100){ Value = emp.VFirstName ?? (object)DBNull.Value},
                new SqlParameter("@NickName",SqlDbType.NVarChar,50){ Value = emp.NickName ?? (object)DBNull.Value},
                new SqlParameter("@DOB",SqlDbType.NVarChar,50){ Value = emp.DOB ?? (object)DBNull.Value},
                new SqlParameter("@Gender",SqlDbType.NVarChar,1){ Value = emp.Gender ?? (object)DBNull.Value},
                new SqlParameter("@Email",SqlDbType.NVarChar,50){ Value = emp.Email ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","SelectByID")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblEmpCV", parameters);
            ViewBag.emp = ds.Tables[0];
            return View();
        }

        [HttpPost]
        public ActionResult UpdateEmp(string id, EmployeeCVModel emp)
        {
            GenericService act = new GenericService();
            emp.EmpID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = emp.EmpID ?? (object)DBNull.Value},
                new SqlParameter("@VLastName",SqlDbType.NVarChar,100){ Value = emp.VLastName ?? (object)DBNull.Value},
                new SqlParameter("@VFirstName",SqlDbType.NVarChar,100){ Value = emp.VFirstName ?? (object)DBNull.Value},
                new SqlParameter("@NickName",SqlDbType.NVarChar,50){ Value = emp.NickName ?? (object)DBNull.Value},
                new SqlParameter("@DOB",SqlDbType.NVarChar,50){ Value = emp.DOB ?? (object)DBNull.Value},
                new SqlParameter("@Gender",SqlDbType.NVarChar,1){ Value = emp.Gender ?? (object)DBNull.Value},
                new SqlParameter("@Email",SqlDbType.NVarChar,50){ Value = emp.Email ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Update")
            };
            act.Generic("sp_InsertUpdateDelete_tblEmpCV", parameters);
            return RedirectToAction("GetAllEmp");
        }

        [HttpGet]
        public ActionResult DeleteEmp(string id, string email)
        {
            EmployeeCVModel emp = new EmployeeCVModel();
            GenericService act = new GenericService();
            emp.EmpID = id;
            emp.Email = email;
            SqlParameter[] parameters =
            {
                new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = emp.EmpID ?? (object)DBNull.Value},
                new SqlParameter("@VLastName",SqlDbType.NVarChar,100){ Value = emp.VLastName ?? (object)DBNull.Value},
                new SqlParameter("@VFirstName",SqlDbType.NVarChar,100){ Value = emp.VFirstName ?? (object)DBNull.Value},
                new SqlParameter("@NickName",SqlDbType.NVarChar,50){ Value = emp.NickName ?? (object)DBNull.Value},
                new SqlParameter("@DOB",SqlDbType.NVarChar,50){ Value = emp.DOB ?? (object)DBNull.Value},
                new SqlParameter("@Gender",SqlDbType.NVarChar,1){ Value = emp.Gender ?? (object)DBNull.Value},
                new SqlParameter("@Email",SqlDbType.NVarChar,50){ Value = emp.Email ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","SelectByID")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblEmpCV", parameters);
            ViewBag.emp = ds.Tables[0];
            return View();
        }

        [HttpPost]
        public ActionResult DeleteEmp(string id, string email, EmployeeCVModel emp)
        {
            GenericService act = new GenericService();
            emp.EmpID = id;
            emp.Email = email;
            SqlParameter[] parameters =
            {
                new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = emp.EmpID ?? (object)DBNull.Value},
                new SqlParameter("@VLastName",SqlDbType.NVarChar,100){ Value = emp.VLastName ?? (object)DBNull.Value},
                new SqlParameter("@VFirstName",SqlDbType.NVarChar,100){ Value = emp.VFirstName ?? (object)DBNull.Value},
                new SqlParameter("@NickName",SqlDbType.NVarChar,50){ Value = emp.NickName ?? (object)DBNull.Value},
                new SqlParameter("@DOB",SqlDbType.NVarChar,50){ Value = emp.DOB ?? (object)DBNull.Value},
                new SqlParameter("@Gender",SqlDbType.NVarChar,1){ Value = emp.Gender ?? (object)DBNull.Value},
                new SqlParameter("@Email",SqlDbType.NVarChar,50){ Value = emp.Email ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Delete")
            };
            act.Generic("sp_InsertUpdateDelete_tblEmpCV", parameters);
            return RedirectToAction("GetAllEmp");            
        }

        public ActionResult Details(string id)
        {
            EmployeeCVModel emp = new EmployeeCVModel();
            GenericService act = new GenericService();
            emp.EmpID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = emp.EmpID ?? (object)DBNull.Value},
                new SqlParameter("@VLastName",SqlDbType.NVarChar,100){ Value = emp.VLastName ?? (object)DBNull.Value},
                new SqlParameter("@VFirstName",SqlDbType.NVarChar,100){ Value = emp.VFirstName ?? (object)DBNull.Value},
                new SqlParameter("@NickName",SqlDbType.NVarChar,50){ Value = emp.NickName ?? (object)DBNull.Value},
                new SqlParameter("@DOB",SqlDbType.NVarChar,50){ Value = emp.DOB ?? (object)DBNull.Value},
                new SqlParameter("@Gender",SqlDbType.NVarChar,1){ Value = emp.Gender ?? (object)DBNull.Value},
                new SqlParameter("@Email",SqlDbType.NVarChar,50){ Value = emp.Email ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","SelectByID")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblEmpCV", parameters);
            ViewBag.emp = ds.Tables[0];
            return View();
        }
    }
}