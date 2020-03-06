using HRM.Core;
using HRM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HRM.Controllers
{
    public class Level1Controller : Controller
    {

            // GET: Level1
            public ActionResult Level1Manage()
            {
                return View();
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LSModel"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult LoadData(Level1Models LSModel)
        {
            GenericService act = new GenericService();
            SqlParameter[] parameters =
            {
                new SqlParameter("@Activity","GetData")
            };
            DataSet ds = act.Generic("LS_SPLevel1", parameters);

            var Object = ConvertDataTableToJSON(ds.Tables[0]);        

         
            return this.Json(Object, JsonRequestBehavior.AllowGet);
        }

        private static object ConvertDataTableToJSON(DataTable dt)
        {
            JavaScriptSerializer jSonString = new JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            string serialize = jSonString.Serialize(rows);
            var data = jSonString.Deserialize<IEnumerable<object>>(serialize);
            return data;

        }   
    }
}