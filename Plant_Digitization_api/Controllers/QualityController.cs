using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Plant_Digitization_api.Controllers
{
    //[EnableCors(origins: "http://localhost:55974", headers: "*", methods: "*")]

    public class QualityController : ApiController
    {
        private string connectionstring = ConfigurationManager.ConnectionStrings["con"].ToString();

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetRejection_Pareto_CustomReport(Models.Rejection_CustomReport rej)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(rej.CompanyCode, rej.PlantCode, rej.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Rejection_Pareto_CustomReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = rej.CompanyCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = rej.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = rej.Machine;
                    cmd.Parameters.Add("@FromDate", SqlDbType.DateTime, 150).Value = rej.FromDate;
                    cmd.Parameters.Add("@ToDate", SqlDbType.DateTime, 150).Value = rej.ToDate;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = rej.PlantCode;
                    cmd.Parameters.Add("@Variant", SqlDbType.NVarChar, 150).Value = rej.Variant;
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

        //Weekwise quality trends
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetRejection_Pareto_WeekwiseReport(Models.quality_week_wise Q)
        {
            try
            {
                database_connection d = new database_connection();
                string con_string = d.Getconnectionstring(Q.CompanyCode, Q.PlantCode, Q.line);
                if (con_string == "0")
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

                }
                else
                {

                    using (SqlConnection con = new SqlConnection(con_string))
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SP_Rejection_Pareto_WeekReport", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = Q.CompanyCode;
                        cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = Q.line;
                        cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = Q.Machine;
                        cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = Q.PlantCode;


                        cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 150).Value = Q.Date;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });

            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetRejection_Pareto_MonthwiseReport(Models.MTBF_MonthwiseReport mtbf)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(mtbf.CompanyCode, mtbf.PlantCode, mtbf.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Rejection_Pareto_MonthwiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = mtbf.CompanyCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = mtbf.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = mtbf.Machine;
                    cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 150).Value = mtbf.Year;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = mtbf.PlantCode;
                    cmd.Parameters.Add("@Variant", SqlDbType.NVarChar, 150).Value = mtbf.Variant;
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

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetRejection_Pareto_YearwiseReport(Models.MTBF_MonthwiseReport mtbf)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(mtbf.CompanyCode, mtbf.PlantCode, mtbf.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Rejection_Pareto_YearwiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = mtbf.CompanyCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = mtbf.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = mtbf.Machine;
                    cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 150).Value = mtbf.Year;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = mtbf.PlantCode;
                    cmd.Parameters.Add("@Variant", SqlDbType.NVarChar, 150).Value = mtbf.Variant;
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
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetRejection_Heatmap_CustomReport(Models.Rejection_CustomReport rej)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(rej.CompanyCode, rej.PlantCode, rej.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Rejection_HeatMap_CustomReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = rej.CompanyCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = rej.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = rej.Machine;
                    cmd.Parameters.Add("@FromDate", SqlDbType.DateTime, 150).Value = rej.FromDate;
                    cmd.Parameters.Add("@ToDate", SqlDbType.DateTime, 150).Value = rej.ToDate;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = rej.PlantCode;
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
       
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetRejection_Heatmap_YearwiseReport(Models.MTBF_MonthwiseReport mtbf)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(mtbf.CompanyCode, mtbf.PlantCode, mtbf.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Rejection_HeatMap_YearwiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = mtbf.CompanyCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = mtbf.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = mtbf.Machine;
                    cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 150).Value = mtbf.Year;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = mtbf.PlantCode;
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


        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetQuality_details(Models.live_report Q)
        {

            try
            {
                database_connection d = new database_connection();
                string con_string = d.Getconnectionstring(Q.CompanyCode, Q.PlantCode, Q.linecode);
                if (con_string == "0")
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

                }
                else
                {
                    using (SqlConnection con = new SqlConnection(con_string))
                    {

                        var result = new List<Models.live_report>();
                        var result1 = new List<Models.live_report>();
                        var endresult = new List<Models.live_report>();
                        con.Open();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SP_Live_QA_Rejection", con);
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = Q.CompanyCode;
                        cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = Q.PlantCode;
                        cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = Q.linecode;
                        cmd.Parameters.Add("@Machinecode", SqlDbType.NVarChar, 150).Value = Q.Machinecode;
                        cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = Q.Shift;
                        //var reader = cmd.ExecuteReader();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables.Count != 0)
                        {
                            //foreach (DataTable data in ds.Tables)
                            //{
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                result.Add(item: new Models.live_report
                                {
                                    //  last_rejection = Convert.ToString(reader["lastRejection"] == DBNull.Value ? "" : reader["lastRejection"]),
                                    mins_ago = Convert.ToString(dr["Mins_Ago"] == DBNull.Value ? "" : dr["Mins_Ago"]),
                                    components = Convert.ToString(dr["components"] == DBNull.Value ? "" : dr["components"]),
                                    no_of_times = Convert.ToString(dr["no_oftimes"] == DBNull.Value ? "" : dr["no_oftimes"]),
                                    continuous_rejection = Convert.ToString(dr["continuous_rejection"] == DBNull.Value ? "" : dr["continuous_rejection"]),
                                    batch = Convert.ToString(dr["batch"] == DBNull.Value ? "" : dr["batch"]),
                                    reason = Convert.ToString(dr["reason"] == DBNull.Value ? "" : dr["reason"]),

                                });
                            }

                            //}
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                result1.Add(item: new Models.live_report
                                {
                                    operator_name = Convert.ToString(dr["OperatorName"] == DBNull.Value ? "" : dr["OperatorName"]),
                                    ok_parts = Convert.ToString(dr["TotalOkParts"] == DBNull.Value ? "" : dr["TotalOkParts"]),
                                    not_parts = Convert.ToString(dr["TotalNOkParts"] == DBNull.Value ? "" : dr["TotalNOkParts"]),
                                    rework_parts = Convert.ToString(dr["TotalReworkParts"] == DBNull.Value ? "" : dr["TotalReworkParts"]),
                                    stime = Convert.ToString(dr["sTime"] == DBNull.Value ? "" : dr["sTime"]),
                                    ctime = Convert.ToString(dr["cTime"] == DBNull.Value ? "" : dr["cTime"]),
                                    target_qty = Convert.ToString(dr["target_qty"] == DBNull.Value ? "" : dr["target_qty"]),
                                    shift_id = Convert.ToString(dr["shift_id"] == DBNull.Value ? "" : dr["shift_id"]),
                                    no_of_stoppage = Convert.ToString(dr["no_of_stoppage"] == DBNull.Value ? "" : dr["no_of_stoppage"]),

                                });
                            }
                        }
                        endresult = result.Concat(result1).ToList();


                        if (endresult.Any())
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = endresult.ToArray() });
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetShiftId(Models.live_report Q)
        {
            try
            {
                database_connection d = new database_connection();
                string con_string = d.Getconnectionstring(Q.CompanyCode, Q.PlantCode, Q.linecode);
                if (con_string == "0")
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

                }
                else
                {
                    using (SqlConnection con = new SqlConnection(con_string))
                    {
                        string shiftname = "s2";
                        con.Open();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("select ShiftName from ShiftSetting where [CompanyCode] = @CompanyCode and[PlantCode] = @PlantCode and[LineCode] = @linecode and StartTime < Convert(Time, dateadd(mi, 330, getdate())) and EndTime > Convert(Time, dateadd(mi, 330, getdate()))", con);

                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = Q.CompanyCode;
                        cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = Q.PlantCode;
                        cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = Q.linecode;



                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        object r1 = cmd.ExecuteScalar();

                        if (r1 != null)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = r1.ToString() });
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" }); ;
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetShifts(Models.live_report Q)
        {

            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(Q.CompanyCode, Q.PlantCode, Q.linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    var result = new List<Models.quality_shift_wise>();
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("select ShiftName from ShiftSetting where CompanyCode = @CompanyCode and PlantCode = @PlantCode and LineCode = @linecode )", con);

                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = Q.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = Q.PlantCode;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = Q.linecode;

                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);


                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }

        }



        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetShiftwise_Quality(Models.quality_shift_wise Q)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(Q.CompanyCode, Q.PlantCode, Q.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    var result = new List<Models.quality_shift_wise>();
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Quality_ShiftwiseReportnew", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar, 150).Value = Q.QueryType;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = Q.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = Q.PlantCode;
                    cmd.Parameters.Add("@LineCode", SqlDbType.NVarChar, 150).Value = Q.line;
                    //cmd.Parameters.Add("@shift", SqlDbType.NVarChar, 150).Value = Q.shift;
                    //cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 150).Value = Q.Date;
                    cmd.Parameters.Add("@MachineCode", SqlDbType.NVarChar, 150).Value = Q.Machine;
                    //cmd.Parameters.Add("@Report_type", SqlDbType.NVarChar, 150).Value = Q.Report_type;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }

        }



        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetSpecific_Reason_hourly(Models.specific_reason_hourly S)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(S.CompanyCode, S.PlantCode, S.linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_SpecificReasonWise_Hourly", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = S.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = S.PlantCode;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = S.linecode;
                    cmd.Parameters.Add("@Machinecode", SqlDbType.NVarChar, 150).Value = S.Machinecode;
                    cmd.Parameters.Add("@shift", SqlDbType.NVarChar, 150).Value = S.shift;
                    cmd.Parameters.Add("@RejectReason", SqlDbType.NVarChar, 150).Value = S.RejectReason;
                    cmd.Parameters.Add("@Report_type", SqlDbType.NVarChar, 150).Value = S.Report_type;
                    cmd.Parameters.Add("@subassembly", SqlDbType.NVarChar, 150).Value = S.subassembly;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }

        }

        //Daywise Quality trends
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetDaywise_Quality(Models.quality_day_wise Q)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(Q.CompanyCode, Q.PlantCode, Q.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    var result = new List<Models.quality_day_wise>();
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Quality_DaywiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar, 150).Value = Q.QueryType;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = Q.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = Q.PlantCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = Q.line;
                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 150).Value = Q.Date;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = Q.Machine;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetSpecific_Reason_daywise(Models.specific_reason_daywise S)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(S.CompanyCode, S.PlantCode, S.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Specific_reason_DaywiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = S.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = S.PlantCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = S.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = S.Machine;
                    cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 150).Value = S.Reason;
                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 150).Value = S.Date;
                    cmd.Parameters.Add("@subassembly", SqlDbType.NVarChar, 150).Value = S.subassembly;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }
        }


        //Monthwise Quality trends
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetMonthwise_Quality(Models.quality_month_wise Q)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(Q.CompanyCode, Q.PlantCode, Q.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Quality_MonthwiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar, 150).Value = Q.QueryType;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = Q.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = Q.PlantCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = Q.line;
                    cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 150).Value = Q.Date;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = Q.Machine;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetSpecific_Reason_monthwise(Models.specific_reason_daywise S)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(S.CompanyCode, S.PlantCode, S.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Specific_reason_MonthwiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = S.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = S.PlantCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = S.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = S.Machine;
                    cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 150).Value = S.Reason;
                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 150).Value = S.Date;
                    cmd.Parameters.Add("@subassembly", SqlDbType.NVarChar, 150).Value = S.subassembly;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }

        }


        //Yearwise Quality trends
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetYearwise_Quality(Models.quality_year_wise Q)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(Q.CompanyCode, Q.PlantCode, Q.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Quality_YearwiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar, 150).Value = Q.QueryType;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = Q.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = Q.PlantCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = Q.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = Q.Machine;
                    cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 150).Value = Q.Date;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetSpecific_Reason_yearwise(Models.specific_reason_daywise S)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(S.CompanyCode, S.PlantCode, S.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Specific_reason_YearwiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = S.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = S.PlantCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = S.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = S.Machine;
                    cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 150).Value = S.Reason;
                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 150).Value = S.Date;
                    cmd.Parameters.Add("@subassembly", SqlDbType.NVarChar, 150).Value = S.subassembly;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }

        }

        //Custom quality trends
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetCustom_Quality(Models.quality_custom_wise Q)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(Q.CompanyCode, Q.PlantCode, Q.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Quality_CustomReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar, 150).Value = Q.QueryType;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = Q.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = Q.PlantCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = Q.line;
                    cmd.Parameters.Add("@FDate", SqlDbType.NVarChar, 150).Value = Q.FDate;
                    cmd.Parameters.Add("@TDate", SqlDbType.NVarChar, 150).Value = Q.TDate;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }

        }

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetSpecific_Reason_customwise(Models.specific_reason_custom S)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(S.CompanyCode, S.PlantCode, S.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Specific_reason_CustomReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = S.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = S.PlantCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = S.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = S.Machine;
                    cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 150).Value = S.Reason;
                    cmd.Parameters.Add("@FDate", SqlDbType.NVarChar, 150).Value = S.FDate;
                    cmd.Parameters.Add("@TDate", SqlDbType.NVarChar, 150).Value = S.TDate;
                    cmd.Parameters.Add("@subassembly", SqlDbType.NVarChar, 150).Value = S.subassembly;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }

        }


        //Weekwise quality trends
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetWeekwise_Quality(Models.quality_week_wise Q)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(Q.CompanyCode, Q.PlantCode, Q.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Quality_WeekwiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar, 150).Value = Q.QueryType;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = Q.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = Q.PlantCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = Q.line;
                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 150).Value = Q.Date;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetSpecific_Reason_weekwise(Models.specific_reason_daywise S)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(S.CompanyCode, S.PlantCode, S.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Specific_reason_WeekwiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = S.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = S.PlantCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = S.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = S.Machine;
                    cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 150).Value = S.Reason;
                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 150).Value = S.Date;
                    cmd.Parameters.Add("@subassembly", SqlDbType.NVarChar, 150).Value = S.subassembly;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }

        }


        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetSpecific_Reason_timestamp(Models.specific_timestamp S)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(S.CompanyCode, S.PlantCode, S.line);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Specific_reason_timestamp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = S.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = S.PlantCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = S.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = S.Machine;
                    cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 150).Value = S.Reason;
                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 150).Value = S.Date;
                    cmd.Parameters.Add("@Shift_id", SqlDbType.NVarChar, 150).Value = S.Shift_id;
                    cmd.Parameters.Add("@Report_type", SqlDbType.NVarChar, 150).Value = S.Report_type;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }

        }

        //Live API-1

        //live API-1
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetQualitylivedata(Models.Qualitylist list)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(list.CompanyCode, list.PlantCode, list.Linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Live_Productiondashboard", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = list.CompanyCode;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = list.Linecode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = list.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
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

        //2
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetCtHistogram(Models.ct_histogram list)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(list.CompanyCode, list.PlantCode, list.Linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_CycleTime_Histogram", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = list.CompanyCode;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = list.Linecode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = list.PlantCode;
                    cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = list.ShiftID;
                    cmd.Parameters.Add("@Machinecode", SqlDbType.NVarChar, 150).Value = list.Machine_Code;
                    cmd.CommandTimeout = 6000;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
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

        //3
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetPartsdetails(Models.ct_histogram list)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(list.CompanyCode, list.PlantCode, list.Linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Production_details", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = list.CompanyCode;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = list.Linecode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = list.PlantCode;
                    cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = list.ShiftID;
                    cmd.Parameters.Add("@Machinecode", SqlDbType.NVarChar, 150).Value = list.Machine_Code;
                    cmd.Parameters.Add("@Flag", SqlDbType.NVarChar, 150).Value = list.Flag;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();

                    if (ds.Tables.Count != 0)
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

        //4
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetLossdetails(Models.ct_histogram list)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(list.CompanyCode, list.PlantCode, list.Linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Production_Reasons", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = list.CompanyCode;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = list.Linecode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = list.PlantCode;
                    cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = list.ShiftID.ToString();
                    cmd.Parameters.Add("@Machinecode", SqlDbType.NVarChar, 150).Value = list.Machine_Code;
                    cmd.Parameters.Add("@Flag", SqlDbType.NVarChar, 150).Value = list.Flag;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
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

        //5
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage downtimegraph_details(Models.ct_histogram list)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(list.CompanyCode, list.PlantCode, list.Linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    DataTable dt_Sorted = new DataTable();
                    SqlCommand cmd = new SqlCommand("SP_Production_Reasons", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = list.CompanyCode;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = list.Linecode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = list.PlantCode;
                    cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = list.ShiftID;
                    cmd.Parameters.Add("@Machinecode", SqlDbType.NVarChar, 150).Value = list.Machine_Code;
                    cmd.Parameters.Add("@Flag", SqlDbType.NVarChar, 150).Value = list.Flag;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                    foreach (DataTable table in ds.Tables)
                    {
                        //foreach (DataRow dr in table.Rows)
                        //{
                        //    var res = dr["Downtime_Reason"];

                        //}
                        var result = table.AsEnumerable().GroupBy(dr => dr.Field<string>("Downtime_Reason")).Select(group => new { Datevalue = group.Key, Count = group.Sum(col => col.Field<decimal>("Duration_In_Sec")) });

                        dt_Sorted = table.Clone();
                        foreach (var grp in result)
                        {
                            var n1 = grp.Count;
                            dt_Sorted.Rows.Add(grp.Datevalue, "", "", grp.Count);
                        }

                    }

                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = dt_Sorted });

                }
            }

        }

        //6
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage losetimegraph_details(Models.ct_histogram list)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(list.CompanyCode, list.PlantCode, list.Linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    DataTable dt_Sorted = new DataTable();
                    SqlCommand cmd = new SqlCommand("SP_Production_Reasons", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = list.CompanyCode;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = list.Linecode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = list.PlantCode;
                    cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = list.ShiftID;
                    cmd.Parameters.Add("@Machinecode", SqlDbType.NVarChar, 150).Value = list.Machine_Code;
                    cmd.Parameters.Add("@Flag", SqlDbType.NVarChar, 150).Value = list.Flag;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                    foreach (DataTable table in ds.Tables)
                    {
                        //foreach (DataRow dr in table.Rows)
                        //{
                        //    var res = dr["Downtime_Reason"];

                        //}
                        var result = table.AsEnumerable().GroupBy(dr => dr.Field<string>("Downtime_Reason")).Select(group => new { Datevalue = group.Key, Count = group.Sum(col => col.Field<decimal>("Duration_In_Sec")) });

                        dt_Sorted = table.Clone();
                        decimal sum = 0;
                        foreach (var grp in result)
                        {
                            sum = sum + grp.Count;
                            //var n1 = grp.Count;
                            //dt_Sorted.Rows.Add(grp.Datevalue, "", "", grp.Count);
                        }
                        foreach (var grp in result)
                        {
                            var temp1 = (grp.Count / sum);
                            var temp = temp1 * 100;
                            var n1 = grp.Count;
                            dt_Sorted.Rows.Add(grp.Datevalue, Math.Round(temp, 0), sum, grp.Count);
                        }
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = dt_Sorted });

                }
            }

        }

        //7
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetTop_Breakup(Models.ct_histogram list)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(list.CompanyCode, list.PlantCode, list.Linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Productiondasboard_AlarmBreakup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = list.CompanyCode;
                    cmd.Parameters.Add("@line_code", SqlDbType.NVarChar, 150).Value = list.Linecode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = list.PlantCode;
                    cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = list.ShiftID;
                    cmd.Parameters.Add("@Machine_code", SqlDbType.NVarChar, 150).Value = list.Machine_Code;
                    cmd.Parameters.Add("@Flag", SqlDbType.NVarChar, 150).Value = list.Flag;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
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

        //8
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage Gettarget_count(Models.target_live list)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(list.CompanyCode, list.PlantCode, list.Linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string date = DateTime.Now.ToString("yyyy-MM-dd");

                    con.Open();
                    int count = 0;
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(@"SELECT [TargetProduction] FROM dbo.tbl_Production_setting WHERE CompanyCode='" + list.CompanyCode + "' AND PlantCode='" + list.PlantCode + "' AND Line_code='" + list.Linecode + "'AND Productname='" + list.variant + "'AND Shift_id='" + list.ShiftID + "'and '" + date + "' between fromdate and todate ", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    object ret = cmd.ExecuteScalar();
                    if (ret != null)
                    {
                        count = (int)cmd.ExecuteScalar();
                    }

                    else
                    {
                        count = 0;
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = count });


                }
            }
        }

        //9
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage Getmachine_status(Models.ct_histogram list)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(list.CompanyCode, list.PlantCode, list.Linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                var messages = new List<Models.status_bar>();

                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Live_Bargraph_Batchwise", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 60000;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = list.CompanyCode;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = list.Linecode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = list.PlantCode;
                    cmd.Parameters.Add("@Machinecode", SqlDbType.NVarChar, 150).Value = list.Machine_Code;
                    cmd.Parameters.Add("@Batch", SqlDbType.NVarChar, 150).Value = list.Batch;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    var reader = cmd.ExecuteReader();
                    var color = "";
                    while (reader.Read())
                    {
                        if (reader["machine_status"].ToString() == "0")
                        {
                            color = "rgb(244,67,54)"; //red

                        }
                        if (reader["machine_status"].ToString().ToString() == "2")
                        {
                            color = "rgb(243,224,58)"; //orange

                        }
                        if (reader["machine_status"].ToString().ToString() == "1")
                        {
                            color = "rgb(76,175,80)"; //green
                        }
                        if (reader["machine_status"].ToString().ToString() == "3")
                        {
                            color = "rgb(255,191,0)"; //yellow
                        }
                        if (reader["machine_status"].ToString().ToString() == "5")
                        {
                            color = "rgb(187,187,187)"; //grey
                        }
                        if (reader["machine_status"].ToString().ToString() == "4")
                        {
                            color = "rgb(61,133,198)"; //lightblue
                        }

                        messages.Add(item: new Models.status_bar
                        {
                            ShiftID = Convert.ToString(reader["Shift_ID"] == DBNull.Value ? "" : reader["Shift_ID"]),
                            Machine_Code = Convert.ToString(reader["Machine_Code"] == DBNull.Value ? "" : reader["Machine_Code"]),
                            Linecode = Convert.ToString(reader["line_code"] == DBNull.Value ? "" : reader["line_code"]),
                            CompanyCode = Convert.ToString(reader["companycode"] == DBNull.Value ? "" : reader["companycode"]),
                            PlantCode = Convert.ToString(reader["plantcode"] == DBNull.Value ? "" : reader["plantcode"]),
                            color = color,
                            starting_time = Convert.ToDateTime(reader["Start"]).ToString(new CultureInfo("en-US")),
                            ending_time = Convert.ToDateTime(reader["end"]).ToString(new CultureInfo("en-US")),
                            Batch_code = Convert.ToString(reader["Batch_code"] == DBNull.Value ? "" : reader["Batch_code"]),
                            Duration = Convert.ToString(reader["Duration"] == DBNull.Value ? "" : reader["Duration"])
                            //Alarm = Convert.ToString(reader["plantcode"] == DBNull.Value ? "" : reader["Alarm"]),
                            //Loss = Convert.ToString(reader["plantcode"] == DBNull.Value ? "" : reader["Loss"]),
                            //starting_time = Convert.ToDateTime(reader["Start"]).ToString("hh:mm:ss"),
                            //ending_time = Convert.ToDateTime(reader["end"]).ToString("hh:mm:ss"),



                        });
                    }
                    con.Close();



                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = messages });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                    // return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = count });



                }
            }
        }

        //10

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage getmachine_code(Models.Qualitylist list)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(list.CompanyCode, list.PlantCode, list.Linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string date = DateTime.Now.ToString("yyyy-MM-dd");

                    con.Open();

                    DataSet ds = new DataSet();
                    SqlCommand command = new SqlCommand("select Machine_code as AssetID from tbl_batchwise_live_data where companycode=@CompanyCode and Plantcode=@PlantCode and linecode=@Line_code and date=@date group by len(machine_code), machine_code", con);


                    command.Parameters.AddWithValue("@CompanyCode", list.CompanyCode);
                    command.Parameters.AddWithValue("@PlantCode", list.PlantCode);
                    command.Parameters.AddWithValue("@Line_code", list.Linecode);
                    command.Parameters.AddWithValue("@date", date);
                    // SqlCommand cmd = new SqlCommand(@"SELECT ID as id,Shift_Id as Shift_ID,Line_COde as Line_Code,Productname as  Product_Name,TargetProduction as target_production,Fromdate as fromdate,Todate as todate FROM dbo.tbl_Production_setting WHERE CompanyCode='" + U.Parameter1 + "' AND PlantCode='" + U.Parameter + "'And id='" + U.QueryType + "'  ", con);
                    SqlDataAdapter da = new SqlDataAdapter(command);

                    da.Fill(ds);
                    if (ds.Tables.Count != 0)
                    {
                        // return Ok(ds.Tables[0]);
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });
                    }

                    //return Ok(new String[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });


                }
            }
        }

        //11
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage getrejectiondetails(Models.rejection list)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(list.CompanyCode, list.PlantCode, list.Linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string date = DateTime.Now.ToString("yyyy-MM-dd");

                    con.Open();

                    DataSet ds = new DataSet();
                    SqlCommand command = new SqlCommand("select c.time_stamp as Timestamp,r.rejectiondescription as Reject_Reason   from cycletime c inner join tbl_rejection r   on convert(date, c.time_stamp) = @date  and c.reject_reason <> 'Null' and c.reject_reason <> '' and c.reject_reason is Not Null and c.plantcode = @plantcode and c.companycode = @CompanyCode and c.line_code = @Line_code and c.variant_code = @variantcode and c.machine_code = @machine and c.shift_id = @shift order by time_stamp", con);


                    command.Parameters.AddWithValue("@CompanyCode", list.CompanyCode);
                    command.Parameters.AddWithValue("@PlantCode", list.PlantCode);
                    command.Parameters.AddWithValue("@Line_code", list.Linecode);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@variantcode", list.variantcode);
                    command.Parameters.AddWithValue("@machine", list.Machine_Code);
                    command.Parameters.AddWithValue("@shift", list.ShiftID);
                    command.CommandTimeout = 600;
                    // SqlCommand cmd = new SqlCommand(@"SELECT ID as id,Shift_Id as Shift_ID,Line_COde as Line_Code,Productname as  Product_Name,TargetProduction as target_production,Fromdate as fromdate,Todate as todate FROM dbo.tbl_Production_setting WHERE CompanyCode='" + U.Parameter1 + "' AND PlantCode='" + U.Parameter + "'And id='" + U.QueryType + "'  ", con);
                    SqlDataAdapter da = new SqlDataAdapter(command);

                    da.Fill(ds);
                    if (ds.Tables.Count != 0)
                    {
                        // return Ok(ds.Tables[0]);
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });
                    }

                    //return Ok(new String[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });


                }
            }
        }

        //12
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage Gettarget_cycletime(Models.target_cycletime list)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(list.CompanyCode, list.PlantCode, list.Linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    //string date = DateTime.Now.ToString("yyyy-MM-dd");

                    con.Open();
                    decimal count = 0;
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(@"SELECT cycletime FROM tbl_MasterProduct WHERE CompanyCode=@CompanyCode  AND PlantCode=@PlantCode AND Line_code=@Line_code AND Variant_code=@variant and machine_code=@Machine_Code ", con);
                    cmd.Parameters.AddWithValue("@CompanyCode", list.CompanyCode);
                    cmd.Parameters.AddWithValue("@PlantCode", list.PlantCode);
                    cmd.Parameters.AddWithValue("@Line_code", list.Linecode);
                    cmd.Parameters.AddWithValue("@variant", list.variant);
                    cmd.Parameters.AddWithValue("@Machine_Code", list.Machine_Code);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    object ret = cmd.ExecuteScalar();
                    if (ret != null)
                    {
                        count = (decimal)cmd.ExecuteScalar();
                    }

                    else
                    {
                        count = 0;
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = count });


                }
            }
        }

        //13
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage Gettarget_cycletime1(Models.target_cycletime list)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(list.CompanyCode, list.PlantCode, list.Linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    //string date = DateTime.Now.ToString("yyyy-MM-dd");

                    con.Open();
                    decimal count = 0;
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(@"SELECT cycletime,auto_cycletime,manual_cycletime FROM tbl_MasterProduct WHERE CompanyCode=@CompanyCode  AND PlantCode=@PlantCode AND Line_code=@Line_code AND Variant_code=@variant and machine_code=@Machine_Code ", con);
                    cmd.Parameters.AddWithValue("@CompanyCode", list.CompanyCode);
                    cmd.Parameters.AddWithValue("@PlantCode", list.PlantCode);
                    cmd.Parameters.AddWithValue("@Line_code", list.Linecode);
                    cmd.Parameters.AddWithValue("@variant", list.variant);
                    cmd.Parameters.AddWithValue("@Machine_Code", list.Machine_Code);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables.Count != 0)
                    {
                        // return Ok(ds.Tables[0]);
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });
                    }

                    //return Ok(new String[0]);
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });
                }
            }
        }

        //14
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetStoppageReason(Models.stoppage_reason list)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(list.CompanyCode, list.PlantCode, list.Linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand(@"select Live_Alarm,Live_Loss from tbl_ProductionCount_live where machine_code=@Machinecode and CompanyCode=@CompanyCode and PlantCode=@PlantCode and Linecode=@linecode and Variantcode=@Variantcode and ShiftID=@Shift  and substring(batch_code,2,len(batch_code))=(select Max(substring(batch_code,2,len(batch_code))) from [dbo].[tbl_ProductionCount_live] where machine_code=@Machinecode and CompanyCode=@CompanyCode and PlantCode=@PlantCode and Linecode=@linecode and Variantcode=@Variantcode and ShiftID=@Shift ) ", con);

                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = list.CompanyCode;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = list.Linecode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = list.PlantCode;
                    cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = list.ShiftID;
                    cmd.Parameters.Add("@Variantcode", SqlDbType.NVarChar, 150).Value = list.Variantcode;
                    cmd.Parameters.Add("@Machinecode", SqlDbType.NVarChar, 150).Value = list.Machine_Code;
                    cmd.CommandTimeout = 6000;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
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

        //15
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetQualitylivedataMachinewise(Models.Qualitylist list)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(list.CompanyCode, list.PlantCode, list.Linecode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Live_Productiondashboard_Machinewise", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = list.CompanyCode;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = list.Linecode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = list.PlantCode;
                    cmd.Parameters.Add("@MachineCode", SqlDbType.NVarChar, 150).Value = list.Machine_Code;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
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
