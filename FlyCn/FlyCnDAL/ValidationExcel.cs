﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using FlyCn.DocumentSettings;
using Messge = FlyCn.DocumentSettings.DocumentStatusSettings;
namespace FlyCn.FlyCnDAL
{

    #region classValidationExcel
    public class ValidationExcel
        {

            #region Public Properties
            //public ImportFile importfile = new ImportFile(Guid.NewGuid());
            public ErrorInformation ErrorInfoObj = new ErrorInformation();
            public string errorMessage
            {
                get;
                set;
            }

            public DataTable ErrorDatatable
            {
                get;
                set;
            }
            public string statusID
            {
                get;
                set;
            }
            #endregion Public Properties

            #region Methods
            //#region GenerateStatusID
            //public void GenerateStatusID()
            //{
            //    status_Id = Guid.NewGuid();
            //    ErrorInfoObj.Status_ID = status_Id;
            //}

            //#endregion GenerateStatusID
            #region Data Validation
            /// <summary>
            /// Validation of Excel Data
            /// </summary>
            /// <param name="datarow from the result dataset of the excel file"></param>
            /// <returns>success/failure and error datatable</returns>
            public bool excelDatasetValidation(DataRow dr, DataSet dsTable,int rowNO,dbConnection dbCon)
            {
                DataTable dtError = CreateErrorTable();
                DataSet dsError = new DataSet();
                CommonDAL stdDal = new CommonDAL();
                
                try
                {
                    DataRow[] result = dsTable.Tables[0].Select("ExcelMustFields='Y'");
                    DataRow[] keyFieldRow = dsTable.Tables[0].Select("Key_Field='Y'");
                    StringBuilder errorDescLists = new StringBuilder();
                    bool flag = false;
                    string keyField = GetInvalidKeyField(keyFieldRow, dr);
                    string comma = "";
                    foreach (var item in result)
                    {
                       
                        string FieldName = item["Field_Description"].ToString();
                        string FieldDataType = item["Field_DataType"].ToString();
                        string temp = dr[FieldName].ToString().Trim();
                        int stringSize = int.Parse(item["Field_Size"].ToString());
                        int dataSize = temp.Length;
                       
                        if (dr[FieldName].ToString().Trim() == "" || string.IsNullOrEmpty(dr[FieldName].ToString()))
                        {

                            flag = true;
                            errorDescLists.Append(comma);
                            errorDescLists.Append(FieldName);
                            errorDescLists.Append(" Field Is Empty");
                            comma = ",";

                        }

                        else if (FieldDataType == "D" && !ValidateDate(dr[FieldName].ToString()))
                        {
                            flag = true;
                            errorDescLists.Append(comma);
                            errorDescLists.Append(FieldName);
                            errorDescLists.Append("is Invalid");
                            comma = ",";

                        }

                        else if (FieldDataType == "A" && !isAlphaNumeric(dr[FieldName].ToString()))
                        {
                            flag = true;
                            errorDescLists.Append(comma);
                            errorDescLists.Append(FieldName);
                            errorDescLists.Append(" is invalid");
                            comma = ",";

                        }

                        else if (FieldDataType == "N" && !isNumber(dr[FieldName].ToString()))
                        {
                            flag = true;
                            errorDescLists.Append(comma);
                            errorDescLists.Append(FieldName);
                            errorDescLists.Append(" is invalid");
                            comma = ",";

                        }

                        else if (FieldDataType == "S" && !isAlphaNumeric(dr[FieldName].ToString()))
                        {
                            flag = true;
                            errorDescLists.Append(comma);
                            errorDescLists.Append(FieldName);
                            errorDescLists.Append(" is invalid");
                            comma = ",";
                        }
                        else if (FieldDataType == "S" && !lengthCheck(stringSize, dataSize))
                        {
                            flag = true;
                            errorDescLists.Append(comma);
                            errorDescLists.Append(FieldName);
                            errorDescLists.Append(" Size is Big");
                            comma = ",";
                        }

                    }

                    if (flag == true)
                    {
                        rowNO= rowNO + 2;
                        ErrorInfoObj.InsertExcelImportErrorDetails(keyField, errorDescLists.ToString(), flag, rowNO, dbCon);
                        return true;
                    }
                    else return false;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }


            #region lengthCheck
            public bool lengthCheck(int stringSize, int dataSize)
            {
                if (dataSize <= stringSize)
                {
                    return true;
                }
                return false;
            }

            #endregion lengthCheck

            /// <summary>
            /// Create datatable for Error Descriptions
            /// </summary>
            /// <returns></returns>
            public DataTable CreateErrorTable()
            {
                DataTable dtTemp = new DataTable();
                dtTemp.Columns.Add(new DataColumn("KeyField", typeof(string)));
                dtTemp.Columns.Add(new DataColumn("ErrorDesc", typeof(string)));
                return dtTemp;
            }


            #region Date validation
            /// <summary>
            /// Date validation
            /// </summary>
            /// <param name="date"></param>
            /// <returns></returns>
            private bool ValidateDate(string date)
            {
                try
                {
                    DateTime tempDate;
                    tempDate = Convert.ToDateTime(date);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }

            #endregion Date validation

            #region Alphanumeric Validation
            /// <summary>
            /// Alphanumeric Validation
            /// </summary>
            /// <param name="strToCheck"></param>
            /// <returns></returns>
            private static bool isAlphaNumeric(string strToCheck)
            {
                Regex rg = new Regex(@"^[a-zA-Z0-9\s,]*$");
                if (rg.IsMatch(strToCheck))
                    return true;
                else
                    return false;
            }

            #endregion Alphanumeric Validation

            #region Numeric Validation
            /// <summary>
            /// Numeric Validation
            /// </summary>
            /// <param name="strToCheck"></param>
            /// <returns></returns>
            private bool isNumber(string strToCheck)
            {
                Regex rg = new Regex(@"^[0-9\s,]+$");
                if (rg.IsMatch(strToCheck))
                    return true;
                else
                    return false;
            }

            #endregion Numeric Validation

            #region Alphabetic validation
            /// <summary>
            /// Alphabetic validation
            /// </summary>
            /// <param name="strToCheck"></param>
            /// <returns></returns>
            private bool isAlpha(string strToCheck)
            {
                Regex rg = new Regex(@"^[a-zA-Z\s,]+$");
                if (rg.IsMatch(strToCheck))
                    return true;
                else
                    return false;
            }

            #endregion Alphabetic validation

            #endregion Data Validation

            #region  ExcelDataStructureValidation
            /// <summary>
            /// Validation to check whether columns exist in excel file
            /// </summary>
            /// <param name="cName"></param>
            /// <param name="dsFile"></param>
            /// <returns></returns>
            public bool ExcelDataStructureValidation(string cName, DataSet dsFile)
            {
                try
                {
                    for (int i = dsFile.Tables[0].Columns.Count - 1; i >= 0; i--)
                    {
                        if (cName == dsFile.Tables[0].Columns[i].ColumnName.ToString())
                            return true;
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }

                return false;
            }



            public bool ValidateExcelDataStructure(DataSet dsFile, DataSet dsTable)
            {
                try
                {
                   for (int i = dsTable.Tables[0].Rows.Count - 1; i >= 0; i--)
                    {
                        bool res;
                        //string FieldName = dsTable.Tables[0].Rows[i]["Field_Name"].ToString();
                        string FieldName = dsTable.Tables[0].Rows[i]["Field_Description"].ToString();
                        res = ExcelDataStructureValidation(FieldName, dsFile);
                        if (!res)
                        {
                            return false;
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }

                return true;
            }

            #endregion  ExcelDataStructureValidation

            #region ValidateFileExtension
            public int ValidateFileExtension(string fileExtension)
            {
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    errorMessage = "Invalid File!";
                    return 0;
                }
                return 1;

            }

            #endregion ValidateFileExtension

            #region GetInvalidKeyField
            private string GetInvalidKeyField(DataRow[] keyFieldRow, DataRow dr)
            {
                string comma = "";
                string keyField = "";

                for (int j = 0; j < keyFieldRow.Count(); j++)
                {
                    keyField += comma + dr[keyFieldRow[j]["Field_Description"].ToString()].ToString();
                   // keyField += comma + dr[keyFieldRow[j]["Field_Name"].ToString()].ToString();
                    comma = ",";
                }

                return keyField;
            }

            #endregion GetInvalidKeyField

            #endregion Methods
            #region DataValidation
            //public int DataValidation(DataSet dsFile,DataSet MasterDS,DataSet dsTable)
            public int DataValidation(DataRow dr, DataSet MasterDS, DataSet dsTable, List<string> MasterColumns,string userName,int rowNO, dbConnection dbCon)
            {
                string comma = "";
                string refTableName = "";
                string refSelectField = "";
                string refJoinField = "";
                bool IsError = false;
                string cName="";
                string fieldName = "";
                DataRow[] refTableRow = null;
                DataRow refTableOneRow = null;
                DataRow[] masterDataExisting = null;
                StringBuilder errorDescLists = new StringBuilder();
                DataRow[] keyFieldRow = dsTable.Tables[0].Select("Key_Field='Y'");
                string keyField = GetInvalidKeyField(keyFieldRow, dr);
                ErrorInfoObj.Status_ID = Guid.Parse(statusID);
                try
                {
                 //---------------------------------------------STEP1 MASTER DATA VALIDATE--------------------------------------------------//
                               foreach(string dc in MasterColumns)                
                               {                         
                                cName = dc.ToString();
                               // count = count + 1;
                                //check whether data exist in the masters
                                fieldName = cName;
                                refTableRow = dsTable.Tables[0].Select("Field_Description = '" + cName + "' AND Ref_TableName IS NOT NULL");
                                refTableOneRow = refTableRow[0];
                                refTableName = refTableOneRow["Ref_TableName"].ToString();
                                refSelectField = refTableOneRow["Ref_SelectField"].ToString();
                                refJoinField = refTableOneRow["Ref_JoinField"].ToString();
                                if(lengthCheck(int.Parse(refTableOneRow["Field_Size"].ToString()), dr[fieldName].ToString().Length)!=true)
                                {
                                    IsError = true;
                                    errorDescLists.Append(comma);
                                    errorDescLists.Append(fieldName);
                                    errorDescLists.Append(" Size is Big");
                                    comma = ",";
                                   
                                    ErrorInfoObj.InsertExcelImportErrorDetails(keyField, errorDescLists.ToString(), IsError, rowNO, dbCon);
                                    return 1;

                                }

                                masterDataExisting = MasterDS.Tables[0].Select("TableName = '" + refTableName + "' AND Code = '" + dr[fieldName].ToString() + "'");
                               
                                    //Not found in masters so insert into masters as well as in masterDS
                                  if (masterDataExisting.Length == 0)
                                   {
                                    //continue;
                                    //Add New record to MasterDS
                                    DataRow newCustomersRow = MasterDS.Tables[0].NewRow();
                                    newCustomersRow["TableName"] = refTableName;
                                    newCustomersRow["Code"] = dr[fieldName].ToString();//dsFile.Tables[0].Rows[i][fieldName].ToString();
                                    MasterDS.Tables[0].Rows.Add(newCustomersRow);
                                    MasterDS.Tables[0].AcceptChanges();
                                    //Add New record to DatabaseTable
                                    MasterOperations objMO = new MasterOperations();
                                    DataSet dsTable_RefTable = null;
                                    CommonDAL objCDAL = new CommonDAL();
                                    dsTable_RefTable = objCDAL.GetTableDefinition(refTableName);
                                    DataTable dt = dsTable_RefTable.Tables[0];
                                    DataColumn workCol = dt.Columns.Add("Values");
                                    dt.Rows[0].Delete();//removes 'projectno' row from the datatable
                                    dt.AcceptChanges();
                                    for (int k = 0; k < dsTable_RefTable.Tables[0].Rows.Count; k++)
                                    {
                                        string columnValue = "";
                                        if (dt.Columns.Contains("Field_Name"))
                                        {
                                            columnValue = dt.Rows[k]["Field_Description"].ToString();
                                            if (columnValue == refSelectField)
                                            {
                                               // dt.Rows[k]["Values"] = dr.Table.Rows[0][fieldName].ToString();//dsFile.Tables[0].Rows[i][fieldName].ToString();
                                                dt.Rows[k]["Values"] =  dr[fieldName].ToString();
                                            }
                                            else if (columnValue == refJoinField)
                                            {
                                               // dt.Rows[k]["Values"] = dr.Table.Rows[0][fieldName].ToString();//dsFile.Tables[0].Rows[i][fieldName].ToString();
                                                dt.Rows[k]["Values"] = dr[fieldName].ToString(); 
                                            }
                                            else
                                            {
                                                dt.Rows[k]["Values"] = "";
                                            }
                                        }
                                    }//for
                                    //Add New record to DatabaseTable
                                    objMO.InsertMasterData(dt, dr.Table.Rows[0]["ProjectNo"].ToString(), refTableName,userName,dbCon,true);
                                }
                             // }//if
                        
                           }//foreach 

                    //----------------------------STEP2 DATA RELATIONAL VALIDATIONS------------------------------------------------------

                        }//try
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                  
                }
  
                return 0;
            }
            
            #endregion DataValidation
            #region MasterDataExist
            //validationObj.MasterDataExist(dsTable, MasterDS, dsFile.Tables[0].Rows[i], i, comDAL.tableName,List<string> MasterColumns);
            public bool MasterDataExist(DataSet dsTable, DataSet MasterDS, DataRow dr, int rowNO, string TableName, List<string> MasterColumns, dbConnection dbCon)
            {
                string comma = "";
                Int16 isupdate;
                string cName;
                string refTableName = "";
                DataRow[] refTableRow = null;
                DataRow refTableOneRow = null;
                DataRow[] masterDataExisting = null;
                StringBuilder errorDescLists = new StringBuilder();
                bool IsError = true;

                DataRow[] keyFieldRow = dsTable.Tables[0].Select("Key_Field='Y'");
                string keyField = GetInvalidKeyField(keyFieldRow, dr);

                foreach (string dc in MasterColumns)
                {
                    cName = dc.ToString();
                    if (dr[cName].ToString() != "")
                    {
                        refTableRow = dsTable.Tables[0].Select("Field_Description = '" + cName + "' AND Ref_TableName IS NOT NULL");
                        refTableOneRow = refTableRow[0];
                        refTableName = refTableOneRow["Ref_TableName"].ToString();
                        masterDataExisting = MasterDS.Tables[0].Select("TableName = '" + refTableName + "' AND Code = '" + dr[cName].ToString() + "'");
                        if (masterDataExisting.Length == 0)//data does not exists in the masters
                        {
                            if (refTableName == "M_Personnel")
                            {
                                errorDescLists.Clear();
                                //Error for table name M_Personel
                                IsError = true;
                                //flag = true;
                                errorDescLists.Append(comma);
                                errorDescLists.Append(cName);
                                errorDescLists.Append(" is Invalid Data");
                                comma = ",";
                                isupdate = ErrorInfoObj.InsertExcelImportErrorDetails(keyField, errorDescLists.ToString(), IsError, rowNO, dbCon);
                                return true;
                            }
                            else
                            {
                                //Warning for Normal masters
                                errorDescLists.Clear();
                                IsError = false;
                                errorDescLists.Append(comma);
                                errorDescLists.Append(cName);
                                errorDescLists.Append(" Warning");
                                comma = "";
                                isupdate = ErrorInfoObj.InsertExcelImportErrorDetails(keyField, errorDescLists.ToString(), IsError, rowNO, dbCon);
                                ErrorInfoObj.WarningCount = ErrorInfoObj.WarningCount + 1;
                                //return true;

                            }//else

                        }//if
                    }//if
                }//foreach
                  return false;

                
            }
            #endregion MasterDataExist
            #region CableLengthValidation
            public bool CableLengthValidation(DataRow dr,DataSet dsTable,int rowNO,dbConnection dbCon)
            {
                //Get the CableSchedule records based on project no,moduleID,category and cableno
                //To find out whether its a update or insert
             
                string comma = "";
                DataSet CableDS = null;
                
                int length;
                StringBuilder errorDescLists = new StringBuilder();
                DataRow[] keyFieldRow = dsTable.Tables[0].Select("Key_Field='Y'");
                string keyField = GetInvalidKeyField(keyFieldRow, dr);
                CableDS = new DataSet();
                ImportFile importfile = new ImportFile();
                if ((dr["ProjectNo"].ToString() != "") && (dr["ModuleID"].ToString() != "") && (dr["Category"].ToString() != "") && (dr["Cable No"].ToString() !=""))
                { 
                 CableDS = importfile.GetCableScheduleMaster(dr["ProjectNo"].ToString(), dr["ModuleID"].ToString(), dr["Category"].ToString(), dr["Cable No"].ToString(),dbCon);
                

                    if (CableDS.Tables[0].Rows.Count > 0)
                    {
                     //record exists
                     //its an update
                     //so validate CablepullDetail
                       length = importfile.GetCableTotalPullLength(dr["ProjectNo"].ToString(), dr["ModuleID"].ToString(), dr["Category"].ToString(), dr["Cable No"].ToString(), dbCon);
                       
                         if ((length >= int.Parse(dr["Total Length"].ToString())))
                         {
                             errorDescLists.Append(comma);
                             errorDescLists.Append(" ");
                             errorDescLists.Append(Messge.CADTL);
                             comma = "";
                             rowNO = rowNO + 2;
                             ErrorInfoObj.InsertExcelImportErrorDetails(keyField, errorDescLists.ToString(), true, rowNO, dbCon);
                             return true;
                         }
                       
                       
                   }
                }
                return false;
            }
            #endregion CableLengthValidation
            #region DrumValidation
            public bool DrumValidation(DataRow dr, DataSet dsTable, int rowNO, dbConnection dbCon)
            {
                int drumAllocLength,usedLength;
                StringBuilder errorDescLists = new StringBuilder();
                string comma = "";
                DataSet DrumDS = null;
                DrumDS = new DataSet();
                DataRow[] keyFieldRow = dsTable.Tables[0].Select("Key_Field='Y'");
                string keyField = GetInvalidKeyField(keyFieldRow, dr);
                ImportFile importfile = new ImportFile();
                if ((dr["ProjectNo"].ToString() != "") && (dr["ModuleID"].ToString() != "") && (dr["Category"].ToString() != "") && (dr["DrumNo"].ToString() != "") && (dr["CableTypeCatg"].ToString() != "") && (dr["CableTypeCode"].ToString() !=""))
                {
                    DrumDS = importfile.GetDrumMaster(dr["ProjectNo"].ToString(), dr["ModuleID"].ToString(), dr["Category"].ToString(), dr["DrumNo"].ToString(), dr["CableTypeCatg"].ToString(), dr["CableTypeCode"].ToString(), dbCon);
                    if(DrumDS.Tables[0].Rows.Count==0)
                    {
                             errorDescLists.Append(comma);
                             errorDescLists.Append(" ");
                             errorDescLists.Append(Messge.DNV);
                             comma = "";
                             rowNO = rowNO + 2;
                             ErrorInfoObj.InsertExcelImportErrorDetails(keyField, errorDescLists.ToString(), true, rowNO, dbCon);
                             return true;
                    }
                    if(DrumDS.Tables[0].Rows.Count>0)
                    {
                     //Drum Changes Case
                     drumAllocLength = (DrumDS.Tables[0].Rows[0]["AllocLength"].ToString() != "") ? int.Parse(DrumDS.Tables[0].Rows[0]["AllocLength"].ToString()) : 0;
                     if (drumAllocLength < (int.Parse(dr["Total Length"].ToString())))
                     {
                        errorDescLists.Append(comma);
                        errorDescLists.Append(" ");
                        errorDescLists.Append(Messge.ALV);
                        comma = "";
                        rowNO = rowNO + 2;
                        ErrorInfoObj.InsertExcelImportErrorDetails(keyField, errorDescLists.ToString(), true, rowNO, dbCon);
                        return true;
                     }
                            usedLength =(DrumDS.Tables[0].Rows[0]["UsedLength"].ToString() !="") ? int.Parse(DrumDS.Tables[0].Rows[0]["UsedLength"].ToString()) : 0;
                            if (usedLength!=0)
                            {
                                errorDescLists.Append(comma);
                                errorDescLists.Append(" ");
                                errorDescLists.Append(Messge.ULV);
                                comma = "";
                                rowNO = rowNO + 2;
                                ErrorInfoObj.InsertExcelImportErrorDetails(keyField, errorDescLists.ToString(), true, rowNO, dbCon);
                                return true;
                            }

                            //Drum Changes Case

                    }
                    
                }


                return false;
            }
            #endregion DrumValidation


        }
    #endregion classValidationExcel

 }