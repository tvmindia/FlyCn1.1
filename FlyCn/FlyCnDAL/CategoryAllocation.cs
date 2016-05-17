using FlyCnSecurity.SecurityDAL;
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

        //public void LoadRootNodes(RadTreeView myTree, TreeNodeExpandMode expandMode)
        //{
          
        //    UIClasses.Const Const = new UIClasses.Const();
        //    FlyCnDAL.Security.UserAuthendication UA;
        //    HttpContext context = HttpContext.Current;
        //    UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
        //    FlyCn.FlyCnDAL.Modules moduleObj = new FlyCn.FlyCnDAL.Modules();
        //    FlyCn.FlyCnDAL.Users userObj = new FlyCn.FlyCnDAL.Users();
        //    DataSet data = new DataSet();
        //    data = moduleObj.GetModules(UA.projectNo);
        //    myTree.Nodes.Clear();
        //    foreach (DataRow row in data.Tables[0].Rows)
        //    {
        //        RadTreeNode node = new RadTreeNode();
        //        node.Text = row["ModuleDesc"].ToString();
        //        node.Value = row["ModuleID"].ToString();
        //        node.ExpandMode = expandMode;
        //        myTree.Nodes.Add(node);
               
        //    }
        //    //myTree.on += new RadTreeViewEventHandler(RadTreeView_NodeExpanded);
        //}

        //private void RadTreeView_NodeExpanded(object sender, RadTreeNodeEventArgs e)
        //{
        //    FlyCnDAL.Users userObj = new FlyCnDAL.Users();
        //    DataTable data = userObj.GetAllCategories("CIV");
        //    string moduleId = "CIV";
        //    HttpContext.Current.Session["moduleId"] = moduleId;
        //    foreach (DataRow row in data.Rows)
        //    {
        //        RadTreeNode node = new RadTreeNode();
        //        node.Text = row["CategoryDesc"].ToString();
        //        node.Value = row["Category"].ToString();
        //        //if (Convert.ToInt32(row["Category"]) > 0)
        //        //{
        //        //    node.ExpandMode = expandMode;
        //        //}
        //        e.Node.Nodes.Add(node);
        //    }

        //    e.Node.Expanded = true;

        //}

        #region BindData()
        public DataTable BindData(string TableName, string moduleID,string category,bool ISbaseTable=false)
        {
            string FieldValue = "";
            string result = "";
            DataTable dt = null;
            dbConnection dcon = new dbConnection();
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            try
            {
                dcon.GetDBConnection();
                SystemDefenitionDetails sd = new SystemDefenitionDetails();
                if (ISbaseTable)
                {
                    dt = sd.getFieldNames(TableName, UA.projectNo, true);
                }
                else
                {
                    dt = sd.getFieldNames(TableName, UA.projectNo);
                }

                if ((dt.Rows.Count > 0) || (dt != null))
                {
                    string temp = dt.Rows[0]["Field_Name"].ToString();
                    SqlCommand cmd = new SqlCommand("GetAllocateTags", dcon.SQLCon);
                    cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 7).Value = UA.projectNo;
                    cmd.Parameters.Add("@ModuleID", SqlDbType.NVarChar, 10).Value = moduleID;
                    cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 25).Value = category;
                    cmd.CommandType = CommandType.StoredProcedure;
                   // cmd.Parameters.AddWithValue("@TableName", TableName);
                    //cmd.Parameters.AddWithValue("@ModuleID", moduleID);
                   
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            FieldValue = FieldValue + dt.Rows[i]["Field_Name"] + ",";
                        }
                        FieldValue = FieldValue + ",";
                        FieldValue = FieldValue.TrimEnd(',');
                        result = FieldValue + ",";
                        cmd.Parameters.AddWithValue("@p_selectedFields", result);
                  
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
               

            }
            return dt;
        }
        #endregion BindData()

        #region BindAvailableTags
        /// <summary>
        /// bind dynamic master datas
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="ProjNo"></param>
        /// <returns> return datatable</returns>
        public DataTable BindAvailableTags(string TableName, string ProjNo, string moduleID=null,int keyField=0, bool ISbaseTable = false)
        {
            //string TableName = "M_Country";
            //string ProjNo = "C00001";
            string FieldValue = "";
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
                    SqlCommand cmd = new SqlCommand("BindAvailableTags", dcon.SQLCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", TableName);
                    cmd.Parameters.AddWithValue("@ModuleID", moduleID);
                        cmd.Parameters.AddWithValue("@ProjectNo", ProjNo);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            FieldValue = FieldValue + dt.Rows[i]["Field_Name"] + ",";
                        }
                        FieldValue = FieldValue + "";
                        FieldValue = FieldValue.TrimEnd(',');
                        cmd.Parameters.AddWithValue("@p_selectedFields", FieldValue);
                        cmd.Parameters.AddWithValue("@keyField", keyField);
                    
                    //SqlParameter param=cmd.Parameters.Add("@out",SqlDbType.NVarChar,-1);
                    //param.Direction = ParameterDirection.Output;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    
                    dt = new DataTable();
                    adapter.Fill(dt);
                    
                }
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
               
            }
            finally
            {
                if (dcon.SQLCon != null)
                {
                    dcon.DisconectDB();
                }
            }
            return dt;
        }

        #endregion BindAvailableTags

        #region DeleteFromAllocatedTags
        public void DeleteFromAllocatedTags(string moduleId, string category,string tagNo)
        {
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("DeleteAllocatedTags", con);
                cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 7).Value = UA.projectNo;
                cmd.Parameters.Add("@ModuleID", SqlDbType.NVarChar,10).Value = moduleId;
                cmd.Parameters.Add("@category", SqlDbType.NVarChar, 25).Value = category;
                cmd.Parameters.Add("@TagNo", SqlDbType.NVarChar,50).Value = tagNo;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                cmd.ExecuteNonQuery();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.DeleteSuccessData(page);
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
        #endregion DeleteFromAllocatedTags
    }
}