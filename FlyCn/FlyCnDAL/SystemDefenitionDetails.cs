using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FlyCn.FlyCnDAL
{
    public class SystemDefenitionDetails
    {
        public DataSet getData(string TableName)
        {
            DataSet dataset = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("SelectAllData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TableName", TableName);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dataset = new DataSet();
            adapter.Fill(dataset);
            con.Close();
            return dataset;
        }


        public DataSet getDataToInsert(string TableName)
        {
            DataSet dataset = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("SelectAllDataTOInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TableName", TableName);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dataset = new DataSet();
            adapter.Fill(dataset);
            con.Close();
            return dataset;
        }
        public DataTable getFieldNames(string TableName,string projectNO,bool ISBaseTable=false)
        {
            DataTable dt = null;
            dbConnection dcon = null;
            SqlCommand cmd = null;
            try
            {
                dcon = new dbConnection();
                dcon.GetDBConnection();
                cmd = new SqlCommand();
                cmd.Connection = dcon.SQLCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetFieldNames";
                cmd.Parameters.Add("@TableName",SqlDbType.VarChar,50).Value=TableName;
                cmd.Parameters.Add("@projectNO", SqlDbType.NVarChar, 7).Value = projectNO;
                cmd.Parameters.Add("@ISBaseTable", SqlDbType.Bit).Value = ISBaseTable;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                dt = new DataTable();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                if(dcon.SQLCon!=null)
                {
                    dcon.DisconectDB();
                }
                
            }
           
           
            return dt;


        }
        public DataTable GetComboBoxDetails(string TableName)
        {
            DataTable dataset = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetComboBoxDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TableName", TableName);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dataset = new DataTable();
            adapter.Fill(dataset);
            con.Close();
            return dataset;
        }

        public DataTable GetPrimarykeys(string TableName)
        {
             UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            DataTable dt = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetPrimaryKeys", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TableName", TableName);
            cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 7).Value = UA.projectNo;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
    }
}