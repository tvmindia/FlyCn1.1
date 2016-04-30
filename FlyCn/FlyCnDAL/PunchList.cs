#region Namespaces

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;
using System.Runtime.InteropServices;
#endregion Namespaces

namespace FlyCn.FlyCnDAL
{

    public class PunchList
    {

        #region Properties

        #region Projno
        public string Projno
        {
            get;
            set;
        }
        #endregion Projno

        #region Idno
        public int Idno
        {
            get;
            set;

        }

        #endregion Idno

        #region OpenDate
        public string OpenDate
        {
            get;
            set;
        }
        #endregion OpenDate

        #region EnteredDt
        public string EnteredDt
        {
            get;
            set;
        }
        #endregion EnteredDt

        #region Plant
        public string Plant
        {
            get;
            set;
        }
        #endregion Plant

        #region Area
        public string Area
        {
            get;
            set;
        }
        #endregion Area

        #region Loacation
        public string Location
        {
            get;
            set;
        }
        #endregion Loacation

        #region Unit
        public string Unit
        {
            get;
            set;
        }
        #endregion Unit

        #region System
        public string System
        {
            get;
            set;
        }
        #endregion System

        #region Subsystem
        public string Subsystem
        {
            get;
            set;
        }
        #endregion Subsystem

        #region ControlSystem
        public string ControlSystem
        {
            get;
            set;
        }
        #endregion ControlSystem

        #region ActionBy
        public string ActionBy
        {
            get;
            set;
        }
        #endregion ActionBy

        #region FailCategory
        public string FailCategory
        {
            get;
            set;
        }
        #endregion FailCategory

        #region RFINo
        public string RFINo
        {
            get;
            set;
        }
        #endregion RFINo

        #region Discipline
        public string Discipline
        {
            get;
            set;
        }
        #endregion Discipline

        #region Category
        public string Category
        {
            get;
            set;

        }
        #endregion Category

        #region RFIDate
        public string RFIDate
        {
            get;
            set;

        }
        #endregion RFIDate

        #region CoveredByProject
        public int CoveredByProject
        {
            get;
            set;
        }
        #endregion CoveredByProject

        #region ItemDescription
        public string ItemDescription
        {
            get;
            set;
        }
        #endregion ItemDescription

        #region Reference
        public string Reference
        {
            get;
            set;
        }

        #endregion Reference

        #region ReferenceDate
        public string ReferenceDate
        {
            get;
            set;
        }
        #endregion ReferenceDate

        #region ChangeReq
        public int ChangeReq
        {
            get;
            set;

        }
        #endregion ChangeReq

        #region Drawing
        public string Drawing
        {
            get;
            set;

        }
        #endregion Drawing

        #region slno
        public int slno
        {
            get;
            set;
        }
        #endregion slno

        #region Revison
        public string Revison
        {
            get;
            set;
        }
        #endregion Revison

        #region Sheet
        public string Sheet
        {
            get;
            set;
        }
        #endregion Sheet

        #region Query
        public int Query
        {
            get;
            set;
        }
        #endregion Query

        #region QueryStatus
        public string QueryStatus
        {
            get;
            set;
        }
        #endregion QueryStatus

        #region QueryRevision
        public int QueryRevision
        {
            get;
            set;
        }
        #endregion QueryRevision

        #region ScheduledDateCompletion
        public string ScheduledDateCompletion
        {
            get;
            set;
        }
        #endregion ScheduledDateCompletion

        #region Organization
        public string Organization
        {
            get;
            set;
        }
        #endregion Organization

        #region CompletionDate
        public string CompletionDate
        {
            get;
            set;
        }
        #endregion CompletionDate

        #region CompletionRemarks
        public string CompletionRemarks
        {
            get;
            set;
        }
        #endregion CompletionRemarks

        #region fileUpload
        public string fileUpload
        {
            get;
            set;
        }
        #endregion fileUpload

        #region EILType
        public string EILType
        {
            get;
            set;
        }
        #endregion EILType

        #region SINo
        public string SINo
        {
            get;
            set;
        }
        #endregion SINo

        #region FileType
        public string FileType
        {
            get;
            set;
        }
        #endregion FileType

        #region id
        public int id
        {
            get;
            set;
        }
        #endregion id

        #region image
        public object image /*Takes image from fileupload control */
        {
            get;
            set;
        }
        #endregion image

        #region fileSize
        public string fileSize
        {
            get;
            set;
        }
        public string linkId
        {
            get;
            set;
        }
        public string moduleId
        {
            get;
            set;
        }
        public string category
        {
            get;
            set;
        }
        public string keyField
        {
            get;
            set;
        }
       
        public string logDesc
        {
            get;
            set;
        }
        public string logStatus
        {
            get;
            set;
        }
        public string updatedBy
        {
            get;
            set;
        }
        public DateTime updatedDate
        {
            get;
            set;
        }
        #endregion fileSize

        #region KeyField
        public string KeyField
        {
            get;
            set;
        }
        public string categoryDesc
        {
            get;
            set;
        }
        #endregion KeyField

        #endregion Properties

        #region Constructor
        public PunchList()
        {
            OpenDate = null;
            EnteredDt = null;
            ScheduledDateCompletion = null;
            CompletionDate = null;
            RFIDate = null;
            RFINo = null;
            Discipline = null;
            CompletionRemarks = null;
            Organization = null;
            Reference = null;
            ReferenceDate = null;
            // Query = null;
            // QueryRevision = null;
            QueryStatus = null;
            Sheet = null;
            Drawing = null;
            //ChangeReq = null;
            ItemDescription = null;
            ActionBy = null;
            FailCategory = null;
            System = null;
            ControlSystem = null;
            Subsystem = null;
            Location = null;
            Plant = null;
            Area = null;
            Unit = null;
            Category = null;
        }
        #endregion Constructor

        // MasterPersonal mObj = new MasterPersonal();       
        DALConstants cnst = new DALConstants();
        ErrorHandling eObj = new ErrorHandling();
        #region Methods

        #region BindTree

        public void BindTree(RadTreeView myTree)
        {

            myTree.Nodes.Clear();
            RadTreeNode rtn = new RadTreeNode("Construction", "WEIL");
            rtn.NavigateUrl = cnst.ConstructionPunchListURL + "?Mode=" + rtn.Value;
            rtn.Target = "contentPane";
            myTree.Nodes.Add(rtn);


            rtn = new RadTreeNode("Client", "CEIL");
            rtn.NavigateUrl = cnst.ConstructionPunchListURL + "?Mode=" + rtn.Value;
            rtn.Target = "contentPane";
            myTree.Nodes.Add(rtn);

            rtn = new RadTreeNode("QC", "QEIL");
            rtn.NavigateUrl = cnst.ConstructionPunchListURL + "?Mode=" + rtn.Value;
            rtn.Target = "contentPane";
            myTree.Nodes.Add(rtn);
        }
        #endregion BindTree()

