using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Telerik.Web.UI;
using System.Data;
using System.Web.UI;
namespace FlyCn.FlyCnDAL
{
    public class BOQHeaderDetails
    {
        #region private variables
        public DocumentMaster documentMaster = new DocumentMaster();
        public BOQDetails bOQDetails = new BOQDetails();
        ErrorHandling eObj = new ErrorHandling();
        #endregion private variables

        #region Boqheaderproperty
        public string RevisionNo
        {
            get;
            set;
        }
        public DateTime? DocumentDate
        {
            get;
            set;
        }
        public string DocumentTitle
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }
        public string UpdatedBy
        {
            get;
            set;
        }
        public string UpdatedDate
        {
            get;
            set;
        }
        public string RevisionIdFromHiddenfield
        {
            get;
            set;
        }
        public DateTime UpdatedDateGMT
        {
            get;
            set;
        }
        public string DocumentOwner
        {
            get;
            set;
        }
       
        #endregion Boqheaderproperty
     
        #region Billofquantitymethods
        public void BindTree(RadTreeView myTree)
        {
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
           myTree.Nodes.Clear();
           RadTreeNode rtn1 = new RadTreeNode("CloseDocument", "");
           rtn1.Target = "contentPane";
           rtn1.Value = "rtn1";
           myTree.Nodes.Add(rtn1);
           rtn1.Attributes.Add("onclick", "CloseDocument(" + 5 + ")");
            RadTreeNode rtn2 = new RadTreeNode("Ownership Change", "");
            rtn2.Target = "contentPane";
          //  rtn2.Value = "rtn2";
            rtn2.Value = "2";
            myTree.Nodes.Add(rtn2);       
            rtn2.Attributes.Add("onclick", "ChangeOwner()");           
           RadTreeNode rtn3 = new RadTreeNode("Revise Document", "");
           rtn3.Target = "contentPane";
           rtn3.Value = "rtn3";
            myTree.Nodes.Add(rtn3);
            rtn3.Attributes.Add("onclick", "ReviseDocument()");
           RadTreeNode rtn4 = new RadTreeNode("Revision History", "");      
           rtn4.Target = "contentPane";
           rtn4.Value = "rtn4";
           myTree.Nodes.Add(rtn4);
           RadTreeNode rtn5 = new RadTreeNode("Approver List", "");
           rtn5.Target = "contentPane";
           rtn5.Value = "rtn5";
           myTree.Nodes.Add(rtn5);
           rtn5.Attributes.Add("onclick", "linkbuttonClient()");
           //rtn5.Visible = false;
        }

      

