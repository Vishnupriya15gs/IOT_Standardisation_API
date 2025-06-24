using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;

namespace Plant_Digitization_api.Controllers
{
    public class ValuesController : ApiController
    {
        static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        private string connectionstring = ConfigurationManager.ConnectionStrings["con"].ToString();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        [HttpPost]
        [Obsolete]
        [CustomAuthenticationFilter]
        public HttpResponseMessage User_settings_details(Models.Setting U)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(U.CompanyCode, U.PlantCode, U.LineCode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string response = string.Empty;
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_GetSettings_data", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar, 150).Value = U.QueryType;
                    cmd.Parameters.Add("@Parameter", SqlDbType.NVarChar, 150).Value = U.Parameter;
                    cmd.Parameters.Add("@Parameter1", SqlDbType.NVarChar, 150).Value = U.Parameter1;
                    cmd.Parameters.Add("@Parameter2", SqlDbType.NVarChar, 150).Value = U.Parameter2;
                    cmd.Parameters.Add("@Parameter4", SqlDbType.NVarChar, 150).Value = U.Parameter4;
                    cmd.Parameters.Add("@Parameter3", SqlDbType.NVarChar, 150).Value = U.Parameter3;
                    cmd.Parameters.Add("@Parameter5", SqlDbType.NVarChar, 150).Value = U.Parameter5;
                    cmd.Parameters.Add("@Parameter6", SqlDbType.NVarChar, 150).Value = U.Parameter6;


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
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

        public IHttpActionResult settings_details(Models.Setting U)
        {
            try
            {
                database_connection d = new database_connection();
                string con_string = d.Getconnectionstring(U.CompanyCode, U.PlantCode, U.LineCode);
                if (con_string == "0")
                {
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldnot connect to database"));

                }
                else
                {
                    using (SqlConnection con = new SqlConnection(con_string))
                    {
                        string response = string.Empty;
                        con.Open();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SP_GetSettings_data", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar, 150).Value = U.QueryType;
                        cmd.Parameters.Add("@Parameter", SqlDbType.NVarChar, 150).Value = U.Parameter;
                        cmd.Parameters.Add("@Parameter1", SqlDbType.NVarChar, 150).Value = U.Parameter1;
                        cmd.Parameters.Add("@Parameter2", SqlDbType.NVarChar, 150).Value = U.Parameter2;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables.Count != 0)
                        {
                            return Ok(ds.Tables[0]);
                        }
                        else
                        {
                            return Ok(new string[0]);
                        }
                        //return Ok(ds.Tables[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok("1");
            }
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        public IHttpActionResult delete_User_settings_details(Models.Setting U)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(U.CompanyCode, U.PlantCode, U.LineCode);
            if (con_string == "0")
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldnot connect to database"));

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string response = string.Empty;
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_delete_usersettings", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar, 150).Value = U.QueryType;
                    cmd.Parameters.Add("@Parameter", SqlDbType.NVarChar, 150).Value = U.Parameter;
                    cmd.Parameters.Add("@Parameter1", SqlDbType.NVarChar, 150).Value = U.Parameter1;
                    cmd.Parameters.Add("@Parameter2", SqlDbType.NVarChar, 150).Value = U.Parameter2;
                    cmd.Parameters.Add("@Parameter3", SqlDbType.NVarChar, 150).Value = U.Parameter3;
                    cmd.Parameters.Add("@Parameter4", SqlDbType.NVarChar, 150).Value = U.Parameter4;
                    cmd.Parameters.Add("@Parameter5", SqlDbType.NVarChar, 150).Value = U.Parameter5;
                    cmd.Parameters.Add("@Parameter6", SqlDbType.NVarChar, 150).Value = U.Parameter6;
                    cmd.ExecuteNonQuery();
                    return Ok(response);
                }
            }
        }
        [HttpPost]
        [CustomAuthenticationFilter]
        public IHttpActionResult new_delete_User_settings_details(Models.Setting U)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(U.CompanyCode, U.PlantCode, U.LineCode);
            if (con_string == "0")
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldnot connect to database"));

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string response = string.Empty;
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_new_delete_usersettings", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar, 150).Value = U.QueryType;
                    cmd.Parameters.Add("@Parameter", SqlDbType.NVarChar, 150).Value = U.Parameter;
                    cmd.Parameters.Add("@Parameter1", SqlDbType.NVarChar, 150).Value = U.Parameter1;
                    SqlParameter SQLReturn = new SqlParameter("@SQLReturn", SqlDbType.NVarChar, 50);
                    SQLReturn.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(SQLReturn);
                    cmd.ExecuteNonQuery();
                    response = SQLReturn.Value.ToString().Trim();
                    return Ok(response);
                }
            }
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetSettingdatas1(Models.SettingData tool)
        {
            var fronthash = tool.HashId;
            var string1 = tool.CompanyCode + tool.PlantCode;
            var backhash = Encrypt(string1);
            if (fronthash == backhash)
            {

                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    //To Get the response from database and display from user
                    var result = new List<Models.SettingData>();
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_Settings_data", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Flag", SqlDbType.NVarChar, 150).Value = tool.Flag;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = tool.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = tool.PlantCode;
                    cmd.Parameters.Add("@LineCode", SqlDbType.NVarChar, 150).Value = tool.LineCode;
                    cmd.Parameters.Add("@MachineCode", SqlDbType.NVarChar, 150).Value = tool.MachineCode;
                    cmd.Parameters.Add("@Parameter", SqlDbType.NVarChar, 150).Value = tool.Parameter;
                    var reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    DataTable dtData = new DataTable("Data");
                    DataTable dtSchema = new DataTable("Schema");
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //da.Fill(dt);
                    while (reader.Read())
                    {

                        result.Add(item: new Models.SettingData
                        {
                            //Name = (string)reader["Name"],
                            //Code = (string)reader["Code"],
                            Name = Convert.ToString(reader["Name"] == DBNull.Value ? "" : reader["Name"]),
                            Code = Convert.ToString(reader["Code"] == DBNull.Value ? "" : reader["Code"]),
                        });
                    }

                    if (result.Any())
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { data = result.ToArray() });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                    }
                }


            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
            }
        }
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetSettingdatas(Models.SettingData tool)
        {

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                //To Get the response from database and display from user
                var result = new List<Models.SettingData>();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Settings_data", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Flag", SqlDbType.NVarChar, 150).Value = tool.Flag;
                cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = tool.CompanyCode;
                cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = tool.PlantCode;
                cmd.Parameters.Add("@LineCode", SqlDbType.NVarChar, 150).Value = tool.LineCode;
                cmd.Parameters.Add("@MachineCode", SqlDbType.NVarChar, 150).Value = tool.MachineCode;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(item: new Models.SettingData
                    {
                        //Name = (string)reader["Name"],
                        //Code = (string)reader["Code"],
                        Name = Convert.ToString(reader["Name"] == DBNull.Value ? "" : reader["Name"]),
                        Code = Convert.ToString(reader["Code"] == DBNull.Value ? "" : reader["Code"]),

                    });
                }
                if (result.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = result });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                }

            }
        }
        public static string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {

                using (var tdes = new TripleDESCryptoServiceProvider())

                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }
        [HttpPost]
        [CustomAuthenticationFilter]
        public HttpResponseMessage GetSettingdatas_line(Models.SettingData tool)
        {

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                //To Get the response from database and display from user
                var result = new List<Models.SettingData>();
                DataSet ds = new DataSet();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Settings_data", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Flag", SqlDbType.NVarChar, 150).Value = tool.Flag;
                cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = tool.CompanyCode;
                cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = tool.PlantCode;
                cmd.Parameters.Add("@LineCode", SqlDbType.NVarChar, 150).Value = tool.LineCode;
                cmd.Parameters.Add("@MachineCode", SqlDbType.NVarChar, 150).Value = tool.MachineCode;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables.Count != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = ds });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                }



                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(item: new Models.SettingData
                    {
                        //Name = (string)reader["Name"],
                        //Code = (string)reader["Code"],
                        Name = Convert.ToString(reader["Name"] == DBNull.Value ? "" : reader["Name"]),
                        Code = Convert.ToString(reader["Code"] == DBNull.Value ? "" : reader["Code"]),

                    });
                }
                if (result.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", msg = "Details Found", data = result });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
                }

            }
        }

        public IHttpActionResult settings_details1(Models.Setting U)
        {
            try
            {
                database_connection d = new database_connection();
                string con_string = d.Getconnectionstring(U.CompanyCode, U.PlantCode, U.LineCode);
                if (con_string == "0")
                {
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldnot connect to database"));

                }
                else
                {
                    using (SqlConnection con = new SqlConnection(con_string))
                    {
                        string response = string.Empty;
                        con.Open();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand("SP_GetSettings_data", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar, 150).Value = U.QueryType;
                        cmd.Parameters.Add("@Parameter", SqlDbType.NVarChar, 150).Value = U.Parameter;
                        cmd.Parameters.Add("@Parameter1", SqlDbType.NVarChar, 150).Value = U.Parameter1;
                        cmd.Parameters.Add("@Parameter2", SqlDbType.NVarChar, 150).Value = U.Parameter2;
                        cmd.Parameters.Add("@Parameter3", SqlDbType.NVarChar, 150).Value = U.Parameter3;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        if (ds.Tables.Count != 0)
                        {

                            return Ok(ds.Tables[0].Rows[0]["alarm_count"].ToString());
                        }
                        else
                        {
                            return Ok("0");
                        }
                        //return Ok(ds.Tables[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok("1");
            }
        }

        //[CustomAuthenticationFilter]
        //public HttpResponseMessage Search_details(Models.Setting U)
        //{

        //    database_connection d = new database_connection();
        //    string con_string = d.Getconnectionstring(U.CompanyCode, U.PlantCode, U.LineCode);
        //    if (con_string == "0")
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

        //    }
        //    else
        //    {
        //        using (SqlConnection con = new SqlConnection(con_string))
        //        {
        //            string response = string.Empty;
        //            con.Open();
        //            DataSet ds = new DataSet();
        //            SqlCommand cmd = new SqlCommand("SP_GetSettings_data", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout = 0;
        //            cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar, 150).Value = U.QueryType;
        //            cmd.Parameters.Add("@Parameter", SqlDbType.NVarChar, 150).Value = U.Parameter;
        //            cmd.Parameters.Add("@Parameter1", SqlDbType.NVarChar, 150).Value = U.Parameter1;
        //            cmd.Parameters.Add("@Parameter2", SqlDbType.NVarChar, 150).Value = U.Parameter2;
        //            cmd.Parameters.Add("@Parameter3", SqlDbType.NVarChar, 150).Value = U.Parameter3;
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            da.Fill(ds);
        //            if (ds.Tables.Count != 0)
        //            {
        //                return Request.CreateResponse(HttpStatusCode.OK, new { data = ds });
        //            }
        //            else
        //            {
        //                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "No Data Available", data = "" });
        //            }

        //        }
        //    }

        //}



        [CustomAuthenticationFilter]
        public HttpResponseMessage Search_details(Models.Setting U)
        {

            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(U.CompanyCode, U.PlantCode, U.LineCode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string response = string.Empty;
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_GetSettings_data", con);
                    //  SqlCommand cmd = new SqlCommand("SELECT * FROM AlarmTable_Setting WHERE CompanyCode=@Parameter AND PlantCode=@Parameter1 AND Line_Code=@Parameter2 AND Machine_Code=@Parameter3", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar, 150).Value = U.QueryType;
                    cmd.Parameters.Add("@Parameter", SqlDbType.NVarChar, 150).Value = U.Parameter;
                    cmd.Parameters.Add("@Parameter1", SqlDbType.NVarChar, 150).Value = U.Parameter1;
                    cmd.Parameters.Add("@Parameter2", SqlDbType.NVarChar, 150).Value = U.Parameter2;
                    cmd.Parameters.Add("@Parameter3", SqlDbType.NVarChar, 150).Value = U.Parameter3;
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
        [Obsolete]
        [CustomAuthenticationFilter]

        public HttpResponseMessage CollectFileName_settings_details(Models.Setting U)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(U.CompanyCode, U.PlantCode, U.LineCode);
            if (con_string == "0")
            {
                // return Ok("Line can not find");
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string response = string.Empty;
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Manualupload", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar, 150).Value = U.QueryType;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = U.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = U.PlantCode;
                    cmd.Parameters.Add("@Line_Code", SqlDbType.NVarChar, 150).Value = U.LineCode;
                    cmd.Parameters.Add("@Unique_id", SqlDbType.NVarChar, 150).Value = U.Unique_id;
                    SqlParameter SQLReturn = new SqlParameter("@SQLReturn", SqlDbType.NVarChar, 50);
                    SQLReturn.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(SQLReturn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
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


        [HttpPost]
        [Obsolete]
        [CustomAuthenticationFilter]
        public HttpResponseMessage File_settings_details(Models.Setting U)
        {
            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(U.CompanyCode, U.PlantCode, U.LineCode);
            if (con_string == "0")
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });

            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string response = string.Empty;
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_Manualupload", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar, 150).Value = U.QueryType;
                    cmd.Parameters.Add("@CompanyCode", SqlDbType.NVarChar, 150).Value = U.CompanyCode;
                    cmd.Parameters.Add("@PlantCode", SqlDbType.NVarChar, 150).Value = U.PlantCode;
                    cmd.Parameters.Add("@Line_Code", SqlDbType.NVarChar, 150).Value = U.LineCode;
                    SqlParameter SQLReturn = new SqlParameter("@SQLReturn", SqlDbType.NVarChar, 50);
                    SQLReturn.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(SQLReturn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
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


        [CustomAuthenticationFilter]
        public IHttpActionResult Download_Search_details(Models.Setting U)
        {

            database_connection d = new database_connection();
            string con_string = d.Getconnectionstring(U.CompanyCode, U.PlantCode, U.LineCode);
            if (con_string == "0")
            {
                //return Request.CreateResponse(HttpStatusCode.OK, new { status = "Error", msg = "Coudnot Connect to database", data = "" });
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldnot connect to database"));
            }
            else
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string response = string.Empty;
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_GetSettings_data", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar, 150).Value = U.QueryType;
                    cmd.Parameters.Add("@Parameter", SqlDbType.NVarChar, 150).Value = U.Parameter;
                    cmd.Parameters.Add("@Parameter1", SqlDbType.NVarChar, 150).Value = U.Parameter1;
                    cmd.Parameters.Add("@Parameter2", SqlDbType.NVarChar, 150).Value = U.Parameter2;
                    cmd.Parameters.Add("@Parameter3", SqlDbType.NVarChar, 150).Value = U.Parameter3;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables.Count != 0)
                    {
                        return Ok(ds.Tables[0]);
                    }
                    else
                    {
                        return Ok(new string[0]);
                    }
                }
            }

        }

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



    }
}
