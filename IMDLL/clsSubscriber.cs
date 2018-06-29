using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IMDLL
{
    public class Subscriber
    {
        public int SubscriberID;
        public string SubscriberFullName;
        public string SubscriberEmail;
        public string SubscriberTitle;
        public string SubscriberOrganization;
        public string SubscriberContact;
        public string SubscriberAddress;
        public int SubscriberInterest;
        public string LastModifiedBy;
        public DateTime LastModifiedDate;
        public string SubscriberCode;
        public DateTime SubscriberAddedDate;

        public int SaveSubscriber(Subscriber newSubscriber, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@SubscriberID", newSubscriber.SubscriberID);
                param[1] = new SqlParameter("@SubscriberFullName", newSubscriber.SubscriberFullName);
                param[2] = new SqlParameter("@SubscriberEmail", newSubscriber.SubscriberEmail);
                param[3] = new SqlParameter("@SubscriberTitle", newSubscriber.SubscriberTitle);
                param[4] = new SqlParameter("@SubscriberOrganization", newSubscriber.SubscriberOrganization);
                param[5] = new SqlParameter("@SubscriberContact", newSubscriber.SubscriberContact);
                param[6] = new SqlParameter("@LastModifiedBy", newSubscriber.LastModifiedBy);
                param[7] = new SqlParameter("@LastModifiedDate", newSubscriber.LastModifiedDate);
                param[8] = new SqlParameter("@SubscriberCode", newSubscriber.SubscriberCode);
                param[9] = new SqlParameter("@SubscriberAddedDate", newSubscriber.SubscriberAddedDate);
                

                savingReport = " Data Has been Saved.";

                clsSqlHelper.executeNonQuery_SP("sp_addSubscribers", param);
                return int.Parse(clsSqlHelper.ExecuteScalar(" select Max(SubscriberID) as SubscriberID from Subscriber ").ToString());
            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public int UpdateSubscriber(Subscriber newSubscriber, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[9];

                param[0] = new SqlParameter("@SubscriberID", newSubscriber.SubscriberID);
                param[1] = new SqlParameter("@SubscriberFullName", newSubscriber.SubscriberFullName);
                param[2] = new SqlParameter("@SubscriberEmail", newSubscriber.SubscriberEmail);
                param[3] = new SqlParameter("@SubscriberTitle", newSubscriber.SubscriberTitle);
                param[4] = new SqlParameter("@SubscriberOrganization", newSubscriber.SubscriberOrganization);
                param[5] = new SqlParameter("@SubscriberContact", newSubscriber.SubscriberContact);
                param[6] = new SqlParameter("@LastModifiedBy", newSubscriber.LastModifiedBy);
                param[7] = new SqlParameter("@LastModifiedDate", newSubscriber.LastModifiedDate);
                param[8] = new SqlParameter("@SubscriberCode", newSubscriber.SubscriberCode);

                savingReport = " Data Has been Saved.";

                return clsSqlHelper.executeNonQuery_SP("sp_updateSubscriber", param);

            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public int UpdateSubscriberConfirm(Subscriber newSubscriber, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[8];

                param[0] = new SqlParameter("@SubscriberID", newSubscriber.SubscriberID);
                param[1] = new SqlParameter("@SubscriberFullName", newSubscriber.SubscriberFullName);
                param[2] = new SqlParameter("@SubscriberEmail", newSubscriber.SubscriberEmail);
                param[3] = new SqlParameter("@SubscriberTitle", newSubscriber.SubscriberTitle);
                param[4] = new SqlParameter("@SubscriberOrganization", newSubscriber.SubscriberOrganization);
                param[5] = new SqlParameter("@SubscriberContact", newSubscriber.SubscriberContact);
                param[6] = new SqlParameter("@LastModifiedBy", newSubscriber.LastModifiedBy);
                param[7] = new SqlParameter("@LastModifiedDate", newSubscriber.LastModifiedDate);

                savingReport = " Data Has been Saved.";

                return clsSqlHelper.executeNonQuery_SP("sp_updateSubscriberconfirm", param);

            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public int FocalPointUpdateSubscriber(Subscriber newSubscriber, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[8];

                param[0] = new SqlParameter("@SubscriberID", newSubscriber.SubscriberID);
                param[1] = new SqlParameter("@SubscriberFullName", newSubscriber.SubscriberFullName);
                param[2] = new SqlParameter("@SubscriberEmail", newSubscriber.SubscriberEmail);
                param[3] = new SqlParameter("@SubscriberTitle", newSubscriber.SubscriberTitle);
                param[4] = new SqlParameter("@SubscriberOrganization", newSubscriber.SubscriberOrganization);
                param[5] = new SqlParameter("@SubscriberContact", newSubscriber.SubscriberContact);
                param[6] = new SqlParameter("@LastModifiedBy", newSubscriber.LastModifiedBy);
                param[7] = new SqlParameter("@LastModifiedDate", newSubscriber.LastModifiedDate);

                savingReport = " Data Has been Saved.";

                return clsSqlHelper.executeNonQuery_SP("sp_focalpointupdateSubscriber", param);

            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public DataTable GetSubscriber(string strwhere)
        {
            string sql = "Select * from GetSubscriber " + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }

        public DataTable GetSubscriberRaw(string strwhere)
        {
            string sql = "Select * from Subscriber " + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }
        public DataTable ExportSubscriber(string strwhere)
        {
            string sql = "Select SubscriberFullName as 'Full Name',SubscriberEmail as 'Email', SubscriberTitle as 'Title',SubscriberOrganization as 'Organization',"
                + " SubscriberContact as 'Phone Contact', SectorInterestName as 'Sector of Interest',AreaInterestName as 'Area of Interest'"
                + "from GetSubscriber  " + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }

        public virtual bool DeleteSubscriber(string SubscriberID)
        {
            try
            {
                string sql = " Delete from Subscriber where SubscriberID =" + SubscriberID;
                clsSqlHelper.ExecuteNonQuery(sql).ToString();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }

        }

        public int CustomUpdateSubscriber(string strwhere)
        {
            string sql = "UPDATE Subscriber SET " + strwhere;
            return clsSqlHelper.ExecuteNonQuery(sql);

        }
    }
}
