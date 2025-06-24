using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanDigitization_api.Models
{
    public class LineOverviewProd
    {

    }
    public class eolProd
    {
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string Line_Code { get; set; }
        public string Shift { get; set; }
        public string Date { get; set; }
    }
}