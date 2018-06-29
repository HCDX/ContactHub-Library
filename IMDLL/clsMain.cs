using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDLL
{
    public class Mains
    {
        public abstract class Constant
        {
            public static string SUCCESS_INSERT = "Successfully added to the system.";
            public static string SUCCESS_DELETE = "Deleted with success from the system.";
            public static string SUCCESS_UPDATE = "Successfully updated.";
            public static string FAIL_CRUD = "Your operation failed. Please try later.";
            public static string GENERAL_ERR = "A prolem occured during the processing. Would you like to try again?";
            public static string NOT_EMPTY_MSG = "It is mandatory and can not be empty.";
            public static string INVALID_EMAIL = "Please enter a valid email address.";
        }

    }

    public class ClsTools
    {
        public static string Text_Validator(string text)
        {
            try
            {
                string ret = string.Empty;
                ret = text.ToString().Trim().Replace("\'", "\'\'");
                return ret;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }

}
