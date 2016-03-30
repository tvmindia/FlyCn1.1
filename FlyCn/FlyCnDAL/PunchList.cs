#region Namespaces
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;
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
        #endregion fileSize

        #region KeyField
        public string KeyField
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
        public DataTable GetPunchList()
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
                if (mObj.OpenBy != null)
                {
                    cmdInsert.Parameters.Add("@openby", SqlDbType.NVarChar, 15).Value = mObj.OpenBy;
                }
                else
                {
                    cmdInsert.Parameters.Add("@openby", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                }
                if (OpenDate != null)
                {
                    cmdInsert.Parameters.Add("@opendate",SqlDbType.DateTime).Value= Convert.ToDateTime(OpenDate);
                }
                else
                {
                    cmdInsert.Parameters.Add("@opendate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (mObj.EnteredBy != null)
                {
                    cmdInsert.Parameters.Add("@enteredby", SqlDbType.NVarChar, 15).Value = mObj.EnteredBy;
                }
                else
                {
                    cmdInsert.Parameters.Add("@enteredby", SqlDbType.NVarChar, 15).Value = DBNull.Value;
                }
                if (EnteredDt != null)
                {
                    cmdInsert.Parameters.Add("@entereddate",SqlDbType.DateTime).Value= Convert.ToDateTime(EnteredDt);
                }
                else
                {
                    cmdInsert.Parameters.Add("@entereddate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                cmdInsert.Parameters.AddWithValue("@plant", Plant);
                if (Area != null)
                {
                    cmdInsert.Parameters.Add("@area", SqlDbType.NVarChar,10).Value=Area;
                }
                else
                {
                    cmdInsert.Parameters.Add("@area", SqlDbType.NVarChar, 10).Value = DBNull.Value;
                }
                cmdInsert.Parameters.AddWithValue("@location", Location);
                cmdInsert.Parameters.AddWithValue("@unit", Unit);
                cmdInsert.Parameters.AddWithValue("@drawing", Drawing);
                cmdInsert.Parameters.AddWithValue("@sheet", Sheet);
                cmdInsert.Parameters.AddWithValue("@revision", Revison);
                cmdInsert.Parameters.AddWithValue("@itemdescription", ItemDescription);
                cmdInsert.Parameters.AddWithValue("@rfino", RFINo);
                if (RFIDate != null)
                {
                    cmdInsert.Parameters.AddWithValue("@rfidate",SqlDbType.DateTime ).Value=Convert.ToDateTime(RFIDate);
                }
                else
                {
                    cmdInsert.Parameters.AddWithValue("@rfidate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                cmdInsert.Parameters.AddWithValue("@inspector", mObj.Inspector);
                cmdInsert.Parameters.AddWithValue("@requestedby", mObj.RequestedBy);
                cmdInsert.Parameters.AddWithValue("@actionby", ActionBy);
                cmdInsert.Parameters.AddWithValue("@displine", Discipline);
                if (Category != null)
                {
                    cmdInsert.Parameters.AddWithValue("@category", Category);
                }
                cmdInsert.Parameters.AddWithValue("@queryrevision", QueryRevision);
                if (ScheduledDateCompletion != null)
                {
                    cmdInsert.Parameters.AddWithValue("@scheduleddatecompletion",SqlDbType.DateTime ).Value=Convert.ToDateTime(ScheduledDateCompletion);
                }
                else
                {
                    cmdInsert.Parameters.AddWithValue("@scheduleddatecompletion", SqlDbType.DateTime).Value = DBNull.Value;

                }
                cmdInsert.Parameters.AddWithValue("@coveredbyproject", CoveredByProject);
                cmdInsert.Parameters.AddWithValue("@system", System);
                cmdInsert.Parameters.AddWithValue("@subsystem", Subsystem);
                cmdInsert.Parameters.AddWithValue("@controlsystem", ControlSystem);
                cmdInsert.Parameters.AddWithValue("@failcategory", FailCategory);
                cmdInsert.Parameters.AddWithValue("@changereq", ChangeReq);
                cmdInsert.Parameters.AddWithValue("@reference", Reference);
                if (ReferenceDate != null)
                {
                    cmdInsert.Parameters.Add("@referencedate", SqlDbType.DateTime).Value=Convert.ToDateTime(ReferenceDate);
                }
                else
                {
                    cmdInsert.Parameters.Add("@referencedate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                cmdInsert.Parameters.AddWithValue("@responsibleperson", mObj.ResponsiblePerson);
                cmdInsert.Parameters.AddWithValue("@organization", Organization);
                if (CompletionDate != null)
                {
                    cmdInsert.Parameters.Add("@completiondate",SqlDbType.DateTime ).Value=Convert.ToDateTime(CompletionDate);
                }
                else
                {
                    cmdInsert.Parameters.Add("@completiondate", SqlDbType.DateTime).Value = DBNull.Value;
                }
                cmdInsert.Parameters.AddWithValue("@completionremarks", CompletionRemarks);
                cmdInsert.Parameters.AddWithValue("@signedby", mObj.SignedBy);
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
        #endregion AddtoPunchList

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
        public DataTable GetTagNo(string projectNo, string moduleId, string category)
        {
           
            DataTable ds = null;
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            dbConnection dcon = new dbConnection();
            try
            {
                dcon.GetDBConnection();
                //conn.Open();

                cmd = new SqlCommand("GetTagNo", dcon.SQLCon);
                cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@ModuleID", SqlDbType.NVarChar, 10).Value = moduleId;
                cmd.Parameters.Add("@category", SqlDbType.NVarChar, 25).Value = category;
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

    }

        #endregion Methods
}
