using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IMDLL
{


  public class ModuleAccessDetails
	{
	public int ModuleAccessDetailsID;
	public int UserID;
	public Boolean   Dashboard;
	public Boolean Mgt;
	public Boolean  Report;
	public Boolean Admin;
	public Boolean users;
    public Boolean Config;
	public int Lastmodifiedby;
	public DateTime LastModifiedDate;
	public int ModuleAccessID;
	public string ModuleAccess;
	public int SaveModuleAccessDetails(ModuleAccessDetails newModuleAccessDetails, out string savingReport)
	{
	 try {
		SqlParameter[] param = new SqlParameter[12];

		param[0] = new SqlParameter("@ModuleAccessDetailsID", newModuleAccessDetails.ModuleAccessDetailsID); 
		param[1] = new SqlParameter("@UserID", newModuleAccessDetails.UserID); 
		param[2] = new SqlParameter("@Dashboard", newModuleAccessDetails.Dashboard); 
		param[3] = new SqlParameter("@Mgt", newModuleAccessDetails.Mgt); 
		param[4] = new SqlParameter("@Report", newModuleAccessDetails.Report); 
		param[5] = new SqlParameter("@Admin", newModuleAccessDetails.Admin); 
		param[6] = new SqlParameter("@users", newModuleAccessDetails.users); 
		param[7] = new SqlParameter("@Config", newModuleAccessDetails.Config); 
		param[8] = new SqlParameter("@Lastmodifiedby", newModuleAccessDetails.Lastmodifiedby); 
		param[9] = new SqlParameter("@LastModifiedDate", newModuleAccessDetails.LastModifiedDate); 
		param[10] = new SqlParameter("@ModuleAccessID", newModuleAccessDetails.ModuleAccessID); 
		param[11] = new SqlParameter("@ModuleAccess", newModuleAccessDetails.ModuleAccess); 

		savingReport = " Data Has been Saved.";

		return clsSqlHelper.executeNonQuery_SP("sp_addModuleAccessDetails", param);

	}

	catch (Exception ex){

		savingReport = ex.Message;
		return 0;

	}
	}

	public int UpdateModuleAccessDetails(ModuleAccessDetails newModuleAccessDetails, out string savingReport)
	{
	 try {
		SqlParameter[] param = new SqlParameter[12];

		param[0] = new SqlParameter("@spModuleAccessDetailsID", newModuleAccessDetails.ModuleAccessDetailsID);
		param[1] = new SqlParameter("@UserID", newModuleAccessDetails.UserID);
		param[2] = new SqlParameter("@Dashboard", newModuleAccessDetails.Dashboard);
		param[3] = new SqlParameter("@Mgt", newModuleAccessDetails.Mgt);
		param[4] = new SqlParameter("@Report", newModuleAccessDetails.Report);
		param[5] = new SqlParameter("@Admin", newModuleAccessDetails.Admin);
		param[6] = new SqlParameter("@users", newModuleAccessDetails.users);
		param[7] = new SqlParameter("@Config", newModuleAccessDetails.Config);
		param[8] = new SqlParameter("@Lastmodifiedby", newModuleAccessDetails.Lastmodifiedby);
		param[9] = new SqlParameter("@LastModifiedDate", newModuleAccessDetails.LastModifiedDate);
		param[10] = new SqlParameter("@ModuleAccessID", newModuleAccessDetails.ModuleAccessID);
		param[11] = new SqlParameter("@ModuleAccess", newModuleAccessDetails.ModuleAccess);

		savingReport = " Data Has been Saved.";

		return clsSqlHelper.executeNonQuery_SP("sp_updateModuleAccessDetails", param);

	}

	catch (Exception ex){

		savingReport = ex.Message;
		return 0;

	}
	}




    public DataTable getModuleAccessDetails(string strwhere)
    {
        string sql = "Select * from ModuleAccessDetails " + strwhere;
        return clsSqlHelper.ExecuteDataSet(sql).Tables[0];
    }



    public int DeleteModuleAccessDetails(string ModuleAccessDetailsID)
    {
        string sql = " Delete from ModuleAccessDetails where QipsEffetID =" + ModuleAccessDetailsID;
        return int.Parse(clsSqlHelper.ExecuteNonQuery(sql).ToString());

    }



    public int CountModuleAccessDetailsID(String strwhere)
    {
        string sql = " Select count(ModuleAccessDetailsID)  as  ModuleAccessDetailsID  from ModuleAccessDetails  " + strwhere;
        return int.Parse(clsSqlHelper.ExecuteScalar(sql).ToString());

    }



	}



}   
