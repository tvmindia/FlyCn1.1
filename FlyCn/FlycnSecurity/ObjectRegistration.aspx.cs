using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlyCnSecurity.SecurityDAL;
using System.Data;
using System.Data.SqlClient;

using System.Reflection;
using System.Collections;


namespace FlyCn.FlycnSecurity
{
    public partial class ObjectRegistration : System.Web.UI.Page
    {
        SecurityObjects DALObj = new SecurityObjects();
        
        

         //dbConnection dcon = new dbConnection();
         //           con = dcon.GetDBConnection();

        #region Public Properties

        public string UserName = "SHAMILA";
        public string Scope = "SYSTEM";
        public string LevelID = " ";

        public string text = " ";
        //public string textboxID = txtNewObject.Text;
        public string temp = string.Empty;

        #endregion Public Properties

        #region Methods

        /// <summary>
        /// Function to create navigation 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="LevelID"></param>
        /// <param name="reverseOrNot"></param>
        public void createNavigation(string text, string LevelID, bool reverseOrNot = false)
        {
            BulletedList temp = new BulletedList();

            for (int i = 0; i < navigation.Items.Count; i++)
            {
                ListItem li1 = new ListItem(navigation.Items[i].Text, navigation.Items[i].Value);

                li1.Attributes.Add("Style", "color:Blue");

                temp.Items.Add(li1);
            }

            navigation.Items.Clear();

            //Copying the bulleted list into temp as it losts items on postbacks(it only retains value and text not the attributes)

            for (int i = 0; i < temp.Items.Count; i++)
            {
                ListItem li1 = new ListItem(temp.Items[i].Text, temp.Items[i].Value);
                li1.Attributes.Add("onclick", "myFn('" + temp.Items[i].Value + "')");

                li1.Attributes.Add("Style", "color:Blue");

                navigation.Items.Add(li1);
                hdnBrowserManualOpen.Value = "True";

            }

            if (reverseOrNot == false)
            {

                //ViewState["tempBulletedList"] = temp;

                ListItem li = new ListItem(text, LevelID);
                li.Attributes.Add("onclick", "myFn('" + LevelID + "')");

                li.Attributes.Add("Style", "color:Blue");

                navigation.Items.Add(li);
            }

 //To regenerate navigation in the page loaded one of clicking one of navigation items

            else if (reverseOrNot == true)
            {

                //ViewState["tempBulletedList"] = temp;

                ListItem li = new ListItem(text, LevelID);
                li.Attributes.Add("onclick", "myFn('" + LevelID + "')");

                li.Attributes.Add("Style", "color:Blue");

                navigation.Items.Insert(0, li);
            }

        }



