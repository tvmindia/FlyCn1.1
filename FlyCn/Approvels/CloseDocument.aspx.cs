using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlyCn.FlyCnDAL;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
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
            caption = caption.Replace(":)", "<img src='/Images/smile_1.png' alt='Happy!' />");
            lblrevisionid.Text = caption;
            //lblrevisionid.Text = Emoticon.Format("Some text with a smiley :-) emoticon.");
            PlaceLabels();

            //HtmlSelect myDdl = (HtmlSelect)FindControl("selecttools1");
            //string ddl = Request.Form["Level1"].ToString();
            //string day = Request.Form["Level1"];
            //string sCorrectVal = .Value;
            //string correct = Request.Form.Get("Level1");
            //HtmlControl myDdlw = (HtmlControl)Placeholder.findcontrol("selecttools");
            HtmlControl lbls = (HtmlControl)Placeholder.FindControl("selecttools");
            Control table = (HtmlControl)FindControl("selecttools");
            Control c = Page.FindControl("selecttools");
            //          HtmlControl Label1 = (HtmlControl)Master.FindControl("selecttools");
            //          HtmlControl contentPanel1 = (HtmlControl)Master.FindControl("IframeContent");
            //          HtmlSelect l = contentPanel1.FindControl("selecttools") as HtmlSelect;
            //          HtmlSelect TB =
            //Master.FindControl("ContentPlaceHolder1").FindControl("select-tools2") as
            //HtmlSelect;
        }

        protected override void OnPreRender(EventArgs e)
        {

            selecttools1.ClientIDMode = ClientIDMode.Static;
            selecttools2.ClientIDMode = ClientIDMode.Static;
            selecttools3.ClientIDMode = ClientIDMode.Static;
            selecttools4.ClientIDMode = ClientIDMode.Static;
            selecttools5.ClientIDMode = ClientIDMode.Static;
            selecttools6.ClientIDMode = ClientIDMode.Static;
            selecttools7.ClientIDMode = ClientIDMode.Static;
            selecttools8.ClientIDMode = ClientIDMode.Static;
            selecttools9.ClientIDMode = ClientIDMode.Static;
            selecttools10.ClientIDMode = ClientIDMode.Static;
        }

        public void PlaceLabels()
        {
            ApprovelMaster ApprovelMasterobj = new ApprovelMaster();
            DataTable ApprovelLeveldt = new DataTable();
            ApprovelLeveldt = ApprovelMasterobj.getDataFromApprovelLevel();
            int totalrows = ApprovelLeveldt.Rows.Count;
            for (int i = 0; i < totalrows; i++)
            {
                Label lbl = (Label)Placeholder.FindControl("lbl" + ApprovelLeveldt.Rows[i]["LevelDescription"]);
                lbl.Text = ApprovelLeveldt.Rows[i]["LevelDescription"].ToString();
                HtmlSelect myDdl = (HtmlSelect)FindControl("selecttools");
                HtmlControl ctrl = (HtmlControl)this.FindControl("selecttools");
                System.Web.UI.HtmlControls.HtmlGenericControl div1 = (System.Web.UI.HtmlControls.HtmlGenericControl)this.FindControl("selecttools");
                FillSelectBoxData();
                if (lbl.Text == "Level1")
                {
                    selecttools1.Visible = true;
                    chkLevel1.Visible = true;
                }
                if (lbl.Text == "Level2")
                {
                    selecttools2.Visible = true;
                    chkLevel2.Visible = true;
                }
                if (lbl.Text == "Level3")
                {
                    selecttools3.Visible = true;
                    chkLevel3.Visible = true;
                }
                if (lbl.Text == "Level4")
                {
                    selecttools4.Visible = true;
                    chkLevel4.Visible = true;
                }
                if (lbl.Text == "Level5")
                {
                    selecttools5.Visible = true;
                    chkLevel5.Visible = true;
                }
                if (lbl.Text == "Level6")
                {
                    selecttools6.Visible = true;
                    chkLevel6.Visible = true;
                }
                if (lbl.Text == "Level7")
                {
                    selecttools7.Visible = true;
                    chkLevel7.Visible = true;
                }
                if (lbl.Text == "Level8")
                {
                    selecttools8.Visible = true;
                    chkLevel8.Visible = true;
                }
                if (lbl.Text == "Level9")
                {
                    selecttools9.Visible = true;
                    chkLevel9.Visible = true;
                }
            }

        }
        public void FillSelectBoxData()
        {
            string documentType = _DocumentType;
            string projectNo = UA.projectNo;
            //int varifierLevel =0;
            ApprovelMaster ApprovelMasterobj = new ApprovelMaster();
            DataTable Varifierdt = new DataTable();
            Varifierdt = ApprovelMasterobj.getDataFromVarifierMaster(1, documentType, projectNo);
            selecttools1.DataSource = Varifierdt;
            selecttools1.DataTextField = "VerifierEmail";
            selecttools1.DataValueField = "VerifierID";
            selecttools1.DataBind();
            //selecttools1.Items.Insert(0, "Select"); 

            DataTable VarifierdtLevel2 = new DataTable();
            VarifierdtLevel2 = ApprovelMasterobj.getDataFromVarifierMaster(2, documentType, projectNo);

            selecttools2.DataSource = VarifierdtLevel2;
            selecttools2.DataTextField = "VerifierEmail";
            selecttools2.DataValueField = "VerifierID";
            selecttools2.DataBind();

            DataTable VarifierdtLevel3 = new DataTable();
            VarifierdtLevel3 = ApprovelMasterobj.getDataFromVarifierMaster(3, documentType, projectNo);
            selecttools3.DataSource = VarifierdtLevel2;
            selecttools3.DataTextField = "VerifierEmail";
            selecttools3.DataValueField = "VerifierID";
            selecttools3.DataBind();
            DataTable VarifierdtLevel4 = new DataTable();
            VarifierdtLevel4 = ApprovelMasterobj.getDataFromVarifierMaster(4, documentType, projectNo);
            selecttools4.DataSource = VarifierdtLevel4;
            selecttools4.DataTextField = "VerifierEmail";
            selecttools4.DataValueField = "VerifierID";
            selecttools4.DataBind();

            DataTable VarifierdtLevel5 = new DataTable();
            VarifierdtLevel5 = ApprovelMasterobj.getDataFromVarifierMaster(5, documentType, projectNo);
            selecttools5.DataSource = VarifierdtLevel5;
            selecttools5.DataTextField = "VerifierEmail";
            selecttools5.DataValueField = "VerifierID";
            selecttools5.DataBind();

            DataTable VarifierdtLevel6 = new DataTable();
            VarifierdtLevel6 = ApprovelMasterobj.getDataFromVarifierMaster(6, documentType, projectNo);
            selecttools6.DataSource = VarifierdtLevel6;
            selecttools6.DataTextField = "VerifierEmail";
            selecttools6.DataValueField = "VerifierID";
            selecttools6.DataBind();

            DataTable VarifierdtLevel7 = new DataTable();
            VarifierdtLevel7 = ApprovelMasterobj.getDataFromVarifierMaster(7, documentType, projectNo);
            selecttools7.DataSource = VarifierdtLevel7;
            selecttools7.DataTextField = "VerifierEmail";
            selecttools7.DataValueField = "VerifierID";
            selecttools7.DataBind();

            DataTable VarifierdtLevel8 = new DataTable();
            VarifierdtLevel8 = ApprovelMasterobj.getDataFromVarifierMaster(8, documentType, projectNo);
            selecttools8.DataSource = VarifierdtLevel8;
            selecttools8.DataTextField = "VerifierEmail";
            selecttools8.DataValueField = "VerifierID";
            selecttools8.DataBind();

            DataTable VarifierdtLevel9 = new DataTable();
            VarifierdtLevel9 = ApprovelMasterobj.getDataFromVarifierMaster(9, documentType, projectNo);
            selecttools9.DataSource = VarifierdtLevel9;
            selecttools9.DataTextField = "VerifierEmail";
            selecttools9.DataValueField = "VerifierID";
            selecttools9.DataBind();
        }
        protected void btnCloseDocument_Click(object sender, EventArgs e)
        {
            string level1Idf = (Request.Form["selecttools1"]);
            ApprovelMaster ApprovelMasterobj = new ApprovelMaster();
            string level1="";
            //string JJ = selecttools1.SelectedIndex.ToString();
            string selection = Request.Form["Level1"];
            //foreach (ListItem Items in selecttools1.Items)
            //{
            //   
            //    //level1 = level1 + selecttools1.Value + ",";
            //    if (Items.Selected)
            //    {
            //        level1 = selecttools1.Value;
            //        if (chkLevel1.Checked == true)
            //        {
            //            isLevelManadatory = Convert.ToByte(true);
            //            InsertOperation(level1, 1, isLevelManadatory);

            //        }
            //    }

            //}
            byte isLevelManadatory = 0;
            //for (int i = 0; i <= selecttools1.Items.Count - 1; i++)
            //{

            //    if (selecttools1.Items[i].Selected)
            //        level1+=  selecttools1.Items[i].Text;

            //}

            //for (int i = 0; i < selecttools1.Items.Count; i++)
            //{

            //    if (selecttools1.Items[i].Selected != null)
            //    {
            //        string query = selecttools1.Items[i].Value;
            //        level1 = query;
            //        if (chkLevel1.Checked == true)
            //        {
            //            isLevelManadatory = Convert.ToByte(true);


            //        }
            //        InsertOperation(level1, 1, isLevelManadatory);
            //    }
            //}
            //string name = "";
            //for (int i = 0; i < selecttools1.Items.Count; i++)
            //{
            //    if (selecttools1.Items[i].Selected)
            //    {
            //        name += selecttools1.Items[i].Text + ",";
            //    }
            //}
            //string smndsa = name;
            string s = selecttools1.Multiple.ToString();
            string ghgh = selecttools1.Value;

            string level2Id;
            foreach (ListItem item in selecttools2.Items)
            {

                if (chkLevel2.Checked == true)
                {
                    isLevelManadatory = Convert.ToByte(true);
                }

                level2Id = selecttools2.Value;
                InsertOperation(level2Id, 2, isLevelManadatory);

            }
            string level3Id;
            foreach (ListItem item in selecttools3.Items)
            {


                if (chkLevel3.Checked == true)
                {
                    isLevelManadatory = Convert.ToByte(true);
                }

                level3Id = selecttools3.Value;
                InsertOperation(level3Id, 3, isLevelManadatory);

            }

            string level4Id;
            foreach (ListItem item in selecttools4.Items)
            {


                if (chkLevel4.Checked == true)
                {
                    isLevelManadatory = Convert.ToByte(true);
                }


                level4Id = selecttools4.Value;
                InsertOperation(level4Id, 4, isLevelManadatory);

            }
            string level5Id;
            foreach (ListItem item in selecttools5.Items)
            {

                if (chkLevel5.Checked == true)
                {
                    isLevelManadatory = Convert.ToByte(true);
                }

                level5Id = selecttools5.Value;
                InsertOperation(level5Id, 5, isLevelManadatory);

            }

            string level6Id;
            foreach (ListItem item in selecttools6.Items)
            {


                if (chkLevel6.Checked == true)
                {
                    isLevelManadatory = Convert.ToByte(true);
                }

                level6Id = selecttools6.Value;
                InsertOperation(level6Id, 6, isLevelManadatory);

            }

            string level7Id;
            foreach (ListItem item in selecttools7.Items)
            {


                if (chkLevel7.Checked == true)
                {
                    isLevelManadatory = Convert.ToByte(true);
                }
                level7Id = selecttools7.Value;
                InsertOperation(level7Id, 7, isLevelManadatory);

            }

            string level8Id;
            foreach (ListItem item in selecttools8.Items)
            {



                if (chkLevel8.Checked == true)
                {
                    isLevelManadatory = Convert.ToByte(true);
                }
                level8Id = selecttools8.Value;
                InsertOperation(level8Id, 8, isLevelManadatory);

            }

            string level9Id;
            foreach (ListItem item in selecttools9.Items)
            {


                if (chkLevel9.Checked == true)
                {
                    isLevelManadatory = Convert.ToByte(true);
                }

                level9Id = selecttools9.Value;
                InsertOperation(level9Id, 9, isLevelManadatory);

            }

            string level10Id;
            foreach (ListItem item in selecttools10.Items)
            {


                if (chkLevel10.Checked == true)
                {
                    isLevelManadatory = Convert.ToByte(true);
                }
                level10Id = selecttools10.Value;
                InsertOperation(level10Id, 10, isLevelManadatory);

            }

            FlyCn.FlyCnDAL.MailSending MailSendingobj = new MailSending();
            MailSendingobj.SendingMail();

        }
        public void InsertOperation(string level1Id, int Level, byte isLevelManadatory)
        {
            ApprovelMaster ApprovelMasterobj = new ApprovelMaster();

            string documentType = _DocumentType;
            string projectNo = UA.projectNo;
            System.Guid guid = System.Guid.NewGuid();
            ApprovelMasterobj.ApprovalID = guid.ToString();
            ApprovelMasterobj.DocumentID = _DocumentID;
            ApprovelMasterobj.RevisionID = _RevisionID;
            ApprovelMasterobj.VerifierID = level1Id;
            ApprovelMasterobj.VerifierLevel = Level;
            ApprovelMasterobj.CreatedBy = UA.userName;
            ApprovelMasterobj.IsLevelManadatory = isLevelManadatory;
            ApprovelMasterobj.InsertApprovelMaster();
        }
    }
}