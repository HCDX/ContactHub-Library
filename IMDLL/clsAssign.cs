using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IMDLL
{


    public class Assign
    {
        public int AssignID;
        public int AssignProfileID;
        public int AssignUserID;
        public int LastModifiedBy;
        public DateTime LastModifiedDate;

        public int SaveAssign(Assign newAssign, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@AssignID", newAssign.AssignID);
                param[1] = new SqlParameter("@AssignProfileID", newAssign.AssignProfileID);
                param[2] = new SqlParameter("@AssignUserID", newAssign.AssignUserID);
                param[3] = new SqlParameter("@LastModifiedBy", newAssign.LastModifiedBy);
                param[4] = new SqlParameter("@LastModifiedDate", newAssign.LastModifiedDate);

                savingReport = " Data Has been Saved.";

                return clsSqlHelper.executeNonQuery_SP("sp_addAssign", param);

            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public int UpdateAssign(Assign newAssign, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@AssignID", newAssign.AssignID);
                param[1] = new SqlParameter("@AssignProfileID", newAssign.AssignProfileID);
                param[2] = new SqlParameter("@AssignUserID", newAssign.AssignUserID);
                param[3] = new SqlParameter("@LastModifiedBy", newAssign.LastModifiedBy);
                param[4] = new SqlParameter("@LastModifiedDate", newAssign.LastModifiedDate);

                savingReport = " Data Has been Saved.";

                return clsSqlHelper.executeNonQuery_SP("sp_updateAssign", param);

            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }


        public DataTable GetAssign(string strwhere)
        {
            string sql = "Select * from GetAssign " + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }


        public virtual bool DeleteAssign(string AssignID)
        {
            try
            {
                string sql = " Delete from Modules where AssignID =" + AssignID;
                clsSqlHelper.ExecuteNonQuery(sql).ToString();
                return true;
            }

            catch (Exception ex)
            {


                return false;

            }

        }

        public int CounAssign(String strwhere)
        {
            string sql = " Select count(AssignID)  as  ModuleID  from GetAssign  " + strwhere;
            return int.Parse(clsSqlHelper.ExecuteScalar(sql).ToString());

        }
    }



}
