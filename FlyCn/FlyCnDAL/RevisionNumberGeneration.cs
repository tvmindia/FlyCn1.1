using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

 namespace FlyCn.FlyCnDAL
{

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
                            int user_Input = Convert.ToInt32(inputbox);
                            resultbox = Convert.ToString(++user_Input);
                            break;
                        }
                    case 2:
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
                            break;
                        }
                    case 3:
                        {

                            string input = inputbox;
                            Match m = Regex.Match(input, @"(\D*)(\d*)");

                            string alpha = m.Groups[1].Value;
                            string number = m.Groups[2].Value;

                            int n = Convert.ToInt32(number) + 1;
                            resultbox = alpha + n;
                            break;

                        }
                    case 4:
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


                            break;
                        }
                }
            #endregion Rev()

            }
        #endregion ClassRev

        }
    }
