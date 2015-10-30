using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyCn.FlyCnDAL
{
    #region DocumentStatusSettings class
    public class DocumentStatusSettings
    {
       #region DocumentStatusSettings
         

            public Int16 Draft
            {
                get { return 0; }

            }
            public Int16 Closed
            {
                get { return 1; }

            }
            public Int16 Declined
            {
                get { return 2; }

            }
            public Int16 Rejected_For_Amendment
            {
                get { return 3; }

            }

            public Int16 Approved
            {
                get { return 4; }

            }

        
            #endregion DocumentStatusSettings

    }
    #endregion DocumentStatusSettings class
}