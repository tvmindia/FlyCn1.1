﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;


namespace FlyCn.FlyCnDAL
{
    public class ProjectParameters
    {
        public void BindTree(RadTreeView myTree)
        {
            myTree.Nodes.Clear();
            RadTreeNode rtn = new RadTreeNode("Project List", "Project Creation"); //<a href="../FlyCnMasters/DynamicMaster.aspx?Mode=Country" target="contentPane">Country</a>
            rtn.NavigateUrl = "../ProjectParameters/ManageProject.aspx";
            rtn.Target = "contentPane";
            myTree.Nodes.Add(rtn);

        }

        #region Properties

        public DateTime Updated_Date
        {
            get;
            set;
        }
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
        public string Company_Logo
        {
            get;
            set;
        }
        public string Client_Logo
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
        #endregion Properties


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
                cmd.Parameters.AddWithValue("@Active",Active);
                cmd.Parameters.AddWithValue("@CompName", CompName);
                cmd.Parameters.AddWithValue("@CompAdd1", CompAdd1);
                cmd.Parameters.AddWithValue("@CompAdd2", CompAdd2);
                cmd.Parameters.AddWithValue("@CompTeleNo", CompTeleNo);
                cmd.Parameters.AddWithValue("@CompFaxNo", CompFaxNo);
                cmd.Parameters.AddWithValue("@CompEmailAdd", CompEmailAdd);
                cmd.Parameters.AddWithValue("@CompWebSite", CompWebSite);
                cmd.Parameters.AddWithValue("@ClientName", ClientName);
                cmd.Parameters.AddWithValue("@ContractNo",ContractNo);
                cmd.Parameters.AddWithValue("@FromCompCode", FromCompCode);
                cmd.Parameters.AddWithValue("@ToCompCode", ToCompCode);           
                    cmd.Parameters.AddWithValue("@Plant_Caption",Plant_Caption);
                    cmd.Parameters.AddWithValue("@Area_Caption", Area_Caption);            
                cmd.Parameters.AddWithValue("@Location_Caption", Location_Caption);
                cmd.Parameters.AddWithValue("@TO_System_Caption",TO_System_Caption);
                cmd.Parameters.AddWithValue("@TO_SubSystem_Caption", TO_SubSystem_Caption);
                cmd.Parameters.AddWithValue("@SchCaptionLevel1",SchCaptionLevel1);
                cmd.Parameters.AddWithValue("@SchCaptionLevel2", SchCaptionLevel2);
                cmd.Parameters.AddWithValue("@SchCaptionLevel3", SchCaptionLevel3);
                cmd.Parameters.AddWithValue("@CaptionForOtherCost1",CaptionForOtherCost1);
                cmd.Parameters.AddWithValue("@CaptionForOtherCost2",CaptionForOtherCost2);
                cmd.Parameters.AddWithValue("@CaptionForOtherCost3", CaptionForOtherCost3);
                cmd.Parameters.AddWithValue("@PaymentCurrency",PaymentCurrency);
                cmd.Parameters.AddWithValue("@LunchBreak_Minutes",LunchBreak_Minutes);
                cmd.Parameters.AddWithValue("@Regional_ImplEngineer",Regional_ImplEngineer);
                cmd.Parameters.AddWithValue("@Project_Administrator", Project_Administrator);
                cmd.Parameters.AddWithValue("@Weld_Client1Caption", Weld_Client1Caption);
                cmd.Parameters.AddWithValue("@Weld_Client2Caption", Weld_Client2Caption);
                cmd.Parameters.AddWithValue("@Weld_ThirdPartyCaption",Weld_ThirdPartyCaption);
                cmd.Parameters.AddWithValue("@Company_Logo",Company_Logo);
                cmd.Parameters.AddWithValue("@Client_Logo",Client_Logo);
                cmd.Parameters.AddWithValue("@MiscManpowerTracking_Caption", MiscManpowerTracking_Caption);
                cmd.ExecuteScalar();
                //var page = HttpContext.Current.CurrentHandler as Page;
                //eObj.InsertionSuccessData(page);
                return 1;
            }
            catch (Exception ex)
            {
                //return 0;
                throw ex;



            }
            finally
            {
                con.Close();

            }
            return result;

        }
    }
}