using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StickyNotes1
{
    public class StickyNoteHelper
    {
        public static bool CheckDuplicateUser(string username)
        {
            string query = "select * from tblUser where username='" + username + "'";
            DBConnection db = new DBConnection();
            DataTable dtUser = db.GetData(query);
            if (dtUser.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public static bool CheckPasswordLength(string password)
        {
            if (password.Length > 5)
                return true;
            else
                return false;
         
        }
        public static bool CheckEmail(string email)
        {
            if (email.Contains("@")|| email.Contains("."))
                return true;
            else
                return false;
        }
        public static bool CompareTwoPassword(string password,string ConformPassword)
        {
            if (password == ConformPassword)
                return true;
            else
                return false;
                    
        }
    }
}
