using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Telerik.Web.UI;


namespace FlyCn.FlyCnDAL
{

    public class ProjectParameters
    {
        #region Properties
        public string ProjectNum
        {
            get;
            set;
        }
        public string ProjectName
        {
            get;
            set;
        }
        public string ProjectLocation
        {
            get;
            set;
        }
        public string baseProject
        {
            get;
            set;
        }
        public int Active
        {
            get;
            set;

        }
        public string CompanyName
        {
            get;
            set;
        }
        #endregion Properties

        #region BindTree
        public void BindTree(RadTreeView myTree)
        {
            myTree.Nodes.Clear();


            RadTreeNode rtn = new RadTreeNode("Project List", "Project Creation");//<a href="../FlyCnMasters/DynamicMaster.aspx?Mode=Country" target="contentPane">Country</a>
            rtn.NavigateUrl = "../ProjectParameters/ManageProject.aspx";
            rtn.Target = "contentPane";
            myTree.Nodes.Add(rtn);

        }
        #endregion BindTree

        #region GetProjectDetails
        public DataTable GetProjectDetails()
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            SqlDataAdapter daObj;
            try
            {

                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                string selectQuery = "select ProjectNo,ProjectName,ProjectLocation,Active,CompName from SYS_projects";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                daObj = new SqlDataAdapter(cmdSelect);
                daObj.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion GetProjectDetails

        #region EditProjectParameters
        public int EditProjectParameters(string projno)
        {
            int result = 0;
            SqlConnection con = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                string editQuery = "";
                SqlCommand cmdEdit = new SqlCommand(editQuery, con);
                cmdEdit.CommandType = CommandType.StoredProcedure;
                cmdEdit.Parameters.AddWithValue("@projectno", ProjectNum);
                cmdEdit.Parameters.AddWithValue("@name", ProjectName);
                cmdEdit.Parameters.AddWithValue("@location", ProjectLocation);
                cmdEdit.Parameters.AddWithValue("@active", ProjectLocation);
                cmdEdit.Parameters.AddWithValue("@location", ProjectLocation);
                result = cmdEdit.ExecuteNonQuery();

             }
            catch (SqlException ex)
            {
                throw ex;
            }
            return result;
        #endregion EditProjectParameters 
        }
        #region GetProjectParameters
        public DataTable GetProjectParameters(string ProjNo)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            SqlDataAdapter daObj;
            try
            {

                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                string selectQuery = "GetProjectDetailsSYS_Projects";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@projectno", ProjNo);
                daObj = new SqlDataAdapter(cmdSelect);
                daObj.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion GetProjectParameters
    }
}
