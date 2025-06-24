using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net;
using PlanDigitization_api.Models;
using System.Data.SqlClient;
using System.Data;
using System.Web.Http;
using Plant_Digitization_api.Controllers;
using Plant_Digitization_api;

namespace PlanDigitization_api.Controllers
{
    public class LineOverView_QualityController : ApiController
    {
        // GET: LineOverView_Quality
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage DPRDaily(Models.DrpDailyModel testmodel)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(testmodel.CompanyCode, testmodel.PlantCode, testmodel.LineCode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Couldn't Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string response = string.Empty;
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_DPR_QualityDashboard", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@Shift_Id", SqlDbType.NVarChar, 150).Value = testmodel.ShiftId;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = testmodel.LineCode;
                    cmd.Parameters.Add("@Machine_Code", SqlDbType.NVarChar, 150).Value = testmodel.MachineCode;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = testmodel.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = testmodel.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }
        }

        public HttpResponseMessage DPR_Pie(DrpDailyModel testmodel)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(testmodel.CompanyCode, testmodel.PlantCode, testmodel.LineCode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Couldn't Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string response = string.Empty;
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_DPR_OVERALL_PIE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@Shift_Id", SqlDbType.NVarChar, 150).Value = testmodel.ShiftId;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = testmodel.LineCode;
                    cmd.Parameters.Add("@Machine_Code", SqlDbType.NVarChar, 150).Value = testmodel.MachineCode;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = testmodel.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = testmodel.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }
        }


        public HttpResponseMessage RejCategory_Pie(DrpDailyModel testmodel)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(testmodel.CompanyCode, testmodel.PlantCode, testmodel.LineCode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Couldn't Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string response = string.Empty;
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_DPR_REJ_CATEGORY_PIE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@Shift_Id", SqlDbType.NVarChar, 150).Value = testmodel.ShiftId;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = testmodel.LineCode;
                    cmd.Parameters.Add("@Machine_Code", SqlDbType.NVarChar, 150).Value = testmodel.MachineCode;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = testmodel.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = testmodel.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }
        }

        public HttpResponseMessage ReworkPareto_Custom(Models.DrpDailyModel testmodel)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(testmodel.CompanyCode, testmodel.PlantCode, testmodel.LineCode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Couldn't Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string response = string.Empty;
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Rework_Pareto_Custom", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@Shift_Id", SqlDbType.NVarChar, 150).Value = testmodel.ShiftId;
                    cmd.Parameters.Add("@FDate", SqlDbType.Date).Value = testmodel.FromDate;
                    cmd.Parameters.Add("@TDate", SqlDbType.Date).Value = testmodel.ToDate;
                    //cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = testmodel.LineCode;
                    //cmd.Parameters.Add("@Machine_Code", SqlDbType.NVarChar, 150).Value = testmodel.MachineCode;
                    //cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = testmodel.CompanyCode;
                    //cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = testmodel.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }
        }

        public HttpResponseMessage ReworkPareto_Monthly(Models.DrpDailyModel testmodel)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(testmodel.CompanyCode, testmodel.PlantCode, testmodel.LineCode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Couldn't Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string response = string.Empty;
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Rework_Pareto_Monthly", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@Shift_Id", SqlDbType.NVarChar, 150).Value = testmodel.ShiftId;
                    cmd.Parameters.Add("@month", SqlDbType.Int).Value = testmodel.Month;
                    //cmd.Parameters.Add("@Machine_Code", SqlDbType.NVarChar, 150).Value = testmodel.MachineCode;
                    //cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = testmodel.CompanyCode;
                    //cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = testmodel.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }
        }

        public HttpResponseMessage SP_CalculateDeviceMetrics(DrpDailyModel testmodel)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(testmodel.CompanyCode, testmodel.PlantCode, testmodel.LineCode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Couldn't Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string response = string.Empty;
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_CalculateDeviceMetrics", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    //cmd.Parameters.Add("@Shift_Id", SqlDbType.NVarChar, 150).Value = testmodel.ShiftId;
                    //cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = testmodel.LineCode;
                    //cmd.Parameters.Add("@Machine_Code", SqlDbType.NVarChar, 150).Value = testmodel.MachineCode;
                    //cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = testmodel.CompanyCode;
                    //cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = testmodel.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }
        }

        public HttpResponseMessage CategoryPareto_Custom(Models.DrpDailyModel testmodel)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(testmodel.CompanyCode, testmodel.PlantCode, testmodel.LineCode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Couldn't Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string response = string.Empty;
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Category_Pareto_Custom", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@Shift_Id", SqlDbType.NVarChar, 150).Value = testmodel.ShiftId;
                    cmd.Parameters.Add("@FDate", SqlDbType.DateTime).Value = testmodel.FromDate;
                    cmd.Parameters.Add("@TDate", SqlDbType.DateTime).Value = testmodel.ToDate;
                    //cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = testmodel.LineCode;
                    //cmd.Parameters.Add("@Machine_Code", SqlDbType.NVarChar, 150).Value = testmodel.MachineCode;
                    //cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = testmodel.CompanyCode;
                    //cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = testmodel.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }
        }

        public HttpResponseMessage CategoryPareto_Monthly(Models.DrpDailyModel testmodel)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(testmodel.CompanyCode, testmodel.PlantCode, testmodel.LineCode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Couldn't Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string response = string.Empty;
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Category_Pareto_Monthly", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@shift_id", SqlDbType.NVarChar, 150).Value = testmodel.ShiftId;
                    cmd.Parameters.Add("@month", SqlDbType.Int).Value = testmodel.Month;
                    //cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = testmodel.LineCode;
                    //cmd.Parameters.Add("@Machine_Code", SqlDbType.NVarChar, 150).Value = testmodel.MachineCode;
                    //cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = testmodel.CompanyCode;
                    //cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = testmodel.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }
        }
    }

}