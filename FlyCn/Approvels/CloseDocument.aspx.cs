using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlyCn.FlyCnDAL;
using System.Data;
using System.Web.UI.HtmlControls;
namespace FlyCn.Approvels
{
    public partial class CloseDocument : System.Web.UI.Page
    {
        string _RevisionID;
        string _DocumentID;
        string _DocumentType;
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        protected void Page_Load(object sender, EventArgs e)
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            _RevisionID = Request.QueryString["RevisionID"];
            _DocumentID = Request.QueryString["DocumentID"];
            _DocumentType = Request.QueryString["DocumentType"];
            //Uri myUri = new Uri(_id1, UriKind.RelativeOrAbsolute);
            //string param1 = HttpUtility.ParseQueryString(myUri.Query).Get("DocumentID");
            ////string param1 = HttpUtility.ParseQueryString(_id1.Query).Get("param1");
            ////txtEmpCode.Text = _id1;
            ////hdfRevisionId.Value = _id1;
            //lblrevisionid.Text = _RevisionID;
            string caption = "Select Your Varifiers :)";
            caption = caption.Replace(":)", "<img src='/Images/glad.png' alt='Happy!' />");
            lblrevisionid.Text = caption;
            //lblrevisionid.Text = Emoticon.Format("Some text with a smiley :-) emoticon.");
            PlaceLabels();
            FillSelectBoxData();
            HtmlSelect myDdl = (HtmlSelect)FindControl("Level1");
            //string ddl = Request.Form["Level1"].ToString();
            string day = Request.Form["Level1"];
            //string sCorrectVal = .Value;
            //string correct = Request.Form.Get("Level1");
            //HtmlControl myDdlw = (HtmlControl)form.findcontrol("selecttools");
        }
       
        public void PlaceLabels()
        {
            ApprovelMaster ApprovelMasterobj = new ApprovelMaster();
            DataTable ApprovelLeveldt = new DataTable();
            ApprovelLeveldt = ApprovelMasterobj.getDataFromApprovelLevel();
            lblLevel1.Text = ApprovelLeveldt.Rows[0]["LevelDescription"].ToString();
            lblLevel2.Text = ApprovelLeveldt.Rows[1]["LevelDescription"].ToString();
            lblLevel3.Text = ApprovelLeveldt.Rows[2]["LevelDescription"].ToString();
            //selecttools.DataSource = ApprovelMasterdt;
            //selecttools.DataTextField = "LevelDescription";

            //selecttools.DataValueField = "LevelDescription";
            //selecttools.DataBind();
            //String Option1 = "Hello";
            //String Option2 = "World";
            //myDdl.Items.Add(new ListItem(Option1 + Option2));
            //this.Controls.Add(myDdl);
           //ddlDOBDay.Items.Add(new ListItem("1", "1"));
            //select.DataSource = ApprovelMasterdt;

            //select.DataTextField = "LevelDescription";

            //select.DataValueField = "LevelDescription";
            //select.DataBind();
            //lblLevel4.Text = ApprovelMasterdt.Rows[3]["LevelDescription"].ToString();
        }
        public void FillSelectBoxData()
        {
            string documentType = _DocumentType;
            string projectNo = UA.projectNo;
            //int varifierLevel =0;
            ApprovelMaster ApprovelMasterobj = new ApprovelMaster();
            DataTable Varifierdt = new DataTable();
            Varifierdt = ApprovelMasterobj.getDataFromVarifierMaster( 1,documentType, projectNo);
            string FieldValue = "";
            int totalrows = Varifierdt.Rows.Count;
            for (int i = 0; i < totalrows; i++)
            {
                FieldValue =FieldValue+ Varifierdt.Rows[i]["VerifierID"] + "=" + Varifierdt.Rows[i]["VerifierEmail"] + "||";
            }
            hdfSelectBox1.Value = FieldValue;

            DataTable VarifierdtLevel2 = new DataTable();
            VarifierdtLevel2 = ApprovelMasterobj.getDataFromVarifierMaster(2, documentType, projectNo);
            string FieldValueLevel2 = "";
            int totalrowsLevel2 = VarifierdtLevel2.Rows.Count;
            for (int j = 0; j < totalrowsLevel2; j++)
            {
                FieldValueLevel2 = FieldValueLevel2 + VarifierdtLevel2.Rows[j]["VerifierID"] + "=" + VarifierdtLevel2.Rows[j]["VerifierEmail"] + "||";
            }
           hdfSelectBox2.Value = FieldValueLevel2;

           DataTable VarifierdtLevel3 = new DataTable();
           VarifierdtLevel3 = ApprovelMasterobj.getDataFromVarifierMaster(3, documentType, projectNo);
           string FieldValueLevel3 = "";
           int totalrowsLevel3 = VarifierdtLevel3.Rows.Count;
           for (int k = 0; k < totalrowsLevel3; k++)
           {
               FieldValueLevel3 = FieldValueLevel3 + VarifierdtLevel3.Rows[k]["VerifierID"] + "=" + VarifierdtLevel3.Rows[k]["VerifierEmail"] + "||";
           }
           hdfSelectBox3.Value = FieldValueLevel3;
        }
        protected void btnCloseDocument_Click(object sender, EventArgs e)
        {
            ApprovelMaster ApprovelMasterobj = new ApprovelMaster();
            string level1Id = (Request.Form["Level1"]);
            string level2Id = (Request.Form["Level2"]);
            string level3Id = (Request.Form["Level3"]);
            //string level4Id = (Request.Form["Level4"]);
            string documentType = _DocumentType;
            string projectNo =UA.projectNo;
            System.Guid guid = System.Guid.NewGuid();            
            ApprovelMasterobj.ApprovalID = guid.ToString();
            ApprovelMasterobj.DocumentID = _DocumentID;
            ApprovelMasterobj.RevisionID = _RevisionID;
            ApprovelMasterobj.VerifierID = level1Id;
            ApprovelMasterobj.VerifierLevel = 1;
            ApprovelMasterobj.CreatedBy = UA.userName;

            ApprovelMasterobj.InsertApprovelMaster();

        }
    }
}