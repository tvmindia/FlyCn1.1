using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Telerik.Web.UI;
using System.Data;
namespace FlyCn.FlyCnDAL
{
    public class BoqHeaderDetails
    {
        public DocumentMaster documentMaster = new DocumentMaster();
        #region Billofquantityproperties

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

        #endregion Boqheaderproperty
        #region Boqdetailproperty
        public int ItemNo
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public Double Quantity
        {
            get;
            set;
        }
        public string Unit
        {
            get;
            set;
        }
        public Double NormHours
        {
            get;
            set;
        }
        public Double LabourRate
        {
            get;
            set;
        }
        public string LabourRateType
        {
            get;
            set;

        }
        public Double MaterialRate
        {
            get;
            set;
        }
        public Double UDFRate1
        {
            get;
            set;
        }
        public string UDFRateType1
        {
            get;
            set;
        }
        public Double UDFRate2
        {
            get;
            set;
        }
        public string UDFRateType2
        {
            get;
            set;
        }
        public Double UDFRate3
        {
            get;
            set;
        }
        public string UDFRateType3
        {
            get;
            set;
        }
        public Double UDFRate4
        {
            get;
            set;
        }
        public string UDFRateType4
        {
            get;
            set;
        }
        public Double UDFRate5
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

    #endregion Billofquantityproperties



        #region Billofquantitymethods
        public void BindTree(RadTreeView myTree)
        {
           myTree.Nodes.Clear();
        }
        public void LoadInputScreen(RadPane myContentPane)
        {
           myContentPane.ContentUrl = "BOQHeader.aspx";
        }
        /// <summary>
        /// inserting Boq header and details
        /// </summary>
        public void AddNewBOQ()
        {
            SqlConnection con = null;
            try
            {
               
                documentMaster.AddNewDocument();
                
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

                boqcmd.ExecuteNonQuery();
                if(int.Parse(OutparamId.Value.ToString())!=0)
                {
                    //not successfull
                }
                else
                {
                    //successfull
                }
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(con!=null)
                {
                    con.Dispose();
                }

            }
        }


        #endregion Billofquantitymethods

    }
       
}