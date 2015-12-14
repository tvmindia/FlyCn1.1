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

namespace FlyCn.FlyCnDAL
{
    public class ExcelTemplate
    {
        public void GenerateExcelTemplate(string projno, string tablename)
        {
          
            SqlConnection con = null;
            SqlDataAdapter daObj;
            DataSet ds = new DataSet();
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                UIClasses.Const Const = new UIClasses.Const();
                FlyCnDAL.Security.UserAuthendication UA;
                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                string selectQuery = "procSelectFieldsFromSYS_TableDefinitionByTable_NameProjectNo";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@projno", projno);
                cmdSelect.Parameters.AddWithValue("@tablename", tablename);
                daObj = new SqlDataAdapter(cmdSelect);
                daObj.Fill(ds);
                Microsoft.Office.Interop.Excel.Range excelCellrange;

                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook ExcelWorkBook = null;
                Worksheet ExcelWorkSheet = null;
               
              
                ExcelWorkBook = ExcelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                
             
            
           
                List<string> SheetNames = new List<string>();
                SheetNames.Add("Fields");
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
                             ExcelWorkSheet.Cells[colIndex, rowIndex+1].Value = "*";
                             //ExcelWorkSheet.Cells[colIndex, rowIndex + 1].style("color", "red");
                             ExcelWorkSheet.Cells[colIndex, rowIndex + 1].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                         }
                        colIndex++;
                  
                  

                    }

                    ExcelWorkSheet.Cells[colIndex, rowIndex].Value = "Note: * marked fields are mandatory";
                    ExcelWorkSheet.Cells[colIndex, rowIndex].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                    ExcelWorkSheet.Name = SheetNames[1];
                  //  ExcelWorkBook.SaveCopyAs(@"E:\Copy_Myfile.xlsx");
                  

                    string file = "ExcelImport_" + tablename;
                    //ExcelWorkBook.SaveAs(path+file);
                   //HttpContext.Current.Response.AppendHeader("content-disposition", "attachment; filename=" + file);

                   //HttpContext.Current.Response.ContentType = "Application/x-msexcel";
                
                   ExcelWorkBook.SaveAs(file);
                   ExcelWorkBook.Close();
                   ExcelApp.Quit();
              
                Marshal.ReleaseComObject(ExcelWorkSheet);
                Marshal.ReleaseComObject(ExcelWorkBook);
                Marshal.ReleaseComObject(ExcelApp);
            }
            catch (Exception exHandle)
            {

                Console.WriteLine("Exception: " + exHandle.Message);
                Console.ReadLine();
            }
           

        }
       
    }

}
               
            
        
    
