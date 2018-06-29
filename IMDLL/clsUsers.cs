using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IMDLL
{
    public class Users
    {
        public int UserID;
        public string UserFullName;
        public string UserOrganization;
        public string UserTitle;
        public string Username;
        public string UserMail;
        public string UserPhone;
        public string UserAddress;
        public int UserProfile;
        public Boolean UserActif;
        public string UserPassword;
        public string UserNote;
        public int LastModifiedBy;
        public DateTime LastModifiedDate;

        public int SaveUsers(Users newUsers, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[14];

                param[0] = new SqlParameter("@UserID", newUsers.UserID);
                param[1] = new SqlParameter("@UserFullName", newUsers.UserFullName);
                param[2] = new SqlParameter("@UserOrganization", newUsers.UserOrganization);
                param[3] = new SqlParameter("@UserTitle", newUsers.UserTitle);
                param[4] = new SqlParameter("@Username", newUsers.Username);
                param[5] = new SqlParameter("@UserMail", newUsers.UserMail);
                param[6] = new SqlParameter("@UserPhone", newUsers.UserPhone);
                param[7] = new SqlParameter("@UserAddress", newUsers.UserAddress);
                param[8] = new SqlParameter("@UserActif", newUsers.UserActif);
                param[9] = new SqlParameter("@UserProfile", newUsers.UserProfile);
                param[10] = new SqlParameter("@UserPassword", newUsers.UserPassword);
                param[11] = new SqlParameter("@UserNote", newUsers.UserNote);
                param[12] = new SqlParameter("@LastModifiedBy", newUsers.LastModifiedBy);
                param[13] = new SqlParameter("@LastModifiedDate", newUsers.LastModifiedDate);

                savingReport = " Data Has been Saved.";

                clsSqlHelper.executeNonQuery_SP("sp_addUsers", param);
                return int.Parse(clsSqlHelper.ExecuteScalar(" select Max(UserID) as UserID from Users ").ToString());
            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public DataTable GetUsers(string strwhere)
        {
            string sql = "Select * from GetUsers " + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }

        public DataTable GetUserProfile(string strwhere)
        {
            string sql = "Select * from GetUserProfile " + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }

        public DataTable GetActiveStatus(string strwhere)
        {
            string sql = "select * from GetActiveStatus " + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }



        public int CustomUpdateUsers(string strwhere)
        {
            string sql = "update Users set" + strwhere;
            return clsSqlHelper.ExecuteNonQuery(sql);

        }


        public virtual bool DeleteUsers(string UserID)
        {
            try
            {
                string sql = " Delete from Users where UserID =" + UserID;
                clsSqlHelper.ExecuteNonQuery(sql).ToString();
                return true;
            }

            catch (Exception ex)
            {


                return false;

            }

        }


        public int AdminUpdateUsers(Users newUsers, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];

                param[0] = new SqlParameter("@UserID", newUsers.UserID);
                param[1] = new SqlParameter("@UserActif", newUsers.UserActif);
                param[2] = new SqlParameter("@UserProfile", newUsers.UserProfile);
                param[3] = new SqlParameter("@LastModifiedBy", newUsers.LastModifiedBy);
                param[4] = new SqlParameter("@LastModifiedDate", newUsers.LastModifiedDate);
                param[5] = new SqlParameter("@UserAddress", newUsers.UserAddress);

                savingReport = " Data Has been Saved.";

                return clsSqlHelper.executeNonQuery_SP("sp_AdminupdateUsers", param);
            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public int UserUpdateUsers(Users newUsers, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@UserID", newUsers.UserID);
                param[1] = new SqlParameter("@UserFullName", newUsers.UserFullName);
                param[2] = new SqlParameter("@UserOrganization", newUsers.UserOrganization);
                param[3] = new SqlParameter("@UserTitle", newUsers.UserTitle);
                param[4] = new SqlParameter("@UserMail", newUsers.UserMail);
                param[5] = new SqlParameter("@UserPhone", newUsers.UserPhone);
                param[6] = new SqlParameter("@UserAddress", newUsers.UserAddress);
                param[7] = new SqlParameter("@UserNote", newUsers.UserNote);
                param[8] = new SqlParameter("@LastModifiedBy", newUsers.LastModifiedBy);
                param[9] = new SqlParameter("@LastModifiedDate", newUsers.LastModifiedDate);

                savingReport = " Data Has been Saved.";

                return clsSqlHelper.executeNonQuery_SP("sp_UserupdateUsers", param);

            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }
    }
}
