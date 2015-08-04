using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FlyCn.FlyCnDAL
{
    public class Connection
    {
        #region GetCCMSDBConnection
        public static SqlConnection GetCCMSDBConnection()
        {

            String strcon = ConfigurationManager.ConnectionStrings["FLYCNConnectionString"].ToString();
            SqlConnection con = new SqlConnection(strcon);
            return con;
        }
        #endregion GetCCMSDBConnection
    }
}