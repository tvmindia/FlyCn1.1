using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;

namespace FlyCn.FlyCnDAL
{
    
    public class MasterPersonnelQualification
    {
        ErrorHandling eObj = new ErrorHandling();


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


        public string Updated_By
        {
            get;
            set;
        }
      
        #endregion Properties


        #region MasterPersonnelQualificationConstructor
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
        #endregion MasterPersonnelQualificationConstructor

        #region Methods

        #region BindMastersPersonalQualification
        /// <summary>
        /// BindMastersPersonalQualification
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return datatable</returns>
        public DataTable BindMastersPersonalQualification(string id)
        {
            
            SqlConnection con = null;
            DataTable dt = null;
            try
            {


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
            catch (Exception ex)
            {
                //return 0;
                throw ex;

            }
            finally
            {
                con.Close();

            }
           
        }

        #endregion BindMastersPersonalQualification

        #region InsertMasterPersonalQualificationData
        /// <summary>
        /// InsertMasterPersonalQualificationData
        /// </summary>
        /// <param name="ProjNo"></param>
        /// <returns>return integer</returns>
        public int InsertMasterPersonalQualificationData(string ProjNo)
        {
            ErrorHandling eObj = new ErrorHandling();
           
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
                //cmd.Parameters.AddWithValue("@Updated_By","Amrutha");

                cmd.Parameters.AddWithValue("@Updated_By", Updated_By);

                cmd.ExecuteScalar();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.InsertionSuccessData(page);
                return 1;
            }
            catch (Exception ex)
            {
                //return 0;
                throw ex;

            }
            finally
            {
                con.Close();

            }
           

        }

        #endregion InsertMasterPersonalQualificationData

        #region GetMasterPersonnelComboBoxData
        /// <summary>
        /// GetMasterPersonnelComboBoxData from M_Personnel table
        /// </summary>
        /// <returns> return datatable</returns>
        public DataTable GetMasterPersonnelComboBoxData()
        {
            DataTable dt = null;
            SqlConnection con = null;
            try
            {


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
            catch (Exception ex)
            {
                //return 0;
                throw ex;

            }
            finally
            {
                con.Close();

            }
           

        }
        #endregion GetMasterPersonnelComboBoxData

        #region DeleteMasterPersonnelQualificationData
        /// <summary>
        /// DeleteMasterPersonnelQualificationData
        /// </summary>
        /// <param name="code"></param>
        /// <param name="Qualification"></param>
        /// <param name="ProjNo"></param>
        /// <returns> return integer </returns>
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
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.DeleteSuccessData(page);
                return 1;
            }
            catch (SqlException ex)
            {
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
        #endregion DeleteMasterPersonnelQualificationData

        #region FillMasterPersonalData
        /// <summary>
        /// FillMasterData to text boxes when clicking edit button
        /// </summary>
        /// <param name="code"></param>
        /// <param name="Qualification"></param>
        /// <param name="ProjNo"></param>
        /// <returns>return datatable</returns>
        public DataTable FillMasterData(string code,string Qualification,string ProjNo)
        {
            DataTable dt = null;


            SqlConnection con = null;
            try
            {

      

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
            catch (Exception ex)
            {
                //return 0;
                throw ex;

            }
            finally
            {
                con.Close();

            }
           
        }
        #endregion FillMasterPersonalData

        #region UpdateMasterPersonelQualificationData
        /// <summary>
        /// UpdateMasterPersonelQualificationData
        /// </summary>
        /// <param name="ProjNo"></param>
        /// <returns>return integer</returns>
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

                //cmd.Parameters.AddWithValue("@Updated_By", "Amrutha");

                cmd.Parameters.AddWithValue("@Updated_By", Updated_By);

                cmd.ExecuteScalar();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.UpdationSuccessData(page);
                return 1;
            }
            catch (SqlException ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
            }
            finally
            {
                con.Close();
            }
            return 0;
        }
        #endregion UpdateMasterPersonelQualificationData

        #endregion Methods
    }
}