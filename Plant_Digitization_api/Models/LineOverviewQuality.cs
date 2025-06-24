using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanDigitization_api.Models
{
    public class DrpDailyModel
    {

        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string LineCode { get; set; }
        public string ShiftId { get; set; }
        public string MachineCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Month { get; set; }

    }
}
