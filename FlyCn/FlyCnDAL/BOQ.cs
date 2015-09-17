using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

namespace FlyCn.FlyCnDAL
{
    public class BOQ
    {
    #region Billofquantityproperties

         #region Boqheaderproperty
        public string RevisionNo
        {
            get;
            set;
        }
        public DateTime DocumentDate
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
        public void Insertboq()
        {
            try
            {
                SqlConnection con = null;
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand boqcmd = new SqlCommand();
                boqcmd.Connection = con;
                boqcmd.CommandType = System.Data.CommandType.StoredProcedure;
                boqcmd.CommandText = "";
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");
                boqcmd.Parameters.Add("");


            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }


        #endregion Billofquantitymethods

    }
       
}