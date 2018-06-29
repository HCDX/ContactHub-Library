using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IMDLL
{
    public class SectorInterest
    {
        public int SectorInterestID;
        public string SectorInterestName;
        public string SectorInterestDescription;
        public int LastModifiedBy;
        public DateTime LastModifiedDate;

        public int SaveSectorInterest(SectorInterest newSectorInterest, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@SectorInterestID", newSectorInterest.SectorInterestID);
                param[1] = new SqlParameter("@SectorInterestName", newSectorInterest.SectorInterestName);
                param[2] = new SqlParameter("@SectorInterestDescription", newSectorInterest.SectorInterestDescription);
                param[3] = new SqlParameter("@LastModifiedBy", newSectorInterest.LastModifiedBy);
                param[4] = new SqlParameter("@LastModifiedDate", newSectorInterest.LastModifiedDate);

                savingReport = " Data Has been Saved.";

                clsSqlHelper.executeNonQuery_SP("sp_addSectorInterest", param);
                return int.Parse(clsSqlHelper.ExecuteScalar(" select Max(SectorInterestID) as SectorInterestID from SectorInterest ").ToString());
            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public int UpdateSectorInterest(SectorInterest newSectorInterest, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@SectorInterestID", newSectorInterest.SectorInterestID);
                param[1] = new SqlParameter("@SectorInterestName", newSectorInterest.SectorInterestName);
                param[2] = new SqlParameter("@SectorInterestDescription", newSectorInterest.SectorInterestDescription);
                param[3] = new SqlParameter("@LastModifiedBy", newSectorInterest.LastModifiedBy);
                param[4] = new SqlParameter("@LastModifiedDate", newSectorInterest.LastModifiedDate);

                savingReport = " Data Has been Saved.";

                clsSqlHelper.executeNonQuery_SP("sp_updateSectorInterest", param);
                return int.Parse(clsSqlHelper.ExecuteScalar(" select Max(SectorInterestID) as SectorInterestID from SectorInterest ").ToString());
            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public DataTable GetSectorInterest(string strwhere)
        {
            string sql = "Select * from GetSectorInterest " + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }


        public virtual bool DeleteSectorInterest(string SectorInterestID)
        {
            try
            {
                string sql = " Delete from SectorInterest where SectorInterestID =" + SectorInterestID;
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
