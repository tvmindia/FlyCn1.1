using FlyCn.FlyCnDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.EIL
{
    public partial class ConstructionPunchList : System.Web.UI.Page
    {
        
        ErrorHandling eObj = new ErrorHandling();
        DataTable dt = new DataTable();
       // PunchList pObj=new PunchList();
        FlyCnDAL.PunchList pObj = new FlyCnDAL.PunchList();
        MasterPersonal mObj = new MasterPersonal();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                FlyCnDAL.PunchList pObj = new FlyCnDAL.PunchList();

                dt = mObj.GetDEtailsFromPersonal();

                ddlOpenBy.DataSource = dt;
                ddlOpenBy.DataTextField = "Name";
                ddlOpenBy.DataValueField = "Code";
                ddlOpenBy.DataBind();
                ddlOpenBy.Items.Insert(0, new ListItem("-Select-", "NULL"));

                ddlEnteredBy.DataSource = dt;
                ddlEnteredBy.DataTextField = "Name";
                ddlEnteredBy.DataValueField = "Code";
                ddlEnteredBy.DataBind();
                ddlEnteredBy.Items.Insert(0, new ListItem("-Select-", "NULL"));

                ddlRequestedBy.DataSource = dt;
                ddlRequestedBy.DataTextField = "Name";
                ddlRequestedBy.DataValueField = "Code";
                ddlRequestedBy.DataBind();
                ddlRequestedBy.Items.Insert(0, new ListItem("-Select-", "NULL"));

                ddlInspector.DataSource = dt;
                ddlInspector.DataTextField = "Name";
                ddlInspector.DataValueField = "Code";
                ddlInspector.DataBind();
                ddlInspector.Items.Insert(0, new ListItem("-Select-", "Null"));

                ddlResponsiblePerson.DataSource = dt;
                ddlResponsiblePerson.DataTextField = "Name";
                ddlResponsiblePerson.DataValueField = "Code";
                ddlResponsiblePerson.DataBind();
                ddlResponsiblePerson.Items.Insert(0, new ListItem("-Select-", "Null"));


                ddlSignedBy.DataSource = dt;
                ddlSignedBy.DataTextField = "Name";
                ddlSignedBy.DataValueField = "Code";
                ddlSignedBy.DataBind();
                ddlSignedBy.Items.Insert(0, new ListItem("-Select-", "Null"));
                DataTable dtp = new DataTable();
                dtp = pObj.GetPlatFromM_Plant();
                ddlPlant.DataSource = dtp;
                ddlPlant.DataTextField = "Description";
                ddlPlant.DataValueField = "Code";
                ddlPlant.DataBind();
                ddlPlant.Items.Insert(0, new ListItem("-Select-", "Null"));

                dt = pObj.GetAreaFromM_Area();
                ddlArea.DataSource = dt;
                ddlArea.DataTextField = "Description";
                ddlArea.DataValueField = "Code";
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, new ListItem("-Select-", "Null"));

                dt = pObj.GetLocationFromM_Location();
                ddlLocation.DataSource = dt;
                ddlLocation.DataTextField = "Description";
                ddlLocation.DataValueField = "Code";
                ddlLocation.DataBind();
                ddlLocation.Items.Insert(0, new ListItem("-Select-", "Null"));

                dt = pObj.GetUnitFromM_Unit();
                ddlUnit.DataSource = dt;
                ddlUnit.DataTextField = "Description";
                ddlUnit.DataValueField = "Code";
                ddlUnit.DataBind();
                ddlUnit.Items.Insert(0, new ListItem("-Select-", "Null"));

                dt = pObj.GetUActionByFromM_Company();
                ddlActionBy.DataSource = dt;
                ddlActionBy.DataTextField = "CompName";
                ddlActionBy.DataValueField = "Code";
                ddlActionBy.DataBind();
                ddlActionBy.Items.Insert(0, new ListItem("-Select-", "Null"));


                dt = pObj.GetDisciplineFromM_Discipline();
                ddlDiscipline.DataSource = dt;
                ddlDiscipline.DataTextField = "Description";
                ddlDiscipline.DataValueField = "Code";
                ddlDiscipline.DataBind();
                ddlDiscipline.Items.Insert(0, new ListItem("-Select-", "Null"));

                dt = pObj.GetFailCategoryFromM_FailCategory();
                ddlFailCategory.DataSource = dt;
                ddlFailCategory.DataTextField = "Description";
                ddlFailCategory.DataValueField = "Code";
                ddlFailCategory.DataBind();
                ddlFailCategory.Items.Insert(0, new ListItem("-Select-", "Null"));


                dt = pObj.GetCategoryFromM_Category();
                ddlCategoryList.DataSource = dt;
                ddlCategoryList.DataTextField = "Description";
                ddlCategoryList.DataValueField = "Code";
                ddlCategoryList.DataBind();
                ddlCategoryList.Items.Insert(0, new ListItem("-Select-", "NULL"));

                dt = pObj.GetUActionByFromM_Company();
                ddlOrganization.DataSource = dt;
                ddlOrganization.DataTextField = "CompName";
                ddlOrganization.DataValueField = "Code";
                ddlOrganization.DataBind();
                ddlOrganization.Items.Insert(0, new ListItem("-Select-", "NULL"));
               
           }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
             
                int result;
                pObj.Idno = Convert.ToInt32(txtIDno.Text);
                pObj.EILType = Request.QueryString["Mode"];
                if (ddlOpenBy.SelectedItem.Text != "-Select-")
                {
                    mObj.OpenBy = Convert.ToString(ddlOpenBy.SelectedValue);
                }
                else
                {
                    mObj.OpenBy = null;
                }
                if (RadOpenDate.SelectedDate != null)
                {
                    pObj.OpenDate = Convert.ToString(RadOpenDate.SelectedDate);
                }
                if (ddlRequestedBy.SelectedItem.Text != "-Select-")
                { 
                    mObj.RequestedBy = Convert.ToString(ddlRequestedBy.SelectedValue); 
                }
                else
                {
                    mObj.RequestedBy = null;
                }
                if (ddlResponsiblePerson.SelectedItem.Text != "-Select-")
                {
                    mObj.ResponsiblePerson = Convert.ToString(ddlResponsiblePerson.SelectedValue);
                }
                else
                {
                    mObj.ResponsiblePerson = null;
                }
                if (ddlInspector.SelectedItem.Text != "-Select-")
                {
                    mObj.Inspector = Convert.ToString(ddlInspector.SelectedValue);
                }
                else
                {
                    mObj.Inspector = null;
                }
                if (ddlSignedBy.SelectedItem.Text != "-Select-")
                {
                    mObj.SignedBy = Convert.ToString(ddlSignedBy.SelectedValue);
                }
                else
                {
                    mObj.SignedBy = null;
                }
                if (ddlEnteredBy.SelectedItem.Text != "-Select-")
                {
                    mObj.EnteredBy = Convert.ToString(ddlEnteredBy.SelectedValue);

                }
                else
                {
                    mObj.EnteredBy = null;
                }
           
                //if (RadEnteredDate.SelectedDate != null)
                //{
                //    pObj.EnteredDt = Convert.ToString(RadEnteredDate.SelectedDate);
                //}
                if (ddlDiscipline.SelectedItem.Text != "-Select-")
                {
                    pObj.Discipline = Convert.ToString(ddlDiscipline.SelectedValue);
                }
                else
                {
                    pObj.Discipline = null;
                }
                pObj.ItemDescription = txtItemDescription.Text;
                if (ddlLocation.SelectedItem.Text != "-Select-")
                {
                    pObj.Location = Convert.ToString(ddlLocation.SelectedValue);
                }
                else
                {
                    pObj.Location = null;
                }
                if (ddlArea.SelectedItem.Text != "-Select-")
                {
                    pObj.Area = Convert.ToString(ddlArea.SelectedValue);
                }
                else
                {
                    pObj.Area =null;
                }
                if (ddlUnit.SelectedItem.Text != "-Select-")
                {
                    pObj.Unit = Convert.ToString(ddlUnit.SelectedValue);
                }
                else
                {
                    pObj.Unit =null;
                }
                if (ddlPlant.SelectedItem.Text != "-Select-")
                {
                    pObj.Plant = Convert.ToString(ddlPlant.SelectedValue);
                }
                else
                {
                    pObj.Plant = null;
                }
                //if (RadScheduleCompletionDate != null)
                //{
                //    pObj.ScheduledDateCompletion = Convert.ToString(RadScheduleCompletionDate.SelectedDate);
                //}
                //if (RadRFINo.SelectedDate != null)
                //{
                //    pObj.RFIDate = Convert.ToString(RadRFINo.SelectedDate);
                //}
                pObj.RFINo = txtRFINo.Text;
                pObj.Sheet = txtSheet.Text;
                pObj.Drawing = txtDrawing.Text;
                if (ddlFailCategory.SelectedItem.Text != "-Select-")
                {
                     
                pObj.FailCategory = Convert.ToString(ddlFailCategory.SelectedValue);

                }
                else
                {
                    pObj.FailCategory=null;
                }
                //if (ddlCategory.SelectedItem.Text != "-Select-")
                //{
                //   pObj.Category = Convert.ToString(ddlCategoryList.SelectedValue);
                //}
                //else
                //{
                //    pObj.Category = null;
                //}
                if (txtSystem.Text != "") { pObj.System = txtSystem.Text; 
                }
                else
                {
                  pObj.System = null;
                }
              if(txtSubsystem.Text!="")
              {
                  pObj.Subsystem = txtSubsystem.Text;
              }
              else
              {

                  pObj.Subsystem = null;
              }
       
                string val=null;
                pObj.QueryRevision =string.IsNullOrEmpty(val)? '0' :Convert.ToInt32(txtQueryRevision.Text);
                pObj.Reference = txtReference.Text;
                //if (RadReferenceDate.SelectedDate != null)
                //{
                //    pObj.ReferenceDate = Convert.ToString(RadReferenceDate.SelectedDate);
                //}
                pObj.Revison = txtRevision.Text;
                //if (RadCompletionDate.SelectedDate != null)
                //{
                //    pObj.CompletionDate = Convert.ToString(RadCompletionDate.SelectedDate);
                //}
                pObj.CompletionRemarks = txtCompletionRemarks.Text;
                if (txtControlSystem.Text != "")
                {
                    pObj.ControlSystem = txtControlSystem.Text;
                }
                else
                {
                    pObj.ControlSystem = null;
                }

                if (ddlOrganization.SelectedItem.Text != "-Select-")
                {
                    pObj.Organization = Convert.ToString(ddlOrganization.SelectedValue);
                }
                else
                {
                    pObj.Organization = null;
                }
               // pObj.CoveredByProject=
              // pObj.ChangeReq=
                if (ddlActionBy.SelectedItem.Text != "-Select-")
                {
                    pObj.ActionBy = Convert.ToString(ddlActionBy.SelectedValue);
                }
                else
                {
                    pObj.ActionBy = null;

                }
                pObj.EILType=Request.QueryString["Mode"];
                result = pObj.AddtoPunchList(mObj);
             
                RadGrid1.Rebind();
                //Cleartextboxes();
                if (fuAttach.HasFile)
                {
                    try
                    {
                        pObj.fileUpload = Path.GetFileName(fuAttach.FileName);
                        string save=Server.MapPath("~/Content/Fileupload/" + pObj.fileUpload);
                        fuAttach.SaveAs(save);
                        StatusLabel.Text = "Upload status: File uploaded!";
                        int id = Convert.ToInt32(txtIDno.Text);
                        int value;
                        value = pObj.InsertEILAttachment(id);
                    }
                    catch (Exception ex)
                    {
                        StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    }
                }
            }
            catch (SqlException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            catch (FormatException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
        }

        protected void RadGrid1_NeedDataSource1(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dt;
            dt = pObj.GetPunchList();
            RadGrid1.DataSource = dt;
           // DataTable dts;
            //dts = mObj.GetDEtailsFromPersonal();
            //RadGrid1.DataSource = dts;
        }

        private void RadGrid1_DeleteCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string ID = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDNo"].ToString();
            DataTable table = (DataTable)Session["DataSource"];
            if (table.Rows.Find(ID) != null)
            {
                table.Rows.Find(ID).Delete();
                table.AcceptChanges();
                Session["DataSource"] = dt;
            }
        }


        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
           // string type = Request.QueryString["Mode"];
            if (e.CommandName == "EditData")
            {
                
                string ID = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDNo"].ToString();
                string projno = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ProjectNo"].ToString();
           
                dt = pObj.GetPunchListByProjNo(projno, ID);             
                txtIDno.Text = dt.Rows[0]["IDNo"].ToString();
                string opndate = dt.Rows[0]["OpenDt"].ToString();
                
                if (opndate != "")
                {
       
                    RadOpenDate.SelectedDate = Convert.ToDateTime(opndate);
                }
                string opnby=dt.Rows[0]["OpenBy"].ToString();
                if (opnby != "")
                {
                    ddlOpenBy.SelectedValue = opnby;
                   
                }
                else
                {
                    ddlOpenBy.SelectedIndex = ddlOpenBy.Items.IndexOf(ddlOpenBy.Items.FindByText("-Select-"));
                }
                string reqby= dt.Rows[0]["ReqBy"].ToString();
                if (reqby != "")
                {
                    ddlRequestedBy.SelectedValue = reqby;
                }
                else
                {
                    ddlRequestedBy.SelectedIndex = ddlRequestedBy.Items.IndexOf(ddlRequestedBy.Items.FindByText("-Select-"));
                }
                string resperson= dt.Rows[0]["ComplRespPerson"].ToString();
                if (resperson!= "")
                {
                    ddlResponsiblePerson.SelectedValue = resperson;
                }
                else
                {
                    ddlResponsiblePerson.SelectedIndex = ddlResponsiblePerson.Items.IndexOf(ddlResponsiblePerson.Items.FindByText("-Select-"));
                }
                string inspector=dt.Rows[0]["Inspector"].ToString();
                if (inspector != "")
                {
                    ddlInspector.SelectedValue = inspector;
                }
                else
                {
                    ddlInspector.SelectedIndex = ddlInspector.Items.IndexOf(ddlInspector.Items.FindByText("-Select-"));
                }
                string signed= dt.Rows[0]["SignOffBy"].ToString();
                if (signed != "")
                {
                    ddlSignedBy.SelectedValue = signed;
                }
                else
                {
                    ddlSignedBy.SelectedIndex = ddlSignedBy.Items.IndexOf(ddlSignedBy.Items.FindByText("-Select-"));
                }
                string entrdby= dt.Rows[0]["EnteredBy"].ToString();
                if (entrdby != "")
                {
                    ddlEnteredBy.SelectedValue = entrdby;
                }
                else
                {
                    ddlEnteredBy.SelectedIndex = ddlEnteredBy.Items.IndexOf(ddlEnteredBy.Items.FindByText("-Select-"));
                }
               
                string entrdDate = dt.Rows[0]["EnteredDt"].ToString();
                //if (entrdDate != "")
                //{
                
                //    RadEnteredDate.SelectedDate = Convert.ToDateTime(entrdDate);
                //}
                string displne = dt.Rows[0]["Discipline"].ToString();
                if (displne != "")
                {
                    ddlDiscipline.SelectedValue = displne;
                }
                else
                {
                    ddlDiscipline.SelectedIndex = ddlDiscipline.Items.IndexOf(ddlDiscipline.Items.FindByText("-Select-"));
                }
              
                txtItemDescription.Text = dt.Rows[0]["Description"].ToString();
                string location = dt.Rows[0]["Location"].ToString();
                if(location!="")
                {
                    ddlLocation.SelectedValue = location;
                }
                else
                {
                    ddlLocation.SelectedIndex = ddlLocation.Items.IndexOf(ddlLocation.Items.FindByText("-Select-"));
                }
                string area = dt.Rows[0]["Area"].ToString();
                if(area!="")

                { ddlArea.SelectedValue = area; }
                else
                {
                    ddlArea.SelectedIndex = ddlArea.Items.IndexOf(ddlArea.Items.FindByText("-Select-"));
                }
                string unit = dt.Rows[0]["Unit"].ToString();
                if(unit!="")
                {
                    ddlUnit.SelectedValue = unit;
                }
                else
                {
                    ddlUnit.SelectedIndex = ddlUnit.Items.IndexOf(ddlUnit.Items.FindByText("-Select-"));
                }
                string plant= dt.Rows[0]["Plant"].ToString();
                if(plant!=""){
                    ddlPlant.SelectedValue = plant;
                }
                else
                {
                    ddlPlant.SelectedIndex = ddlPlant.Items.IndexOf(ddlPlant.Items.FindByText("-Select-"));
                }
                string schDate = dt.Rows[0]["SchComplDt"].ToString();
                //if (schDate != null)
                //{
                  
                //    RadScheduleCompletionDate.SelectedDate = Convert.ToDateTime(schDate );
                //}
                string rfiDate = dt.Rows[0]["RFIDate"].ToString();
                //if (rfiDate != "")
                //{
                
                //    RadRFINo.SelectedDate = Convert.ToDateTime(rfiDate);
                //}
                txtRFINo.Text = dt.Rows[0]["RFINo"].ToString();
                txtSheet.Text = dt.Rows[0]["Sht"].ToString();
                txtDrawing.Text = dt.Rows[0]["DwgNo"].ToString();
                string failcategory = dt.Rows[0]["FailCategory"].ToString();
                if (failcategory != "") {
                    ddlFailCategory.SelectedValue = failcategory;
                }
                else
                {
                    ddlFailCategory.SelectedIndex = ddlFailCategory.Items.IndexOf(ddlFailCategory.Items.FindByText("-Select-"));
                }
                string category = dt.Rows[0]["Category"].ToString();
                if(category!="")
                {
                    ddlCategoryList.SelectedValue = category;
                }
                else
                {

                    ddlCategoryList.SelectedIndex = ddlCategoryList.Items.IndexOf(ddlCategoryList.Items.FindByText("-Select-"));
                }
                txtSystem.Text = dt.Rows[0]["TO_System"].ToString();
                txtSubsystem.Text = dt.Rows[0]["TO_Subsystem"].ToString();
                txtQueryRevision.Text = dt.Rows[0]["CTRL_System"].ToString();
                txtReference.Text = dt.Rows[0]["ChangeReqRef"].ToString();

                string refDate = dt.Rows[0]["ChangeReqDt"].ToString();
                //if (refDate != "")
                //{
                //    RadReferenceDate.SelectedDate = Convert.ToDateTime(refDate);
                //}
                txtRevision.Text = dt.Rows[0]["Rev"].ToString();

                string compDate = dt.Rows[0]["ComplDt"].ToString();
                //if (compDate !="")
                //{
                //    RadCompletionDate.SelectedDate = Convert.ToDateTime(compDate);
                //}
                txtCompletionRemarks.Text = dt.Rows[0]["ComplRemarks"].ToString();
                txtControlSystem.Text = dt.Rows[0]["CTRL_System"].ToString();
                string organization = dt.Rows[0]["ComplRespOrg"].ToString();
                if (organization != "")
                {
                    ddlOrganization.SelectedValue = organization;
                }
                else
                {
                    ddlOrganization.SelectedIndex = ddlOrganization.Items.IndexOf(ddlOrganization.Items.FindByText("-Select-"));
                }
                string actionby=dt.Rows[0]["ActionBy"].ToString();   
                if(actionby!="")
                {
                    ddlActionBy.SelectedValue = actionby;
                }
                else
                {
                    ddlActionBy.SelectedIndex = ddlActionBy.Items.IndexOf(ddlActionBy.Items.FindByText("-Select-"));
                }
               // grdFileUpload.Visible = true;
                DataTable dtt;
                dtt = pObj.GetFileFromEILAttachByProjectNoRefEILType(ID);
                grdFileUpload.DataSource = dtt;
                grdFileUpload.DataBind();

                btnUpdate.Visible = true;
                btnSave.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "Edit", "ShowEdit();", true);
           
            }
            if (e.CommandName == "DeleteColumn")
            {
                string ID = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IDNo"].ToString();
                string projno = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ProjectNo"].ToString();
                string type=Request.QueryString["Mode"];
                int val=0;
                val = pObj.DeleteEILAttach(ID, type);
                int result;
                result = pObj.DeleteEIL(projno, ID);
                RadGrid1.Rebind();        
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int result;
                pObj.Idno = Convert.ToInt32(txtIDno.Text);
                if (ddlOpenBy.SelectedItem.Text != "-Select-")
                {
                    mObj.OpenBy = Convert.ToString(ddlOpenBy.SelectedValue);
                }
                else
                {
                    mObj.OpenBy = null;
                }
                if (RadOpenDate.SelectedDate != null)
                {
                    pObj.OpenDate = Convert.ToString(RadOpenDate.SelectedDate);
                }
                if (ddlRequestedBy.SelectedItem.Text != "-Select-")
                {
                    mObj.RequestedBy = Convert.ToString(ddlRequestedBy.SelectedValue);
                }
                else
                {
                    mObj.RequestedBy = null;
                }
                if (ddlResponsiblePerson.SelectedItem.Text != "-Select-")
                {
                    mObj.ResponsiblePerson = Convert.ToString(ddlResponsiblePerson.SelectedValue);
                }
                else
                {
                    mObj.ResponsiblePerson = null;
                }
                if (ddlInspector.SelectedItem.Text != "-Select-")
                {
                    mObj.Inspector = Convert.ToString(ddlInspector.SelectedValue);
                }
                else
                {
                    mObj.Inspector = null;
                }
                if (ddlSignedBy.SelectedItem.Text != "-Select-")
                {
                    mObj.SignedBy = Convert.ToString(ddlSignedBy.SelectedValue);
                }
                else
                {
                    mObj.SignedBy = null;
                }
                if (ddlEnteredBy.SelectedItem.Text != "-Select-")
                {
                    mObj.EnteredBy = Convert.ToString(ddlEnteredBy.SelectedValue);
                }
                else
                {
                    mObj.EnteredBy = null;
                }
                
                //if (RadEnteredDate.SelectedDate != null)
                //{
                //    pObj.EnteredDt = Convert.ToString(RadEnteredDate.SelectedDate);
                //}
                if (ddlDiscipline.SelectedItem.Text != "-Select-")
                {
                    pObj.Discipline = Convert.ToString(ddlDiscipline.SelectedValue);
                }
                else
                {
                    pObj.Discipline = null;
                }
                pObj.ItemDescription = txtItemDescription.Text;
                if (ddlLocation.SelectedItem.Text != "-Select-")
                {
                    pObj.Location = Convert.ToString(ddlLocation.SelectedValue);
                }
                else
                {
                    pObj.Location = null;
                }
                if (ddlArea.SelectedItem.Text != "-Select-")
                {
                    pObj.Area = Convert.ToString(ddlArea.SelectedValue);
                }
                else
                {
                    pObj.Area = null;
                }
                if (ddlUnit.SelectedItem.Text != "-Select-")
                {
                    pObj.Unit = Convert.ToString(ddlUnit.SelectedValue);
                }
                else
                {
                    pObj.Unit = null;
                }
                if (ddlPlant.SelectedItem.Text != "-Select-")
                {
                    pObj.Plant = Convert.ToString(ddlPlant.SelectedValue);
                }
                else
                {
                    pObj.Unit = null;
                }
                
                //if (RadScheduleCompletionDate.SelectedDate!=null)
                //{
                //    pObj.ScheduledDateCompletion = Convert.ToString(RadScheduleCompletionDate.SelectedDate);
                //}
                //if (RadRFINo.SelectedDate != null)
                //{
                //    pObj.RFIDate = Convert.ToString(RadRFINo.SelectedDate);
                //}
                pObj.RFINo = txtRFINo.Text;
                pObj.Sheet = txtSheet.Text;
                pObj.Drawing = txtDrawing.Text;
                if (ddlFailCategory.SelectedItem.Text != "-Select-")
                {
                    pObj.FailCategory = Convert.ToString(ddlFailCategory.SelectedValue);
                }
                else
                {
                    pObj.FailCategory = null;
                }
             
               // pObj.Category = Convert.ToString(ddlCategoryList.SelectedValue);
                if (txtSystem.Text!= "")
                {
                    pObj.System = txtSystem.Text;
                }
                else
                {
                    pObj.System = null;
                }
                if (txtSubsystem.Text != "")
                {
                    pObj.Subsystem = txtSubsystem.Text;
                }
                else
                {
                    pObj.Subsystem = null;
                }
              
                string val = null;
                pObj.QueryRevision = string.IsNullOrEmpty(val) ? 0 : Convert.ToInt32(txtQueryRevision.Text);
                pObj.Reference = txtReference.Text;
                //if (RadReferenceDate.SelectedDate!=null)
                //{
                //    pObj.ReferenceDate = Convert.ToString(RadReferenceDate.SelectedDate);
                //}
      
                //pObj.Revison = txtRevision.Text;
                //if (RadCompletionDate.SelectedDate!=null)
                //{
                //    pObj.CompletionDate = Convert.ToString(RadCompletionDate.SelectedDate);
                //}
                pObj.CompletionRemarks = txtCompletionRemarks.Text;
                if (txtControlSystem.Text != "")
                {
                    pObj.ControlSystem = txtControlSystem.Text;
                }
                else
                {
                    pObj.ControlSystem = null;
                }
          
                if (ddlOrganization.SelectedItem.Text != "-Select-")
                {
                    pObj.Organization = Convert.ToString(ddlOrganization.SelectedValue);
                }
                else
                {
                    pObj.Organization = null;
                }
                // pObj.CoveredByProject=
                // pObj.ChangeReq=
                if (ddlActionBy.SelectedItem.Text != "-Select-")
                {
                    pObj.ActionBy = Convert.ToString(ddlActionBy.SelectedValue);
                }
                else
                {
                    pObj.ActionBy = null;
                }
                pObj.Idno = Convert.ToInt32(txtIDno.Text);
                pObj.EILType = Request.QueryString["Mode"];
              
               
                result = pObj.EditPunchListItems(pObj.Idno, mObj);
                Response.Redirect("ConstructionPunchList.aspx");
                RadGrid1.Rebind();
                //Cleartextboxes();  
            }
            catch (SqlException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            catch (FormatException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
             
        }


        //public void Cleartextboxes()
        //{
         
        //}

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtIDno_TextChanged(object sender, EventArgs e)
        {
            string id = txtIDno.Text;
            if (id.Trim() == "") return;
            for (int i = 0; i <id.Length; i++)
            {
                if (!char.IsNumber(id[i]))
                {
                    lblError.Text="Please enter a valid number";
                    txtIDno.Text = "";
                    return;
                }

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConstructionPunchList.aspx");
        }

        protected void grdFileUpload_RowCommand(object sender, GridViewCommandEventArgs e)
             
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    int result;
                    pObj.Idno = Convert.ToInt32(txtIDno.Text);
                    string type = Request.QueryString["Mode"];
                    GridViewRow row = grdFileUpload.Rows[index];
                    HiddenField hdnField = (HiddenField)row.FindControl("hdnField");
                    int slno = Convert.ToInt32(hdnField.Value);
                    pObj.fileUpload = row.Cells[2].Text;
                    result = pObj.DeleteEilAttachByProjectNoRefNoEILTypeSlNo(pObj.Idno, type, slno);
                    // Response.Redirect("PunchList.aspx");
                  
                        string save = Server.MapPath("~/Content/Fileupload/" + pObj.fileUpload);
                       

                        if (File.Exists(save))
                        {
                            bool deleteSuccess = false;
                            File.Delete(save);
                            deleteSuccess = true;
                        }
                    
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    grdFileUpload.Visible = true;
                    grdFileUpload.DataBind();
                    ScriptManager.RegisterStartupScript(this, GetType(), "Edit", "ShowEdit();", true);

                }
            }
            catch(Exception)
            {

            }
           
        }
        public void grdFileUpload_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {

        }
        //protected void OnRowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Cells[1].CssClass = "hdnField";
        //    }
        //    else if (e.Row.RowType == DataControlRowType.Header)
        //    {
        //        e.Row.Cells[1].CssClass = "hdnField";
        //    }
        //}

        //protected void UploadButton_Click(object sender, EventArgs e)
        //{
           
        //}
        protected void grdFileUpload_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
   
        }

        //protected void btnUpdate_Click1(object sender, EventArgs e)
        //{

        //}

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuAttach.HasFile)
            {
                try
                {
                    pObj.Idno = Convert.ToInt32(txtIDno.Text);
                    //pObj.EILType = "WEIL";
                       
                       // HiddenField hidden1 = (HiddenField)grdFileUpload.Rows..FindControl("hdnType");
                     //   string text = Convert.ToString((HiddenField)row.Cells[2].FindControl("hdnType"));
                    if (grdFileUpload.Rows.Count > 0)
                    {
                        HiddenField hdf = (HiddenField)grdFileUpload.Rows[0].FindControl("hdnType");
                        pObj.EILType = hdf.Value;
                    }
                    else
                    {
                        pObj.EILType = Request.QueryString["Mode"];
                    }
                    
                    string id = txtIDno.Text;
                    pObj.fileUpload = Path.GetFileName(fuAttach.FileName);
                    DataTable dt;
                    dt = pObj.GetEIL_AttachDetails(id, pObj.fileUpload, pObj.EILType);
                   
                    if ((dt.Rows.Count >0))
                    {
                        foreach (DataRow rows in dt.Rows)
                        {
                            string name = rows["FileName"].ToString();
                            //  pObj.slno = Convert.ToInt32(dt.Rows[0]["SlNo"].ToString());
                            int sl = pObj.slno + 1;

                            if (pObj.fileUpload == name)
                            {
                                ChangeFileName(id, pObj.fileUpload, pObj.EILType, pObj.slno);

                            }
                            btnUpdate.Visible = true;
                            btnSave.Visible = false;


                        }
                    }
                                           
                    else
                    {
                       
                                string save = Server.MapPath("~/Content/Fileupload/" + pObj.fileUpload);
                                fuAttach.SaveAs(save);
                                StatusLabel.Text = "Upload status: File uploaded!";
                                int idno = Convert.ToInt32(txtIDno.Text);
                                int value;
                                value = pObj.InsertEILAttachment(idno);
                               // grdFileUpload.Visible = true;
                              //  grdFileUpload.DataBind();
                                //pObj.slno = Convert.ToInt32(dt.Rows[0]["SlNo"].ToString());
                                //int sl = pObj.slno + 1;
                            
                        }
                    grdFileUpload.Visible = true;
                    BindFileuploadGrid(id);
                     ScriptManager.RegisterStartupScript(this, GetType(), "Edit", "ShowEdit();", true);
                   
                }

        
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }
        public void ChangeFileName(string id, string name, string type,int sl)
        {
            if (fuAttach.HasFile)
            {


                 UIClasses.Const Const = new UIClasses.Const();

                 FlyCnDAL.Security.UserAuthendication UA;
                 HttpContext context = HttpContext.Current;
                 UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                 pObj.Projno= UA.projectNo;
                 string pNo = pObj.Projno;
                 string filename = Path.GetFileName(fuAttach.FileName);
                 string extension = Path.GetExtension(fuAttach.PostedFile.FileName);
                 string oldFileName = fuAttach.FileName;
                 string newFileName = (pNo+ id + type + (sl+1) + name);
                 int idno = Convert.ToInt32(id);
                 pObj.fileUpload = newFileName;
                 fuAttach.SaveAs(Server.MapPath("~/Content/Fileupload/") + newFileName);
                 int value;
                 value = pObj.InsertEILAttachment(idno);
            }
        }

        protected void imageButtonDownload_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = sender as ImageButton;

            GridViewRow gvrow = imgbtn.NamingContainer as GridViewRow;
            string filePath = grdFileUpload.DataKeys[gvrow.RowIndex].Value.ToString();
            
            string strExtenstion = Path.GetExtension(filePath);
            string File = Path.GetFileNameWithoutExtension(filePath);
            string path = ("~/Content/Fileupload/");
           if (strExtenstion ==".doc" || strExtenstion == ".docx")
                {
                        Response.ContentType = "application/vnd.ms-word";
                        Response.AddHeader("content-disposition",
                                                          "attachment;filename=" + filePath);
                }
                else if (strExtenstion == ".xls" || strExtenstion == ".xlsx")
                {
                         Response.ContentType = "application/vnd.ms-excel";
                         Response.AddHeader("content-disposition",
                                                         "attachment;filename=" + filePath);
                }
                else if (strExtenstion == ".txt")
                {
                         Response.ContentType = "application/pdf";
                         Response.AddHeader("content-disposition", 
                                                        "attachment;filename="+filePath);
                }
          //  Response.ContentType = "text/plain";
          //  Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath);
           string filepath = path + filePath;
            Response.TransmitFile(Server.MapPath(filepath));
           //Response.WriteFile(path);
            Response.End();
        }
        public void BindFileuploadGrid(string id)
        {

           // string ID = Convert.ToString(id);
            
            DataTable dtt;
            dtt = pObj.GetFileFromEILAttachByProjectNoRefEILType(id);
            grdFileUpload.DataSource = dtt;
            grdFileUpload.DataBind();

        }


    }
}
        
    