        /// <summary>
        ///Function to get Previous Selection
        /// </summary>
        public void getPreviousSelection()
        {
            if (Request.QueryString["ParentID"] != null)
            {
                string ID = Request.QueryString["ParentID"];
                DALObj.LevelID = ID;
                ViewState["testID"] = ID;

                DataSet dsObjectsWithParentIDNotNull = null;

                DataSet firstlevelIDs = null;
                DataSet dsObjectsWithParentIDNull = null;

                try
                {

                    firstlevelIDs = DALObj.GetAllObjectsWithParentIDNull();
                    string temp = "";
                    string s = "";
                    int firstLevelIDCount = firstlevelIDs.Tables[0].Rows.Count;
                    int rowIndex = firstLevelIDCount - 1;
                    for (int i = 0; i < rowIndex; i++)
                    {
                        temp = firstlevelIDs.Tables[0].Rows[i][1].ToString();
                        s = temp + "|" + s;
                    }

                    string fullString = s;

                    if (fullString.Contains(ID))
                    {
                        dsObjectsWithParentIDNull = new DataSet();

                        try
                        {
                            ddlParent.DataSource = DALObj.GetAllObjectsWithParentIDNull();
                            ddlParent.DataTextField = "LevelDesc";
                            ddlParent.DataValueField = "LevelID";
                            ddlParent.DataBind();
                            ddlParent.Items.FindByValue(ViewState["testID"].ToString()).Selected = true;
                            //ddlParent.Items.FindByValue(ID).Selected = true;

                            ddlParent.Items.Insert(0, "--Select--");

                        }
                        catch (Exception)
                        {
                            lblError.ForeColor = System.Drawing.Color.Red;
                            lblError.Text = " Some problem while accessing objects with parent id null ";
                        }

                    }

                    else
                    {
                        int Place = ID.LastIndexOf('.');
                        string value = ID.Substring(Place);
                        string result = ID.Remove(Place, value.Length).Insert(Place, string.Empty);


                        DALObj.ParentID = result;
                        DataSet ds = DALObj.GetDataOnNavigation();
                        ddlParent.DataSource = ds;

                        ddlParent.DataTextField = "LevelDesc";
                        ddlParent.DataValueField = "LevelID";
                        ddlParent.DataBind();

                        ddlParent.Items.FindByValue(ViewState["testID"].ToString()).Selected = true;


                    }

                    dsObjectsWithParentIDNotNull = DALObj.GetAllObjectsWithParentIDIsNotNull();
                    ddlChild.DataSource = dsObjectsWithParentIDNotNull;
                    ddlChild.DataTextField = "LevelDesc";
                    ddlChild.DataValueField = "LevelID";
                    ddlChild.DataBind();

                }

                catch (Exception)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Exception";
                }

                //Request.QueryString.Clear();

            }
        }

        #region Bind Gridview

        /// <summary>
        /// Function to bind gridview with registered objects
        /// </summary>
        public void Bindgridview()
        {
            DataSet dsgridview = null;
            DataTable dtGridview = null;
            DataRow dr = null;
            DataTable dtTemp = null;

            string LevelID = ViewState["ID"].ToString();
            DALObj.LevelID = LevelID;

            if (temp != string.Empty)
            {
                DALObj.LevelID = temp;
            }

            try
            {
                dsgridview = DALObj.PopulateGridview();
            }
            catch (Exception)
            {

                lblError.Text = "Some problem while accessing data to populate gridview.Please try again ! ";
            }

            if (dsgridview.Tables[0] != null)
            {
                dtGridview = dsgridview.Tables[0];

                int rowCount = dtGridview.Rows.Count;
                gvObjectRegistration.DataSource = dtGridview;
                gvObjectRegistration.DataBind();
            }

        }

        #endregion  Bind Gridview



        #endregion Methods


        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet dsObjectsWithParentIDNull = null;
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.showTreeNode();", true);
            if (!Page.IsPostBack)
            {
                hdnBrowserManualOpen.Value = "True";


                dsObjectsWithParentIDNull = new DataSet();

                try
                {
                    ddlParent.DataSource = DALObj.GetAllObjectsWithParentIDNull();
                    ddlParent.DataTextField = "LevelDesc";
                    ddlParent.DataValueField = "LevelID";
                    ddlParent.DataBind();
                    ddlParent.Items.Insert(0, "--Select--");

                }
                catch (Exception)
                {

                    lblError.Text = " Some problem while accessing objects with parent id null ";
                }



            }

            //else
            //{

