using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn
{
    public partial class ProjectsSwithching : System.Web.UI.Page
    {
        public string PNo = "";
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        HttpContext context = HttpContext.Current;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dtgProjectSwitching_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            FlyCnDAL.ProjectParameters projObj = new FlyCnDAL.ProjectParameters();
            DataTable ds = new DataTable();
            ds = projObj.GetAllProjectSwitching();
            dtgProjectSwitching.DataSource = ds;
            try
            {
                dtgProjectSwitching.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void dtgProjectSwitching_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
             FlyCnDAL.ProjectParameters projObj = new FlyCnDAL.ProjectParameters();
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            DataTable dt = new DataTable();
            GridDataItem items = e.Item as GridDataItem;
           
            if (items != null)
            {
                string projectNo = items.GetDataKeyValue("ProjectNo").ToString();

                if (e.CommandName == "SelectDefault")
                {
                  
                    dt = projObj.GetAllProjectSwitching();
                    int rowCount = dt.Rows.Count;
                    for (int i = 0; i < rowCount; i++)
                    {
                        if (dt.Columns.Contains("ProjectNo"))
                        {
                            if (dt.Rows[i]["ProjectNo"].ToString() == projectNo)
                            {
                                userObj.UpdateDefaultProject(projectNo);
                               // e.Item.ForeColor = System.Drawing.Color.Green;
                                FlyCnDAL.Security.UserAuthendication UA;                                
                                UIClasses.Const Const = new UIClasses.Const();
                                UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];

                                FlyCnDAL.Security.UserAuthendication UA_Changed = new FlyCnDAL.Security.UserAuthendication(UA.userName, projectNo,false);
                                if (UA_Changed.ValidUser)
                                {
                                    Session[Const.LoginSession]= UA_Changed;                                  
                                   
                                }

                            }
                        }
                    }
                    
                }
                if (e.CommandName == "Select")
                {
                    dt = projObj.GetAllProjectSwitching();
                    int rowCount = dt.Rows.Count;
                    for (int i = 0; i < rowCount; i++)
                    {
                        if (dt.Columns.Contains("ProjectNo"))
                        {
                            if (dt.Rows[i]["ProjectNo"].ToString() == projectNo)
                            {
                                FlyCnDAL.Security.UserAuthendication UA;
                                UIClasses.Const Const = new UIClasses.Const();
                                UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];

                                FlyCnDAL.Security.UserAuthendication UA_Changed = new FlyCnDAL.Security.UserAuthendication(UA.userName, projectNo, false);
                                if (UA_Changed.ValidUser)
                                {
                                    Session[Const.LoginSession] = UA_Changed;

                                }

                            }
                        }
                    }
                }
               
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "parent.goMenu()", true);
            }
        }

        protected void dtgProjectSwitching_ItemDataBound(object sender, GridItemEventArgs e)
        {
           //// string projNo = lblProjNo.Text;
           // FlyCnDAL.ProjectParameters projObj = new FlyCnDAL.ProjectParameters();
           // DataTable dt = new DataTable();
           // dt = projObj.GetAllProjectSwitching();
           // int rowCount = dt.Rows.Count;
           // for (int i = 0; i < rowCount; i++)
           // {
           //     if (dt.Rows[i]["ProjectNo"].ToString() == "C00001")
           //     {
           //         e.Item.BackColor = System.Drawing.Color.Green;
           //     }
           // }
        }
        }
    }
