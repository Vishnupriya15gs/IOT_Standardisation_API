using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plant_Digitization_api.Models
{
    public class Avl_Daywisereport
    {
        public string line { get; set; }
        public string Machine { get; set; }
        public string Month { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
    }

    public class Avl_weekwisereport
    {
        public string line { get; set; }
        public string Machine { get; set; }
        public string Month { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
    }

    public class Avl_shiftwisereport
    {
        public string line { get; set; }
        public string Machine { get; set; }
        public string Month { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
    }

    public class Avl_yearwisereport
    {
        public string line { get; set; }
        public string Machine { get; set; }
        public string Year { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
    }

    public class Avl_Breakdown
    {
        public string line { get; set; }
        public string Machine { get; set; }
        public string Fromdate { get; set; }
        public string Todate { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
    }

    public class Avl_weekBreakdown
    {
        public string line { get; set; }
        public string Machine { get; set; }
        public DateTime Date { get; set; }
        public Int32 WeekNo { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
    }

    public class Avl_shiftBreakdown
    {
        public string line { get; set; }
        public string Machine { get; set; }
        public string shift { get; set; }
        public string Fromdate { get; set; }
        public string Todate { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
    }

    public class Avl_custom
    {
        public string line { get; set; }
        public string Machine { get; set; }
        public string Fromdate { get; set; }
        public string Todate { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
    }

    //Live API

    public class Availability_Live
    {
        public string ShiftID { get; set; }
        public string Line_Code { get; set; }
        public string Machine_Code { get; set; }
        public string Machine_Status { get; set; }
        public string Variant_Code { get; set; }
        public decimal Avail { get; set; }
        public decimal UpTime { get; set; }
        public decimal DownTime { get; set; }
        public decimal LossTime { get; set; }
        public decimal Totaltime { get; set; }
        public DateTime lastupdate { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
    }
}
