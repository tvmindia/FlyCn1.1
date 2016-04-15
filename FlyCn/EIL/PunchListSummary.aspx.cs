using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.EIL
{
    public partial class PunchListSummary : System.Web.UI.Page
    {
        FlyCnDAL.ErrorHandling eObj = new FlyCnDAL.ErrorHandling();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Bind Charts  
                BindChart();
            }  
        }
        public void BindChart()
        {
            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();
            FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
            try
            {
                dsChartData = punchObj.GetChartData();

                strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawVisualization() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['Month-Year', 'Total', 'Opened', 'Closed'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["Month-Year"] + "'," + row["Total"] + "," +
                        row["Opened"] + "," + row["Closed"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title : 'Monthly Punchlist Summary', vAxis: {title: 'Percentage Of Items'},  hAxis: {title: 'Month'}, seriesType: 'bars', series: {3: {type: 'area'}}, animation: { duration: 1000, startup: true } };");
                strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('columnchart_material'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                strScript.Append(" </script>");

                ltScripts.Text = strScript.ToString();
            }
            catch
            {
            }
            finally
            {
                dsChartData.Dispose();
                strScript.Clear();
            }
        }

        protected void printPunchList_Click(object sender, EventArgs e)
        {
          
            try
            {
               FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
               punchObj.GeneratePunchListExcelTemplate();
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);

            }
           
        }  
  
    }
}