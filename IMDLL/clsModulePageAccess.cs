using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IMDLL
{

     public class ModulePageAccess
	{
	public int ModulePageAccessID;
	public int PageID;
	public int ProfileID;
    public Boolean Access;
	 
	public int Doneby;
	public DateTime DoneDate;
	public int SaveModulePageAccess(ModulePageAccess newModulePageAccess, out string savingReport)
	{
	 try {
		SqlParameter[] param = new SqlParameter[6];

		param[0] = new SqlParameter("@ModulePageAccessID", newModulePageAccess.ModulePageAccessID); 
		param[1] = new SqlParameter("@PageID", newModulePageAccess.PageID);
        param[2] = new SqlParameter("@ProfileID", newModulePageAccess.ProfileID);
        param[3] = new SqlParameter("@Access", newModulePageAccess.Access); 
	 
		param[4] = new SqlParameter("@Doneby", newModulePageAccess.Doneby); 
		param[5] = new SqlParameter("@DoneDate", newModulePageAccess.DoneDate); 

		savingReport = " Data Has been Saved.";

		return clsSqlHelper.executeNonQuery_SP("sp_addModulePageAccess", param);

	}

	catch (Exception ex){

		savingReport = ex.Message;
		return 0;

	}
	}

	public int UpdateModulePageAccess(ModulePageAccess newModulePageAccess, out string savingReport)
	{
	 try {
		SqlParameter[] param = new SqlParameter[6];

		param[0] = new SqlParameter("@ModulePageAccessID", newModulePageAccess.ModulePageAccessID);
		param[1] = new SqlParameter("@PageID", newModulePageAccess.PageID);
        param[2] = new SqlParameter("@ProfileID", newModulePageAccess.ProfileID);
        param[3] = new SqlParameter("@Access", newModulePageAccess.Access);
		 
		param[4] = new SqlParameter("@Doneby", newModulePageAccess.Doneby);
		param[5] = new SqlParameter("@DoneDate", newModulePageAccess.DoneDate);

		savingReport = " Data Has been Saved.";

		return clsSqlHelper.executeNonQuery_SP("sp_updateModulePageAccess", param);

	}

	catch (Exception ex){

		savingReport = ex.Message;
		return 0;

	}
	}



    public DataTable GetModulePageAccessProc(string strProfileID)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ProfileID", strProfileID);

            DataTable Dt = clsSqlHelper.getDataSet_SP("GetModulePageAccessProc", param).Tables[0];
            return Dt;
        }

        catch (Exception ex)
        {


            DataTable DtError = new DataTable();
            return DtError;
        }
    }


    public DataTable GetModulePageAccessProcModule(string strProfileID, string StrModule)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@ProfileID", strProfileID);

            param[1] = new SqlParameter("@ModuleID", StrModule);

            DataTable Dt = clsSqlHelper.getDataSet_SP("GetModulePageAccessProcModule", param).Tables[0];
            return Dt;
        }

        catch (Exception ex)
        {


            DataTable DtError = new DataTable();
            return DtError;
        }
    }

    public DataTable GetModulePageAccess(string strwhere)
    {
        string sql = "Select * from GetModulePageAccess " + strwhere;
        return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
    }



    public int DeleteModules(string ModulePageAccessID)
    {
        string sql = " Delete from ModulePageAccess where ModulePageAccessID =" + ModulePageAccessID;
        return int.Parse(clsSqlHelper.ExecuteNonQuery(sql).ToString());

    }



	}



}
