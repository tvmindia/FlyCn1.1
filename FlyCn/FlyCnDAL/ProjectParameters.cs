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
                cmdEdit.Parameters.AddWithValue("@ProjectNo", ProjectNum);
                cmdEdit.Parameters.AddWithValue("@ProjectName", ProjectName);
                cmdEdit.Parameters.AddWithValue("@ProjectLocation", ProjectLocation);
                //cmdEdit.Parameters.AddWithValue("@BaseProject", BaseProject);
                cmdEdit.Parameters.AddWithValue("@Active", Active);
                cmdEdit.Parameters.AddWithValue("@CompName", CompanyName);
                cmdEdit.Parameters.AddWithValue("@CompAdd1", );
                cmdEdit.Parameters.AddWithValue("@CompAdd2", CompAdd2);
                cmdEdit.Parameters.AddWithValue("@CompTeleNo", CompTeleNo);
                cmdEdit.Parameters.AddWithValue("@CompFaxNo", CompFaxNo);
                cmdEdit.Parameters.AddWithValue("@CompEmailAdd", CompEmailAdd);
                cmdEdit.Parameters.AddWithValue("@CompWebSite", CompWebSite);
                cmdEdit.Parameters.AddWithValue("@ClientName", ClientName);
                cmdEdit.Parameters.AddWithValue("@ContractNo", ContractNo);
                cmdEdit.Parameters.AddWithValue("@FromCompCode", FromCompCode);
                cmdEdit.Parameters.AddWithValue("@ToCompCode", ToCompCode);
                cmdEdit.Parameters.AddWithValue("@Plant_Caption", Plant_Caption);
                cmdEdit.Parameters.AddWithValue("@Area_Caption", Area_Caption);
                cmdEdit.Parameters.AddWithValue("@Location_Caption", Location_Caption);
                cmdEdit.Parameters.AddWithValue("@TO_System_Caption", TO_System_Caption);
                cmdEdit.Parameters.AddWithValue("@TO_SubSystem_Caption", TO_SubSystem_Caption);
                cmdEdit.Parameters.AddWithValue("@SchCaptionLevel1", SchCaptionLevel1);
                cmdEdit.Parameters.AddWithValue("@SchCaptionLevel2", SchCaptionLevel2);
                cmdEdit.Parameters.AddWithValue("@SchCaptionLevel3", SchCaptionLevel3);
                cmdEdit.Parameters.AddWithValue("@CaptionForOtherCost1", CaptionForOtherCost1);
                cmdEdit.Parameters.AddWithValue("@CaptionForOtherCost2", CaptionForOtherCost2);
                cmdEdit.Parameters.AddWithValue("@CaptionForOtherCost3", CaptionForOtherCost3);
                cmdEdit.Parameters.AddWithValue("@PaymentCurrency", PaymentCurrency);
                cmdEdit.Parameters.AddWithValue("@LunchBreak_Minutes", LunchBreak_Minutes);
                cmdEdit.Parameters.AddWithValue("@Regional_ImplEngineer", Regional_ImplEngineer);
                cmdEdit.Parameters.AddWithValue("@Project_Administrator", Project_Administrator);
                cmdEdit.Parameters.AddWithValue("@Weld_Client1Caption", Weld_Client1Caption);
                cmdEdit.Parameters.AddWithValue("@Weld_Client2Caption", Weld_Client2Caption);
                cmdEdit.Parameters.AddWithValue("@Weld_ThirdPartyCaption", Weld_ThirdPartyCaption);
                cmdEdit.Parameters.AddWithValue("@Company_Logo", Company_Logo);
                cmdEdit.Parameters.AddWithValue("@Client_Logo", Client_Logo);
                cmdEdit.Parameters.AddWithValue("@MiscManpowerTracking_Caption", MiscManpowerTracking_Caption);
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
