using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IMDLL
{
    public class Profile
    {
        public int ProfileID;
        public string ProfileName;
        public string ProfileDescription;
        public int LastModifiedBy;
        public DateTime LastModifiedDate;
        public int SaveProfile(Profile newProfile, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@ProfileID", newProfile.ProfileID);
                param[1] = new SqlParameter("@ProfileName", newProfile.ProfileName);
                param[2] = new SqlParameter("@ProfileDescription", newProfile.ProfileDescription);
                param[3] = new SqlParameter("@LastModifiedBy", newProfile.LastModifiedBy);
                param[4] = new SqlParameter("@LastModifiedDate", newProfile.LastModifiedDate);

                savingReport = " Data Has been Saved.";

                return clsSqlHelper.executeNonQuery_SP("sp_addProfile", param);

            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public int UpdateProfile(Profile newProfile, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@ProfileID", newProfile.ProfileID);
                param[1] = new SqlParameter("@ProfileName", newProfile.ProfileName);
                param[2] = new SqlParameter("@ProfileDescription", newProfile.ProfileDescription);
                param[3] = new SqlParameter("@LastModifiedBy", newProfile.LastModifiedBy);
                param[4] = new SqlParameter("@LastModifiedDate", newProfile.LastModifiedDate);

                savingReport = " Data Has been Saved.";

                return clsSqlHelper.executeNonQuery_SP("sp_updateProfile", param);

            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public DataTable GetProfile(string strwhere)
        {
            string sql = "Select * from GetProfile " + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }

      
        public virtual bool DeleteProfile(string ProfileID)
        {
            try
            {
                string sql = " Delete from Profile where ProfileID =" + ProfileID;
                clsSqlHelper.ExecuteNonQuery(sql).ToString();
                return true;
            }

            catch (Exception ex)
            {


                return false;

            }

        }
    }
}
