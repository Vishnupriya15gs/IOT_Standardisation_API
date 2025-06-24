using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plant_Digitization_api.Models
{
    public class Toollife
    {
        public string linename { get; set; }
        public string subsystem { get; set; }
        public string element { get; set; }
        public string make { get; set; }
        public string partnumber { get; set; }
        public string classification { get; set; }
        public string isreplaced { get; set; }
        public Int32 noofreplace { get; set; }
        public decimal currentusage { get; set; }
        public string remarks { get; set; }
        public string uom { get; set; }
        public string lastmain { get; set; }
        public string Flag { get; set; }
        public string ToolID { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string Rectext { get; set; }
        public string SerialNo { get; set; }
        public string Status { get; set; }
        public string ratedlifecle { get; set; }
        public string lifeatpm { get; set; }

    }

    public class historical
    {
        public string linename { get; set; }
        public string subsystem { get; set; }
        public string element { get; set; }
        public string make { get; set; }
        public string partnumber { get; set; }
        public string classification { get; set; }
        public string conversionparameter { get; set; }
        public decimal currentlifecycle { get; set; }
        public decimal ratedlife { get; set; }
        public string uom { get; set; }
        public decimal usage { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
        public string Flag { get; set; }
        public string lastmain { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string RecText { get; set; }
        public string SerialNo { get; set; }
        public string lifeatpm { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string PM_count { get; set; }
        public string ToolID { get; set; }
    }

    public class Toollifelive
    {
        public string linename { get; set; }
        public string subsystem { get; set; }
        public string element { get; set; }
        public string make { get; set; }
        public string partnumber { get; set; }
        public string classification { get; set; }
        public string conversionparameter { get; set; }
        public decimal currentlifecycle { get; set; }
        public decimal ratedlife { get; set; }
        public string uom { get; set; }
        public decimal usage { get; set; }
        public string lastmain { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }

    }

    public class SettingData
    {
        public string HashId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string LineCode { get; set; }
        public string MachineCode { get; set; }
        public string Parameter { get; set; }
    }
    public class SettingData_Variable
    {
        public string HashId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string LineCode { get; set; }
        public string MachineCode { get; set; }
        public string Parameter { get; set; }
    }
    public class SettingData2
    {
        public string HashId { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public string Flag { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string LineCode { get; set; }
        public string MachineCode { get; set; }
    }
    public class maintenance
    {
        public string ToolID { get; set; }
        public DateTime LastMaintenaceDate { get; set; }
        public string IsReplaced { get; set; }
        public Int32 No_of_Replacements { get; set; }
        public decimal Currentusage { get; set; }
        public string Remarks { get; set; }
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string LineCode { get; set; }
        public string Status { get; set; }
        public string NSerialNo { get; set; }
        public string SerialNo { get; set; }
        public string RecText { get; set; }
        public string lastmain { get; set; }
    }

    //Live 

    public class ToolLifelive
    {
        public string Line_code { get; set; }
        public string ToolName { get; set; }
        public string ToolID { get; set; }
        public string Make { get; set; }
        public string UOM { get; set; }
        public string Part_number { get; set; }
        public string Classification { get; set; }
        public decimal ratedlifecle { get; set; }//
        public string Machine_code { get; set; }
        public string Conversion_parameter { get; set; }
        public decimal currentlifecle { get; set; }
        public string lastmain { get; set; }
        public decimal usage { get; set; }//
        public string CompanyCode { get; set; }
        public string PlantCode { get; set; }
        public string line_name { get; set; }
        public string RecText { get; set; }// asset //mc code
        public string Status { get; set; }
        public string Next_PM { get; set; }

    }


}