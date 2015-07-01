using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FlyCn.FlyCnDAL
{
    public class SliderDataAccess
    {
        #region getSliderContent
        public DataSet getSliderContent()
        {
            DataSet dataset = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            

            SqlCommand cmd = new SqlCommand("GetSliderData", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dataset = new DataSet();
            adapter.Fill(dataset);
            con.Close();
            return dataset;


        }
        #endregion getSliderContent

       


    }

    public class DynamicIcons {

        public DataSet getMenuNames()
        {
            DataSet dataset = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();

            SqlCommand cmd = new SqlCommand("GetMainIcons", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dataset = new DataSet();
            adapter.Fill(dataset);
            con.Close();
            return dataset;
        }

        public DataSet getSubMenuNames(string id)
        {
            DataSet dataset = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();

            SqlCommand cmd = new SqlCommand("GetSubIcons", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dataset = new DataSet();
            adapter.Fill(dataset);
            con.Close();
            return dataset;
        }
    }
}