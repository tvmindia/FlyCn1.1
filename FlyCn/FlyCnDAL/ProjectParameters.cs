using FlyCnSecurity.SecurityDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;


namespace FlyCn.FlyCnDAL
{

    public class ProjectParameters
    {  
        #region Global Variables
        ErrorHandling eObj = new ErrorHandling();
          #endregion Global Variables

        #region Properties


        public string ProjectNo
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
        public string ProjectManager
        {
            get;
            set;
        }
        public string BaseProject
        {
            get;
            set;
        }
        public byte Active
        {
            get;
            set;
        }
        public string CompName
        {
            get;
            set;
        }
        public string CompAdd1
        {
            get;
            set;
        }
        public string CompAdd2
        {
            get;
            set;
        }
        public string CompTeleNo
        {
            get;
            set;
        }
        public string CompFaxNo
        {
            get;
            set;
        }
        public string CompEmailAdd
        {
            get;
            set;
        }
        public string CompWebSite
        {
            get;
            set;
        }
        public string ClientName
        {
            get;
            set;
        }
        public string ContractNo
        {
            get;
            set;
        }
        public string FromCompCode
        {
            get;
            set;
        }
        public string ToCompCode
        {
            get;
            set;
        }
        public string Plant_Caption
        {
            get;
            set;
        }
        public string Area_Caption
        {
            get;
            set;
        }
        public string Location_Caption
        {
            get;
            set;
        }
        public string TO_System_Caption
        {
            get;
            set;
        }
        public string TO_SubSystem_Caption
        {
            get;
            set;
        }
        public string SchCaptionLevel1
        {
            get;
            set;
        }
        public string SchCaptionLevel2
        {
            get;
            set;
        }
        public string SchCaptionLevel3
        {
            get;
            set;
        }
        public string CaptionForOtherCost1
        {
            get;
            set;
        }
        public string CaptionForOtherCost2
        {
            get;
            set;
        }
        public string CaptionForOtherCost3
        {
            get;
            set;
        }
        public string PaymentCurrency
        {
            get;
            set;
        }
        public string Regional_ImplEngineer
        {
            get;
            set;
        }
        public string Project_Administrator
        {
            get;
            set;
        }
        public string Weld_Client1Caption
        {
            get;
            set;
        }
        public string Weld_Client2Caption
        {
            get;
            set;
        }
        public string Weld_ThirdPartyCaption
        {
            get;
            set;
        }

        public object Company_Logo
        {
            get;
            set;
        }
        public object Client_Logo
        {
            get;
            set;
        }
        public string MiscManpowerTracking_Caption
        {
            get;
            set;
        }
        public decimal LunchBreak_Minutes
        {
            get;
            set;
        }

        public string RoleName
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }

        //public string ProjectNum
        //{
        //    get;
        //    set;
        //}
        //public string ProjectName
        //{
        //    get;
        //    set;
        //}
        //public string ProjectLocation
        //{
        //    get;
        //    set;
        //}
        //public string BaseProject
        //{
        //    get;
        //    set;
        //}
        //public byte Active
        //{
        //    get;
        //    set;
        //}
        //public string CompName
        //{
        //    get;
        //    set;
        //}
        //public string CompAdd1
        //{
        //    get;
        //    set;
        //}
        //public string CompAdd2
        //{
        //    get;
        //    set;
        //}
        //public string CompTeleNo
        //{
        //    get;
        //    set;
        //}
        //public string CompFaxNo
        //{
        //    get;
        //    set;
        //}
        //public string CompEmailAdd
        //{
        //    get;
        //    set;
        //}
        //public string CompWebSite
        //{
        //    get;
        //    set;
        //}
        //public string ClientName
        //{
        //    get;
        //    set;
        //}
        //public string ContractNo
        //{
        //    get;
        //    set;
        //}
        //public string FromCompCode
        //{
        //    get;
        //    set;
        //}
        //public string ToCompCode
        //{
        //    get;
        //    set;
        //}
        //public string Plant_Caption
        //{
        //    get;
        //    set;
        //}
        //public string Area_Caption
        //{
        //    get;
        //    set;
        //}
        //public string Location_Caption
        //{
        //    get;
        //    set;
        //}
        //public string TO_System_Caption
        //{
        //    get;
        //    set;
        //}
        //public string TO_SubSystem_Caption
        //{
        //    get;
        //    set;
        //}
        //public string SchCaptionLevel1
        //{
        //    get;
        //    set;
        //}
        //public string SchCaptionLevel2
        //{
        //    get;
        //    set;
        //}
        //public string SchCaptionLevel3
        //{
        //    get;
        //    set;
        //}
        //public string CaptionForOtherCost1
        //{
        //    get;
        //    set;
        //}
        //public string CaptionForOtherCost2
        //{
        //    get;
        //    set;
        //}
        //public string CaptionForOtherCost3
        //{
        //    get;
        //    set;
        //}
        //public string PaymentCurrency
        //{
        //    get;
        //    set;
        //}
        //public string Regional_ImplEngineer
        //{
        //    get;
        //    set;
        //}
        //public string Project_Administrator
        //{
        //    get;
        //    set;
        //}
        //public string Weld_Client1Caption
        //{
        //    get;
        //    set;
        //}
        //public string Weld_Client2Caption
        //{
        //    get;
        //    set;
        //}
        //public string Weld_ThirdPartyCaption
        //{
        //    get;
        //    set;
        //}
        //public string Company_Logo
        //{
        //    get;
        //    set;
        //}
        //public string Client_Logo
        //{
        //    get;
        //    set;
        //}
        //public string MiscManpowerTracking_Caption
        //{
        //    get;
        //    set;
        //}
        //public decimal LunchBreak_Minutes
        //{
        //    get;
        //    set;
        //}

