using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IMDLL
{
    public class AreaInterest
    {
        public int AreaInterestID;
        public string AreaInterestName;
        public string AreaInterestDescription;
        public int LastModifiedBy;
        public DateTime LastModifiedDate;

        public int SaveAreaInterest(AreaInterest newAreaInterest, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@AreaInterestID", newAreaInterest.AreaInterestID);
                param[1] = new SqlParameter("@AreaInterestName", newAreaInterest.AreaInterestName);
                param[2] = new SqlParameter("@AreaInterestDescription", newAreaInterest.AreaInterestDescription);
                param[3] = new SqlParameter("@LastModifiedBy", newAreaInterest.LastModifiedBy);
                param[4] = new SqlParameter("@LastModifiedDate", newAreaInterest.LastModifiedDate);

                savingReport = " Data Has been Saved.";

                return clsSqlHelper.executeNonQuery_SP("sp_addAreaInterest", param);

            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public int UpdateAreaInterest(AreaInterest newAreaInterest, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@AreaInterestID", newAreaInterest.AreaInterestID);
                param[1] = new SqlParameter("@AreaInterestName", newAreaInterest.AreaInterestName);
                param[2] = new SqlParameter("@AreaInterestDescription", newAreaInterest.AreaInterestDescription);
                param[3] = new SqlParameter("@LastModifiedBy", newAreaInterest.LastModifiedBy);
                param[4] = new SqlParameter("@LastModifiedDate", newAreaInterest.LastModifiedDate);

                savingReport = " Data Has been Saved.";

                return clsSqlHelper.executeNonQuery_SP("sp_updateAreaInterest", param);

            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public DataTable GetAreaInterest(string strwhere)
        {
            string sql = "Select * from GetAreaInterest " + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }

        public virtual bool DeleteAreaInterest(string AreaInterestID)
        {
            try
            {
                string sql = " Delete from AreaInterest where AreaInterestID =" + AreaInterestID;
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
