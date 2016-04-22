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
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "parent.collapsenode();", true);
            if (!Page.IsPostBack)
            {
                // Bind Charts  
                BindChart();
                BindProjectManpowerChart();
                BindProjectByAreaChart();
            }  
        }

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
            StringBuilder str = new StringBuilder();
            FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
            try
            {
                dsChartData = punchObj.GetProjectByAreaGraphDetails();

               str.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});
                       google.setOnLoadCallback(drawChart);
                       function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Percentage');
        data.addColumn('number', 'Area');     
 
        data.addRows(" + dsChartData.Rows.Count + ");");

               for (int i = 0; i <= dsChartData.Rows.Count - 1; i++)
            {
                str.Append("data.setValue(" + i + "," + 1 + "," + dsChartData.Rows[i]["Percentage"].ToString() + ") ;");   
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dsChartData.Rows[i]["Area"].ToString() + "');");
                        
            }

               str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('columnchart_material2'));");
            str.Append(" chart.draw(data, {width: 500, height: 500, title: 'Project-By-Area',");
            str.Append("hAxis: {title: 'Area'},vAxis: {title: 'Percentage'},backgroundColor: '#f4f4d7',bar: {groupWidth: '20%'}");
            str.Append("}); }");
            str.Append("</script>");
            ltProjectByArea.Text = str.ToString().Replace('*', '"');

            }
            catch
            {
            }
            finally
            {
                dsChartData.Dispose();
                str.Clear();
            }
        }
        #endregion BindProjectByAreaChart
        protected void printPunchList_Click(object sender, EventArgs e)
        {
           
            }

        #region PunchListSummary_Download
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
                DataTable dt = punchObj.GetChartData();

                Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
                //  xla.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
                //********************** Now create the chart. *****************************
                Microsoft.Office.Interop.Excel.ChartObjects chartObjs = (Microsoft.Office.Interop.Excel.ChartObjects)ws.ChartObjects(Type.Missing);
                Microsoft.Office.Interop.Excel.ChartObject chartObj = chartObjs.Add(250, 60, 300, 300);
                Microsoft.Office.Interop.Excel.Chart xlChart = chartObj.Chart;

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

                //---------------insert logo---------------------------//
                object misValue = System.Reflection.Missing.Value;

                ws.Shapes.AddPicture("E:\\Applications\\FlyCn1.1_New\\FlyCn\\Images\\flycnLogo.png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 700, 1, 20, 45); 


                //----------------------Adding Custom header to the excel file--------------//
                ws.get_Range("A1", "z3").Merge(false);
                chartRange = ws.get_Range("A1", "z3");
                chartRange.FormulaR1C1 = "Flycn";
                chartRange.HorizontalAlignment = 3;
                chartRange.VerticalAlignment = 3;
                //--------------------------Cell font color , size--------------------------//
                Microsoft.Office.Interop.Excel.Range formatRange;
                formatRange = ws.get_Range("A1", "z3");
                formatRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                formatRange.Font.Size = 25;
               
                //-------------------Cell background color----------------//
                Microsoft.Office.Interop.Excel.Range formatRange1;
                formatRange1 = ws.get_Range("A1", "z3");
                formatRange1.Interior.Color = System.Drawing.
                ColorTranslator.ToOle(System.Drawing.Color.Bisque);
               

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
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
                DataTable dt = punchObj.GetProjectManpowerChartData();

                Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
                //  xla.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
                //********************** Now create the chart. *****************************
                Microsoft.Office.Interop.Excel.ChartObjects chartObjs = (Microsoft.Office.Interop.Excel.ChartObjects)ws.ChartObjects(Type.Missing);
                Microsoft.Office.Interop.Excel.ChartObject chartObj = chartObjs.Add(250, 60, 300, 300);
                Microsoft.Office.Interop.Excel.Chart xlChart = chartObj.Chart;

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

                //---------------insert logo---------------------------//
                object misValue = System.Reflection.Missing.Value;

                ws.Shapes.AddPicture("E:\\Applications\\FlyCn1.1_New\\FlyCn\\Images\\flycnLogo.png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 700, 1, 20, 45);


                //----------------------Adding Custom header to the excel file--------------//
                ws.get_Range("A1", "z3").Merge(false);
                chartRange = ws.get_Range("A1", "z3");
                chartRange.FormulaR1C1 = "Flycn";
                chartRange.HorizontalAlignment = 3;
                chartRange.VerticalAlignment = 3;
                //--------------------------Cell font color , size--------------------------//
                Microsoft.Office.Interop.Excel.Range formatRange;
                formatRange = ws.get_Range("A1", "z3");
                formatRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                formatRange.Font.Size = 25;

                //-------------------Cell background color----------------//
                Microsoft.Office.Interop.Excel.Range formatRange1;
                formatRange1 = ws.get_Range("A1", "z3");
                formatRange1.Interior.Color = System.Drawing.
                ColorTranslator.ToOle(System.Drawing.Color.Bisque);

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
                // ****************For Quiting The Excel Aplication ***********************
                //if (xla != null)
                //{
                //    xla.DisplayAlerts = false;
                //    wb.Close();
                //    wb = null;
                //    xla.Quit();
                //    xla = null;
                //}
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);

            }
            //FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
            //punchObj.GeneratePunchListExcelTemplate();
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
                DataTable dt = punchObj.GetProjectByAreaGraphDetails();

                Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
                //  xla.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
                //********************** Now create the chart. *****************************
                Microsoft.Office.Interop.Excel.ChartObjects chartObjs = (Microsoft.Office.Interop.Excel.ChartObjects)ws.ChartObjects(Type.Missing);
                Microsoft.Office.Interop.Excel.ChartObject chartObj = chartObjs.Add(250, 60, 300, 300);
                Microsoft.Office.Interop.Excel.Chart xlChart = chartObj.Chart;

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

                //Microsoft.Office.Interop.Excel.Range chartRange = ws.get_Range(upperLeftCell, lowerRightCell);
                //for (int i = 1; i <= dt.Rows.Count; i++)
                //{
                //    chartRange[1, i] = dt.Rows[i - 1][0].ToString();          //For Adding Header Text
                //    chartRange[2, i] = dt.Rows[i - 1][1];  //For Adding Datarow Value
                //}


                Microsoft.Office.Interop.Excel.Range chartRange = ws.get_Range("A5", "A10");
                xlChart.SetSourceData(chartRange, Type.Missing);
                xlChart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered;

             
                xlChart.SeriesCollection(1).Name = "Area";
                xlChart.SeriesCollection(1).XValues = ws.get_Range("B2:B5");
              
                xlChart.HasTitle = true;
                xlChart.ChartTitle.Text = "Project-By-Area Graph";

                // *****************Set legend:***************************
                xlChart.HasLegend = true;

                //---------------insert logo---------------------------//
                object misValue = System.Reflection.Missing.Value;

                ws.Shapes.AddPicture("E:\\Applications\\FlyCn1.1_New\\FlyCn\\Images\\flycnLogo.png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 700, 1, 20, 45);


                //----------------------Adding Custom header to the excel file--------------//
                ws.get_Range("A1", "z3").Merge(false);
                chartRange = ws.get_Range("A1", "z3");
                chartRange.FormulaR1C1 = "Flycn";
                chartRange.HorizontalAlignment = 3;
                chartRange.VerticalAlignment = 3;
                //--------------------------Cell font color , size--------------------------//
                Microsoft.Office.Interop.Excel.Range formatRange;
                formatRange = ws.get_Range("A1", "z3");
                formatRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                formatRange.Font.Size = 25;

                //-------------------Cell background color----------------//
                Microsoft.Office.Interop.Excel.Range formatRange1;
                formatRange1 = ws.get_Range("A1", "z3");
                formatRange1.Interior.Color = System.Drawing.
                ColorTranslator.ToOle(System.Drawing.Color.Bisque);

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
                // ****************For Quiting The Excel Aplication ***********************
                //if (xla != null)
                //{
                //    xla.DisplayAlerts = false;
                //    wb.Close();
                //    wb = null;
                //    xla.Quit();
                //    xla = null;
                //}
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);

            }
            //FlyCnDAL.PunchList punchObj = new FlyCnDAL.PunchList();
            //punchObj.GeneratePunchListExcelTemplate();
        }
        }
          
           
        }  
  
    
