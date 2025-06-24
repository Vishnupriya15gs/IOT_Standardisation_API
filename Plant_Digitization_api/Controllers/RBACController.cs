using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using Plant_Digitization_api.Models;

namespace Plant_Digitization_api.Controllers
{

    public class RBACController : ApiController
    {
        private string connectionstring = ConfigurationManager.ConnectionStrings["con"].ToString();
        private string username;
        private string password;
        [HttpPost]

        public IHttpActionResult RBAC()
        {


            DataSet ds = new DataSet();

            string Sqlquery = "exec SP_GetMasterData";
            string SqlConnStr = connectionstring;
            using (SqlConnection SqlConn = new SqlConnection(SqlConnStr))
            {
                SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(Sqlquery, SqlConn);
                SqlDataAdapter.SelectCommand.CommandType = CommandType.Text;
                SqlConn.Open();
                SqlDataAdapter.Fill(ds);
            }
            return Ok(ds);

        }
    }
}

