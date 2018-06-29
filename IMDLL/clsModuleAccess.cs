using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IMDLL
{
   
    public class ModuleAccess
	{
	public int ModuleAccessID;
	public int ModuleID;
	public int UserID;
	public int Doneby;
	public DateTime DoneDate;
	public Boolean Viewing;
	public int SaveModuleAccess(ModuleAccess newModuleAccess, out string savingReport)
	{
	 try {
		SqlParameter[] param = new SqlParameter[6];

		param[0] = new SqlParameter("@ModuleAccessID", newModuleAccess.ModuleAccessID); 
		param[1] = new SqlParameter("@ModuleID", newModuleAccess.ModuleID); 
		param[2] = new SqlParameter("@UserID", newModuleAccess.UserID); 
		param[3] = new SqlParameter("@Doneby", newModuleAccess.Doneby); 
		param[4] = new SqlParameter("@DoneDate", newModuleAccess.DoneDate); 
		param[5] = new SqlParameter("@Viewing", newModuleAccess.Viewing); 

		savingReport = " Data Has been Saved.";

		  clsSqlHelper.executeNonQuery_SP("sp_addModuleAccess", param);
          return int.Parse(clsSqlHelper.ExecuteScalar(" select Max(ModuleAccessID) as ModuleAccessID from ModuleAccess ").ToString());
	}

	catch (Exception ex){

		savingReport = ex.Message;
		return 0;

	}
	}

	public int UpdateModuleAccess(ModuleAccess newModuleAccess, out string savingReport)
	{
	 try {
		SqlParameter[] param = new SqlParameter[6];

		param[0] = new SqlParameter("@spModuleAccessID", newModuleAccess.ModuleAccessID);
		param[1] = new SqlParameter("@ModuleID", newModuleAccess.ModuleID);
		param[2] = new SqlParameter("@UserID", newModuleAccess.UserID);
		param[3] = new SqlParameter("@Doneby", newModuleAccess.Doneby);
		param[4] = new SqlParameter("@DoneDate", newModuleAccess.DoneDate);
		param[5] = new SqlParameter("@Viewing", newModuleAccess.Viewing);

		savingReport = " Data Has been Saved.";

		return clsSqlHelper.executeNonQuery_SP("sp_updateModuleAccess", param);

	}

	catch (Exception ex){

		savingReport = ex.Message;
		return 0;

	}
	}



         public DataTable getModuleAccess(string strwhere)
        {
            string sql = "Select * from getModuleAccess " + strwhere;
            return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
        }



        public int DeleteModuleAccess(string ModuleAccessID)
        {
            string sql = " Delete from ModuleAccess where ModuleAccessID =" + ModuleAccessID;
            return int.Parse(clsSqlHelper.ExecuteNonQuery(sql).ToString());

        }



        public int CountModuleAccess(String strwhere)
        {
            string sql = " Select count(ModuleAccessID)  as  ModuleAccessID  from getModuleAccess  " + strwhere;
            return int.Parse(clsSqlHelper.ExecuteScalar(sql).ToString());

        }


	}


}   
