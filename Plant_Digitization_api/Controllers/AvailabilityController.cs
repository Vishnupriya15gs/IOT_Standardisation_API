using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Data.SqlClient;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Web.Http.Cors;

namespace Plant_Digitization_api.Controllers
{
    //[EnableCors(origins: "http://localhost:55974", headers: "*", methods: "*")]

    public class AvailabilityController : ApiController
    {
        //Models.PlanDigitizationEntities db = new Models.PlanDigitizationEntities();
        private string connectionstring = ConfigurationManager.ConnectionStrings["con"].ToString();

        [Route("api/Availability/GetAvlDaywise")]
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetAvlDaywise(Models.Avl_Daywisereport avl)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(avl.CompanyCode, avl.PlantCode, avl.line);
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
                    SqlCommand cmd = new SqlCommand("SP_Avl_DaywiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = avl.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = avl.Machine;
                    cmd.Parameters.Add("@date", SqlDbType.NVarChar, 150).Value = avl.Month;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = avl.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = avl.PlantCode;
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
        public HttpResponseMessage GetAvlweekwise(Models.Avl_weekwisereport avl)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(avl.CompanyCode, avl.PlantCode, avl.line);
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
                    SqlCommand cmd = new SqlCommand("SP_Avl_WeekwiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = avl.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = avl.Machine;
                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 150).Value = avl.Month;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = avl.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = avl.PlantCode;
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
        public HttpResponseMessage GetAvlshiftwise(Models.Avl_shiftwisereport avl)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(avl.CompanyCode, avl.PlantCode, avl.line);
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
                    SqlCommand cmd = new SqlCommand("SP_Avl_ShiftwiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = avl.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = avl.Machine;
                    cmd.Parameters.Add("@date", SqlDbType.NVarChar, 150).Value = avl.Month;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = avl.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = avl.PlantCode;
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
        [Route("api/Availability/GetAvlyearwise")]
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetAvlyearwise(Models.Avl_yearwisereport avl)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(avl.CompanyCode, avl.PlantCode, avl.line);
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
                    SqlCommand cmd = new SqlCommand("SP_Avl_YearwiseReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = avl.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = avl.Machine;
                    cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 150).Value = avl.Year;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = avl.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = avl.PlantCode;
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
        public HttpResponseMessage GetAvlReasons(Models.Avl_Breakdown avl)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(avl.CompanyCode, avl.PlantCode, avl.line);
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
                    SqlCommand cmd = new SqlCommand("SP_Avl_Reasons ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = avl.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = avl.Machine;
                    cmd.Parameters.Add("@Fromdate", SqlDbType.DateTime, 150).Value = avl.Fromdate;
                    cmd.Parameters.Add("@Todate", SqlDbType.DateTime, 150).Value = avl.Todate;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = avl.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = avl.PlantCode;
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
        public HttpResponseMessage GetAvlWeekReasons(Models.Avl_weekBreakdown avl)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(avl.CompanyCode, avl.PlantCode, avl.line);
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
                    SqlCommand cmd = new SqlCommand("SP_Avl_Week_Reasons", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = avl.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = avl.Machine;
                    cmd.Parameters.Add("@Date", SqlDbType.DateTime, 150).Value = avl.Date;
                    cmd.Parameters.Add("@WeekNo", SqlDbType.NVarChar, 150).Value = avl.WeekNo;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = avl.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = avl.PlantCode;
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
        public HttpResponseMessage GetAvlShiftReasons(Models.Avl_shiftBreakdown avl)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(avl.CompanyCode, avl.PlantCode, avl.line);
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
                    SqlCommand cmd = new SqlCommand("SP_Avl_Shift_Reasons", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = avl.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = avl.Machine;
                    cmd.Parameters.Add("@Fromdate", SqlDbType.DateTime, 150).Value = avl.Fromdate;
                    //cmd.Parameters.Add("@Todate", SqlDbType.DateTime, 150).Value = avl.Todate;
                    cmd.Parameters.Add("@shift", SqlDbType.NVarChar, 150).Value = avl.shift;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = avl.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = avl.PlantCode;
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
        public HttpResponseMessage GetAvlcustomreport(Models.Avl_custom avl)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(avl.CompanyCode, avl.PlantCode, avl.line);
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
                    SqlCommand cmd = new SqlCommand("SP_Avl_CustomReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = avl.line;
                    cmd.Parameters.Add("@Machine", SqlDbType.NVarChar, 150).Value = avl.Machine;
                    cmd.Parameters.Add("@Fromdate", SqlDbType.DateTime, 150).Value = avl.Fromdate;
                    cmd.Parameters.Add("@Todate", SqlDbType.DateTime, 150).Value = avl.Todate;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = avl.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = avl.PlantCode;
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
        //Live API 1
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetAvllivedata(Models.Availability_Live live)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(live.CompanyCode, live.PlantCode, live.Line_Code);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                var messages = new List<Models.Availability_Live>();
                using (var connection = new SqlConnection(con_string))
                {
                    connection.Open();
                    //using (var command = new SqlCommand(@"SELECT [ShiftID]
                    //                                      ,[Line_Code]
                    //                                      ,[Machine_Code]
                    //                                      ,[Machine_Status]
                    //                                      ,[Availability]
                    //                                      ,[UpTime]
                    //                                      ,[DownTime]
                    //                                      ,[LossTime]
                    //                                      ,[TotalProductionTime]
                    //                                      ,[lastupdate]
                    //                                  FROM [dbo].[Live_Availability] WHERE CompanyCode='" + live.CompanyCode + "' AND PlantCode='" + live.PlantCode + "' AND Line_Code='" + live.Line_Code + "' ", connection))

                    SqlCommand command = new SqlCommand("SELECT ShiftID,Line_Code,Machine_Code,Machine_Status,Availability,UpTime,DownTime,LossTime,TotalProductionTime,lastupdate from dbo.Live_Availability where CompanyCode=@CompanyCode and PlantCode=@PlantCode and Line_Code=@Line_Code and Convert(Date,lastupdate)=@currentdate", connection);


                    command.Parameters.AddWithValue("@CompanyCode", live.CompanyCode);
                    command.Parameters.AddWithValue("@PlantCode", live.PlantCode);
                    command.Parameters.AddWithValue("@Line_Code", live.Line_Code);
                    command.Parameters.AddWithValue("@currentdate", DateTime.Now.ToString("yyyy/MM/dd"));
                    {
                        //command.Notification = null;
                        //var dependency = new SqlDependency(command);
                        //dependency.OnChange += new OnChangeEventHandler(avllive);

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            messages.Add(item: new Models.Availability_Live
                            {
                                ShiftID = Convert.ToString(reader["ShiftID"] == DBNull.Value ? "" : reader["ShiftID"]),
                                Line_Code = Convert.ToString(reader["Line_Code"] == DBNull.Value ? "" : reader["Line_Code"]),
                                Machine_Code = Convert.ToString(reader["Machine_Code"] == DBNull.Value ? "" : reader["Machine_Code"]),
                                Machine_Status = Convert.ToString(reader["Machine_Status"] == DBNull.Value ? "" : reader["Machine_Status"]),
                                Avail = Convert.ToDecimal(reader["Availability"] == DBNull.Value ? "" : reader["Availability"]),
                                UpTime = Convert.ToDecimal(reader["UpTime"] == DBNull.Value ? "" : reader["UpTime"]),
                                DownTime = Convert.ToDecimal(reader["DownTime"] == DBNull.Value ? "" : reader["DownTime"]),
                                LossTime = Convert.ToDecimal(reader["LossTime"] == DBNull.Value ? "" : reader["LossTime"]),
                                Totaltime = Convert.ToInt32(reader["TotalProductionTime"] == DBNull.Value ? "" : reader["TotalProductionTime"]),
                                lastupdate = Convert.ToDateTime(reader["lastupdate"] == DBNull.Value ? null : reader["lastupdate"]),
                            });
                        }
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = messages });
            }

        }

        //2
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetAvllivedata_mcwise(Models.Availability_Live live)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(live.CompanyCode, live.PlantCode, live.Line_Code);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                var messages = new List<Models.Availability_Live>();
                using (var connection = new SqlConnection(con_string))
                {
                    connection.Open();
                    //using (var command = new SqlCommand(@"SELECT [ShiftID]
                    //                                      ,[Line_Code]
                    //                                      ,[Machine_Code]
                    //                                      ,[Machine_Status]
                    //                                      ,[Availability]
                    //                                      ,[UpTime]
                    //                                      ,[DownTime]
                    //                                      ,[LossTime]
                    //                                      ,[TotalProductionTime]
                    //                                      ,[lastupdate]
                    //                                  FROM [dbo].[Live_Availability] WHERE CompanyCode='" + live.CompanyCode + "' AND PlantCode='" + live.PlantCode + "' AND Line_Code='" + live.Line_Code + "' ", connection))

                    SqlCommand command = new SqlCommand("SELECT ShiftID,Line_Code,Machine_Code,Machine_Status,Availability,UpTime,DownTime,LossTime,TotalProductionTime,lastupdate from dbo.Live_Availability where CompanyCode=@CompanyCode and PlantCode=@PlantCode and Line_Code=@Line_Code and machine_code=@machinecode", connection);


                    command.Parameters.AddWithValue("@CompanyCode", live.CompanyCode);
                    command.Parameters.AddWithValue("@PlantCode", live.PlantCode);
                    command.Parameters.AddWithValue("@Line_Code", live.Line_Code);
                    command.Parameters.AddWithValue("@machinecode", live.Machine_Code);

                    {
                        //command.Notification = null;
                        //var dependency = new SqlDependency(command);
                        //dependency.OnChange += new OnChangeEventHandler(avllive);

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            messages.Add(item: new Models.Availability_Live
                            {
                                ShiftID = Convert.ToString(reader["ShiftID"] == DBNull.Value ? "" : reader["ShiftID"]),
                                Line_Code = Convert.ToString(reader["Line_Code"] == DBNull.Value ? "" : reader["Line_Code"]),
                                Machine_Code = Convert.ToString(reader["Machine_Code"] == DBNull.Value ? "" : reader["Machine_Code"]),
                                Machine_Status = Convert.ToString(reader["Machine_Status"] == DBNull.Value ? "" : reader["Machine_Status"]),
                                Avail = Convert.ToDecimal(reader["Availability"] == DBNull.Value ? "" : reader["Availability"]),
                                UpTime = Convert.ToDecimal(reader["UpTime"] == DBNull.Value ? "" : reader["UpTime"]),
                                DownTime = Convert.ToDecimal(reader["DownTime"] == DBNull.Value ? "" : reader["DownTime"]),
                                LossTime = Convert.ToDecimal(reader["LossTime"] == DBNull.Value ? "" : reader["LossTime"]),
                                Totaltime = Convert.ToInt32(reader["TotalProductionTime"] == DBNull.Value ? "" : reader["TotalProductionTime"]),
                                lastupdate = Convert.ToDateTime(reader["lastupdate"] == DBNull.Value ? null : reader["lastupdate"]),
                            });
                        }
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = messages });
            }
        }
    }
}
