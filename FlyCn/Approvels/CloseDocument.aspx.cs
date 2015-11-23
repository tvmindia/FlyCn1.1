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
using System.Threading;
using DocStatus = FlyCn.DocumentSettings.DocumentStatusSettings;

namespace FlyCn.Approvels
{
    public partial class CloseDocument : System.Web.UI.Page
    {
        string _RevisionID;
        string _DocumentID;
        string _DocumentType;
        string _DocumentNo;
        string _HiddenFieldOwner;
        string _HiddendocumentDate;
        int count = 0;
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;
        protected void Page_Load(object sender, EventArgs e)
        {
            UA = (FlyCnDAL.Security.UserAuthendication)Session[Const.LoginSession];
            _RevisionID = Request.QueryString["RevisionID"];
            _DocumentID = Request.QueryString["DocumentID"];
            _DocumentType = Request.QueryString["DocumentType"];
            _DocumentNo = Request.QueryString["DocumentNo"];
            _HiddenFieldOwner = Request.QueryString["hiddenFieldOwner"];
            _HiddendocumentDate = Request.QueryString["hiddendocumentDate"];
            //string caption = "Select Your Varifiers :)";
            string caption = "Select Document Varifiers ";
            //caption = caption.Replace(":)", "<img src='/Images/smile_1.png' alt='Happy!' />");
            lblCaption.Text = caption;
            string tryhdj = DocStatus.Closed;
            PlaceLabels();
         

        }


        #region PlaceLabels
        public void PlaceLabels()
        {
            ApprovelMaster ApprovelMasterobj = new ApprovelMaster();
            DataTable ApprovelLeveldt = new DataTable();
            ApprovelLeveldt = ApprovelMasterobj.getDataFromApprovelLevel();
            int totalrows = ApprovelLeveldt.Rows.Count;
            string DivLevels = "";
            for (int i = 0; i < totalrows; i++)
            {
                Label lbl = (Label)Placeholder.FindControl("lbl" + ApprovelLeveldt.Rows[i]["LevelDescription"]);
                lbl.Text = ApprovelLeveldt.Rows[i]["LevelDescription"].ToString();

                DivLevels = DivLevels + "selecttools" + ApprovelLeveldt.Rows[i]["Level"] + ",";

                FillSelectBoxData();
                if (lbl.Text == "Level1")
                {
                    divLevel1.Visible = true;
                }
                if (lbl.Text == "Level2")
                {

                    divLevel2.Visible = true;
                }
                if (lbl.Text == "Level3")
                {
                    divLevel3.Visible = true;
                }
                if (lbl.Text == "Level4")
                {
                    divLevel4.Visible = true;
                }
                if (lbl.Text == "Level5")
                {
                    divLevel5.Visible = true;
                }
                if (lbl.Text == "Level6")
                {
                    divLevel6.Visible = true;
                }
                if (lbl.Text == "Level7")
                {
                    divLevel7.Visible = true;
                }
                if (lbl.Text == "Level8")
                {
                    divLevel8.Visible = true;
                }
                if (lbl.Text == "Level9")
                {
                    divLevel9.Visible = true;
                }
                if (lbl.Text == "Level10")
                {
                    divLevel10.Visible = true;
                }
            }

            hdfDivLevels.Value = DivLevels.TrimEnd(',');
        }
        #endregion PlaceLabels

