using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace IMDLL
{
    public class clsSqlHelper
    {

        public static SqlConnection oConn;
        public static SqlCommand oCmd = new SqlCommand();

        public static string thisConnectionString = "if you are using Azure, please add your connexion string here";//in my case I used Azure

        // or if you are using MSQL Server uncomment and use this (this means, you have to comment line 17 for Azure): 
        //public static string thisConnectionString = "data source=SQL Server name; User ID=your username; Password=yourpassword; Initial Catalog=your ContactHub database; Integrated Security=false;  Connection Timeout=0; Max Pool Size=100000;";



        public clsSqlHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        /// <summary>
        /// This method returns a dataset
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <returns></returns>
        static public DataSet getDataSet_SP(string storedProcName)
        {

            DataSet ds = new DataSet();




            SqlConnection oConn = new SqlConnection(thisConnectionString);

            try
            {
                oConn.Open();                                                       // Tempory until DAAB implementation
            }
            catch { }

            oCmd = new SqlCommand(storedProcName, oConn);
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(oCmd);
            adp.Fill(ds);
            ds.Dispose();

            oConn.Close();

            return ds;

        }

        /// <summary>
        /// Method to return dataset with parameters
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        static public DataSet getDataSet_SP(string storedProcName, SqlParameter[] param)
        {

            DataSet ds = new DataSet();

            SqlConnection oConn = new SqlConnection(thisConnectionString);

            try
            {
                oConn.Open();                                                       // Tempory until DAAB implementation
            }
            catch { }

            oCmd = new SqlCommand(storedProcName, oConn);
            oCmd.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < param.Length; i++)
            {
                oCmd.Parameters.Add(param[i]);
            }

            SqlDataAdapter adp = new SqlDataAdapter(oCmd);

            adp.Fill(ds);
            oCmd.Parameters.Clear();
            ds.Dispose();
            oConn.Close();

            return ds;

        }


        /// <summary>
        /// Method to retun integer value
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <returns></returns>
        static public int executeScaler_SP(string storedProcName)
        {
            int retVal = 0;

            SqlConnection oConn = new SqlConnection(thisConnectionString);

            try
            {
                oConn.Open();                                                       // Tempory until DAAB implementation
            }
            catch { }


            oCmd = new SqlCommand(storedProcName, oConn);
            oCmd.CommandType = CommandType.StoredProcedure;

            retVal = Convert.ToInt32(oCmd.ExecuteScalar());

            oConn.Close();
            return retVal;

        }
        static public object ExecuteScalar(string sql, SqlParameter[] param)
        {



            SqlConnection oConn = new SqlConnection(thisConnectionString);
            SqlCommand ocmd = new SqlCommand(sql, oConn);
            try
            {
                oConn.Open();                                                       // Tempory until DAAB implementation
            }
            catch { }
            for (int i = 0; i < param.Length; i++)
            {
                ocmd.Parameters.Add(param[i]);
            }

            object retVal = ocmd.ExecuteScalar();
            oConn.Close();
            return retVal;

        }


        /// <summary>
        /// Method to return integer with parameter
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        static public int executeScaler_SP(string storedProcName, SqlParameter[] param)
        {
            int retVal = 0;

            SqlConnection oConn = new SqlConnection(thisConnectionString);

            //try
            //{
            oConn.Open();                                                       // Tempory until DAAB implementation
            //}
            //catch {
            //    
            //}

            oCmd = new SqlCommand(storedProcName, oConn);
            oCmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < param.Length; i++)
            {
                oCmd.Parameters.Add(param[i]);
            }

            retVal = Convert.ToInt32(oCmd.ExecuteScalar());

            oConn.Close();
            return retVal;

        }


        /// <summary>
        /// Method to execute query with parameters
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        static public int executeNonQuery_SP(string storedProcName, SqlParameter[] param)
        {
            int retVal = 0;

            SqlConnection oConn = new SqlConnection(thisConnectionString);

            try
            {
                oConn.Open();                                                       // Tempory until DAAB implementation
            }
            catch { }

            oCmd = new SqlCommand(storedProcName, oConn);
            oCmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < param.Length; i++)
            {
                oCmd.Parameters.Add(param[i]);
            }
            retVal = oCmd.ExecuteNonQuery();

            oConn.Close();

            return retVal;

        }


        static public object ExecuteScalar(string sql)
        {


            SqlConnection oConn = new SqlConnection(thisConnectionString);
            SqlCommand ocmd = new SqlCommand(sql, oConn);
            try
            {
                oConn.Open();                                                       // Tempory until DAAB implementation
            }
            catch { }


            object retVal = ocmd.ExecuteScalar();
            oConn.Close();
            return retVal;

        }



        static public DataSet ExecuteDataSet(string sql)
        {

            DataSet ds = new DataSet();
            SqlConnection oConn = new SqlConnection(thisConnectionString);
            try
            {
                oConn.Open();
            }
            catch { }
            SqlDataAdapter da = new SqlDataAdapter(sql, oConn);
            da.SelectCommand.CommandTimeout = 120;
            da.Fill(ds);
            return ds;
            oConn.Close();

        }
        static public DataSet ExecuteDataSet(string sql, SqlParameter[] param)
        {

            SqlConnection cnn = new SqlConnection(thisConnectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            for (int i = 0; i < param.Length; i++)
            {
                da.SelectCommand.Parameters.Add(param[i]);
            }
            da.Fill(ds);
            return ds;

        }
        static public int ExecuteNonQuery(string sql, SqlParameter[] param)
        {
            string thisConnectionString = "data source=MIN-BKO-LB-CSS\\SMSSERVER; User ID=sa; Password=Qwert123!@#; Initial Catalog=smsdb; Integrated Security=false;  Connection Timeout=0; Max Pool Size=100000;";
            SqlConnection cnn = new SqlConnection(thisConnectionString);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            for (int i = 0; i < param.Length; i++)
            {
                cmd.Parameters.Add(param[i]);
            }
            cnn.Open();
            int retval = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cnn.Close();
            return retval;
        }
        static public int ExecuteNonQuery(string sql)
        {

            SqlConnection cnn = new SqlConnection(thisConnectionString);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cnn.Open();
            int retval = cmd.ExecuteNonQuery();
            cnn.Close();
            return retval;

        }
    }
}
