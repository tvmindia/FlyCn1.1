using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyCn.FlyCnDAL
{
    public class Security
    {
        public class PageSecurity
        {
            private bool isRead;
            private bool isWrite;
            private bool isDelete;
            private string isExecute;

            Boolean Read {
                get {
                    return isRead;
                }
                 
            }
            Boolean Write
            {
                get
                {
                    return isWrite;
                }
                  
            }
            Boolean Delete
            {
                get
                {
                    return isDelete;
                }
                
            }
            string Execute
            {
                get
                {
                    return isExecute;
                }
                  
            }
            Boolean ReadOnly
            {
                get
                {                  

                    if(Read && (!Delete && !Write)){
                    ReadOnly=true;
                    }

                    return ReadOnly;
                }
                  set {
                    ReadOnly = value;
                }
            }

            public  PageSecurity(string pageName, string userName) { 
            

                //will be changed to db date based n page soon
                if(userName=="User3"){
                   isRead = true;
                    isWrite = false;
                    isDelete=false;
                    isExecute = "";
                }
                else{

                    isRead = true;
                    isWrite = true;
                    isDelete = true;
                    isExecute = "X";
                }

            }

        }
        public class UserAuthendication {
          
            public UserAuthendication(String userName,String password){

                if (userName==password){
                    isValidUser = true;
                    userN = userName;
                    project = "C00001";
                }
                else
                {

                    isValidUser = false;
                }
                }

            private Boolean isValidUser;
            private string userN;
            private string project;

               public Boolean ValidUser
                {
                    get
                    {

                        return isValidUser;
                    }
                      
                }
               public string userName {

                   get {
                       return userN;
                   }
               }
               public string projectNo
               {

                   get
                   {
                       return project;
                   }
               }
            
            }
        }
    }
 