using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http.Cors;

namespace Plant_Digitization_api.Controllers
{
    //[EnableCors(origins: "http://localhost:55974", headers: "*", methods: "*")]

    public class OEEController : ApiController
    {
        private string connectionstring = ConfigurationManager.ConnectionStrings["con"].ToString();
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetOEEDaywise(Models.OEE_Daywisereport oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.line);
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
                    SqlCommand cmd = new SqlCommand("SP_OEE_DaywiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = oee.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = oee.Machine;
                    cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 150).Value = oee.Year;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds.Tables[0] });
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
        public HttpResponseMessage GetOEEweekwise(Models.OEE_weekwisereport oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.line);
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
                    SqlCommand cmd = new SqlCommand("SP_OEE_WeekwiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = oee.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = oee.Machine;
                    cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 150).Value = oee.Year;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds.Tables[0] });
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
        public HttpResponseMessage GetOEEshiftwise(Models.OEE_shiftwisereport oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.line);
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
                    SqlCommand cmd = new SqlCommand("SP_OEE_ShiftwiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = oee.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = oee.Machine;
                    cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 150).Value = oee.Year;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds.Tables[0] });
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
        public HttpResponseMessage GetOEEyearwise(Models.OEE_yearwisereport oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.line);
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
                    SqlCommand cmd = new SqlCommand("SP_OEE_YearwiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = oee.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = oee.Machine;
                    cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 150).Value = oee.Year;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds.Tables[0] });
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
        public HttpResponseMessage GetOEEBreakdown(Models.OEE_Breakdown oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.line);
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
                    SqlCommand cmd = new SqlCommand("SP_OEE_Breakdown", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = oee.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = oee.Machine;
                    cmd.Parameters.Add("@Fromdate", SqlDbType.Date, 150).Value = oee.Fromdate;
                    cmd.Parameters.Add("@Todate", SqlDbType.Date, 150).Value = oee.Todate;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds.Tables[0] });
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
        public HttpResponseMessage GetOEEweekBreakdown(Models.OEE_weekBreakdown oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.line);
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
                    SqlCommand cmd = new SqlCommand("SP_OEE_Week_Breakdown", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = oee.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = oee.Machine;
                    cmd.Parameters.Add("@Date", SqlDbType.Date, 150).Value = oee.Date;
                    cmd.Parameters.Add("@WeekNo", SqlDbType.NVarChar, 150).Value = oee.WeekNo;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds.Tables[0] });
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
        public HttpResponseMessage GetOEEshiftkBreakdown(Models.OEE_shiftBreakdown oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.line);
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
                    SqlCommand cmd = new SqlCommand("SP_OEE_Shift_Breakdown", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = oee.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = oee.Machine;
                    cmd.Parameters.Add("@Fromdate", SqlDbType.Date, 150).Value = oee.Fromdate;
                    cmd.Parameters.Add("@shift", SqlDbType.NVarChar, 150).Value = oee.shift;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds.Tables[0] });
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
        public HttpResponseMessage GetOEEcustomreport(Models.OEE_custom oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.line);
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
                    SqlCommand cmd = new SqlCommand("SP_OEE_CustomReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = oee.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = oee.Machine;
                    cmd.Parameters.Add("@Fromdate", SqlDbType.Date, 150).Value = oee.Fromdate;
                    cmd.Parameters.Add("@Todate", SqlDbType.Date, 150).Value = oee.Todate;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds.Tables[0] });
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
        public HttpResponseMessage ShiftwiseOEE(Models.OEE_custom oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.line);
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
                    SqlCommand cmd = new SqlCommand("SP_Shiftwise_Batch_Cumulation_OEE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@machinecode", SqlDbType.NVarChar, 150).Value = oee.Machine;
                    cmd.Parameters.Add("@fromdate", SqlDbType.Date, 150).Value = oee.Fromdate;
                    cmd.Parameters.Add("@todate", SqlDbType.Date, 150).Value = oee.Todate;
                    cmd.Parameters.Add("@LineCode", SqlDbType.NVarChar, 150).Value = oee.line;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds.Tables[0] });
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
        public HttpResponseMessage MonthlyShiftwiseOEE(Models.OEE_custom oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.line);
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
                    SqlCommand cmd = new SqlCommand("SP_MonthlyShiftwise_Batch_Cumulation_OEE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@machinecode", SqlDbType.NVarChar, 150).Value = oee.Machine;
                    cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 150).Value = oee.Year;
                    cmd.Parameters.Add("@line_code", SqlDbType.NVarChar, 150).Value = oee.line;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds.Tables[0] });
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
        public HttpResponseMessage YearlyShiftwiseOEE(Models.OEE_custom oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.line);
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
                    SqlCommand cmd = new SqlCommand("SP_YearlyShiftwise_Batch_Cumulation_OEE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@machinecode", SqlDbType.NVarChar, 150).Value = oee.Machine;
                    cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 150).Value = oee.Year;
                    cmd.Parameters.Add("@line_code", SqlDbType.NVarChar, 150).Value = oee.line;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds.Tables[0] });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }
            }
        }

        //Live API-1

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetEmployee()
        {
            return Request.CreateResponse(HttpStatusCode.OK, value: "Successfully valid");
        }

        //2
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage check_holiday(Models.Holidaylive oee)
        {
            try
            {
                var messages = new List<Models.Holidaylive>();

                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();


                    SqlCommand cmd = new SqlCommand("SP_check_holiday_live", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.Add("@company", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;
                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 150).Value = DateTime.Today.ToString("yyyy-MM-dd");
                    cmd.Parameters.Add("@plant", SqlDbType.NVarChar, 150).Value = oee.PlantCode;


                    {
                        //command.Notification = null;
                        //var dependency = new SqlDependency(command);
                        //dependency.OnChange += new OnChangeEventHandler(oeelive);

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            messages.Add(item: new Models.Holidaylive
                            {

                                holiday_name = Convert.ToString(reader["HolidayReason"] == DBNull.Value ? "" : reader["HolidayReason"])

                            });
                        }
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = messages });
            }
            catch (Exception ex)
            {
                var exc = ex;
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Details Found", data = "" });
            }
        }

        //3

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetOEElivedata(Models.OEE_Live oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.Line_Code);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                var messages = new List<Models.OEE_Live>();
                using (var connection = new SqlConnection(con_string))
                {
                    connection.Open();
                    //using (var command = new SqlCommand(@"SELECT [Machine_Code]
                    //                                    ,[Availability]
                    //                                    ,[Performance]
                    //                                    ,[Quality]
                    //                                    ,[OEE]
                    //                                    FROM dbo.tbl_Live_OEE WHERE CompanyCode='" + oee.CompanyCode + "' AND PlantCode='" + oee.PlantCode + "' AND Line_Code='" + oee.Line_Code + "'  ", connection))

                    SqlCommand command = new SqlCommand("SELECT Shift_ID,Machine_Code,Availability,Performance,Quality,OEE,Machine_Status from dbo.tbl_Live_OEE where CompanyCode=@CompanyCode and PlantCode=@PlantCode and Line_Code=@Line_Code and Convert(Date,lastupdate)=@currentdate", connection);


                    command.Parameters.AddWithValue("@CompanyCode", oee.CompanyCode);
                    command.Parameters.AddWithValue("@PlantCode", oee.PlantCode);
                    command.Parameters.AddWithValue("@Line_Code", oee.Line_Code);
                    command.Parameters.AddWithValue("@currentdate", DateTime.Now.ToString("yyyy/MM/dd"));

                    {
                        //command.Notification = null;
                        //var dependency = new SqlDependency(command);
                        //dependency.OnChange += new OnChangeEventHandler(oeelive);

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            messages.Add(item: new Models.OEE_Live
                            {
                                shift_id = Convert.ToString(reader["Shift_ID"] == DBNull.Value ? "" : reader["Shift_ID"]),
                                MachineCode = Convert.ToString(reader["Machine_Code"] == DBNull.Value ? "" : reader["Machine_Code"]),
                                OEE = Convert.ToDecimal(reader["OEE"] == DBNull.Value ? 0.00 : reader["OEE"]),
                                Availability = Convert.ToDecimal(reader["Availability"] == DBNull.Value ? 0.00 : reader["Availability"]),
                                Performance = Convert.ToDecimal(reader["Performance"] == DBNull.Value ? 0.00 : reader["Performance"]),
                                Quality = Convert.ToDecimal(reader["Quality"] == DBNull.Value ? 0.00 : reader["Quality"]),
                                MachineStatus = Convert.ToString(reader["Machine_Status"] == DBNull.Value ? "" : reader["Machine_Status"]),
                            });
                        }
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = messages });
            }
        }

        //4

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetLineOEE(Models.OEE_Live oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.Line_Code);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                var messages = new List<Models.OEE_Live>();
                using (var connection = new SqlConnection(con_string))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT distinct a.[Line_Code],a.CompanyCode,b.AssetName as AssetName
                        FROM dbo.tbl_Live_OEE a inner join tbl_assets b on a.machine_code=b.AssetID and a.Line_code=b.FunctionName and a.CompanyCode=b.CompanyCode and a.PlantCode=b.PlantCode
                        
                        
                        WHERE a.CompanyCode=@company AND a.PlantCode=@plant and a.Line_code=@line and b.EOL=1 ", connection);

                    cmd.Parameters.AddWithValue("@company", oee.CompanyCode);
                    cmd.Parameters.AddWithValue("@plant", oee.PlantCode);
                    cmd.Parameters.AddWithValue("@line", oee.Line_Code);

                    {
                        //command.Notification = null;
                        //var dependency = new SqlDependency(command);
                        //dependency.OnChange += new OnChangeEventHandler(oeelive);

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            messages.Add(item: new Models.OEE_Live
                            {
                                // CompanyCode = Convert.ToString(reader["CompanyCode"] == DBNull.Value ? "" : reader["CompanyCode"]),
                                // PlantCode = Convert.ToString(reader["PlantName"] == DBNull.Value ? "" : reader["PlantName"]),
                                Line_Code = Convert.ToString(reader["Line_Code"] == DBNull.Value ? "" : reader["Line_Code"]),
                                line_name = Convert.ToString(reader["AssetName"] == DBNull.Value ? "" : reader["AssetName"]),

                            });
                        }
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = messages });
            }
        }

        //5

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetDashboardOEEData(Models.OEE_Live oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.Line_Code);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                var messages = new List<Models.OEE_Live>();
                using (var connection = new SqlConnection(con_string))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SP_Live_MainDashboard", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.Add("@company", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = oee.Line_Code;
                    cmd.Parameters.Add("@plant", SqlDbType.NVarChar, 150).Value = oee.PlantCode;


                    {
                        //command.Notification = null;
                        //var dependency = new SqlDependency(command);
                        //dependency.OnChange += new OnChangeEventHandler(oeelive);

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            messages.Add(item: new Models.OEE_Live
                            {
                                shift_id = (string)reader["Shift_ID"],
                                MachineCode = (string)reader["Machine_Code"],
                                Line_Code = (string)reader["Line_Code"],
                                OEE = Convert.ToDecimal(reader["OEE"] == DBNull.Value ? "" : reader["OEE"]),
                                variant_name = Convert.ToString(reader["Variantname"] == DBNull.Value ? "" : reader["Variantname"]),
                                LineCount = Convert.ToInt32(reader["LineCount"] == DBNull.Value ? "" : reader["LineCount"]),
                                MachineCount = Convert.ToInt32(reader["MachineCount"] == DBNull.Value ? "" : reader["MachineCount"]),
                                totalok = Convert.ToInt32(reader["totalok"] == DBNull.Value ? 0 : reader["totalok"]),
                                totalnok = Convert.ToInt32(reader["totalnok"] == DBNull.Value ? 0 : reader["totalnok"]),
                                MachineStatus = Convert.ToString(reader["Machine_Status"] == DBNull.Value ? "" : reader["Machine_Status"]),
                                MachineIndex = Convert.ToString(reader["EOL"] == DBNull.Value ? "" : reader["EOL"]),
                                Availability = Convert.ToDecimal(reader["Availability"] == DBNull.Value ? 0 : reader["Availability"]),
                                Performance = Convert.ToDecimal(reader["Performance"] == DBNull.Value ? 0 : reader["Performance"]),
                                Quality = Convert.ToDecimal(reader["Quality"] == DBNull.Value ? 0 : reader["Quality"]),
                                uptime = Convert.ToDecimal(reader["UpTime"] == DBNull.Value ? 0 : reader["UpTime"]),
                                downtime = Convert.ToDecimal(reader["DownTime"] == DBNull.Value ? 0 : reader["DownTime"]),
                                losstime = Convert.ToDecimal(reader["LossTime"] == DBNull.Value ? 0 : reader["LossTime"]),
                                breaktime = Convert.ToDecimal(reader["BreakTime"] == DBNull.Value ? 0 : reader["BreakTime"]),
                                last_updatedate = Convert.ToString(reader["last_updatedate"] == DBNull.Value ? "" : reader["last_updatedate"]),
                                Ideal_cycletime = Convert.ToString(reader["Ideal_cycletime"] == DBNull.Value ? "" : reader["Ideal_cycletime"]),
                                Reworkparts = Convert.ToString(reader["TotalReworkParts"] == DBNull.Value ? "" : reader["TotalReworkParts"]),
                                Batch_code = Convert.ToString(reader["Batch_code"] == DBNull.Value ? "" : reader["Batch_code"]),
                            });
                        }
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = messages });
            }
        }

        //6
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetDashboardOEEData_Machinewise(Models.OEE_Live oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.Line_Code);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                var messages = new List<Models.OEE_Live>();
                using (var connection = new SqlConnection(con_string))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[SP_Live_MainDashboard_Machinewise]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.Add("@company", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = oee.Line_Code;
                    cmd.Parameters.Add("@plant", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                    cmd.Parameters.Add("@machine", SqlDbType.NVarChar, 150).Value = oee.MachineCode;


                    {
                        //command.Notification = null;
                        //var dependency = new SqlDependency(command);
                        //dependency.OnChange += new OnChangeEventHandler(oeelive);

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            messages.Add(item: new Models.OEE_Live
                            {
                                shift_id = (string)reader["Shift_ID"],
                                MachineCode = (string)reader["Machine_Code"],
                                Line_Code = (string)reader["Line_Code"],
                                OEE = Convert.ToDecimal(reader["OEE"] == DBNull.Value ? "" : reader["OEE"]),
                                // Dept_name = Convert.ToString(reader["Dept_name"] == DBNull.Value ? "" : reader["Dept_name"]),
                                variant_name = Convert.ToString(reader["Variantname"] == DBNull.Value ? "" : reader["Variantname"]),
                                // line_name = Convert.ToString(reader["AssetName"] == DBNull.Value ? "" : reader["AssetName"]),
                                LineCount = Convert.ToInt32(reader["LineCount"] == DBNull.Value ? "" : reader["LineCount"]),
                                MachineCount = Convert.ToInt32(reader["MachineCount"] == DBNull.Value ? "" : reader["MachineCount"]),
                                totalok = Convert.ToInt32(reader["totalok"] == DBNull.Value ? 0 : reader["totalok"]),
                                totalnok = Convert.ToInt32(reader["totalnok"] == DBNull.Value ? 0 : reader["totalnok"]),
                                MachineStatus = Convert.ToString(reader["Machine_Status"] == DBNull.Value ? "" : reader["Machine_Status"]),
                                MachineIndex = Convert.ToString(reader["EOL"] == DBNull.Value ? "" : reader["EOL"]),
                                // PlantName = Convert.ToString(reader["PlantName"] == DBNull.Value ? "" : reader["PlantName"]),
                                Availability = Convert.ToDecimal(reader["Availability"] == DBNull.Value ? 0 : reader["Availability"]),
                                Performance = Convert.ToDecimal(reader["Performance"] == DBNull.Value ? 0 : reader["Performance"]),
                                Quality = Convert.ToDecimal(reader["Quality"] == DBNull.Value ? 0 : reader["Quality"]),
                                uptime = Convert.ToDecimal(reader["UpTime"] == DBNull.Value ? 0 : reader["UpTime"]),
                                downtime = Convert.ToDecimal(reader["DownTime"] == DBNull.Value ? 0 : reader["DownTime"]),
                                losstime = Convert.ToDecimal(reader["LossTime"] == DBNull.Value ? 0 : reader["LossTime"]),
                                breaktime = Convert.ToDecimal(reader["BreakTime"] == DBNull.Value ? 0 : reader["BreakTime"]),
                                last_updatedate = Convert.ToString(reader["last_updatedate"] == DBNull.Value ? "" : reader["last_updatedate"]),
                                Ideal_cycletime = Convert.ToString(reader["Ideal_cycletime"] == DBNull.Value ? "" : reader["Ideal_cycletime"]),
                                Reworkparts = Convert.ToString(reader["TotalReworkParts"] == DBNull.Value ? "" : reader["TotalReworkParts"]),
                                Batch_code = Convert.ToString(reader["Batch_code"] == DBNull.Value ? "" : reader["Batch_code"]),

                            });
                        }
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = messages });
            }
        }

        //7
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage Get_NewUI_data(Models.NewUI oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.LineCode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                var messages = new List<Models.NewUI>();
                using (var connection = new SqlConnection(con_string))
                {
                    connection.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Live_Batchwise_Carousel", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@company", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = oee.LineCode;
                    cmd.Parameters.Add("@plant", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

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
        public HttpResponseMessage Get_Machinewise_KPI_Live_data(Models.Machinewise_KPI oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.LineCode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                var messages = new List<Models.Machinewise_KPI>();
                using (var connection = new SqlConnection(con_string))
                {
                    connection.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Machinewise_KPI_Live", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@company", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;
                    cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = oee.LineCode;
                    cmd.Parameters.Add("@plant", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                    cmd.Parameters.Add("@machine", SqlDbType.NVarChar, 150).Value = oee.MachineCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

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

        //9

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage New_GetLineOEE(Models.OEE_Live oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.Line_Code);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                var messages = new List<Models.OEE_Live>();
                using (var connection = new SqlConnection(con_string))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT distinct a.[LineCode],a.CompanyCode,b.AssetName as AssetName
                        FROM dbo.tbl_batchwise_live_data a inner join tbl_assets b on a.machine_code=b.AssetID and a.LineCode=b.FunctionName and a.CompanyCode=b.CompanyCode and a.PlantCode=b.PlantCode
                        WHERE a.CompanyCode=@company AND a.PlantCode=@plant and a.LineCode=@line and b.EOL=1 and b.EOL=1 and a.Date=CAST(GETDATE() as date) ", connection);

                    cmd.Parameters.AddWithValue("@company", oee.CompanyCode);
                    cmd.Parameters.AddWithValue("@plant", oee.PlantCode);
                    cmd.Parameters.AddWithValue("@line", oee.Line_Code);

                    {
                        //command.Notification = null;
                        //var dependency = new SqlDependency(command);
                        //dependency.OnChange += new OnChangeEventHandler(oeelive);

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            messages.Add(item: new Models.OEE_Live
                            {
                                // CompanyCode = Convert.ToString(reader["CompanyCode"] == DBNull.Value ? "" : reader["CompanyCode"]),
                                // PlantCode = Convert.ToString(reader["PlantName"] == DBNull.Value ? "" : reader["PlantName"]),
                                Line_Code = Convert.ToString(reader["LineCode"] == DBNull.Value ? "" : reader["LineCode"]),
                                line_name = Convert.ToString(reader["AssetName"] == DBNull.Value ? "" : reader["AssetName"]),

                            });
                        }
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = messages });
            }
        }

        //10

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage Get_FactoryKPI_data(Models.NewUI oee)
        {

            var messages = new List<Models.NewUI>();
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();


                DataSet ds = new DataSet();



                SqlCommand cmd = new SqlCommand("SP_get_no_of_lines", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;
                // cmd.Parameters.Add("@linecode", SqlDbType.NVarChar, 150).Value = oee.LineCode;
                cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);


                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                if (ds.Tables[0].Rows.Count != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                }
            }
            // }
        }

        //11

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage getoeeutilization(Models.NewUI oee)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(oee.CompanyCode, oee.PlantCode, oee.LineCode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                var messages = new List<Models.NewUI>();
                using (var connection = new SqlConnection(con_string))

                {
                    connection.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Live_Factory KPI", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@company", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;
                    cmd.Parameters.Add("@Linecode", SqlDbType.NVarChar, 150).Value = oee.LineCode;
                    cmd.Parameters.Add("@plant", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

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

        //12
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage get_tooltipline(Models.NewUI oee)
        {
            Console.WriteLine(connectionstring);
            var messages = new List<Models.NewUI>();
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();


                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand("SP_FactoryKPI_linedetails_1", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = oee.CompanyCode;
                cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = oee.PlantCode;
                cmd.Parameters.Add("@LineCode", SqlDbType.NVarChar, 150).Value = oee.LineCode;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                if (ds.Tables[0].Rows.Count != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                }
            }
            // }








        }

    }
}
