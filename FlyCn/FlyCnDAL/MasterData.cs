﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Telerik.Web.UI;
using System.Web.UI;

namespace FlyCn.FlyCnDAL
{
    public class MasterData
    {
        DALConstants cnst = new DALConstants();

        public DataSet GetMasters() {

            DataSet dataset = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();


            SqlCommand cmd = new SqlCommand("GetDynamicMasters", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dataset = new DataSet();
            adapter.Fill(dataset);
            con.Close();
            return dataset;

        } 


        public void BindTree(RadTreeView  myTree){
            myTree.Nodes.Clear();

            DataSet dataset = GetMasters();
            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                RadTreeNode rtn = new RadTreeNode(dataset.Tables[0].Rows[i]["Table_Description"].ToString(), dataset.Tables[0].Rows[i]["Table_Name"].ToString()); //<a href="../FlyCnMasters/DynamicMaster.aspx?Mode=Country" target="contentPane">Country</a>
                rtn.NavigateUrl = cnst.DynamicMasterURL + "?Mode=" + rtn.Value;
                rtn.Target = "contentPane";               
                myTree.Nodes.Add(rtn);
            }
        
        }
    }
}