using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

namespace FlyCn.FlyCnDAL
{
    
    public class MasterPersonnelQualification
    {

        #region Properties

        public DateTime Updated_Date
        {
            get;
            set;
        }
        public string EmpCode
        {
            get;
            set;
        }

        public string Qualification
        {
            get;
            set;
        }

        public string QualificationType
        {
            get;
            set;
        }

        public string FirstQualifiedDate
        {
            get;
            set;
        }

        public string ExpiryDate
        {
            get;
            set;
        }

        public string RenewedDate
        {
            get;
            set;
        }

  
        public string Remarks
        {
            get;
            set;
        }

      
        #endregion Properties

        public MasterPersonnelQualification()
    {
        EmpCode = null;
        Qualification = null;
        QualificationType = null;
   
        FirstQualifiedDate = null;
        ExpiryDate = null;
        RenewedDate = null;
       
        Remarks = null;
        
    }

        #region BindMastersPersonalQualification

        public DataTable BindMastersPersonalQualification(string id)
        {

            SqlConnection con = null;
            DataTable dt = null;

            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();


            SqlCommand cmd = new SqlCommand("GetMasterPersonalQualificationData", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@code", id);


            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }

        #endregion BindMastersPersonalQualification

        #region InsertMasterPersonalQualificationData
        public int InsertMasterPersonalQualificationData(string ProjNo)
        {
            ErrorHandling eObj = new ErrorHandling();
            int result = 0;
            SqlConnection con = null;
            try
            {
                DataSet dataset = new DataSet();

                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertMasterPersonalQualification";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ProjectNo", ProjNo);
                cmd.Parameters.AddWithValue("@EmpCode", EmpCode);
                cmd.Parameters.AddWithValue("@Qualification", Qualification);
               
                cmd.Parameters.AddWithValue("@QualificationType", QualificationType);
       

                    if (FirstQualifiedDate != null)

                {

                    cmd.Parameters.AddWithValue("@FirstQualifiedDate",Convert.ToDateTime( FirstQualifiedDate));

                }
                    if (ExpiryDate != null)
                {

                    cmd.Parameters.AddWithValue("@ExpiryDate", Convert.ToDateTime( ExpiryDate));

                }
                    if (RenewedDate != null)
                    {

                        cmd.Parameters.AddWithValue("@RenewedDate",Convert.ToDateTime( RenewedDate));

                    }
              
                cmd.Parameters.AddWithValue("@Remarks",Remarks);
                cmd.Parameters.AddWithValue("@Updated_By","Amrutha");
         
                cmd.ExecuteScalar();
                return 1;
            }
            catch (Exception ex)
            {
                //return 0;
                //throw ex;

            }
            finally
            {
                con.Close();

            }
            return result;

        }

        #endregion InsertMasterPersonalQualificationData

        #region GetMasterPersonnelComboBoxData
        public DataTable GetMasterPersonnelComboBoxData()
        {
            DataTable dt = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetMasterPersonnelComboBoxData", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;


        }
        #endregion GetMasterPersonnelComboBoxData

        #region DeleteMasterPersonnelQualificationData
        public int DeleteMasterPersonnelQualificationData(string code, string Qualification, string ProjNo)
        {

            SqlConnection conObj = null;
            try
            {



                dbConnection dcon = new dbConnection();
                conObj = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("DELETEMASTERPERSONALQualification", conObj);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@Qualification", Qualification);
                cmd.Parameters.AddWithValue("@ProjectNo", ProjNo);
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
        #endregion DeleteMasterPersonnelQualificationData

        #region FillMasterPersonalData
        public DataTable FillMasterData(string code,string Qualification,string ProjNo)
        {
            DataTable dt = null;


            SqlConnection con = null;

            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();



            SqlCommand cmd = new SqlCommand("FILLMASTERPERSONALQualification", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@code", code);
            cmd.Parameters.AddWithValue("@ProjNo", ProjNo);
            cmd.Parameters.AddWithValue("@Qualification", Qualification);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        #endregion FillMasterPersonalData

        #region UpdateMasterPersonelQualificationData
        public int UpdateMasterPersonelQualificationData(string ProjNo)
        {


            SqlConnection con = null;
            try
            {
                DataSet dataset = new DataSet();
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UpdateMasterPersonalQualificationData";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
             
                cmd.Parameters.AddWithValue("@ProjectNo", ProjNo);
                cmd.Parameters.AddWithValue("@EmpCode", EmpCode);
                cmd.Parameters.AddWithValue("@Qualification", Qualification);

                cmd.Parameters.AddWithValue("@QualificationType", QualificationType);


                if (FirstQualifiedDate != null)
                {

                    cmd.Parameters.AddWithValue("@FirstQualifiedDate", Convert.ToDateTime(FirstQualifiedDate));

                }
                if (ExpiryDate != null)
                {

                    cmd.Parameters.AddWithValue("@ExpiryDate", Convert.ToDateTime(ExpiryDate));

                }
                if (RenewedDate != null)
                {

                    cmd.Parameters.AddWithValue("@RenewedDate", Convert.ToDateTime(RenewedDate));

                }

                cmd.Parameters.AddWithValue("@Remarks", Remarks);
                cmd.Parameters.AddWithValue("@Updated_By", "Amrutha");
         

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
        #endregion UpdateMasterPersonelQualificationData

    }
}