            if (hdnBrowserManualOpen.Value == "True")
            {
                if (Request.QueryString["ParentID"] != null)
                {

                    //BulletedList previousNavigation = (BulletedList)ViewState["tempBulletedList"];
                    //int listCount = previousNavigation.Items.Count;



                    string ID = Request.QueryString["ParentID"];

                    DALObj.LevelID = ID;
                    ViewState["navigationID"] = ID;
                    ViewState["parentID"] = ID;
                    ViewState["ID"] = ID;

                    PropertyInfo isreadonly =
                      typeof(System.Collections.Specialized.NameValueCollection).GetProperty(
                          "IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                    // make collection editable
                    isreadonly.SetValue(this.Request.QueryString, false, null);
                    // remove
                    this.Request.QueryString.Remove("ParentID");

                    DataSet dsObjectsWithParentIDNotNull = null;

                    DataSet firstlevelIDs = null;
                    DataSet dsObjectsWithParentIDNulll = null;

                    try
                    {

                        firstlevelIDs = DALObj.GetAllObjectsWithParentIDNull();
                        string temp = "";
                        string s = "";
                        int firstLevelIDCount = firstlevelIDs.Tables[0].Rows.Count;
                        int rowIndex = firstLevelIDCount - 1;
                        for (int i = 0; i < rowIndex; i++)
                        {
                            temp = firstlevelIDs.Tables[0].Rows[i][1].ToString();
                            s = temp + "|" + s;
                        }

                        string fullString = s;

                        if (fullString.Contains(ID))
                        {

                            dsObjectsWithParentIDNulll = new DataSet();

                            try
                            {
                                ddlParent.DataSource = DALObj.GetAllObjectsWithParentIDNull();
                                ddlParent.DataTextField = "LevelDesc";
                                ddlParent.DataValueField = "LevelID";
                                ddlParent.DataBind();
                                ddlParent.Items.FindByValue(ViewState["navigationID"].ToString()).Selected = true;
                                //ddlParent.Items.FindByValue(ID).Selected = true;

                                ddlParent.Items.Insert(0, "--Select--");
                                string selectedItemText = ddlParent.SelectedItem.Text;


                                createNavigation(selectedItemText, ID);

                            }
                            catch (Exception)
                            {
                                lblError.ForeColor = System.Drawing.Color.Red;
                                lblError.Text = " Some problem while accessing objects with parent id null ";
                            }

                        }

                        else
                        {
                            ViewState["parentID"] = ID;

                            int Place = ID.LastIndexOf('.');
                            string value = ID.Substring(Place);
                            string result = ID.Remove(Place, value.Length).Insert(Place, string.Empty);
                            string tempID = ID;

                            int countTemp = ID.Split('.').Length - 1;

                            for (int i = countTemp; i >= 1; i--)
                            {
                                string str = tempID;
                                string ext = tempID.Substring(0, str.LastIndexOf("."));
                                tempID = ext;


                                DALObj.LevelID = tempID;
                                DataSet dsPreviousListItemTemp = DALObj.GetPreviousListItem();
                                string selectedItemTextTemp = dsPreviousListItemTemp.Tables[0].Rows[0][0].ToString();
                                string selectedItemvalueTemp = dsPreviousListItemTemp.Tables[0].Rows[0][1].ToString();

                                createNavigation(selectedItemTextTemp, selectedItemvalueTemp, true);

                            }


                            DALObj.ParentID = result;
                            DataSet ds = DALObj.GetDataOnNavigation();
                            ddlParent.DataSource = ds;

                            ddlParent.DataTextField = "LevelDesc";
                            ddlParent.DataValueField = "LevelID";
                            ddlParent.DataBind();

                            string a = ds.Tables[0].Rows[0][1].ToString();

                            if (ViewState["navigationID"] != null)
                            {
                                ddlParent.Items.FindByValue(ViewState["navigationID"].ToString()).Selected = true;

                                string caseParentNavigation = ddlParent.SelectedItem.Text;
                                ViewState["caseParentNavigation"] = caseParentNavigation;
                            }
                        }


                        DALObj.LevelID = ID;
                        dsObjectsWithParentIDNotNull = DALObj.GetAllObjectsWithParentIDIsNotNull();
                        ddlChild.DataSource = dsObjectsWithParentIDNotNull;
                        ddlChild.DataTextField = "LevelDesc";
                        ddlChild.DataValueField = "LevelID";
                        ddlChild.DataBind();


                        //this.Request.QueryString.Remove("ParentID");

                    }
                    catch (Exception)
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Exception";
                    }
                }
            }

            try
            {
                getPreviousSelection();
            }
            catch (Exception)
            {

                lblError.Text = "Some problem while accessing the objects with parent id not null";
            }
                
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //Object ID (getting greatest value from objid column and new object id created by incrementing it by one

