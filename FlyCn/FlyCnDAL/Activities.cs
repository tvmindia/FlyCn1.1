using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Telerik.Web.UI;
using System.Web.UI;
using System.Data.SqlClient;

namespace FlyCn.FlyCnDAL
{
    public class Activities
    {
        public void BindTree(RadTreeView myTree)
        {
            myTree.Nodes.Clear();
            RadTreeNode rtn = new RadTreeNode("Activity Library", "Activity Library"); //<a href="../FlyCnMasters/DynamicMaster.aspx?Mode=Country" target="contentPane">Country</a>
            rtn.NavigateUrl = "../Activities/ActivityLibrary.aspx";
                rtn.Target = "contentPane";
                myTree.Nodes.Add(rtn);
           }


        public DataSet GetActivities(string ProjNo )
        {
            DataSet dataset = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();


            SqlCommand cmd = new SqlCommand("GetActLibrary", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ProjectNo", ProjNo);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dataset = new DataSet();
            adapter.Fill(dataset);
            con.Close();
            return dataset;

        }
    }
}