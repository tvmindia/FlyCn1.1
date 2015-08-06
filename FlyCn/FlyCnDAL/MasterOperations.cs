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

  
        #region Methods

        #region InsertMasterData
        public int InsertMasterData(DataTable dsTest, string ProjNo, string TableName)
        {
            ErrorHandling eObj = new ErrorHandling();
            int result = 0;
            SqlConnection con = null;
            try

            {
                List<object> list = (from row in dsTest.AsEnumerable() select (row["Values"])).ToList();
                DataSet dataset = new DataSet();
                string FieldValue = "";
                string FieldParams = "";
                SystemDefenitionDetails dbobj = new SystemDefenitionDetails();
                dataset = dbobj.getDataToInsert(TableName);
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@TableName", TableName);
                int totalrows = dataset.Tables[0].Rows.Count;
                string temp = dataset.Tables[0].Rows[0]["Field_Name"].ToString();
                if (temp == "ProjectNo")
                {
                    cmd.Parameters.AddWithValue("@ProjNo", ProjNo);
                    FieldValue = "ProjectNo" + ",";
                    FieldParams = "'"+ProjNo+"'"+",";
                    for (int i = 1; i < totalrows; i++)
                    {


                        FieldValue = FieldValue  + dataset.Tables[0].Rows[i]["Field_Name"] + ",";
                        FieldParams = FieldParams +"'"+ list[i - 1]+"'"+",";

                    }
                }
                else
                {
                    for (int i = 0; i < totalrows; i++)
                    {
                        FieldValue = FieldValue + dataset.Tables[0].Rows[i]["Field_Name"] + ",";
                        FieldParams = FieldParams + "'" + list[i ] + "'" + ",";

                        //cmd.Parameters.AddWithValue("@Field" + (i + 1), dataset.Tables[0].Rows[i]["Field_Name"]);
                        //cmd.Parameters.AddWithValue("@Field" + (i + 1) + "Val", list[i]);
                        //FieldValue = FieldValue + dataset.Tables[0].Rows[i]["Field_Name"] + ",";
                        //FieldParams = FieldParams + "@Field" + (i + 1) + "Val" + ",";

                    }
                }
                //cmd.Parameters.AddWithValue("@Updated_By", "Amrutha");
                //cmd.Parameters.AddWithValue("@Updated_Date", System.DateTime.Now);
                FieldValue = FieldValue + "Updated_By,Updated_Date" ;
                FieldParams = FieldParams +"'"+ "Amrutha"+"'"+","+"'"+System.DateTime.Now.ToString("MM/dd/yyyy")+"'";
                cmd.Parameters.AddWithValue("@p_selectedFields",FieldValue);
                cmd.Parameters.AddWithValue("@p_selectedFieldsParameters", FieldParams);
                cmd.ExecuteScalar();
                return 1;
            }
            catch (Exception ex)
            {
                //return 0;
                //throw ex;
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
               
            }
            finally
            {
                con.Close();

            }
            return result;

        }
       
        #endregion InsertMasterData

        #region BindMasters
        public DataTable BindMasters(string TableName, string ProjNo)
        {
            //string TableName = "M_Country";
            //string ProjNo = "C00001";
            string FieldValue = "";
            SqlConnection con = null;
            DataTable dt = null;

            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();

            DataSet da = null;
            SystemDefenitionDetails sd = new SystemDefenitionDetails();
            dt = sd.getFieldNames(TableName);
            int totalrows = dt.Rows.Count;
            string temp = dt.Rows[0]["Field_Name"].ToString();
            
            SqlCommand cmd = new SqlCommand("SelectMasterTable", con);
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
            }
            else
            {
                for (int i = 0; i < totalrows; i++)
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
            con.Close();
            return dt;
        }

        #endregion BindMasters
        public int DeleteMasterData(string code, string TableName, string Id)
        {

            SqlConnection conObj = null;
            try
            {
                string whereCondition;
                dbConnection dcon = new dbConnection();
                conObj = dcon.GetDBConnection();
                whereCondition = Id + "=" + "'" + code + "'";
                SqlCommand cmd = new SqlCommand("DeleteMaster", conObj);
                cmd.CommandType = CommandType.StoredProcedure;            
                cmd.Parameters.AddWithValue("@TableName", TableName);
                cmd.Parameters.AddWithValue("@p_whereCondition", whereCondition);
                cmd.ExecuteScalar();
                return 1;
            }
            catch (SqlException ex)  
            {
                return 0;
                throw ex;
            }
            finally
            {
                conObj.Close();
            }
        }
        public DataTable FillMasterData(string Id1, string TableName, string ProjNo,string condition)
        {


            string FieldValue = "";
            SystemDefenitionDetails dbobj = new SystemDefenitionDetails();
            SqlConnection con = null;
            DataTable dt = null;
            DataTable dts = null;
            dts = dbobj.getFieldNames(TableName);
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();

            DataSet da = null;
            SystemDefenitionDetails sd = new SystemDefenitionDetails();
            da = sd.getData(TableName);
            int totalrows = da.Tables[0].Rows.Count;
            string temp = da.Tables[0].Rows[0]["Field_Name"].ToString();
            string whereCondition;
         
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
                whereCondition = condition + "=" +"'"+ Id1+"'";
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
                whereCondition = condition + "=" + "'" + Id1 + "'";
                    
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
        public int UpdateMaster(DataTable dsTest, string Table,string Condition)
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


                SqlCommand cmd = new SqlCommand("Update", con);
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
                        updatestring = dsTest.Rows[i-1]["Field_Name"] + "='" + dsTest.Rows[i-1]["Values"] + "'";

                        //cmd.Parameters.AddWithValue("@p_UpdateString", updatestring + ",");
                        FieldValue = FieldValue + updatestring + ",";
                    }
                }
                string addfield = "Updated_By" + "=" + "'Amrutha'" + "," + "Updated_Date" + "='" + System.DateTime.Now.ToString("MM/dd/yyyy")+"'";
               FieldValue = FieldValue + addfield;

                cmd.Parameters.AddWithValue("@p_UpdateString", FieldValue);
                cmd.Parameters.AddWithValue("@p_whereCondition", whereCondition);
                cmd.ExecuteScalar();
                return 1;
            }
            catch (SqlException ex)
            {
                return 0;
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
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
        public DataTable GetComboBoxDataById(string Id,string TableName,string Name,string Code)
        {
            DataTable dataset = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            string WhereCondition =Code + '=' +"'"+ Id+"'";
            SqlCommand cmd = new SqlCommand("GetComboBoxDataById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TableName", TableName);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@WhereCondition", WhereCondition);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dataset = new DataTable();
            adapter.Fill(dataset);
            con.Close();
            return dataset;


        }
        }
        #endregion Methods
    }
//changes//