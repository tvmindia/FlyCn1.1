using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FlyCn.FlyCnDAL
{
    public class dbConnection
    {
        public SqlConnection SQLCon = new SqlConnection(ConfigurationManager.ConnectionStrings["FLYCNConnectionString"].ConnectionString);
       public SqlTransaction DBTrans; 

        public int ConnectDB() {
            try
            {
                if (SQLCon.State == ConnectionState.Closed) {

                    SQLCon.Open();
                }
                return 1;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public SqlConnection GetDBConnection()
        {
            try
            {
                if (SQLCon.State == ConnectionState.Closed)
                {

                    SQLCon.Open();
                }
                return SQLCon;
            }
            catch (Exception)
            {
                try
                { 
                    HttpContext.Current.Response.Redirect("~/General/UnderConstruction.aspx?cause=dbDown", true);
                }
                catch (Exception)
                {
                    throw;
                }

                return null;

            }
        }

        public int DisconectDB() {
            try
            {
                if (SQLCon.State == ConnectionState.Open)
                {
                    SQLCon.Close();
                }
                return 1;
                
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}