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
        public SqlConnection SQLCon = new SqlConnection(ConfigurationManager.ConnectionStrings["FLYCNConnectionString"].ConnectionString);//.Replace("sa@2015","sqlserver"));
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
                throw;
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