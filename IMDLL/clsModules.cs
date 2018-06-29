using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IMDLL
{


    public class Modules
    {
        public int ModuleID;
        public string ModuleName;
        public string ModuleDescription;
        public int LastModifiedBy;
        public DateTime LastModifiedDate;

        public int SaveModules(Modules newModules, out string savingReport)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@ModuleID", newModules.ModuleID);
                param[1] = new SqlParameter("@ModuleName", newModules.ModuleName);
                param[2] = new SqlParameter("@ModuleDescription", newModules.ModuleDescription);
                param[3] = new SqlParameter("@LastModifiedBy", newModules.LastModifiedBy);
                param[4] = new SqlParameter("@LastModifiedDate", newModules.LastModifiedDate);

                savingReport = " Data Has been Saved.";

                clsSqlHelper.executeNonQuery_SP("sp_addModules", param);
                return int.Parse(clsSqlHelper.ExecuteScalar(" select Max(ModuleID) as ModuleID from Modules ").ToString());
            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public int UpdateModules(Modules newModules, out string savingReport)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@ModuleID", newModules.ModuleID);
                param[1] = new SqlParameter("@ModuleName", newModules.ModuleName);
                param[2] = new SqlParameter("@ModuleDescription", newModules.ModuleDescription);
                param[3] = new SqlParameter("@LastModifiedBy", newModules.LastModifiedBy);
                param[4] = new SqlParameter("@LastModifiedDate", newModules.LastModifiedDate);



                savingReport = " Data Has been Saved.";

                return clsSqlHelper.executeNonQuery_SP("sp_updateModules", param);

            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }


        public DataTable GetModules(string strwhere)
        {
            string sql = "Select * from GetModules " + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }

 
        public virtual bool DeleteModules(string ModuleID)
        {
            try
            {
                string sql = " Delete from Modules where ModuleID =" + ModuleID;
                clsSqlHelper.ExecuteNonQuery(sql).ToString();
                return true;
            }

            catch (Exception ex)
            {


                return false;

            }

        }

        public int CountModules(String strwhere)
        {
            string sql = " Select count(ModuleID)  as  ModuleID  from GetModules  " + strwhere;
            return int.Parse(clsSqlHelper.ExecuteScalar(sql).ToString());

        }
    }



}
