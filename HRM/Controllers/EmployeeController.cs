using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRM.Class;
using HRM.Models;

namespace HRM.Controllers
{
    public class EmployeeController : Controller
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        // GET: Employee
        [HttpGet]
        public ActionResult GetAllEmp()
        {
            DataAccessLayer act = new DataAccessLayer();
            Employee employee = new Employee();
            SqlParameter[] parameters =
            {
                new SqlParameter("@Searchtxt",SqlDbType.NVarChar,100){ Value = employee.searchtxt ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","GetData")
            };
            DataSet ds = act.Generic("sp_MergeEmpl", parameters);
            ViewBag.emp = ds.Tables[0];
            return View();
        }

        /// <summary>
        /// Search data from table
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetAllEmp(Employee employee)
        {
            DataAccessLayer act = new DataAccessLayer();        
            if (employee.searchtxt != null)
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Searchtxt",SqlDbType.NVarChar,100){ Value = employee.searchtxt ?? (object)DBNull.Value},
                    new SqlParameter("@ACTION","Search")
                };
                DataSet ds = act.Generic("sp_MergeEmpl", parameters);
                ViewBag.emp = ds.Tables[0];
                return View(new Employee());
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateEmp(Employee employee)
        {
            DataAccessLayer act = new DataAccessLayer();
            employee.EmpID = act.getOutPut("sp_AutoGenID_Emp_Test", "@EmpID");
            SqlParameter[] parameters =
            {
                new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = employee.EmpID ?? (object)DBNull.Value},
                new SqlParameter("@VLastName",SqlDbType.NVarChar,100){ Value = employee.VLastName ?? (object)DBNull.Value},
                new SqlParameter("@VFirstName",SqlDbType.NVarChar,100){ Value = employee.VFirstName ?? (object)DBNull.Value},
                new SqlParameter("@NickName",SqlDbType.NVarChar,50){ Value = employee.NickName ?? (object)DBNull.Value},
                new SqlParameter("@DOB",SqlDbType.NVarChar,50){ Value = employee.DOB ?? (object)DBNull.Value},
                new SqlParameter("@Gender",SqlDbType.NVarChar,1){ Value = employee.Gender ?? (object)DBNull.Value},
                new SqlParameter("@LSMaritalID",SqlDbType.NVarChar,12){ Value = employee.LSMaritalID ?? (object)DBNull.Value},
                new SqlParameter("@Born_District",SqlDbType.NVarChar,12){ Value = employee.Born_District ?? (object)DBNull.Value},
                new SqlParameter("@Born_LSProvinceID",SqlDbType.NVarChar,12){ Value = employee.Born_LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@Native_District",SqlDbType.NVarChar,12){ Value = employee.Native_District ?? (object)DBNull.Value},
                new SqlParameter("@Native_LSProvinceID",SqlDbType.NVarChar,12){ Value = employee.Native_LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@LSEthnicID",SqlDbType.NVarChar,12){ Value = employee.LSEthnicID ?? (object)DBNull.Value},
                new SqlParameter("@IDNo",SqlDbType.VarChar,20){ Value = employee.IDNo ?? (object)DBNull.Value},
                new SqlParameter("@IDIssuedDate",SqlDbType.NVarChar,50){ Value = employee.IDIssuedDate ?? (object)DBNull.Value},
                new SqlParameter("@IDIssuedPlace",SqlDbType.NVarChar,12){ Value = employee.IDIssuedPlace ?? (object)DBNull.Value},
                new SqlParameter("@Mobifone",SqlDbType.NVarChar,30){ Value = employee.Mobifone ?? (object)DBNull.Value},
                new SqlParameter("@Telephone",SqlDbType.NVarChar,30){ Value = employee.Telephone ?? (object)DBNull.Value},
                new SqlParameter("@Email",SqlDbType.NVarChar,50){ Value = employee.Email ?? (object)DBNull.Value},
                new SqlParameter("@LSNationalityID",SqlDbType.NVarChar,12){ Value = employee.LSNationalityID ?? (object)DBNull.Value},
                new SqlParameter("@LSCultureLevelID",SqlDbType.NVarChar,12){ Value = employee.LSCultureLevelID ?? (object)DBNull.Value},
                new SqlParameter("@ScanCode",SqlDbType.NVarChar,20){ Value = employee.ScanCode ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = employee.Note ?? (object)DBNull.Value},
                new SqlParameter("@Creater",SqlDbType.NVarChar,12){ Value = employee.Creater ?? (object)DBNull.Value},
                new SqlParameter("@Editer",SqlDbType.NVarChar,12){ Value = employee.Editer ?? (object)DBNull.Value},
                new SqlParameter("@BankNo",SqlDbType.NVarChar,20){ Value = employee.BankNo ?? (object)DBNull.Value},
                new SqlParameter("@LSBankID",SqlDbType.NVarChar,12){ Value = employee.LSBankID ?? (object)DBNull.Value},
                new SqlParameter("@IsEmpBook",SqlDbType.Bit){ Value = employee.IsEmpBook.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsEmpCode",SqlDbType.Bit){ Value = employee.IsEmpCode.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsUniform",SqlDbType.Bit){ Value = employee.IsUniform.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsTrain",SqlDbType.Bit){ Value = employee.IsTrain.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Insert")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblEmpCV", parameters);
            SqlParameter[] parameters1 =
            {
                 new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = employee.EmpID ?? (object)DBNull.Value},
                 new SqlParameter("@EmpCode",SqlDbType.NVarChar,15){ Value = employee.EmpCode ?? (object)DBNull.Value},
                 new SqlParameter("@EmpCodeOld",SqlDbType.NVarChar,15){ Value = employee.EmpCodeOld ?? (object)DBNull.Value},
                 new SqlParameter("@StartDate",SqlDbType.NVarChar,50){ Value = employee.StartDate ?? (object)DBNull.Value},
                 new SqlParameter("@LSCompanyID",SqlDbType.NVarChar,12){ Value = employee.LSCompanyID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLevel1ID",SqlDbType.NVarChar,12){ Value = employee.LSLevel1ID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLevel2ID",SqlDbType.NVarChar,12){ Value = employee.LSLevel2ID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLevel3ID",SqlDbType.NVarChar,12){ Value = employee.LSLevel3ID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLevel4ID",SqlDbType.NVarChar,12){ Value = employee.LSLevel4ID ?? (object)DBNull.Value},
                 new SqlParameter("@LSPositionID",SqlDbType.NVarChar,12){ Value = employee.LSPositionID ?? (object)DBNull.Value},
                 new SqlParameter("@LSJobTitleID",SqlDbType.NVarChar,12){ Value = employee.LSJobTitleID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLocationID",SqlDbType.NVarChar,12){ Value = employee.LSLocationID ?? (object)DBNull.Value},
                 new SqlParameter("@LSEmpTypeID",SqlDbType.NVarChar,12){ Value = employee.LSEmpTypeID ?? (object)DBNull.Value},
                 new SqlParameter("@Active",SqlDbType.Bit){ Value = employee.Active.ToString() ?? (object)DBNull.Value},
                 new SqlParameter("@ACTION","Insert")
            };
            DataSet ds1 = act.Generic("sp_InsertUpdateDelete_tblEmp", parameters1);
            var redirectUrl = new UrlHelper(Request.RequestContext).Action("GetAllEmp", "Employee");
            return Json(new { Url = redirectUrl });
        }


        [HttpGet]
        public ActionResult UpdateEmp(Employee employee, string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            employee.EmpID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = employee.EmpID ?? (object)DBNull.Value},
                new SqlParameter("@VLastName",SqlDbType.NVarChar,100){ Value = employee.VLastName ?? (object)DBNull.Value},
                new SqlParameter("@VFirstName",SqlDbType.NVarChar,100){ Value = employee.VFirstName ?? (object)DBNull.Value},
                new SqlParameter("@NickName",SqlDbType.NVarChar,50){ Value = employee.NickName ?? (object)DBNull.Value},
                new SqlParameter("@DOB",SqlDbType.NVarChar,50){ Value = employee.DOB ?? (object)DBNull.Value},
                new SqlParameter("@Gender",SqlDbType.NVarChar,1){ Value = employee.Gender ?? (object)DBNull.Value},
                new SqlParameter("@LSMaritalID",SqlDbType.NVarChar,12){ Value = employee.LSMaritalID ?? (object)DBNull.Value},
                new SqlParameter("@Born_District",SqlDbType.NVarChar,12){ Value = employee.Born_District ?? (object)DBNull.Value},
                new SqlParameter("@Born_LSProvinceID",SqlDbType.NVarChar,12){ Value = employee.Born_LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@Native_District",SqlDbType.NVarChar,12){ Value = employee.Native_District ?? (object)DBNull.Value},
                new SqlParameter("@Native_LSProvinceID",SqlDbType.NVarChar,12){ Value = employee.Native_LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@LSEthnicID",SqlDbType.NVarChar,12){ Value = employee.LSEthnicID ?? (object)DBNull.Value},
                new SqlParameter("@IDNo",SqlDbType.VarChar,20){ Value = employee.IDNo ?? (object)DBNull.Value},
                new SqlParameter("@IDIssuedDate",SqlDbType.NVarChar,50){ Value = employee.IDIssuedDate ?? (object)DBNull.Value},
                new SqlParameter("@IDIssuedPlace",SqlDbType.NVarChar,12){ Value = employee.IDIssuedPlace ?? (object)DBNull.Value},
                new SqlParameter("@Mobifone",SqlDbType.NVarChar,30){ Value = employee.Mobifone ?? (object)DBNull.Value},
                new SqlParameter("@Telephone",SqlDbType.NVarChar,30){ Value = employee.Telephone ?? (object)DBNull.Value},
                new SqlParameter("@Email",SqlDbType.NVarChar,50){ Value = employee.Email ?? (object)DBNull.Value},
                new SqlParameter("@LSNationalityID",SqlDbType.NVarChar,12){ Value = employee.LSNationalityID ?? (object)DBNull.Value},
                new SqlParameter("@LSCultureLevelID",SqlDbType.NVarChar,12){ Value = employee.LSCultureLevelID ?? (object)DBNull.Value},
                new SqlParameter("@ScanCode",SqlDbType.NVarChar,20){ Value = employee.ScanCode ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = employee.Note ?? (object)DBNull.Value},
                new SqlParameter("@Creater",SqlDbType.NVarChar,12){ Value = employee.Creater ?? (object)DBNull.Value},
                new SqlParameter("@Editer",SqlDbType.NVarChar,12){ Value = employee.Editer ?? (object)DBNull.Value},
                new SqlParameter("@BankNo",SqlDbType.NVarChar,20){ Value = employee.BankNo ?? (object)DBNull.Value},
                new SqlParameter("@LSBankID",SqlDbType.NVarChar,12){ Value = employee.LSBankID ?? (object)DBNull.Value},
                new SqlParameter("@IsEmpBook",SqlDbType.Bit){ Value = employee.IsEmpBook.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsEmpCode",SqlDbType.Bit){ Value = employee.IsEmpCode.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsUniform",SqlDbType.Bit){ Value = employee.IsUniform.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsTrain",SqlDbType.Bit){ Value = employee.IsTrain.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","SelectByID")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblEmpCV", parameters);
          
            SqlParameter[] parameters1 =
            {
                 new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = employee.EmpID ?? (object)DBNull.Value},
                 new SqlParameter("@EmpCode",SqlDbType.NVarChar,15){ Value = employee.EmpCode ?? (object)DBNull.Value},
                 new SqlParameter("@EmpCodeOld",SqlDbType.NVarChar,15){ Value = employee.EmpCodeOld ?? (object)DBNull.Value},
                 new SqlParameter("@StartDate",SqlDbType.NVarChar,50){ Value = employee.StartDate ?? (object)DBNull.Value},
                 new SqlParameter("@LSCompanyID",SqlDbType.NVarChar,12){ Value = employee.LSCompanyID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLevel1ID",SqlDbType.NVarChar,12){ Value = employee.LSLevel1ID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLevel2ID",SqlDbType.NVarChar,12){ Value = employee.LSLevel2ID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLevel3ID",SqlDbType.NVarChar,12){ Value = employee.LSLevel3ID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLevel4ID",SqlDbType.NVarChar,12){ Value = employee.LSLevel4ID ?? (object)DBNull.Value},
                 new SqlParameter("@LSPositionID",SqlDbType.NVarChar,12){ Value = employee.LSPositionID ?? (object)DBNull.Value},
                 new SqlParameter("@LSJobTitleID",SqlDbType.NVarChar,12){ Value = employee.LSJobTitleID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLocationID",SqlDbType.NVarChar,12){ Value = employee.LSLocationID ?? (object)DBNull.Value},
                 new SqlParameter("@LSEmpTypeID",SqlDbType.NVarChar,12){ Value = employee.LSEmpTypeID ?? (object)DBNull.Value},
                 new SqlParameter("@Active",SqlDbType.Bit){ Value = employee.Active.ToString() ?? (object)DBNull.Value},
                 new SqlParameter("@ACTION","SelectByID")
            };
            DataSet ds1 = act.Generic("sp_InsertUpdateDelete_tblEmp", parameters1);
            ViewBag.emp = ds.Tables[0];
            ViewBag.emp1 = ds1.Tables[0];          
            return View();
        }

        [HttpPost]
        public ActionResult UpdateEmp(string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            Employee employee = new Employee();
            employee.EmpID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = employee.EmpID ?? (object)DBNull.Value},
                new SqlParameter("@VLastName",SqlDbType.NVarChar,100){ Value = employee.VLastName ?? (object)DBNull.Value},
                new SqlParameter("@VFirstName",SqlDbType.NVarChar,100){ Value = employee.VFirstName ?? (object)DBNull.Value},
                new SqlParameter("@NickName",SqlDbType.NVarChar,50){ Value = employee.NickName ?? (object)DBNull.Value},
                new SqlParameter("@DOB",SqlDbType.NVarChar,50){ Value = employee.DOB ?? (object)DBNull.Value},
                new SqlParameter("@Gender",SqlDbType.NVarChar,1){ Value = employee.Gender ?? (object)DBNull.Value},
                new SqlParameter("@LSMaritalID",SqlDbType.NVarChar,12){ Value = employee.LSMaritalID ?? (object)DBNull.Value},
                new SqlParameter("@Born_District",SqlDbType.NVarChar,12){ Value = employee.Born_District ?? (object)DBNull.Value},
                new SqlParameter("@Born_LSProvinceID",SqlDbType.NVarChar,12){ Value = employee.Born_LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@Native_District",SqlDbType.NVarChar,12){ Value = employee.Native_District ?? (object)DBNull.Value},
                new SqlParameter("@Native_LSProvinceID",SqlDbType.NVarChar,12){ Value = employee.Native_LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@LSEthnicID",SqlDbType.NVarChar,12){ Value = employee.LSEthnicID ?? (object)DBNull.Value},
                new SqlParameter("@IDNo",SqlDbType.VarChar,20){ Value = employee.IDNo ?? (object)DBNull.Value},
                new SqlParameter("@IDIssuedDate",SqlDbType.NVarChar,50){ Value = employee.IDIssuedDate ?? (object)DBNull.Value},
                new SqlParameter("@IDIssuedPlace",SqlDbType.NVarChar,12){ Value = employee.IDIssuedPlace ?? (object)DBNull.Value},
                new SqlParameter("@Mobifone",SqlDbType.NVarChar,30){ Value = employee.Mobifone ?? (object)DBNull.Value},
                new SqlParameter("@Telephone",SqlDbType.NVarChar,30){ Value = employee.Telephone ?? (object)DBNull.Value},
                new SqlParameter("@Email",SqlDbType.NVarChar,50){ Value = employee.Email ?? (object)DBNull.Value},
                new SqlParameter("@LSNationalityID",SqlDbType.NVarChar,12){ Value = employee.LSNationalityID ?? (object)DBNull.Value},
                new SqlParameter("@LSCultureLevelID",SqlDbType.NVarChar,12){ Value = employee.LSCultureLevelID ?? (object)DBNull.Value},
                new SqlParameter("@ScanCode",SqlDbType.NVarChar,20){ Value = employee.ScanCode ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = employee.Note ?? (object)DBNull.Value},
                new SqlParameter("@Creater",SqlDbType.NVarChar,12){ Value = employee.Creater ?? (object)DBNull.Value},
                new SqlParameter("@Editer",SqlDbType.NVarChar,12){ Value = employee.Editer ?? (object)DBNull.Value},
                new SqlParameter("@BankNo",SqlDbType.NVarChar,20){ Value = employee.BankNo ?? (object)DBNull.Value},
                new SqlParameter("@LSBankID",SqlDbType.NVarChar,12){ Value = employee.LSBankID ?? (object)DBNull.Value},
                new SqlParameter("@IsEmpBook",SqlDbType.Bit){ Value = employee.IsEmpBook.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsEmpCode",SqlDbType.Bit){ Value = employee.IsEmpCode.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsUniform",SqlDbType.Bit){ Value = employee.IsUniform.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsTrain",SqlDbType.Bit){ Value = employee.IsTrain.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Update")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblEmpCV", parameters);
            SqlParameter[] parameters1 =
            {
                 new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = employee.EmpID ?? (object)DBNull.Value},
                 new SqlParameter("@EmpCode",SqlDbType.NVarChar,15){ Value = employee.EmpCode ?? (object)DBNull.Value},
                 new SqlParameter("@EmpCodeOld",SqlDbType.NVarChar,15){ Value = employee.EmpCodeOld ?? (object)DBNull.Value},
                 new SqlParameter("@StartDate",SqlDbType.NVarChar,50){ Value = employee.StartDate ?? (object)DBNull.Value},
                 new SqlParameter("@LSCompanyID",SqlDbType.NVarChar,12){ Value = employee.LSCompanyID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLevel1ID",SqlDbType.NVarChar,12){ Value = employee.LSLevel1ID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLevel2ID",SqlDbType.NVarChar,12){ Value = employee.LSLevel2ID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLevel3ID",SqlDbType.NVarChar,12){ Value = employee.LSLevel3ID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLevel4ID",SqlDbType.NVarChar,12){ Value = employee.LSLevel4ID ?? (object)DBNull.Value},
                 new SqlParameter("@LSPositionID",SqlDbType.NVarChar,12){ Value = employee.LSPositionID ?? (object)DBNull.Value},
                 new SqlParameter("@LSJobTitleID",SqlDbType.NVarChar,12){ Value = employee.LSJobTitleID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLocationID",SqlDbType.NVarChar,12){ Value = employee.LSLocationID ?? (object)DBNull.Value},
                 new SqlParameter("@LSEmpTypeID",SqlDbType.NVarChar,12){ Value = employee.LSEmpTypeID ?? (object)DBNull.Value},
                 new SqlParameter("@Active",SqlDbType.Bit){ Value = employee.Active.ToString() ?? (object)DBNull.Value},
                 new SqlParameter("@ACTION","Update")
            };
            DataSet ds1 = act.Generic("sp_InsertUpdateDelete_tblEmp", parameters1);
            var redirectUrl = new UrlHelper(Request.RequestContext).Action("GetAllEmp", "Employee");
            return Json(new { Url = redirectUrl });
        }

        [HttpGet]
        public ActionResult DeleteEmp(string id)
        {
            EmployeeCVModel emp = new EmployeeCVModel();
            DataAccessLayer act = new DataAccessLayer();
            SqlParameter[] parameters =
            {
                new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = emp.EmpID ?? (object)DBNull.Value},
                new SqlParameter("@VLastName",SqlDbType.NVarChar,100){ Value = emp.VLastName ?? (object)DBNull.Value},
                new SqlParameter("@VFirstName",SqlDbType.NVarChar,100){ Value = emp.VFirstName ?? (object)DBNull.Value},
                new SqlParameter("@NickName",SqlDbType.NVarChar,50){ Value = emp.NickName ?? (object)DBNull.Value},
                new SqlParameter("@DOB",SqlDbType.NVarChar,50){ Value = emp.DOB ?? (object)DBNull.Value},
                new SqlParameter("@Gender",SqlDbType.NVarChar,1){ Value = emp.Gender ?? (object)DBNull.Value},
                new SqlParameter("@LSMaritalID",SqlDbType.NVarChar,12){ Value = emp.LSMaritalID ?? (object)DBNull.Value},
                new SqlParameter("@Born_District",SqlDbType.NVarChar,12){ Value = emp.Born_District ?? (object)DBNull.Value},
                new SqlParameter("@Born_LSProvinceID",SqlDbType.NVarChar,12){ Value = emp.Born_LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@Native_District",SqlDbType.NVarChar,12){ Value = emp.Native_District ?? (object)DBNull.Value},
                new SqlParameter("@Native_LSProvinceID",SqlDbType.NVarChar,12){ Value = emp.Native_LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@LSEthnicID",SqlDbType.NVarChar,12){ Value = emp.LSEthnicID ?? (object)DBNull.Value},
                new SqlParameter("@IDNo",SqlDbType.VarChar,20){ Value = emp.IDNo ?? (object)DBNull.Value},
                new SqlParameter("@IDIssuedDate",SqlDbType.NVarChar,50){ Value = emp.IDIssuedDate ?? (object)DBNull.Value},
                new SqlParameter("@IDIssuedPlace",SqlDbType.NVarChar,12){ Value = emp.IDIssuedPlace ?? (object)DBNull.Value},
                new SqlParameter("@Mobifone",SqlDbType.NVarChar,30){ Value = emp.Mobifone ?? (object)DBNull.Value},
                new SqlParameter("@Telephone",SqlDbType.NVarChar,30){ Value = emp.Telephone ?? (object)DBNull.Value},
                new SqlParameter("@Email",SqlDbType.NVarChar,50){ Value = emp.Email ?? (object)DBNull.Value},
                new SqlParameter("@LSNationalityID",SqlDbType.NVarChar,12){ Value = emp.LSNationalityID ?? (object)DBNull.Value},
                new SqlParameter("@LSCultureLevelID",SqlDbType.NVarChar,12){ Value = emp.LSCultureLevelID ?? (object)DBNull.Value},
                new SqlParameter("@ScanCode",SqlDbType.NVarChar,20){ Value = emp.ScanCode ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = emp.Note ?? (object)DBNull.Value},
                new SqlParameter("@Creater",SqlDbType.NVarChar,12){ Value = emp.Creater ?? (object)DBNull.Value},
                new SqlParameter("@Editer",SqlDbType.NVarChar,12){ Value = emp.Editer ?? (object)DBNull.Value},
                new SqlParameter("@BankNo",SqlDbType.NVarChar,20){ Value = emp.BankNo ?? (object)DBNull.Value},
                new SqlParameter("@LSBankID",SqlDbType.NVarChar,12){ Value = emp.LSBankID ?? (object)DBNull.Value},
                new SqlParameter("@IsEmpBook",SqlDbType.Bit){ Value = emp.IsEmpBook.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsEmpCode",SqlDbType.Bit){ Value = emp.IsEmpCode.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsUniform",SqlDbType.Bit){ Value = emp.IsUniform.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsTrain",SqlDbType.Bit){ Value = emp.IsTrain.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","SelectByID")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblEmpCV", parameters);
            ViewBag.emp = ds.Tables[0];
            return View();
        }

        [HttpPost]
        public ActionResult DeleteEmp(string id, EmployeeCVModel emp)
        {
            DataAccessLayer act = new DataAccessLayer();
            emp.EmpID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = emp.EmpID ?? (object)DBNull.Value},
                new SqlParameter("@VLastName",SqlDbType.NVarChar,100){ Value = emp.VLastName ?? (object)DBNull.Value},
                new SqlParameter("@VFirstName",SqlDbType.NVarChar,100){ Value = emp.VFirstName ?? (object)DBNull.Value},
                new SqlParameter("@NickName",SqlDbType.NVarChar,50){ Value = emp.NickName ?? (object)DBNull.Value},
                new SqlParameter("@DOB",SqlDbType.NVarChar,50){ Value = emp.DOB ?? (object)DBNull.Value},
                new SqlParameter("@Gender",SqlDbType.NVarChar,1){ Value = emp.Gender ?? (object)DBNull.Value},
                new SqlParameter("@LSMaritalID",SqlDbType.NVarChar,12){ Value = emp.LSMaritalID ?? (object)DBNull.Value},
                new SqlParameter("@Born_District",SqlDbType.NVarChar,12){ Value = emp.Born_District ?? (object)DBNull.Value},
                new SqlParameter("@Born_LSProvinceID",SqlDbType.NVarChar,12){ Value = emp.Born_LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@Native_District",SqlDbType.NVarChar,12){ Value = emp.Native_District ?? (object)DBNull.Value},
                new SqlParameter("@Native_LSProvinceID",SqlDbType.NVarChar,12){ Value = emp.Native_LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@LSEthnicID",SqlDbType.NVarChar,12){ Value = emp.LSEthnicID ?? (object)DBNull.Value},
                new SqlParameter("@IDNo",SqlDbType.VarChar,20){ Value = emp.IDNo ?? (object)DBNull.Value},
                new SqlParameter("@IDIssuedDate",SqlDbType.NVarChar,50){ Value = emp.IDIssuedDate ?? (object)DBNull.Value},
                new SqlParameter("@IDIssuedPlace",SqlDbType.NVarChar,12){ Value = emp.IDIssuedPlace ?? (object)DBNull.Value},
                new SqlParameter("@Mobifone",SqlDbType.NVarChar,30){ Value = emp.Mobifone ?? (object)DBNull.Value},
                new SqlParameter("@Telephone",SqlDbType.NVarChar,30){ Value = emp.Telephone ?? (object)DBNull.Value},
                new SqlParameter("@Email",SqlDbType.NVarChar,50){ Value = emp.Email ?? (object)DBNull.Value},
                new SqlParameter("@LSNationalityID",SqlDbType.NVarChar,12){ Value = emp.LSNationalityID ?? (object)DBNull.Value},
                new SqlParameter("@LSCultureLevelID",SqlDbType.NVarChar,12){ Value = emp.LSCultureLevelID ?? (object)DBNull.Value},
                new SqlParameter("@ScanCode",SqlDbType.NVarChar,20){ Value = emp.ScanCode ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = emp.Note ?? (object)DBNull.Value},
                new SqlParameter("@Creater",SqlDbType.NVarChar,12){ Value = emp.Creater ?? (object)DBNull.Value},
                new SqlParameter("@Editer",SqlDbType.NVarChar,12){ Value = emp.Editer ?? (object)DBNull.Value},
                new SqlParameter("@BankNo",SqlDbType.NVarChar,20){ Value = emp.BankNo ?? (object)DBNull.Value},
                new SqlParameter("@LSBankID",SqlDbType.NVarChar,12){ Value = emp.LSBankID ?? (object)DBNull.Value},
                new SqlParameter("@IsEmpBook",SqlDbType.Bit){ Value = emp.IsEmpBook.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsEmpCode",SqlDbType.Bit){ Value = emp.IsEmpCode.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsUniform",SqlDbType.Bit){ Value = emp.IsUniform.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsTrain",SqlDbType.Bit){ Value = emp.IsTrain.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Delete")
            };
            act.Generic("sp_InsertUpdateDelete_tblEmpCV", parameters);
            var redirectUrl = new UrlHelper(Request.RequestContext).Action("GetAllEmp", "Employee");
            return Json(new { Url = redirectUrl });
        }

        public ActionResult Details(Employee employee, string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            SqlParameter[] parameters =
            {
                new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = employee.EmpID ?? (object)DBNull.Value},
                new SqlParameter("@VLastName",SqlDbType.NVarChar,100){ Value = employee.VLastName ?? (object)DBNull.Value},
                new SqlParameter("@VFirstName",SqlDbType.NVarChar,100){ Value = employee.VFirstName ?? (object)DBNull.Value},
                new SqlParameter("@NickName",SqlDbType.NVarChar,50){ Value = employee.NickName ?? (object)DBNull.Value},
                new SqlParameter("@DOB",SqlDbType.NVarChar,50){ Value = employee.DOB ?? (object)DBNull.Value},
                new SqlParameter("@Gender",SqlDbType.NVarChar,1){ Value = employee.Gender ?? (object)DBNull.Value},
                new SqlParameter("@LSMaritalID",SqlDbType.NVarChar,12){ Value = employee.LSMaritalID ?? (object)DBNull.Value},
                new SqlParameter("@Born_District",SqlDbType.NVarChar,12){ Value = employee.Born_District ?? (object)DBNull.Value},
                new SqlParameter("@Born_LSProvinceID",SqlDbType.NVarChar,12){ Value = employee.Born_LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@Native_District",SqlDbType.NVarChar,12){ Value = employee.Native_District ?? (object)DBNull.Value},
                new SqlParameter("@Native_LSProvinceID",SqlDbType.NVarChar,12){ Value = employee.Native_LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@LSEthnicID",SqlDbType.NVarChar,12){ Value = employee.LSEthnicID ?? (object)DBNull.Value},
                new SqlParameter("@IDNo",SqlDbType.VarChar,20){ Value = employee.IDNo ?? (object)DBNull.Value},
                new SqlParameter("@IDIssuedDate",SqlDbType.NVarChar,50){ Value = employee.IDIssuedDate ?? (object)DBNull.Value},
                new SqlParameter("@IDIssuedPlace",SqlDbType.NVarChar,12){ Value = employee.IDIssuedPlace ?? (object)DBNull.Value},
                new SqlParameter("@Mobifone",SqlDbType.NVarChar,30){ Value = employee.Mobifone ?? (object)DBNull.Value},
                new SqlParameter("@Telephone",SqlDbType.NVarChar,30){ Value = employee.Telephone ?? (object)DBNull.Value},
                new SqlParameter("@Email",SqlDbType.NVarChar,50){ Value = employee.Email ?? (object)DBNull.Value},
                new SqlParameter("@LSNationalityID",SqlDbType.NVarChar,12){ Value = employee.LSNationalityID ?? (object)DBNull.Value},
                new SqlParameter("@LSCultureLevelID",SqlDbType.NVarChar,12){ Value = employee.LSCultureLevelID ?? (object)DBNull.Value},
                new SqlParameter("@ScanCode",SqlDbType.NVarChar,20){ Value = employee.ScanCode ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = employee.Note ?? (object)DBNull.Value},
                new SqlParameter("@Creater",SqlDbType.NVarChar,12){ Value = employee.Creater ?? (object)DBNull.Value},
                new SqlParameter("@Editer",SqlDbType.NVarChar,12){ Value = employee.Editer ?? (object)DBNull.Value},
                new SqlParameter("@BankNo",SqlDbType.NVarChar,20){ Value = employee.BankNo ?? (object)DBNull.Value},
                new SqlParameter("@LSBankID",SqlDbType.NVarChar,12){ Value = employee.LSBankID ?? (object)DBNull.Value},
                new SqlParameter("@IsEmpBook",SqlDbType.Bit){ Value = employee.IsEmpBook.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsEmpCode",SqlDbType.Bit){ Value = employee.IsEmpCode.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsUniform",SqlDbType.Bit){ Value = employee.IsUniform.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@IsTrain",SqlDbType.Bit){ Value = employee.IsTrain.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","SelectByID")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblEmpCV", parameters);
            SqlParameter[] parameters1 =
            {
                 new SqlParameter("@EmpID",SqlDbType.NVarChar,12){ Value = employee.EmpID ?? (object)DBNull.Value},
                 new SqlParameter("@EmpCode",SqlDbType.NVarChar,15){ Value = employee.EmpCode ?? (object)DBNull.Value},
                 new SqlParameter("@EmpCodeOld",SqlDbType.NVarChar,15){ Value = employee.EmpCodeOld ?? (object)DBNull.Value},
                 new SqlParameter("@StartDate",SqlDbType.NVarChar,50){ Value = employee.StartDate ?? (object)DBNull.Value},
                 new SqlParameter("@LSCompanyID",SqlDbType.NVarChar,12){ Value = employee.LSCompanyID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLevel1ID",SqlDbType.NVarChar,12){ Value = employee.LSLevel1ID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLevel2ID",SqlDbType.NVarChar,12){ Value = employee.LSLevel2ID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLevel3ID",SqlDbType.NVarChar,12){ Value = employee.LSLevel3ID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLevel4ID",SqlDbType.NVarChar,12){ Value = employee.LSLevel4ID ?? (object)DBNull.Value},
                 new SqlParameter("@LSPositionID",SqlDbType.NVarChar,12){ Value = employee.LSPositionID ?? (object)DBNull.Value},
                 new SqlParameter("@LSJobTitleID",SqlDbType.NVarChar,12){ Value = employee.LSJobTitleID ?? (object)DBNull.Value},
                 new SqlParameter("@LSLocationID",SqlDbType.NVarChar,12){ Value = employee.LSLocationID ?? (object)DBNull.Value},
                 new SqlParameter("@LSEmpTypeID",SqlDbType.NVarChar,12){ Value = employee.LSEmpTypeID ?? (object)DBNull.Value},
                 new SqlParameter("@Active",SqlDbType.Bit){ Value = employee.Active.ToString() ?? (object)DBNull.Value},
                 new SqlParameter("@ACTION","SelectByID")
            };
            DataSet ds1 = act.Generic("sp_InsertUpdateDelete_tblEmp", parameters1);
            ViewBag.emp = ds.Tables[0];
            ViewBag.emp1 = ds1.Tables[0];
            return View();
        }
    }
}