        #region FillSelectBoxData
        public void FillSelectBoxData()
        {
            string documentType = _DocumentType;
            string projectNo = UA.projectNo;
            //int varifierLevel =0;
            ApprovelMaster ApprovelMasterobj = new ApprovelMaster();

            DataTable VarifierdtLevel1 = new DataTable();
            VarifierdtLevel1 = ApprovelMasterobj.getDataFromVarifierMaster(1, documentType, projectNo);
            string FieldValueLevel1 = "";
            int totalrowsLevel1 = VarifierdtLevel1.Rows.Count;
            for (int j = 0; j < totalrowsLevel1; j++)
            {
                FieldValueLevel1 = FieldValueLevel1 + VarifierdtLevel1.Rows[j]["VerifierID"] + "=" + VarifierdtLevel1.Rows[j]["VerifierEmail"] + "||";
            }
            hdfSelectBox1.Value = FieldValueLevel1;
            //selecttools1.Items.Insert(0, "Select"); 

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
            for (int j = 0; j < totalrowsLevel3; j++)
            {
                FieldValueLevel3 = FieldValueLevel3 + VarifierdtLevel3.Rows[j]["VerifierID"] + "=" + VarifierdtLevel3.Rows[j]["VerifierEmail"] + "||";
            }
            hdfSelectBox3.Value = FieldValueLevel3;
            DataTable VarifierdtLevel4 = new DataTable();
            VarifierdtLevel4 = ApprovelMasterobj.getDataFromVarifierMaster(4, documentType, projectNo);
            string FieldValueLevel4 = "";
            int totalrowsLevel4 = VarifierdtLevel4.Rows.Count;
            for (int j = 0; j < totalrowsLevel4; j++)
            {
                FieldValueLevel4 = FieldValueLevel4 + VarifierdtLevel4.Rows[j]["VerifierID"] + "=" + VarifierdtLevel4.Rows[j]["VerifierEmail"] + "||";
            }
            hdfSelectBox4.Value = FieldValueLevel4;
            DataTable VarifierdtLevel5 = new DataTable();
            VarifierdtLevel5 = ApprovelMasterobj.getDataFromVarifierMaster(5, documentType, projectNo);
            string FieldValueLevel5 = "";
            int totalrowsLevel5 = VarifierdtLevel5.Rows.Count;
            for (int j = 0; j < totalrowsLevel5; j++)
            {
                FieldValueLevel5 = FieldValueLevel5 + VarifierdtLevel5.Rows[j]["VerifierID"] + "=" + VarifierdtLevel5.Rows[j]["VerifierEmail"] + "||";
            }
            hdfSelectBox5.Value = FieldValueLevel5;

            DataTable VarifierdtLevel6 = new DataTable();
            VarifierdtLevel6 = ApprovelMasterobj.getDataFromVarifierMaster(6, documentType, projectNo);
            string FieldValueLevel6 = "";
            int totalrowsLevel6 = VarifierdtLevel6.Rows.Count;
            for (int j = 0; j < totalrowsLevel6; j++)
            {
                FieldValueLevel6 = FieldValueLevel6 + VarifierdtLevel6.Rows[j]["VerifierID"] + "=" + VarifierdtLevel6.Rows[j]["VerifierEmail"] + "||";
            }
            hdfSelectBox6.Value = FieldValueLevel6;

            DataTable VarifierdtLevel7 = new DataTable();
            VarifierdtLevel7 = ApprovelMasterobj.getDataFromVarifierMaster(7, documentType, projectNo);
            string FieldValueLevel7 = "";
            int totalrowsLevel7 = VarifierdtLevel7.Rows.Count;
            for (int j = 0; j < totalrowsLevel7; j++)
            {
                FieldValueLevel7 = FieldValueLevel7 + VarifierdtLevel7.Rows[j]["VerifierID"] + "=" + VarifierdtLevel7.Rows[j]["VerifierEmail"] + "||";
            }
            hdfSelectBox7.Value = FieldValueLevel7;

            DataTable VarifierdtLevel8 = new DataTable();
            VarifierdtLevel8 = ApprovelMasterobj.getDataFromVarifierMaster(8, documentType, projectNo);
            string FieldValueLevel8 = "";
            int totalrowsLevel8 = VarifierdtLevel8.Rows.Count;
            for (int j = 0; j < totalrowsLevel8; j++)
            {
                FieldValueLevel8 = FieldValueLevel8 + VarifierdtLevel8.Rows[j]["VerifierID"] + "=" + VarifierdtLevel8.Rows[j]["VerifierEmail"] + "||";
            }
            hdfSelectBox8.Value = FieldValueLevel8;

            DataTable VarifierdtLevel9 = new DataTable();
            VarifierdtLevel9 = ApprovelMasterobj.getDataFromVarifierMaster(9, documentType, projectNo);
            string FieldValueLevel9 = "";
            int totalrowsLevel9 = VarifierdtLevel9.Rows.Count;
            for (int j = 0; j < totalrowsLevel9; j++)
            {
                FieldValueLevel9 = FieldValueLevel9 + VarifierdtLevel9.Rows[j]["VerifierID"] + "=" + VarifierdtLevel9.Rows[j]["VerifierEmail"] + "||";
            }
            hdfSelectBox9.Value = FieldValueLevel9;

            DataTable VarifierdtLevel10 = new DataTable();
            VarifierdtLevel10 = ApprovelMasterobj.getDataFromVarifierMaster(10, documentType, projectNo);
            string FieldValueLevel10 = "";
            int totalrowsLevel10 = VarifierdtLevel10.Rows.Count;
            for (int j = 0; j < totalrowsLevel10; j++)
            {
                FieldValueLevel10 = FieldValueLevel10 + VarifierdtLevel10.Rows[j]["VerifierID"] + "=" + VarifierdtLevel10.Rows[j]["VerifierEmail"] + "||";
            }
            hdfSelectBox10.Value = FieldValueLevel10;
        }

