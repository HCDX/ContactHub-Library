using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IMDLL
{
    public class FocalPoints
    {
        public int FocalPointsID;
        public int FocalPointsUser;
        public int FocalPointsSector;
        public int FocalPointsArea;
        public int LastModifiedBy;
        public DateTime LastModifiedDate;
        public Boolean FocalPointsNotification;

        public int SaveFocalPoints(FocalPoints newFocalPoints, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[7];

                param[0] = new SqlParameter("@FocalPointsID", newFocalPoints.FocalPointsID);
                param[1] = new SqlParameter("@FocalPointsUser", newFocalPoints.FocalPointsUser);
                param[2] = new SqlParameter("@FocalPointsSector", newFocalPoints.FocalPointsSector);
                param[3] = new SqlParameter("@FocalPointsArea", newFocalPoints.FocalPointsArea);
                param[4] = new SqlParameter("@LastModifiedBy", newFocalPoints.LastModifiedBy);
                param[5] = new SqlParameter("@LastModifiedDate", newFocalPoints.LastModifiedDate);
                param[6] = new SqlParameter("@FocalPointsNotification", newFocalPoints.FocalPointsNotification);

                savingReport = " Data Has been Saved.";

                clsSqlHelper.executeNonQuery_SP("sp_addFocalPoints", param);
                return int.Parse(clsSqlHelper.ExecuteScalar(" select Max(FocalPointsID) as FocalPointsID from FocalPoints ").ToString());
            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public int UpdateFocalPoints(FocalPoints newFocalPoints, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[7];

                param[0] = new SqlParameter("@FocalPointsID", newFocalPoints.FocalPointsID);
                param[1] = new SqlParameter("@FocalPointsUser", newFocalPoints.FocalPointsUser);
                param[2] = new SqlParameter("@FocalPointsSector", newFocalPoints.FocalPointsSector);
                param[3] = new SqlParameter("@FocalPointsArea", newFocalPoints.FocalPointsArea);
                param[4] = new SqlParameter("@LastModifiedBy", newFocalPoints.LastModifiedBy);
                param[5] = new SqlParameter("@LastModifiedDate", newFocalPoints.LastModifiedDate);
                param[6] = new SqlParameter("@FocalPointsNotification", newFocalPoints.FocalPointsNotification);

                savingReport = " Data Has been Saved.";

                clsSqlHelper.executeNonQuery_SP("sp_updateFocalPoints", param);
                return int.Parse(clsSqlHelper.ExecuteScalar(" select Max(FocalPointsID) as FocalPointsID from FocalPoints ").ToString());
            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }


        public DataTable GetFocalPoints(string strwhere)
        {
            string sql = "Select * from GetFocalPoints " + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }

        public DataTable FocalPointsData(string FocalPointsUser)
        {
            string sql = "select f.FocalPointsID, f.FocalPointsUser, f.FocalPointsSector, f.FocalPointsArea, f.SectorInterestName, f.AreaInterestName, count(*) as Total, f.FocalPointsNotification "
            + " from GetFocalPoints f join GetSubscriber s on s.InterestSector = f.FocalPointsSector and s.InterestArea = f.FocalPointsArea "
            + " where FocalPointsUser = " + FocalPointsUser + " group by f.FocalPointsID, f.FocalPointsUser, f.FocalPointsSector, f.FocalPointsArea, f.SectorInterestName, f.AreaInterestName, f.FocalPointsNotification "
            + " order by f.SectorInterestName";

            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }

        public virtual bool DeleteFocalPoints(string FocalPointsID)
        {
            try
            {
                string sql = " Delete from FocalPoints where FocalPointsID =" + FocalPointsID;
                clsSqlHelper.ExecuteNonQuery(sql).ToString();
                return true;
            }

            catch (Exception ex)
            {


                return false;

            }

        }


        public int CustomUpdateFocalPoints(string strwhere)
        {
            string sql = "UPDATE FocalPoints SET " + strwhere;
            return clsSqlHelper.ExecuteNonQuery(sql);

        }
    }
}
