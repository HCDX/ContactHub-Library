using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IMDLL
{
    public class Interest
    {
        public int InterestID;
        public int InterestSector;
        public int InterestArea;
        public int InterestSubscriber;
        public Boolean InterestStatus;
        public string InterestCode;
        public int LastModifiedBy;
        public DateTime LastModifiedDate;

        public int SaveInterest(Interest newInterest, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[8];

                param[0] = new SqlParameter("@InterestID", newInterest.InterestID);
                param[1] = new SqlParameter("@InterestSector", newInterest.InterestSector);
                param[2] = new SqlParameter("@InterestArea", newInterest.InterestArea);
                param[3] = new SqlParameter("@InterestSubscriber", newInterest.InterestSubscriber);
                param[4] = new SqlParameter("@InterestStatus", newInterest.InterestStatus);
                param[5] = new SqlParameter("@LastModifiedBy", newInterest.LastModifiedBy);
                param[6] = new SqlParameter("@LastModifiedDate", newInterest.LastModifiedDate);
                param[7] = new SqlParameter("@InterestCode", newInterest.InterestCode);

                savingReport = " Data Has been Saved.";

                clsSqlHelper.executeNonQuery_SP("sp_addInterest", param);
                return int.Parse(clsSqlHelper.ExecuteScalar(" select Max(InterestID) as InterestID from Interest ").ToString());

            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public int UpdateInterest(Interest newInterest, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[8];

                param[0] = new SqlParameter("@InterestID", newInterest.InterestID);
                param[1] = new SqlParameter("@InterestSector", newInterest.InterestSector);
                param[2] = new SqlParameter("@InterestArea", newInterest.InterestArea);
                param[3] = new SqlParameter("@InterestSubscriber", newInterest.InterestSubscriber);
                param[4] = new SqlParameter("@InterestStatus", newInterest.InterestStatus);
                param[5] = new SqlParameter("@LastModifiedBy", newInterest.LastModifiedBy);
                param[6] = new SqlParameter("@LastModifiedDate", newInterest.LastModifiedDate);
                param[7] = new SqlParameter("@InterestCode", newInterest.InterestCode);

                savingReport = " Data Has been Saved.";

                clsSqlHelper.executeNonQuery_SP("sp_updateInterest", param);
                return int.Parse(clsSqlHelper.ExecuteScalar(" select Max(InterestID) as ModuleID from Interest ").ToString());
            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }


        public int CustomUpdateInterest(string strwhere)
        {
            string sql = "UPDATE Interest SET" + strwhere;
            return clsSqlHelper.ExecuteNonQuery(sql);

        }


        public DataTable GetInterest(string strwhere)
        {
            string sql = "Select * from GetInterest " + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }

        public DataTable GetActiveStatus(string strwhere)
        {
            string sql = "SELECT* FROM ActiveStatus" + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }


        public virtual bool DeleteInterest(string InterestID)
        {
            try
            {
                string sql = " Delete from Interest where InterestID =" + InterestID;
                clsSqlHelper.ExecuteNonQuery(sql).ToString();
                return true;
            }

            catch (Exception ex)
            {


                return false;

            }

        }

        public virtual bool RemoveInterest(string InterestID)
        {
            try
            {
                string sql = " delete from Interest where InterestID= " + InterestID;
                clsSqlHelper.ExecuteNonQuery(sql).ToString();
                return true;
            }

            catch (Exception ex)
            {


                return false;

            }

        }

        public virtual bool DeleteMultipleInterest(string InterestIDs)
        {
            try
            {
                string sql = " Delete from Interest where InterestID IN (" + InterestIDs + ")";
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
