using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace FlyCn.FlyCnDAL
{
    public class MasterPersonal
    {
        ErrorHandling eObj = new ErrorHandling();
        #region PersonalProperties
    public string ProjectNo
        {
            get;
            set;
        }
    public string Code
        {
            get;
            set;
        }
    public string Name
        {
            get;
            set;
        }
    public string Company
        {
            get;
            set;
        }
    public string Emp_No
        {
            get;
            set;
        }
    public decimal WorkHours
        {
            get;
            set;
        }
    public byte OTEligibleYN
        {
            get;
            set;
        }
    public string Generic_Position
        {
            get;
            set;
        }
    public string Contract_Position
        {
            get;
            set;
        }
    public string Discipline
        {
            get;
            set;
        }
    public string Emp_Category
        {
            get;
            set;
        }
    public string HierachyPosition
        {
            get;
            set;
        }
    public string Immedt_Superior
        {
            get;
            set;
        }
    public byte OwnEmployeeYN
        {
            get;
            set;
        }
    public string Updated_By
        {
            get;
            set;
        }
    public DateTime Updated_Date
        {
            get;
            set;
        }
    public string PassportNo
        {
            get;
            set;
        }
    public string Nationality
        {
            get;
            set;
        }
    public string ContactNo
        {
            get;
            set;
        }
    public string WelderStamp
        {
            get;
            set;
        }
    public string WelderTypeFS
        {
            get;
            set;
        }
    public string DateStarted
        {
            get;
            set;
        }
    public string DateFinished
        {
            get;
            set;
        }
    public string DateTested
        {
            get;
            set;
        }

    public byte CompanyApprdYN
        {
            get;
            set;
        }
    public DateTime CompanyApprdDate
        {
            get;
            set;
        }
    public string ApprvlAgency
        {
            get;
            set;
        }
    public DateTime AgencyApprdDate
        {
            get;
            set;
        }
    public DateTime ClientApprdDate
        {
            get;
            set;
        }
    public string Remarks
        {
            get;
            set;
        }
    public byte WelderYN
        {
            get;
            set;
        }
    public string Cost_Code
        {
            get;
            set;
        }
        #endregion PersonalProperties

     #region MasterPersonalConstructor
    public MasterPersonal()
    {
        Code = null;
        Name = null;
        Company = null;
    //    DBNull.Value
        DateFinished = null;
        DateStarted = null;
        Emp_No = null;
        OTEligibleYN = 0;
        Generic_Position = null;
        Contract_Position = null;
        Discipline = null;
        Emp_Category = null;
        HierachyPosition = null;
        OwnEmployeeYN = 1;
        PassportNo = null;
        Nationality = null;
        Remarks = null;
    }
    #endregion MasterPersonalConstructor
    
        #region BindMasters

    public DataTable BindMastersPersonal()
        {
           
            SqlConnection con = null;
            DataTable dt = null;

            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();

           
            SqlCommand cmd = new SqlCommand("GetMasterPersonalData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }

        #endregion BindMasters

        #region GetComboBoxDetails
        public DataTable GetComboBoxDetails()
        {
            try
            {

           
            DataTable dt = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetCompanyComboBoxData", con);
            cmd.CommandType = CommandType.StoredProcedure;
          
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
                 }
            catch(Exception ex)
            {
                throw ex;
            }


        }
        #endregion GetComboBoxDetails
        #region GetComboBoxDetailsById
        public DataTable GetComboBoxDetailsById(string Code)
        {
            try
            {

            
            DataTable dt = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetCompanyComboBoxDataById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Code", Code);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;

                }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion GetComboBoxDetailsById

        #region InsertMasterData
        public int InsertMasterData(string ProjNo)
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
                cmd.CommandText = "InsertMasterPersonal";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ProjectNo",ProjNo );
                cmd.Parameters.AddWithValue("@Code",Code);
                cmd.Parameters.AddWithValue("@Name", Name);
                if(Company!="")
                {
                    cmd.Parameters.AddWithValue("@Company", Company);

                }
               
                cmd.Parameters.AddWithValue("@Emp_No",Emp_No );
                cmd.Parameters.AddWithValue("@WorkHours",WorkHours );
                
                cmd.Parameters.AddWithValue("@OTEligibleYN",OTEligibleYN );
                cmd.Parameters.AddWithValue("@Generic_Position",Generic_Position );
                cmd.Parameters.AddWithValue("@Contract_Position", Contract_Position);
                cmd.Parameters.AddWithValue("@Discipline", Discipline);
                cmd.Parameters.AddWithValue("@Emp_Category",Emp_Category);
                cmd.Parameters.AddWithValue("@HierachyPosition", HierachyPosition);
                cmd.Parameters.AddWithValue("@OwnEmployeeYN", OwnEmployeeYN);

                cmd.Parameters.AddWithValue("@Updated_By","Amrutha" );
                cmd.Parameters.AddWithValue("@Updated_Date",System.DateTime.Now.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("@PassportNo", PassportNo);
                cmd.Parameters.AddWithValue("@Nationality",Nationality );
                if (DateStarted!=null)
                {
                    cmd.Parameters.AddWithValue("@DateStarted",Convert.ToDateTime(DateStarted));
                  
                }
                if (DateFinished != null)
                {

                    cmd.Parameters.AddWithValue("@DateFinished",Convert.ToDateTime(DateFinished));
                }
                 cmd.Parameters.AddWithValue("@Remarks", Remarks);
               
                cmd.ExecuteScalar();
                return 1;
            }
            catch (Exception ex)
            {
                //return 0;
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

        #region DeleteMasterPersonalData
        public int DeleteMasterData(string code)
        {

            SqlConnection conObj = null;
            try
            {
                dbConnection dcon = new dbConnection();
                conObj = dcon.GetDBConnection();


                SqlCommand cmd = new SqlCommand("DELETEMASTERPERSONAL", conObj);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", code);
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
          #endregion DeleteMasterPersonalData

        #region FillMasterPersonalData
        public DataTable FillMasterData(string code)
        {
            try
            {

           
            DataTable dt = null;

    
            SqlConnection con = null;

            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();

           
          
            SqlCommand cmd = new SqlCommand("FILLMASTERPERSONAL", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@code",code);
            
          
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
                 }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        #endregion FillMasterPersonalData

        #region UpdateMasterPersonel
        public int UpdateMasterPersonel(string ProjNo)
        {

        
            SqlConnection con = null;
            try
            {
                DataSet dataset = new DataSet();
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UpdateMasterPersonalData";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ProjectNo", ProjNo);
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@Name", Name);
                if (Company != "")
                {
                    cmd.Parameters.AddWithValue("@Company", Company);

                }

                cmd.Parameters.AddWithValue("@Emp_No", Emp_No);
                cmd.Parameters.AddWithValue("@WorkHours", WorkHours);

                cmd.Parameters.AddWithValue("@OTEligibleYN", OTEligibleYN);
                cmd.Parameters.AddWithValue("@Generic_Position", Generic_Position);
                cmd.Parameters.AddWithValue("@Contract_Position", Contract_Position);
                cmd.Parameters.AddWithValue("@Discipline", Discipline);
                cmd.Parameters.AddWithValue("@Emp_Category", Emp_Category);
                cmd.Parameters.AddWithValue("@HierachyPosition", HierachyPosition);
                cmd.Parameters.AddWithValue("@OwnEmployeeYN", OwnEmployeeYN);

                cmd.Parameters.AddWithValue("@Updated_By", "Amrutha");
                cmd.Parameters.AddWithValue("@Updated_Date", System.DateTime.Now.ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("@PassportNo", PassportNo);
                cmd.Parameters.AddWithValue("@Nationality", Nationality);
                if (DateStarted != null)
                {
                    cmd.Parameters.AddWithValue("@DateStarted", Convert.ToDateTime(DateStarted));

                }
                if (DateFinished != null)
                {

                    cmd.Parameters.AddWithValue("@DateFinished", Convert.ToDateTime(DateFinished));
                }
                cmd.Parameters.AddWithValue("@Remarks", Remarks);

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
        #endregion UpdateMasterPersonel
    }
}