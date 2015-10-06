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
        string _id1;
        protected void Page_Load(object sender, EventArgs e)
        {
            _id1 = Request.QueryString["id"];
            //txtEmpCode.Text = _id1;
            hdfRevisionId.Value = _id1;
            lblrevisionid.Text = _id1;
            PlaceLabels();
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
            DataTable ApprovelMasterdt = new DataTable();
            ApprovelMasterdt = ApprovelMasterobj.getDataFromApprovelMaster();
            lblLevel1.Text = ApprovelMasterdt.Rows[0]["LevelDescription"].ToString();
            lblLevel2.Text = ApprovelMasterdt.Rows[1]["LevelDescription"].ToString();
            lblLevel3.Text = ApprovelMasterdt.Rows[2]["LevelDescription"].ToString();
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

        protected void btnCloseDocument_Click(object sender, EventArgs e)
        {
            string level1Id = (Request.Form["Level1"]);
            string level2Id = (Request.Form["Level2"]);
            string level3Id = (Request.Form["Level3"]);
            string level4Id = (Request.Form["Level4"]);
           
        }
    }
}