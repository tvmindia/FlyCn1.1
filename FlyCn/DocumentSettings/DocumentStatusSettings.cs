using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyCn.DocumentSettings
{
    #region DocumentStatusSettings class
    public static class  DocumentStatusSettings
    {
       #region DocumentStatusSettings


        public static string Draft
            {
                get { return "0"; }

            }
        public static string Closed
            {
                get { return "1"; }

            }
        public static string Declined
            {
                get { return "2"; }

            }
            public  static string Rejected_For_Amendment
            {
                get { return "3"; }

            }

            public  static string Approved
            {
                get { return "4"; }

            }

        
            #endregion DocumentStatusSettings

    }
    #endregion DocumentStatusSettings class
}