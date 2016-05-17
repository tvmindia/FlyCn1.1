using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace FlyCn.FlyCnDAL
{
    public class MasterOperations
    {
        ErrorHandling eObj = new ErrorHandling();

        #region Methods

        #region InsertMasterData
        /// <summary>
        /// dynamic master insert operation
        /// </summary>
        /// <param name="dsTest"></param>
        /// <param name="ProjNo"></param>
        /// <param name="TableName"></param>
        /// <returns>return result  </returns>
        public int InsertMasterData(DataTable dsTest, string ProjNo, string TableName, string userName, dbConnection dbcon=null,bool flag=false)
        {
            //int result = 0;
            //SqlConnection con = null;
           
            try
            {
                List<object> list = (from row in dsTest.AsEnumerable() select (row["Values"])).ToList();
                DataSet dataset = new DataSet();
                string FieldValue = "";
                string FieldParams = "";
                SqlConnection con = null;
                SystemDefenitionDetails dbobj = new SystemDefenitionDetails();
                dataset = dbobj.getDataToInsert(TableName);
                if(dbcon==null)
                {
                  dbConnection dcon = new dbConnection();
                  con=dcon.GetDBConnection();
                
                }
               
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertDynamicMaster";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@TableName", TableName);
                int totalrows = dataset.Tables[0].Rows.Count;
                string temp = dataset.Tables[0].Rows[0]["Field_Name"].ToString();
                if (temp == "ProjectNo")
                {
                    cmd.Parameters.AddWithValue("@ProjNo", ProjNo);
                    FieldValue = "ProjectNo" + ",";
                    FieldParams = "'" + ProjNo + "'" + ",";
                    for (int i = 1; i < totalrows; i++)
                    {


                        FieldValue = FieldValue + dataset.Tables[0].Rows[i]["Field_Name"] + ",";
                        if (list[i - 1] == "")
                        {
                            FieldParams = FieldParams + "NULL" + ",";

                        }
                        else
                        {

                            FieldParams = FieldParams + "'" + list[i - 1] + "'" + ",";

                        }
                        //FieldParams = FieldParams +"'"+ list[i - 1]+"'"+",";

                    }
                }
                else
                {
                    for (int i = 0; i < totalrows; i++)
                    {
                        FieldValue = FieldValue + dataset.Tables[0].Rows[i]["Field_Name"] + ",";
                        if (list[i] == "")
                        {
                            FieldParams = FieldParams + "NULL" + ",";

                        }
                        else
                        {

                            FieldParams = FieldParams + "'" + list[i] + "'" + ",";

                        }

                    }
                }

                FieldValue = FieldValue + "Updated_By,Updated_Date";
                FieldParams = FieldParams + "'" + userName + "'" + "," + "'" + System.DateTime.Now.ToString("MM/dd/yyyy") + "'";
                cmd.Parameters.AddWithValue("@p_selectedFields", FieldValue);
                cmd.Parameters.AddWithValue("@p_selectedFieldsParameters", FieldParams);
                cmd.ExecuteScalar();
                if (flag != true)
                {
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.InsertionSuccessData(page);
                }
                return 1;
            }
            catch (Exception ex)
            {
              throw ex;
            }
            finally
            {
              //  con.Close();

            }
           // return result;

        }

        #endregion InsertMasterData

        #region BindMasters
        /// <summary>
        /// bind dynamic master datas
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="ProjNo"></param>
        /// <returns> return datatable</returns>
        public DataTable BindMasters(string TableName, string ProjNo, string moduleID = null, bool ISbaseTable = false)
        {
            //string TableName = "M_Country";
            //string ProjNo = "C00001";
            string FieldValue = "";
            DataTable dt = null;
            dbConnection dcon = new dbConnection();
            try
            {
                dcon.GetDBConnection();
                SystemDefenitionDetails sd = new SystemDefenitionDetails();
                if (ISbaseTable)
                {
                    dt = sd.getFieldNames(TableName, ProjNo, true);
                }
                else
                {
                    dt = sd.getFieldNames(TableName, ProjNo);
                }

                if ((dt.Rows.Count > 0) || (dt != null))
                {
                    string temp = dt.Rows[0]["Field_Name"].ToString();
                    SqlCommand cmd = new SqlCommand("SelectMasterTable", dcon.SQLCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", TableName);
                    cmd.Parameters.AddWithValue("@ModuleID", moduleID);
                    if (temp == "ProjNo")
                    {
                        cmd.Parameters.AddWithValue("@ProjectNo", ProjNo);
                        FieldValue = "ProjNo";
                        for (int i = 1; i < dt.Rows.Count; i++)
                        {
                            FieldValue = FieldValue + "," + dt.Rows[i]["Field_Name"];
                        }
                        FieldValue = FieldValue + "";
                        cmd.Parameters.AddWithValue("@p_selectedFields", FieldValue);
                    }
                    else
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            FieldValue = FieldValue + dt.Rows[i]["Field_Name"] + ",";
                        }
                        FieldValue = FieldValue + "";
                        FieldValue = FieldValue.TrimEnd(',');
                        cmd.Parameters.AddWithValue("@p_selectedFields", FieldValue);
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (dcon.SQLCon != null)
                {
                    dcon.DisconectDB();
                }
            }
            return dt;
        }

        #endregion BindMasters

        #region DeleteMasterData
        /// <summary>
        /// delete dynamic master datas
        /// </summary>
        /// <param name="code"></param>
        /// <param name="TableName"></param>
        /// <param name="Id"></param>
        /// <returns>return integer</returns>
        public int DeleteMasterData(string keys, string TableName, string KeyValue)
        {
            SqlConnection conObj = null;
            try
            {
                string whereCondition = "";
                string[] strArr = keys.Split(',');
                string[] year = KeyValue.Split(new char[] { ',' });
                string a = strArr[0];
                int b = strArr.Length;
                for (int i = 0; strArr.Length >= i + 1; i++)
                {
                    whereCondition = whereCondition + strArr[i] + "=" + "'" + year[i] + "'" + "  AND ";
                }
                // whereCondition = whereCondition.TrimEnd();
                whereCondition = whereCondition.Remove(whereCondition.Length - 4);
                dbConnection dcon = new dbConnection();
                conObj = dcon.GetDBConnection();
                // whereCondition = Id + "=" + "'" + code + "'";
                SqlCommand cmd = new SqlCommand("DeleteMaster", conObj);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TableName", TableName);
                cmd.Parameters.AddWithValue("@p_whereCondition", whereCondition);
                cmd.ExecuteScalar();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.DeleteSuccessData(page);
                return 1;
            }
            catch (SqlException ex)
            {

                // throw ex;
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);

            }
            finally
            {
                conObj.Close();
            }
            return 0;
        }

        #endregion DeleteMasterData

        #region FillMasterData
        /// <summary>
        /// fill datas to the text boxes
        /// </summary>
        /// <param name="Id1"></param>
        /// <param name="TableName"></param>
        /// <param name="ProjNo"></param>
        /// <param name="condition"></param>
        /// <returns>return data table</returns>
        public DataTable FillMasterData(string keys, string TableName, string ProjNo, string KeyValue)
        {
            string whereCondition = "";
            string[] strArr = keys.Split(',');
            string[] year = KeyValue.Split(new char[] { ',' });
            string a = strArr[0];
            int b = strArr.Length;
            for (int i = 0; strArr.Length >= i + 1; i++)
            {
                whereCondition = whereCondition + strArr[i] + "=" + "'" + year[i] + "'" + "  AND ";
            }
            // whereCondition = whereCondition.TrimEnd();
            whereCondition = whereCondition.Remove(whereCondition.Length - 4);

            string FieldValue = "";
            SystemDefenitionDetails dbobj = new SystemDefenitionDetails();
            SqlConnection con = null;
            DataTable dt = null;
            DataTable dts = null;
            dts = dbobj.getFieldNames(TableName, ProjNo);
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();

            DataSet da = null;
            SystemDefenitionDetails sd = new SystemDefenitionDetails();
            da = sd.getData(TableName);
            int totalrows = da.Tables[0].Rows.Count;
            string temp = da.Tables[0].Rows[0]["Field_Name"].ToString();


            SqlCommand cmd = new SqlCommand("FillMasterData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TableName", TableName);
            if (temp == "ProjNo")
            {
                cmd.Parameters.AddWithValue("@ProjNo", ProjNo);
                FieldValue = "ProjNo";
                for (int i = 1; i < totalrows; i++)
                {
                    FieldValue = FieldValue + "," + da.Tables[0].Rows[i]["Field_Name"];
                }
                FieldValue = FieldValue + "";

                cmd.Parameters.AddWithValue("@p_selectedFields", FieldValue);
                cmd.Parameters.AddWithValue("@p_whereCondition", whereCondition);
            }
            else
            {
                for (int i = 0; i < totalrows; i++)
                {
                    FieldValue = FieldValue + da.Tables[0].Rows[i]["Field_Name"] + ",";
                }
                FieldValue = FieldValue + "";
                FieldValue = FieldValue.TrimEnd(',');


                cmd.Parameters.AddWithValue("@p_selectedFields", FieldValue);
                cmd.Parameters.AddWithValue("@p_whereCondition", whereCondition);
            }
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }

        #endregion FillMasterData

        #region UpdateMaster
        /// <summary>
        /// Update Dynamic master data
        /// </summary>
        /// <param name="dsTest"></param>
        /// <param name="Table"></param>
        /// <param name="Condition"></param>
        /// <returns>return datatable</returns>
        public int UpdateMaster(DataTable dsTest, string Table, string Condition)
        {

            List<object> list = (from row in dsTest.AsEnumerable() select (row["Values"])).ToList();
            List<object> list2 = (from row in dsTest.AsEnumerable() select (row["Field_Name"])).ToList();
            string FieldValue = "";
            SqlConnection con = null;
            try
            {


                DataSet dataset = new DataSet();
                SystemDefenitionDetails dbobj = new SystemDefenitionDetails();
                dataset = dbobj.getData(Table);
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();


                SqlCommand cmd = new SqlCommand("UpdateMaster", con);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@TableName", Table);
                int totalrows = dsTest.Rows.Count;
                string temp = dsTest.Rows[0]["Field_Name"].ToString();
                string updatestring;
                string whereCondition;

                cmd.CommandType = CommandType.StoredProcedure;
                whereCondition = Condition + "=" + "'" + list[0] + "'";
                if (temp == "ProjNo")
                {
                    for (int i = 0; i <= totalrows; i++)
                    {
                        //updatestring = list2[i - 1].ToString() + "='" + list[i - 1].ToString() + "'";
                        updatestring = dsTest.Rows[i - 1]["Field_Name"] + "='" + dsTest.Rows[i - 1]["Values"] + "'";

                        //cmd.Parameters.AddWithValue("@p_UpdateString", updatestring + ",");
                        FieldValue = FieldValue + updatestring + ",";
                    }
                }
                else
                {
                    for (int i = 1; i <= totalrows; i++)
                    {
                        //updatestring = list2[i - 1].ToString() + "='" + list[i - 1].ToString() + "'";
                        if (dsTest.Rows[i - 1]["Values"].ToString() == "")
                        {
                            updatestring = dsTest.Rows[i - 1]["Field_Name"] + "=NULL";
                        }
                      
                        else
                        {
                            updatestring = dsTest.Rows[i - 1]["Field_Name"] + "='" + dsTest.Rows[i - 1]["Values"] + "'";
                        }

                        //cmd.Parameters.AddWithValue("@p_UpdateString", updatestring + ",");
                        FieldValue = FieldValue + updatestring + ",";
                    }
                }
                string addfield = "Updated_By" + "=" + "'Amrutha'" + "," + "Updated_Date" + "='" + System.DateTime.Now.ToString("MM/dd/yyyy") + "'";
                FieldValue = FieldValue + addfield;

                cmd.Parameters.AddWithValue("@p_UpdateString", FieldValue);
                cmd.Parameters.AddWithValue("@p_whereCondition", whereCondition);
                cmd.ExecuteScalar();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.UpdationSuccessData(page);
                return 1;
            }
            catch (SqlException ex)
            {

                throw ex;


            }
            finally
            {
                con.Close();
            }
        }

        #endregion UpdateMaster

        #region GetComboBoxData
        /// <summary>
        /// get drop down data dynamically depends on table
        /// </summary>
        /// <param name="query"></param>
        /// <returns> return datatable</returns>
        public DataTable GetComboBoxData(string query)
        {
            DataTable dataset = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetComboBoxData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@query", query);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dataset = new DataTable();
            adapter.Fill(dataset);
            con.Close();
            return dataset;


        }

        #endregion GetComboBoxData

        #region GetComboBoxDataById
        /// <summary>
        /// get combobox data dynamically to fill text boxes when edit the data
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="TableName"></param>
        /// <param name="Name"></param>
        /// <param name="Code"></param>
        /// <returns> return datatable</returns>
        public DataTable GetComboBoxDataById(string Id, string TableName, string Name, string Code)
        {
            DataTable dt = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            string WhereCondition = Code + '=' + "'" + Id + "'";
            SqlCommand cmd = new SqlCommand("GetComboBoxDataById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TableName", TableName);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Code", Code);
            cmd.Parameters.AddWithValue("@WhereCondition", WhereCondition);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;


        }
    }
        #endregion GetComboBoxDataById

        #endregion Methods

    }
//changes//---------