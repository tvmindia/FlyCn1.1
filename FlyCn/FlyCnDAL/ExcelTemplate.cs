using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices; 
using System.Drawing;
using System.IO;
using System.Windows.Forms;





namespace FlyCn.FlyCnDAL
{

    public class ExcelTemplate
    {

        ErrorHandling eObj = new ErrorHandling();

        //public string GetSheetName(string tablename)
        //{

        //    SqlConnection con = null;
        //    SqlDataAdapter daObj;
          
          
        //    DataSet ds = new DataSet();
        //    string procName = "";
        //    string fieldName = "";

        //    try
        //    {
             
        //        dbConnection dcon = new dbConnection();
        //        con = dcon.GetDBConnection();
        //        UIClasses.Const Const = new UIClasses.Const();
        //        FlyCnDAL.Security.UserAuthendication UA;
        //        HttpContext context = HttpContext.Current;
        //        UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
        //        string selectQuery = "GetProcedureName";
        //        SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
        //        cmdSelect.CommandType = CommandType.StoredProcedure;
              
        //        cmdSelect.Parameters.AddWithValue("@tablename", tablename);
        //        daObj = new SqlDataAdapter(cmdSelect);
        //        daObj.Fill(ds);
        //        SqlParameter ouputprocedurename = cmdSelect.Parameters.Add("@procedurename", SqlDbType.NVarChar, 50);
        //        ouputprocedurename.Direction = ParameterDirection.Output;
        //        cmdSelect.ExecuteNonQuery();
        //        procName = ouputprocedurename.Value.ToString();
        //        SqlParameter ouputFieldName = cmdSelect.Parameters.Add("@sheetname", SqlDbType.NVarChar, 50);
        //        ouputFieldName.Direction = ParameterDirection.Output;
        //        cmdSelect.ExecuteNonQuery();
        //        procName = ouputprocedurename.Value.ToString();

        //        return fieldName;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public void GenerateExcelTemplate(string projno, string tablename)
        {

            SqlConnection con = null;
            SqlDataAdapter daObj;
          
          
            DataSet ds = new DataSet();
            string errorstatus="";
            try
            {
                errorstatus = "started";
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                UIClasses.Const Const = new UIClasses.Const();
                FlyCnDAL.Security.UserAuthendication UA;
                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                string selectQuery = "SelectFieldsFromSYS_TableDefinitionByTable_NameProjectNo";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@projno", projno);
                cmdSelect.Parameters.AddWithValue("@tablename", tablename);
                daObj = new SqlDataAdapter(cmdSelect);
                daObj.Fill(ds);
                CommonDAL cObj = new CommonDAL();
                cObj.GetProcedureName(tablename);
                string sheetname=cObj.ExcelSheetName;
               

                Microsoft.Office.Interop.Excel.Range excelCellrange;
                errorstatus = "Creating App";
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();

                Workbook ExcelWorkBook = null;
                Worksheet ExcelWorkSheet = null;


                ExcelWorkBook = ExcelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                errorstatus = "Created";


                List<string> SheetNames = new List<string>();

                SheetNames.Add(sheetname);
                SheetNames.Add("Field Description");
                int colIndex = 1;
                int rowIndex = 1;


                //  ExcelWorkSheet.Columns.ColumnWidth = 21.00;
                var rows = ds.Tables[0].Rows;

                for (int i = 1; i < 2; i++)
                    ExcelWorkBook.Worksheets.Add();

                //--------------------   First Sheet------------------------------//
                ExcelWorkSheet = ExcelWorkBook.Worksheets[1];
                foreach (DataRow row in rows)
                {
                    ExcelWorkSheet.Columns.AutoFit();
                    string name = Convert.ToString(row["Field_Name"]);

                    ExcelWorkSheet.Cells[colIndex, rowIndex].Value = name;


                    rowIndex++;
                }

                ExcelWorkSheet.Name = SheetNames[0];

                //---------------------Second Sheet----------------------------//

                colIndex = 1;
                rowIndex = 1;

                ExcelWorkSheet = ExcelWorkBook.Worksheets[2];
                foreach (DataRow row in rows)
                {
                    ExcelWorkSheet.Columns.AutoFit();
                    string name = Convert.ToString(row["Field_Name"]);

                    ExcelWorkSheet.Cells[colIndex, rowIndex].Value = name;
                    string isMandatory = Convert.ToString(row["ExcelMustFields"]);


                    if (isMandatory == "Y")
                    {
                        ExcelWorkSheet.Cells[colIndex, rowIndex + 1].Value = "*";
                        //ExcelWorkSheet.Cells[colIndex, rowIndex + 1].style("color", "red");
                        ExcelWorkSheet.Cells[colIndex, rowIndex + 1].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                    }
                    colIndex++;



                }

                ExcelWorkSheet.Cells[colIndex, rowIndex].Value = "Note: * marked fields are mandatory";
                ExcelWorkSheet.Cells[colIndex, rowIndex].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                ExcelWorkSheet.Name = SheetNames[1];
          

                string file = "ExcelImport_" + tablename;



                string path = ("~/Content/ExcelTemplate/");

                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Current.Response.AddHeader("content-disposition",
                                                "attachment;filename=" + file + ".xlsx");


                string filepath = path + file + ".xlsx";
                if (File.Exists(HttpContext.Current.Server.MapPath(filepath)))
                {
                    File.Delete(HttpContext.Current.Server.MapPath(filepath));
                   // System.IO.File.Delete(filepath);
                    ExcelWorkBook.SaveAs(HttpContext.Current.Server.MapPath(filepath));
                    ExcelWorkBook.Close();
                    ExcelApp.Quit();
                    HttpContext.Current.Response.TransmitFile(HttpContext.Current.Server.MapPath(filepath));
                    HttpContext.Current.Response.End();
                }
                else
                {

                    errorstatus = "saving";
                    ExcelWorkBook.SaveAs(HttpContext.Current.Server.MapPath(filepath));
                    ExcelWorkBook.Close();
                    ExcelApp.Quit();


                    HttpContext.Current.Response.TransmitFile(HttpContext.Current.Server.MapPath(filepath));
                    HttpContext.Current.Response.End();
                    errorstatus = "saved";

                } 

                Marshal.ReleaseComObject(ExcelWorkSheet);
                Marshal.ReleaseComObject(ExcelWorkBook);
                Marshal.ReleaseComObject(ExcelApp);
            }
            catch (Exception exHandle)
            {
                
                throw new Exception(exHandle.Message + errorstatus);
            }
     

        }



    }
}
               
            
        
    
