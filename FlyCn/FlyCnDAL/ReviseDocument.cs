using FlyCn.UIClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Messages = FlyCn.UIClasses.Messages;

namespace FlyCn.FlyCnDAL
{
    public class ReviseDocument
    {
        public string RevisionID
        {
            get;
            set;
        }

        public string RevisionNo
        {
            get;
            set;
        }
        public string DocumentNo
        {
            get;
            set;
        }

       
        public string DocumentId
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }
        public int RevisionStatus
        {
            get;
            set;
        }

        public int Flag
        {
            get;
            set;
        }
        ErrorHandling eObj = new ErrorHandling();

        #region InsertReviseDocument
        public int InsertReviseDocument()
        {

            SqlConnection con = null;
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("InsertRevisedDocument", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RevisionId", RevisionID);
                cmd.Parameters.AddWithValue("@Remarks", Remarks);
                cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                cmd.Parameters.AddWithValue("@RevisionStatus", RevisionStatus);
                cmd.Parameters.AddWithValue("@RevisionNo", RevisionNo);
              
                cmd.Parameters.AddWithValue("@DocumentId",DocumentId );
               
                cmd.ExecuteScalar();
                var page = HttpContext.Current.CurrentHandler as Page;

                eObj.InsertionSuccessData(page, Messages.documentrevisesuccessMessage);
                Flag = 1;
                return 1;
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                var master = page.Master;
                eObj.ErrorData(ex, page);
                return 0;
            }
            finally
            {
                con.Close();

            }
        }

        #endregion InsertReviseDocument

        public List<KeyValuePair<String, int>> GetRevisionStatus()
        {
            ApprovelMaster amObj = new ApprovelMaster();
            DataTable dtStatus = new DataTable();
            dtStatus = amObj.GetAllDocumentStatus();
            List<KeyValuePair<String, int>> Docstatus = new List<KeyValuePair<string, int>>();
            
            for (int f = 0; f < dtStatus.Rows.Count; f++)
            {
               

                
                    Docstatus.Add(new KeyValuePair<string, int>(dtStatus.Rows[f]["StatusDescription"].ToString(), Convert.ToInt16(dtStatus.Rows[f]["ApprovalStatus"])));
                }
               
            
return Docstatus;
        }
        public DataTable GetDocumentIdByNo()
        {

            SqlConnection con = null;
            DataTable dt = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("GetDocumentIdByNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DocumentNo", DocumentNo);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }

    }
        public static class RevisionNumberGeneration
        {
            #region IsNumeric()
            public static bool IsNumeric(this string s)
            {
                foreach (char c in s)
                {
                    if (!char.IsDigit(c) && c != '.')
                    {
                        return false;
                    }
                }

                return true;
            }
            #endregion IsNumeric()

            #region IsAllAlphabetic()
            public static bool IsAllAlphabetic(string value)
            {
                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                        return false;
                }

                return true;
            }
            #endregion IsAllAlphabetic()

            #region isAlphaNumeric()
            public static bool isAlphaNumeric(string strToCheck)
            {
                Regex rg = new Regex(@"^[a-zA-Z0-9\s,]*$");
                if (rg.IsMatch(strToCheck) && Regex.IsMatch(strToCheck, "^[A-Za-z]"))
                {
                    return true;
                }
                return false;
            }
        }
            #endregion isAlphaNumeric()

        #region ClassRev
        public class ClassRev
        {
            #region Public String
            public string inputbox, resultbox;
            #endregion Public String

            #region Rev()
            public void Rev()
            {
                int choice = 0;

                if (RevisionNumberGeneration.IsNumeric(inputbox) == true)
                {
                    choice = 1;
                }
                else if (RevisionNumberGeneration.IsAllAlphabetic(inputbox) == true)
                {
                    choice = 2;
                }
                else if (RevisionNumberGeneration.isAlphaNumeric(inputbox) == true)
                {
                    choice = 3;
                }

                else
                {
                    choice = 4;
                }


                switch (choice)
                {
                    case 1:
                        {
                            try
                            {
                                int user_Input = Convert.ToInt32(inputbox);
                                resultbox = Convert.ToString(++user_Input);

                            }
                            catch (Exception ex)
                            {
                                resultbox = inputbox + "x001";
                            }
                            break;
                        }
                    case 2:
                        {
                            try
                            {
                                string input = inputbox;
                                Match m = Regex.Match(input, @"(\D*)(\D*)");

                                string number = m.Groups[1].Value;
                                char cLastCharacter = number[number.Length - 1];
                                string alpha = Convert.ToString(cLastCharacter);

                                char i = Convert.ToChar(alpha);
                                int ascii = Convert.ToInt32(i) + 1;
                                char ch = Convert.ToChar(ascii);
                                if (number.Length > 1)
                                {
                                    resultbox = number.Substring(0, number.Length - 1) + ch;
                                }
                                else
                                {

                                    resultbox = Convert.ToString(ch);
                                }
                                if ((cLastCharacter == 'z') || (cLastCharacter == 'Z'))
                                {
                                    resultbox = number.Substring(0, number.Length - 1) + "a1";
                                }
                            }
                            catch (Exception ex)
                            {
                                resultbox = inputbox + "$123";
                            }
                            break;
                        }
                    case 3:
                        {
                            try
                            {
                                string input = inputbox;
                                Match m = Regex.Match(input, @"(\D*)(\d*)");

                                string alpha = m.Groups[1].Value;
                                string number = m.Groups[2].Value;

                                int n = Convert.ToInt32(number) + 1;
                                resultbox = alpha + n;
                            }
                            catch (Exception ex)
                            {
                                resultbox = inputbox + "abc1";
                            }
                            break;

                        }
                    case 4:
                        {
                            try
                            {
                                string input = inputbox;

                                Match m = Regex.Match(input, @"(\d*)(\D*)");

                                string number = m.Groups[1].Value;
                                string alpha = m.Groups[2].Value;

                                char cLastCharacter = input[input.Length - 1];
                                char i = Convert.ToChar(cLastCharacter);
                                int ascii = Convert.ToInt32(i) + 1;
                                char ch = Convert.ToChar(ascii);

                                if (input.Length > 1)
                                {
                                    resultbox = input.Substring(0, input.Length - 1) + ch;
                                }
                                if (cLastCharacter == 'z')
                                {
                                    resultbox = input.Substring(0, input.Length - 1) + "a1";
                                }
                            }
                            catch (Exception ex)
                            {
                                resultbox = inputbox + "f543";
                            }

                            break;
                        }
                }
            #endregion Rev()

            }
        #endregion ClassRev

        }
    

}