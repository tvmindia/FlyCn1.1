using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;

namespace FlyCn.FlyCnDAL
{
    public class CategoryAllocation
    {
        ErrorHandling eObj = new ErrorHandling();

        #region public properties
        public string projectNo
        {
            get;
            set;
        }
        public string moduleId
        {
            get;
            set;
        }
        public string category
        {
            get;
            set;
        }
        public string tagNo
        {
            get;
            set;
        }
        public string updatedBy
        {
            get;
            set;
        }
        public DateTime updatedDate
        {
            get;
            set;
        }
        #endregion public properties

        #region InsertCategoryToAllocatedTags
        public void InsertCategoryToAllocatedTags(string tagNoField,string categoryField)
        {
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            updatedBy = UA.userName;
            SqlConnection con = null;

            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("InsertCategoryToAllocatedTags", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 7).Value = UA.projectNo;
                cmd.Parameters.Add("@ModuleId", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 25).Value = categoryField;
                cmd.Parameters.Add("@TagNo", SqlDbType.NVarChar, 50).Value = tagNoField;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 256).Value = updatedBy;
                cmd.Parameters.Add("@updatedDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd");

                cmd.ExecuteNonQuery();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.InsertionSuccessData(page);
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

        }
        #endregion InsertCategoryToAllocatedTags

        public void LoadRootNodes(RadTreeView myTree, TreeNodeExpandMode expandMode)
        {
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            FlyCn.FlyCnDAL.Modules moduleObj = new FlyCn.FlyCnDAL.Modules();
            DataSet data = new DataSet();
            data = moduleObj.GetModules(UA.projectNo);
            myTree.Nodes.Clear();
            foreach (DataRow row in data.Tables[0].Rows)
            {
                RadTreeNode node = new RadTreeNode();
                node.Text = row["ModuleDesc"].ToString();
                node.Value = row["ModuleID"].ToString();
                node.ExpandMode = expandMode;
                myTree.Nodes.Add(node);
            }

        }

        #region BindData()
        public DataTable BindData(string TableName, string ProjNo,string moduleID=null,bool ISbaseTable=false)
        {
            string FieldValue = "";
            string result = "";
            DataTable dt = null;
            dbConnection dcon = new dbConnection();
          
            try
            {
                dcon.GetDBConnection();
                SystemDefenitionDetails sd = new SystemDefenitionDetails();
                if (ISbaseTable)
                {
                    dt = sd.getFieldNames(TableName, ProjNo, true);
                }
                else
                {
                    dt = sd.getFieldNames(TableName, ProjNo);
                }

                if ((dt.Rows.Count > 0) || (dt != null))
                {
                    string temp = dt.Rows[0]["Field_Name"].ToString();
                    SqlCommand cmd = new SqlCommand("GetAllocateTags", dcon.SQLCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                   // cmd.Parameters.AddWithValue("@TableName", TableName);
                    //cmd.Parameters.AddWithValue("@ModuleID", moduleID);
                    if (temp == "ProjNo")
                    {
                        cmd.Parameters.AddWithValue("@ProjectNo", ProjNo);
                        FieldValue = "ProjNo";
                        for (int i = 1; i < dt.Rows.Count; i++)
                        {
                            FieldValue = FieldValue + "," + dt.Rows[i]["Field_Name"];
                        }
                        FieldValue = FieldValue + "";
                        cmd.Parameters.AddWithValue("@p_selectedFields", FieldValue);
                    }
                    else
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            FieldValue = FieldValue + dt.Rows[i]["Field_Name"] + ",";
                        }
                        FieldValue = FieldValue + ",";
                        FieldValue = FieldValue.TrimEnd(',');
                        result = FieldValue + ",";
                        cmd.Parameters.AddWithValue("@p_selectedFields", result);
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion BindData()
    }
}