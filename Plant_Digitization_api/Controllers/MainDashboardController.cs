using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Plant_Digitization_api.Controllers
{
    public class MainDashboardController : ApiController
    {
        [HttpGet]
        [CustomAuthenticationFilter]

        public string CbmURL(string PlantCode, string LineCode, string CompanyCode, string UserID, string UserName)
        {
            DataSet ds = new DataSet();
            string result = string.Empty;
            string Sqlquery = $"exec SP_CBMPortal2Redirect '{PlantCode}','{LineCode}','{CompanyCode}','{UserID}','{UserName}'";
            string SqlConnStr = ConfigurationManager.ConnectionStrings["con"].ToString();
            using (SqlConnection SqlConn = new SqlConnection(SqlConnStr))
            {
                SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(Sqlquery, SqlConn);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;
                SqlConn.Open();
                SqlDataAdapter.Fill(ds);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = JsonConvert.SerializeObject(ds);
                string status = ds.Tables[0].Rows[0]["Status"].ToString();
                string url = ds.Tables[0].Rows[0]["Cbmurl"].ToString();

                result = status + "," + url;

            }
            return result;
        }
    }
}
