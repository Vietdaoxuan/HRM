using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class LSCompanyModel
    {
        public string LSCompanyID { get; set; }

        public string LSCompanyCode { get; set; }

        public string ShortName { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public int Rank { get; set; }

        public string Note { get; set; }

        public int Used { get; set; }

        public string WorkingPlace { get; set; }

        public string Creater { get; set; }

        public string CreateTime { get; set; }

        public string Editer { get; set; }

        public string EditTime { get; set; }
    }
}