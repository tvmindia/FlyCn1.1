﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyCn.UIClasses
{
    public class Const
    {
     //   public string LoginSession = "LoginDetails";
        public string LoginSession {
            get {
                return "LoginDetails";
            }
        }


        public string HomePage
        {
            get
            {
                return "Home.aspx";
            }
        }

        public string HomePageURL
        {
            get
            {
                return "~/Home.aspx";
            }
        }
    }
}