        #endregion FillSelectBoxData

        #region CloseDocumentButtonClick
        protected void btnCloseDocument_Click(object sender, EventArgs e)
        {



            byte isLevelManadatory = 0;
            string level1IdData;
            string level1Id;

            level1IdData = Request.Form["Level1"];
            if (level1IdData != null)
            {
                List<string> level1List = level1IdData.Split(',').ToList<string>();
                foreach (var item in level1List)
                {
                    level1Id = item;
                    if (chkLevel1.Checked == true)
                    {
                        isLevelManadatory = Convert.ToByte(true);
                    }
                    InsertOperation(level1Id, 1, isLevelManadatory);

                }

            }

            string level2Id;
            string level2IdData;
            level2IdData = Request.Form["Level2"];
            if (level2IdData != null)
            {
                List<string> level2List = level2IdData.Split(',').ToList<string>();
                foreach (var item in level2List)
                {
                    level2Id = item;
                    if (chkLevel2.Checked == true)
                    {
                        isLevelManadatory = Convert.ToByte(true);
                    }
                    InsertOperation(level2Id, 2, isLevelManadatory);

                }

            }



            string level3Id;
            string level3IdData;
            level3IdData = Request.Form["Level3"];
            if (level3IdData != null)
            {
                List<string> level3List = level3IdData.Split(',').ToList<string>();
                foreach (var item in level3List)
                {
                    level3Id = item;
                    if (chkLevel3.Checked == true)
                    {
                        isLevelManadatory = Convert.ToByte(true);
                    }
                    InsertOperation(level3Id, 3, isLevelManadatory);


                }

            }

            string level4Id;
            string level4IdData;
            level4IdData = Request.Form["Level4"];
            if (level4IdData != null)
            {
                List<string> level4List = level4IdData.Split(',').ToList<string>();
                foreach (var item in level4List)
                {
                    level4Id = item;
                    if (chkLevel4.Checked == true)
                    {
                        isLevelManadatory = Convert.ToByte(true);
                    }
                    InsertOperation(level4Id, 4, isLevelManadatory);


                }

            }


            string level5Id;
            string level5IdData;
            level5IdData = Request.Form["Level5"];
            if (level5IdData != null)
            {
                List<string> level5List = level5IdData.Split(',').ToList<string>();
                foreach (var item in level5List)
                {
                    level5Id = item;
                    if (chkLevel5.Checked == true)
                    {
                        isLevelManadatory = Convert.ToByte(true);
                    }
                    InsertOperation(level5Id, 5, isLevelManadatory);


                }

            }


            string level6Id;

            string level6IdData;
            level6IdData = Request.Form["Level6"];
            if (level6IdData != null)
            {
                List<string> level6List = level6IdData.Split(',').ToList<string>();
                foreach (var item in level6List)
                {
                    level6Id = item;
                    if (chkLevel6.Checked == true)
                    {
                        isLevelManadatory = Convert.ToByte(true);
                    }
                    InsertOperation(level6Id, 6, isLevelManadatory);

                }

            }
            string level7Id;
            string level7IdData;
            level7IdData = Request.Form["Level7"];
            if (level7IdData != null)
            {
                List<string> level7List = level7IdData.Split(',').ToList<string>();
                foreach (var item in level7List)
                {
                    level7Id = item;
                    if (chkLevel7.Checked == true)
                    {
                        isLevelManadatory = Convert.ToByte(true);
                    }
                    InsertOperation(level7Id, 7, isLevelManadatory);


                }

            }

            string level8Id;
            string level8IdData;
            level8IdData = Request.Form["Level8"];
            if (level8IdData != null)
            {
                List<string> level8List = level8IdData.Split(',').ToList<string>();
                foreach (var item in level8List)
                {
                    level8Id = item;
                    if (chkLevel8.Checked == true)
                    {
                        isLevelManadatory = Convert.ToByte(true);
                    }
                    InsertOperation(level8Id, 8, isLevelManadatory);


                }

            }

            string level9Id;
            string level9IdData;
            level9IdData = Request.Form["Level9"];
            if (level9IdData != null)
            {
                List<string> level9List = level9IdData.Split(',').ToList<string>();
                foreach (var item in level9List)
                {
                    level9Id = item;
                    if (chkLevel9.Checked == true)
                    {
                        isLevelManadatory = Convert.ToByte(true);
                    }
                    InsertOperation(level9Id, 9, isLevelManadatory);


                }

            }

            string level10Id;
            string level10IdData;
            level10IdData = Request.Form["Level10"];
            if (level10IdData != null)
            {
                List<string> level10List = level10IdData.Split(',').ToList<string>();
                foreach (var item in level10List)
                {
                    level10Id = item;
                    if (chkLevel10.Checked == true)
                    {
                        isLevelManadatory = Convert.ToByte(true);
                    }
                    InsertOperation(level10Id, 10, isLevelManadatory);


                }

            }
            hiddenCloseFlag.Value = "1";
            FlyCn.FlyCnDAL.MailSending MailSendingobj = new MailSending();

           MailSendingobj.SendMailToNextLevelVarifiers(_RevisionID);
           //FlyCn.BOQ.BOQHeader boqObj = new BOQ.BOQHeader();
           //boqObj.Page.();
         
        }

        #endregion CloseDocumentButtonClick

        #region InsertOperation
        public void InsertOperation(string levelId, int Level, byte isLevelManadatory)
        {
            ApprovelMaster ApprovelMasterobj = new ApprovelMaster();
           
            string documentType = _DocumentType;
            string projectNo = UA.projectNo;
            System.Guid guid = System.Guid.NewGuid();
            ApprovelMasterobj.ApprovalID = guid.ToString();
            ApprovelMasterobj.DocumentID = _DocumentID;
            ApprovelMasterobj.RevisionID = _RevisionID;
            ApprovelMasterobj.VerifierID = levelId;
            ApprovelMasterobj.VerifierLevel = Level;
            ApprovelMasterobj.CreatedBy = UA.userName;
            ApprovelMasterobj.ApprovalStatus = 1;
            ApprovelMasterobj.IsLevelManadatory = isLevelManadatory;

            ApprovelMasterobj.InsertApprovelMaster();
            ApprovelMasterobj.InsertApprovalLog();


        }

        #endregion InsertOperation


    }
}