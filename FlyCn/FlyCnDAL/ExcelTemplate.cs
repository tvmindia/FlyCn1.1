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
                
              
                //string sPath = Server.MapPath("exportedfiles\\");

                //Response.AppendHeader("Content-Disposition", "attachment; filename=EmployeeDetails.xlsx");
                //Response.TransmitFile(sPath + "EmployeeDetails.xlsx");
                //Response.End();

                //if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
                //{
                //    Directory.CreateDirectory(path);
                //}
              string filename= "E:Myfile.xlsx";
           
                List<string> SheetNames = new List<string>();
                SheetNames.Add("Fields");
                SheetNames.Add("Field Description");
                int colIndex = 1;
                int rowIndex = 1;
                var rows = ds.Tables[0].Rows;
                for (int i = 1; i < 2; i++)
                    ExcelWorkBook.Worksheets.Add();
               
                //--------------------   First Sheet------------------------------//
                    ExcelWorkSheet = ExcelWorkBook.Worksheets[1];
                    foreach (DataRow row in rows)
                    {
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
                        string name = Convert.ToString(row["Field_Name"]);
                       
                        ExcelWorkSheet.Cells[colIndex, rowIndex].Value = name;
                        colIndex++;
                  
                  

                    }
                    colIndex = 1;
                    rowIndex = 2;
                    foreach (DataRow row in rows)
                    {
                        string description = Convert.ToString(row["Field_Description"]);
                     
                      
                        ExcelWorkSheet.Cells[colIndex, rowIndex].Value = description;

                       
                     
                       
                        colIndex++;
                    }


               
                  

                    ExcelWorkSheet.Name = SheetNames[1];
                    ExcelWorkBook.SaveCopyAs(@"E:\Copy_Myfile.xlsx");
          
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
               
            
        
    
