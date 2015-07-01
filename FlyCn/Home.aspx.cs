using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSlider();
        }


        private void LoadSlider()
        {
            FlyCnDAL.SliderDataAccess da = new FlyCnDAL.SliderDataAccess();
            DataSet ds = da.getSliderContent();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string img = ds.Tables[0].Rows[i]["ImagePath"].ToString();
                string Description = ds.Tables[0].Rows[i]["Description"].ToString();
                string Caption = ds.Tables[0].Rows[i]["Caption"].ToString();
                string myInnerHtml = " <div>" +

                   " <img" + " u" + "=" + "image" + " src=" + "'" + img + "'" + "/>" +
                   " <div" + " style" + "=" + "'position: absolute; width: 480px; height: 120px; top: 30px; left: 30px; padding: 5px;text-align: left;" +
                     "line-height: 60px; text-transform: uppercase; font-size: 40px;color:#FFFFFF;'" + ">" +
                     Description +
                   "   </div>" +
                   " <div style=" + "'position: absolute; width: 480px; height: 120px; top: 300px; left: 30px; padding: 5px;text-align: left; line-height: 36px; font-size: 30px;color:#FFFFFF;'" + ">" +
                     Caption +
                   " </div>" +
                   "</div>";
                slides.Controls.Add(new LiteralControl(myInnerHtml));
            }
        }

    }
}