        #endregion Properties

        #region BindTree
        //public void BindTree(RadTreeView myTree)
        //{
        //    myTree.Nodes.Clear();
        //    RadTreeNode rtn = new RadTreeNode("Project List", "Project Creation");//<a href="../FlyCnMasters/DynamicMaster.aspx?Mode=Country" target="contentPane">Country</a>
        //    rtn.NavigateUrl = "../ProjectParameters/ManageProject.aspx";
        //    rtn.Target = "contentPane";
        //    myTree.Nodes.Add(rtn);

        //}




        public void BindTree(RadTreeView myTree)
        {
            myTree.Nodes.Clear();
        }
        public void LoadInputScreen(RadPane myContentPane)
        {
            myContentPane.ContentUrl = "../ProjectParameters/ManageProject.aspx";
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
                string editQuery = "UpdateProjectNoSYS_Projects";
                SqlCommand cmdEdit = new SqlCommand(editQuery, con);
                cmdEdit.CommandType = CommandType.StoredProcedure;
                cmdEdit.Parameters.AddWithValue("@ProjectNo", ProjectNo);
                cmdEdit.Parameters.AddWithValue("@ProjectName", ProjectName);
                cmdEdit.Parameters.AddWithValue("@ProjectLocation", ProjectLocation);
                cmdEdit.Parameters.AddWithValue("@BaseProject", BaseProject);
                cmdEdit.Parameters.AddWithValue("@Project_Manager", ProjectManager);

                cmdEdit.Parameters.AddWithValue("@Active", Active);
                cmdEdit.Parameters.AddWithValue("@CompName", CompName);
                cmdEdit.Parameters.AddWithValue("@CompAdd1", CompAdd2);
                cmdEdit.Parameters.AddWithValue("@CompAdd2", CompAdd2);
                cmdEdit.Parameters.AddWithValue("@CompTeleNo", CompTeleNo);
                cmdEdit.Parameters.AddWithValue("@CompFaxNo", CompFaxNo);
                cmdEdit.Parameters.AddWithValue("@CompEmailAdd", CompEmailAdd);
                cmdEdit.Parameters.AddWithValue("@CompWebSite", CompWebSite);
                cmdEdit.Parameters.AddWithValue("@ClientName", ClientName);
                if (ContractNo != "")
                {
                    cmdEdit.Parameters.AddWithValue("@ContractNo", ContractNo);

                }

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
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.UpdationSuccessData(page);
                return 1;
            }
            catch (SqlException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            return result;
        }
        #endregion EditProjectParameters

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
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;

            }

        }
        #endregion GetProjectParameters

        #region InsertSYSProjectsData
        public int InsertSYSProjectsData()
        {
            ErrorHandling eObj = new ErrorHandling();
            int result = 0;
            SqlConnection con = null;
            try
            {
                DataSet dataset = new DataSet();
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertSYSProjects";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ProjectNo", ProjectNo);
                cmd.Parameters.AddWithValue("@ProjectName", ProjectName);
                cmd.Parameters.AddWithValue("@ProjectLocation", ProjectLocation);
                cmd.Parameters.AddWithValue("@BaseProject", BaseProject);
                cmd.Parameters.AddWithValue("@Project_Manager", ProjectManager);

                cmd.Parameters.AddWithValue("@Active", Active);
                cmd.Parameters.AddWithValue("@CompName", CompName);
                cmd.Parameters.AddWithValue("@CompAdd1", CompAdd1);
                cmd.Parameters.AddWithValue("@CompAdd2", CompAdd2);
                cmd.Parameters.AddWithValue("@CompTeleNo", CompTeleNo);
                cmd.Parameters.AddWithValue("@CompFaxNo", CompFaxNo);
                cmd.Parameters.AddWithValue("@CompEmailAdd", CompEmailAdd);
                cmd.Parameters.AddWithValue("@CompWebSite", CompWebSite);
                cmd.Parameters.AddWithValue("@ClientName", ClientName);
                if (ContractNo != "")
                {
                    cmd.Parameters.AddWithValue("@ContractNo", ContractNo);

                }
                cmd.Parameters.AddWithValue("@FromCompCode", FromCompCode);
                cmd.Parameters.AddWithValue("@ToCompCode", ToCompCode);
                cmd.Parameters.AddWithValue("@Plant_Caption", Plant_Caption);
                cmd.Parameters.AddWithValue("@Area_Caption", Area_Caption);
                cmd.Parameters.AddWithValue("@Location_Caption", Location_Caption);
                cmd.Parameters.AddWithValue("@TO_System_Caption", TO_System_Caption);
                cmd.Parameters.AddWithValue("@TO_SubSystem_Caption", TO_SubSystem_Caption);
                cmd.Parameters.AddWithValue("@SchCaptionLevel1", SchCaptionLevel1);
                cmd.Parameters.AddWithValue("@SchCaptionLevel2", SchCaptionLevel2);
                cmd.Parameters.AddWithValue("@SchCaptionLevel3", SchCaptionLevel3);
                cmd.Parameters.AddWithValue("@CaptionForOtherCost1", CaptionForOtherCost1);
                cmd.Parameters.AddWithValue("@CaptionForOtherCost2", CaptionForOtherCost2);
                cmd.Parameters.AddWithValue("@CaptionForOtherCost3", CaptionForOtherCost3);
                cmd.Parameters.AddWithValue("@PaymentCurrency", PaymentCurrency);
                cmd.Parameters.AddWithValue("@LunchBreak_Minutes", LunchBreak_Minutes);
                cmd.Parameters.AddWithValue("@Regional_ImplEngineer", Regional_ImplEngineer);
                cmd.Parameters.AddWithValue("@Project_Administrator", Project_Administrator);
                cmd.Parameters.AddWithValue("@Weld_Client1Caption", Weld_Client1Caption);
                cmd.Parameters.AddWithValue("@Weld_Client2Caption", Weld_Client2Caption);
                cmd.Parameters.AddWithValue("@Weld_ThirdPartyCaption", Weld_ThirdPartyCaption);
                // cmd.Parameters.AddWithValue("@Company_Logo",s).Value=Company_Logo
                //cmd.Parameters.AddWithValue("@Company_Logo",Company_Logo);
                cmd.Parameters.Add("@Company_Logo", SqlDbType.VarBinary).Value = Company_Logo;
                cmd.Parameters.Add("@Client_Logo", SqlDbType.VarBinary).Value = Client_Logo;
                /// cmd.Parameters.AddWithValue("@Client_Logo",DBNull.Value);
                cmd.Parameters.AddWithValue("@MiscManpowerTracking_Caption", MiscManpowerTracking_Caption);
                cmd.ExecuteScalar();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.InsertionSuccessData(page);
                return 1;
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            finally
            {
                con.Close();

            }
            return result;

        }

        #endregion InsertSYSProjectsData

        #region DeleteSYSProjectsData
        /// <summary>
        /// Delete SYSProjectsData Data 
        /// </summary>
        /// <param name="code"></param>
        /// <returns> return integer value</returns>
        public int DeleteSYSProjectsData(string ProjectNo)
        {

            SqlConnection conObj = null;
            try
            {
                dbConnection dcon = new dbConnection();
                conObj = dcon.GetDBConnection();


                SqlCommand cmd = new SqlCommand("DeleteSysProjects", conObj);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectNo", ProjectNo);
                cmd.ExecuteScalar();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.DeleteSuccessData(page);
                return 1;
            }
            catch (SqlException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            finally
            {
                conObj.Close();
            }
            return 0;
        }
        #endregion DeleteSYSProjectsData

        #region BindProjectNo
        public DataTable BindProjectNo()
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("SelectPrjectNo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                datatableobj = new DataTable();
                adapter.Fill(datatableobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return datatableobj;
        }
        #endregion BindProjectNo

        #region GetAllProjectRoles
        public DataTable GetAllProjectRoles(string ProjectNo)
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            DBconnection dcon = new DBconnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetAllProjectRoles", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar,10).Value = ProjectNo;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                datatableobj = new DataTable();
                adapter.Fill(datatableobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return datatableobj;
        }
        #endregion GetAllProjectRoles

        #region InsertProjectRoles
        public DataTable InsertProjectRoles(string ProjectNo)
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            DBconnection dcon = new DBconnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("InsertProjectRoles", con);
                cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 10).Value = ProjectNo;
                cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar,50).Value = RoleName;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 250).Value = Description;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                datatableobj = new DataTable();
                adapter.Fill(datatableobj);
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.InsertionSuccessData(page, "Data Saved Successfully..!!!");
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return datatableobj;
        }
        #endregion InsertProjectRoles


    }
}
