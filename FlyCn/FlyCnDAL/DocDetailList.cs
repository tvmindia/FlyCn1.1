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
        public DataTable GetDocDetailList(string projectnum,string revid)
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

                string SelectQuery = "";
                SqlCommand cmdSelect = new SqlCommand(SelectQuery, con);
                cmdSelect.CommandType = CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("@projectno", UA.projectNo);
                cmdSelect.Parameters.Add("@RevisionID", SqlDbType.UniqueIdentifier).Value = revid;
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