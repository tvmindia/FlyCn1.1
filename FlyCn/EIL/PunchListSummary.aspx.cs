using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.EIL
{
    public partial class PunchListSummary : System.Web.UI.Page
    {
        FlyCnDAL.ErrorHandling eObj = new FlyCnDAL.ErrorHandling();

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.collapsenode();", true);
            if (!Page.IsPostBack)
            {
                // Bind Charts  
                BindChart();
                BindProjectManpowerChart();
                BindProjectByAreaChart();
                BindGetProgressByFIWPChart();
            }  
        }
        #endregion Page_Load

        #region BindChart
        public void BindChart()
        {
            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();
            FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
            try
            {
                dsChartData = punchObj.GetChartData();
                //int total = Convert.ToInt32(dsChartData.Rows[0]["Total"]);
                if (dsChartData.Rows.Count>0)
                {
                    strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawVisualization() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['Month-Year', 'Total', 'Open', 'Closed'],");

                    foreach (DataRow row in dsChartData.Rows)
                    {
                        strScript.Append("['" + row["Month-Year"] + "'," + row["Total"] + "," +
                            row["Opened"] + "," + row["Closed"] + "],");
                    }
                    strScript.Remove(strScript.Length - 1, 1);
                    strScript.Append("]);");

                    strScript.Append("var options = { title : 'Monthly Punchlist Summary', vAxis: {title: 'Count Of Items', viewWindow:{max:16,min:0}, gridlines: { count:9}},  hAxis: {title: 'Month'}, backgroundColor: '#fff2e6',seriesType: 'bars', series: {3: {type: 'area'}}, animation: { duration: 1000, startup: true } };");
                    strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('columnchart_material'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                    strScript.Append(" </script>");

                    ltScripts.Text = strScript.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearTextBox", "drawPunchListSummary();", true);
                }
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
        #endregion BindChart

        #region BindProjectManpowerChart
        public void BindProjectManpowerChart()
        {
            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();
            FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
            try
            {
                dsChartData = punchObj.GetProjectManpowerChartData();
                int total = Convert.ToInt32(dsChartData.Rows[2]["Welders"]);
                int empTotal = Convert.ToInt32(dsChartData.Rows[2]["Employee"]);
                if (total!=0||empTotal!=0)
                {
                    strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawVisualization() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['Categories', 'Employee', 'Welders'],");

                    foreach (DataRow row in dsChartData.Rows)
                    {
                        strScript.Append("['" + row["Categories"] + "'," + row["Employee"] + "," +
                            row["Welders"] + "],");
                    }
                    strScript.Remove(strScript.Length - 1, 1);
                    strScript.Append("]);");

                    strScript.Append("var options = { title : 'Project-Manpower Graph',bar: {groupWidth: '30%'}, vAxis: {title: 'Count', viewWindow:{max:50,min:0}, gridlines: { count:10}},  hAxis: {title: 'Category'}, backgroundColor: '#f0f0f5',seriesType: 'bars', series: {3: {type: 'area'}}, animation: { duration: 1000, startup: true } };");
                    strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('columnchart_material1'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                    strScript.Append(" </script>");

                    ltManpowerScripts.Text = strScript.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ClearTextBox", "drawChart();", true);
                }
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
        #endregion BindProjectManpowerChart

        #region BindProjectByAreaChart
        public void BindProjectByAreaChart()
        {
            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();
            FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
            try
            {
                dsChartData = punchObj.GetProjectByAreaGraphDetails();
                strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawVisualization() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['Area', 'Workdone', 'Weighted'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["Area"] + "'," + row["Workdone"] + "," +
                        row["Weighted"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title : 'Project-By-Area Graph',bar: {groupWidth: '30%'}, vAxis: {title: 'Percentage', viewWindow:{max:50,min:0}, gridlines: { count:10}},  hAxis: {title: 'Area'}, backgroundColor: '#f4f4d7',seriesType: 'bars', series: {3: {type: 'area'}}, animation: { duration: 1000, startup: true } };");
                strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('columnchart_material2'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                strScript.Append(" </script>");

                ltProjectByArea.Text = strScript.ToString();

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
        #endregion BindProjectByAreaChart

        #region BindGetProgressByFIWPChart
        public void BindGetProgressByFIWPChart()
        {
            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();
            FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
            try
            {
                dsChartData = punchObj.GetProgressByFIWPDetails();
                strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawVisualization() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['FIWP', 'Weightage', 'Weighted'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["FIWP"] + "'," + row["Weightage"] + "," +
                        row["Weighted"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title : 'Progress-By-FIWP Graph',bar: {groupWidth: '30%'}, vAxis: {title: 'Percentage', viewWindow:{max:50,min:0}, gridlines: { count:10}},  hAxis: {title: 'FIWP'}, backgroundColor: '#ebfaeb',seriesType: 'bars', series: {3: {type: 'area'}}, animation: { duration: 1000, startup: true } };");
                strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('columnchart_material3'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                strScript.Append(" </script>");

                ltProgressByFIWP.Text = strScript.ToString();

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
        #endregion BindGetProgressByFIWPChart

        #region PunchListSummary_Download
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
                DataTable dt = punchObj.GetChartData();
                FlyCnDAL.ExcelReportSettings excelObj = new FlyCnDAL.ExcelReportSettings();
                Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
                //  xla.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
                //********************** Now create the chart. *****************************
                Microsoft.Office.Interop.Excel.ChartObjects chartObjs = (Microsoft.Office.Interop.Excel.ChartObjects)ws.ChartObjects(Type.Missing);
                Microsoft.Office.Interop.Excel.ChartObject chartObj = chartObjs.Add(250, 60, 300, 300);
                Microsoft.Office.Interop.Excel.Chart xlChart = chartObj.Chart;
                excelObj.pageTitle = "PunchList Summary Report";
                excelObj.GenerateReport(ws);
                int colIndex = 1;
                int rowIndex = 5;

                ws.Columns.AutoFit();
                foreach (DataColumn column in dt.Columns)
                {
                    string columnName = Convert.ToString(column.ColumnName);

                    ws.Cells[rowIndex, colIndex].Value = columnName;

                    colIndex++;
                }
                rowIndex++;

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    colIndex = 1;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        ws.Cells[rowIndex, colIndex].Value = dt.Rows[j][dc.ColumnName].ToString();
                        colIndex++;
                    }
                    rowIndex++;
                }


                int nRows = 5;
                int nColumns = dt.Rows.Count;
                string upperLeftCell = "A5";
                int endRowNumber = System.Int32.Parse(upperLeftCell.Substring(1))
                    + nRows - 1;
                char endColumnLetter = System.Convert.ToChar(
                    Convert.ToInt32(upperLeftCell[0]) + nColumns - 1);
                string upperRightCell = System.String.Format("{0}{1}",
                    endColumnLetter, System.Int32.Parse(upperLeftCell.Substring(1)));
                string lowerRightCell = System.String.Format("{0}{1}",
                    endColumnLetter, endRowNumber);

                Microsoft.Office.Interop.Excel.Range chartRange = ws.get_Range(upperLeftCell, lowerRightCell);
                xlChart.SetSourceData(chartRange, Type.Missing);
                xlChart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered;

               
                // *********************Add title: *******************************
                xlChart.HasTitle = true;
                xlChart.ChartTitle.Text = "PunchList Summary";

                // *****************Set legend:***************************
                xlChart.HasLegend = true;

              
                string file = "PunchlistSummary";
                string path = ("~/Content/ExcelTemplate/");

                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Current.Response.AddHeader("content-disposition",
                                                "attachment;filename=" + file + ".xlsx");
                string filepath = path + file + ".xlsx";
                // wb.SaveCopyAs(Server.MapPath(filepath));
                if (File.Exists(HttpContext.Current.Server.MapPath(filepath)))
                {
                    File.Delete(HttpContext.Current.Server.MapPath(filepath));
                    // System.IO.File.Delete(filepath);
                    wb.SaveAs(HttpContext.Current.Server.MapPath(filepath));
                    wb.Close();
                    xla.Quit();
                    HttpContext.Current.Response.TransmitFile(HttpContext.Current.Server.MapPath(filepath));
                    HttpContext.Current.Response.End();
                }
                else
                {

                    //  errorstatus = "saving";
                    wb.SaveAs(HttpContext.Current.Server.MapPath(filepath));
                    wb.Close();
                    xla.Quit();


                    HttpContext.Current.Response.TransmitFile(HttpContext.Current.Server.MapPath(filepath));
                    HttpContext.Current.Response.End();
                    // errorstatus = "saved";

                }
                xla.Visible = true;
              
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);

            }
          
        }
        #endregion PunchListSummary_Download

        #region Project-ManpowerDownload
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
                DataTable dt = punchObj.GetProjectManpowerChartData();
                FlyCnDAL.ExcelReportSettings excelObj = new FlyCnDAL.ExcelReportSettings();

                Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
                
                Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
                //********************** Now create the chart. *****************************
                Microsoft.Office.Interop.Excel.ChartObjects chartObjs = (Microsoft.Office.Interop.Excel.ChartObjects)ws.ChartObjects(Type.Missing);
                Microsoft.Office.Interop.Excel.ChartObject chartObj = chartObjs.Add(250, 60, 300, 300);
                Microsoft.Office.Interop.Excel.Chart xlChart = chartObj.Chart;
                excelObj.pageTitle = "Project Manpower Report";
                excelObj.GenerateReport(ws);
                int colIndex = 1;
                int rowIndex = 5;

                ws.Columns.AutoFit();
                foreach (DataColumn column in dt.Columns)
                {
                    string columnName = Convert.ToString(column.ColumnName);

                    ws.Cells[rowIndex, colIndex].Value = columnName;

                    colIndex++;
                }
                rowIndex++;

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    colIndex = 1;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        ws.Cells[rowIndex, colIndex].Value = dt.Rows[j][dc.ColumnName].ToString();
                        colIndex++;
                    }
                    rowIndex++;
                }


                int nRows = 5;
                int nColumns = dt.Rows.Count;
                string upperLeftCell = "A5";
                int endRowNumber = System.Int32.Parse(upperLeftCell.Substring(1))
                    + nRows - 1;
                char endColumnLetter = System.Convert.ToChar(
                    Convert.ToInt32(upperLeftCell[0]) + nColumns - 1);
                string upperRightCell = System.String.Format("{0}{1}",
                    endColumnLetter, System.Int32.Parse(upperLeftCell.Substring(1)));
                string lowerRightCell = System.String.Format("{0}{1}",
                    endColumnLetter, endRowNumber);

                Microsoft.Office.Interop.Excel.Range chartRange = ws.get_Range(upperLeftCell, lowerRightCell);
                xlChart.SetSourceData(chartRange, Type.Missing);
                xlChart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered;

                Microsoft.Office.Interop.Excel.SeriesCollection oSeriesCollection = (Microsoft.Office.Interop.Excel.SeriesCollection)chartObj.Chart.SeriesCollection(Type.Missing);
                Microsoft.Office.Interop.Excel.Series series1 = oSeriesCollection.Item(1);
                series1.Delete();
              
                // *********************Add title: *******************************
                xlChart.HasTitle = true;
                xlChart.ChartTitle.Text = "Project-Manpower Graph";

                // *****************Set legend:***************************
                xlChart.HasLegend = true;

             
                string file = "ProjectManpower";
                string path = ("~/Content/ExcelTemplate/");

                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Current.Response.AddHeader("content-disposition",
                                                "attachment;filename=" + file + ".xlsx");
                string filepath = path + file + ".xlsx";
                // wb.SaveCopyAs(Server.MapPath(filepath));
                if (File.Exists(HttpContext.Current.Server.MapPath(filepath)))
                {
                    File.Delete(HttpContext.Current.Server.MapPath(filepath));
                    // System.IO.File.Delete(filepath);
                    wb.SaveAs(HttpContext.Current.Server.MapPath(filepath));
                    wb.Close();
                    xla.Quit();
                    HttpContext.Current.Response.TransmitFile(HttpContext.Current.Server.MapPath(filepath));
                    HttpContext.Current.Response.End();
                }
                else
                {

                    //  errorstatus = "saving";
                    wb.SaveAs(HttpContext.Current.Server.MapPath(filepath));
                    wb.Close();
                    xla.Quit();


                    HttpContext.Current.Response.TransmitFile(HttpContext.Current.Server.MapPath(filepath));
                    HttpContext.Current.Response.End();
                    // errorstatus = "saved";

                }
                xla.Visible = true;
               
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);

            }
           
        }
        #endregion Project-ManpowerDownload

        #region Project-By-AreaDownload
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
                DataTable dt = punchObj.GetProjectByAreaGraphDetails();
                FlyCnDAL.ExcelReportSettings excelObj = new FlyCnDAL.ExcelReportSettings();

                Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
                //********************** Now create the chart. *****************************
                Microsoft.Office.Interop.Excel.ChartObjects chartObjs = (Microsoft.Office.Interop.Excel.ChartObjects)ws.ChartObjects(Type.Missing);
                Microsoft.Office.Interop.Excel.ChartObject chartObj = chartObjs.Add(250, 60, 300, 300);
                Microsoft.Office.Interop.Excel.Chart xlChart = chartObj.Chart;
                excelObj.pageTitle = "Project-By-Area Report";
                excelObj.GenerateReport(ws);
                int colIndex = 1;
                int rowIndex = 5;

                ws.Columns.AutoFit();
                foreach (DataColumn column in dt.Columns)
                {
                    string columnName = Convert.ToString(column.ColumnName);

                    ws.Cells[rowIndex, colIndex].Value = columnName;

                    colIndex++;
                }
                rowIndex++;

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    colIndex = 1;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        ws.Cells[rowIndex, colIndex].Value = dt.Rows[j][dc.ColumnName].ToString();
                        colIndex++;
                    }
                    rowIndex++;
                }


                int nRows = 5;
                int nColumns = dt.Rows.Count;
                string upperLeftCell = "A5";
                int endRowNumber = System.Int32.Parse(upperLeftCell.Substring(1))
                    + nRows - 1;
                char endColumnLetter = System.Convert.ToChar(
                    Convert.ToInt32(upperLeftCell[0]) + nColumns - 1);
                string upperRightCell = System.String.Format("{0}{1}",
                    endColumnLetter, System.Int32.Parse(upperLeftCell.Substring(1)));
                string lowerRightCell = System.String.Format("{0}{1}",
                    endColumnLetter, endRowNumber);

                Microsoft.Office.Interop.Excel.Range chartRange = ws.get_Range("A5", "C9");
                xlChart.SetSourceData(chartRange, Type.Missing);
                xlChart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered;

                Microsoft.Office.Interop.Excel.SeriesCollection oSeriesCollection = (Microsoft.Office.Interop.Excel.SeriesCollection)chartObj.Chart.SeriesCollection(Type.Missing);
                //Microsoft.Office.Interop.Excel.Series series1 = oSeriesCollection.Item(1);
                //series1.Delete();

                // *********************Add title: *******************************
                xlChart.HasTitle = true;
                xlChart.ChartTitle.Text = "Project-By-Area Graph";

                // *****************Set legend:***************************
                xlChart.HasLegend = true;


                string file = "ProjectByArea";
                string path = ("~/Content/ExcelTemplate/");

                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Current.Response.AddHeader("content-disposition",
                                                "attachment;filename=" + file + ".xlsx");
                string filepath = path + file + ".xlsx";
                // wb.SaveCopyAs(Server.MapPath(filepath));
                if (File.Exists(HttpContext.Current.Server.MapPath(filepath)))
                {
                    File.Delete(HttpContext.Current.Server.MapPath(filepath));
                    // System.IO.File.Delete(filepath);
                    wb.SaveAs(HttpContext.Current.Server.MapPath(filepath));
                    wb.Close();
                    xla.Quit();
                    HttpContext.Current.Response.TransmitFile(HttpContext.Current.Server.MapPath(filepath));
                    HttpContext.Current.Response.End();
                }
                else
                {

                    //  errorstatus = "saving";
                    wb.SaveAs(HttpContext.Current.Server.MapPath(filepath));
                    wb.Close();
                    xla.Quit();


                    HttpContext.Current.Response.TransmitFile(HttpContext.Current.Server.MapPath(filepath));
                    HttpContext.Current.Response.End();
                    // errorstatus = "saved";

                }
                xla.Visible = true;

            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);

            }
          
        }
        #endregion Project-By-AreaDownload

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {

            try
            {
                FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
                DataTable dt = punchObj.GetProgressByFIWPDetails();
                FlyCnDAL.ExcelReportSettings excelObj = new FlyCnDAL.ExcelReportSettings();

                Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
                //********************** Now create the chart. *****************************
                Microsoft.Office.Interop.Excel.ChartObjects chartObjs = (Microsoft.Office.Interop.Excel.ChartObjects)ws.ChartObjects(Type.Missing);
                Microsoft.Office.Interop.Excel.ChartObject chartObj = chartObjs.Add(250, 60, 300, 300);
                Microsoft.Office.Interop.Excel.Chart xlChart = chartObj.Chart;
                excelObj.pageTitle = "Progress-By-FIWP Report";
                excelObj.GenerateReport(ws);
                int colIndex = 1;
                int rowIndex = 5;

                ws.Columns.AutoFit();
                foreach (DataColumn column in dt.Columns)
                {
                    string columnName = Convert.ToString(column.ColumnName);

                    ws.Cells[rowIndex, colIndex].Value = columnName;

                    colIndex++;
                }
                rowIndex++;

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    colIndex = 1;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        ws.Cells[rowIndex, colIndex].Value = dt.Rows[j][dc.ColumnName].ToString();
                        colIndex++;
                    }
                    rowIndex++;
                }


                int nRows = 5;
                int nColumns = dt.Rows.Count;
                string upperLeftCell = "A5";
                int endRowNumber = System.Int32.Parse(upperLeftCell.Substring(1))
                    + nRows - 1;
                char endColumnLetter = System.Convert.ToChar(
                    Convert.ToInt32(upperLeftCell[0]) + nColumns - 1);
                string upperRightCell = System.String.Format("{0}{1}",
                    endColumnLetter, System.Int32.Parse(upperLeftCell.Substring(1)));
                string lowerRightCell = System.String.Format("{0}{1}",
                    endColumnLetter, endRowNumber);

                Microsoft.Office.Interop.Excel.Range chartRange = ws.get_Range("A5", "C9");
                xlChart.SetSourceData(chartRange, Type.Missing);
                xlChart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered;

                Microsoft.Office.Interop.Excel.SeriesCollection oSeriesCollection = (Microsoft.Office.Interop.Excel.SeriesCollection)chartObj.Chart.SeriesCollection(Type.Missing);
                //Microsoft.Office.Interop.Excel.Series series1 = oSeriesCollection.Item(1);
                //series1.Delete();

                // *********************Add title: *******************************
                xlChart.HasTitle = true;
                xlChart.ChartTitle.Text = "Progress-By-FIWP Graph";

                // *****************Set legend:***************************
                xlChart.HasLegend = true;


                string file = "ProgressByFIWP";
                string path = ("~/Content/ExcelTemplate/");

                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Current.Response.AddHeader("content-disposition",
                                                "attachment;filename=" + file + ".xlsx");
                string filepath = path + file + ".xlsx";
                // wb.SaveCopyAs(Server.MapPath(filepath));
                if (File.Exists(HttpContext.Current.Server.MapPath(filepath)))
                {
                    File.Delete(HttpContext.Current.Server.MapPath(filepath));
                    // System.IO.File.Delete(filepath);
                    wb.SaveAs(HttpContext.Current.Server.MapPath(filepath));
                    wb.Close();
                    xla.Quit();
                    HttpContext.Current.Response.TransmitFile(HttpContext.Current.Server.MapPath(filepath));
                    HttpContext.Current.Response.End();
                }
                else
                {

                    //  errorstatus = "saving";
                    wb.SaveAs(HttpContext.Current.Server.MapPath(filepath));
                    wb.Close();
                    xla.Quit();


                    HttpContext.Current.Response.TransmitFile(HttpContext.Current.Server.MapPath(filepath));
                    HttpContext.Current.Response.End();
                    // errorstatus = "saved";

                }
                xla.Visible = true;

            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);

            }
          
        }
    }
          
           
        }  
  
    
