using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace FlyCn.FlyCnDAL
{
    public class DocDetailList
    {
        ErrorHandling eObj = new ErrorHandling();
        public DataTable GetDocDetailList(string revid,string type)
        {
            SqlConnection con = null;
            DataTable dt =new DataTable();
            SqlDataAdapter da = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                UIClasses.Const Const = new UIClasses.Const();
                FlyCnDAL.Security.UserAuthendication UA;

                HttpContext context = HttpContext.Current;
                UA = (FlyCnDAL.Security.UserAuthendication)context.Session[Const.LoginSession];

                string SelectQuery = "GetDocDetailsByProjectNoDocumentTypeRevisionId";
                SqlCommand cmdSelect = new SqlCommand(SelectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@projectno","C00001");
                cmdSelect.Parameters.AddWithValue("@RevisionID", revid);
                cmdSelect.Parameters.AddWithValue("@type", type);
                da = new SqlDataAdapter(cmdSelect);
                da.Fill(dt);

              
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return dt;
        }
    }
}