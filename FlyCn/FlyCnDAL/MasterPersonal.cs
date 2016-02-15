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
    public string OpenBy
    {
        get;
        set;
    }
    public string EnteredBy
    {
        get;
        set;
    }
    public string RequestedBy
    {
        get;
        set;
    }
    public string Inspector
    {
        get;
        set;
    }
    public string ResponsiblePerson
    {
        get;
        set;
    }
    public string SignedBy
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

    #region Methods

        #region BindMasters
        /// <summary>
        /// bind Master Personnel data
        /// </summary>
        /// <returns>return data table</returns>
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

        #region GetCompanyComboBoxData
        /// <summary>
        /// Get Company DropDown Data
        /// </summary>
        /// <returns>return datatable</returns>
        public DataTable GetCompanyComboBoxData()
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
        #endregion GetCompanyComboBoxData

        #region GetCompanyComboBoxDataById
        /// <summary>
        /// Get Combo box data by id to fill combo box when clicking edit button
        /// </summary>
        /// <param name="Code"></param>
        /// <returns>return datatable </returns>
        public DataTable GetCompanyComboBoxDataById(string Code)
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
        #endregion GetCompanyComboBoxDataById

        #region InsertMasterData
        /// <summary>
        /// Insert Master Personnel data
        /// </summary>
        /// <param name="ProjNo"></param>
        /// <returns>return integer value</returns>
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

                //cmd.Parameters.AddWithValue("@Updated_By","Amrutha" );

                cmd.Parameters.AddWithValue("@Updated_By", Updated_By);

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
            return result;

        }

        #endregion InsertMasterData

        #region DeleteMasterPersonalData
        /// <summary>
        /// Delete Master Personnel Data 
        /// </summary>
        /// <param name="code"></param>
        /// <returns> return integer value</returns>
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
          #endregion DeleteMasterPersonalData

        #region FillMasterPersonalData
        /// <summary>
        /// Fill text boxes when clicking edit button
        /// </summary>
        /// <param name="code"></param>
        /// <returns>return data table</returns>
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
        /// <summary>
        /// update master personnel data
        /// </summary>
        /// <param name="ProjNo"></param>
        /// <returns>return integer</returns>
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

                cmd.Parameters.AddWithValue("@Updated_By", Updated_By);

                //cmd.Parameters.AddWithValue("@Updated_By", "Amrutha");

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
        #endregion UpdateMasterPersonel

        #region GetDEtailsFromPersonal
        public DataTable GetDEtailsFromPersonal()
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            SqlDataAdapter daObj;
            try
            {

                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                UIClasses.Const Const = new UIClasses.Const();
                FlyCnDAL.Security.UserAuthendication UA;

                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                string selectQuery = "BindM_Personnel";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@projno", UA.projectNo);
                daObj = new SqlDataAdapter(cmdSelect);
                daObj.Fill(dt);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return dt;

        }
        #endregion GetDEtailsFromPersonal
        #endregion Methods
    }
}