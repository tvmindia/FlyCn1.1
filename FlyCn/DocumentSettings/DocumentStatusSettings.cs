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


        #region ExcelSheetNames

        public static string FileDescriptionSheetName
        {
            get { return "Field Description"; }
        }
        public static string CIV
        {
            get { return "Civil"; }//returns module description of tables from modules
        }

        public static string ELE
        {
            get { return "Electrical"; }
        }
        public static string CAD
        {
            get { return "Cable and Drum";}
        }

        public static string CTL
        {
            get { return "Control Systems"; }
        }

        public static string INS
        {
            get { return "Instrumentation"; }
        }

        public static string MEC
        {
            get { return "Mechanical"; }
        }

        public static string PIP
        {
            get { return "Piping"; }
        }

        public static string TEL
        {
            get { return "Telecommunication"; }
        }
        #endregion ExcelSheetNames

        #region ImportStatus
        public static string One
        {
            get { return "Started"; }
        }

        public static string Two
        {
            get { return "Processing"; }
        }

        public static string Three
        {
            get { return "Finished"; }
        }
        #endregion ImportStatus

        #region CableDrumValidation
        public static string CADTL//cable and drum total length
        {
            get { return "Cable Already Pulled"; }

        }
        public static string DNV
        {
            get { return "Drum no invalid"; }
        }

        public static string ALV
        {
            get{return "Allocated length is small";}
        }

        public static string ULV
        {
            get { return "Used Drum Can Not Change";}
        }
        #endregion CableDrumValidation

      


    }
    #endregion DocumentStatusSettings class


   
}