            try
            {
                int currentObjID = DALObj.GetLastObjIDFromObjectRegistration();
                string newObjID = Convert.ToString(currentObjID + 1);
                DALObj.ObjId = newObjID;
            }
            catch (Exception)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Some problem while accessing the current object.Please try again ";
            }

            //Level ID ( with pattern parentid.count)

            int count = 0;
            string currentLevelID = "";

            if (ViewState["parentID"] != null)
            {
                currentLevelID = ViewState["parentID"].ToString();
                DALObj.LevelID = currentLevelID;

                DataSet ds = DALObj.GetAllObjectsWithParentIDIsNotNull();
                int c = ds.Tables[0].Rows.Count;
                count = c;
                count = count + 1;

                string newlevelID = currentLevelID + "." + count;
                DALObj.LevelID = newlevelID;


                if (ddlChild.Items.FindByText("--Select--") == null)
                {
                    count = count + 1;
                    newlevelID = currentLevelID + "." + count;
                    DALObj.LevelID = newlevelID;
                }

                //if(  ddlChild.Items.FindByValue(newlevelID)!=null)
                //{
                //    count = count + 1;
                //    newlevelID = currentLevelID + "." + count;
                //    DALObj.LevelID = newlevelID;
                //}

                //Parent ID

                DALObj.ParentID = currentLevelID;


                // Level Description 

                DALObj.LevelDesc = txtNewObject.Text;

                //Scope(accessed from public properties)

                DALObj.Scope = Scope;

                //CreatedBy (accessed from public properties)

                DALObj.CreatedBy = UserName;

                try
                {
                    if (DALObj.LevelDesc == string.Empty)
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Please enter a value";
                    }

                    else
                    {
                        DALObj.RegisterNewObject();
                        Bindgridview();
                        //up.Update();

                        BulletedList temp = new BulletedList();

                        temp = navigation;

                        for (int i = 0; i < temp.Items.Count; i++)
                        {

                            string LevelID = temp.Items[i].Value;

                            temp.Items[i].Attributes.Add("onclick", "myFn('" + LevelID + "')");

                            temp.Items[i].Attributes.Add("Style", "color:Blue");
                        }

                        //ddlChild.Items.Add(DALObj.LevelDesc);

                        ddlChild.Items.Add(new ListItem(txtNewObject.Text, newlevelID));



                    }
                }
                catch (Exception)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = " Some problem in object registration ,Please check the inputs and try again ";
                }

            }

            else
            {
                lblError.Text = "Sorry! First level items can added only by admin ";
            }


        }

        protected void imgBtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow clickedRow = ((ImageButton)sender).NamingContainer as GridViewRow;
            ImageButton lblID = (ImageButton)clickedRow.FindControl("imgBtnDelete");

            try
            {
                string selectedRow = clickedRow.Cells[1].Text;

                //To delete item from combobox on deleting item from gridview

                foreach (ListItem li in ddlChild.Items)
                {
                    string selectedRowTemp = selectedRow;
                    //string selectedRowTemp = gvObjectRegistration.SelectedRow.Cells[1].Text;

                    if (li.Value == selectedRowTemp)
                    {
                        ddlChild.Items.Remove(li);
                        break;
                    }
                }

                foreach (ListItem li in ddlParent.Items)
                {
                    //string selectedRowTemp = gvObjectRegistration.SelectedRow.Cells[1].Text;

                    string selectedRowTemp = selectedRow;

                    if (li.Value == selectedRowTemp)
                    {
                        ddlParent.Items.Remove(li);
                        break;
                    }
                }


                //gvObjectRegistration.SelectedRow.Cells[0].Attributes.Add("onClick", "javascript: return window.confirm(\"Do you confirm to delete this item?\");");

                DALObj.LevelID = selectedRow;
                int objID = DALObj.GetObjectIDByLevelID();

                DALObj.ObjId = objID.ToString();
                DALObj.DeleteObjectByID();


                Bindgridview();

                BulletedList temp = new BulletedList();

                temp = navigation;

                for (int i = 0; i < temp.Items.Count; i++)
                {

                    string LevelID = temp.Items[i].Value;

                    temp.Items[i].Attributes.Add("onclick", "myFn('" + LevelID + "')");

                    temp.Items[i].Attributes.Add("Style", "color:Blue");
                }

            }
            catch (Exception)
            {

                lblError.Text = "Some problem while deleting the object";
            }

        }

        protected void imgBtnUpdate_Click(object sender, ImageClickEventArgs e)
        {


        }

        protected void ddlParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            text = ddlParent.SelectedItem.Text;
            string parentValue = ddlParent.SelectedItem.Value;

            DataSet dsObjectsWithParentIDNotNull = null;
            int rowCount = 0;

            LevelID = ddlParent.SelectedItem.Value;
            ViewState["ID"] = LevelID;

            DataSet firstlevelIDs = null;

            firstlevelIDs = DALObj.GetAllObjectsWithParentIDNull();
            string temp = "";
            string s = "";
            int firstLevelIDCount = firstlevelIDs.Tables[0].Rows.Count;
            int rowIndex = firstLevelIDCount - 1;
            for (int i = 0; i < rowIndex; i++)
            {
                temp = firstlevelIDs.Tables[0].Rows[i][1].ToString();
                s = temp + "|" + s;
            }

            string fullString = s;

            if (fullString.Contains(LevelID))
            {


                ViewState["parentText"] = text;
                ViewState["parentLevelID"] = LevelID;

                int bulletedlistItemCount = navigation.Items.Count;

                if (bulletedlistItemCount != 0)
                {
                    navigation.Items.Clear();
                }
                createNavigation(ViewState["parentText"].ToString(), ViewState["parentLevelID"].ToString());


            }

            if (ViewState["caseParentNavigation"] != null)
            {
                createNavigation(text, LevelID);
            }


            if (navigation.Items.Count != 0)
            {
                int bulletedlistItemCount = navigation.Items.Count;
                string lastBulletedlistItemValueExcludingPartAfterLastDot = string.Empty;
                string parentValueExcludingPartAfterLastDot = string.Empty;

                if (navigation.Items[bulletedlistItemCount - 1].Value.Contains("."))
                {
                    lastBulletedlistItemValueExcludingPartAfterLastDot = navigation.Items[bulletedlistItemCount - 1].Value.Substring(0, navigation.Items[bulletedlistItemCount - 1].Value.LastIndexOf("."));
                    parentValueExcludingPartAfterLastDot = parentValue.Substring(0, parentValue.LastIndexOf("."));
                    temp = navigation.Items[bulletedlistItemCount - 1].Value;

                    if (lastBulletedlistItemValueExcludingPartAfterLastDot == parentValueExcludingPartAfterLastDot)
                    {
                        createNavigation(text, LevelID);

                        if (navigation.Items.FindByValue(temp) != null)
                        {
                            ListItem itemToBeRemoved = navigation.Items.FindByValue(temp);
                            navigation.Items.Remove(itemToBeRemoved);
                        }

                    }

                }

            }


            int rowcount = 0;

            try
            {

                DALObj.LevelID = LevelID;

                dsObjectsWithParentIDNotNull = DALObj.GetAllObjectsWithParentIDIsNotNull();
                rowCount = dsObjectsWithParentIDNotNull.Tables[0].Rows.Count;

                if (rowCount == 0)
                {
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Selected item doesn't have any childs. Please register new item";

                    if (ddlChild.Items.Count != 0)
                    {
                        ddlChild.Items.Clear();
                    }
                }
                else
                {
                    ddlChild.DataSource = DALObj.GetAllObjectsWithParentIDIsNotNull();

                    rowcount = dsObjectsWithParentIDNotNull.Tables[0].Rows.Count;

                    ddlChild.DataTextField = "LevelDesc";
                    ddlChild.DataValueField = "LevelID";
                    ddlChild.DataBind();
                    ddlChild.Items.Insert(0, "--Select--");
                }
            }
            catch (Exception)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Some problem while accessing the objects with parent id not null" + rowcount.ToString();
            }
            Bindgridview();
        }

        protected void ddlChild_SelectedIndexChanged(object sender, EventArgs e)
        {

            string parentValue = ddlParent.SelectedItem.Text;
            string parentid = ddlParent.SelectedItem.Value;

            if (navigation.Items.FindByText(parentValue) == null)
            {
                createNavigation(parentValue, parentid);
            }

            DataSet dsObjectsWithParentIDNotNull = null;
            int rowCount = 0;

            LevelID = ddlChild.SelectedItem.Value;
            ViewState["ID"] = LevelID;

            text = ddlChild.SelectedItem.Text;

            DataSet firstlevelIDs = null;

            firstlevelIDs = DALObj.GetAllObjectsWithParentIDNull();
            string temp = "";
            string s = "";
            int firstLevelIDCount = firstlevelIDs.Tables[0].Rows.Count;
            int rowIndex = firstLevelIDCount - 1;
            for (int i = 0; i < rowIndex; i++)
            {
                temp = firstlevelIDs.Tables[0].Rows[i][1].ToString();
                s = temp + "|" + s;
            }

            string fullString = s;

            if (!fullString.Contains(LevelID))
            {

                ViewState["parentText"] = text;
                ViewState["parentLevelID"] = LevelID;

                createNavigation(ViewState["parentText"].ToString(), ViewState["parentLevelID"].ToString());

            }


            ViewState["parentID"] = LevelID;
            temp = LevelID;

            try
            {
                DALObj.LevelID = LevelID;

                dsObjectsWithParentIDNotNull = DALObj.GetAllObjectsWithParentIDIsNotNull();
                rowCount = dsObjectsWithParentIDNotNull.Tables[0].Rows.Count;

                if (rowCount == 0)
                {

                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Selected item doesn't have any childs. Please register new item";

                    if (ddlChild.Items.Count != 0)
                    {
                        ddlChild.Items.Clear();
                    }

                }
                else
                {
                    //ViewState["parentID"] = ViewState["ID"];

                    //ddlChild.DataSource = DALObj.GetAllObjectsWithParentIDIsNotNull();
                    ddlChild.DataSource = dsObjectsWithParentIDNotNull;
                    ddlChild.DataTextField = "LevelDesc";
                    ddlChild.DataValueField = "LevelID";
                    ddlChild.DataBind();
                    ddlChild.Items.Insert(0, "--Select--");

                    //ddlChild.Items.FindByValue(ViewState["ID"].ToString()).Selected = true;
                }
            }
            catch (Exception)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Some problem while accessing the objects with parent id not null";
            }

            try
            {
                string ID = temp;

                int Place = ID.LastIndexOf('.');
                string value = ID.Substring(Place);
                string result = ID.Remove(Place, value.Length).Insert(Place, string.Empty);

                //LevelID = ViewState["parentID"].ToString();

                DALObj.ParentID = result;


                dsObjectsWithParentIDNotNull = DALObj.GetDataOnNavigation();
                rowCount = dsObjectsWithParentIDNotNull.Tables[0].Rows.Count;

                if (rowCount == 0)
                {
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Selected item doesn't have any childs. Please register new item";

                    if (ddlChild.Items.Count != 0)
                    {
                        ddlChild.Items.Clear();
                    }
                }
                else
                {
                    ddlParent.DataSource = dsObjectsWithParentIDNotNull;
                    ddlParent.DataTextField = "LevelDesc";
                    ddlParent.DataValueField = "LevelID";
                    ddlParent.DataBind();


                    ddlParent.Items.FindByValue(ViewState["parentID"].ToString()).Selected = true;
                    ddlParent.Items.Insert(0, "--Select--");

                    ViewState["parentID"] = ddlParent.SelectedItem.Value;

                }

            }
            catch (Exception)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Some problem while accessing the objects with parent id not null";
            }

            Bindgridview();
        }

       
    }
}