        #region GetPunchList
        /// <summary>
        /// To get desatils from EIL table
        /// </summary>
        /// <returns>Datatable with details from table</returns>
        public DataTable GetPunchList(string eilType)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            SqlDataAdapter daObj;
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            try
            {

                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();

                string selectQuery = "GetPunchlistData";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value=UA.projectNo;
                if (EILType != null)
                {
                    cmdSelect.Parameters.Add("@eilType", SqlDbType.NVarChar, 4).Value = EILType;
                }
                else
                {
                    cmdSelect.Parameters.Add("@eilType", SqlDbType.NVarChar, 4).Value = eilType;
                }
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
        #endregion GetPunchList()

        #region GetChartData

        public DataTable GetChartData()  
    {
        SqlConnection conn = null;
        DataTable dt = null;
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        dbConnection dcon = new dbConnection();
        UIClasses.Const Const = new UIClasses.Const();
        FlyCnDAL.Security.UserAuthendication UA;

        HttpContext context = HttpContext.Current;
        UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
        try
        {
            conn = dcon.GetDBConnection();
            //conn.Open();

            cmd = new SqlCommand("GetPunchListSummary", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = UA.projectNo;
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);

          
        }
        catch (Exception ex)
        {
            throw ex;
        }


        finally
        {
            if (conn != null)
            {
                conn.Close();
            }

        }
        return dt;
    }
        #endregion GetChartData

        #region GetProjectByAreaGraphDetails

        public DataTable GetProjectByAreaGraphDetails()
        {
            SqlConnection conn = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetProjectByAreaGraphDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);


            }
            catch (Exception ex)
            {
                throw ex;
            }


            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

            }
            return dt;
        }
        #endregion GetProjectByAreaGraphDetails

        #region GetProjectManpowerChartData

        public DataTable GetProjectManpowerChartData()
        {
            SqlConnection conn = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;

            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetProjectManpowerGraphDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = UA.projectNo;
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);


            }
            catch (Exception ex)
            {
                throw ex;
            }


            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

            }
            return dt;
        }
        #endregion GetProjectManpowerChartData

        #region GetProgressByFIWPDetails

        public DataTable GetProgressByFIWPDetails()
        {
            SqlConnection conn = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetProgressByFIWPDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);


            }
            catch (Exception ex)
            {
                throw ex;
            }


            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

            }
            return dt;
        }
        #endregion GetProgressByFIWPDetails

        #region GetChartDataBasedOnActionBy
        public DataTable GetChartDataBasedOnActionBy(string ActionBy)
        {
            SqlConnection conn = null;
            DataTable ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetPunchListSummaryBasedOnActionBy", conn);
                cmd.Parameters.Add("@ActionBy", SqlDbType.NVarChar, 5).Value = ActionBy;
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
                da.Fill(ds);
              
            }
            catch (Exception ex)
            {
                throw ex;
            }


            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

            }
            return ds;
        }

        #endregion GetChartDataBasedOnActionBy


        #region GetOpenByfromPersonnel
        /// <summary>
        /// To Get details from Personnel table 
        /// </summary>
        /// <returns>DataTable with Code,Name</returns>
        public DataTable GetOpenByfromPersonnel()
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            SqlDataAdapter daObj;
            try
            {

                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();

                string selectArea = "GetDetailsFromM_Personnel";
                daObj = new SqlDataAdapter(selectArea, con);
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
        #endregion GetOpenByfromPersonnel

        #region AddtoPunchList
        /// <summary>
        /// To insert data to the EIL table
        /// </summary>
        /// <param name="mObj">Object of the personnel table</param>
        /// <returns>integer value 0 or 1</returns>
        public int AddtoPunchList(MasterPersonal mObj)
        {
            int result = 0;
            SqlConnection con = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                UIClasses.Const Const = new UIClasses.Const();
                FlyCnDAL.Security.UserAuthendication UA;

                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];

                string insertQuery = "EILInsert";
                SqlCommand cmdInsert = new SqlCommand(insertQuery, con);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.Add("@projectno",SqlDbType.NVarChar,7).Value=UA.projectNo;
                cmdInsert.Parameters.Add("@Idno", SqlDbType.Int).Value=Idno;
                cmdInsert.Parameters.Add("@EILType",SqlDbType.NVarChar,7 ).Value=EILType;
                if (mObj.OpenBy != null && mObj.OpenBy!="")
                {
                    cmdInsert.Parameters.Add("@openby", SqlDbType.NVarChar, 15).Value = mObj.OpenBy;
                }
                else
                {
                    cmdInsert.Parameters.Add("@openby", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                }
                if (OpenDate != null && OpenDate!="")
                {
                    cmdInsert.Parameters.Add("@opendate",SqlDbType.DateTime).Value= Convert.ToDateTime(OpenDate);
                }
                else
                {
                    cmdInsert.Parameters.Add("@opendate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (mObj.EnteredBy != null && mObj.EnteredBy!="")
                {
                    cmdInsert.Parameters.Add("@enteredby", SqlDbType.NVarChar, 15).Value = mObj.EnteredBy;
                }
                else
                {
                    cmdInsert.Parameters.Add("@enteredby", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                }
                if (EnteredDt != null && EnteredDt!="")
                {
                    cmdInsert.Parameters.Add("@entereddate",SqlDbType.DateTime).Value= Convert.ToDateTime(EnteredDt);
                }
                else
                {
                    cmdInsert.Parameters.Add("@entereddate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (Plant != null && Plant != "")
                {
                    cmdInsert.Parameters.Add("@plant",SqlDbType.NVarChar,10 ).Value=Plant;
                }
                else
                {
                    cmdInsert.Parameters.Add("@plant", SqlDbType.NVarChar, 10).Value = DBNull.Value;

                }
                if (Area != null && Area!="")
                {
                    cmdInsert.Parameters.Add("@area", SqlDbType.NVarChar,10).Value=Area;
                }
                else
                {
                    cmdInsert.Parameters.Add("@area", SqlDbType.NVarChar, 10).Value = DBNull.Value;
                }
                if(Location!=null && Location!="")
                {
                    cmdInsert.Parameters.Add("@location",SqlDbType.NVarChar,10 ).Value=Location;
                }
                else
                {
                    cmdInsert.Parameters.Add("@location", SqlDbType.NVarChar, 10).Value = DBNull.Value;
                }
                if(Unit!=null && Unit!="")
                {
                    cmdInsert.Parameters.Add("@unit",SqlDbType.NVarChar,10 ).Value=Unit;
                }
               else
                {
                    cmdInsert.Parameters.Add("@unit", SqlDbType.NVarChar, 10).Value = DBNull.Value;
                }
                if(Drawing!=null && Drawing!="")
                {
                    cmdInsert.Parameters.Add("@drawing",SqlDbType.NVarChar,25 ).Value=Drawing;
                }
                else
                {
                    cmdInsert.Parameters.Add("@drawing", SqlDbType.NVarChar, 25).Value = DBNull.Value;
                }
                if(Sheet!=null && Sheet!="")
                {
                    cmdInsert.Parameters.Add("@sheet",SqlDbType.NVarChar,20 ).Value=Sheet;
                }
               else
                {
                    cmdInsert.Parameters.Add("@sheet", SqlDbType.NVarChar, 20).Value = DBNull.Value;
                }
                if (Revison != null && Revison!="")
                {
                    cmdInsert.Parameters.Add("@revision",SqlDbType.NVarChar,10 ).Value=Revison;
                }
                else
                {
                    cmdInsert.Parameters.Add("@revision", SqlDbType.NVarChar, 10).Value = DBNull.Value;
                }
                if (ItemDescription!=null && ItemDescription!="")
                {
                    cmdInsert.Parameters.AddWithValue("@itemdescription",SqlDbType.NText ).Value=ItemDescription;
                }
                else
                {
                    cmdInsert.Parameters.AddWithValue("@itemdescription", SqlDbType.NText).Value = DBNull.Value;
                }
                if(RFINo!=null && RFINo!="")
                {
                    cmdInsert.Parameters.Add("@rfino",SqlDbType.NVarChar,25 ).Value=RFINo;
                }
                else
                {
                    cmdInsert.Parameters.Add("@rfino", SqlDbType.NVarChar, 25).Value = DBNull.Value;
                }
                if (RFIDate != null && RFIDate!="")
                {
                    cmdInsert.Parameters.AddWithValue("@rfidate",SqlDbType.DateTime ).Value=Convert.ToDateTime(RFIDate);
                }
                else
                {
                    cmdInsert.Parameters.AddWithValue("@rfidate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (mObj.Inspector!=null && mObj.Inspector!="")
                {
                    cmdInsert.Parameters.Add("@inspector",SqlDbType.NVarChar,15 ).Value=mObj.Inspector;
                }
               else
                {
                    cmdInsert.Parameters.Add("@inspector", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                }
                if (mObj.RequestedBy != null && mObj.RequestedBy!="")
                {
                    cmdInsert.Parameters.Add("@requestedby",SqlDbType.NVarChar,15 ).Value=mObj.RequestedBy;
                }
                else
                {
                    cmdInsert.Parameters.Add("@requestedby", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                }
                if (ActionBy != null && ActionBy!="")
                {
                    cmdInsert.Parameters.Add("@actionby",SqlDbType.NVarChar,5 ).Value=ActionBy;
                }
                else
                {
                    cmdInsert.Parameters.Add("@actionby", SqlDbType.NVarChar, 5).Value = DBNull.Value;
                }
                if (Discipline != null && Discipline!="")
                {
                    cmdInsert.Parameters.Add("@displine",SqlDbType.NVarChar,5 ).Value=Discipline;
                }
               else
                {
                    cmdInsert.Parameters.Add("@displine", SqlDbType.NVarChar, 5).Value = DBNull.Value;
                }
                if (Category != null && Category!="")
                {
                    cmdInsert.Parameters.Add("@category",SqlDbType.NVarChar,5 ).Value=Category;
                }
                else
                {
                    cmdInsert.Parameters.Add("@category", SqlDbType.NVarChar, 5).Value = DBNull.Value;
                }
                cmdInsert.Parameters.AddWithValue("@queryrevision", QueryRevision);
                if (ScheduledDateCompletion != null && ScheduledDateCompletion!="")
                {
                    cmdInsert.Parameters.Add("@scheduleddatecompletion",SqlDbType.DateTime ).Value=Convert.ToDateTime(ScheduledDateCompletion);
                }
                else
                {
                    cmdInsert.Parameters.Add("@scheduleddatecompletion", SqlDbType.DateTime).Value = DBNull.Value;

                }
                if(CoveredByProject!=null)
                {
                    cmdInsert.Parameters.Add("@coveredbyproject", SqlDbType.Bit).Value=CoveredByProject;
                }
                else
                {
                    cmdInsert.Parameters.Add("@coveredbyproject", SqlDbType.Bit).Value = DBNull.Value;
                }
                if(System!=null && System!="")
                {
                    cmdInsert.Parameters.Add("@system",SqlDbType.NVarChar,20 ).Value=System;
                }
               else
                {
                    cmdInsert.Parameters.Add("@system", SqlDbType.NVarChar, 20).Value = DBNull.Value;
                }
                if(Subsystem!=null && Subsystem!="")
                {
                    cmdInsert.Parameters.Add("@subsystem",SqlDbType.NVarChar,20 ).Value=Subsystem;
                }
                else
                {
                    cmdInsert.Parameters.Add("@subsystem", SqlDbType.NVarChar, 20).Value = DBNull.Value;
                }
                if(ControlSystem!=null && ControlSystem!="")
                {
                    cmdInsert.Parameters.Add("@controlsystem",SqlDbType.NVarChar,20 ).Value=ControlSystem;
                }
               else
                {
                    cmdInsert.Parameters.Add("@controlsystem", SqlDbType.NVarChar, 20).Value = DBNull.Value;
                }
                if(FailCategory!=null && FailCategory!="")
                {
                    cmdInsert.Parameters.Add("@failcategory", SqlDbType.NVarChar,1).Value = FailCategory;
                }
                else
                {
                    cmdInsert.Parameters.Add("@failcategory", SqlDbType.NVarChar, 1).Value = DBNull.Value;
                }
                if(ChangeReq!=null)
                {
                    cmdInsert.Parameters.Add("@changereq",SqlDbType.Bit ).Value=ChangeReq;
                }
                else
                {
                    cmdInsert.Parameters.Add("@changereq", SqlDbType.Bit).Value = DBNull.Value;
                }
                if(Reference!=null && Reference!="")
                {
                    cmdInsert.Parameters.Add("@reference", SqlDbType.NVarChar,25).Value=Reference;
                }
               else
                {
                    cmdInsert.Parameters.Add("@reference", SqlDbType.NVarChar, 25).Value = DBNull.Value;
                }
                if (ReferenceDate != null && ReferenceDate!="")
                {
                    cmdInsert.Parameters.Add("@referencedate", SqlDbType.DateTime).Value=Convert.ToDateTime(ReferenceDate);
                }
                else
                {
                    cmdInsert.Parameters.Add("@referencedate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (mObj.ResponsiblePerson != null && mObj.ResponsiblePerson != "")
                {
                    cmdInsert.Parameters.Add("@responsibleperson", SqlDbType.NVarChar,15).Value=mObj.ResponsiblePerson;
                }
                else
                {
                    cmdInsert.Parameters.Add("@responsibleperson", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                }
                if (Organization != null && Organization != "")
                {
                    cmdInsert.Parameters.Add("@organization",SqlDbType.NVarChar,5 ).Value=Organization;
                }
                else
                {
                    cmdInsert.Parameters.Add("@organization", SqlDbType.NVarChar, 5).Value = DBNull.Value;
                }
                if (CompletionDate != null && CompletionDate!="")
                {
                    cmdInsert.Parameters.Add("@completiondate",SqlDbType.DateTime ).Value=Convert.ToDateTime(CompletionDate);
                }
                else
                {
                    cmdInsert.Parameters.Add("@completiondate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (CompletionRemarks!=null && CompletionRemarks!="")
                {
                    cmdInsert.Parameters.Add("@completionremarks", SqlDbType.NText).Value=CompletionRemarks;
                }
                else
                {
                    cmdInsert.Parameters.Add("@completionremarks", SqlDbType.NText).Value = DBNull.Value;
                }
                
                if (mObj.SignedBy != null && mObj.SignedBy != "")
                {
                    cmdInsert.Parameters.Add("@signedby", SqlDbType.NVarChar, 15).Value = mObj.SignedBy;
                }
                else
                {
                    cmdInsert.Parameters.Add("@signedby", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                }
                if (linkId != null && linkId != "")
                {
                    cmdInsert.Parameters.Add("@LnkId", SqlDbType.NVarChar, 50).Value = linkId;
                }
                else
                {
                    cmdInsert.Parameters.Add("@LnkId", SqlDbType.NVarChar, 50).Value = DBNull.Value;
                }
                cmdInsert.Parameters.Add("@moduleId",SqlDbType.NVarChar,10).Value=moduleId;
                cmdInsert.Parameters.Add("@trackCategory", SqlDbType.NVarChar, 25).Value = category;
                cmdInsert.Parameters.Add("@categoryDesc", SqlDbType.NVarChar, 25).Value = categoryDesc;
                //cmdInsert.Parameters.Add("@actCode", SqlDbType.SmallInt).Value = 1;
                if (logDesc != null && logDesc != "")
                {
                    cmdInsert.Parameters.Add("@logDesc", SqlDbType.NText).Value = logDesc;
                }
                else
                {
                    cmdInsert.Parameters.Add("@logDesc", SqlDbType.NText).Value = DBNull.Value;
                }
                if (logStatus != null && logStatus != "")
                {
                    cmdInsert.Parameters.Add("@logStatus", SqlDbType.NVarChar, 10).Value = logStatus;
                }
                else
                {
                    cmdInsert.Parameters.Add("@logStatus", SqlDbType.NVarChar, 10).Value = DBNull.Value;
                }
                if(updatedBy!=null && updatedBy!="")
                {
                    cmdInsert.Parameters.Add("@updatedBy", SqlDbType.NVarChar, 256).Value = updatedBy;
                }
                else
                {
                    cmdInsert.Parameters.Add("@updatedBy", SqlDbType.NVarChar, 256).Value = DBNull.Value;
                }
                if(updatedDate!=null)
                {
                    cmdInsert.Parameters.Add("@updatedDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd");
                }
               else
                {
                    cmdInsert.Parameters.Add("@updatedDate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                cmdInsert.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@createdby", UA.userName);

                SqlParameter outputp = cmdInsert.Parameters.Add("@out", SqlDbType.NVarChar,100);
                outputp.Direction = ParameterDirection.Output;
              
              
                result = cmdInsert.ExecuteNonQuery();
                string dfdf = outputp.Value.ToString();
                
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        #endregion AddtoPunchList

        #region EILInsertWithoutTrackingDetails
        /// <summary>
        /// To insert data to the EIL table
        /// </summary>
        /// <param name="mObj">Object of the personnel table</param>
        /// <returns>integer value 0 or 1</returns>
        public int EILInsertWithoutTrackingDetails(MasterPersonal mObj)
        {
            int result = 0;
            SqlConnection con = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                UIClasses.Const Const = new UIClasses.Const();
                FlyCnDAL.Security.UserAuthendication UA;

                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];

                string insertQuery = "EILInsertWithoutTrackingDetails";
                SqlCommand cmdInsert = new SqlCommand(insertQuery, con);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.Add("@projectno", SqlDbType.NVarChar, 7).Value = UA.projectNo;
                cmdInsert.Parameters.Add("@Idno", SqlDbType.Int).Value = Idno;
                cmdInsert.Parameters.Add("@EILType", SqlDbType.NVarChar, 7).Value = EILType;
                if (mObj.OpenBy != null && mObj.OpenBy != "")
                {
                    cmdInsert.Parameters.Add("@openby", SqlDbType.NVarChar, 15).Value = mObj.OpenBy;
                }
                else
                {
                    cmdInsert.Parameters.Add("@openby", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                }
                if (OpenDate != null && OpenDate != "")
                {
                    cmdInsert.Parameters.Add("@opendate", SqlDbType.DateTime).Value = Convert.ToDateTime(OpenDate);
                }
                else
                {
                    cmdInsert.Parameters.Add("@opendate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (mObj.EnteredBy != null && mObj.EnteredBy != "")
                {
                    cmdInsert.Parameters.Add("@enteredby", SqlDbType.NVarChar, 15).Value = mObj.EnteredBy;
                }
                else
                {
                    cmdInsert.Parameters.Add("@enteredby", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                }
                if (EnteredDt != null && EnteredDt != "")
                {
                    cmdInsert.Parameters.Add("@entereddate", SqlDbType.DateTime).Value = Convert.ToDateTime(EnteredDt);
                }
                else
                {
                    cmdInsert.Parameters.Add("@entereddate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (Plant != null && Plant != "")
                {
                    cmdInsert.Parameters.Add("@plant", SqlDbType.NVarChar, 10).Value = Plant;
                }
                else
                {
                    cmdInsert.Parameters.Add("@plant", SqlDbType.NVarChar, 10).Value = DBNull.Value;

                }
                if (Area != null && Area != "")
                {
                    cmdInsert.Parameters.Add("@area", SqlDbType.NVarChar, 10).Value = Area;
                }
                else
                {
                    cmdInsert.Parameters.Add("@area", SqlDbType.NVarChar, 10).Value = DBNull.Value;
                }
                if (Location != null && Location != "")
                {
                    cmdInsert.Parameters.Add("@location", SqlDbType.NVarChar, 10).Value = Location;
                }
                else
                {
                    cmdInsert.Parameters.Add("@location", SqlDbType.NVarChar, 10).Value = DBNull.Value;
                }
                if (Unit != null && Unit != "")
                {
                    cmdInsert.Parameters.Add("@unit", SqlDbType.NVarChar, 10).Value = Unit;
                }
                else
                {
                    cmdInsert.Parameters.Add("@unit", SqlDbType.NVarChar, 10).Value = DBNull.Value;
                }
                if (Drawing != null && Drawing != "")
                {
                    cmdInsert.Parameters.Add("@drawing", SqlDbType.NVarChar, 25).Value = Drawing;
                }
                else
                {
                    cmdInsert.Parameters.Add("@drawing", SqlDbType.NVarChar, 25).Value = DBNull.Value;
                }
                if (Sheet != null && Sheet != "")
                {
                    cmdInsert.Parameters.Add("@sheet", SqlDbType.NVarChar, 20).Value = Sheet;
                }
                else
                {
                    cmdInsert.Parameters.Add("@sheet", SqlDbType.NVarChar, 20).Value = DBNull.Value;
                }
                if (Revison != null && Revison != "")
                {
                    cmdInsert.Parameters.Add("@revision", SqlDbType.NVarChar, 10).Value = Revison;
                }
                else
                {
                    cmdInsert.Parameters.Add("@revision", SqlDbType.NVarChar, 10).Value = DBNull.Value;
                }
                if (ItemDescription != null && ItemDescription != "")
                {
                    cmdInsert.Parameters.AddWithValue("@itemdescription", SqlDbType.NText).Value = ItemDescription;
                }
                else
                {
                    cmdInsert.Parameters.AddWithValue("@itemdescription", SqlDbType.NText).Value = DBNull.Value;
                }
                if (RFINo != null && RFINo != "")
                {
                    cmdInsert.Parameters.Add("@rfino", SqlDbType.NVarChar, 25).Value = RFINo;
                }
                else
                {
                    cmdInsert.Parameters.Add("@rfino", SqlDbType.NVarChar, 25).Value = DBNull.Value;
                }
                if (RFIDate != null && RFIDate != "")
                {
                    cmdInsert.Parameters.AddWithValue("@rfidate", SqlDbType.DateTime).Value = Convert.ToDateTime(RFIDate);
                }
                else
                {
                    cmdInsert.Parameters.AddWithValue("@rfidate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (mObj.Inspector != null && mObj.Inspector != "")
                {
                    cmdInsert.Parameters.Add("@inspector", SqlDbType.NVarChar, 15).Value = mObj.Inspector;
                }
                else
                {
                    cmdInsert.Parameters.Add("@inspector", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                }
                if (mObj.RequestedBy != null && mObj.RequestedBy != "")
                {
                    cmdInsert.Parameters.Add("@requestedby", SqlDbType.NVarChar, 15).Value = mObj.RequestedBy;
                }
                else
                {
                    cmdInsert.Parameters.Add("@requestedby", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                }
                if (ActionBy != null && ActionBy != "")
                {
                    cmdInsert.Parameters.Add("@actionby", SqlDbType.NVarChar, 5).Value = ActionBy;
                }
                else
                {
                    cmdInsert.Parameters.Add("@actionby", SqlDbType.NVarChar, 5).Value = DBNull.Value;
                }
                if (Discipline != null && Discipline != "")
                {
                    cmdInsert.Parameters.Add("@displine", SqlDbType.NVarChar, 5).Value = Discipline;
                }
                else
                {
                    cmdInsert.Parameters.Add("@displine", SqlDbType.NVarChar, 5).Value = DBNull.Value;
                }
                if (Category != null && Category != "")
                {
                    cmdInsert.Parameters.Add("@category", SqlDbType.NVarChar, 5).Value = Category;
                }
                else
                {
                    cmdInsert.Parameters.Add("@category", SqlDbType.NVarChar, 5).Value = DBNull.Value;
                }
                cmdInsert.Parameters.AddWithValue("@queryrevision", QueryRevision);
                if (ScheduledDateCompletion != null && ScheduledDateCompletion != "")
                {
                    cmdInsert.Parameters.Add("@scheduleddatecompletion", SqlDbType.DateTime).Value = Convert.ToDateTime(ScheduledDateCompletion);
                }
                else
                {
                    cmdInsert.Parameters.Add("@scheduleddatecompletion", SqlDbType.DateTime).Value = DBNull.Value;

                }
                if (CoveredByProject != null)
                {
                    cmdInsert.Parameters.Add("@coveredbyproject", SqlDbType.Bit).Value = CoveredByProject;
                }
                else
                {
                    cmdInsert.Parameters.Add("@coveredbyproject", SqlDbType.Bit).Value = DBNull.Value;
                }
                if (System != null && System != "")
                {
                    cmdInsert.Parameters.Add("@system", SqlDbType.NVarChar, 20).Value = System;
                }
                else
                {
                    cmdInsert.Parameters.Add("@system", SqlDbType.NVarChar, 20).Value = DBNull.Value;
                }
                if (Subsystem != null && Subsystem != "")
                {
                    cmdInsert.Parameters.Add("@subsystem", SqlDbType.NVarChar, 20).Value = Subsystem;
                }
                else
                {
                    cmdInsert.Parameters.Add("@subsystem", SqlDbType.NVarChar, 20).Value = DBNull.Value;
                }
                if (ControlSystem != null && ControlSystem != "")
                {
                    cmdInsert.Parameters.Add("@controlsystem", SqlDbType.NVarChar, 20).Value = ControlSystem;
                }
                else
                {
                    cmdInsert.Parameters.Add("@controlsystem", SqlDbType.NVarChar, 20).Value = DBNull.Value;
                }
                if (FailCategory != null && FailCategory != "")
                {
                    cmdInsert.Parameters.Add("@failcategory", SqlDbType.NVarChar, 1).Value = FailCategory;
                }
                else
                {
                    cmdInsert.Parameters.Add("@failcategory", SqlDbType.NVarChar, 1).Value = DBNull.Value;
                }
                if (ChangeReq != null)
                {
                    cmdInsert.Parameters.Add("@changereq", SqlDbType.Bit).Value = ChangeReq;
                }
                else
                {
                    cmdInsert.Parameters.Add("@changereq", SqlDbType.Bit).Value = DBNull.Value;
                }
                if (Reference != null && Reference != "")
                {
                    cmdInsert.Parameters.Add("@reference", SqlDbType.NVarChar, 25).Value = Reference;
                }
                else
                {
                    cmdInsert.Parameters.Add("@reference", SqlDbType.NVarChar, 25).Value = DBNull.Value;
                }
                if (ReferenceDate != null && ReferenceDate != "")
                {
                    cmdInsert.Parameters.Add("@referencedate", SqlDbType.DateTime).Value = Convert.ToDateTime(ReferenceDate);
                }
                else
                {
                    cmdInsert.Parameters.Add("@referencedate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (mObj.ResponsiblePerson != null && mObj.ResponsiblePerson != "")
                {
                    cmdInsert.Parameters.Add("@responsibleperson", SqlDbType.NVarChar, 15).Value = mObj.ResponsiblePerson;
                }
                else
                {
                    cmdInsert.Parameters.Add("@responsibleperson", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                }
                if (Organization != null && Organization != "")
                {
                    cmdInsert.Parameters.Add("@organization", SqlDbType.NVarChar, 5).Value = Organization;
                }
                else
                {
                    cmdInsert.Parameters.Add("@organization", SqlDbType.NVarChar, 5).Value = DBNull.Value;
                }
                if (CompletionDate != null && CompletionDate != "")
                {
                    cmdInsert.Parameters.Add("@completiondate", SqlDbType.DateTime).Value = Convert.ToDateTime(CompletionDate);
                }
                else
                {
                    cmdInsert.Parameters.Add("@completiondate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (CompletionRemarks != null && CompletionRemarks != "")
                {
                    cmdInsert.Parameters.Add("@completionremarks", SqlDbType.NText).Value = CompletionRemarks;
                }
                else
                {
                    cmdInsert.Parameters.Add("@completionremarks", SqlDbType.NText).Value = DBNull.Value;
                }

                if (mObj.SignedBy != null && mObj.SignedBy != "")
                {
                    cmdInsert.Parameters.Add("@signedby", SqlDbType.NVarChar, 15).Value = mObj.SignedBy;
                }
                else
                {
                    cmdInsert.Parameters.Add("@signedby", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                }
                if (linkId != null && linkId != "")
                {
                    cmdInsert.Parameters.Add("@LnkId", SqlDbType.NVarChar, 50).Value = linkId;
                }
                else
                {
                    cmdInsert.Parameters.Add("@LnkId", SqlDbType.NVarChar, 50).Value = DBNull.Value;
                }
                cmdInsert.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                cmdInsert.Parameters.AddWithValue("@createdby", UA.userName);
                result = cmdInsert.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        #endregion EILInsertWithoutTrackingDetails


        #region EditPunchListItems
        /// <summary>
        /// To Update data in EIL Table
        /// </summary>
        /// <param name="Idno">Id no and Object of Personnel class</param>
        /// <param name="mObj"></param>
        /// <returns>Integer 0 or 1</returns>
        public int EditPunchListItems(int Idno, MasterPersonal mObj)
        {
            int result = 0;
            SqlConnection con = null;
            try
            {
                UIClasses.Const Const = new UIClasses.Const();
                FlyCnDAL.Security.UserAuthendication UA;
                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                string editQuery = "EILByProjectNoIDNoUpdate";
                SqlCommand cmdEdit = new SqlCommand(editQuery, con);
                cmdEdit.CommandType = CommandType.StoredProcedure;
                cmdEdit.Parameters.AddWithValue("@projectno", UA.projectNo);
                cmdEdit.Parameters.AddWithValue("@Idno", Idno);

                cmdEdit.Parameters.AddWithValue("@openby", mObj.OpenBy);
                if (OpenDate != null)
                {
                    cmdEdit.Parameters.AddWithValue("@opendate", Convert.ToDateTime(OpenDate));
                }
                if (!string.IsNullOrEmpty(mObj.EnteredBy))
                {
                    cmdEdit.Parameters.AddWithValue("@enteredby", mObj.EnteredBy);
                }
                cmdEdit.Parameters.AddWithValue("@requestedby", mObj.RequestedBy);
                cmdEdit.Parameters.AddWithValue("@inspector", mObj.Inspector);
                cmdEdit.Parameters.AddWithValue("@responsibleperson", mObj.ResponsiblePerson);
                cmdEdit.Parameters.AddWithValue("@signedby", mObj.SignedBy);
                cmdEdit.Parameters.AddWithValue("@plant", Plant);
                cmdEdit.Parameters.AddWithValue("@unit", Unit);
                cmdEdit.Parameters.AddWithValue("@area", Area);
                cmdEdit.Parameters.AddWithValue("@location", Location);
                if (EnteredDt != null)
                {
                    cmdEdit.Parameters.AddWithValue("@entereddate", Convert.ToDateTime(EnteredDt));
                }
                cmdEdit.Parameters.AddWithValue("@system", System);
                cmdEdit.Parameters.AddWithValue("@subsystem", Subsystem);
                cmdEdit.Parameters.AddWithValue("@controlsystem", ControlSystem);
                cmdEdit.Parameters.AddWithValue("@actionby", ActionBy);
                cmdEdit.Parameters.AddWithValue("@failcategory", FailCategory);
                cmdEdit.Parameters.AddWithValue("@rfino", RFINo);
                cmdEdit.Parameters.AddWithValue("@displine", Discipline);
                cmdEdit.Parameters.AddWithValue("@category", Category);
                if (RFIDate != null)
                {
                    cmdEdit.Parameters.AddWithValue("@rfidate", Convert.ToDateTime(RFIDate));
                }
                cmdEdit.Parameters.AddWithValue("@coveredbyproject", CoveredByProject);
                cmdEdit.Parameters.AddWithValue("@itemdescription", ItemDescription);
                cmdEdit.Parameters.AddWithValue("@reference", Reference);
                if (ReferenceDate != null)
                {
                    cmdEdit.Parameters.AddWithValue("@referencedate", Convert.ToDateTime(ReferenceDate));
                }
                cmdEdit.Parameters.AddWithValue("@changereq", ChangeReq);
                cmdEdit.Parameters.AddWithValue("@drawing", Drawing);
                cmdEdit.Parameters.AddWithValue("@revision", Revison);
                cmdEdit.Parameters.AddWithValue("@sheet", Sheet);
                cmdEdit.Parameters.AddWithValue("@queryrevision", QueryRevision);
                if (ScheduledDateCompletion != null)
                {
                    cmdEdit.Parameters.AddWithValue("@scheduleddatecompletion", Convert.ToDateTime(ScheduledDateCompletion));
                }
                cmdEdit.Parameters.AddWithValue("@organization", Organization);
                if (CompletionDate != null)
                {
                    cmdEdit.Parameters.AddWithValue("@completiondate", Convert.ToDateTime(CompletionDate));
                }
                cmdEdit.Parameters.AddWithValue("@completionremarks", CompletionRemarks);
                result = cmdEdit.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        #endregion EditPunchListItems

        #region GetPunchListItemDetails
        /// <summary>
        /// To get the details from EIL table passing Project No and Id
        /// </summary>
        /// <param name="ProjNo">Project Number and Id</param>
        /// <param name="id"></param>
        /// <returns>Datatable with all the details from EIL Table</returns>
        public DataTable GetPunchListItemDetails(string ProjNo, string id)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            SqlDataAdapter daObj;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();             
                string selectQuery = "procEILByProjectNOIdSelect";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@projectno", ProjNo);
                cmdSelect.Parameters.AddWithValue("@idno", id);
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
        #endregion GetPunchListItemDetails

        #region GetIntermediateLog
        public DataTable GetIntermediateLog(string id)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            SqlDataAdapter daObj;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                string selectQuery = "GetIntermediateLog";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.Add("@IdNo",SqlDbType.NVarChar,50).Value= id;
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
        #endregion GetIntermediateLog

        #region GetActivityByActCode
        public DataTable GetActivityByActCode(string id,string projectNo,string moduleId,string category)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            SqlDataAdapter daObj;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                string selectQuery = "GetActivityByActCode";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.Add("@actCode", SqlDbType.SmallInt).Value = id;
                cmdSelect.Parameters.Add("@projectno", SqlDbType.NVarChar,7).Value = projectNo;
                cmdSelect.Parameters.Add("@moduleId", SqlDbType.NVarChar, 10).Value = moduleId;
                cmdSelect.Parameters.Add("@trackCategory",SqlDbType.NVarChar,25).Value=category;
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
        #endregion GetActivityByActCode

        #region Get Punch List Item Details For Mobile
        /// <summary>
        /// To get the details from EIL table passing for mobile app
        /// </summary>
        /// <param name="ProjNo">Project Number and Id</param>
        /// <param name="id"></param>
        /// /// <param name="type"> WEIL/CEIL/QEIL </param>
        /// <returns>Datatable with all the details from EIL Table of curresponding item</returns>
        public DataTable GetPunchListItemDetailsForMobile(string ProjNo, string id, string type)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            SqlDataAdapter daObj;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                string selectQuery = "GetPunchListItemDetailsForMobile";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@projectno", ProjNo);
                cmdSelect.Parameters.AddWithValue("@id", id);
                cmdSelect.Parameters.AddWithValue("@type", type);
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
        /// <summary>
        /// To get the attachments from EIL_Attach table passing for mobile app
        /// </summary>
        /// <param name="projNo">Project Number</param>
        /// <param name="punchID">ID of EIL</param>
        /// /// <param name="EILtype"> WEIL/CEIL/QEIL </param>
        /// <returns>Datatable with the details from EIL_Attach Table of curresponding item</returns>
        public DataTable GetPunchListItemAttachments(string projNo, string punchID, string EILtype)
        {
            DataTable dt = new DataTable();
            SqlConnection con = null;
            SqlDataAdapter daObj;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmdSelect = new SqlCommand("[GetDetailsFromEIL_Attach]", con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@No", projNo);
                cmdSelect.Parameters.AddWithValue("@id", punchID);
                cmdSelect.Parameters.AddWithValue("@EILType", EILtype);
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
        #endregion Get PunchList Item Details For Mobile

        #region GetSystemDetails
        public DataTable GetSystemDetails()
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
                string selectQuery = "SelectCodeDescriptionFromSystem";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@projectno", UA.projectNo);

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
        #endregion GetSystemDetails

        #region GetSubSystemDetails
        public DataTable GetSubSystemDetails()
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
                string selectQuery = "SelectCodeDescriptionFromSubSystem";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@projectno", UA.projectNo);

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
        #endregion GetSubSystemDetails

        #region GetCTRLSystemDetails
        public DataTable GetCTRLSystemDetails()
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
                string selectQuery = "SelectCodeDescriptionFromCNTRLSystem";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@projectno", UA.projectNo);

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
        #endregion GetCTRLSystemDetails

        #region DeleteEIL
        public int DeleteEIL(string projno, string Id)
        {
            int result = 0;
            SqlConnection con = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                UIClasses.Const Const = new UIClasses.Const();

                FlyCnDAL.Security.UserAuthendication UA;


                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];

                string deleteQuery = "procEILDelete";
                SqlCommand cmdDelete = new SqlCommand(deleteQuery, con);
                cmdDelete.CommandType = CommandType.StoredProcedure;
                cmdDelete.Parameters.AddWithValue("@projectno", UA.projectNo);
                cmdDelete.Parameters.AddWithValue("@Idno", Id);
                result = cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        #endregion DeleteEIL

        #region GetPlatFromM_Plant
        public DataTable GetPlatFromM_Plant()
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

                string selectQuery = "GetDetailsFromM_Plant";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@No", UA.projectNo);
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
        #endregion GetPlatFromM_Plant

        #region GetAreaFromM_Area
        public DataTable GetAreaFromM_Area()
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

                string selectQuery = "GetDetailsFromM_Area";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@No", UA.projectNo);
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

        #endregion GetAreaFromM_Area

        #region GetLocationFromM_Location
        public DataTable GetLocationFromM_Location()
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

                string selectQuery = "GetDetailsFromM_Location";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@No", UA.projectNo);
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
        #endregion GetLocationFromM_Location

        #region GetUnitFromM_Unit
        public DataTable GetUnitFromM_Unit()
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

                string selectQuery = "GetDetailsFromM_Unit";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@No", UA.projectNo);
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
        #endregion GetUnitFromM_Unit

        #region GetUActionByFromM_Company
        public DataTable GetUActionByFromM_Company()
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

                string selectQuery = "GetDetailsFromM_Company";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@No", UA.projectNo);
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
        #endregion GetUActionByFromM_Company

        #region GetDisciplineFromM_Discipline
        public DataTable GetDisciplineFromM_Discipline()
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

                string selectQuery = "GetDetailsFromM_Discipline";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@No", UA.projectNo);
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
        #endregion GetDisciplineFromM_Discipline

        #region GetFailCategoryFromM_FailCategory
        public DataTable GetFailCategoryFromM_FailCategory()
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

                string selectQuery = "GetDetailsFromM_FailCategory";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@No", UA.projectNo);
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
        #endregion GetFailCategoryFromM_FailCategory

        #region GetCategoryFromM_Category
        public DataTable GetCategoryFromM_Category()
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

                string selectQuery = "GetDetailsFromM_Category";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@No", UA.projectNo);
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
        #endregion GetCategoryFromM_Category

        #region InsertEILAttachment
        public int InsertEILAttachment(Boolean isFromMobile=false,string userName="",string projNo="")
        {
            int result = 0;
            SqlConnection con = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                UIClasses.Const Const = new UIClasses.Const();

                string insertQuery = "procInsertEILAttachByProjectNo";
                SqlCommand cmdInsert = new SqlCommand(insertQuery, con);
                cmdInsert.CommandType = CommandType.StoredProcedure;

                if (isFromMobile)
                {
                    cmdInsert.Parameters.AddWithValue("@projectno", projNo);
                    cmdInsert.Parameters.AddWithValue("@uploadedBy", userName);
                }
                else
                {
                    FlyCnDAL.Security.UserAuthendication UA;
                    HttpContext context = HttpContext.Current;
                    UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
                    cmdInsert.Parameters.AddWithValue("@projectno", UA.projectNo);
                    cmdInsert.Parameters.AddWithValue("@uploadedBy", UA.userName);
                }
                cmdInsert.Parameters.AddWithValue("@Idno", id);
                cmdInsert.Parameters.AddWithValue("@EILType", EILType);
                cmdInsert.Parameters.AddWithValue("@filename", fileUpload);
                cmdInsert.Parameters.AddWithValue("@date", DateTime.Now);
                cmdInsert.Parameters.AddWithValue("@fileType", FileType);
                cmdInsert.Parameters.AddWithValue("@image", image);
                cmdInsert.Parameters.AddWithValue("@fileSize", fileSize);
                result = cmdInsert.ExecuteNonQuery();
                if (!isFromMobile)
                {
                    var page = HttpContext.Current.CurrentHandler as Page;
                    eObj.InsertionSuccessData(page);
                }
            }
            catch (SqlException ex)
            {
                if (!isFromMobile)
                {
                    var page = HttpContext.Current.CurrentHandler as Page;
                   // eObj.ErrorData(ex, page);
                    throw ex;
                }
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        #endregion InsertEILAttachment

        #region DeleteEilByID
        public void DeleteEilByID(Guid ImageID)
        {
            SqlConnection con = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand boqcmd = new SqlCommand();
                boqcmd.CommandType = CommandType.StoredProcedure;
                boqcmd.Connection = con;
                boqcmd.CommandText = "[GetEIL_AttachByID]";
                boqcmd.Parameters.Add("@AttachID", SqlDbType.UniqueIdentifier).Value = ImageID;
                boqcmd.ExecuteNonQuery();
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.DeleteSuccessData(page);
               
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Dispose();
                }
            }
        }
        #endregion DeleteEilByID

        #region DeleteEILAttach
        public int DeleteEILAttach(string id, string type)
        {
            int result = 0;
            SqlConnection con = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                UIClasses.Const Const = new UIClasses.Const();

                FlyCnDAL.Security.UserAuthendication UA;


                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];

                string deleteQuery = "procDeleteByProjectNoRFIType";
                SqlCommand cmdDelete = new SqlCommand(deleteQuery, con);
                cmdDelete.CommandType = CommandType.StoredProcedure;
                cmdDelete.Parameters.AddWithValue("@projectno", UA.projectNo);
                cmdDelete.Parameters.AddWithValue("@Idno", id);
                cmdDelete.Parameters.AddWithValue("@EILType", type);
                
                result = cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        #endregion DeleteEILAttach

        #region GetFileFromEILAttachByProjectNoRefEILType
        public DataTable GetFileFromEILAttachByProjectNoRefEILType(string id)
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

            /*    string selectQuery = "select FileName,SlNo,EILType from EIL_Attach where ProjectNo=@No and RefNo=@id and EILType=@EILType";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.Parameters.AddWithValue("@No", UA.projectNo);
                cmdSelect.Parameters.AddWithValue("@id", id);
                cmdSelect.Parameters.AddWithValue("@EILType", "WEIL");
                daObj = new SqlDataAdapter(cmdSelect);
                daObj.Fill(dt);                                                                  */
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
        #endregion GetFileFromEILAttachByProjectNoRefEILType

        #region DeleteEilAttachByProjectNoRefNoEILTypeSlNo
        public int DeleteEilAttachByProjectNoRefNoEILTypeSlNo(int id, string type, int slno)
        {
            int result = 0;
            SqlConnection con = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                UIClasses.Const Const = new UIClasses.Const();

                FlyCnDAL.Security.UserAuthendication UA;


                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];

                string deleteQuery = "DeleteFileNameEilAttachByProjectNoRFINoEILTypeSlNo";
                SqlCommand cmdDelete = new SqlCommand(deleteQuery, con);
                cmdDelete.CommandType = CommandType.StoredProcedure;
                cmdDelete.Parameters.AddWithValue("@projectno", UA.projectNo);
                cmdDelete.Parameters.AddWithValue("@Idno", id);
                cmdDelete.Parameters.AddWithValue("@EILType", "WEIL");
                cmdDelete.Parameters.AddWithValue("@name", fileUpload);
                cmdDelete.Parameters.AddWithValue("@slno", slno);
                result = cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        #endregion DeleteEilAttachByProjectNoRefNoEILTypeSlNo

        #region GetEIL_AttachDetails
        public DataTable GetEIL_AttachDetails()
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

                string selectQuery = "GetDetailsFromEIL_Attach";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@No", UA.projectNo);
                cmdSelect.Parameters.AddWithValue("@id", id);
                cmdSelect.Parameters.AddWithValue("@EILType",EILType);
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
        #endregion GetEIL_AttachDetails

        #region GetSLNo_AttachDetails
        public DataTable GetSLNo_AttachDetails(string id, string name, string type)
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

                string selectQuery = "SelectSlNoEIL_Attach";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@projectno", UA.projectNo);
                cmdSelect.Parameters.AddWithValue("@Idno", id);
                cmdSelect.Parameters.AddWithValue("@EILType", type);
                cmdSelect.Parameters.AddWithValue("@filename", name);
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
        #endregion GetSLNo_AttachDetails

        //#region GetControlSystemFromM_CTRL_System
        //public DataTable GetControlSystemFromM_CTRL_System()
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection con = null;
        //    SqlDataAdapter daObj;
        //    try
        //    {

        //        dbConnection dcon = new dbConnection();
        //        con = dcon.GetDBConnection();
        //        UIClasses.Const Const = new UIClasses.Const();

        //        FlyCnDAL.Security.UserAuthendication UA;
        //        HttpContext context = HttpContext.Current;
        //        UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];

        //        string selectQuery = "select Code,Description from M_CTRL_System where ProjectNo=@No";
        //        SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
        //        cmdSelect.Parameters.AddWithValue("@No", UA.projectNo);
        //        daObj = new SqlDataAdapter(cmdSelect);
        //        daObj.Fill(dt);
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;

        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return dt;
        //}
        //#endregion GetControlSystemFromM_CTRL_System

        //#region GetSystemFromM_TO_System
        //public DataTable GetSystemFromM_TO_System()
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection con = null;
        //    SqlDataAdapter daObj;
        //    try
        //    {

        //        dbConnection dcon = new dbConnection();
        //        con = dcon.GetDBConnection();
        //        UIClasses.Const Const = new UIClasses.Const();

        //        FlyCnDAL.Security.UserAuthendication UA;
        //        HttpContext context = HttpContext.Current;
        //        UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];

        //        string selectQuery = "select Code,Description from M_TO_System where ProjectNo=@No";
        //        SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
        //        cmdSelect.Parameters.AddWithValue("@No", UA.projectNo);
        //        daObj = new SqlDataAdapter(cmdSelect);
        //        daObj.Fill(dt);
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;

        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return dt;
        //}
        //#endregion GetControlSystemFromM_CTRL_System

        //#region GetSubSystemFromM_TO_SubSystem
        //public DataTable GetSubSystemFromM_TO_SubSystem()
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection con = null;
        //    SqlDataAdapter daObj;
        //    try
        //    {

        //        dbConnection dcon = new dbConnection();
        //        con = dcon.GetDBConnection();
        //        UIClasses.Const Const = new UIClasses.Const();

        //        FlyCnDAL.Security.UserAuthendication UA;
        //        HttpContext context = HttpContext.Current;
        //        UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];

        //        string selectQuery = "select Code,Description from M_TO_SubSystem where ProjectNo=@No";
        //        SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
        //        cmdSelect.Parameters.AddWithValue("@No", UA.projectNo);
        //        daObj = new SqlDataAdapter(cmdSelect);
        //        daObj.Fill(dt);
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;

        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return dt;
        //}
        //#endregion GetControlSystemFromM_CTRL_System

        #region MakeFile
        public SqlDataReader MakeFile(Guid Id)
        {
           SqlDataReader reader=null;
           SqlCommand cmd =null;
           dbConnection dcon = new dbConnection();
          
            //
            try
            {

               
                dcon.GetDBConnection();
                
                cmd = new SqlCommand();

                cmd.Connection = dcon.SQLCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEILAttachment";
                cmd.Parameters.Add("@AttachID", SqlDbType.UniqueIdentifier).Value = Id;
                reader = cmd.ExecuteReader();
               
            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
               
                
            }
            return reader;
        }
        
        #endregion MakeFile

        #region ValidateIdNo
        public bool ValidateIdNo(int CheckID,string Type)
        {
            bool flag;
            SqlConnection con = null;
            try
            {

                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("CheckID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = CheckID;
                cmd.Parameters.Add("@EilType", SqlDbType.NVarChar, 4).Value = Type;
                SqlParameter outflag = cmd.Parameters.Add("@flag", SqlDbType.Bit);
                outflag.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                flag = (bool)outflag.Value;
                if (flag == true)
                {
                    return flag;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return false;
        }

        #endregion ValidateIdNo

        #region GetAllCategory
        public DataTable GetAllCategory(string projectNo, string moduleId)
        {
            SqlConnection conn = null;
            DataTable ds = null;

            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                SqlCommand cmd = new SqlCommand("GetAllCategory", conn);
                cmd.Parameters.Add("@moduleId", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar, 7).Value = projectNo;

                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
                da.Fill(ds);

                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

            }

        }

        #endregion GetAllCategory

        #region GetAllModules
        public DataTable GetAllModules()
        {
            SqlConnection conn = null;
            DataTable ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            string projectNo = UA.projectNo;
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetAllModules", conn);
                cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
                da.Fill(ds);

                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

            }

        }

        #endregion GetAllModules

        #region GetAllActivitiesFromSys_Activities
        public DataTable GetAllActivitiesFromSys_Activities(string projectNo, string moduleId,string category)
        {
            SqlConnection conn = null;
            DataTable ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                conn = dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetAllActivitiesFromSys_Activities", conn);
                cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@ModuleID", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 25).Value = category;
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
                da.Fill(ds);

                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

            }

        }

        #endregion GetAllActivitiesFromSys_Activities

        #region GetTagNo
        public DataTable GetTagNo(string moduleId, string category, string text)
        {
           
            DataTable ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            FlyCn.EIL.ConstructionPunchList punchObj = new EIL.ConstructionPunchList();
            UIClasses.Const Const = new UIClasses.Const();
            FlyCnDAL.Security.UserAuthendication UA;
            HttpContext context = HttpContext.Current;
            UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];
            string projectNo = UA.projectNo;
            try
            {
                dcon.GetDBConnection();
                //conn.Open();
                
                cmd = new SqlCommand("GetTagNo", dcon.SQLCon);
                cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@ModuleID", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@category", SqlDbType.NVarChar, 25).Value = category;
                cmd.Parameters.Add("@text",SqlDbType.NVarChar,50).Value = text;
                SqlParameter outKeyField = cmd.Parameters.Add("@OutKeyField", SqlDbType.NVarChar, 50);
                outKeyField.Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataTable();
                da.Fill(ds);
                KeyField = outKeyField.Value.ToString();
               
              
            }
                catch(SqlException spexe)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(spexe, page);
              
            }
            catch (Exception ex)
            {
                  var page = HttpContext.Current.CurrentHandler as Page;
                 eObj.ErrorData(ex, page);
                throw ex;
            }
                

            finally
            {
                if (dcon.SQLCon != null)
                {
                    dcon.DisconectDB();
                }

            }
            return ds;
        }

        #endregion GetTagNo

        public void GeneratePunchListExcelTemplate()
        {

            SqlConnection con = null;
            SqlDataAdapter daObj;


            DataTable dt = new DataTable();
            string errorstatus = "";
            try
            {
                errorstatus = "started";
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                string selectQuery = "GetPunchListSummary";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                daObj = new SqlDataAdapter(cmdSelect);
                daObj.Fill(dt);
              
               // Microsoft.Office.Interop.Excel.Range excelCellrange;
                errorstatus = "Creating App";
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
               Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook = null;
               Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet = null;
               ExcelWorkBook = ExcelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                errorstatus = "Created";
                int colIndex = 1;
                int rowIndex = 1;

          
               
                //var rows = ds.Tables[0].Rows;

                //for (int i = 1; i < 2; i++)
                //    ExcelWorkBook.Worksheets.Add();

                //--------------------   First Sheet------------------------------//
                ExcelWorkSheet = ExcelWorkBook.Worksheets[1];
                //foreach (DataRow row in rows)
                //{
                    ExcelWorkSheet.Columns.AutoFit();
                 foreach (DataColumn column in dt.Columns)
                 {
                     string columnName = Convert.ToString(column.ColumnName);

                     ExcelWorkSheet.Cells[rowIndex, colIndex].Value = columnName;

                     colIndex++;
                 }
                    rowIndex++;
                //
                //  for (int j = 0; j < dsTable.Tables[0].Rows.Count; j++)
                //{
                //    //string paramName = dsTable.Tables[0].Rows[j]["Field_Name"].ToString();
                //    string excelColName = dsTable.Tables[0].Rows[j]["Field_Description"].ToString();
                //
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        colIndex = 1;
                        foreach (DataColumn dc in dt.Columns)
                        {
                            ExcelWorkSheet.Cells[rowIndex, colIndex].Value = dt.Rows[j][dc.ColumnName].ToString();
                            colIndex++;
                        }
                        rowIndex++;
                    }
              
                //---------------------Second Sheet----------------------------//
                string file = "PunchlistSummary";
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

        #endregion Methods


}