        public void LoadInputScreen(RadPane myContentPane)
        {
           myContentPane.ContentUrl = "BOQHeader.aspx";
            
        }
        #region AddNewBOQ
        /// <summary>
        /// inserting New Document,Revision and Boq header
        /// </summary>
        public Guid AddNewBOQ()
        {
            SqlConnection con = null;
            try
            {
               
                documentMaster.AddNewDocument();//New Document and Revision is made here
                
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand boqcmd = new SqlCommand();
                boqcmd.Connection = con;
                boqcmd.CommandType = System.Data.CommandType.StoredProcedure;
                boqcmd.CommandText = "InsertBOQHeader";
                boqcmd.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value = documentMaster.RevisionID;
                boqcmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 10).Value = documentMaster.ProjectNo;
                boqcmd.Parameters.Add("@RevisionNo", SqlDbType.NVarChar, 10).Value = RevisionNo;
                boqcmd.Parameters.Add("@DocumentDate", SqlDbType.SmallDateTime).Value = DocumentDate;
                boqcmd.Parameters.Add("@DocumentTitle", SqlDbType.NVarChar, 250).Value = DocumentTitle;
                boqcmd.Parameters.AddWithValue("@Remarks",Remarks);
                SqlParameter OutparamId= boqcmd.Parameters.Add("@OutparamId", SqlDbType.SmallInt);
                OutparamId.Direction = ParameterDirection.Output;
                SqlParameter OutRevisionId = boqcmd.Parameters.Add("@OutRevisionID", SqlDbType.UniqueIdentifier);
                OutRevisionId.Direction = ParameterDirection.Output;
                boqcmd.ExecuteNonQuery();
                if(int.Parse(OutparamId.Value.ToString())!=0)
                {

                    //not successfull duplicate entry
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.InsertionSuccessData(page,"Given data is already existing,Duplicate Entry!");
                    
                }
                else
                {
                    //successfull
                     documentMaster.RevisionID = (Guid)(OutRevisionId.Value);//returning revison id to store in boq iframe hidddendfield
                     var page = HttpContext.Current.CurrentHandler as Page;
                     eObj.InsertionSuccessData(page);
                }
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                if(con!=null)
                {
                    con.Dispose();
                }

            }
            return documentMaster.RevisionID;
        }
        #endregion AddNewBOQ
        #region UpdateBOQ
        /// <summary>
        /// Updates the BOQHeader
        /// </summary>
        public void UpdateBOQ()
        {
            SqlConnection con = null;
            try
            {
               // BoqHeaderDetails boqHeaderDetails = new BoqHeaderDetails();
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand boqcmd = new SqlCommand();
                boqcmd.Connection = con;
                boqcmd.CommandType = System.Data.CommandType.StoredProcedure;
                boqcmd.CommandText = "UpdateDocumentMaster";
                boqcmd.Parameters.Add("@DocumentID", SqlDbType.UniqueIdentifier).Value = documentMaster.DocumentID;
                boqcmd.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value = documentMaster.RevisionID;
                boqcmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 10).Value = documentMaster.ProjectNo;
                boqcmd.Parameters.Add("@ClientDocNo", SqlDbType.NVarChar, 50).Value = documentMaster.ClientDocNo;
                boqcmd.Parameters.Add("@RevisionNo", SqlDbType.NVarChar, 10).Value = RevisionNo;
                boqcmd.Parameters.Add("@DocumentDate", SqlDbType.SmallDateTime).Value = DocumentDate;
                boqcmd.Parameters.Add("@DocumentTitle", SqlDbType.NVarChar, 250).Value = DocumentTitle;
                boqcmd.Parameters.AddWithValue("@Remarks", Remarks);
                boqcmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 50).Value = UpdatedBy;
                boqcmd.Parameters.Add("@UpdatedDate", SqlDbType.SmallDateTime).Value = UpdatedDate;
                boqcmd.Parameters.Add("@UpdatedDateGMT", SqlDbType.SmallDateTime).Value = UpdatedDateGMT;
                SqlParameter OutparamId = boqcmd.Parameters.Add("@OutparamId", SqlDbType.SmallInt);
                OutparamId.Direction = ParameterDirection.Output;

                boqcmd.ExecuteNonQuery();
                if (int.Parse(OutparamId.Value.ToString()) != 0)
                {
                    //not successfull
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.UpdationSuccessData(page,"Not Updated");
                }
                else
                {
                    //successfull
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.UpdationSuccessData(page);
                }


            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Dispose();
                }

            }
        }
        #endregion UpdateBOQ

        public DataSet GetBOQHeader(Guid RevisionID)
        {
            SqlConnection con = null;
            DataSet ds = null;
            SqlDataAdapter sda = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[GetAllBOQDocumentHeaderByRevisionID]";
                cmd.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value = RevisionID;
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);
                if(ds.Tables[0].Rows.Count>0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    DocumentDate =Convert.ToDateTime(dr["DocumentDate"]);
                    RevisionNo = dr["RevisionNo"].ToString();
                    DocumentTitle = dr["DocumentTitle"].ToString();
                    Remarks = dr["Remarks"].ToString();
                    //UpdatedBy = dr["UpdatedBy"].ToString();
                    //UpdatedDate = dr["UpdatedDate"].ToString();

                }
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
            return ds;
        }

        #endregion Billofquantitymethods

    }

    public class BOQDetails
    {
        #region private variables
        ErrorHandling eObj = new ErrorHandling();
        #endregion private variables

        #region Boqdetailproperty

        public Guid RevisionID
        {
            get;
            set;
        }
        public Guid ItemID
        {
            get;
            set;
        }

        public string ProjectNo
        {
            get;
            set;
        }
        public Int16 ItemNo
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public Single Quantity
        {
            get;
            set;
        }
        public string Unit
        {
            get;
            set;
        }
        public Double? NormHours
        {
            get;
            set;
        }
        public Double? LabourRate
        {
            get;
            set;
        }
        public string LabourRateType
        {
            get;
            set;

        }
        public Double? MaterialRate
        {
            get;
            set;
        }
        public Double? UDFRate1
        {
            get;
            set;
        }
        public string UDFRateType1
        {
            get;
            set;
        }
        public Double? UDFRate2
        {
            get;
            set;
        }
        public string UDFRateType2
        {
            get;
            set;
        }
        public Double? UDFRate3
        {
            get;
            set;
        }
        public string UDFRateType3
        {
            get;
            set;
        }
        public Double? UDFRate4
        {
            get;
            set;
        }
        public string UDFRateType4
        {
            get;
            set;
        }
        public Double? UDFRate5
        {
            get;
            set;
        }
        public string UDFRateType5
        {
            get;
            set;
        }
        public string Group1
        {
            get;
            set;
        }
        public string Group2
        {
            get;
            set;
        }
        public string Group3
        {
            get;
            set;
        }
        public string Group4
        {
            get;
            set;
        }
        public string Group5
        {
            get;
            set;
        }
        #endregion Boqdetailproperty
         
        #region BOQDetailMethods
        #region GetAllBOQDetails
        /// <summary>
        /// Select All BOQDetails
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllBOQDetails()//Accepts two parameters as property setting projectno and Revisonid
        {
            SqlConnection con = null;
            DataSet ds = null;
            SqlDataAdapter sda = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[GetAllBOQDetails]";
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 10).Value = ProjectNo;
                cmd.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value = RevisionID;
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return ds;

        }
        #endregion GetAllBOQDetails

        #region GetBOQDetailsByItemID
        /// <summary>
        /// Select BOQ Detail By item id
        /// </summary>
        /// <returns>BOQ Details</returns>
        public DataSet GetBOQDetailsByItemID() //Brings only one record since itemid is primarykey in BOQDetail table
        {
            SqlConnection con = null;
            DataSet ds = null;
            SqlDataAdapter sda = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[GetBOQDetailsByItemID]";
                cmd.Parameters.Add("@ItemID", SqlDbType.UniqueIdentifier).Value = ItemID;
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return ds;
        }

        #endregion GetBOQDetailsByItemID
        #region  AddBOQDetails
        /// <summary>
        /// Add Boq Details into the table
        /// </summary>
        /// <returns></returns>
        public Guid AddBOQDetails()
        {
           
            SqlConnection con = null;
            try
            {
                //bOQHeaderDetails.bOQDetails.UDFRate2 = (txtUDFRate2.Text.Trim() != "") ? Convert.ToSingle(txtUDFRate2.Text.Trim()) : Convert.ToSingle(null);
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand boqcmd = new SqlCommand();
                boqcmd.Connection = con;
                boqcmd.CommandType = System.Data.CommandType.StoredProcedure;
                boqcmd.CommandText = "[InsertBoqDetails]";
                boqcmd.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value = RevisionID;
                boqcmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 10).Value = ProjectNo;
                boqcmd.Parameters.Add("@ItemDescription", SqlDbType.NVarChar, 250).Value = ItemDescription;
                boqcmd.Parameters.Add("@Quantity", SqlDbType.Real).Value = Quantity;
                boqcmd.Parameters.Add("@Unit", SqlDbType.NVarChar, 10).Value = Unit;
                boqcmd.Parameters.Add("@NormHours", SqlDbType.Real).Value = NormHours;
                boqcmd.Parameters.Add("@LabourRate", SqlDbType.Real).Value = LabourRate;
                boqcmd.Parameters.Add("@LabourRateType", SqlDbType.NVarChar,1).Value = LabourRateType;
                boqcmd.Parameters.Add("@MaterialRate", SqlDbType.Real).Value = MaterialRate;
                boqcmd.Parameters.Add("@UDFRate1", SqlDbType.Real).Value = UDFRate1;
                boqcmd.Parameters.Add("@UDFRateType1", SqlDbType.NVarChar, 1).Value = UDFRateType1;
                boqcmd.Parameters.Add("@UDFRate2", SqlDbType.Real).Value = UDFRate2;
                boqcmd.Parameters.Add("@UDFRateType2", SqlDbType.NVarChar, 1).Value = UDFRateType2;
                boqcmd.Parameters.Add("@UDFRate3", SqlDbType.Real).Value = UDFRate3;
                boqcmd.Parameters.Add("@UDFRateType3", SqlDbType.NVarChar, 1).Value = UDFRateType3;
                boqcmd.Parameters.Add("@UDFRate4", SqlDbType.Real).Value = UDFRate4;
                boqcmd.Parameters.Add("@UDFRateType4", SqlDbType.NVarChar, 1).Value = UDFRateType4;
                boqcmd.Parameters.Add("@UDFRate5", SqlDbType.Real).Value = UDFRate5;
                boqcmd.Parameters.Add("@UDFRateType5", SqlDbType.NVarChar, 1).Value = UDFRateType5;

                boqcmd.Parameters.Add("@Group1", SqlDbType.NVarChar, 50).Value = Group1;
                boqcmd.Parameters.Add("@Group2", SqlDbType.NVarChar, 50).Value = Group2;
                boqcmd.Parameters.Add("@Group3", SqlDbType.NVarChar, 50).Value = Group3;
                boqcmd.Parameters.Add("@Group4", SqlDbType.NVarChar, 50).Value = Group4;
                boqcmd.Parameters.Add("@Group5", SqlDbType.NVarChar, 50).Value = Group5;


               
                SqlParameter OutparmItemId = boqcmd.Parameters.Add("@OutputItemID", SqlDbType.UniqueIdentifier);
                OutparmItemId.Direction = ParameterDirection.Output;
            
                boqcmd.ExecuteNonQuery();

                if (OutparmItemId.Value.ToString()=="")
                {
                   //not successfull   
                    
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.InsertionSuccessData(page,"Insert not Successfull,Duplicate Entry!");

                }
                else
                {
                    //successfull
                    ItemID = (Guid)OutparmItemId.Value;
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.InsertionSuccessData(page);


                }
              

            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }
                 
            finally
            {
                if (con != null)
                {
                    con.Dispose();
                }
               
            }
            return ItemID;
       }
        #endregion  AddBOQDetails

        #region UpdateBOQDocumentDetails
        /// <summary>
        /// Updates the BOQ details based on the itemId
        /// </summary>
        /// <param name="paramItemid"></param>
        /// <returns></returns>
        public string UpdateBOQDocumentDetails(Guid paramItemid)
        {

            SqlConnection con = null;
            string ItemId = "";
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand boqcmd = new SqlCommand();
                boqcmd.Connection = con;
                boqcmd.CommandType = System.Data.CommandType.StoredProcedure;
                boqcmd.CommandText = "[UpdateBOQDetails]";
                boqcmd.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value = RevisionID;
                boqcmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 10).Value = ProjectNo;
                boqcmd.Parameters.Add("@ItemID", SqlDbType.UniqueIdentifier).Value = paramItemid;
                boqcmd.Parameters.Add("@ItemDescription", SqlDbType.NVarChar, 250).Value = ItemDescription;
                boqcmd.Parameters.Add("@Quantity", SqlDbType.Real).Value = Quantity;
                boqcmd.Parameters.Add("@Unit", SqlDbType.NVarChar, 10).Value = Unit;
                boqcmd.Parameters.Add("@NormHours", SqlDbType.Real).Value = NormHours;
                boqcmd.Parameters.Add("@LabourRate", SqlDbType.Real).Value = LabourRate;
                boqcmd.Parameters.Add("@LabourRateType", SqlDbType.NVarChar, 1).Value = LabourRateType;
                boqcmd.Parameters.Add("@MaterialRate", SqlDbType.Real).Value = MaterialRate;
                boqcmd.Parameters.Add("@UDFRate1", SqlDbType.Real).Value = UDFRate1;
                boqcmd.Parameters.Add("@UDFRateType1", SqlDbType.NVarChar, 1).Value = UDFRateType1;
                boqcmd.Parameters.Add("@UDFRate2", SqlDbType.Real).Value = UDFRate2;
                boqcmd.Parameters.Add("@UDFRateType2", SqlDbType.NVarChar, 1).Value = UDFRateType2;
                boqcmd.Parameters.Add("@UDFRate3", SqlDbType.Real).Value = UDFRate3;
                boqcmd.Parameters.Add("@UDFRateType3", SqlDbType.NVarChar, 1).Value = UDFRateType3;
                boqcmd.Parameters.Add("@UDFRate4", SqlDbType.Real).Value = UDFRate4;
                boqcmd.Parameters.Add("@UDFRateType4", SqlDbType.NVarChar, 1).Value = UDFRateType4;
                boqcmd.Parameters.Add("@UDFRate5", SqlDbType.Real).Value = UDFRate5;
                boqcmd.Parameters.Add("@UDFRateType5", SqlDbType.NVarChar, 1).Value = UDFRateType5;
                boqcmd.Parameters.Add("@Group1", SqlDbType.NVarChar, 50).Value = Group1;
                boqcmd.Parameters.Add("@Group2", SqlDbType.NVarChar, 50).Value = Group2;
                boqcmd.Parameters.Add("@Group3", SqlDbType.NVarChar, 50).Value = Group3;
                boqcmd.Parameters.Add("@Group4", SqlDbType.NVarChar, 50).Value = Group4;
                boqcmd.Parameters.Add("@Group5", SqlDbType.NVarChar, 50).Value = Group5;
                SqlParameter OutparamId = boqcmd.Parameters.Add("@OutputParamId", SqlDbType.SmallInt);
                SqlParameter OutparmItemId = boqcmd.Parameters.Add("@OutputItemID", SqlDbType.UniqueIdentifier);
                OutparmItemId.Direction = ParameterDirection.Output;
                OutparamId.Direction = ParameterDirection.Output;
                boqcmd.ExecuteNonQuery();
                if (int.Parse(OutparamId.Value.ToString()) != 0)
                {
                    //not successfull   
                    ItemId = OutparmItemId.Value.ToString();
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.UpdationSuccessData(page,"Not Updated");
                }
                else
                {
                    //successfull
                    ItemId = OutparmItemId.Value.ToString();
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.UpdationSuccessData(page);
                }
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Dispose();
                }
            }
            return ItemId;
        }
        #endregion UpdateBOQDocumentDetails
        #region DeleteBOQDocumentDetails
        /// <summary>
        /// Deletes BOQ Details based on the itemid
        /// </summary>
        /// <param name="Itemid"></param>
        public void DeleteBOQDocumentDetails(Guid Itemid)
        {
            SqlConnection con = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand boqcmd = new SqlCommand();
                boqcmd.Connection = con;
                boqcmd.CommandType = System.Data.CommandType.StoredProcedure;
                boqcmd.CommandText = "[DeleteBOQDocumentDetails]";
                boqcmd.Parameters.Add("@ItemID", SqlDbType.UniqueIdentifier).Value = Itemid;
                SqlParameter OutparamId = boqcmd.Parameters.Add("@OutputParamId", SqlDbType.SmallInt);
                OutparamId.Direction = ParameterDirection.Output;
                boqcmd.ExecuteNonQuery();
                if (int.Parse(OutparamId.Value.ToString()) != 0)
                {
                 //not successfull   
                  var page = HttpContext.Current.CurrentHandler as Page;
                 // eObj.DeleteSuccessData(page);
                }
                else
                {
                 //successfull
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.DeleteSuccessData(page);
                }
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Dispose();
                }
            }
        }
        #endregion DeleteBOQDocumentDetails

        #endregion BOQDetailMethods
    }
       
}