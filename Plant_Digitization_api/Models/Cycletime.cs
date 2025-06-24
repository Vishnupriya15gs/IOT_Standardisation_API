using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plant_Digitization_api.Models
{
    public class Cycletime
    {
    }
    public class CycleTime_Live
    {
        public string QueryType { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string Line { get; set; }
        public string Machine { get; set; }
        public string records { get; set; }
    }

    public class CycleTime_Histogram
    {
        public string QueryType { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string Line { get; set; }
        public string Machine { get; set; }
        public string Date { get; set; }
        public string FDate { get; set; }
        public string TDate { get; set; }
        public string Variant { get; set; }
        public string Shift { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Operation { get; set; }
        public string offset { get; set; }
        public string percentage { get; set; }

        public string Count { get; set; }
    }

    public class CycleTime_Average
    {
        public string QueryType { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string Line { get; set; }
        public string Machine { get; set; }
        public string Date { get; set; }
        public string FDate { get; set; }
        public string TDate { get; set; }
        public string Variant { get; set; }
        public string Shift { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
    }


    public class CycleTime_Partwise
    {
        public string QueryType { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string Line { get; set; }
        public string Machine { get; set; }
        public string Date { get; set; }
        public string FTime { get; set; }
        public string TTime { get; set; }
        public string Variant { get; set; }
    }

    public class Cycletime_setting
    {
        public string QueryType { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string Line_Code { get; set; }
        public string Machine { get; set; }
        public string Variant { get; set; }
        public string Movement { get; set; }
        public string Type { get; set; }
        public string Cycle_time { get; set; }
        public string ID { get; set; }
        public string Status { get; set; }

        public string if_applicable { get; set; }
    }



    //Live API Models
    public class ct_histogram
    {
        public string Machine_Code { get; set; }
        public string Linecode { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string ShiftID { get; set; }
        public int Occurence { get; set; }
        public decimal cycletime { get; set; }
        public string Flag { get; set; }
        public string Batch { get; set; }

    }

    public class target_live
    {

        public string Linecode { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string ShiftID { get; set; }
        public DateTime Date { get; set; }
        public string variant { get; set; }


    }

    public class status_bar
    {
        public string Machine_Code { get; set; }
        public string Linecode { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string ShiftID { get; set; }
        public string color { get; set; }
        public string starting_time { get; set; }
        public string ending_time { get; set; }
        public string Duration { get; set; }
        public string Loss { get; set; }
        public string Alarm { get; set; }
        public string Batch_code { get; set; }

    }

    public class rejection
    {
        public string Machine_Code { get; set; }
        public string Linecode { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string ShiftID { get; set; }


        public string variantcode { get; set; }
    }

    public class target_cycletime
    {

        public string Linecode { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string Machine_Code { get; set; }
        public string variant { get; set; }


    }

    public class stoppage_reason
    {
        public string Machine_Code { get; set; }
        public string Linecode { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string ShiftID { get; set; }
        public string Variantcode { get; set; }
    }
}