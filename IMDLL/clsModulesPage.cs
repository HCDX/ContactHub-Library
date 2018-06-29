using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IMDLL
{

    public class ModulesPage
    {
        public int ModulesPageID;
        public string PageName;
        public string PageDescription;
        public string PageUrl;
        public int ModuleID;
        public int SaveModulesPage(ModulesPage newModulesPage, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@ModulesPageID", newModulesPage.ModulesPageID);
                param[1] = new SqlParameter("@PageName", newModulesPage.PageName);
                param[2] = new SqlParameter("@PageDescription", newModulesPage.PageDescription);
                param[3] = new SqlParameter("@PageUrl", newModulesPage.PageUrl);
                param[4] = new SqlParameter("@ModuleID", newModulesPage.ModuleID);
                savingReport = " Data Has been Saved.";

                clsSqlHelper.executeNonQuery_SP("sp_addModulesPage", param);
                return int.Parse(clsSqlHelper.ExecuteScalar(" select Max(ModulesPageID) as ModulesPageID from ModulesPage ").ToString());
            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public int UpdateModulesPage(ModulesPage newModulesPage, out string savingReport)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@ModulesPageID", newModulesPage.ModulesPageID);
                param[1] = new SqlParameter("@PageName", newModulesPage.PageName);
                param[2] = new SqlParameter("@PageDescription", newModulesPage.PageDescription);
                param[3] = new SqlParameter("@PageUrl", newModulesPage.PageUrl);
                param[4] = new SqlParameter("@ModuleID", newModulesPage.ModuleID);
                savingReport = " Data Has been Saved.";

                clsSqlHelper.executeNonQuery_SP("sp_updateModulesPage", param);
                return int.Parse(clsSqlHelper.ExecuteScalar(" select Max(ModulesPageID) as ModulesPageID from ModuleSub ").ToString());
            }

            catch (Exception ex)
            {

                savingReport = ex.Message;
                return 0;

            }
        }

        public DataTable GetModulesPageSet(string strwhere)
        {
            string sql = "Select * from GetModulesPageSet " + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }
        public DataTable GetModulesPage(string strwhere)
        {
            string sql = "Select * from GetModulesPage " + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }


        public DataTable GetModuleMenu()
        {
            string sql = "select ModuleMenuID, MenuName, MenuDesc  from [dbo].[ModuleMenu]  order by ModuleMenuID ";
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }


        public virtual bool DeleteModulesPage(string ModulesPageID)
        {
            try
            {
                string sql = "  Delete from ModulesPage where ModulesPageID =" + ModulesPageID;
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
