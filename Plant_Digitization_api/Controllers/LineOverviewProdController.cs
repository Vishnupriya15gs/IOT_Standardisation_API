using Plant_Digitization_api.Controllers;
using Plant_Digitization_api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlanDigitization_api.Controllers
{
    public class LineOverviewProdController : ApiController
    {
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage get_Current_Shift(Models.eolProd L)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(L.CompanyCode, L.PlantCode, L.Line_Code);
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
                    SqlCommand cmd = new SqlCommand("SP_Lineoverview_Current_Shift", con);
                    cmd.CommandType = CommandType.StoredProcedure;

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
        public HttpResponseMessage get_Data_Production(Models.eolProd L)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(L.CompanyCode, L.PlantCode, L.Line_Code);
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
                    SqlCommand cmd = new SqlCommand("SP_Lineoverview_ProductionDashborad", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = L.CompanyCode;
                    cmd.Parameters.Add("@Plantcode", SqlDbType.NVarChar, 150).Value = L.PlantCode;
                    cmd.Parameters.Add("@LineCode", SqlDbType.NVarChar, 150).Value = L.Line_Code;
                    cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = L.Shift;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables.Count != 0)
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
        public HttpResponseMessage get_Data_Rejection_Reason(Models.eolProd L)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(L.CompanyCode, L.PlantCode, L.Line_Code);
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
                    SqlCommand cmd = new SqlCommand("SP_Lineoverview_StationwiseRejection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = L.CompanyCode;
                    cmd.Parameters.Add("@Plantcode", SqlDbType.NVarChar, 150).Value = L.PlantCode;
                    cmd.Parameters.Add("@LineCode", SqlDbType.NVarChar, 150).Value = L.Line_Code;
                    cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = L.Shift;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables.Count != 0)
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
        public HttpResponseMessage get_Cycletime_last_ten_parts(Models.eolProd L)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(L.CompanyCode, L.PlantCode, L.Line_Code);
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
                    SqlCommand cmd = new SqlCommand("SP_Lineoverview_CT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = L.CompanyCode;
                    cmd.Parameters.Add("@Plantcode", SqlDbType.NVarChar, 150).Value = L.PlantCode;
                    cmd.Parameters.Add("@LineCode", SqlDbType.NVarChar, 150).Value = L.Line_Code;
                    cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = L.Shift;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables.Count != 0)
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
        public HttpResponseMessage get_Data_Alarms(Models.eolProd L)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(L.CompanyCode, L.PlantCode, L.Line_Code);
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
                    SqlCommand cmd = new SqlCommand("SP_Lineoverview_Alarms", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = L.CompanyCode;
                    cmd.Parameters.Add("@Plantcode", SqlDbType.NVarChar, 150).Value = L.PlantCode;
                    cmd.Parameters.Add("@LineCode", SqlDbType.NVarChar, 150).Value = L.Line_Code;
                    cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = L.Shift;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables.Count != 0)
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
        public HttpResponseMessage get_Daily_Variantwise_Production(Models.eolProd L)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(L.CompanyCode, L.PlantCode, L.Line_Code);
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
                    SqlCommand cmd = new SqlCommand("SP_Lineoverview_DaywisePopup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = L.CompanyCode;
                    cmd.Parameters.Add("@Plantcode", SqlDbType.NVarChar, 150).Value = L.PlantCode;
                    cmd.Parameters.Add("@LineCode", SqlDbType.NVarChar, 150).Value = L.Line_Code;
                    cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = L.Shift;
                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 150).Value = L.Date;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables.Count != 0)
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
        //Popup API Overall line Stoppage
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage get_Daily_Overall_line_Alarm_data(Models.eolProd L)
        {
            database_connection db_connection = new database_connection();
            string con_string = db_connection.Getconnectionstring(L.CompanyCode, L.PlantCode, L.Line_Code);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = String.Empty });

            }
            else
            {
                try
                {

                    using (SqlConnection con = new SqlConnection(con_string))
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SP_Lineoverview_Popupdowntime", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = L.CompanyCode;
                        cmd.Parameters.Add("@Plantcode", SqlDbType.NVarChar, 150).Value = L.PlantCode;
                        cmd.Parameters.Add("@LineCode", SqlDbType.NVarChar, 150).Value = L.Line_Code;
                        cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = L.Shift;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables.Count != 0)
                        {
                            con.Close();
                            return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                        }
                        else
                        {
                            con.Close();
                            return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = String.Empty });
                        }
                    }
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Couldn't Retrieve Data", data = String.Empty });
                }
            }

        }


        //Utilisation - added by priya
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage get_Prod_Utilisation(Models.eolProd L)
        {
            database_connection db_connection = new database_connection();
            string con_string = db_connection.Getconnectionstring(L.CompanyCode, L.PlantCode, L.Line_Code);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = String.Empty });
            }
            else
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(con_string))
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SP_GET_Prod_Utilisation", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = L.CompanyCode;
                        cmd.Parameters.Add("@Plantcode", SqlDbType.NVarChar, 150).Value = L.PlantCode;
                        cmd.Parameters.Add("@line", SqlDbType.NVarChar, 150).Value = L.Line_Code;
                        cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = L.Shift;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables.Count != 0)
                        {
                            con.Close();
                            return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                        }
                        else
                        {
                            con.Close();
                            return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = String.Empty });
                        }
                    }
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Couldn't Retrieve Data", data = String.Empty });
                }
            }
        }


        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage get_Prod_Stationwise_Rejection(Models.eolProd L)
        {
            database_connection db_connection = new database_connection();
            string con_string = db_connection.Getconnectionstring(L.CompanyCode, L.PlantCode, L.Line_Code);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = String.Empty });
            }
            else
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(con_string))
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SP_Lineoverview_drilldown_StationwiseRejection", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = L.CompanyCode;
                        cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = L.PlantCode;
                        cmd.Parameters.Add("@LineCode", SqlDbType.NVarChar, 150).Value = L.Line_Code;
                        cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = L.Shift;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables.Count != 0)
                        {
                            con.Close();
                            return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                        }
                        else
                        {
                            con.Close();
                            return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = String.Empty });
                        }
                    }
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Couldn't Retrieve Data", data = String.Empty });
                }
            }
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage get_Prod_downtime_reasons(Models.eolProd L)
        {
            database_connection db_connection = new database_connection();
            string con_string = db_connection.Getconnectionstring(L.CompanyCode, L.PlantCode, L.Line_Code);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = String.Empty });
            }
            else
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(con_string))
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SP_Lineoverview_DowntimeReason_Drilldown", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = L.CompanyCode;
                        cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = L.PlantCode;
                        cmd.Parameters.Add("@LineCode", SqlDbType.NVarChar, 150).Value = L.Line_Code;
                        cmd.Parameters.Add("@Shift", SqlDbType.NVarChar, 150).Value = L.Shift;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables.Count != 0)
                        {
                            con.Close();
                            return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
                        }
                        else
                        {
                            con.Close();
                            return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = String.Empty });
                        }
                    }
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Couldn't Retrieve Data", data = String.Empty });
                }
            }
        }

    }
}
